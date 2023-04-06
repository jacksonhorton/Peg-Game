using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
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
    /// Interaction logic for HelpWindow.xaml
    /// </summary>
    public partial class HelpWindow : Window
    {
        public HelpWindow()
        {
            InitializeComponent();

            string str = "The goal of the Peg Game is jump over and remove pegs\n" +
                "from the board until one peg remains.\n" +
                "Rules:\n" + 
                "1. A you can only move a peg into empty hole, \n" +
                "if the peg jumps over another peg in order to get into said hole.\n" +
                "(Valid move positions will be highlighted in green).\n" +
                "2. If a peg is jumped over it is removed from the board.\n" +
                "3. The aim is to get to as close to 1 peg remaining as possible.\n" +
                "4. Once the player run out of valid moves to make or have 1 peg left, the game ends.\n\n" +
                "Features:\n" +
                "1. Menu- Return to the main menu.\n" +
                "2. Quit- Quits the program.\n" +
                "3. Restart- Resets the board.\n" +
                "4. Undo- Undoes the previous moves made.\n" +
                "5. Pause- Pauses the game.\n" +
                "6. Help- Shows the help menu.\n";

            generateText(str, 235, 27);

            ConButton Btn = new ConButton();

            Btn.Operation(this, 84, 32, -200, 300, Help_Grid, EnumButton.MENU);
            Btn.Operation(this, 84, 32, 400, 300, Help_Grid, EnumButton.QUIT);
        }

        private void generateText(string text, double left, double top)
        {
            Label l = new Label()
            {
                Width = 600,
                Height = 470,
                FontFamily = new FontFamily("Strika Text"),
                Margin = new Thickness(left, top, 0, 0),
                FontSize = 14,
                Content = text,    
            };

            Help_Grid.Children.Add(l);
            Help_Grid.UpdateLayout();
        }
    }
}
