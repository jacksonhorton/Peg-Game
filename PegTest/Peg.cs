/*
 * @authors: William Hayes & Jackson Horton
 * @date:4/6/2023
 * @brief: Peg is used to represent each peg on the board. A peg goes
 * with a hole on the board. 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PegTest
{
    public class Peg
    {
        private int position;
        private bool filled;

        /**
         * Constructor
         * @param   position    The index of the peg, correlated to the index of a hole on the board
         * @param   isFilled    Is the peg filled or not/still a valid peg to be moved
         */
        public Peg(int position, bool isFilled)
        {
            this.position = position;
            this.filled = isFilled;
        }

        /**
         * Getter for isFilled
         * @return  bool    isFilled instance variable
         */
        public bool isFilled()
        {
            return filled;
        }
        /**
         * Setter for isFilled
         * @param   filled    is the peg now filled or not
         */
        public void setFilled(bool filled)
        {
            this.filled = filled;
        }
        /**
         * Getter for position
         * @return  int the index of this object
         */
        public int getPosition()
        {
            return position;
        }
    }
}
