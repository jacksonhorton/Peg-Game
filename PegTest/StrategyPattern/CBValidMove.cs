/*
 * @file: CBValidMove.cs
 * @authors: William Hayes & Jackson Horton
 * @date:4/6/2023
 * @brief: This is a concrete strategy class.
 * 
 * This class implements the isPossibleMove method and any helper methods
 * to create a valid move checking algorithm for a triangular gameboard.
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PegTest
{
    /**
     * CBValidMove is the valid move checking strategy for the Cracker
     * Barrel board. It is fairly complicated and calculates the positions
     * of adjacent holes on different rows.
     * 
     */
    internal class CBValidMove : ValidStrat
    {
        /**
         * These two variables are used in the move calculations to calculate
         * adjacent positions.
         * 
         * NumOfHoles   number of holes on this type of board.
         * NumOfRows    number of rows on this board
         */
        private const int NumOfHoles = 15;
        private const int NumOfRows = 5;

        /**
         * Checks if a single given move is valid. Requires the program to pass the
         * position of each peg involved (hole being moved, jumped, and the destination
         * hole). Also requires the list of holes on a board to be passed in order to
         * validate the move.
         * @param   start   Index of the first hole position (all positions are 0-based)
         * @param   mid     Index of the middle hole position which is being jumped.
         * @param   end     Index of the final/destination hole position
         * @param   holes   List of the holes for the board
         * @return  bool    Returns if there is at least one possible move by any peg on the board
         */
        public override bool anyValidMoves(List<Hole> holes)
        {
            // starts from first hole and continues until a move is found or there are no more holes
            for (int i = 0; i < NumOfHoles; i++)
            {
                // gets a list of possible moves for a peg
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

            // there is no move from any hole on the board, return false
            return false;
        }


        /**
         * Checks if a single given move is valid. Requires the program to pass the
         * position of each peg involved (hole being moved, jumped, and the destination
         * hole). Also requires the list of holes on a board to be passed in order to
         * validate the move.
         * @param   start   Index of the first hole position (all positions are 0-based)
         * @param   mid     Index of the middle hole position which is being jumped.
         * @param   end     Index of the final/destination hole position
         * @param   holes   List of the holes for the board
         * @return  bool    Returns if the move is valid or not.
         */
        public override bool isPossibleMove(int start, int mid, int end, List<Hole> holes)
        {
            // checks if middle/intermediate hole is filled (should be filled to move)
            if (exists(start) && exists(mid) && exists(end))
            {
                // checks if final/destination hole is filled (should be empty to move)
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

        /**
         * Gets a list of possible move positions from a given start position on a given board.
         * This method doesn't check the validity of the moves, but generates at what positions a
         * valid move could be. Generates and returns a list of start, middle, and end positions.
         * @param   startPosition   The index of the starting hole on the board.
         * @param   holes           The list of holes for the board.
         * @return  holes           List of possible moves
         */
        public override List<(int startPos, int midPos, int endPos)> GetValidMoves(int startPosition, List<Hole> holes)
        {
            // possibly use a map for better lookup
            List<(int, int, int)> moveList = new List<(int startPos, int midPos, int endPos)> { };

            int midPos;
            int endPos;

            /*
             * Checks one movement direction at a time. A peg on this board can move horizonally left
             * and right, and diagonally upper left, upper right, lower right, and lower left.
             */

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




        /**
         * Checks if a position is within the bounds of this board
         * @param   position    The index position of the hole
         * @return  bool        If the position is on the board
         */
        private bool exists(int position)
        {
            if (position >= 0 && position < NumOfHoles)
                return true;
            else
                return false;
        }


        /**
         * Gets the Hole object for a given hole position
         * @param   position    The index of a hole
         * @param   holes       A list of all the holes on the board
         * @return  Hole        The Hole object at the position given
         */
        private Hole GetHole(int position, List<Hole> holes)
        {
            return holes[position];
        }

        /**
         * Gets the row on the board of a given index position for a hole/peg
         * @param   position    The index position of the peg you want the row for
         * @return  int         The row the indexed position resides on
         */
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
