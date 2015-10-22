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
    public partial class DutyListExport : Form
    {
        public DutyListExport()
        {
            InitializeComponent();
        }

        public List<Entities.People> Peoples { get; set; }

        private void cb_Whole_Click(object sender, EventArgs e)
        {
            if (cb_Whole.Checked)
            {
                dateTimePicker2.Enabled = false;
                DateTime d = dateTimePicker1.Value;
                dateTimePicker1.Value = new DateTime(d.Year, d.Month, 1);
                dateTimePicker2.Value = dateTimePicker1.Value.AddMonths(1);
            }
            else
            {
                dateTimePicker2.Enabled = true;
            }
        }

        private void cb_Whole_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_Whole.Checked)
            {
                dateTimePicker2.Enabled = false;
                DateTime d = dateTimePicker1.Value;
                dateTimePicker1.Value = new DateTime(d.Year, d.Month, 1);
                dateTimePicker2.Value = dateTimePicker1.Value.AddMonths(1);
            }
            else
            {
                dateTimePicker2.Enabled = true;
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            try
            {
                //System.Runtime.InteropServices.Marshal.ReleaseComObject();
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel files (*.xlsx)|*.xlsx";
                sfd.DefaultExt = "xlsx";
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.btn_OK.Text = "正在生成表格...请等待...";

                    if (Tools.ExcelOutput.Gen(dateTimePicker1.Value, dateTimePicker2.Value, sfd.FileName, Peoples) == 1)
                    {
                        this.btn_OK.Text = "生成成功,点击打开";
                        this.btn_OK.Click -= btn_OK_Click;
                        this.btn_OK.Click += new EventHandler(delegate(object ss, EventArgs ee) { System.Diagnostics.Process.Start(sfd.FileName); });
                    }
                    //if (ExcelGen.Gen2(dateTimePicker1.Value, dateTimePicker2.Value, sfd.FileName,ls) == 1)
                    //{
                    //    this.btn_OK.Text = "生成成功,点击关闭";
                    //    this.btn_OK.Click -= btn_OK_Click;
                    //    this.btn_OK.Click += new EventHandler(CloseThis);
                    //}
                    //else
                    //{
                    //    this.btn_OK.Text = "失败！";
                    //    //this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    //}
                    //ExcelGen.Gen();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }



    }
}
