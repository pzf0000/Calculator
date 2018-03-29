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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            // 结果输出框禁止输入
            textBox_Result.Enabled = false;
        }

        private void button_Calculate_Click(object sender, EventArgs e)
        {
            string cal = textBox_CalculateString.Text;
            if(cal == null || cal == "")
            {
                textBox_Result.Text = "算式为空";
            }
            else
            {
                string result = Calculator.Calculate(cal);
                textBox_Result.Text = result;
            }
        }
    }
}
