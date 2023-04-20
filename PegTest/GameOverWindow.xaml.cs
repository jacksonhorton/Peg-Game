﻿/*
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
    public partial class GameOverWindow : Window
    {
        public GameOverWindow(int PegsLeft, int timeInSeconds)
        {
            InitializeComponent();

            ///Formats time string
            // calculate seconds and minutes
            int min = timeInSeconds / 60;
            int sec = timeInSeconds % 60;

            // Update timertext with formatting
            string timeString = $"{min}:{sec:D2}";

            TimerText.Text = "Time taken: " + timeString;
            PegsLeftText.Text = "Number of pegs left: " + PegsLeft;
            InsultText.Text = GetInsult(PegsLeft);

            ConButton Btn = new ConButton();

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
    }
}
