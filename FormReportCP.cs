using DishSysManager.Data;
using DishSysManager.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace DishSysManager
{
    public partial class FormReportCP : Form
    {
        FastReport.Report report = new FastReport.Report();
        bool autoClose = false;
        public FormReportCP()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }
        public FormReportCP(string ord_no)
        {
            InitializeComponent();
            var order = SqlUtil.Inst.Orders.FirstOrDefault(a=>a.no==ord_no);
            if (order == null) return;
            var dataList = SqlUtil.Inst.Details.Where(a => a.ord_no == order.no).ToList();
            Assembly assembly = Assembly.GetExecutingAssembly();
            List<Order> dataList2 = new List<Order>();
            dataList2.Add(order);
            var hz = dataList2.Select(a => new
            {
                date = a.date.ToString("yyyy-MM-dd HH:mm"),
                zje = a.zje.ToString("0.00"),
                yhje = a.yhje.ToString("0.00"),
                sfje = (a.zje - a.yhje).ToString("0.00"),
                a.desk,
                ord_no = a.no
            }).ToList();
            //获取指定的资源

            using (Stream stream = assembly.GetManifestResourceStream("DishSysManager.daily_cp.frx"))
            {
                if (stream != null)  //没有找到，GetManifestResourceStream会返回null
                {
                    report.Clear();
                    report.Load(stream);
                    report.RegisterData(dataList, "mx");
                    report.RegisterData(hz, "hz");
                    report.Prepare();
                    report.PrintSettings.ShowDialog = false;
                    report.Print();
                }
            }
            autoClose = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {

            DateTime d_rq1 = dateTimePicker1.Value.Date;
            DateTime d_rq2 = dateTimePicker2.Value.AddDays(1).Date;

            var dataList = SqlUtil.Inst.Orders.Where(a=>a.date>=d_rq1&&a.date<d_rq2).ToList();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dataList;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0) return;
            var order = dataGridView1.SelectedRows[0].DataBoundItem as Data.Order;
            if (order == null) return;
            var dataList = SqlUtil.Inst.Details.Where(a => a.ord_no==order.no).ToList();
            Assembly assembly = Assembly.GetExecutingAssembly();
            List<Order> dataList2 = new List<Order>();
            dataList2.Add(order);
            var hz = dataList2.Select(a => new
            {
                date = a.date.ToString("yyyy-MM-dd HH:mm"),
                zje = a.zje.ToString("0.00"),
                yhje = a.yhje.ToString("0.00"),
                sfje = (a.zje - a.yhje).ToString("0.00"),
                a.desk,ord_no=a.no
            }).ToList();
            //获取指定的资源

            using (Stream stream = assembly.GetManifestResourceStream("DishSysManager.daily_cp.frx"))
            {
                if (stream != null)  //没有找到，GetManifestResourceStream会返回null
                {
                    report.Clear();
                    //this.previewControl1.Clear();
                    report.Load(stream);
                    report.RegisterData(dataList, "mx");
                    report.RegisterData(hz, "hz");
                    report.Preview = this.previewControl1;
                    report.Prepare();
                    report.ShowPrepared();
                    previewControl1.ZoomPageWidth();
                }
            }

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView1_CellContentClick(null, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            previewControl1.Print();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormReportCP_Load(object sender, EventArgs e)
        {
            if (autoClose)
            {
                this.Close();
            }
        }
    }
}
