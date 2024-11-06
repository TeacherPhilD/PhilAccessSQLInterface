using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PhilAccessSQLInterface
{
    public class ValidLib
    {
        #region Constructor
        public ValidLib()
        {
            // empty
        }
        #endregion

        #region Generic Validations
        /////////////
        // Generic Validations
        /////////////

        /*
			Function: IsStringEmpty()
			Argument(s): string to check
			Author: Phillip Donald
			Last Edited: 31/05/2021
			Purpose: Validation function that checks if a string is empty (no characters) or not
			*/
        public bool IsStringEmpty(string strIn)
        {
            bool booValid = false;
            if (strIn.Equals("") || strIn.Equals(string.Empty))
            {
                booValid = true;
            }

            return booValid;

            // Example use:
            //if(valCheck.IsStringEmpty(strName))
            //    {
            //        lblDebug.Content = "Name cannot be empty!";
            //    }
        }

        /*
			Function: IsStringNumericInteger()
			Argument(s): string to check
			Author: Phillip Donald
			Last Edited: 31/05/2021
			Purpose: Validation function that checks if a string can be converted to an integer
			*/
        public bool IsStringNumericInteger(string strIn)
        {
            int intRetVal = -999;
            bool booValid = int.TryParse(strIn, out intRetVal);
            // If this fails to convert properly, intRetVal will = 0 and booValid will = false

            return booValid;
        }

        /*
			Function: IsStringNumericDouble()
			Argument(s): string to check
			Author: Phillip Donald
			Last Edited: 31/05/2021
			Purpose: Validation function that checks if a string can be converted to a double
			*/
        public bool IsStringNumericDouble(string strIn)
        {
            double dblRetVal = -999;
            bool booValid = double.TryParse(strIn, out dblRetVal);
            // If this fails to convert properly, intRetVal will = 0 and booValid will = false

            return booValid;
        }

        /*
			Function: IsIntNumberInRange()
			Argument(s): int to check, minimum and maximum
			Author: Phillip Donald
			Last Edited: 31/05/2021
			Purpose: Validation function that checks if an integer is within a range
			*/
        public bool IsIntNumberInRange(int intIn, int intMin, int intMax)
        {
            bool booNumInRange = true;
            // With this logic, we accept the number (don't turn booNumInRange to false) if it is between intMin-intMax inclusive.
            if (intIn < intMin || intIn > intMax)
            {
                booNumInRange = false;
            }

            return booNumInRange;
        }

        /*
			Function: IsStringAndStringEqual()
			Argument(s): 2x strings
			Author: Phillip Donald
			Last Edited: 31/05/2021
			Purpose: See if two strings are the same text
			*/
        public bool IsStringAndStringEqual(string strOne, string strTwo)
        {
            bool booValid = string.Equals(strOne, strTwo);
            return booValid;
        }

        /*
			Function: IsStringX3Equal()
			Argument(s): 3x strings
			Author: Phillip Donald
			Last Edited: 02/06/2021
			Purpose: See if three strings are the same text
			*/
        public bool IsStringX3Equal(string strOne, string strTwo, string strThree)
        {
            bool booValid1 = string.Equals(strOne, strTwo);
            bool booValid2 = string.Equals(strOne, strThree);
            bool booValid3 = string.Equals(strTwo, strThree);

            if (booValid1 == true && booValid2 == true && booValid3 == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*
			Function: RoundNum()
			Argument(s): double to round
			Author: Phillip Donald
			Last Edited: 31/05/2021
			Purpose: Round to the nearest whole number
			*/
        public double RoundNum(double dblNum)
        {
            // how to round to the nearest whole number
            double dblOut = Math.Round(dblNum);

            return dblOut;
        }

        /*
			Function: RoundNum()
			Argument(s): double to round and how many decimal places to round to
			Author: Phillip Donald
			Last Edited: 31/05/2021
			Purpose: Round to x decimal points
			*/
        public double RoundNum(double dblNum, int intDecimalPlace)
        {
            // How to round to x decimal places (in this case 3)
            double dblOut = Math.Round(dblNum, intDecimalPlace);

            return dblOut;
        }

        /*
			Function: RoundDoubleToInt()
			Argument(s): double to turn to an int with rounding
			Last Edited: 13/07/2022
			Purpose: simple round to integer
			*/
        public int RoundDoubleToInt(double dblIn)
        {
            if (dblIn < 0)
            {
                return (int)(dblIn - 0.5);
            }
            return (int)(dblIn + 0.5);
        }

        /*
			Function: RemoveRoundBracketsNumbersAndTrim()
			Argument(s): string to trim
            Author: Phillip Donald
			Last Edited: 07/08/2023
			Purpose: Removes numbers and brackets
            Example: In: "Lightning Bolt (20)" Out: "Lightning Bolt"
			*/
        public string RemoveRoundBracketsNumbersAndTrim(string strIn)
        {
            // example strIn = "Lightning Bolt (20)
            strIn = Regex.Replace(strIn, @"[()0-9]", ""); // remove (20)
            strIn = strIn.Trim(); // removes the " " at the end. (space at the end)
            return strIn;
        }

        /*
			Function: IsWordMatchSpaceNum()
			Argument(s): string to check, string of word to check for
            Author: Phillip Donald
			Last Edited: 28/1/2023
			Purpose: Determines if word + number
            Example: In: "Lightning Bolt 20" Out: true
            Example: In: "Lightning Bolt" Out: false
			*/

        public bool IsWordMatchSpaceNum(string strInput, string strWordToMatch)
        {
            return Regex.IsMatch(strInput, ".*" + strWordToMatch + "[0-9]+$");
        }

        /*
			Function: IsNumAtEndofString()
			Argument(s): string to check
            Author: Phillip Donald
			Last Edited: 1/12/2023
			Purpose: Whether the inputted string has a number at the end or not
            Example: In: "Lightning Bolt 20" Out: true
            Example: In: "Lightning Bolt" Out: false
			*/
        public bool IsNumAtEndofString(string strInput)
        {
            return char.IsDigit(strInput.Last());
        }
        #endregion

        #region Console convenience functions
        /////////////
        // Console convenience functions
        /////////////

        // get a string
        public string ConsoleGetString(string strQuestion)
        {
            bool booValid = false;
            string strUserInput = String.Empty;
            while (booValid == false)
            {
                Console.Write($"{strQuestion} ");
                strUserInput = Console.ReadLine();

                if (!strUserInput.Equals(String.Empty) && !strUserInput.Equals(""))
                {
                    booValid = true;
                }
            }

            return strUserInput;
        }

        // get an int
        public int ConsoleGetInteger(string strQuestion)
        {
            Console.Write(strQuestion + " ");
            int intNum = -999; // error value
            while (!int.TryParse(Console.ReadLine(), out intNum))
            {
                Console.Write("The value must be an integer, try again: ");
            }

            return intNum;
        }

        // get a double
        public double ConsoleGetDouble(string strQuestion)
        {
            Console.Write(strQuestion + " ");
            double dblNum = -999; // error value
            while (!double.TryParse(Console.ReadLine(), out dblNum))
            {
                Console.Write("The value must be a double, try again: ");
            }

            return dblNum;
        }

        // get a validated int
        public int ConsoleGetValidInteger(string strQuestion, int intMin, int intMax)
        {
            bool booNumCheck = true;
            int intNum = -999; // error value
            while (booNumCheck == true)
            {
                intNum = ConsoleGetInteger(strQuestion);

                if (intNum >= intMin && intNum <= intMax)
                {
                    // number is between intMin and intMax inclusive
                    booNumCheck = false;
                }
                else
                {
                    // number is invalid
                    Console.WriteLine("Invalid input, must be between " + intMin + " and " + intMax);
                }
            }

            return intNum;
        }

        // get a validated double
        public double ConsoleGetValidDouble(string strQuestion, double dblMin, double dblMax)
        {
            bool booNumCheck = true;
            double dblNum = -999; // error value
            while (booNumCheck == true)
            {
                // Safely get input from user
                dblNum = ConsoleGetDouble(strQuestion);

                if (dblNum >= dblMin && dblNum <= dblMax)
                {
                    // number is between intMin and intMax inclusive
                    booNumCheck = false;
                }
                else
                {
                    // number is invalid
                    Console.WriteLine("Invalid input, must be between " + dblMin + " and " + dblMax);
                }
            }

            return dblNum;
        }

        public string WordWrap(string strInput, int intLineLength = 35)
        {
            // Takes a string and "word wraps" it by inserting a new line ('\n')
            // every x characters. Where x characters is intLineLength.

            // split string up into words using ' ' (a space)
            string[] stringSplit = strInput.Split(' ');

            int intCharCount = 0;
            string strOutput = ""; // init output

            for (int i = 0; i < stringSplit.Length; i++)
            {
                strOutput += stringSplit[i] + " ";
                intCharCount += stringSplit[i].Length;

                // true if this "word" contains a line break
                bool booContainsLineBreak = stringSplit[i].Contains("\n");

                // If it contains a line break this wont happen
                // Before putting this in it would sometimes insert multiple
                // line breaks
                if (intCharCount > intLineLength && booContainsLineBreak == false)
                {
                    strOutput += "\n"; // add a new line
                    intCharCount = 0;
                }
            }

            return strOutput;
        }
        #endregion
    }
}
