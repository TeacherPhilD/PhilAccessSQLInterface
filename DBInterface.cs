#region Imports
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Windows.Media.Animation;
#endregion

namespace PhilAccessSQLInterface
{
    // This class does all the heavy lifting for interacting with access and executing sql queries and so on
    internal class DBInterface
    {
        #region Class Variables
        public DBInterface()
        { }
        #endregion

        #region Database Functions
        // Execute SQL on the specified filepath
        public async Task<string> ExecuteQuery(string strQuery, string strFilePath)
        {
            int columnWidth = Consts.RESULTS_COLUMN_WIDTH; // Default width for each column
                                        
            // Connection string for accessing the Excel file using the Microsoft ACE OLEDB provider
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strFilePath;
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    // Open the connection asynchronously
                    await connection.OpenAsync();
                    OleDbCommand command = new OleDbCommand(strQuery, connection);

                    // Execute the query asynchronously and obtain the data reader
                    using (OleDbDataReader reader = (OleDbDataReader)await command.ExecuteReaderAsync())
                    {
                        StringBuilder results = new StringBuilder();

                        // Read column names for the header
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            results.Append(reader.GetName(i).PadRight(columnWidth)).Append("\t");
                        }
                        results.AppendLine();

                        // Read the query results asynchronously
                        while (await reader.ReadAsync())
                        {
                            // Append each column's value, padded to the column width
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                results.Append(reader[i].ToString().PadRight(columnWidth)).Append("\t");
                            }
                            results.AppendLine();
                        }
                        return results.ToString();
                    }
                }
                catch (Exception ex)
                {
                    // Return the error message if an exception occurs
                    return "Error: " + ex.Message;
                }
            }
        }

        // Attempts to open a connection to an Access database and returns the result as a string.
        //
        // strFilePath: The file path of the Access database to check.
        //
        // returns: A string indicating the success or failure of opening the database connection. If successful, returns "Success opening database". If an error occurs, returns the error message.
        // Exception: Returns the exception message if an error occurs during the connection attempt.
        public async Task<string> CheckAccessDB(string strFilePath)
        {
            // Default return value in case of an error
            string strRetVal = "Default Error";

            // Connection string for accessing the Access database using the Microsoft ACE OLEDB provider
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strFilePath;

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    // Attempt to open the connection asynchronously
                    await connection.OpenAsync();
                    strRetVal = "Success opening database";
                }
                catch (Exception ex)
                {
                    // Return the error message if an exception occurs
                    strRetVal = "Error: " + ex.Message;
                }
                finally
                {
                    // Ensure the connection is closed, even if an exception occurs
                    connection.Close();
                }
            }

            return strRetVal;
        }
#endregion
    }
}