using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private double firstNumber = 0;
        private string operation = "";
        private bool isOperationPerformed = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void NumButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (txtDisplay.Text == "0" || isOperationPerformed)
                txtDisplay.Clear();

            isOperationPerformed = false;

            if (btn.Text == ".")
            {
                if (!txtDisplay.Text.Contains("."))
                    txtDisplay.Text += ".";
            }
            else
            {
                txtDisplay.Text += btn.Text;
            }
        }

        private void OpButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (firstNumber != 0 && !isOperationPerformed)
            {
                CalculateResult();
            }

            firstNumber = Convert.ToDouble(txtDisplay.Text);
            operation = btn.Text;
            isOperationPerformed = true;
        }

        private void EqualButton_Click(object sender, EventArgs e)
        {
            CalculateResult();
            operation = "";
        }

        private void CalculateResult()
        {
            double secondNumber = Convert.ToDouble(txtDisplay.Text);

            switch (operation)
            {
                case "+":
                    txtDisplay.Text = (firstNumber + secondNumber).ToString();
                    break;
                case "-":
                    txtDisplay.Text = (firstNumber - secondNumber).ToString();
                    break;
                case "*":
                    txtDisplay.Text = (firstNumber * secondNumber).ToString();
                    break;
                case "/":
                    if (secondNumber != 0)
                        txtDisplay.Text = (firstNumber / secondNumber).ToString();
                    else
                        MessageBox.Show("Sıfıra bölmək olmaz!", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

            firstNumber = Convert.ToDouble(txtDisplay.Text);
            isOperationPerformed = true;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            firstNumber = 0;
            operation = "";
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text.Length > 1)
                txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1);
            else
                txtDisplay.Text = "0";
        }
    }
}