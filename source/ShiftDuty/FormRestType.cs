﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShiftDuty
{
    public partial class FormRestType : Form
    {
        public FormRestType(Dictionary<string,int> dicData)
        {
            InitializeComponent();
            this.dic = dicData;
        }
        Dictionary<string, int> dic;
        public string SelectedItem;
        public List<RadioButton> ListRB = new List<RadioButton>();
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var item in ListRB)
            {
                if (item.Checked)
                {
                    this.SelectedItem = item.Text;
                }
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void FormRestType_Load(object sender, EventArgs e)
        {
            int i = 0;
            foreach (KeyValuePair<string,int> item in dic)
            {
                RadioButton rb = new RadioButton();
                rb.Text = item.Key;
                rb.Location = new Point(10, 20 * (++i));
                ListRB.Add(rb);
                this.Controls.Add(rb);
            }
        }
    }
}
