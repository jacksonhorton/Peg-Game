/*
 * @file:
 * @authors: William Hayes & Jackson Horton
 * @date:4/6/2023
 * @brief: This window is where the game is played. It contains the pegs, holes, and interaction logic.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
    public partial class BoardWindow : Window
    {
        private Board board;
        private int startPos;
        private System.Windows.Forms.Timer timer;


        /**
         * Returns the Board object associated with this BoardWindow
         * @return  Board   the Board associated with this BoardWindow
         */
        public Board GetBoard() { return board; }


        /**
         * Constructor
         */
        public BoardWindow()
        {
            InitializeComponent();
            // creates new board and passes this window so it can control pegs
            board = new Board(5, 15, 14, this);
            startPos = -1;
            // creates timer for board
            TimerText.Text = "0:50";
            timer = new System.Windows.Forms.Timer();
            timer.Tick += new EventHandler(TimerTick);
            timer.Interval = 1000; // in miliseconds
            timer.Start();

            ConButton btn = new ConButton();

            btn.Operation(this, 84, 32, 650, -300, Board_Window_Grid, EnumButton.MENU);
            btn.Operation(this, 84, 32, 650, -200, Board_Window_Grid, EnumButton.RESET);
            btn.Operation(this, 84, 32, 650, -100, Board_Window_Grid, EnumButton.UNDO);
            btn.Operation(this, 84, 32, 650, 0, Board_Window_Grid, EnumButton.PAUSE);
            btn.Operation(this, 84, 32, 650, 350, Board_Window_Grid, EnumButton.QUIT);

            

        }

        /**
         * Timer tick event for this window. Runs every second by TimerTick handler.
         * Gets current time, checks for any errors, increments, and displays new, correct time.
         * @param   sender?     Nullable sender object. Not used, needed to match delegate EventHandler
         * @param   EventArgs   event data
         * @return  void
         */
        public void TimerTick(object? sender, EventArgs e)
        {
            // not terribly efficient :)
            String[] timerTokens;
            int min, sec;
            timerTokens = TimerText.Text.Split(':');

            if (timerTokens.Length >= 2 )
            {
                //get int values of minute and second from timer text
                min = Convert.ToInt32(timerTokens[0]);
                sec = Convert.ToInt32(timerTokens[1]);

                // increament timer, check for seconds hitting minute mark
                if (sec < 59)
                {
                    sec += 1;
                }
                else
                {
                    min += 1;
                    sec = 0;
                }

                // Update timertext with formatting
                TimerText.Text = $"{min}:{sec:D2}";
            }
            else
            {
                TimerText.Text = "0:00";
            }
        }

        /**
         * Stops the timer on this window.
         * @return  void
         */
        public void StopTimer()
        {
            if (timer != null)
                timer.Stop();
        }

        /**
         * Starts the timer on this window.
         * @return  void
         */
        public void StartTimer()
        {
            if (timer != null)
                timer.Start();
        }

        /**
         * Clicking logic for the game board.
         * When a peg is clicked, generate valid move ellipses; if a valid move ellipse, execute the move.
         * @param   sender  reference to event sender
         * @param   e       event data
         * @return  void
         */
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


        /**
         * Possible implementation to allow dragging from one peg to a move ellipse for easier play.
         * @param   sender  reference to event sender
         * @param   e       event data
         * @return  void
         */
        private void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is Ellipse)
            {
                Ellipse el = (Ellipse)e.OriginalSource;

            }
        }
    }
}
