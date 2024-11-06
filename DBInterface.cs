using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Windows.Media.Animation;

namespace PhilAccessSQLInterface
{
    internal class DBInterface
    {
        private bool booDBOpen = false;

        public DBInterface()
        { }

        //public async Task<string> CheckAccessDB(string strFilePath)
        //{
        //    string strRetVal = "Default Error";
        //    string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strFilePath;
        //    using (OleDbConnection connection = new OleDbConnection(connectionString))
        //    {
        //        try
        //        {
        //            await connection.OpenAsync();
        //            strRetVal = "Success opening database";
        //            connection.Close();
        //        }
        //        catch (Exception ex)
        //        {
        //            strRetVal = "Error: " + ex.Message;
        //        }
        //        return strRetVal;
        //    }
        //}

        public async Task<string> ExecuteQuery(string query, string strFilePath)
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strFilePath;
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    OleDbCommand command = new OleDbCommand(query, connection);

                    using (OleDbDataReader reader = (OleDbDataReader)await command.ExecuteReaderAsync())
                    {
                        string results = "";
                        while (await reader.ReadAsync())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                results += reader[i] + "\t";
                            }
                            results += Environment.NewLine;
                        }
                        return results;
                    }
                }
                catch (Exception ex)
                {
                    return "Error: " + ex.Message;
                }
            }
        }

        public async Task<string> CheckAccessDB(string strFilePath)
        {
            string strRetVal = "Default Error";
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strFilePath;

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    strRetVal = "Success opening database";
                }
                catch (Exception ex)
                {
                    strRetVal = "Error: " + ex.Message;
                }
                finally
                {
                    connection.Close(); // Ensure this happens even if there is an exception
                }
            }

            return strRetVal;
        }

    }
}

/*
 * Let's expand your application to include a text box for SQL queries and a button to execute them, displaying the results in a new window.

Step 1: Update MainWindow XAML
Add a TextBox and Button to your MainWindow:

<Window x:Class="YourNamespace.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="Database Checker" Height="350" Width="525">
    <DockPanel>
        <StatusBar DockPanel.Dock="Bottom" Name="statusBar">
            <StatusBarItem>
                <TextBlock Name="statusText" Text="Ready" />
            </StatusBarItem>
            <StatusBarItem>
                <ProgressBar x:Name="progressBar" IsIndeterminate="True" Width="100" Visibility="Collapsed" />
            </StatusBarItem>
        </StatusBar>
        <StackPanel Margin="10">
            <TextBox x:Name="queryTextBox" Width="400" Height="100" VerticalAlignment="Top" AcceptsReturn="True"/>
            <Button Content="Execute Query" Width="100" Height="30" Margin="5" Click="ExecuteQuery_Click"/>
        </StackPanel>
    </DockPanel>
</Window>

Step 2: Update MainWindow Code-Behind
Handle the button click to execute the query and open a new window with the results:

private async void ExecuteQuery_Click(object sender, RoutedEventArgs e)
{
    progressBar.Visibility = Visibility.Visible;
    statusText.Text = "Executing query...";

    string query = queryTextBox.Text;
    string result = await Task.Run(async () => await dbInterface.ExecuteQuery(query, strFilePath));

    progressBar.Visibility = Visibility.Collapsed;
    statusText.Text = "Query executed";

    // Open results window
    ResultsWindow resultsWindow = new ResultsWindow(result);
    resultsWindow.Show();
}

Step 3: Create ResultsWindow
Add a new WPF Window to your project for displaying query results:

ResultsWindow XAML:

<Window x:Class="YourNamespace.ResultsWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="Query Results" Height="300" Width="400">
    <Grid>
        <TextBox x:Name="resultsTextBox" IsReadOnly="True" VerticalScrollBarVisibility="Auto" HorizontalScrollBarVisibility="Auto" TextWrapping="Wrap"/>
    </Grid>
</Window>

ResultsWindow Code-Behind:

public partial class ResultsWindow : Window
{
    public ResultsWindow(string result)
    {
        InitializeComponent();
        resultsTextBox.Text = result;
    }
}

Step 4: Update dbInterface to Handle SQL Query Execution
Add the ExecuteQuery method to dbInterface:

public async Task<string> ExecuteQuery(string query, string strFilePath)
{
    string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strFilePath;
    using (OleDbConnection connection = new OleDbConnection(connectionString))
    {
        try
        {
            await connection.OpenAsync();
            OleDbCommand command = new OleDbCommand(query, connection);

            using (OleDbDataReader reader = await command.ExecuteReaderAsync())
            {
                string results = "";
                while (await reader.ReadAsync())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        results += reader[i] + "\t";
                    }
                    results += Environment.NewLine;
                }
                return results;
            }
        }
        catch (Exception ex)
        {
            return "Error: " + ex.Message;
        }
    }
}

This will give your app the ability to execute SQL queries and display the results in a new window. How does this setup feel for you?

 */