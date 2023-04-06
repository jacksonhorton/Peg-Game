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
        public GameOverWindow(int PegsLeft)
        {
            InitializeComponent();

            PegsLeftText.Text = "Number of pegs left: " + PegsLeft;
            InsultText.Text = GetInsult(PegsLeft);

            ConButton Btn = new ConButton();
            Btn.Operation(this, 84, 32, 0, 180, GameOverGrid, EnumButton.MENU);
            Btn.Operation(this, 84, 32, 0, 270, GameOverGrid, EnumButton.RESET);
            Btn.Operation(this, 84, 32, 0, 360, GameOverGrid, EnumButton.QUIT);

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
                    return "You are made of stupid and bring shame on your family name";
                default:
                    return "You ain't a smart feller, you're a fart smeller";
            }

        }
    }
}
