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
        private PegPosition position;
        private bool filled;

        public Peg(PegPosition position, bool isFilled)
        {
            this.position = position;
            this.filled = isFilled;
        }

        public bool isFilled()
        {
            return filled;
        }
        public PegPosition getPosition()
        {
            return position;
        }
    }
}
