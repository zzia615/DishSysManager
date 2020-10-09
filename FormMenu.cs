using DishSysManager.Data;
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
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
            this.treeView1.HideSelection = false;//失去焦点后不隐藏选中节点
            //自已绘制  
            this.treeView1.DrawMode = TreeViewDrawMode.OwnerDrawText;
            this.treeView1.DrawNode += new DrawTreeNodeEventHandler(treeView1_DrawNode);
        }
        private void treeView1_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            e.DrawDefault = true; //使用默认颜色，只需要在TreeView失去焦点时选中节点仍然突显  
            return;
        }


        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 新增分类ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCatagory form = new FormCatagory();
            form.Text = "新增菜品分类";
            var dr = form.ShowDialog();
            if(dr== DialogResult.OK)
            {
                RefreshCatagory();
            }
        }

        private void RefreshCatagory()
        {
            treeView1.Nodes.Clear();
            var dataList = SqlUtil.Inst.Catagories.ToList();
            foreach(var data in dataList)
            {
                TreeNode node = new TreeNode(data.mc);
                node.Tag = data;
                treeView1.Nodes.Add(node);
            }
            if (treeView1.Nodes.Count > 0)
            {
                treeView1.SelectedNode = treeView1.Nodes[0];
            }
        }

        private void 修改分类ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;
            var catagory = node.Tag as Data.Catagory;
            if (catagory != null)
            {
                FormCatagory form = new FormCatagory(catagory);
                form.Text = "修改菜品分类";
                var dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    RefreshCatagory();
                }
            }
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            RefreshCatagory();
            treeView1.Focus();
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if(e.Button== MouseButtons.Left)
            {
                修改分类ToolStripMenuItem_Click(null, null);
            }
        }

        private void 删除分类ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;
            var catagory = node.Tag as Data.Catagory;
            if (catagory != null)
            {

                var dr = MessageBox.Show($"是否删除菜品分类【{catagory.mc}】", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dr== DialogResult.Yes)
                {
                    var db = SqlUtil.Inst;
                    var tmp = db.Catagories.FirstOrDefault(a => a.id == catagory.id);
                    db.Entry(tmp).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                    RefreshCatagory();
                    MessageBox.Show("已成功删除菜品分类", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;
            var catagory = node.Tag as Data.Catagory;
            if (catagory != null)
            {
                RefreshMenu(catagory.id);

                label1.Text = "当前菜品分类："+catagory.mc;
            }
        }

        private void RefreshMenu(int ct_id)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = SqlUtil.Inst.Menus.Where(a => a.ct_id == ct_id).ToList();

        }

        private void 新增菜品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;
            var catagory = node.Tag as Data.Catagory;
            if (catagory == null)
            {
                MessageBox.Show("请先选择一个菜品分类", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FormMenuEdit form = new FormMenuEdit(catagory.id);
            form.Text = "新增菜品";
            var dr = form.ShowDialog();
            if (dr == DialogResult.OK)
            {
                RefreshMenu(catagory.id);
            }
        }

        private void 修改菜品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请先选择一个菜品", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var menu = dataGridView1.SelectedRows[0].DataBoundItem as Data.Menu;
            FormMenuEdit form = new FormMenuEdit(menu);
            form.Text = "修改菜品";
            var dr = form.ShowDialog();
            if (dr == DialogResult.OK)
            {
                TreeNode node = treeView1.SelectedNode;
                var catagory = node.Tag as Data.Catagory;
                if (catagory != null)
                    RefreshMenu(catagory.id);
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewColumn col = dataGridView1.Columns[e.ColumnIndex];
            if (col.Name == isRxcDataGridViewTextBoxColumn.Name
                ||col.Name == isTjcDataGridViewTextBoxColumn.Name)
            {
                if ((int)e.Value == 0)
                {
                    e.Value = "否";
                }
                else
                {
                    e.Value = "是";
                }
            }
        }

        private void 删除菜品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请先选择一个菜品", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var menu = dataGridView1.SelectedRows[0].DataBoundItem as Data.Menu;
            if (menu != null)
            {

                var dr = MessageBox.Show($"是否删除菜品【{menu.mc}】", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    var db = SqlUtil.Inst;
                    var tmp = db.Menus.FirstOrDefault(a => a.id == menu.id);
                    db.Entry(tmp).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                    RefreshMenu(menu.ct_id);
                    MessageBox.Show("已成功删除菜品", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                修改菜品ToolStripMenuItem_Click(null, null);
            }
        }
    }
}
