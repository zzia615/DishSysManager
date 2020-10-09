using DishSysManager.Util;
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
    public partial class FormMenuEdit : Form
    {
        private readonly Data.Menu menu;

        public FormMenuEdit(int ct_id)
        {
            InitializeComponent();

            comboBox1.DataSource = SqlUtil.Inst.Catagories.ToList();
            comboBox1.DisplayMember = "mc";
            comboBox1.ValueMember = "id";

            comboBox1.SelectedValue = ct_id;
        }
        public FormMenuEdit(Data.Menu menu)
        {
            InitializeComponent();
            this.menu = menu;

            comboBox1.DataSource = SqlUtil.Inst.Catagories.ToList();
            comboBox1.DisplayMember = "mc";
            comboBox1.ValueMember = "id";
            //界面赋值
            comboBox1.SelectedValue = menu.ct_id;
            textBox1.Text = menu.mc;
            numericUpDown1.Value = (decimal)menu.price;
            checkBox1.Checked = menu.isTjc == 1 ? true : false;
            checkBox2.Checked = menu.isRxc == 1 ? true : false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mc = textBox1.Text;
            int ct_id = (int)comboBox1.SelectedValue;
            int isTjc = checkBox1.Checked ? 1 : 0;
            int isRxc = checkBox2.Checked ? 1 : 0;
            double price = (double)numericUpDown1.Value;

            if (string.IsNullOrEmpty(mc))
            {
                MessageBox.Show("菜品名称不能为空，请输入", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var db = SqlUtil.Inst;
            if (menu != null)
            {
                var tmp = db.Menus.FirstOrDefault(a => a.id == menu.id);
                tmp.isRxc = isRxc;
                tmp.isTjc = isTjc;
                tmp.mc = mc;
                tmp.price = price;
                tmp.ct_id = ct_id;

                db.Entry(tmp).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                MessageBox.Show("修改菜品成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var tmp = new Data.Menu();
                tmp.isRxc = isRxc;
                tmp.isTjc = isTjc;
                tmp.mc = mc;
                tmp.price = price;
                tmp.ct_id = ct_id;

                db.Menus.Add(tmp);
                db.SaveChanges();
                MessageBox.Show("新增菜品成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            DialogResult = DialogResult.OK;
        }
        
    }
}
