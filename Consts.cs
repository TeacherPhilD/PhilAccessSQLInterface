#region Imports
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace PhilAccessSQLInterface
{
    // Project-wide constants
    public class Consts
    {
        #region About
        public const string PROGRAM_TITLE = "PhilAccessSQLInterface";
        public const string ABOUT_AUTHOR = "Phillip Donald";
        public const string ABOUT_VERSION = "1.1";
        public const string ABOUT_ICON = "\nSQL icon created by Freepik - Flaticon\nhttps://www.flaticon.com/free-icons/sql";
        #endregion

        #region GUI Strings
        public const string MAIN_DB_EXEC_PROGRESS = "Executing query...";
        public const string MAIN_DB_EXEC_FINISHED = "Query executed";
        public const string MAIN_CHECK_DB = "Checking database...";
        public const string MAIN_PATH_DEFAULT = "No path set";
        public const string MAIN_GUI_RESET = "GUI has been reset";

        public const string MAIN_OPEN_ACCESS_FILE_FILTER = "Access Database (*.accdb)|*.accdb|All files (*.*)|*.*";
        public const string MAIN_SAVE_LOG_FILE_FILTER = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

        public const string LOG_SPACER = "--- ---";

        public const string SQL_EXISTENCE_ERROR = "SQL Query is empty, please enter a SQL Query";
        public const string SQL_EXISTENCE_ERROR_TITLE = "SQL Existence Check Error";
        #endregion

        #region Results Config
        public const int RESULTS_COLUMN_WIDTH = 32; // Default width for each column
        #endregion
    }
}
