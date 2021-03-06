﻿using DishSysManager.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DishSysManager
{
    /// <summary>
    /// BaseMainFrame.xaml 的交互逻辑
    /// </summary>
    public partial class BaseMainFrame : System.Windows.Controls.UserControl
    {
        FrameDataContext FrameContext;
        Dictionary<string, Form> ChildForm = new Dictionary<string, Form>();
        public BaseMainFrame()
        {
            InitializeComponent();
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
            FrameContext = new FrameDataContext();
            this.DataContext = FrameContext;
            FrameContext.ProductName = "点餐管理系统  Jaylosy版权所有";
            timer.Enabled = true;

            ShowWelcome();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            FrameContext.CurrentTime = DateTime.Now.ToString("yyyy年MM月dd日HH时mm分");
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {

            ClearMenuChecked();
            (sender as ToggleButton).IsChecked = true;
            string btnName = (sender as ToggleButton).Content.ToString();
            switch (btnName)
            {
                case "点餐":
                    ShowChild(btnName, new FormDish());
                    break;
                case "查询统计":
                    var contextMenu = reportMenu;
                    contextMenu.PlacementTarget = (sender as ToggleButton);
                    contextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
                    contextMenu.IsOpen = true;
                    break;
                case "菜品维护":
                    ShowChild(btnName, new FormMenu());
                    break;


            }
        }
        void ClearMenuChecked()
        {
            foreach (UIElement ele in navMenu.Children)
            {
                if (ele is ToggleButton)
                {
                    (ele as ToggleButton).IsChecked = false;
                }
            }
        }
        void ShowChild(string menu,Form form)
        {
            Form cachedForm;
            bool ret = ChildForm.TryGetValue(menu, out cachedForm);
            if (!ret)
            {
                cachedForm = form;
                ChildForm.Add(menu, cachedForm);
                cachedForm.FormClosed += CachedForm_FormClosed;
            }
            else
            {
                if (cachedForm.IsDisposed)
                {
                    ChildForm.Remove(menu);
                    cachedForm = form;
                    ChildForm.Add(menu, cachedForm);
                    cachedForm.FormClosed += CachedForm_FormClosed;
                }
            }

            cachedForm.Dock = DockStyle.Fill;
            cachedForm.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            cachedForm.AutoScaleMode = AutoScaleMode.Dpi;
            cachedForm.FormBorderStyle = FormBorderStyle.None;
            cachedForm.TopLevel = false;
            mainWindowHost.Child = cachedForm;
        }

        private void CachedForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClearMenuChecked();
            ShowWelcome();
        }

        void ShowWelcome()
        {
            ShowChild("欢迎", new FormWelcome());
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var menu = sender as System.Windows.Controls.MenuItem;
            string title = menu.Header.ToString();
            switch (title)
            {
                case "每日汇总统计":
                    ShowChild(title, new FormReport());
                    break;
                case "每日明细统计":
                    ShowChild(title, new FormReportMX());
                    break;
                case "点餐明细查询":
                    ShowChild(title, new FormReportCP());
                    break;
            }
        }

        private void ToggleButton_Initialized(object sender, EventArgs e)
        {
            (sender as ToggleButton).ContextMenu = null;
        }
    }
}
