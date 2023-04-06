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
using System.Windows.Shapes;

namespace PegTest
{
    public class Hole
    {
        protected Peg peg;

        public Hole(int position, bool filled)
        {
            peg = new Peg(position, filled);
        }
        
        public bool isFilled()
        {
            return peg.isFilled();
        }

        public void setFilled(bool filled)
        {
            peg.setFilled(filled);
        }

        public int GetPosition()
        {
            return peg.getPosition();
        }

        public Peg GetPeg()
        {
            return peg;
        }

        //public void RemovePeg()

        public void SetFilled(bool filled)
        {
            peg.setFilled(filled);
        }
    }
}
