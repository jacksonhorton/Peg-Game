using System;
using System.Collections.Generic;
using System.Linq;
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

namespace PegTest
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class BoardWindow : Window
    {
        private Board board;
        private int startPos;
        public BoardWindow()
        {
            InitializeComponent();
            // creates new board and passes this window so it can control pegs
            board = new Board(5, 15, this);
            startPos = -1;
        }

        private void Quit_Button_Click(object sender, RoutedEventArgs e)
        {
            Window window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is Ellipse)
            {
                Ellipse ellipse = (Ellipse)e.OriginalSource;

                // show possible moves if peg is clicked/held
                if (ellipse.Name.Contains("Peg"))
                {
                    //int position = Int32.Parse(ellipse.Name.Substring(3, ellipse.Name.Length-1));
                    int position = Int32.Parse(ellipse.Name.Substring(3));
                    board.MoveCheck(position);

                    startPos = position;
                }
                // try to make move if move ellipse is pressed
                else if (ellipse.Name.Contains("Move"))
                {
                    if (startPos >=0)
                    {
                        int endPosition = Int32.Parse(ellipse.Name.Substring(4));

                        // make move
                        board.MovePeg(startPos, endPosition);


                        startPos = -1;
                    }

                    board.RemoveMoveEllipses();


                }
            }
        }

        private void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is Ellipse)
            {
                Ellipse el = (Ellipse)e.OriginalSource;
                //el.Fill = Brushes.Purple;

            }

            //// sets startPos to -1, like it is by default since it is no longer used
            //startPos = -1;
        }
    }
}
