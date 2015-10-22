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
    public partial class InputBox : Form
    {
        public InputBox()
        {
            InitializeComponent();
        }

        public string Password { get; set; }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!=null)
            {
                this.Password = textBox1.Text;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
    }
}
