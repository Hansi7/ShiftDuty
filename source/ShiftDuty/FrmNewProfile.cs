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
    public partial class FrmNewProfile : Form
    {
        public FrmNewProfile()
        {
            InitializeComponent();
        }

        public Entities.People People { get; set; }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            double r = 0.0;
            if (double.TryParse(txt_RestRemain.Text,out r) && txt_Name.Text.Trim()!="")
            {
                Entities.People p = new Entities.People()
                {
                    AliasName = txt_Name.Text.Trim(),
                    DaoXiuRemain = r
                };
                this.People = p;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
    }
}
