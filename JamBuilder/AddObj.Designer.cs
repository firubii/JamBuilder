namespace JamBuilder
{
    partial class AddObj
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
            this.objectDropDown = new System.Windows.Forms.ComboBox();
            this.save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // objectDropDown
            // 
            this.objectDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.objectDropDown.FormattingEnabled = true;
            this.objectDropDown.Location = new System.Drawing.Point(12, 12);
            this.objectDropDown.Name = "objectDropDown";
            this.objectDropDown.Size = new System.Drawing.Size(256, 21);
            this.objectDropDown.TabIndex = 0;
            this.objectDropDown.SelectedIndexChanged += new System.EventHandler(this.objectDropDown_SelectedIndexChanged);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(97, 44);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 1;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // AddObj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 75);
            this.Controls.Add(this.save);
            this.Controls.Add(this.objectDropDown);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddObj";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Object";
            this.Load += new System.EventHandler(this.AddObj_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox objectDropDown;
        private System.Windows.Forms.Button save;
    }
}