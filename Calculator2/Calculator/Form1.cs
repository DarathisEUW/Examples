using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestWindowsFormApp
{
    public partial class Windows_Form_Start : Form
    {
        string input = string.Empty;
        string opp1 = string.Empty;
        string opp2 = string.Empty;
        char operation;

        float answer;

        //////////////////////////////////////////////////////////////////////////////
        ////////////////////////////Forms generated code//////////////////////////////
        //////////////////////////////////////////////////////////////////////////////
        public Windows_Form_Start()
        {
            InitializeComponent();
        }
        private void Windows_Form_Start_Load(object sender, EventArgs e)
        {
            //well didn't mean to make this but now it looks like I am stuck with it
        }
///////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////Clear and Result///////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////
        private void buttonClear_Click(object sender, EventArgs e)
        {
            input = string.Empty;
            opp1 = string.Empty;
            opp2 = string.Empty;

            answer = 0;

            textBox1.Text = string.Empty;
        }
        private void buttonAnswer_Click(object sender, EventArgs e)
        {
            opp2 = input;

            float numb1, numb2;
            float.TryParse(opp1, out numb1);
            float.TryParse(opp2, out numb2);
            //ADD
            if(operation == '+')
            {
                answer = numb1 + numb2;
                textBox1.Text = answer.ToString();
            }
            //Subtract
            else if (operation == '-')
            {
                answer = numb1 - numb2;
                textBox1.Text = answer.ToString();
            }
            //Multiply
            else if (operation == '*')
            {
                answer = numb1 * numb2;
                textBox1.Text = answer.ToString();
            }
            //Divide
            else if (operation == '/')
            {
                if (numb2 != 0)
                {
                    answer = numb1 / numb2;
                    textBox1.Text = answer.ToString();
                }
                else
                {
                    textBox1.Text = "Cannot divide by 0";
                }
            }

            //additional calculations code (little hacky)
                //clears second number
                opp2 = string.Empty;
                //inputs answer as first number
                input = answer.ToString();
            
        }

        //////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////Opperations///////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////
        //TODO: Make it Scientific
            //Square, Square root, Cube, Cube root, powers of
            //brackets for longer sums
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            opperationInput();
            operation = '+';
        }
        private void buttonSubtract_Click(object sender, EventArgs e)
        {
            opperationInput();
            operation = '-';
        }
        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            opperationInput();
            operation = '*';
        }
        private void buttonDivide_Click(object sender, EventArgs e)
        {
            opperationInput();
            operation = '/';
        }
        private void opperationInput()
        {
            opp1 = input;
            input = string.Empty;
        }

        //////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////Number Entry///////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////
        //TODO: add decimal point button so you can enter decimals
        //TODO: throw into a switch to make it look a little prettier
        private void button1_Click(object sender, EventArgs e)
        {
            input += "1";
            showTextEntry();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            input += "2";
            showTextEntry();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            input += "3";
            showTextEntry();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            input += "4";
            showTextEntry();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            input += "5";
            showTextEntry();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            input += "6";
            showTextEntry();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            input += "7";
            showTextEntry();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            input += "8";
            showTextEntry();
        }
        private void button9_Click(object sender, EventArgs e)
        {
            input += "9";
            showTextEntry();
        }
        private void button0_Click(object sender, EventArgs e)
        {
            input += "0";
            showTextEntry();
        }
        //Updates visible text to show numbers
        private void showTextEntry()
        {
            textBox1.Text = input;
        }
    }
}
