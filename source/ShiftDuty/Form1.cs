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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            loadList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DAL.DAL_SD sd = new DAL.DAL_SD();
            var dt = sd.GetShiftHistory(DateTime.Now.AddDays(-1), DateTime.Now,"张三丰");
            var str = printDataTable(dt);
            if (str!=string.Empty)
            {
                MessageBox.Show(str);
            }
            else
            {
                MessageBox.Show("Nothing");
            }
        }
        /// <summary>
        /// 实体要不要，决定一下啊。要的话，这段就没有了。
        /// </summary>
        void loadList()
        {
            var dt = DAL.DBHelper.ExecuteDataTable(new System.Data.OleDb.OleDbCommand("select * from pNames"));

            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem li = new ListViewItem(dr[1].ToString());
                li.SubItems.Add(dr[2].ToString());
                listView1.Items.Add(li);
            }
        }


        string printDataTable(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataRow dr in dt.Rows)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    sb.Append(dr[i].ToString() + "\t");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

    }
}
