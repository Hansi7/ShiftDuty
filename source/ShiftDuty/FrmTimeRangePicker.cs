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
    public partial class FrmTimeRangePicker : Form
    {
        public FrmTimeRangePicker()
        {
            InitializeComponent();
        }
        private DateTime _start;

        public DateTime START_TIME
        {
            get { return _start; }
            set { _start = value; }
        }

        private DateTime _end;

        public DateTime END_TIME
        {
            get { return _end; }
            set { _end = value; }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (this.dateTimePicker2.Value > this.dateTimePicker1.Value)
            {
                this.START_TIME = this.dateTimePicker1.Value;
                this.END_TIME = this.dateTimePicker2.Value;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                MessageBox.Show("结束时间不能小于开始时间!","错误", MessageBoxButtons.OK , MessageBoxIcon.Error);
            }
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                this.dateTimePicker1.ValueChanged += new EventHandler(dateTimePicker1_ValueChanged);
                this.dateTimePicker2.Enabled = false;
                dateTimePicker1_ValueChanged(null, null);
            }
            else
            {
                this.dateTimePicker1.ValueChanged -= dateTimePicker1_ValueChanged;
                this.dateTimePicker2.Enabled = true;
            }
        }

        void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.Value = dateTimePicker1.Value.AddDays(1);
        }

        private void FrmTimeRangePicker_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now.AddDays(-1);
            dateTimePicker2.Value = DateTime.Now;
        }
    }
}
