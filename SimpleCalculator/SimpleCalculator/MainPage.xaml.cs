using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SimpleCalculator
{
	public partial class MainPage : ContentPage
	{
        private double number1;
        private double number2;
        private string operation = string.Empty;
        private int clickCounter = 0;
        private bool isComputed = false;

		public MainPage()
		{
			InitializeComponent();
		}

        private void OnClickedNumber(object sender, EventArgs e)
        {
            clickCounter++;

            if (clickCounter < 2)
            {
                lblResult.Text = ((Button)sender).Text;
                return;
            }
            lblResult.Text += ((Button)sender).Text;
        }

        private void OnClickedOperator(object sender, EventArgs e)
        {
            if (clickCounter > 0 || isComputed)
            {
                number1 = double.Parse(lblResult.Text);
                operation = ((Button)sender).Text;
                clickCounter = 0;
            }
        }

        private void OnClickedEquals(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(operation))
            {
                number2 = double.Parse(lblResult.Text);
                var computer = new Computer();
                try
                {
                    lblResult.Text = computer.Compute(number1, number2, operation).ToString();
                    clickCounter = 0;
                    isComputed = true;
                }
                catch (Exception)
                {
                    lblResult.Text = "Math Error";
                }
            }
        }

        private void OnClickedClear(object sender, EventArgs e)
        {
            lblResult.Text = "0";
            operation = string.Empty;
            clickCounter = 0;
            isComputed = false;
        }
    }
}
