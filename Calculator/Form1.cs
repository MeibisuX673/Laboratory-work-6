using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        Calculator calc;
        public Form1()
        {
            InitializeComponent();
            calc = new Calculator();
            calc.didUpdateValue += CalculatorDidUpdateValue;
            calc.InputError += CalculatorInputError;
            calc.EqullyError += CalculatorInternalError;
            calc.MinusSqrtError += CalculatorMinusError;
            calc.Clear();
        }

        private void CalculatorMinusError(Calculator sender, string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CalculatorInputError(Calculator sender, string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CalculatorDidUpdateValue(Calculator sender, double value, int precision)
        {
            label1.Text = value.ToString();
        }

        private void CalculatorInternalError(Calculator sender,string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button_Click(object sender, EventArgs e)
        {
            int digit = -1;
            Button b = sender as Button;
            if(int.TryParse(b.Text,out digit))
            {
                
                calc.AddDigit(digit);
            }
            else
            {
                switch (b.Tag)
                {

                    case "minus":
                        calc.CountPointOff();
                        calc.AddOperation(CalculatorOperation.Mul);
                        
                        break;
                    case "plus":
                        calc.AddOperation(CalculatorOperation.Add);
                        calc.CountPointOff();
                        break;
                    case "clear":
                        calc.CountPointOff();
                        calc.Clear();
                        break;
                    case "div":
                        calc.AddOperation(CalculatorOperation.Div);
                        calc.CountPointOff();
                        break;
                    case "mult":
                        calc.AddOperation(CalculatorOperation.Sub);
                        calc.CountPointOff();
                        break;
                    case "equally":

                        calc.Compute();
                        calc.Equlay();
                        calc.CountPointOff();
                        break;
                    case "ClearAll":
                        calc.ClearAll();
                        calc.CountPointOff();
                        break;
                    case "point":
                        
                        this.label1.Text += ",";
                        calc.Point();
                        break;
                    case "sqrt":
                        calc.CountPointOff();
                        calc.AddOperation2(CalculatorOperation2.Sqrt);      
                        break;
                    case "sqr":
                        calc.CountPointOff();
                        calc.AddOperation2(CalculatorOperation2.Sqr);
                        break;
                    case "gip":
                        calc.CountPointOff();
                        calc.AddOperation2(CalculatorOperation2.Gip);
                        break;
                    case "polar":
                        calc.CountPointOff();
                        calc.Polar();
                        break;
                    case "clearEnd":
                        calc.ClearEnd();
                        break;
                    case "procent":
                        calc.CountPointOff();
                        calc.AddOperation2(CalculatorOperation2.Proc);
                        break;
                    default:
                        break;
                }

            }

        }



        
    }
}
