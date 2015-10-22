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
    public partial class FormAddRest : Form
    {
        public FormAddRest(Entities.People p, Dictionary<string,int> dicRest, List<Entities.People> peoples)
        {
            InitializeComponent();
            this.dicRest = dicRest;
            cb_names.Items.AddRange(peoples.ToArray());
            cb_names.DisplayMember = "AliasName";
            for (int i = 0; i < peoples.Count; i++)
            {
                if (peoples[i].Equals(p))
                {
                    cb_names.SelectedItem = peoples[i];
                }
            }


            cb_restType.Items.AddRange(dicRest.Keys.ToArray<string>());
            //默认值
            cb_restType.SelectedItem = "倒休";
        }

        Dictionary<string,int>dicRest;
        public List<Entities.RestItem> RestItems { get; set; }


        private void btn_OK_Click(object sender, EventArgs e)
        {
            RestItems = new List<Entities.RestItem>();
            this.dtp_From.Value = new DateTime(dtp_From.Value.Year, dtp_From.Value.Month, dtp_From.Value.Day);
            this.dtp_To.Value = new DateTime(dtp_To.Value.Year, dtp_To.Value.Month, dtp_To.Value.Day);
            
            
            Entities.People p = cb_names.SelectedItem as Entities.People;
            DateTime fromdate = dtp_From.Value;
            while (dtp_To.Value >= fromdate)
            {
                double restValue = 1;
                if (cb_oneDay.Checked)
                {
                    if (rb_HalfDay.Checked)
                    {
                        restValue = 0.5;
                    }
                }
                if (cb_restType.SelectedItem.ToString()=="加班")
                {
                    restValue = -restValue;
                }
                var ri = new Entities.RestItem() { AliasName = p.AliasName, NID = p.NID, RestDate = fromdate, RestType = dicRest[cb_restType.SelectedItem.ToString()], RestValue = restValue };
                RestItems.Add(ri);
                fromdate = fromdate.AddDays(1);
                Console.WriteLine(ri);
            }
            Console.WriteLine(RestItems);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void dtp_From_ValueChanged(object sender, EventArgs e)
        {
            if (cb_oneDay.Checked)
            {
                dtp_To.Value = dtp_From.Value;
            }
        }
        private void cb_oneDay_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_oneDay.Checked)
            {
                dtp_To.Value = dtp_From.Value;
                dtp_To.Enabled = false;
                rb_HalfDay.Visible = true;
                rb_FullDay.Visible = true;
            }
            else
            {
                dtp_To.Enabled = true;
                rb_HalfDay.Visible = false;
                rb_FullDay.Visible = false;
            }
        }


    }
}
