using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace String_Stuff
{
    public partial class stringForm : Form
    {
        public stringForm()
        {
            InitializeComponent();
        }

        private string SwitchCase(string input) // Takes a string and returns a string with swapped casing
        {
            string output = "";

            for(int i = 0; i < input.Length; i++)
            {
                if (char.IsUpper(input[i]))         // If the character is uppercase...
                    output += (char.ToLower(input[i]));     // Copy it as a lowercase letter
                else if (char.IsLower(input[i]))
                    output += (char.ToUpper(input[i]));
            }

            return output;
        }

        private string Reverse(string input)    // Takes a string and returns a string with reversed order
        {
            string output = "";

            for (int i = 0; i < input.Length; i++)
                output += input[input.Length - i - 1];

            return output;
        }

        private string PigLatin(string input)   // Takes a string, moves the lirst letter to the end, adds "ay" to the end, then returns that string
        {
            string output = input;                  // Copy the string
            output = output.Remove(0, 1);           // Remove the first letter
            output += input[0] + "ay";              // Add the removed letter to the end and add "ay" after that

            return output;
        }

        private string ShiftCypher(string input, int charsToShift)      // Shifts characters in the string "charsToShift" times, and returns that string
        {
            string output = "";

            char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n',
                'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };           // Lower case alphabet
            char[] ALPHABET = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N',
                'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };           // Upper case alphabet

            for (int i = 0; i < input.Length; i++)
            {
                for(int a = 0; a < alphabet.Length; a++)
                {
                    if (input[i] == alphabet[a])            // Test whether or not the character is part of the lowercase or uppercase alphabet
                        output += alphabet[(a + charsToShift) % alphabet.Length];       // Then add the coresponding letter to the output string
                    else if (input[i] == ALPHABET[a])
                        output += ALPHABET[(a + charsToShift) % ALPHABET.Length];
                }
            }

            return output;
        }

        private string SubCypher(string input, string charsToSub)   // Passes in a string to modify, and a string representing letters in the alphabet. Replace letters in the first string with characters in the second. Return string
        {
            string output = "";

            char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n',
                'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };           // Lower case alphabet
            char[] ALPHABET = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N',
                'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };           // Upper case alphabet

            for (int i = 0; i < input.Length; i++)
            {
                for (int a = 0; a < alphabet.Length; a++)
                {
                    if (input[i] == alphabet[a] || input[i] == ALPHABET[a])         // Test if the character is a part of either alphabet
                        output += charsToSub[a];            // Then add the coresponding character from the string "charsToSub"
                }
            }

            return output;
        }

        private void transformButton_Click(object sender, EventArgs e)
        {
            string input = inputTextBox.Text;                   // Take the users input

            switchCaseTextBox.Text = SwitchCase(input);         // Then fill the message boxs with the coresponding output
            reverseTextBox.Text = Reverse(input);
            pigLatinTextBox.Text = PigLatin(input);
            shiftTextBox.Text = ShiftCypher(input, 1);
            subTextBox.Text = SubCypher(input, "CDEFGHIJKLMNOPQRSTUVWXYZAB");
        }
    }
}