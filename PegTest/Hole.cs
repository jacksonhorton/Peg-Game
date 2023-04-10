/*
 * @file:
 * @authors: William Hayes & Jackson Horton
 * @date:4/6/2023
 * @brief: Holes represent places where pegs can be. There is always
 * a constant number of holes for a given board. Position may or may
 * not contain a peg.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace PegTest
{
    public class Hole
    {
        // Holes contain pegs
        private Peg peg;

        /**
         * Constructor
         * @param   position    index position of the hole on the board
         * @param   filled      whether or not the hole has a peg in it
         */
        public Hole(int position, bool filled)
        {
            peg = new Peg(position, filled);
        }
        
        /*
         * Getter for the isFilled attribute of the Peg object
         * @return  bool    Whether or not the contained Peg is filled
         */
        public bool isFilled()
        {
            return peg.isFilled();
        }
        /*
         * Setter for the isFilled attribute of the Peg object
         * @param   filled  Update to if the contained peg is filled
         */
        public void setFilled(bool filled)
        {
            peg.setFilled(filled);
        }

        public int GetPosition()
        {
            return peg.getPosition();
        }
    }
}
