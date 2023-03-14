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
        public BoardWindow()
        {
            InitializeComponent();
            // creates new board and passes this window so it can control pegs
            Board board = new Board(5, 15, this);
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
                Ellipse el = (Ellipse)e.OriginalSource;
                el.Fill = Brushes.Navy;
            }
        }

        private void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is Ellipse)
            {
                Ellipse el = (Ellipse)e.OriginalSource;
                el.Fill = Brushes.Purple;
            }
        }
    }
}
