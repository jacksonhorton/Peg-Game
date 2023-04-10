/*
 * @file: Valid Strat.cs
 * @authors: William Hayes & Jackson Horton
 * @date:4/6/2023
 * @brief: This is the abstract strategy class.
 * 
 * This class is the abstract strategy class. It declares the isPossibleMove method
 * that create different valid move checking algorithms depending on the board shape.
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
     * ValidStrat is an important part of the strategy pattern. It specifies
     * all of the necessary methods for any valid move algorithm.
     */
    public abstract class ValidStrat
    {
        /**
         * Checks if a single given move is valid. Requires the program to pass the
         * position of each peg involved (hole being moved, jumped, and the destination
         * hole). Also requires the list of holes on a board to be passed in order to
         * validate the move.
         * @param   start   Index of the first hole position (all positions are 0-based)
         * @param   mid     Index of the middle hole position which is being jumped.
         * @param   end     Index of the final/destination hole position
         * @param   holes   List of the holes for the board
         * @return          Returns if the move is valid or not.
         */
        public abstract bool isPossibleMove(int start, int mid, int end, List<Hole> holes);

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
        public abstract bool anyValidMoves(List<Hole> holes);

        /**
         * Gets a list of possible move positions from a given start position on a given board.
         * This method doesn't check the validity of the moves, but generates at what positions a
         * valid move could be. Generates and returns a list of start, middle, and end positions.
         * @param   startPosition   The index of the starting hole on the board.
         * @param   holes           The list of holes for the board.
         * @return  holes           List of possible moves
         */
        public abstract List<(int startPos, int midPos, int endPos)> GetValidMoves(int startPosition, List<Hole> holes);
    }
}
