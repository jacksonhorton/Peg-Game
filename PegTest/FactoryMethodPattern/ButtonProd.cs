/*
 * @file: ButtonProd.cs
 * @authors: William Hayes & Jackson Horton
 * @date:4/6/2023
 * @brief: The concrete Buttons product.
 * 
 * This file contain the ButtonProd class which functions
 * as the concrete product of Buttons. It implements the Render()
 * method to create a button UI element in a window, by using the data members
 * stored from the constructor. It also implements the Button Click method to add functionality
 * to each button which clicked. Using the button object's respective Enum value to determine 
 * functionality, the buttons created can: open the menu window, close the entire program, restart
 * the game board, undo moves, open the help screen, pause and resume the game, and create a new game board
 * window.
 */
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
using Microsoft.Win32;
using PegGame;

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

        /*
         * Constructor
         * 
         * @para window w, the window w that is creating a new button.
         * @para double width, the width of the button
         * @para double height, the height of the button
         * @para int left, the position of the left margin
         * @para int top, the position of th etop margin
         * @para Grid g, w's specified grid that will contain the button
         * @para EnumButton e, the enum value of the button, using to determine functionality when clicked.
         */
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

        /*
         * Renders the newly instantiated buttonProd as a UI element in the desired window and grid, using the 
         * data member collected from the constructor.
         * 
         */
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

        /*
         * This method add functionality to the buttons when clicked, using the ButtonProd object's
         * store EnumButton value to determine its functionality via a switch statement.
         * 
         */
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
                    HelpWindow help = new HelpWindow();
                    help.Show();
                    w.Close();
                    break;

                case EnumButton.RESET:
                    board = new BoardWindow();
                    board.Show();
                    w.Close();
                    break;

                case EnumButton.UNDO:
                    // Gets board object, undoes last move, clears move elipses
                    Board b =((BoardWindow)w).GetBoard(); //scawwwyyyy
                    b.RemoveMoveEllipses();
                    b.undoMove();
                    break;

                case EnumButton.PAUSE:
                    // timer is stopped by PauseWindow
                    PauseWindow temp = new PauseWindow(w);
                    temp.HidePausedWindow();
                    temp.Show();

                    break;

                case EnumButton.RESUME:
                    // timer is restarted by PauseWindow
                    ((PauseWindow)w).RenderPausedWindow();
                    w.Close();
                    break;

                case EnumButton.SAVE:
                    // prompts user for name to save to leaderboard
                    SaveGameBox saveWindow = new SaveGameBox();
                    saveWindow.ShowDialog();  // waits for save fialog to close before moving on

                    // call for window to add score to leaders file
                    String name_field = saveWindow.name_Text_box.Text;
                    ((GameOverWindow)w).appendScoreToLeaderboard(name_field.Replace('%', ' '));
                    break;

                default:
                    break;
            };

        }


    }
}
