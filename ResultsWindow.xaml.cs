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

namespace PhilAccessSQLInterface
{
    /// <summary>
    /// Interaction logic for ResultsWindow.xaml
    /// </summary>
    public partial class ResultsWindow : Window
    {
        public ResultsWindow(string result)
        {
            InitializeComponent();
            resultsTextBox.Text = result;
        }

        private void btnSaveSQL_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSaveResults_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
