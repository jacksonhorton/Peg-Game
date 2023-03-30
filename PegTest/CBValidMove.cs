using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PegTest
{
    internal class CBValidMove : ValidStrat
    {

        public const int NumOfHoles = 15;
        public const int NumOfRows = 5;

        public bool anyValidMoves(List<Hole> holes)
        {
            // start from first peg
            for (int i = 0; i < NumOfHoles; i++)
            {
                // gets a list of possible valid moves for a peg
                var validmoves = GetValidMoves(i, holes);
                
                // checks if any of the possible valid moves 
                for (int j = 0; j < validmoves.Count; j++)
                {
                    if (isPossibleMove(validmoves[j].startPos, validmoves[j].midPos, validmoves[j].endPos, holes))
                    {
                        // return true, there is at least one possible move
                        return true;
                    }
                }
            }

            return false;
        }


        public override bool isPossibleMove(int start, int mid, int end, List<Hole> holes)
        {
            if (exists(start) && exists(mid) && exists(end))  // checks if middle/intermediate hole is filled
            {
                // checks if final hole is not filled
                if (holes[start].isFilled() && holes[mid].isFilled() && !holes[end].isFilled())
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

        public List<(int startPos, int midPos, int endPos)> GetValidMoves(int startPosition, List<Hole> holes)
        {
            // possibly use a map for better lookup
            List<(int, int, int)> moveList = new List<(int startPos, int midPos, int endPos)> { };

            int midPos;
            int endPos;

            // check upper left 
            midPos = startPosition - getRow(startPosition) - 1;
            endPos = midPos - getRow(midPos) - 1;
            if (isPossibleMove(startPosition, midPos, endPos, holes))
            {
                Console.WriteLine("UL");
                moveList.Add((startPosition, midPos, endPos));
            }

            // check upper right 
            midPos = startPosition - getRow(startPosition);
            endPos = midPos - getRow(midPos);
            if (isPossibleMove(startPosition, midPos, endPos, holes))
            {
                Console.WriteLine("UR");
                moveList.Add((startPosition, midPos, endPos));
            }

            // check lower right 
            midPos = startPosition + getRow(startPosition) + 2;
            endPos = midPos + getRow(midPos) + 2;
            if (isPossibleMove(startPosition, midPos, endPos, holes))
            {
                Console.WriteLine("LR");
                moveList.Add((startPosition, midPos, endPos));
            }

            // check lower left
            midPos = startPosition + getRow(startPosition) + 1;
            endPos = midPos + getRow(midPos) + 1;
            if (isPossibleMove(startPosition, midPos, endPos, holes))
            {
                Console.WriteLine("LL");
                moveList.Add((startPosition, midPos, endPos));
            }

            // check left
            midPos = startPosition - 1;
            endPos = midPos - 1;
            if (isPossibleMove(startPosition, midPos, endPos, holes))
            {
                Console.WriteLine("L");
                moveList.Add((startPosition, midPos, endPos));
            }

            // check right
            midPos = startPosition + 1;
            endPos = midPos + 1;
            if (isPossibleMove(startPosition, midPos, endPos, holes))
            {
                Console.WriteLine("R");
                moveList.Add((startPosition, midPos, endPos));
            }

            // returns a list of all possible moves
            return moveList;
        }




        // checks if hole exists / is within bounds
        private bool exists(int position)
        {
            if (position >= 0 && position < NumOfHoles)
                return true;
            else
                return false;
        }


        // gets the hole object based on position
        public Hole GetHole(int position, List<Hole> holes)
        {
            return holes[position];
        }


        private int getRow(int position)
        {
            // returns the row a peg at  given position should be found at (0-indexed)
            int row = 0;
            for (int i = 0; i < NumOfRows; i++)
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
