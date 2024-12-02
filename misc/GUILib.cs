#region usings
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
#endregion

namespace PhilAccessSQLInterface.misc
{
    public class GUILib
    {
        #region Messageboxes and Popups
        //////////////////////
        // Messageboxes / Popups
        //////////////////////

        // Show a generic popup message
        public void ShowMsg(string strTitle, string strMsg)
        {
            MessageBox.Show(strMsg, strTitle);
        }

        // Generic ErrorPopUp
        public void ErrorPopUp(string strTitle, string strError)
        {
            MessageBox.Show(strError, strTitle, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        // Show a yes/no popup message
        // Returns false if they click no, true if they click yes
        // Defaults to the warning messagebox image, but this is chosen by the user if they want
        public bool YesNoMessageBox(string strMessage, string strTitle, MessageBoxImage mbImage = MessageBoxImage.Warning)
        {
            bool booYes;
            if (MessageBox.Show(strMessage, strTitle, MessageBoxButton.YesNo, mbImage) == MessageBoxResult.Yes)
            {
                // User clicks Yes
                booYes = true;
            }
            else
            {
                // User clicks No 
                booYes = false;
            }

            return booYes;
        }

        #endregion

        #region Misc Functions
        //////////////////////
        // Misc
        //////////////////////

        // Shortcut function
        // Fills a combobox given an array of strings then selects the first one
        public void FillComboBox(ComboBox cbComboBox, string[] arrString, bool booSelectIndexZero = true)
        {
            // init the combobox
            for (int i = 0; i < arrString.Length; i++)
            {
                cbComboBox.Items.Add(arrString[i]);
            }

            if (booSelectIndexZero == true)
            {
                cbComboBox.SelectedIndex = 0;
            }
        }

        // Get array of strings from combobox
        public string[] GetComboBoxStringArray(ComboBox cbComboBox)
        {
            // Build an array of strings to return
            string[] arrRetVal = new string[cbComboBox.Items.Count];

            // Fill in the array
            for (int i = 0; i < cbComboBox.Items.Count; i++)
            {
                arrRetVal[i] = cbComboBox.Items[i].ToString();
            }

            return arrRetVal;
        }
        #endregion

        #region How to handle a form closing (example)
        ///* 
        //         * This is how we can intercept the window closing and do something
        //         * You need to add the following to the xaml of the form
        //         * Closing="DataWindow_Closing"
        //         * Put that inside the initial <window x:Name etc..>
        //         */
        //private void DataWindow_Closing(object sender, CancelEventArgs e)
        //{
        //    if (booProceed == false)
        //    {
        //        // this exit attempt was called by the user quitting/clicking X
        //        bool booResult = guiHelper.YesNoMessageBox(GameConsts.GUI_QUIT_QUERY, GameConsts.GAME_TITLE);
        //        if (booResult == false)
        //        {
        //            // If user doesn't want to close, cancel closure
        //            e.Cancel = true;
        //        }
        //        else
        //        {
        //            // Well they want to quit, so we're going to quit
        //            Environment.Exit(0);
        //        }
        //    }
        //}
        #endregion
    }
}
