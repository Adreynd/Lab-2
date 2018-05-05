using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CSV_Reader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public double Average(int[] scores)
        {
            double average = 0;
            int total = 0;

            // Calculate the total of the
            // test score tokens.
            for (int i = 0; i <scores.Length; i++)
                total += scores[i];
            // Calculate the average of these
            // test scores.
            average = total / scores.Length;
            return average;
        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader inputFile; // To read the file
                string line;            // To hold a line from the file
                string[] tokens;        // Holds the individual test scores as token after a line has been split
                int[] scores;           // Array that holds test scores after they have been converted to ints
                double average = 0;     // Test score average
                int count = 0;          // Holds the student index

                // Create a delimiter variable
                char delim = ',';

                // Open the CSV file.
                inputFile = File.OpenText("..\\..\\Grades.csv");

                while (!inputFile.EndOfStream)
                {
                    // Read a line from the file.
                    line = inputFile.ReadLine();
                    // Get the test scores as tokens.
                    tokens = line.Split(delim);
                    scores = new int[tokens.Length];

                    for(int i = 0; i < tokens.Length; i++)
                        scores[i] = Convert.ToInt32(tokens[i]);

                    // calculate the average by calling the method Average
                    // Display the average.
                    average = Average(scores);
                    count++;
                    averagesListBox.Items.Add("The average for student " +
                        count + " is " + average.ToString("n1"));
                }

                // Close the file.
                inputFile.Close();
            }
            catch (Exception ex)
            {
                // Display an error message.
                MessageBox.Show(ex.Message);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}