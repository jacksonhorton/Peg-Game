/*
 * @file: AbsButton.cs
 * @authors: William Hayes & Jackson Horton
 * @date:4/6/2023
 * @brief: This is the abstract factory method class.
 * 
 * This class declares the CreateButton method that will be used by the 
 * concreteMethod classes to create new button objects. It also declares
 * the operation method that is used create button objects at runtime and
 * call the Render() method for those objects.
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

    public abstract class AbsButton
    {
        /*
         * The declared FactoryMethod, used to return a newly instantiated Buttons concrete product.
         * 
         * @para window w, the window w that is creating a new button.
         * @para double width, the width of the button
         * @para double height, the height of the button
         * @para int left, the position of the left margin
         * @para int top, the position of th etop margin
         * @para Grid g, w's specified grid that will contain the button
         * @para EnumButton e, the enum value of the button, using to determine functionality when clicked.
         * 
         */
        public abstract Buttons CreateButton(Window w, double width, double height, int left, int top, Grid g, EnumButton e);

        /*
         * The operation method used to create a new concrete product and it's Render() method.
         * 
         * @para window w, the window w that is creating a new button.
         * @para double width, the width of the button
         * @para double height, the height of the button
         * @para int left, the position of the left margin
         * @para int top, the position of th etop margin
         * @para Grid g, w's specified grid that will contain the button
         * @para EnumButton e, the enum value of the button, using to determine functionality when clicked.
         * 
         */

        public void Operation(Window w, double width, double height, int left, int top, Grid g, EnumButton e)
        {
            Buttons buttons = CreateButton(w, width, height, left, top, g, e);

            buttons.Render();
        }
    }
}
