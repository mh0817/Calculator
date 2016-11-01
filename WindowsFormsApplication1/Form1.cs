using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//エラー制御用変数
enum Error : int
{
    DIV_NOT_ZERO = 0,
    DIV_ZERO
}

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
            else if(Disp_Calc_Symbol.Text == "E")
            {
            }
            else
            {
                checked { 
                    Display_NumberInput.Text += ((Button)sender).Text;
                }
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
            try
            {
                checked
                {
                    if (Disp_Calc_Symbol.Text == "")
                    {
                        Display_Calc_Number.Text = Display_NumberInput.Text;
                        Disp_Calc_Symbol.Text = ((Button)sender).Text;
                    }
                    else if(Disp_Calc_Symbol.Text == "E")
                    {
                        
                    }
                    else
                    {
                        if (Display_Calc_Number.Text == "")
                        {
                            Display_Calc_Number.Text = Display_NumberInput.Text;
                        }
                        else
                        {
                            int Equal_data = 0;
                            int Input_data = Convert.ToInt32(Display_Calc_Number.Text);


                            if(Display_NumberInput.Text != "")
                            {
                                                            int Calc_data = Convert.ToInt32(Display_NumberInput.Text);
                                switch (Disp_Calc_Symbol.Text)
                                {
                                    case "+":
                                        Equal_data = Input_data + Calc_data;
                                        break;
                                    case "-":
                                        Equal_data = Input_data - Calc_data;
                                        break;
                                    case "×":
                                        Equal_data = Input_data * Calc_data;
                                        break;
                                    case "÷":
                                        if (Calc_data == 0)
                                        {
                                            Display_NumberInput.Text = "０で割るやつとかｗｗｗ";
                                            Disp_Calc_Symbol.Text = "E";
                                        }
                                        else
                                        {
                                            Equal_data = (Input_data / Calc_data);
                                        }
                                        break;
                                }
                                Display_Calc_Number.Text = Convert.ToString(Equal_data);
                            }

                        }
                        Disp_Calc_Symbol.Text = ((Button)sender).Text;

                    }
                    if(Disp_Calc_Symbol.Text != "E")
                    {
                        Display_NumberInput.Text = "";
                    }
                }
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("CHECKED and CAUGHT:  " + ex.ToString());
                Display_NumberInput.Text = "-------";
                Display_Calc_Number.Text = "";
                Disp_Calc_Symbol.Text = "E";
            }
        }

        private void button_Equal_Click(object sender, EventArgs e)
        {
            try
            {
                checked
                {
                    int Input_data = 0;
                    int Calc_data = 0;
                    int Equal_data = 0;

                    if (Disp_Calc_Symbol.Text != "")
                    {
                        if(Disp_Calc_Symbol.Text != "E")
                        {
                            if (Display_Calc_Number.Text != "")
                            {
                                Input_data = Convert.ToInt32(Display_Calc_Number.Text);
                            }
                            if (Display_NumberInput.Text != "")
                            {
                                Calc_data = Convert.ToInt32(Display_NumberInput.Text);
                                switch (Disp_Calc_Symbol.Text)
                                {
                                    case "+":
                                        Equal_data = Input_data + Calc_data;
                                        break;
                                    case "-":
                                        Equal_data = Input_data - Calc_data;
                                        break;
                                    case "×":
                                        Equal_data = Input_data * Calc_data;
                                        break;
                                    case "÷":
                                        if (Calc_data == 0)
                                        {
                                            Display_NumberInput.Text = "０で割るやつとかｗｗｗ";
                                            Disp_Calc_Symbol.Text = "E";
                                        }
                                        else
                                        {
                                            Equal_data = (Input_data / Calc_data);
                                        }
                                        break;
                                }
                                Display_NumberInput.Text = Convert.ToString(Equal_data);
                            }
                            else
                            {
                                Display_NumberInput.Text = Display_Calc_Number.Text;
                            }
                            Display_Calc_Number.ResetText();
                            Disp_Calc_Symbol.ResetText();
                        }
                    }
                    else if (Disp_Calc_Symbol.Text == "E")
                    {

                    }
                }
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("CHECKED and CAUGHT:  " + ex.ToString());
                Display_NumberInput.Text = "-------";
                Display_Calc_Number.Text = "";
                Disp_Calc_Symbol.Text = "E";
            }

        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //IMEを無効にする
            base.ImeMode = ImeMode.Disable;

            if (System.Text.RegularExpressions.Regex.IsMatch(Display_NumberInput.Text, "^[0-9]+$") == false)
            {
　            MessageBox.Show("数字じゃない文字が入ってる！");
              e.Handled = true;
            }


            // 数字(0-9)は入力可
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
                return;
            }

            // 小数点は１つだけ入力可
            if (e.KeyChar == '.')
            {
                TextBox target = sender as TextBox;
                if (target.Text.IndexOf('.') < 0)
                {
                    // 複数のピリオド入力はNG
                    e.Handled = false;
                    return;
                }
            }

            // 上記以外は入力不可
            e.Handled = true;
        }

    }
}
