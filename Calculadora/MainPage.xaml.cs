using System;
using Xamarin.Forms;

namespace Calculadora
{
    public partial class MainPage : ContentPage
    {
        private string currentNumber = "";
        private string operation = "";
        private double firstNumber = 0;
        private bool isNewCalculation = true;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnNumberClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string pressed = button.Text;

            if (isNewCalculation || resultText.Text == "0")
            {
                resultText.Text = "";
                isNewCalculation = false;
            }

            currentNumber += pressed;
            resultText.Text += pressed;
        }

        private void OnOperatorClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string newOperation = button.Text;

            if (!string.IsNullOrEmpty(currentNumber))
            {
                firstNumber = double.Parse(currentNumber);
                currentNumber = "";
                operation = newOperation;
                calculationText.Text = $"{firstNumber} {operation}";
                resultText.Text = "0";
            }
            else if (!string.IsNullOrEmpty(operation))
            {
                operation = newOperation;
                calculationText.Text = $"{firstNumber} {operation}";
            }
        }

        private void OnEqualsClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentNumber) && !string.IsNullOrEmpty(operation))
            {
                double secondNumber = double.Parse(currentNumber);
                double result = 0;

                switch (operation)
                {
                    case "+":
                        result = firstNumber + secondNumber;
                        break;
                    case "-":
                        result = firstNumber - secondNumber;
                        break;
                    case "×":
                        result = firstNumber * secondNumber;
                        break;
                    case "÷":
                        if (secondNumber != 0)
                            result = firstNumber / secondNumber;
                        else
                            resultText.Text = "Error";
                        break;
                }

                if (resultText.Text != "Error")
                {
                    calculationText.Text = $"{firstNumber} {operation} {secondNumber} =";
                    resultText.Text = result.ToString();
                    currentNumber = result.ToString();
                    isNewCalculation = true;
                }
            }
        }

        private void OnClearClicked(object sender, EventArgs e)
        {
            resultText.Text = "0";
            calculationText.Text = "";
            currentNumber = "";
            operation = "";
            firstNumber = 0;
            isNewCalculation = true;
        }

        private void OnDecimalClicked(object sender, EventArgs e)
        {
            if (isNewCalculation)
            {
                resultText.Text = "0";
                currentNumber = "0";
                isNewCalculation = false;
            }

            if (!currentNumber.Contains("."))
            {
                currentNumber += ".";
                resultText.Text += ".";
            }
        }

        private void OnPercentClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentNumber))
            {
                double number = double.Parse(currentNumber);
                number = number / 100;
                currentNumber = number.ToString();
                resultText.Text = currentNumber;
            }
        }

        private void OnNegateClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentNumber))
            {
                double number = double.Parse(currentNumber);
                number = -number;
                currentNumber = number.ToString();
                resultText.Text = currentNumber;
            }
        }
    }
}