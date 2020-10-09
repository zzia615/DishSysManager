using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DishSysManager
{
    public partial class FormJz : Form
    {
        public Func<string, double,bool> SaveOrder;
        public FormJz(double zje)
        {
            InitializeComponent();
            textBox1.Text = zje.ToString("0.00");
            textBox2.Text = "0";
            textBox4.Text = (double.Parse(textBox1.Text) - double.Parse(textBox2.Text)).ToString("0.00");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.Text = "0";
            }
            textBox4.Text = (double.Parse(textBox1.Text) - double.Parse(textBox2.Text)).ToString("0.00");

            textBox3_TextChanged(null, null);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                textBox3.Text = "0";
            }
            textBox5.Text = (double.Parse(textBox3.Text) - double.Parse(textBox4.Text)).ToString("0.00");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double zje = double.Parse(textBox1.Text);
            double yhje = double.Parse(textBox2.Text);
            double ssje = double.Parse(textBox3.Text);

            if (yhje > zje)
            {
                MessageBox.Show("优惠金额不能大于总金额", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (ssje < zje - yhje)
            {
                MessageBox.Show("实收金额不足，请联系顾客", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }



            string zffs = "现金";



            if (radioButton2.Checked)
            {
                zffs = radioButton2.Text;
            }
            if (radioButton3.Checked)
            {
                zffs = radioButton3.Text;
            }
            if (radioButton4.Checked)
            {
                zffs = radioButton4.Text;
            }
            if (SaveOrder(zffs, yhje))
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
