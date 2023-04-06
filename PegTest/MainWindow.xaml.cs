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
        public MainWindow()
        {
            InitializeComponent();

            ConButton button = new ConButton();

            button.Operation(this, 84, 32, 0, -125, MainGrid, EnumButton.PLAY);
            button.Operation(this, 84, 32, 0, -25, MainGrid, EnumButton.HELP);
            button.Operation(this, 84, 32, 0, 75, MainGrid, EnumButton.QUIT);

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


    }
}
