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
    /// Interaction logic for QueryInputWindow.xaml
    /// </summary>
    public partial class QueryInputWindow : Window
    {
        public string UserInput { get; private set; }

        public QueryInputWindow()
        {
            InitializeComponent();
        }

        private void ExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            // Store the query in the UserInput property
            UserInput = queryTextBox.Text;
            this.DialogResult = true; // Set the dialog result to true to indicate success
            this.Close();
        }
    }

}


