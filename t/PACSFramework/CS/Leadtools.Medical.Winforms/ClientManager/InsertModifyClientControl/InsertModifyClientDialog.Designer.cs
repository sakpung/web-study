namespace Leadtools.Medical.Winforms
{
   partial class InsertModifyClientDialog
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
         Leadtools.Medical.AeManagement.DataAccessLayer.ClientInformation clientInformation1 = new Leadtools.Medical.AeManagement.DataAccessLayer.ClientInformation();
         this.buttonCancel = new System.Windows.Forms.Button();
         this.buttonOK = new System.Windows.Forms.Button();
         this.insertModifyClientControl = new Leadtools.Medical.Winforms.InsertModifyClientControl();
         this.SuspendLayout();
         // 
         // buttonCancel
         // 
         this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.buttonCancel.Location = new System.Drawing.Point(421, 358);
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
         this.buttonOK.Location = new System.Drawing.Point(339, 358);
         this.buttonOK.Name = "buttonOK";
         this.buttonOK.Size = new System.Drawing.Size(75, 23);
         this.buttonOK.TabIndex = 3;
         this.buttonOK.Text = "OK";
         this.buttonOK.UseVisualStyleBackColor = true;
         this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
         // 
         // insertModifyClientControl
         // 
         this.insertModifyClientControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.insertModifyClientControl.AutoSize = true;
         this.insertModifyClientControl.ClientInformation = clientInformation1;
         this.insertModifyClientControl.ControlType = Leadtools.Medical.Winforms.InsertModifyClientControlType.Insert;
         this.insertModifyClientControl.Location = new System.Drawing.Point(0, 0);
         this.insertModifyClientControl.MinimumSize = new System.Drawing.Size(487, 320);
         this.insertModifyClientControl.Name = "insertModifyClientControl";
         this.insertModifyClientControl.Permissions = null;
         this.insertModifyClientControl.Size = new System.Drawing.Size(509, 351);
         this.insertModifyClientControl.TabIndex = 0;
         // 
         // InsertModifyClientDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(503, 393);
         this.Controls.Add(this.buttonCancel);
         this.Controls.Add(this.buttonOK);
         this.Controls.Add(this.insertModifyClientControl);
         this.MinimumSize = new System.Drawing.Size(519, 418);
         this.Name = "InsertModifyClientDialog";
         this.ShowIcon = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "InsertModifyClientDialog";
         this.Load += new System.EventHandler(this.InsertModifyClientDialog_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private Leadtools.Medical.Winforms.InsertModifyClientControl insertModifyClientControl;
      private System.Windows.Forms.Button buttonCancel;
      private System.Windows.Forms.Button buttonOK;
   }
}