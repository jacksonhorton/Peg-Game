using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PegTest
{
    public abstract class ValidStrat
    {
        public abstract bool isPossibleMove(int start, int mid, int end, List<Hole> holes);


    }
}
