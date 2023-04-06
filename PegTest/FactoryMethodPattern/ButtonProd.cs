using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Automation.Peers;

namespace PegTest
{
    public class ButtonProd : Buttons
    {
        Window w;
        double width;
        double height;
        int left;
        int top;
        Grid g;
        EnumButton enumB;

        public ButtonProd(Window w, double width, double height, int left, int top, Grid g, EnumButton e) 
        {
            this.w = w;

            this.width = width;
            this.height = height;

            this.left = left;
            this.top = top;

            this.g = g;

            this.enumB = e;
        }

        public void Render()
        {
            Button b = new Button()
            {
                Height = height,
                Width = width,
                Background = Brushes.OrangeRed,
                IsHitTestVisible = true,
                Content = Convert.ToString(enumB)
            };

            var style = new Style
            {
                TargetType = typeof(Border),
                Setters = { new Setter { Property = Border.CornerRadiusProperty, Value = new CornerRadius(7) } }
            };

            b.Resources.Add(style.TargetType, style);

            b.Margin = new System.Windows.Thickness(left, top, 0, 0);

            b.Click += new RoutedEventHandler(Button_Click);

            g.Children.Add(b);
            g.UpdateLayout();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            switch(enumB)
            {
                case EnumButton.MENU:
                    Window window = new MainWindow();
                    window.Show();
                    w.Close();
                    break;

                case EnumButton.QUIT:
                    Environment.Exit(0); //closes all windows in the program
                    break;

                case EnumButton.PLAY:
                    Window board = new BoardWindow();
                    board.Show();
                    w.Close();
                    break;

                case EnumButton.HELP:
                    break;

                case EnumButton.RESET:
                    board = new BoardWindow();
                    board.Show();
                    w.Close();
                    break;

                case EnumButton.UNDO:
                    //scawwwyyyyy
                    Board b =((BoardWindow)w).GetBoard();
                    b.undoMove();
                    break;

                case EnumButton.PAUSE:
                    PauseWindow temp = new PauseWindow(w);
                    temp.HidePausedWindow();
                    temp.Show();

                    break;

                case EnumButton.RESUME:
                    ((PauseWindow)w).RenderPausedWindow();
                    w.Close();
                    break;

                default:
                    break;
            };

        }


    }
}
