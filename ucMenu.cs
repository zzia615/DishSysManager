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
    public partial class ucMenu : UserControl
    {
        private readonly MenuInfo menuInfo;
        public EventHandler<MenuInfo> SelectedMenu;
        public ucMenu(MenuInfo info)
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
            this.menuInfo = info;
            pbMenu.ImageLocation = info.img_url;
            lbName.Text = info.title;
            lbPrice.Text = "价格："+info.price.ToString("0.00");
            label1.Visible = info.isTjc;
            label2.Visible = info.isRxc;
        }

        public MenuInfo GetMenuInfo()
        {
            return menuInfo;
        }

        private void ucMenu_Load(object sender, EventArgs e)
        {
            this.Click += Control_Click;
            SetClickEvent(this.Controls);
        }

        void SetClickEvent(ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                control.Click += Control_Click;
                SetClickEvent(control.Controls);
            }
        }

        private void Control_Click(object sender, EventArgs e)
        {
            if (SelectedMenu != null)
            {
                SelectedMenu(sender,menuInfo);
            }
        }
    }
}
