using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Telephone_Format
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // The NumberDigits method accepts a string argument
        // and returns the number of numeric digits it contains.
        private int NumberDigits(string str)
        {
            int digits = 0;  // The number of digits

            // Count the digits in str.
            for (int i = 0; i < str.Length; i++)
                if (char.IsDigit(str, i))
                    digits++;
            // Return the number of digits.
            return digits;
        }

        // The IsValidNumber method accepts a string and
        // returns true if it contains 10 digits, or false
        // otherwise.
        private bool IsValidNumber(string str)
        {
            const int VALID_LENGTH = 10;  // Length of a valid string

            if (NumberDigits(str) != VALID_LENGTH)      // Return false if the length isn't correct
                return false;
            for (int i = 0; i < str.Length; i++)        // Return false if any part of the string isn't a digit
                if (!char.IsDigit(str, i))
                    return false;
                    // Return the status.
            return true;
        }

        // The TelephoneFormat method accepts a string argument
        // by reference and formats it as a telephone number.
        // phone number format is ###-###-####
        private void TelephoneFormat(ref string str)
        {
            str = str.Insert(0, "(");
            str = str.Insert(4, ")");
            str = str.Insert(5, "-");
            str = str.Insert(9, "-");
        }

        private void formatButton_Click(object sender, EventArgs e)
        {
            // Get a trimmed copy of the user's input.
            string input = numberTextBox.Text.Trim();

            // If the input is a valid number, format it
            // and display it.
            if ((IsValidNumber(input)))
            {
                TelephoneFormat(ref input);
                MessageBox.Show(input);
            }
            else
            {
                // Display an error message.
                MessageBox.Show("Invalid input");
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
