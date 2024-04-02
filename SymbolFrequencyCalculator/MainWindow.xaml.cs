using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace SymbolFrequencyCalculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            string filePath = FilePathTextBox.Text;

            if (File.Exists(filePath))
            {
                Dictionary<char, int> symbolFrequencies = CalculateSymbolFrequencies(filePath);

                double entropy = CalculateEntropy(symbolFrequencies);

                OutputTextBox.Text = "Symbol frequencies:\n";
                foreach (var pair in symbolFrequencies)
                {
                    OutputTextBox.Text += $"{pair.Key}: {pair.Value}\n";
                }
                OutputTextBox.Text += $"\nEntropy: {entropy}";
            }
            else
            {
                OutputTextBox.Text = "File not found!";
            }
        }

        private Dictionary<char, int> CalculateSymbolFrequencies(string filePath)
        {
            Dictionary<char, int> frequencies = new Dictionary<char, int>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                int currentChar;
                while ((currentChar = reader.Read()) != -1)
                {
                    char character = (char)currentChar;
                    if (frequencies.ContainsKey(character))
                        frequencies[character]++;
                    else
                        frequencies[character] = 1;
                }
            }

            return frequencies;
        }

        private double CalculateEntropy(Dictionary<char, int> symbolFrequencies)
        {
            int totalSymbols = symbolFrequencies.Sum(pair => pair.Value);
            double entropy = 0.0;

            foreach (var pair in symbolFrequencies)
            {
                double probability = (double)pair.Value / totalSymbols;
                entropy -= probability * Math.Log(probability, 2);
            }

            return entropy;
        }
    }
}

