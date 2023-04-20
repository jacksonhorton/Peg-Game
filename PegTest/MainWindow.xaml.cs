/*
 * @file:
 * @authors: William Hayes & Jackson Horton
 * @date:4/6/2023
 * @brief:  The MainWindow is the menu screen where the program starts.
 * Has additional functionality like help screen and possibly a leaderboard in the future.
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PegTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /**
         * Constructor
         */
        public MainWindow()
        {
            InitializeComponent();

            ConButton button = new ConButton();

            button.Operation(this, 84, 32, -130, -50, MainGrid, EnumButton.PLAY);
            button.Operation(this, 84, 32, -130, 50, MainGrid, EnumButton.HELP);
            button.Operation(this, 84, 32, -130, 150, MainGrid, EnumButton.QUIT);

            TextBlock t = new TextBlock()
            {
                Width = 500,
                Height = 60,
                Margin = new Thickness(0,330,0,0),
                Text = "Developed & Created by William Hayes & Jackson Horton\n" + "University of Tennessee at Martin, Department of Computer Science",
                FontSize = 14,
                FontFamily = new FontFamily("Strika Text"),
                HorizontalAlignment = HorizontalAlignment.Center,
                TextAlignment = TextAlignment.Center,
            };

            MainGrid.Children.Add(t);
            MainGrid.UpdateLayout();
        }

        private struct leaderPerson
        {
            public leaderPerson(string name, string pegsRemaining, string time)
            {
                Name = name;
                PegsRemaining = pegsRemaining;
                Time = time;
            }
            public string Name { get; }
            public string PegsRemaining { get; }
            public string Time { get; }
        }
        private void UpdateLeaderBoard()
        {


        }

        private void ReadLeadersFile()
        {
            try
            {
                // Open the text file using a stream reader.
                using (var sr = new StreamReader("leaders.txt"))
                {
                    // Read the stream as a string, and write the string to the console.
                    Console.WriteLine(sr.ReadToEnd());
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }


    }
}
