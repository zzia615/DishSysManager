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

        List<CartInfo> GetCartList()
        {
            List<CartInfo> dataList = new List<CartInfo>();
            foreach (Control control in flowLayoutPanel2.Controls)
            {
                if (control is ucCart)
                {
                    var cart = control as ucCart;
                    var info = cart.GetCartInfo();
                    dataList.Add(info);
                }
            }
            return dataList;
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
                var db = SqlUtil.Inst;
                string ord_no = db.GetLsh("order");

                var trans = db.Database.BeginTransaction();
                try
                {
                    var order = new Data.Order
                    {
                        zffs = zffs,
                        isJz = 1,
                        no = ord_no,
                        yhje = yhje,
                        zje = zje
                    };

                    db.Orders.Add(order);
                    List<Data.Detail> details = new List<Data.Detail>();
                    foreach (var data in GetCartList())
                    {
                        var detail = new Data.Detail
                        {
                            m_id = data.id,
                            m_mc = data.title,
                            m_price = data.price,
                            m_sl = data.num,
                            ord_no = ord_no
                        };

                        db.Details.Add(detail);
                    }

                    db.SaveChanges();
                    trans.Commit();
                    MessageBox.Show("结账成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("结账失败\r\n"+ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            };
            var dr = formJz.ShowDialog();
            if(dr== DialogResult.OK)
            {
                button2_Click(null, null);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            LoadMenu();
        }
    }
}
