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
    public partial class FrmNewShift : Form
    {
        public FrmNewShift(Entities.ShiftItem si, List<Entities.People> peoples)
        {
            InitializeComponent();
            cb_names.Items.AddRange(peoples.ToArray());
            cb_names.DisplayMember = "AliasName";
            for (int i = 0; i < peoples.Count; i++)
            {
                if (peoples[i].NID == si.NID)
                {
                    cb_names.SelectedItem = peoples[i];
                }
            }
            dtp_From.Value = si.ShiftDate;
            nud_Value.Value = (decimal)si.RestValue;
        }
        public FrmNewShift(Entities.People p, List<Entities.People> peoples)
        {
            InitializeComponent();
            cb_names.Items.AddRange(peoples.ToArray());
            cb_names.DisplayMember = "AliasName";
            for (int i = 0; i < peoples.Count; i++)
            {
                if (peoples[i].NID == p.NID)
                {
                    cb_names.SelectedItem = peoples[i];
                }
            }
        }

        public Entities.ShiftItem ShiftItem { get; set; }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (ShiftItem ==null)
            {
                ShiftItem = new Entities.ShiftItem();
            }
            Entities.People p = cb_names.SelectedItem as Entities.People;
            this.dtp_From.Value = new DateTime(dtp_From.Value.Year, dtp_From.Value.Month, dtp_From.Value.Day);
            ShiftItem.NID = p.NID;
            ShiftItem.Is_Calc = false;
            ShiftItem.ShiftDate = dtp_From.Value;
            ShiftItem.RestValue = (double)nud_Value.Value;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

    }
}
