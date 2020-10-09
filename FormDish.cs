using DishSysManager.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DishSysManager
{
    public partial class FormDish : Form
    {
        public FormDish()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var dataList = SqlUtil.Inst.Catagories.ToList();
            dataList.Insert(0, new Data.Catagory
            {
                id = 0,
                mc = "全部"
            });
            comboBox1.DisplayMember = "mc";
            comboBox1.ValueMember = "id";
            comboBox1.DataSource = dataList;

            comboBox1.SelectedValue = 0;
        }


        void LoadMenu()
        {
            int ct_id = (int)comboBox1.SelectedValue;
            flowLayoutPanel1.Controls.Clear();
            BackgroundWorker bgWorker = new BackgroundWorker();
            bgWorker.DoWork += (sender, e) =>
            {
                var query = SqlUtil.Inst.Menus.AsQueryable();
                if (ct_id > 0)
                {
                    query = query.Where(a => a.ct_id == ct_id);
                }
                var menus = query.ToList();
                foreach (var info in menus)
                {
                    this.Invoke(new Action(() =>
                    {
                        var menu = new ucMenu(new MenuInfo
                        {
                            id = info.id,
                            img_url = "",
                            title = info.mc,
                            price = info.price,
                            isRxc = info.isRxc == 1 ? true : false,
                            isTjc = info.isTjc == 1 ? true : false
                        });
                        menu.SelectedMenu = SelectedMenu;
                        flowLayoutPanel1.Controls.Add(menu);
                    }));
                }

            };
            bgWorker.RunWorkerAsync();
        }
        

        private void SelectedMenu(object sender, MenuInfo info)
        {
            foreach(Control control in flowLayoutPanel2.Controls)
            {
                if(control is ucCart)
                {
                    var uc = (control as ucCart);
                    var tmp = uc.GetCartInfo();
                    if(tmp.id== info.id)
                    {
                        uc.AddCartNum();
                        uc.Focus();
                        return;
                    }
                }
            }


            var cart = new ucCart(info);
            cart.CalPriceHandle = CalPriceHandle;
            flowLayoutPanel2.Controls.Add(cart);
            cart.Focus();
        }

        private void CalPriceHandle(object sender, EventArgs e)
        {
            CalPrice();
        }

        private void flowLayoutPanel2_ControlAdded(object sender, ControlEventArgs e)
        {
            CalPrice();
        }

        private void flowLayoutPanel2_ControlRemoved(object sender, ControlEventArgs e)
        {
            CalPrice();
        }


        void CalPrice()
        {
            double total_price = 0;
            foreach (Control control in flowLayoutPanel2.Controls)
            {
                if(control is ucCart)
                {
                    var cart = control as ucCart;
                    var info = cart.GetCartInfo();
                    total_price += info.price*info.num;
                }
            }

            label2.Text = total_price.ToString("0.00");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            flowLayoutPanel2.Controls.Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMenu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double zje = double.Parse(label2.Text);
            FormJz formJz = new FormJz(zje);
            formJz.SaveOrder = (zffs, yhje) =>
            {
                return true;
            };
            var dr = formJz.ShowDialog();
            if(dr== DialogResult.OK)
            {
                button2_Click(null, null);
            }
        }
    }
}
