/*
 * @file:
 * @authors: William Hayes & Jackson Horton
 * @date:4/6/2023
 * @brief: The pause Window for the game.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace PegTest
{
    /// <summary>
    /// Interaction logic for PauseWindow.xaml
    /// </summary>
    public partial class PauseWindow : Window
    {
        Window window;

        /**
         * Constructor
         * @param   window  The window that is being paused that the program will return to.
         */
        public PauseWindow(Window window)
        {
            this.window = window;

            InitializeComponent();

            ConButton Btn = new ConButton();


            Btn.Operation(this, 84, 32, 0, 0, PauseGrid, EnumButton.RESUME);
            Btn.Operation(this, 84, 32, 0, 100, PauseGrid, EnumButton.MENU);
            Btn.Operation(this, 84, 32, 0, 200, PauseGrid, EnumButton.RESET);
            Btn.Operation(this, 84, 32, 0, 300, PauseGrid, EnumButton.QUIT);


            Label l = new Label()
            {
                Height = 120,
                Width = 425,
                FontSize = 72,
                FontFamily = new FontFamily("Sitka Text Semibold"),
                Margin = new Thickness(175, -200, 0, 0),
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.White,
                Content = "Paused",
            };

            PauseGrid.Children.Add(l);
            PauseGrid.UpdateLayout();
        }


        /**
         * Hides the open window (probably the BoardWindow where the game is being played)
         * @return  void
         */
        public void HidePausedWindow()
        {
            window.Visibility = Visibility.Hidden;
            window.ShowInTaskbar = false;
        }

        /**
         * Makes the hidden Window visible again
         * @return  void
         */
        public void RenderPausedWindow()
        {
            window.Visibility = Visibility.Visible;
            window.ShowInTaskbar = true;
        }

    }
}
