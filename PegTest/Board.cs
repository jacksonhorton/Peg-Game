/*
 * @file:
 * @authors: William Hayes & Jackson Horton
 * @date:4/6/2023
 * @brief:
 * 
 * 
 * 
 */
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
using System.Collections;
using System.Threading;

namespace PegTest
{
    public class Board : UIElement
    {
        private List<(int startPos, int midPos, int endPos)> previousMoves = new List<(int startPos, int midPos, int endPos)>();

        private int numOfRows;
        private int numOfHoles;
        private int numOfPegs;
        public Dictionary<int, (int, int)> PegPoints;
        public List<Hole> holes;
        public List<Ellipse> renderedHoles;
        private List<Ellipse> renderedMoves;
        private BoardWindow window;
        private CBValidMove moveChecker;

        // Constructor
        public Board(int numOfRows, int numOfHoles, int numOfPegs, BoardWindow window)
        {
            this.window = window;
            moveChecker = new CBValidMove();

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
            this.numOfHoles = numOfHoles;
            this.numOfPegs = numOfPegs;


            // generates ellipses and Hole objects for each peg
            for (int i=0; i<numOfHoles; i++)
            {
                string name = "Peg" + i;
                Ellipse e;

                // the center peg on this board is empty when the game starts
                if (i == 0)
                {
                    // invisible ellipse
                    e = RenderEllipse(i, name, Brushes.Transparent, 0);
                    // creates hole object for this ellipse and adds to list; empty since empty hole
                    holes.Add(new Hole(i, false));
                }
                else
                {
                    e = RenderEllipse(i, name, Brushes.White, 1.0);
                    // creates hole object for this ellipse and adds to list
                    holes.Add(new Hole(i, true));
                }

                renderedHoles.Add(e);

                
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
        public void undoMove()
        {
            if (previousMoves.Count == 0)
            {
                // no moves to undo
                return;
            }

            // get current move and remove from list
            int last = previousMoves.Count - 1;
            var move = previousMoves[last];
            previousMoves.RemoveAt(last);

            // modifies hole objects to reverse the given move
            foreach (Hole h in holes)
            {
                if (h.GetPosition() == move.startPos)
                {
                    h.setFilled(true);
                    numOfPegs++;
                }

                else if (h.GetPosition() == move.midPos)
                {
                    h.setFilled(true);
                    numOfPegs++;
                }

                else if (h.GetPosition() == move.endPos)
                {
                    h.setFilled(false);
                    numOfPegs--;
                }
            }


            // modifies the visible ellipses to reflect the move change
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



                // makes the ellipse transparent; is NOT deleted but no longer visible or clickable
                if (position == move.startPos)
                {
                    e.Fill = Brushes.White;
                    e.Opacity = 100;
                }
                else if (position == move.midPos)
                {
                    e.Fill = Brushes.White;
                    e.Opacity = 100;
                }
                else if (position == move.endPos)
                {
                    e.Fill = Brushes.Transparent;
                }


            }



        }

        public bool MovePeg(int start, int final)
        {
            var possibleMoves = moveChecker.GetValidMoves(start, holes);
            var move = possibleMoves.Find(x => x.endPos == final);

            if (!moveChecker.isPossibleMove(move.startPos, move.midPos, move.endPos, holes))
            {
                // if the move is not valid, return false
                return false;
            }

            
            // modifies the holes container to reflect the move
            foreach(Hole h in holes)
            {
                if (h.GetPosition() == move.startPos)
                {
                    h.setFilled(false);
                    numOfPegs--;
                }

                else if (h.GetPosition() == move.midPos)
                {
                    h.setFilled(false);
                    numOfPegs--;
                }

                else if (h.GetPosition() == move.endPos)
                {
                    h.setFilled(true);
                    numOfPegs++;
                }
            }

            // modifies the visible ellipses to reflect the move change
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



                // makes the ellipse transparent; is NOT deleted but no longer visible or clickable
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

            // add to previous moves stack
            previousMoves.Add(move);


            // check if there are any valid moves left
            if (!moveChecker.anyValidMoves(holes)) {
                CloseGame(window);
            }

            return true;
        }

        async void CloseGame(Window w)
        {
            await Task.Delay(500);


            //game over window load
            GameOverWindow gameover = new GameOverWindow(numOfPegs);
            gameover.Show();

            // close game window
            w.Close();

        }






        /*
         * Movechecker visual functions/generate ellipses for moves
         */


        // name represents where the move is (upper left = UL, Right = R, etc.)
        protected void generateMoveEllipse (int position, string name)
        {
            // generates a new ellipse at given position and renders it
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
            List<(int startPos, int midPos, int endPos)> validMoves = moveChecker.GetValidMoves(position, holes);

            foreach (var move in validMoves)
            {
                Ellipse e = RenderEllipse(move.endPos, "Move" + move.endPos, Brushes.Green, 0.5);
                renderedMoves.Add(e);
            }

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

        

    }
}
