/*
 * @file: ConButtons.cs
 * @authors: William Hayes & Jackson Horton
 * @date:4/6/2023
 * @brief: This is the concrete method class.
 * 
 * This file contains the concrete method class, ConButton.
 * Its purpose it to implement the CreateButton method to return a newly
 * instantiated button prod, in this case ButtonProd.
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
        /*
         * The implemented FactoryMethod, used to return a newly instantiated ButtonProd object.
         * 
         * @para window w, the window w that is creating a new button.
         * @para double width, the width of the button
         * @para double height, the height of the button
         * @para int left, the position of the left margin
         * @para int top, the position of th etop margin
         * @para Grid g, w's specified grid that will contain the button
         * @para EnumButton e, the enum value of the button, using to determine functionality when clicked.
         */
        public override Buttons CreateButton(Window w, double width, double height, int left, int top, Grid g, EnumButton e)
        {
            return new ButtonProd(w, width, height, left, top, g, e);
        }
    }
}
