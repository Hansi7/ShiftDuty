namespace ShiftDuty
{
    partial class FormAddRest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cb_names = new System.Windows.Forms.ComboBox();
            this.dtp_From = new System.Windows.Forms.DateTimePicker();
            this.dtp_To = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_oneDay = new System.Windows.Forms.CheckBox();
            this.btn_OK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb_FullDay = new System.Windows.Forms.RadioButton();
            this.rb_HalfDay = new System.Windows.Forms.RadioButton();
            this.cb_restType = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_names
            // 
            this.cb_names.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_names.FormattingEnabled = true;
            this.cb_names.Location = new System.Drawing.Point(14, 19);
            this.cb_names.Name = "cb_names";
            this.cb_names.Size = new System.Drawing.Size(99, 20);
            this.cb_names.TabIndex = 0;
            // 
            // dtp_From
            // 
            this.dtp_From.CustomFormat = "yyyy-MM-dd";
            this.dtp_From.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_From.Location = new System.Drawing.Point(40, 20);
            this.dtp_From.MinDate = new System.DateTime(2009, 7, 28, 0, 0, 0, 0);
            this.dtp_From.Name = "dtp_From";
            this.dtp_From.Size = new System.Drawing.Size(99, 21);
            this.dtp_From.TabIndex = 2;
            this.dtp_From.ValueChanged += new System.EventHandler(this.dtp_From_ValueChanged);
            // 
            // dtp_To
            // 
            this.dtp_To.CustomFormat = "yyyy-MM-dd";
            this.dtp_To.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_To.Location = new System.Drawing.Point(168, 20);
            this.dtp_To.MinDate = new System.DateTime(2009, 7, 28, 0, 0, 0, 0);
            this.dtp_To.Name = "dtp_To";
            this.dtp_To.Size = new System.Drawing.Size(99, 21);
            this.dtp_To.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "从";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(145, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "至";
            // 
            // cb_oneDay
            // 
            this.cb_oneDay.AutoSize = true;
            this.cb_oneDay.Location = new System.Drawing.Point(40, 47);
            this.cb_oneDay.Name = "cb_oneDay";
            this.cb_oneDay.Size = new System.Drawing.Size(72, 16);
            this.cb_oneDay.TabIndex = 6;
            this.cb_oneDay.Text = "唯一日期";
            this.cb_oneDay.UseVisualStyleBackColor = true;
            this.cb_oneDay.CheckedChanged += new System.EventHandler(this.cb_oneDay_CheckedChanged);
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(218, 144);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 9;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(171, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "休";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb_FullDay);
            this.groupBox1.Controls.Add(this.rb_HalfDay);
            this.groupBox1.Controls.Add(this.dtp_From);
            this.groupBox1.Controls.Add(this.dtp_To);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cb_oneDay);
            this.groupBox1.Location = new System.Drawing.Point(14, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(279, 77);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "日期选择";
            // 
            // rb_FullDay
            // 
            this.rb_FullDay.AutoSize = true;
            this.rb_FullDay.Location = new System.Drawing.Point(220, 47);
            this.rb_FullDay.Name = "rb_FullDay";
            this.rb_FullDay.Size = new System.Drawing.Size(47, 16);
            this.rb_FullDay.TabIndex = 8;
            this.rb_FullDay.TabStop = true;
            this.rb_FullDay.Text = "全天";
            this.rb_FullDay.UseVisualStyleBackColor = true;
            // 
            // rb_HalfDay
            // 
            this.rb_HalfDay.AutoSize = true;
            this.rb_HalfDay.Location = new System.Drawing.Point(167, 47);
            this.rb_HalfDay.Name = "rb_HalfDay";
            this.rb_HalfDay.Size = new System.Drawing.Size(47, 16);
            this.rb_HalfDay.TabIndex = 7;
            this.rb_HalfDay.TabStop = true;
            this.rb_HalfDay.Text = "半天";
            this.rb_HalfDay.UseVisualStyleBackColor = true;
            // 
            // cb_restType
            // 
            this.cb_restType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_restType.FormattingEnabled = true;
            this.cb_restType.Location = new System.Drawing.Point(194, 19);
            this.cb_restType.Name = "cb_restType";
            this.cb_restType.Size = new System.Drawing.Size(99, 20);
            this.cb_restType.TabIndex = 13;
            // 
            // FormAddRest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 184);
            this.Controls.Add(this.cb_restType);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.cb_names);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddRest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "增加休息记录";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_names;
        private System.Windows.Forms.DateTimePicker dtp_From;
        private System.Windows.Forms.DateTimePicker dtp_To;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cb_oneDay;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cb_restType;
        private System.Windows.Forms.RadioButton rb_FullDay;
        private System.Windows.Forms.RadioButton rb_HalfDay;
    }
}