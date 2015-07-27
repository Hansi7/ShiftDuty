using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ShiftDuty.Entities;


namespace ShiftDuty
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            init();
            loadList();
        }

        Dictionary<int, string> dicRestType = new Dictionary<int, string>();
        List<People> listPeople = new List<People>();
        BLL.ShiftManager manager = new BLL.ShiftManager();
        /// <summary>
        /// 初始化基础数据
        /// </summary>
        private void init()
        {
            #region 此处用dal初始化，别的信息尽量都用bll初始化
            DAL.DAL_SD dal = new DAL.DAL_SD();
            var dt = dal.GetRestType();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dicRestType.Add(int.Parse(dt.Rows[i][1].ToString()), dt.Rows[i][2].ToString());
            } 
            #endregion

            listPeople = manager.GetAllPeople();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dd = manager.GetShiftHistory(DateTime.Now.AddDays(-70));
            Console.WriteLine(dd.Count);
        }
        /// <summary>
        /// 重新读取并显示倒休列表
        /// </summary>
        void loadList()
        {
            var ps = manager.GetAllPeople();
            listView1.Items.Clear();
            foreach (var item in ps)
            {
                ListViewItem li = new ListViewItem(item.AliasName);
                li.SubItems.Add(item.DaoXiuRemain.ToString());
                li.Tag = item;
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

        private void button2_Click(object sender, EventArgs e)
        {
            Console.WriteLine((listView1.Items[int.Parse(listView1.Tag.ToString())].Tag as People).AliasName);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormRestType frm = new FormRestType(dicRestType);
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MessageBox.Show(frm.SelectedItem);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        #region 界面

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count==1)
            {
                foreach (ListViewItem item in listView1.Items)
                {
                    item.BackColor = Color.Transparent;
                }
                listView1.SelectedItems[0].BackColor = Color.DeepSkyBlue;
                listView1.Tag = listView1.SelectedIndices[0];
            }
        }

        #endregion

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                var b = manager.Is_Calc(dateTimePicker1.Value, listView1.Items[int.Parse(listView1.Tag.ToString())].Tag as People);
                MessageBox.Show(b.ToString());
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            manager.AddShiftHistory(dateTimePicker1.Value, _getSelectedPeople(), 1.5);
        }
        People _getSelectedPeople()
        {
            return (listView1.Items[int.Parse(listView1.Tag.ToString())].Tag as People);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            manager.DutyDone(dateTimePicker1.Value, _getSelectedPeople());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var ps = manager.WhosOnDuty(dateTimePicker1.Value);
            foreach (var item in ps)
            {
                MessageBox.Show(item.AliasName);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var f = new FormDataTableView(manager.RestHistoryView());
            f.Show();
        }
    }
}
