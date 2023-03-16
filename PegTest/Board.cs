using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace PegTest
{
    public class Board : UIElement
    {
        private int numOfRows;
        private int numOfPegs;
        public Dictionary<int, (int, int)> PegPoints;
        private List<Hole> holes;
        private List<Ellipse> renderedHoles;
        private List<Ellipse> renderedMoves;
        private BoardWindow window;

        // Constructor
        public Board(int numOfRows, int numOfPegs, BoardWindow window)
        {
            this.window = window;

            PegPoints = new Dictionary<int, (int,int)>();
            PegPoints.Add(0, (260, 282));
            PegPoints.Add(1, (218, 214));
            PegPoints.Add(2, (299, 214));
            PegPoints.Add(3, (179, 146));
            PegPoints.Add(4, (258, 146));
            PegPoints.Add(5, (339, 146));
            PegPoints.Add(6, (141,79));
            PegPoints.Add(7, (219, 79));
            PegPoints.Add(8, (299, 79));
            PegPoints.Add(9, (380, 79));
            PegPoints.Add(10, (100, 12));
            PegPoints.Add(11, (179, 12));
            PegPoints.Add(12, (258, 12));
            PegPoints.Add(13, (339, 12));
            PegPoints.Add(14, (420, 12));


            // initializes lists
            renderedHoles = new List<Ellipse>();
            renderedMoves = new List<Ellipse>();
            holes = new List<Hole>();
            
            this.numOfRows = numOfRows;
            this.numOfPegs = numOfPegs;


            // generates ellipses and Hole objects for each peg
            for (int i=0; i<numOfPegs; i++)
            {
                string name = "Peg" + i;
                Ellipse e;

                if (i == 4)
                {
                    // invisible ellipse
                    e = RenderEllipse(i, name, Brushes.Transparent, 0);
                }
                else
                {
                    e = RenderEllipse(i, name, Brushes.White, 1.0);
                }

                renderedHoles.Add(e);

                // creates hole object for this ellipse and adds to list
                holes.Add(new Hole(i));
            }
        }


        public Ellipse RenderEllipse(int position, string name, SolidColorBrush color, double opacity = 1)
        {
            Ellipse temp = new Ellipse();

            // gets the left and bottom margin from the dictionary
            (int left, int bottom) margin = PegPoints[position];

            // fill in ellipse data, some is constant
            temp.Width = 47;
            temp.Height = 47;
            temp.Margin = new Thickness(margin.left, 0, 0, margin.bottom);
            temp.HorizontalAlignment = HorizontalAlignment.Left;
            temp.VerticalAlignment = VerticalAlignment.Bottom;
            temp.Fill = color;
            // Names ellipse so it can identify where it is
            temp.Name = name;
            temp.Opacity = opacity;

            // adds to grid with game board
            window.Game_Board_Grid.Children.Add(temp);

            return temp;
        }




        /*
         * Moving Logic
         */
        public bool MovePeg(int start, int final)
        {
            var possibleMoves = GetValidMoves(start);
            var move = possibleMoves.Find(x => x.endPos == final);

            if (GetHole(move.endPos).isFilled())
            {
                // Can't move if the final hole already has a peg in it
                Console.WriteLine("Peg in destination hole, can't move from " + move.startPos + " to " + move.endPos);
                return false;
            }
            else if (!GetHole(move.startPos).isFilled())
            {
                // can't move start peg if there isn't a peg there
                Console.WriteLine("No peg in start hole " + start);
                return false;
            }
            else if (!GetHole(move.midPos).isFilled())
            {
                // not intermediate peg present -> illegal move
                Console.WriteLine("No intermediate peg to jump over at " + move.endPos);
                return false;
            }

            // if all checks pass, move is valid; make move
            Console.WriteLine("Moving " + move.startPos + " to " + move.endPos);
            
            // TODO: Add appropriate logic to move the peg from the start position and move everything from hole object to hole object and not just update the gui
            foreach(Hole h in holes)
            {
                if (h.GetPosition() == move.startPos)
                {
                    h.setFilled(false);
                }

                else if (h.GetPosition() == move.midPos)
                {
                    h.setFilled(false);
                }

                else if (h.GetPosition() == move.endPos)
                {
                    h.setFilled(true);
                }
            }

            foreach (Ellipse e in renderedHoles)
            {
                Ellipse ellipse = (Ellipse)e;
                int position = -1;
                // gets position of the ellipse
                if (ellipse.Name.Contains("Peg"))
                {
                    position = Int32.Parse(ellipse.Name.Substring(3));
                }
                else if (ellipse.Name.Contains("Move"))
                {
                    position = Int32.Parse(ellipse.Name.Substring(4));
                }



                // waits until after the foreach to modify the ellipses
                if (position == move.startPos)
                {
                    e.Fill = Brushes.Transparent;
                }
                else if (position == move.midPos)
                {
                    e.Fill = Brushes.Transparent;
                }
                else if (position == move.endPos)
                {
                    e.Fill = Brushes.White;
                    e.Opacity = 100;
                }


            }


            return true;
        }






        /*
         * Movechecker visual functions/generate ellipses for moves
         */


        // name represents where the move is (upper left = UL, Right = R, etc.)
        protected void generateMoveEllipse (int position, string name)
        {
            Ellipse e;
            
            e = RenderEllipse(position, "Move" + position, Brushes.Green, 0.5);

            renderedMoves.Add(e);
        }


        /*
         * Move Checker logic functions
         */

        // handles creation of move ellipses and check valid moves and deletes previously generated moves
        public void MoveCheck(int position)
        {
            // clears previously highlighted possible moves from game board
            RemoveMoveEllipses();

            // calculate possible moves
            _ = GetValidMoves(position);

        }

        // clears previously highlighted possible moves from game board
        public void RemoveMoveEllipses()
        {
            foreach (Ellipse e in renderedMoves)
            {
                window.Game_Board_Grid.Children.Remove(e);
            }

            renderedMoves.Clear();
        }

        // checks if hole exists / is within bounds
        private bool exists(int position)
        {
            if (position >= 0 && position < numOfPegs)
                return true;
            else
                return false;
        }


        private bool isPossibleMove(int start, int mid, int end)
        {
            if (exists(start) && exists(mid) && exists(end))  // checks if middle/intermediate hole is filled
            {
                // checks if final hole is not filled
                if (GetHole(start).isFilled() && GetHole(mid).isFilled() && !GetHole(end).isFilled())
                {
                    // checks for moves taking place accross different rows
                    if (Math.Abs(getRow(end) - getRow(start)) == 2)
                    {
                        return true;
                    }
                    // checks for moves on same row
                    if (getRow(end) == getRow(start) && Math.Abs(start - end) == 2)
                    {
                        return true;
                    }

                }
            }

            return false;
        }

        private List<(int startPos, int midPos, int endPos)> GetValidMoves(int startPosition)
        {
            // possibly use a map for better lookup
            List<(int, int, int)> moveList = new List<(int startPos, int midPos, int endPos)> { };


            int midPos;
            int endPos;

            // check upper left 
            midPos = startPosition - getRow(startPosition) - 1;
            endPos = midPos - getRow(midPos) - 1;
            //Console.WriteLine(startPosition + " " + midPos + " " + endPos);
            if (isPossibleMove(startPosition, midPos, endPos))
            {
                Console.WriteLine("UL");
                moveList.Add((startPosition, midPos, endPos));
                generateMoveEllipse(endPos, "UL");
            }

            // check upper right 
            midPos = startPosition - getRow(startPosition);
            endPos = midPos - getRow(midPos);
            //Console.WriteLine(startPosition + " " + midPos + " " + endPos);
            if (isPossibleMove(startPosition, midPos, endPos))
            {
                Console.WriteLine("UR");
                moveList.Add((startPosition, midPos, endPos));
                generateMoveEllipse(endPos, "UR");
            }

            // check lower right 
            midPos = startPosition + getRow(startPosition) + 2;
            endPos = midPos + getRow(midPos) + 2;
            //Console.WriteLine(startPosition + " " + midPos + " " + endPos);
            if (isPossibleMove(startPosition, midPos, endPos))
            {
                Console.WriteLine("LR");
                moveList.Add((startPosition, midPos, endPos));
                generateMoveEllipse(endPos, "LR");
            }

            // check lower left
            midPos = startPosition + getRow(startPosition) + 1;
            endPos = midPos + getRow(midPos) + 1;
            //Console.WriteLine(startPosition + " " + midPos + " " + endPos);
            if (isPossibleMove(startPosition, midPos, endPos))
            {
                Console.WriteLine("LL");
                moveList.Add((startPosition, midPos, endPos));
                generateMoveEllipse(endPos, "L");
            }

            // check left
            midPos = startPosition - 1;
            endPos = midPos - 1;
            //Console.WriteLine(startPosition + " " + midPos + " " + endPos);
            if (isPossibleMove(startPosition, midPos, endPos))
            {
                Console.WriteLine("L");
                moveList.Add((startPosition, midPos, endPos));
                generateMoveEllipse(endPos, "L");
            }

            // check right
            midPos = startPosition + 1;
            endPos = midPos + 1;
            //Console.WriteLine(startPosition + " " + midPos + " " + endPos);
            if (isPossibleMove(startPosition, midPos, endPos))
            {
                Console.WriteLine("R");
                moveList.Add((startPosition, midPos, endPos));
                generateMoveEllipse(endPos, "R");
            }





            return moveList;
        }


        private Hole GetHole(int position)
        {
            return holes[position];
        }


        private int getRow(int position)
        {
            // returns the row a peg at  given position should be found at (0-indexed)
            int row = 0;
            for (int i = 0; i < numOfRows; i++)
            {
                // magical formula to determine what row the pos it at
                position = position - i - 1;
                if (position < 0)
                {
                    row = i;
                    return row;
                }
            }

            return 0;
        }

    }
}
