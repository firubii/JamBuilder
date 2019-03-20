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
            this.value = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.valueSelect = new System.Windows.Forms.ComboBox();
            this.boolSelect = new System.Windows.Forms.CheckBox();
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
            // value
            // 
            this.value.Location = new System.Drawing.Point(216, 28);
            this.value.Name = "value";
            this.value.Size = new System.Drawing.Size(201, 20);
            this.value.TabIndex = 2;
            this.value.TextChanged += new System.EventHandler(this.value_TextChanged);
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
            // valueSelect
            // 
            this.valueSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.valueSelect.Enabled = false;
            this.valueSelect.FormattingEnabled = true;
            this.valueSelect.Location = new System.Drawing.Point(216, 55);
            this.valueSelect.Name = "valueSelect";
            this.valueSelect.Size = new System.Drawing.Size(201, 21);
            this.valueSelect.TabIndex = 6;
            this.valueSelect.SelectedIndexChanged += new System.EventHandler(this.valueSelect_SelectedIndexChanged);
            // 
            // boolSelect
            // 
            this.boolSelect.AutoSize = true;
            this.boolSelect.Location = new System.Drawing.Point(216, 83);
            this.boolSelect.Name = "boolSelect";
            this.boolSelect.Size = new System.Drawing.Size(53, 17);
            this.boolSelect.TabIndex = 7;
            this.boolSelect.Text = "Value";
            this.boolSelect.UseVisualStyleBackColor = true;
            this.boolSelect.CheckedChanged += new System.EventHandler(this.boolSelect_CheckedChanged);
            // 
            // YAMLEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 338);
            this.Controls.Add(this.boolSelect);
            this.Controls.Add(this.valueSelect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.value);
            this.Controls.Add(this.save);
            this.Controls.Add(this.yamlDataList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "YAMLEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "YAMLEditor";
            this.Load += new System.EventHandler(this.YAMLEditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox yamlDataList;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.TextBox value;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox valueSelect;
        private System.Windows.Forms.CheckBox boolSelect;
    }
}