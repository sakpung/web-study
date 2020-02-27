namespace Leadtools.Ccow.Dialogs
{
    partial class ApplicationListDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.listViewApplications = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.comboBoxSecurityType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Application:";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(302, 232);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button2.Location = new System.Drawing.Point(221, 232);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "OK";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // listViewApplications
            // 
            this.listViewApplications.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewApplications.FullRowSelect = true;
            this.listViewApplications.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewApplications.HideSelection = false;
            this.listViewApplications.Location = new System.Drawing.Point(12, 29);
            this.listViewApplications.Name = "listViewApplications";
            this.listViewApplications.Size = new System.Drawing.Size(365, 196);
            this.listViewApplications.TabIndex = 4;
            this.listViewApplications.UseCompatibleStateImageBehavior = false;
            this.listViewApplications.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            // 
            // comboBoxSecurityType
            // 
            this.comboBoxSecurityType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSecurityType.FormattingEnabled = true;
            this.comboBoxSecurityType.Items.AddRange(new object[] {
            "None",
            "Get",
            "Geta",
            "Set",
            "Seta"});
            this.comboBoxSecurityType.Location = new System.Drawing.Point(93, 234);
            this.comboBoxSecurityType.Name = "comboBoxSecurityType";
            this.comboBoxSecurityType.Size = new System.Drawing.Size(69, 21);
            this.comboBoxSecurityType.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 242);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Security Type:";
            // 
            // ApplicationListDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 267);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxSecurityType);
            this.Controls.Add(this.listViewApplications);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ApplicationListDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Choose Application";
            this.Load += new System.EventHandler(this.ApplicationListDialog_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ApplicationListDialog_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListView listViewApplications;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ComboBox comboBoxSecurityType;
        private System.Windows.Forms.Label label2;
    }
}