#region imports
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
using System.IO; // We need this if we are going to use files!
#endregion

namespace PhilAccessSQLInterface
{
    /// <summary>
    /// Interaction logic for ResultsWindow.xaml
    /// </summary>
    public partial class ResultsWindow : Window
    {
        #region Class Variables
        string strResult;
        string strQuery;
        FileLib fileLib = new FileLib();
        GUILib guiCollection = new GUILib();
        #endregion

        #region GUI Functions
        public ResultsWindow(string strResultA, string strQueryA)
        {
            InitializeComponent();

            strResult = strResultA;
            strQuery = strQueryA;

            InitGUI();
            LogSQL();
            LogResults();
        }

        // Fill in the GUI with SQL, results and so on
        private void InitGUI()
        {
            txtResults.Text = strResult;
            lblSQLQuery.Content = strQuery;
        }
        #endregion

        #region File Functions

        // Log SQL to a file (append)
        private void LogSQL()
        {
            string strFilePath = AppDomain.CurrentDomain.BaseDirectory + "SQL_Log.txt";
            bool booSuccess = SaveSQL(strFilePath, true); // append is true

            if (booSuccess == true)
            {
                statusTextBlock.Text = $"SQL Logged to: {strFilePath}";
            }
        }

        // Log Results to a file (append)
        private void LogResults()
        {
            string strFilePath = AppDomain.CurrentDomain.BaseDirectory + "SQL_Results.txt";
            bool booSuccess = SaveResults(strFilePath, true); // append is true

            if (booSuccess == true)
            {
                statusTextBlock.Text += $"\nResults Logged to: {strFilePath}";
            }
        }

        // Save SQL to file
        private bool SaveSQL(string strFilePath, bool booAppend = false)
        {
            bool booSuccess = true;

            if (booAppend == false)
            {
                // Write new file
                try
                {
                    // Create the actual file
                    using (StreamWriter fileStr = File.CreateText(strFilePath))
                    {
                        // Datestamp
                        DateTime dt = DateTime.Now;
                        string strDateStamp = dt.ToString("G");
                        fileStr.WriteLine(strDateStamp);

                        // Pretty spacer
                        fileStr.WriteLine(Consts.LOG_SPACER);

                        // SQL
                        fileStr.WriteLine(strQuery);

                        // Pretty spacer (ending)
                        fileStr.WriteLine(Consts.LOG_SPACER + '\n');
                    }
                }
                catch (Exception excpFile)
                {
                    booSuccess = false;
                    guiCollection.ErrorPopUp("Error Saving SQL", excpFile.ToString());
                }
            }
            else
            {
                try
                {
                    if (!File.Exists(strFilePath))
                    {
                        // If the file doesn't exist, we'll make a blank one
                        using (StreamWriter fileStr = File.CreateText(strFilePath))
                        {
                            // Writing a blank text file
                            string strLineOne = "";
                            fileStr.Write(strLineOne);
                        }
                    }

                    // This block of code will append (add to) the file
                    using (StreamWriter swFile = File.AppendText(strFilePath))
                    {
                        // Datestamp
                        DateTime dt = DateTime.Now;
                        string strDateStamp = dt.ToString("G");
                        swFile.WriteLine(strDateStamp);

                        // Pretty spacer
                        swFile.WriteLine(Consts.LOG_SPACER);

                        // SQL
                        swFile.WriteLine(strQuery);

                        // Pretty spacer (ending)
                        swFile.WriteLine(Consts.LOG_SPACER + '\n');
                    }
                }
                catch (Exception excpFile)
                {
                    booSuccess = false;
                    guiCollection.ErrorPopUp("Error Appending SQL", excpFile.ToString());
                }
            }

            return booSuccess;
        }

        // Save Results to file
        private bool SaveResults(string strFilePath, bool booAppend = false)
        {
            bool booSuccess = true;

            if (booAppend == false)
            {
                // Write new file
                try
                {
                    // Create the actual file
                    using (StreamWriter fileStr = File.CreateText(strFilePath))
                    {
                        // Datestamp
                        DateTime dt = DateTime.Now;
                        string strDateStamp = dt.ToString("G");
                        fileStr.WriteLine(strDateStamp);

                        // Pretty spacer
                        fileStr.WriteLine(Consts.LOG_SPACER);

                        // SQL
                        fileStr.WriteLine(strQuery);

                        // Pretty spacer
                        fileStr.WriteLine(Consts.LOG_SPACER);

                        // Result
                        fileStr.WriteLine(strResult);

                        // Pretty spacer (ending)
                        fileStr.WriteLine(Consts.LOG_SPACER + '\n');
                    }
                }
                catch (Exception excpFile)
                {
                    booSuccess = false;
                    guiCollection.ErrorPopUp("Error Saving Results", excpFile.ToString());
                }
            }
            else
            {
                try
                {
                    if (!File.Exists(strFilePath))
                    {
                        // If the file doesn't exist, we'll make a blank one
                        using (StreamWriter fileStr = File.CreateText(strFilePath))
                        {
                            // Writing a blank text file
                            string strLineOne = "";
                            fileStr.Write(strLineOne);
                        }
                    }

                    // This block of code will append (add to) the file
                    using (StreamWriter swFile = File.AppendText(strFilePath))
                    {
                        // Datestamp
                        DateTime dt = DateTime.Now;
                        string strDateStamp = dt.ToString("G");
                        swFile.WriteLine(strDateStamp);

                        // Pretty spacer
                        swFile.WriteLine(Consts.LOG_SPACER);

                        // SQL
                        swFile.WriteLine(strQuery);

                        // Pretty spacer
                        swFile.WriteLine(Consts.LOG_SPACER);

                        // Result
                        swFile.WriteLine(strResult);

                        // Pretty spacer (ending)
                        swFile.WriteLine(Consts.LOG_SPACER + '\n');
                    }
                }
                catch (Exception excpFile)
                {
                    booSuccess = false;
                    guiCollection.ErrorPopUp("Error Appending Results", excpFile.ToString());
                }
            }

            return booSuccess;
        }

        // Choose the filepath for SQL
        private void ChooseFileSQL()
        {
            string strFilePath = fileLib.SaveFileBrowser("SQL_File");

            bool booSuccess = SaveSQL(strFilePath);

            if (booSuccess == true)
            {
                statusTextBlock.Text = $"Saved Query to: {strFilePath}";
            }
        }

        // Choose the filepath for results
        private void ChooseFileResults()
        {
            string strFilePath = fileLib.SaveFileBrowser("Results_File");

            bool booSuccess = SaveResults(strFilePath);

            if (booSuccess == true)
            {
                statusTextBlock.Text = $"Saved Results to: {strFilePath}";
            }
        }
        #endregion

        #region Listeners
        private void btnSaveSQL_Click(object sender, RoutedEventArgs e)
        {
            ChooseFileSQL();
        }

        private void btnSaveResults_Click(object sender, RoutedEventArgs e)
        {
            ChooseFileResults();
        }
        #endregion
    }
}
