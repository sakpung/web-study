namespace Leadtools.Medical.Winforms.DatabaseManager.Export
{
   partial class AnonymizeOptionsDialog
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
         this.buttonCancel = new System.Windows.Forms.Button();
         this.buttonOk = new System.Windows.Forms.Button();
         this.panelAnonymizeOptions = new System.Windows.Forms.Panel();
         this.SuspendLayout();
         // 
         // buttonCancel
         // 
         this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.buttonCancel.Location = new System.Drawing.Point(399, 475);
         this.buttonCancel.Name = "buttonCancel";
         this.buttonCancel.Size = new System.Drawing.Size(75, 23);
         this.buttonCancel.TabIndex = 6;
         this.buttonCancel.Text = "&Cancel";
         this.buttonCancel.UseVisualStyleBackColor = true;
         // 
         // buttonOk
         // 
         this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.buttonOk.Location = new System.Drawing.Point(318, 475);
         this.buttonOk.Name = "buttonOk";
         this.buttonOk.Size = new System.Drawing.Size(75, 23);
         this.buttonOk.TabIndex = 5;
         this.buttonOk.Text = "&OK";
         this.buttonOk.UseVisualStyleBackColor = true;
         // 
         // panelAnonymizeOptions
         // 
         this.panelAnonymizeOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.panelAnonymizeOptions.Location = new System.Drawing.Point(1, 1);
         this.panelAnonymizeOptions.Name = "panelAnonymizeOptions";
         this.panelAnonymizeOptions.Size = new System.Drawing.Size(483, 468);
         this.panelAnonymizeOptions.TabIndex = 7;
         // 
         // AnonymizeOptionsDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(486, 507);
         this.Controls.Add(this.panelAnonymizeOptions);
         this.Controls.Add(this.buttonCancel);
         this.Controls.Add(this.buttonOk);
         this.MinimizeBox = false;
         this.MinimumSize = new System.Drawing.Size(502, 381);
         this.Name = "AnonymizeOptionsDialog";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Anonymize Options";
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button buttonCancel;
      private System.Windows.Forms.Button buttonOk;
      private System.Windows.Forms.Panel panelAnonymizeOptions;

   }
}