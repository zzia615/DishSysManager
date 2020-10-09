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
    public partial class FormCatagory : Form
    {
        private readonly Data.Catagory catagory;

        public FormCatagory()
        {
            InitializeComponent();
        }
        public FormCatagory(Data.Catagory catagory)
        {
            InitializeComponent();
            this.catagory = catagory;

            textBox1.Text = catagory.mc;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mc = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(mc))
            {
                MessageBox.Show("菜品分类不能为空，请输入", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var db = SqlUtil.Inst;
            var data = db.Catagories.FirstOrDefault(a => a.mc == mc);
            if (catagory != null)
            {
                if (data != null)
                {
                    if (data.id != catagory.id)
                    {
                        MessageBox.Show("菜品分类已经存在，请重新输入", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                var tmp = db.Catagories.FirstOrDefault(a => a.id == catagory.id);
                tmp.mc = mc;
                //执行修改操作
                db.Entry(tmp).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                MessageBox.Show("修改菜品分类成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (data != null)
                {
                    MessageBox.Show("菜品分类已经存在，请重新输入", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //执行新增操作
                db.Catagories.Add(new Data.Catagory
                {
                    mc = mc
                });
                db.SaveChanges();
                MessageBox.Show("新增菜品分类成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            DialogResult = DialogResult.OK;
        }
    }
}
