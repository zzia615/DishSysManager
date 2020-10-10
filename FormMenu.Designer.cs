namespace DishSysManager
{
    partial class FormMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.新增分类ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改分类ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.删除分类ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripDropDownButton();
            this.新增菜品ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改菜品ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.删除菜品ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mcDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isTjcDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isRxcDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.menuBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.Font = new System.Drawing.Font("宋体", 10F);
            this.treeView1.Location = new System.Drawing.Point(1, 28);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(182, 422);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.mcDataGridViewTextBoxColumn,
            this.ctidDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn,
            this.isTjcDataGridViewTextBoxColumn,
            this.isRxcDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.menuBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(189, 47);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(611, 403);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton5,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 27);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(187, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 3;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新增分类ToolStripMenuItem,
            this.修改分类ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.删除分类ToolStripMenuItem});
            this.toolStripButton1.Image = global::DishSysManager.Properties.Resources.MoreFunctions_32x32;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(65, 24);
            this.toolStripButton1.Text = "分类";
            // 
            // 新增分类ToolStripMenuItem
            // 
            this.新增分类ToolStripMenuItem.Name = "新增分类ToolStripMenuItem";
            this.新增分类ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.新增分类ToolStripMenuItem.Text = "新增分类";
            this.新增分类ToolStripMenuItem.Click += new System.EventHandler(this.新增分类ToolStripMenuItem_Click);
            // 
            // 修改分类ToolStripMenuItem
            // 
            this.修改分类ToolStripMenuItem.Name = "修改分类ToolStripMenuItem";
            this.修改分类ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.修改分类ToolStripMenuItem.Text = "修改分类";
            this.修改分类ToolStripMenuItem.Click += new System.EventHandler(this.修改分类ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(121, 6);
            // 
            // 删除分类ToolStripMenuItem
            // 
            this.删除分类ToolStripMenuItem.Name = "删除分类ToolStripMenuItem";
            this.删除分类ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.删除分类ToolStripMenuItem.Text = "删除分类";
            this.删除分类ToolStripMenuItem.Click += new System.EventHandler(this.删除分类ToolStripMenuItem_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新增菜品ToolStripMenuItem,
            this.修改菜品ToolStripMenuItem,
            this.toolStripMenuItem2,
            this.删除菜品ToolStripMenuItem});
            this.toolStripButton5.Image = global::DishSysManager.Properties.Resources.MoreFunctions_32x32;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(65, 24);
            this.toolStripButton5.Text = "菜品";
            // 
            // 新增菜品ToolStripMenuItem
            // 
            this.新增菜品ToolStripMenuItem.Name = "新增菜品ToolStripMenuItem";
            this.新增菜品ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.新增菜品ToolStripMenuItem.Text = "新增菜品";
            this.新增菜品ToolStripMenuItem.Click += new System.EventHandler(this.新增菜品ToolStripMenuItem_Click);
            // 
            // 修改菜品ToolStripMenuItem
            // 
            this.修改菜品ToolStripMenuItem.Name = "修改菜品ToolStripMenuItem";
            this.修改菜品ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.修改菜品ToolStripMenuItem.Text = "修改菜品";
            this.修改菜品ToolStripMenuItem.Click += new System.EventHandler(this.修改菜品ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
            // 
            // 删除菜品ToolStripMenuItem
            // 
            this.删除菜品ToolStripMenuItem.Name = "删除菜品ToolStripMenuItem";
            this.删除菜品ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.删除菜品ToolStripMenuItem.Text = "删除菜品";
            this.删除菜品ToolStripMenuItem.Click += new System.EventHandler(this.删除菜品ToolStripMenuItem_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::DishSysManager.Properties.Resources.Cancel_32x32;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(56, 24);
            this.toolStripButton2.Text = "关闭";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "ID";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mcDataGridViewTextBoxColumn
            // 
            this.mcDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.mcDataGridViewTextBoxColumn.DataPropertyName = "mc";
            this.mcDataGridViewTextBoxColumn.HeaderText = "名称";
            this.mcDataGridViewTextBoxColumn.Name = "mcDataGridViewTextBoxColumn";
            this.mcDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ctidDataGridViewTextBoxColumn
            // 
            this.ctidDataGridViewTextBoxColumn.DataPropertyName = "ct_id";
            this.ctidDataGridViewTextBoxColumn.HeaderText = "分类";
            this.ctidDataGridViewTextBoxColumn.Name = "ctidDataGridViewTextBoxColumn";
            this.ctidDataGridViewTextBoxColumn.ReadOnly = true;
            this.ctidDataGridViewTextBoxColumn.Visible = false;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "price";
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.priceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.priceDataGridViewTextBoxColumn.HeaderText = "单价";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // isTjcDataGridViewTextBoxColumn
            // 
            this.isTjcDataGridViewTextBoxColumn.DataPropertyName = "isTjc";
            this.isTjcDataGridViewTextBoxColumn.HeaderText = "推荐菜";
            this.isTjcDataGridViewTextBoxColumn.Name = "isTjcDataGridViewTextBoxColumn";
            this.isTjcDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // isRxcDataGridViewTextBoxColumn
            // 
            this.isRxcDataGridViewTextBoxColumn.DataPropertyName = "isRxc";
            this.isRxcDataGridViewTextBoxColumn.HeaderText = "热销菜";
            this.isRxcDataGridViewTextBoxColumn.Name = "isRxcDataGridViewTextBoxColumn";
            this.isRxcDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // menuBindingSource
            // 
            this.menuBindingSource.DataSource = typeof(DishSysManager.Data.Menu);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.treeView1);
            this.Name = "FormMenu";
            this.Text = "FormMenu";
            this.Load += new System.EventHandler(this.FormMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.menuBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem 新增分类ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改分类ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 删除分类ToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton5;
        private System.Windows.Forms.ToolStripMenuItem 新增菜品ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改菜品ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 删除菜品ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.BindingSource menuBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mcDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn isTjcDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn isRxcDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label1;
    }
}