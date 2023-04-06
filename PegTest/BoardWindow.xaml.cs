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

        
        public Board GetBoard() { return board; }


        public BoardWindow()
        {
            InitializeComponent();
            // creates new board and passes this window so it can control pegs
            board = new Board(5, 15, 14, this);
            startPos = -1;
                
            ConButton btn = new ConButton();

            btn.Operation(this, 84, 32, 650, -300, Board_Window_Grid, EnumButton.MENU);
            btn.Operation(this, 84, 32, 650, -200, Board_Window_Grid, EnumButton.RESET);
            btn.Operation(this, 84, 32, 650, -100, Board_Window_Grid, EnumButton.UNDO);
            btn.Operation(this, 84, 32, 650, 0, Board_Window_Grid, EnumButton.PAUSE);
            btn.Operation(this, 84, 32, 650, 350, Board_Window_Grid, EnumButton.QUIT);

            

        }

        

        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is Ellipse)
            {
                Ellipse ellipse = (Ellipse)e.OriginalSource;

                // show possible moves if peg is clicked/held
                if (ellipse.Name.Contains("Peg"))
                {
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

            }
        }
    }
}
