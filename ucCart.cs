using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DishSysManager
{
    public partial class ucCart : UserControl
    {
        private readonly MenuInfo menuInfo;
        public EventHandler CalPriceHandle;
        public ucCart(MenuInfo menuInfo)
        {
            InitializeComponent();
            this.menuInfo = menuInfo;
            pictureBox1.ImageLocation = menuInfo.img_url;
            label1.Text = menuInfo.title;
            label2.Text = menuInfo.price.ToString("0.00");
            textBox1.Text = "1";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                Parent.Controls.Remove(this);
            }
            else
            {
                if (textBox1.Text != "0")
                {
                    if (textBox1.Text == "1")
                    {

                        Parent.Controls.Remove(this);
                    }
                    else
                    {
                        textBox1.Text = (int.Parse(textBox1.Text) - 1).ToString();

                        if (CalPriceHandle != null)
                            CalPriceHandle(sender, e);
                    }
                }
                else
                {
                    Parent.Controls.Remove(this);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Text = "1";
            }
            else
            {
                textBox1.Text = (int.Parse(textBox1.Text) + 1).ToString();
            }
            if (CalPriceHandle != null)
                CalPriceHandle(sender, e);
        }

        public CartInfo GetCartInfo()
        {
            return new CartInfo
            {
                id = menuInfo.id,
                img_url = menuInfo.img_url,
                num = int.Parse(textBox1.Text),
                price = menuInfo.price,
                title = menuInfo.title,
                isRxc = menuInfo.isRxc,
                isTjc = menuInfo.isTjc
            };
        }

        public void AddCartNum()
        {
            button2_Click(null, null);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Text = "0";
            }
            if (CalPriceHandle != null)
                CalPriceHandle(sender, e);
        }
    }
}
