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

        public Hole(PegPosition position)
        {
            peg = new Peg(position, position==PegPosition.Peg4 ? false : true);
        }
        
        public bool isFilled()
        {
            return peg.isFilled();
        }

        public PegPosition GetPosition()
        {
            return peg.getPosition();
        }
    }
}
