using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCalculator
{
    public class Computer
    {
        public double Compute(double number1, double number2, string operation)
        {
            switch (operation)
            {
                case "+": return (number1 + number2);
                case "-": return (number1 - number2);
                case "X": return (number1 * number2);
                case "/":
                    {
                        if (number2 == 0)
                            throw new DivideByZeroException();
                        return (number1 / number2);
                    }
                default:
                    throw new ArgumentException();
            }
        }
    }
}
