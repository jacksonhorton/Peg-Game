using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace PegTest
{
    class Hole
    {
        protected Peg peg;

        public Hole(int position)
        {
            peg = new Peg(position, position==4 ? false : true);
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
    }
}
