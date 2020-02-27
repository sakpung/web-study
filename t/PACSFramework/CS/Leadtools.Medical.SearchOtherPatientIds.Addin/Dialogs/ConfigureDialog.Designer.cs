namespace Leadtools.Medical.SearchOtherPatientId.Addin.Dialogs
{
   partial class ConfigureDialog
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
         this.checkBoxUseOtherPatientId = new System.Windows.Forms.CheckBox();
         this.buttonOK = new System.Windows.Forms.Button();
         this.buttonCancel = new System.Windows.Forms.Button();
         this.panel1 = new System.Windows.Forms.Panel();
         this.label1 = new System.Windows.Forms.Label();
         this.panel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // checkBoxUseOtherPatientId
         // 
         this.checkBoxUseOtherPatientId.AutoSize = true;
         this.checkBoxUseOtherPatientId.Location = new System.Drawing.Point(12, 55);
         this.checkBoxUseOtherPatientId.Name = "checkBoxUseOtherPatientId";
         this.checkBoxUseOtherPatientId.Size = new System.Drawing.Size(148, 17);
         this.checkBoxUseOtherPatientId.TabIndex = 0;
         this.checkBoxUseOtherPatientId.Text = "Search \'Other Patient IDs\'";
         this.checkBoxUseOtherPatientId.UseVisualStyleBackColor = true;
         // 
         // buttonOK
         // 
         this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.buttonOK.Location = new System.Drawing.Point(177, 90);
         this.buttonOK.Name = "buttonOK";
         this.buttonOK.Size = new System.Drawing.Size(75, 23);
         this.buttonOK.TabIndex = 1;
         this.buttonOK.Text = "&OK";
         this.buttonOK.UseVisualStyleBackColor = true;
         // 
         // buttonCancel
         // 
         this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.buttonCancel.Location = new System.Drawing.Point(258, 90);
         this.buttonCancel.Name = "buttonCancel";
         this.buttonCancel.Size = new System.Drawing.Size(75, 23);
         this.buttonCancel.TabIndex = 2;
         this.buttonCancel.Text = "&Cancel";
         this.buttonCancel.UseVisualStyleBackColor = true;
         // 
         // panel1
         // 
         this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.panel1.Controls.Add(this.label1);
         this.panel1.Location = new System.Drawing.Point(12, 3);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(321, 46);
         this.panel1.TabIndex = 4;
         // 
         // label1
         // 
         this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.label1.Location = new System.Drawing.Point(0, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(321, 46);
         this.label1.TabIndex = 4;
         this.label1.Text = "Check to configure C-Find queries to search the \'Other Patient IDs\' element in ad" +
    "dition to the \'Patient ID\' element.";
         // 
         // ConfigureDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(345, 125);
         this.Controls.Add(this.panel1);
         this.Controls.Add(this.buttonCancel);
         this.Controls.Add(this.buttonOK);
         this.Controls.Add(this.checkBoxUseOtherPatientId);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.MinimumSize = new System.Drawing.Size(361, 163);
         this.Name = "ConfigureDialog";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Other Patient ID Configuration";
         this.TopMost = true;
         this.panel1.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.CheckBox checkBoxUseOtherPatientId;
      private System.Windows.Forms.Button buttonOK;
      private System.Windows.Forms.Button buttonCancel;
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.Label label1;
   }
}