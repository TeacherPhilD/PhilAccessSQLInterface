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

namespace PhilAccessSQLInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FileLib fileLib = new FileLib();
        string strFilePath = "error";
        DBInterface dbInterface = new DBInterface();
        GUICollection guiCollection = new GUICollection();

        public MainWindow()
        {
            InitializeComponent();
            SetupGUI();
        }

        private void SetupGUI()
        {
            NoDBSelected();
        }

        private void NoDBSelected()
        {
            btnOpenDB.IsEnabled = true;
            btnRunSQL.IsEnabled = false;
            txtSQLQuery.IsEnabled = false;
            lblDBInfo.Content = "";
        }

        private void DBSelected()
        {
            btnOpenDB.IsEnabled = false;
            btnRunSQL.IsEnabled = true;
            txtSQLQuery.IsEnabled = true;
        }

        private void btnOpenDB_Click(object sender, RoutedEventArgs e)
        {
            strFilePath = fileLib.OpenFileBrowser("Access Database (*.accdb)|*.accdb|All files (*.*)|*.*");
            lblPath.Content = strFilePath;

            if(lblPath.Content.Equals(FileLib.OPEN_FILE_DIALOG_ERROR))
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

        private async void CheckDB()
        {
            progressBar.Visibility = Visibility.Visible; // Show progress bar
            statusText.Text = "Checking database...";    // Update status text

            string result = await Task.Run(async () => await dbInterface.CheckAccessDB(strFilePath));

            progressBar.Visibility = Visibility.Collapsed; // Hide progress bar
            statusText.Text = result;                      // Update status with result
            DBSelected();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            NoDBSelected();
            lblPath.Content = "No path set";
            txtSQLQuery.Clear();
        }
    }
}
