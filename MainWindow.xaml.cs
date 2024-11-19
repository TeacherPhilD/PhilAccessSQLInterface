#region imports
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
using System.IO;
using PhilAccessSQLInterface.misc;
using Microsoft.Win32; // We need this if we are going to use files!
#endregion

namespace PhilAccessSQLInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Class Variables
        FileLib fileLib = new FileLib();
        string strFilePath = "error";
        DBInterface dbInterface = new DBInterface();
        GUICollection guiCollection = new GUICollection();
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            SetupGUI();
        }

        #region Utility Functions
        private void SetupGUI()
        {
            NoDBSelected();
        }

        private void NoDBSelected()
        {
            btnOpenDB.IsEnabled = true;
            muiOpenDB.IsEnabled = true;

            btnRunSQL.IsEnabled = false;
            muiRunSQL.IsEnabled = false;

            txtSQLQuery.IsEnabled = false;
            lblDBInfo.Content = "";
        }

        private void DBSelected()
        {
            btnOpenDB.IsEnabled = false;
            muiOpenDB.IsEnabled= false;

            btnRunSQL.IsEnabled = true;
            muiRunSQL.IsEnabled= true;

            txtSQLQuery.IsEnabled = true;
        }
        #endregion

        // Execute SQL query on access database
        private async void ExecuteQuery()
        {
            progressBar.Visibility = Visibility.Visible;
            statusText.Text = "Executing query...";

            string query = txtSQLQuery.Text;
            string result = await Task.Run(async () => await dbInterface.ExecuteQuery(query, strFilePath));

            progressBar.Visibility = Visibility.Collapsed;
            statusText.Text = "Query executed";

            // Open results window
            ResultsWindow resultsWindow = new ResultsWindow(result);
            resultsWindow.Show();
        }

        // Check that access database exists
        private async void CheckDB()
        {
            progressBar.Visibility = Visibility.Visible; // Show progress bar
            statusText.Text = "Checking database...";    // Update status text

            string result = await Task.Run(async () => await dbInterface.CheckAccessDB(strFilePath));

            progressBar.Visibility = Visibility.Collapsed; // Hide progress bar
            statusText.Text = result;                      // Update status with result
            DBSelected();
        }

        private void RunSQLMenu()
        {
            QueryInputWindow inputWindow = new QueryInputWindow();
            bool? result = inputWindow.ShowDialog();

            // Check if the dialog result is true (user clicked Execute)
            if (result == true)
            {
                guiCollection.ShowMsg("test", inputWindow.UserInput);
            }
            else
            {
                guiCollection.ShowMsg("test", "error");
            }
        }


        #region Listeners
        private void btnOpenDB_Click(object sender, RoutedEventArgs e)
        {
            strFilePath = fileLib.OpenFileBrowser("Access Database (*.accdb)|*.accdb|All files (*.*)|*.*");
            lblPath.Content = strFilePath;

            if (lblPath.Content.Equals(FileLib.OPEN_FILE_DIALOG_ERROR))
            {
                NoDBSelected();
            }
            else
            {
                CheckDB();
            }
        }

        private void btnRunSQL_Click(object sender, RoutedEventArgs e)
        {
            ExecuteQuery();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            NoDBSelected();
            lblPath.Content = "No path set";
            statusText.Text = "GUI has been reset";

            txtSQLQuery.Clear();
        }

        private void muiRunSQL_Click(object sender, RoutedEventArgs e)
        {
            RunSQLMenu();
        }


        private void AboutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            CustomMessageBox.Show("PhilAccessSQLInterface\nVersion 1.0\n© 2023 Your Company Name");
        }
        #endregion
    }
}