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
        public abstract Buttons CreateButton(Window w, double width, double height, int left, int top, Grid g, EnumButton e);

        public void Operation(Window w, double width, double height, int left, int top, Grid g, EnumButton e)
        {
            Buttons buttons = CreateButton(w, width, height, left, top, g, e);

            buttons.Render();
        }
    }
}
