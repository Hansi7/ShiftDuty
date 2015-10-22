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
            reloadProfiles();
            reloadShiftList();
        }

        Dictionary<string, int> dicRestType = new Dictionary<string, int>();
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
                dicRestType.Add(dt.Rows[i][2].ToString(), int.Parse(dt.Rows[i][1].ToString()));
            }
            #endregion

            listPeople = manager.GetAllPeople();

        }


        /// <summary>
        /// 重新读取并显示倒休列表
        /// </summary>
        void reloadProfiles()
        {
            var ps = manager.GetAllPeople();
            lv_Profiles.Items.Clear();
            foreach (var item in ps)
            {
                ListViewItem li = new ListViewItem(item.AliasName);
                li.SubItems.Add(item.DaoXiuRemain.ToString());
                li.Tag = item;
                lv_Profiles.Items.Add(li);
            }
            lv_Profiles.Tag = null;
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        #region 界面

        private void lv_Profiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv_Profiles.SelectedItems.Count == 1)
            {
                foreach (ListViewItem item in lv_Profiles.Items)
                {
                    item.BackColor = Color.Transparent;
                }
                lv_Profiles.SelectedItems[0].BackColor = Color.DeepSkyBlue;
                lv_Profiles.Tag = lv_Profiles.SelectedIndices[0];
            }
        }
        private void lv_ShiftList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv_ShiftList.SelectedItems.Count == 1)
            {
                foreach (ListViewItem item in lv_ShiftList.Items)
                {
                    item.BackColor = Color.Transparent;
                }
                lv_ShiftList.SelectedItems[0].BackColor = Color.DeepSkyBlue;
                lv_ShiftList.Tag = lv_ShiftList.SelectedIndices[0];
            }
        }
        #endregion

        /// <summary>
        /// 获取选定的人，没有选定，则为null
        /// </summary>
        /// <returns></returns>
        People _getSelectedPeople()
        {
            if (lv_Profiles.Tag == null)
            {
                return null;
            }
            else
            {
                try
                {
                    var p = (lv_Profiles.Items[int.Parse(lv_Profiles.Tag.ToString())].Tag as People);
                    return p;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
        ShiftItem _getSelectedShiftItem()
        {
            if (lv_ShiftList.Tag == null)
            {
                return null;
            }
            else
            {
                try
                {
                    var p = (lv_ShiftList.Items[int.Parse(lv_ShiftList.Tag.ToString())].Tag as ShiftItem);
                    return p;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
        #region 正式按钮


        #endregion


        private void reloadShiftList()
        {
            var dt = manager.GetShiftHistory(DateTime.Now);
            refillShiftList(dt);
        }

        private void refillShiftList(List<ShiftItem> dt)
        {
            lv_ShiftList.Items.Clear();
            var DayNames = new string[]{"日","一","二","三","四","五","六"};
            foreach (ShiftItem item in dt)
            {
                ListViewItem li = new ListViewItem(item.ShiftDate.ToString("yyyy/MM/dd"));
                int weekday = int.Parse(item.ShiftDate.DayOfWeek.ToString("d"));
                li.SubItems.Add(DayNames[weekday]);
                li.SubItems.Add(FindAliasNameByNID(item.NID));
                li.SubItems.Add(item.RestValue.ToString());
                li.Tag = item;
                lv_ShiftList.Items.Add(li);
            }
            //取消选择
            lv_ShiftList.Tag = null;
        }

        string FindAliasNameByNID(int nid)
        {
            foreach (People item in listPeople)
            {
                if (item.NID==nid)
                {
                    return item.AliasName;
                }
            }
            return string.Empty;
        }
        People FindPeopleByNID(int nid)
        {
            foreach (People item in listPeople)
            {
                if (item.NID==nid)
                {
                    return item;
                }
            }
            return null;
        }

        #region Menus

        
        private void Menu_Names_New_Click(object sender, EventArgs e)
        {
            var frm = new FrmNewProfile();
            bool first = true;
            while (first || MessageBox.Show("添加成功，继续添加?", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (manager.AddNewPeople(frm.People) == 1)
                    {
                        first = false;
                        reloadProfiles();
                        continue;
                    }
                }
                else
                {
                    break;
                }
            }
            listPeople = manager.GetAllPeople();

        }

        private void Menu_Names_Del_Click(object sender, EventArgs e)
        {
            var input = new InputBox();
            if (input.ShowDialog()!= System.Windows.Forms.DialogResult.OK || input.Password != "281")
            {
                return;
            }

            if (_getSelectedPeople()!=null)
            {
                if (MessageBox.Show("确认删除？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                {
                    manager.DelPeople(_getSelectedPeople());
                }
                reloadProfiles();
                reloadShiftList();
            }
            else
            {
                MessageBox.Show("请先选择要删除的人");
            }
            
        }

        private void Menu_Names_truncate_Click(object sender, EventArgs e)
        {

            var input = new InputBox();
            if (input.ShowDialog() != System.Windows.Forms.DialogResult.OK || input.Password != "281")
            {
                return;
            }
            DAL.DAL_SD sd = new DAL.DAL_SD();
            sd.ClearAll(123456);
            reloadProfiles();
            reloadShiftList();
            GC.Collect();
        }

        private void Menu_Shift_Import_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.DefaultExt = "xlsx";
                ofd.Filter = "Excel files (*.xlsx)|*.xlsx";
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    int c = Tools.ExcelInput.ImportOndutyList(ofd.FileName, listPeople);
                    if (c > 0)
                    {
                        MessageBox.Show(string.Format("导入成功！共计导入项目:{0}", c), "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("导入失败或没有可以导入的项目", "失败", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                reloadShiftList();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void Menu_Shift_Download_Click(object sender, EventArgs e)
        {
            try
            {
                var list = new DutyListExport();
                list.Peoples = this.listPeople;
                list.ShowDialog();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void Menu_Shift_add_Click(object sender, EventArgs e)
        {
            if (_getSelectedPeople()==null)
            {
                MessageBox.Show("请先选择一个要操作的人员");
                return;
            }

            var frm = new FrmNewShift(_getSelectedPeople(), listPeople);
            if (frm.ShowDialog()== System.Windows.Forms.DialogResult.OK)
            {
                manager.AddShiftHistory(frm.ShiftItem.ShiftDate, frm.ShiftItem.NID, frm.ShiftItem.RestValue);
            }
            //reloadProfiles();
            reloadShiftList();
        }

        private void Menu_Shift_del_Click(object sender, EventArgs e)
        {
            try
            {
                if (_getSelectedShiftItem() != null)
                {
                    var si = _getSelectedShiftItem();
                    if (manager.DelShiftItem(si) == 0)
                    {

                        if (MessageBox.Show("失败，已经算计倒休了。是否减少倒休数量:" + si.RestValue, "失败", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            manager.ReBackDutyDone(si);
                            manager.DelShiftItem(si);
                        }
                        else
                        {

                        }

                    }
                    reloadProfiles();
                    reloadShiftList();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        #endregion

        private void Menu_Shift_ReCalc_Click(object sender, EventArgs e)
        {
            try
            {
                var list = manager.UnDoneShiftItem();
                foreach (var item in list)
                {
                    manager.DutyDone(item.ShiftDate, item.NID);
                }
                reloadProfiles();
                reloadShiftList();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        #region 命令

        private void _cmdAddRestItem()
        {
            if (_getSelectedPeople() != null)
            {
                var r = new FormAddRest(_getSelectedPeople(), dicRestType, listPeople);
                if (r.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    foreach (RestItem item in r.RestItems)
                    {
                        manager.AddRestHistory(item.RestDate, item.NID, item.RestType,item.RestValue);
                    }
                }
            }
            else
            {
                MessageBox.Show("请先选择休假的人");
            }
        }


        #endregion

        private void Menu_Rest_Add_Click(object sender, EventArgs e)
        {
            _cmdAddRestItem();
        }

        private void Menu_Shift_Swap_Click(object sender, EventArgs e)
        {
            //这个是删除的。还没有改代码呢。
            try
            {
                if (_getSelectedShiftItem() != null)
                {
                    var si = _getSelectedShiftItem();

                    var frm = new FrmNewShift(si, listPeople);
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        if (manager.Is_Calc(si.ShiftDate, si.NID))
                        {
                            if (MessageBox.Show("失败，已经计算倒休了。是否减少倒休数量:" + si.RestValue, "失败", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                            {
                                manager.ReBackDutyDone(si);
                                manager.DelShiftItem(si);
                                manager.AddShiftHistory(frm.ShiftItem.ShiftDate, frm.ShiftItem.NID, frm.ShiftItem.RestValue);
                            }
                        }
                        else
                        {
                            manager.ModifyPeopleShiftItem(si,frm.ShiftItem.NID);
                        }
                    }

                    reloadProfiles();
                    reloadShiftList();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void Menu_Rest_Viewer_Click(object sender, EventArgs e)
        {
            var lf = manager.GetRestView();
            var frm = new FrmRestView();
            
        }

        private void Menu_Rest_ViewerOne_Click(object sender, EventArgs e)
        {

        }


    }
}
