namespace ShiftDuty
{
    partial class FrmNewShift
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
            this.btn_OK = new System.Windows.Forms.Button();
            this.nud_Value = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Value)).BeginInit();
            this.SuspendLayout();
            // 
            // cb_names
            // 
            this.cb_names.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_names.FormattingEnabled = true;
            this.cb_names.Location = new System.Drawing.Point(12, 12);
            this.cb_names.Name = "cb_names";
            this.cb_names.Size = new System.Drawing.Size(99, 20);
            this.cb_names.TabIndex = 1;
            // 
            // dtp_From
            // 
            this.dtp_From.CustomFormat = "yyyy-MM-dd";
            this.dtp_From.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_From.Location = new System.Drawing.Point(117, 12);
            this.dtp_From.MinDate = new System.DateTime(2009, 7, 28, 0, 0, 0, 0);
            this.dtp_From.Name = "dtp_From";
            this.dtp_From.Size = new System.Drawing.Size(99, 21);
            this.dtp_From.TabIndex = 3;
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(194, 61);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 10;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // nud_Value
            // 
            this.nud_Value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nud_Value.DecimalPlaces = 1;
            this.nud_Value.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nud_Value.Location = new System.Drawing.Point(221, 13);
            this.nud_Value.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            65536});
            this.nud_Value.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nud_Value.Name = "nud_Value";
            this.nud_Value.Size = new System.Drawing.Size(45, 21);
            this.nud_Value.TabIndex = 12;
            this.nud_Value.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // FrmNewShift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 96);
            this.Controls.Add(this.nud_Value);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.dtp_From);
            this.Controls.Add(this.cb_names);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmNewShift";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "增加值班表项";
            ((System.ComponentModel.ISupportInitialize)(this.nud_Value)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_names;
        private System.Windows.Forms.DateTimePicker dtp_From;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.NumericUpDown nud_Value;

    }
}