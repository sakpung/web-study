using Leadtools.Medical.PatientRestrict.AddIn.Dialogs;
using Leadtools.Medical.WebViewer.PatientAccessRights;

namespace Leadtools.Medical.PatientRestrict.AddIn.Dialogs
{
   partial class InsertModifyAeRoleDialog
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
         Leadtools.Medical.WebViewer.PatientAccessRights.AeAccessKey aeAccessKey2 = new Leadtools.Medical.WebViewer.PatientAccessRights.AeAccessKey();
         this.buttonCancel = new System.Windows.Forms.Button();
         this.buttonOK = new System.Windows.Forms.Button();
         this.insertModifyAeRoleControl = new Leadtools.Medical.PatientRestrict.AddIn.Dialogs.InsertModifyAeRoleControl();
         this.SuspendLayout();
         // 
         // buttonCancel
         // 
         this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.buttonCancel.Location = new System.Drawing.Point(421, 94);
         this.buttonCancel.Name = "buttonCancel";
         this.buttonCancel.Size = new System.Drawing.Size(75, 23);
         this.buttonCancel.TabIndex = 4;
         this.buttonCancel.Text = "Cancel";
         this.buttonCancel.UseVisualStyleBackColor = true;
         this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
         // 
         // buttonOK
         // 
         this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonOK.Location = new System.Drawing.Point(339, 94);
         this.buttonOK.Name = "buttonOK";
         this.buttonOK.Size = new System.Drawing.Size(75, 23);
         this.buttonOK.TabIndex = 3;
         this.buttonOK.Text = "OK";
         this.buttonOK.UseVisualStyleBackColor = true;
         this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
         // 
         // insertModifyAeRoleControl
         // 
         this.insertModifyAeRoleControl.aeList = null;
         aeAccessKey2.AccessKey = "";
         aeAccessKey2.AeTitle = "";
         this.insertModifyAeRoleControl.aeRole = aeAccessKey2;
         this.insertModifyAeRoleControl.aeRoleList = null;
         this.insertModifyAeRoleControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.insertModifyAeRoleControl.AutoSize = true;
         this.insertModifyAeRoleControl.ControlType = Leadtools.Medical.PatientRestrict.AddIn.Dialogs.InsertModifyAeRoleControlType.Insert;
         this.insertModifyAeRoleControl.Location = new System.Drawing.Point(0, 0);
         this.insertModifyAeRoleControl.Name = "insertModifyAeRoleControl";
         this.insertModifyAeRoleControl.roleList = null;
         this.insertModifyAeRoleControl.Size = new System.Drawing.Size(509, 81);
         this.insertModifyAeRoleControl.TabIndex = 0;
         // 
         // InsertModifyAeRoleDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(503, 131);
         this.Controls.Add(this.buttonCancel);
         this.Controls.Add(this.buttonOK);
         this.Controls.Add(this.insertModifyAeRoleControl);
         this.Name = "InsertModifyAeRoleDialog";
         this.ShowIcon = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "InsertModifyAeRoleDialog";
         this.Load += new System.EventHandler(this.InsertModifyClientDialog_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private InsertModifyAeRoleControl insertModifyAeRoleControl;
      private System.Windows.Forms.Button buttonCancel;
      private System.Windows.Forms.Button buttonOK;
   }
}