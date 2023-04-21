/*
 * @file:
 * @authors: William Hayes & Jackson Horton
 * @date:4/6/2023
 * @brief:
 * 
 * 
 * 
 */
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Linq;

namespace PegTest
{
    public partial class GameOverWindow : Window
    {
        private int PegsLeft;
        private int timeInSeconds;
        private string formattedTimeString;

        public GameOverWindow(int PegsLeft, int timeInSeconds)
        {
            this.PegsLeft = PegsLeft;
            this.timeInSeconds = timeInSeconds;

            InitializeComponent();

            ///Formats time string
            // calculate seconds and minutes
            int min = timeInSeconds / 60;
            int sec = timeInSeconds % 60;

            // Update timertext with formatting
            this.formattedTimeString = $"{min}:{sec:D2}";

            TimerText.Text = "Time taken: " + formattedTimeString;
            PegsLeftText.Text = "Number of pegs left: " + PegsLeft;
            InsultText.Text = GetInsult(PegsLeft);

            ConButton Btn = new ConButton();

            Btn.Operation(this, 84, 32, 200, 245, GameOverGrid, EnumButton.SAVE);
            Btn.Operation(this, 84, 32, 0, 200, GameOverGrid, EnumButton.MENU);
            Btn.Operation(this, 84, 32, 0, 290, GameOverGrid, EnumButton.RESET);
            Btn.Operation(this, 84, 32, 0, 380, GameOverGrid, EnumButton.QUIT);

        }

        private string GetInsult(int PegsLeft)
        {
            switch (PegsLeft)
            {
                case 1:
                    return "Not too poopy :)";
                case 2:
                    return "A baboon could do better";
                case 3:
                    return "You ain't a smart feller, you're a fart smeller";
                default:
                    return "You are made of stupid and bring shame on your family name";
            }
        }

        public void appendScoreToLeaderboard(string name)
        {
            // open file stream to leaders file
            StreamWriter sw = new StreamWriter("..\\leaders.txt", true);


            // '%%' is used as a delimiter to separate data in the leaders file
            // should be stored as 'name%%pegs_left%%time_in_seconds'
            sw.WriteLine($"{name}%%{PegsLeft}%%{timeInSeconds}%%{formattedTimeString}");
            sw.Close();

            // disable save button
        }
    }
}
