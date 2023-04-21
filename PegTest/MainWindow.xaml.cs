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

        /**
         * Struct that stores a pervious game's stats for the leaderboard.
         */
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

        /**
         * Loads the leaderboard file, parses each entry/line and updates leaderboard on
         * main menu with ordered game stats.
         * 
         * @return  void
         */
        private void UpdateLeaderBoard()
        {
            // get lines from file
            string[] lines = ReadLeadersFile();

            // parses each line, then store in dict
            foreach (string line in lines)
            {
                string[] tokens = line.Split("%%");

                // creates leaderPerson struct from this line's parsed data
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
                    // if temp has fewer or equal pegs than the current entry, it may go here: check for time taken...
                    if (temp.PegsRemaining < entry.Value.PegsRemaining)
                    {
                        //swap is going in the current entry's place, entry becomes temp and continues iterating through the dict(leaderboard)
                        leaderPerson swap = temp;
                        temp = entry.Value;

                        leaderboard[entry.Key] = swap;
                    
                    }
                    // if temp has equal pegs, check if time is lower
                    else if (temp.PegsRemaining == entry.Value.PegsRemaining)
                    {
                        // check if temp has lower time, if so temp should take this entrys place
                        if (temp.Time < entry.Value.Time)
                        {
                            //swap is going in the current entry's place, entry becomes temp and continues iterating through the dict(leaderboard)
                            leaderPerson swap = temp;
                            temp = entry.Value;

                            leaderboard[entry.Key] = swap;
                        }

                    }
                }
                // add whatever is left to the end of the dictionary
                leaderboard.Add(leaderboard.Count+1, temp);

            }

            // update leaderboard scores with top 5 scores in dict if present
            if (leaderboard.ContainsKey(1))
            {
                Leader_1_name.Content = leaderboard[1].Name;
                Leader_1_pegs.Content = leaderboard[1].PegsRemaining;
                Leader_1_time.Content = leaderboard[1].FormatTime;
            }
            if (leaderboard.ContainsKey(2))
            {
                Leader_2_name.Content = leaderboard[2].Name;
                Leader_2_pegs.Content = leaderboard[2].PegsRemaining;
                Leader_2_time.Content = leaderboard[2].FormatTime;
            }
            if (leaderboard.ContainsKey(3))
            {
                Leader_3_name.Content = leaderboard[3].Name;
                Leader_3_pegs.Content = leaderboard[3].PegsRemaining;
                Leader_3_time.Content = leaderboard[3].FormatTime;
            }
            if (leaderboard.ContainsKey(4))
            {
                Leader_4_name.Content = leaderboard[4].Name;
                Leader_4_pegs.Content = leaderboard[4].PegsRemaining;
                Leader_4_time.Content = leaderboard[4].FormatTime;
            }
            if (leaderboard.ContainsKey(5))
            {
                Leader_5_name.Content = leaderboard[5].Name;
                Leader_5_pegs.Content = leaderboard[5].PegsRemaining;
                Leader_5_time.Content = leaderboard[5].FormatTime;
            }

        }

        /**
         * Reads the lines from the leaders file and returns an array of strings of each line in the file
         * 
         * @return  string[]    array of (strings) lines containing game stats
         */
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
                    lines = sr.ReadToEnd().Split('\n');
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            return lines;
        }


    }
}
