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
        public FormReportCP()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string no = textBox1.Text;

            var dataList = SqlUtil.Inst.Details.Where(a=>a.ord_no==no).ToList();

            Assembly assembly = Assembly.GetExecutingAssembly();

            //获取指定的资源

            using (Stream stream = assembly.GetManifestResourceStream("DishSysManager.daily_cp.frx"))
            {
                if (stream != null)  //没有找到，GetManifestResourceStream会返回null
                {
                    var report = new FastReport.Report();
                    report.Load(stream);
                    report.RegisterData(dataList,"mx");
                    report.Preview = this.previewControl1;
                    report.Prepare();
                    report.ShowPrepared();
                }
            }
        }
    }
}
