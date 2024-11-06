#region imports
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // We need this if we are going to use files!
using System.Windows.Documents;
#endregion

namespace PhilAccessSQLInterface.misc
{
    public class FileLib
    {
        public const string OPEN_FILE_DIALOG_ERROR = "No file has been selected";
        public FileLib()
        {
            // blank constructor
        }

        /*
         * Function: OpenFileBrowser()
         * Argument(s): [optional] Filter settings
         * Author: Phillip Donald
         * Last Edited: 27/11/2023
         * Purpose: Use open dialog to return a path
         */
        public string OpenFileBrowser(string strFilter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
            string strInitialDirectory = "Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)")
        {
            string strRetVal = "error"; // if this value is returned, an error has occured!
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = strFilter;
            openFileDialog.InitialDirectory = strInitialDirectory;

            if (openFileDialog.ShowDialog() == true)
            {
                // if it is true we will return the file name
                strRetVal = openFileDialog.FileName;
            }
            else
            {
                strRetVal = OPEN_FILE_DIALOG_ERROR;
            }

            return strRetVal;
        }

        /*
         * Function: SaveFileBrowser()
         * Argument(s): strFileName is path
         * strFilter is the filter that adds the extension, defaults to "Text files (*.txt)|*.txt"
         * booAddExtension controls whether file extension is added, defaults to true
         * strTitle is the title of the window, defaults to "Save As"
         * strInitialDirectiory is where the directory it starts in, defaults to .exe directory
         * 
         * Author: Phillip Donald
         * Last Edited: 19/07/2023
         * Purpose: Use open dialog to return a path for saving
         */
        public string SaveFileBrowser(string strFileName, string strFilter = "Text files (*.txt)|*.txt",
            bool booAddExtension = true, string strTitle = "Save As", string strInitialDirectory = "AppDomain.CurrentDomain.BaseDirectory")
        {
            string strRetVal = "SaveFileBrowser() error"; // if this value is returned, an error has occured!
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // configure the Save File Dialog
            saveFileDialog.Filter = strFilter;
            saveFileDialog.InitialDirectory = strInitialDirectory;
            saveFileDialog.AddExtension = booAddExtension;
            saveFileDialog.Title = strTitle;
            saveFileDialog.FileName = strFileName;

            if (saveFileDialog.ShowDialog() == true)
            {
                strRetVal = saveFileDialog.FileName;
            }

            return strRetVal;
        }

        /*
         * Function: AppendToTextFile()
         * Argument(s): strFile is path of the file
         * strAppendText is the text that will be added
         * 
         * Author: Phillip Donald
         * Last Edited: 19/07/2023
         * Purpose: Add to the bottom of a text file
         */
        public void AppendToTextFile(string strFile, string strAppendText)
        {
            try
            {
                if (!File.Exists(strFile))
                {
                    // If the file doesn't exist, we'll make a blank one
                    using (StreamWriter fileStr = File.CreateText(strFile))
                    {
                        // Writing a blank text file
                        string strLineOne = "";
                        fileStr.Write(strLineOne);
                    }
                }

                // This block of code will append (add to) the file
                using (StreamWriter swFile = File.AppendText(strFile))
                {
                    swFile.WriteLine(strAppendText);
                }
            }
            catch (Exception excpFile)
            {
                Console.WriteLine(excpFile.ToString());
            }
        }

        /*
         * Function: DeleteTextFile()
         * Argument(s): strFile is path of the file
         * 
         * Author: Phillip Donald
         * Last Edited: 19/07/2023
         * Purpose: Delete a text file
         */
        public void DeleteTextFile(string strFile)
        {
            try
            {
                // Delete the file if it exists.
                if (File.Exists(strFile))
                {
                    File.Delete(strFile);
                }
            }
            catch (Exception excpFile)
            {
                Console.WriteLine(excpFile.ToString());
            }
        }

        /*
         * Function: ReadTextFile()
         * Argument(s): strFile is path of the file
         * 
         * Author: Phillip Donald
         * Last Edited: 19/07/2023
         * Purpose: Returns a string that is the contents of a file
         */
        public string ReadTextFile(string strFile)
        {
            try
            {
                string strFileText = "";
                // This block of code is how we read from a file
                using (StreamReader srFileRead = File.OpenText(strFile))
                {
                    string strTemp = "";
                    while ((strTemp = srFileRead.ReadLine()) != null)
                    {
                        strFileText += strTemp;
                    }
                }

                return strFileText;
            }
            catch (Exception excpFile)
            {
                Console.WriteLine(excpFile.ToString());
                return excpFile.ToString();
            }
        }

        /*
         * Function: WriteTextFile()
         * Argument(s): strFile is path of the file
         * strText is the string to write
         * 
         * Author: Phillip Donald
         * Last Edited: 19/07/2023
         * Purpose: Writes text to a new file
         */
        public void WriteTextFile(string strFile, string strText)
        {
            try
            {
                // Create the actual file
                using (StreamWriter fileStr = File.CreateText(strFile))
                {
                    // Write our text
                    fileStr.WriteLine(strText);
                }
            }
            catch (Exception excpFile)
            {
                Console.WriteLine(excpFile.ToString());
            }
        }

        /*
         * Function: GetBaseDirectory()
         * 
         * Author: Phillip Donald
         * Last Edited: 19/07/2023
         * Purpose: Gets the base directory of the executable
         */
        public string GetBaseDirectory()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        /*
         * Function: DoesFileExist()
         * Argument(s): strPath is the path to the file
         * 
         * Author: Phillip Donald
         * Last Edited: 19/07/2023
         * Purpose: Gets the base directory of the executable
         */
        public bool DoesFileExist(string strPath)
        {
            bool boolExists = true;
            if (!File.Exists(strPath))
            {
                boolExists = false;
            }

            return boolExists;
        }

        /*
         * Left in for your reference
			Function: SaveRTFLog()
			Argument(s): txtContent is all of the text in the RichTextBox, strFile is the file path
			Author: Phillip Donald
			Last Edited: 31/05/2021
			Purpose: Saves the log
			*/
        //public void SaveRTFLog(TextRange txtContent, string strFile)
        //{
        //    FileStream fiStream = new FileStream(strFile, FileMode.Create);
        //    txtContent.Save(fiStream, System.Windows.Data);
        //    fiStream.Close();
        //}
    }
}
