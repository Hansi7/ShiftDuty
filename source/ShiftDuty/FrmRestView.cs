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
    public partial class FrmRestView : Form
    {
        public FrmRestView()
        {
            InitializeComponent();
        }

        public List<Entities.RestItem> List { get; set; }
        public List<Entities.People> Peoples { get; set; }

        private void FrmRestView_Load(object sender, EventArgs e)
        {
            if (List!=null)
            {
                foreach (var item in List)
                {
                    ListViewItem li = new ListViewItem(GetPeople(item.NID).AliasName);
                    li.SubItems.Add(item.RestValue)



                }
            }
        }
        private Entities.People GetPeople(int nid)
        {
            foreach (var item in Peoples)
            {
                if (item.NID == nid)
                {
                    return item;
                }
            }
            return null;
        }






    }
}
