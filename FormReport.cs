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
    public partial class FormReport : Form
    {
        FastReport.Report report = new FastReport.Report();
        public FormReport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime d_rq1 = dateTimePicker1.Value.Date;
            DateTime d_rq2 = dateTimePicker2.Value.AddDays(1).Date;

            var dataList = SqlUtil.Inst.Orders.Where(a => a.date >= d_rq1 && a.date < d_rq2).ToList().Select(a=>new { 
                date = a.date.ToString("yyyy年MM月dd日"),
                zje =a.zje,
                yhje=a.yhje
            }).GroupBy(a => a.date).Select(g => new
            {
                rq = g.Key,
                zje = g.Sum(t => t.zje).ToString("0.00"),
                yhje = g.Sum(t => t.yhje).ToString("0.00"),
                ssje = (g.Sum(t => t.zje) - g.Sum(t => t.yhje)).ToString("0.00")
            }).ToList();

            Assembly assembly = Assembly.GetExecutingAssembly();

            //获取指定的资源

            using (Stream stream = assembly.GetManifestResourceStream("DishSysManager.daily_sum.frx"))
            {
                if (stream != null)  //没有找到，GetManifestResourceStream会返回null
                {
                    report.Clear();
                    report.Load(stream);
                    report.RegisterData(dataList,"hz");
                    report.Preview = this.previewControl1;
                    report.Prepare();
                    report.ShowPrepared();
                }
            }
        }
    }
}
