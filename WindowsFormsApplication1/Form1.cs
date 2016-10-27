using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        private void button_Number_Click(object sender, EventArgs e)
        {
            if (Display_NumberInput.Text == "0")
            {
                Display_NumberInput.Text = ((Button)sender).Text;
            }
            else
            {
                Display_NumberInput.Text += ((Button)sender).Text;
            }
            
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            Display_NumberInput.Text = Convert.ToString("0");
            Display_Calc_Number.ResetText();
            Disp_Calc_Symbol.ResetText();
        }

        private void button_Calc_Click(object sender, EventArgs e)
        {
            if (Disp_Calc_Symbol.Text == "")
            {
                Display_Calc_Number.Text = Display_NumberInput.Text;
                Disp_Calc_Symbol.Text = ((Button)sender).Text;
            }
            else
            {
                if(Display_Calc_Number.Text == "")
                {
                    Display_Calc_Number.Text = Display_NumberInput.Text;
                }
                else
                {
                    int Equal_data = 0;
                    int Input_data = Convert.ToInt32(Display_Calc_Number.Text);
                    int Calc_data = Convert.ToInt32(Display_NumberInput.Text);

                    if (Disp_Calc_Symbol.Text == "+")
                    {
                        Equal_data = Input_data + Calc_data;
                    }
                    else if (Disp_Calc_Symbol.Text == "-")
                    {
                        Equal_data = Input_data - Calc_data;
                    }
                    else if (Disp_Calc_Symbol.Text == "×")
                    {
                        Equal_data = Input_data * Calc_data;
                    }
                    else if (Disp_Calc_Symbol.Text == "÷")
                    {
                        if (Calc_data == 0)
                        {
                            Equal_data = Input_data;
                        }
                        else
                        {
                            Equal_data = (Input_data / Calc_data);
                        }
                    }

                    Display_Calc_Number.Text = Convert.ToString(Equal_data);
                }

                Disp_Calc_Symbol.Text = ((Button)sender).Text;
            }
            
            Display_NumberInput.Text = Convert.ToString("0");
        }

        private void button_Equal_Click(object sender, EventArgs e)
        {
            int Input_data = 0;
            if (Display_Calc_Number.Text != "")
            {
                Input_data = Convert.ToInt32(Display_Calc_Number.Text);
            }
            int Calc_data = Convert.ToInt32(Display_NumberInput.Text);

            int Equal_data = 0;
            if(Disp_Calc_Symbol.Text != "")
            {
                if (Disp_Calc_Symbol.Text == "+")
                {
                    Equal_data = Input_data + Calc_data;
                }
                else if (Disp_Calc_Symbol.Text == "-")
                {
                    Equal_data = Input_data - Calc_data;
                }
                else if (Disp_Calc_Symbol.Text == "×")
                {
                    Equal_data = Input_data * Calc_data;
                }
                else if (Disp_Calc_Symbol.Text == "÷")
                {
                    if (Calc_data == 0)
                    {
                        Equal_data = Input_data;
                    }
                    else
                    {
                        Equal_data = (Input_data / Calc_data);
                    }
                }
                Display_NumberInput.Text = Convert.ToString(Equal_data);
                Display_Calc_Number.ResetText();
                Disp_Calc_Symbol.ResetText();
            }



        }
    }
}
