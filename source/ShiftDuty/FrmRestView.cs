using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShiftDuty
{
    public partial class FrmRestView : Form
    {
        public FrmRestView()
        {
            InitializeComponent();
        }

        public List<Entities.RestItem> List { get; set; }

        private void FrmRestView_Load(object sender, EventArgs e)
        {
            if (List!=null)
            {
                foreach (var item in List)
                {
                    ListViewItem li = new ListViewItem(item.AliasName);
                    li.SubItems.Add(item.RestDate.ToString("yyyy-MM-dd"));
                    li.SubItems.Add(item.RestText);
                    li.SubItems.Add(item.RestValue.ToString("0.0"));
                    li.Tag = item.ID;
                    this.listView1.Items.Add(li);
                }
            }
        }

        private void cMenu_toExcel_Click(object sender, EventArgs e)
        {
            var fn = DateTime.Now.ToString("yyyyMMdd")+"导出倒休记录"+".xlsx";
            Tools.ExcelOutput.ListViewToExcel_RestHistory(this.listView1, fn, "倒休记录");
            System.Diagnostics.Process.Start(fn);
        }
    }
}
