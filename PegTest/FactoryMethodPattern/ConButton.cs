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
using System.Windows;
using System.Windows.Controls;

namespace PegTest
{
    public class ConButton : AbsButton
    {
        public override Buttons CreateButton(Window w, double width, double height, int left, int top, Grid g, EnumButton e)
        {
            return new ButtonProd(w, width, height, left, top, g, e);
        }
    }
}
