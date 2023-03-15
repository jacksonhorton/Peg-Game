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

        public Peg(int position, bool isFilled)
        {
            this.position = position;
            this.filled = isFilled;
        }

        public bool isFilled()
        {
            return filled;
        }
        public void setFilled(bool filled)
        {
            this.filled = filled;
        }
        public int getPosition()
        {
            return position;
        }
    }
}
