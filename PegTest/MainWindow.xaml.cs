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
        private Dictionary<int, leaderPerson> leaderboard = new Dictionary<int, leaderPerson>();

        /**
         * Constructor
         */
        public MainWindow()
        {
            InitializeComponent();

            // if a leaders file exists, try to load it onto the leaderboard
            if (File.Exists("..\\leaders.txt"))
            {
                UpdateLeaderBoard();
            }

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
            public leaderPerson(string name, int pegsRemaining, int time, string formatTime)
            {
                Name = name;
                PegsRemaining = pegsRemaining;
                Time = time;
                FormatTime = formatTime;
            }
            public string Name { get; set; }
            public int PegsRemaining { get; set; }
            public int Time { get; set; }
            public string FormatTime { get; set; }
        }
        private void UpdateLeaderBoard()
        {
            // get lines from file
            string[] lines = ReadLeadersFile();

            // parses each line, then store in dict
            foreach (string line in lines)
            {
                string[] tokens = line.Split("%%");

                leaderPerson aLeader;
                if (tokens.Length == 4)
                {
                    // stores data in leaderPerson struct
                    aLeader = new leaderPerson(tokens[0], int.Parse(tokens[1]), int.Parse(tokens[2]), tokens[3]);
                }
                else // bad format, continue to next line
                {
                    continue;
                }


                // find what position new leaderPerson should be
                leaderPerson temp = aLeader;
                foreach (KeyValuePair<int, leaderPerson> entry in leaderboard)
                {
                    // if temp has higher pegs left than current entry, move to next entry
                    if (temp.PegsRemaining > entry.Value.PegsRemaining)
                        continue;

                    // if temp has equal pegs left.....
                    if (temp.PegsRemaining == entry.Value.PegsRemaining)
                    {
                        // check if temp has lower time, if so temp should take this entrys place
                        if (temp.Time < entry.Value.Time)
                        {
                            leaderPerson swap = entry.Value;
                            entry.Value = temp;
                            temp = swap;
                        }

                    }
                }

            }

        }

        private string[] ReadLeadersFile()
        {
            // creates array to store lines of file
            string[] lines = Array.Empty<string>();

            try
            {
                // Open the text file using a stream reader.
                using (var sr = new StreamReader("..\\leaders.txt"))
                {
                    // add each line from file to the string array
                    lines = sr.ReadToEnd().Split("%%");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            return lines;
        }


    }
}
