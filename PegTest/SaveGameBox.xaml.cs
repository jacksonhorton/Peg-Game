﻿using System;
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

namespace PegGame
{
    /// <summary>
    /// Interaction logic for SaveGameBox.xaml
    /// </summary>
    public partial class SaveGameBox : Window
    {
        public SaveGameBox()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            // https://stackoverflow.com/questions/10946421/append-data-to-existing-file-in-c-sharp
        }
    }
}
