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
    public partial class FormDataTableView : Form
    {
        public FormDataTableView(DataTable dt)
        {
            InitializeComponent();
            this.dt = dt;
        }
        DataTable dt;
        private void FormDataTableView_Load(object sender, EventArgs e)
        {
            foreach (DataColumn item in dt.Columns)
            {
                lv.Columns.Add(getHeader(item.ColumnName));
            }
            foreach (DataRow item in dt.Rows)
            {
                lv.Items.Add(getItem(item));
            }
        }

        ColumnHeader getHeader(string text)
        {
            var h = new ColumnHeader();
            h.Text = text;
            return h;
        }
        ListViewItem getItem(DataRow r)
        {
            var i = new ListViewItem(r[0].ToString());
            for (int j = 1; j < dt.Columns.Count; j++)
            {
                if (r[j] is DateTime) 
                {
                    i.SubItems.Add(((DateTime)r[j]).ToString("yyyy-MM-dd"));
                }
                else
                {
                    i.SubItems.Add(r[j].ToString());
                }
            }
            return i;
        }
    }
}
