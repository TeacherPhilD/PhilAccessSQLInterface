#region Imports
using PhilAccessSQLInterface.misc;
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
#endregion

namespace PhilAccessSQLInterface
{
    /// <summary>
    /// Interaction logic for QueryInputWindow.xaml
    /// </summary>
    public partial class QueryInputWindow : Window
    {
        #region Class Variables
        public string strUserInput { get; private set; }
        private GUILib guiLib = new GUILib();
        private ValidLib validLib = new ValidLib();

        public QueryInputWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region Listeners
        private void ExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            // Store the query in the strUserInput property
            strUserInput = queryTextBox.Text;
            if (validLib.IsStringEmpty(strUserInput))
            {
                // Nothing entered, give error
                guiLib.ErrorPopUp(Consts.SQL_EXISTENCE_ERROR_TITLE, Consts.SQL_EXISTENCE_ERROR);
            }
            else
            {
                // Something entered, return
                this.DialogResult = true; // Set the dialog result to true to indicate success
                this.Close();
            }
        }
        #endregion
    }

}


