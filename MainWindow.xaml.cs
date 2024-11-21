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

        #region GUI Init
        public MainWindow()
        {
            InitializeComponent();
            SetupGUI();
        }

        private void SetupGUI()
        {
            NoDBSelected();
        }
        #endregion

        #region Utility Functions
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

        #region Query Functions
        // Execute SQL query on access database
        private async void ExecuteQuery(string strQuery)
        {
            // Set GUI to loading state
            progressBar.Visibility = Visibility.Visible;
            statusText.Text = Consts.MAIN_DB_EXEC_PROGRESS;

            string strResult = await Task.Run(async () => await dbInterface.ExecuteQuery(strQuery, strFilePath));

            // Set GUI to finished state
            progressBar.Visibility = Visibility.Collapsed;
            statusText.Text = Consts.MAIN_DB_EXEC_FINISHED;

            // Open results window
            ResultsWindow resultsWindow = new ResultsWindow(strResult, strQuery);
            resultsWindow.Show();
        }

        // Check that access database exists
        private async void CheckDB()
        {
            // Set GUI to loading state
            progressBar.Visibility = Visibility.Visible; // Show progress bar
            statusText.Text = Consts.MAIN_CHECK_DB;    // Update status text

            string strResult = await Task.Run(async () => await dbInterface.CheckAccessDB(strFilePath));

            // Set GUI to finished state
            progressBar.Visibility = Visibility.Collapsed; // Hide progress bar
            statusText.Text = strResult;                      // Update status with result

            if(strResult.Contains("Error"))
            {
                guiCollection.ErrorPopUp("Error Opening Access Database", strResult);
            }
            else
            {
                // Set GUI to state where database has been selected
                DBSelected();
            }
            
        }

        // Grab input from a custom input window instead of the textbox
        private void SQLQueryFromMenu()
        {
            QueryInputWindow inputWindow = new QueryInputWindow();
            bool? booResult = inputWindow.ShowDialog();

            // Check if the dialog result is true (user clicked Execute)
            if (booResult == true)
            {
                // Execute query
                ExecuteQuery(inputWindow.UserInput);
            }
        }
        #endregion

        #region Listeners
        private void btnOpenDB_Click(object sender, RoutedEventArgs e)
        {
            strFilePath = fileLib.OpenFileBrowser(Consts.MAIN_OPEN_ACCESS_FILE_FILTER);
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
            ExecuteQuery(txtSQLQuery.Text);
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            NoDBSelected();
            lblPath.Content = Consts.MAIN_PATH_DEFAULT;
            statusText.Text = Consts.MAIN_GUI_RESET;

            txtSQLQuery.Clear();
        }

        private void muiRunSQL_Click(object sender, RoutedEventArgs e)
        {
            SQLQueryFromMenu();
        }


        private void AboutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            CustomMessageBox.Show($"{Consts.PROGRAM_TITLE}\n{Consts.ABOUT_AUTHOR}\n{Consts.ABOUT_VERSION}\n{Consts.ABOUT_ICON}");
        }
        #endregion
    }
}