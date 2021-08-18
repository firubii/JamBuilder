namespace JamBuilder
{
    partial class YAMLEditor
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
            this.yamlDataList = new System.Windows.Forms.ListBox();
            this.save = new System.Windows.Forms.Button();
            this.valueString = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.valueEnum = new System.Windows.Forms.ComboBox();
            this.valueBool = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.valueNum = new System.Windows.Forms.NumericUpDown();
            this.valueOffset = new System.Windows.Forms.NumericUpDown();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valueNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueOffset)).BeginInit();
            this.SuspendLayout();
            // 
            // yamlDataList
            // 
            this.yamlDataList.FormattingEnabled = true;
            this.yamlDataList.Location = new System.Drawing.Point(13, 13);
            this.yamlDataList.Name = "yamlDataList";
            this.yamlDataList.Size = new System.Drawing.Size(197, 277);
            this.yamlDataList.TabIndex = 0;
            this.yamlDataList.SelectedIndexChanged += new System.EventHandler(this.yamlDataList_SelectedIndexChanged);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(178, 302);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 1;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // valueString
            // 
            this.valueString.Location = new System.Drawing.Point(3, 29);
            this.valueString.Name = "valueString";
            this.valueString.Size = new System.Drawing.Size(200, 20);
            this.valueString.TabIndex = 2;
            this.valueString.TextChanged += new System.EventHandler(this.valueString_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(214, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Value";
            // 
            // valueEnum
            // 
            this.valueEnum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.valueEnum.Enabled = false;
            this.valueEnum.FormattingEnabled = true;
            this.valueEnum.Location = new System.Drawing.Point(3, 55);
            this.valueEnum.Name = "valueEnum";
            this.valueEnum.Size = new System.Drawing.Size(200, 21);
            this.valueEnum.TabIndex = 6;
            this.valueEnum.SelectedIndexChanged += new System.EventHandler(this.valueSelect_SelectedIndexChanged);
            // 
            // valueBool
            // 
            this.valueBool.AutoSize = true;
            this.valueBool.Location = new System.Drawing.Point(3, 82);
            this.valueBool.Name = "valueBool";
            this.valueBool.Size = new System.Drawing.Size(53, 17);
            this.valueBool.TabIndex = 7;
            this.valueBool.Text = "Value";
            this.valueBool.UseVisualStyleBackColor = true;
            this.valueBool.CheckedChanged += new System.EventHandler(this.boolSelect_CheckedChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.valueNum);
            this.flowLayoutPanel1.Controls.Add(this.valueOffset);
            this.flowLayoutPanel1.Controls.Add(this.valueString);
            this.flowLayoutPanel1.Controls.Add(this.valueEnum);
            this.flowLayoutPanel1.Controls.Add(this.valueBool);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(216, 28);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(211, 150);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // valueNum
            // 
            this.valueNum.Location = new System.Drawing.Point(3, 3);
            this.valueNum.Name = "valueNum";
            this.valueNum.Size = new System.Drawing.Size(150, 20);
            this.valueNum.TabIndex = 8;
            this.valueNum.ValueChanged += new System.EventHandler(this.valueNum_ValueChanged);
            // 
            // valueOffset
            // 
            this.valueOffset.Location = new System.Drawing.Point(159, 3);
            this.valueOffset.Name = "valueOffset";
            this.valueOffset.Size = new System.Drawing.Size(44, 20);
            this.valueOffset.TabIndex = 9;
            this.valueOffset.ValueChanged += new System.EventHandler(this.valueNum_ValueChanged);
            // 
            // YAMLEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 338);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.save);
            this.Controls.Add(this.yamlDataList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "YAMLEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "YAMLEditor";
            this.Load += new System.EventHandler(this.YAMLEditor_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valueNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueOffset)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox yamlDataList;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.TextBox valueString;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox valueEnum;
        private System.Windows.Forms.CheckBox valueBool;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.NumericUpDown valueNum;
        private System.Windows.Forms.NumericUpDown valueOffset;
    }
}