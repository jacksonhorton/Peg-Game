/*
 * @file: Buttons.cs
 * @authors: William Hayes & Jackson Horton
 * @date:4/6/2023
 * @brief: This is the abstract product class.
 * 
 * This file contains the abstract product class, Buttons. It
 * declares but doesn't impelement the Render() method used to
 * create the button UI elements.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PegTest
{
    public interface Buttons
    {
        /*
         * The declared Render() method, using the concrete product class to render the newly
         * instantiated button into the desired window and grid.
         */
        void Render();
    }
}
