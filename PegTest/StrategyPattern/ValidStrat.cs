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
    public abstract class ValidStrat
    {
        public abstract bool isPossibleMove(int start, int mid, int end, List<Hole> holes);


    }
}
