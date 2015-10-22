namespace ShiftDuty
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lv_Profiles = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Menu_Shift = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Shift_Import = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Shift_Download = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Menu_Shift_add = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Shift_del = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Shift_Swap = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.Menu_Shift_ReCalc = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Rest = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Rest_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Rest_Viewer = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Rest_ViewerOne = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_init = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Names_New = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.Menu_Names_Del = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Names_truncate = new System.Windows.Forms.ToolStripMenuItem();
            this.lv_ShiftList = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lv_Profiles
            // 
            this.lv_Profiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lv_Profiles.FullRowSelect = true;
            this.lv_Profiles.Location = new System.Drawing.Point(292, 28);
            this.lv_Profiles.Name = "lv_Profiles";
            this.lv_Profiles.Size = new System.Drawing.Size(177, 394);
            this.lv_Profiles.TabIndex = 2;
            this.lv_Profiles.UseCompatibleStateImageBehavior = false;
            this.lv_Profiles.View = System.Windows.Forms.View.Details;
            this.lv_Profiles.SelectedIndexChanged += new System.EventHandler(this.lv_Profiles_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "姓名";
            this.columnHeader1.Width = 70;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "可用倒休";
            this.columnHeader2.Width = 70;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Shift,
            this.Menu_Rest,
            this.Menu_init});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(588, 25);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Menu_Shift
            // 
            this.Menu_Shift.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Shift_Import,
            this.Menu_Shift_Download,
            this.toolStripSeparator1,
            this.Menu_Shift_add,
            this.Menu_Shift_del,
            this.Menu_Shift_Swap,
            this.toolStripSeparator2,
            this.Menu_Shift_ReCalc});
            this.Menu_Shift.Name = "Menu_Shift";
            this.Menu_Shift.Size = new System.Drawing.Size(80, 21);
            this.Menu_Shift.Text = "排班表管理";
            // 
            // Menu_Shift_Import
            // 
            this.Menu_Shift_Import.Name = "Menu_Shift_Import";
            this.Menu_Shift_Import.Size = new System.Drawing.Size(160, 22);
            this.Menu_Shift_Import.Text = "导入排班表";
            this.Menu_Shift_Import.Click += new System.EventHandler(this.Menu_Shift_Import_Click);
            // 
            // Menu_Shift_Download
            // 
            this.Menu_Shift_Download.Name = "Menu_Shift_Download";
            this.Menu_Shift_Download.Size = new System.Drawing.Size(160, 22);
            this.Menu_Shift_Download.Text = "下载排版表模板";
            this.Menu_Shift_Download.Click += new System.EventHandler(this.Menu_Shift_Download_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
            // 
            // Menu_Shift_add
            // 
            this.Menu_Shift_add.Name = "Menu_Shift_add";
            this.Menu_Shift_add.Size = new System.Drawing.Size(160, 22);
            this.Menu_Shift_add.Text = "添加排班";
            this.Menu_Shift_add.Click += new System.EventHandler(this.Menu_Shift_add_Click);
            // 
            // Menu_Shift_del
            // 
            this.Menu_Shift_del.Name = "Menu_Shift_del";
            this.Menu_Shift_del.Size = new System.Drawing.Size(160, 22);
            this.Menu_Shift_del.Text = "删除排班";
            this.Menu_Shift_del.Click += new System.EventHandler(this.Menu_Shift_del_Click);
            // 
            // Menu_Shift_Swap
            // 
            this.Menu_Shift_Swap.Name = "Menu_Shift_Swap";
            this.Menu_Shift_Swap.Size = new System.Drawing.Size(160, 22);
            this.Menu_Shift_Swap.Text = "改换班";
            this.Menu_Shift_Swap.Click += new System.EventHandler(this.Menu_Shift_Swap_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(157, 6);
            // 
            // Menu_Shift_ReCalc
            // 
            this.Menu_Shift_ReCalc.Name = "Menu_Shift_ReCalc";
            this.Menu_Shift_ReCalc.Size = new System.Drawing.Size(160, 22);
            this.Menu_Shift_ReCalc.Text = "重新计算";
            this.Menu_Shift_ReCalc.Click += new System.EventHandler(this.Menu_Shift_ReCalc_Click);
            // 
            // Menu_Rest
            // 
            this.Menu_Rest.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Rest_Add,
            this.Menu_Rest_Viewer,
            this.Menu_Rest_ViewerOne});
            this.Menu_Rest.Name = "Menu_Rest";
            this.Menu_Rest.Size = new System.Drawing.Size(68, 21);
            this.Menu_Rest.Text = "休假管理";
            // 
            // Menu_Rest_Add
            // 
            this.Menu_Rest_Add.Name = "Menu_Rest_Add";
            this.Menu_Rest_Add.Size = new System.Drawing.Size(160, 22);
            this.Menu_Rest_Add.Text = "录入休假";
            this.Menu_Rest_Add.Click += new System.EventHandler(this.Menu_Rest_Add_Click);
            // 
            // Menu_Rest_Viewer
            // 
            this.Menu_Rest_Viewer.Name = "Menu_Rest_Viewer";
            this.Menu_Rest_Viewer.Size = new System.Drawing.Size(160, 22);
            this.Menu_Rest_Viewer.Text = "查看所有人休假";
            this.Menu_Rest_Viewer.Click += new System.EventHandler(this.Menu_Rest_Viewer_Click);
            // 
            // Menu_Rest_ViewerOne
            // 
            this.Menu_Rest_ViewerOne.Name = "Menu_Rest_ViewerOne";
            this.Menu_Rest_ViewerOne.Size = new System.Drawing.Size(160, 22);
            this.Menu_Rest_ViewerOne.Text = "查看当前人休假";
            this.Menu_Rest_ViewerOne.Click += new System.EventHandler(this.Menu_Rest_ViewerOne_Click);
            // 
            // Menu_init
            // 
            this.Menu_init.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Names_New,
            this.toolStripSeparator,
            this.Menu_Names_Del,
            this.Menu_Names_truncate});
            this.Menu_init.Name = "Menu_init";
            this.Menu_init.Size = new System.Drawing.Size(94, 21);
            this.Menu_init.Text = "初始化管理(&F)";
            // 
            // Menu_Names_New
            // 
            this.Menu_Names_New.Image = ((System.Drawing.Image)(resources.GetObject("Menu_Names_New.Image")));
            this.Menu_Names_New.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Menu_Names_New.Name = "Menu_Names_New";
            this.Menu_Names_New.Size = new System.Drawing.Size(142, 22);
            this.Menu_Names_New.Text = "新建人员(&N)";
            this.Menu_Names_New.Click += new System.EventHandler(this.Menu_Names_New_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(139, 6);
            // 
            // Menu_Names_Del
            // 
            this.Menu_Names_Del.Name = "Menu_Names_Del";
            this.Menu_Names_Del.Size = new System.Drawing.Size(142, 22);
            this.Menu_Names_Del.Text = "删除人员(&D)";
            this.Menu_Names_Del.Click += new System.EventHandler(this.Menu_Names_Del_Click);
            // 
            // Menu_Names_truncate
            // 
            this.Menu_Names_truncate.Name = "Menu_Names_truncate";
            this.Menu_Names_truncate.Size = new System.Drawing.Size(142, 22);
            this.Menu_Names_truncate.Text = "清空数据库";
            this.Menu_Names_truncate.Click += new System.EventHandler(this.Menu_Names_truncate_Click);
            // 
            // lv_ShiftList
            // 
            this.lv_ShiftList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader5,
            this.columnHeader4,
            this.columnHeader6});
            this.lv_ShiftList.FullRowSelect = true;
            this.lv_ShiftList.Location = new System.Drawing.Point(12, 28);
            this.lv_ShiftList.Name = "lv_ShiftList";
            this.lv_ShiftList.Size = new System.Drawing.Size(274, 394);
            this.lv_ShiftList.TabIndex = 11;
            this.lv_ShiftList.UseCompatibleStateImageBehavior = false;
            this.lv_ShiftList.View = System.Windows.Forms.View.Details;
            this.lv_ShiftList.SelectedIndexChanged += new System.EventHandler(this.lv_ShiftList_SelectedIndexChanged);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "日期";
            this.columnHeader3.Width = 77;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "星期";
            this.columnHeader5.Width = 45;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "值班员";
            this.columnHeader4.Width = 64;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "值";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 434);
            this.Controls.Add(this.lv_ShiftList);
            this.Controls.Add(this.lv_Profiles);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "考勤管理";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lv_Profiles;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Menu_init;
        private System.Windows.Forms.ToolStripMenuItem Menu_Names_New;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ListView lv_ShiftList;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ToolStripMenuItem Menu_Names_Del;
        private System.Windows.Forms.ToolStripMenuItem Menu_Names_truncate;
        private System.Windows.Forms.ToolStripMenuItem Menu_Shift;
        private System.Windows.Forms.ToolStripMenuItem Menu_Shift_Import;
        private System.Windows.Forms.ToolStripMenuItem Menu_Shift_Download;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem Menu_Shift_add;
        private System.Windows.Forms.ToolStripMenuItem Menu_Shift_del;
        private System.Windows.Forms.ToolStripMenuItem Menu_Shift_Swap;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem Menu_Shift_ReCalc;
        private System.Windows.Forms.ToolStripMenuItem Menu_Rest;
        private System.Windows.Forms.ToolStripMenuItem Menu_Rest_Add;
        private System.Windows.Forms.ToolStripMenuItem Menu_Rest_Viewer;
        private System.Windows.Forms.ToolStripMenuItem Menu_Rest_ViewerOne;

    }
}

