namespace OmrProcessingDemo.UI
{
   partial class TwainDialog
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
         this.btnScan = new System.Windows.Forms.Button();
         this.btnCancel = new System.Windows.Forms.Button();
         this.btnSelectSource = new System.Windows.Forms.Button();
         this.btnChooseSaveLocation = new System.Windows.Forms.Button();
         this.txtSelectedSource = new System.Windows.Forms.TextBox();
         this.txtSaveLocation = new System.Windows.Forms.TextBox();
         this.SuspendLayout();
         // 
         // btnScan
         // 
         this.btnScan.Location = new System.Drawing.Point(221, 70);
         this.btnScan.Name = "btnScan";
         this.btnScan.Size = new System.Drawing.Size(75, 23);
         this.btnScan.TabIndex = 1;
         this.btnScan.Text = "Scan";
         this.btnScan.UseVisualStyleBackColor = true;
         this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
         // 
         // btnCancel
         // 
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point(302, 70);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(75, 23);
         this.btnCancel.TabIndex = 2;
         this.btnCancel.Text = "Cancel";
         this.btnCancel.UseVisualStyleBackColor = true;
         // 
         // btnSelectSource
         // 
         this.btnSelectSource.Location = new System.Drawing.Point(12, 12);
         this.btnSelectSource.Name = "btnSelectSource";
         this.btnSelectSource.Size = new System.Drawing.Size(137, 23);
         this.btnSelectSource.TabIndex = 3;
         this.btnSelectSource.Text = "Choose Scanner";
         this.btnSelectSource.UseVisualStyleBackColor = true;
         this.btnSelectSource.Click += new System.EventHandler(this.btnSelectSource_Click);
         // 
         // btnChooseSaveLocation
         // 
         this.btnChooseSaveLocation.Location = new System.Drawing.Point(12, 41);
         this.btnChooseSaveLocation.Name = "btnChooseSaveLocation";
         this.btnChooseSaveLocation.Size = new System.Drawing.Size(137, 23);
         this.btnChooseSaveLocation.TabIndex = 5;
         this.btnChooseSaveLocation.Text = "Choose Save Location";
         this.btnChooseSaveLocation.UseVisualStyleBackColor = true;
         this.btnChooseSaveLocation.Click += new System.EventHandler(this.btnChooseSaveLocation_Click);
         // 
         // txtSelectedSource
         // 
         this.txtSelectedSource.Enabled = false;
         this.txtSelectedSource.Location = new System.Drawing.Point(155, 15);
         this.txtSelectedSource.Name = "txtSelectedSource";
         this.txtSelectedSource.Size = new System.Drawing.Size(222, 20);
         this.txtSelectedSource.TabIndex = 6;
         // 
         // txtSaveLocation
         // 
         this.txtSaveLocation.Enabled = false;
         this.txtSaveLocation.Location = new System.Drawing.Point(155, 44);
         this.txtSaveLocation.Name = "txtSaveLocation";
         this.txtSaveLocation.Size = new System.Drawing.Size(222, 20);
         this.txtSaveLocation.TabIndex = 7;
         // 
         // TwainDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.btnCancel;
         this.ClientSize = new System.Drawing.Size(388, 104);
         this.Controls.Add(this.txtSaveLocation);
         this.Controls.Add(this.txtSelectedSource);
         this.Controls.Add(this.btnChooseSaveLocation);
         this.Controls.Add(this.btnSelectSource);
         this.Controls.Add(this.btnCancel);
         this.Controls.Add(this.btnScan);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "TwainDialog";
         this.ShowInTaskbar = false;
         this.Text = "Scanner Input";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TwainDialog_FormClosing);
         this.Load += new System.EventHandler(this.TwainDialog_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion
      private System.Windows.Forms.Button btnScan;
      private System.Windows.Forms.Button btnCancel;
      private System.Windows.Forms.Button btnSelectSource;
      private System.Windows.Forms.Button btnChooseSaveLocation;
      private System.Windows.Forms.TextBox txtSelectedSource;
      private System.Windows.Forms.TextBox txtSaveLocation;
   }
}