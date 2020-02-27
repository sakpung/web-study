namespace OmrProcessingDemo.UI
{
   partial class BarcodeFieldDialog
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
         this.btnOK = new System.Windows.Forms.Button();
         this.btnCancel = new System.Windows.Forms.Button();
         this.txtName = new System.Windows.Forms.TextBox();
         this.lblName = new System.Windows.Forms.Label();
         this.lblSymbology = new System.Windows.Forms.Label();
         this.cboxSymbology = new System.Windows.Forms.ComboBox();
         this.btnAutoDetect = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // btnOK
         // 
         this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.btnOK.Location = new System.Drawing.Point(168, 91);
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size(75, 23);
         this.btnOK.TabIndex = 0;
         this.btnOK.Text = "OK";
         this.btnOK.UseVisualStyleBackColor = true;
         // 
         // btnCancel
         // 
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point(249, 91);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(75, 23);
         this.btnCancel.TabIndex = 1;
         this.btnCancel.Text = "Cancel";
         this.btnCancel.UseVisualStyleBackColor = true;
         // 
         // txtName
         // 
         this.txtName.Location = new System.Drawing.Point(73, 12);
         this.txtName.Name = "txtName";
         this.txtName.Size = new System.Drawing.Size(251, 20);
         this.txtName.TabIndex = 5;
         // 
         // lblName
         // 
         this.lblName.AutoSize = true;
         this.lblName.Location = new System.Drawing.Point(3, 15);
         this.lblName.Name = "lblName";
         this.lblName.Size = new System.Drawing.Size(38, 13);
         this.lblName.TabIndex = 4;
         this.lblName.Text = "Name:";
         // 
         // lblSymbology
         // 
         this.lblSymbology.AutoSize = true;
         this.lblSymbology.Location = new System.Drawing.Point(6, 44);
         this.lblSymbology.Name = "lblSymbology";
         this.lblSymbology.Size = new System.Drawing.Size(61, 13);
         this.lblSymbology.TabIndex = 6;
         this.lblSymbology.Text = "Symbology:";
         // 
         // cboxSymbology
         // 
         this.cboxSymbology.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cboxSymbology.FormattingEnabled = true;
         this.cboxSymbology.Location = new System.Drawing.Point(73, 41);
         this.cboxSymbology.Name = "cboxSymbology";
         this.cboxSymbology.Size = new System.Drawing.Size(170, 21);
         this.cboxSymbology.TabIndex = 7;
         // 
         // btnAutoDetect
         // 
         this.btnAutoDetect.Location = new System.Drawing.Point(249, 41);
         this.btnAutoDetect.Name = "btnAutoDetect";
         this.btnAutoDetect.Size = new System.Drawing.Size(75, 23);
         this.btnAutoDetect.TabIndex = 8;
         this.btnAutoDetect.Text = "Auto Detect";
         this.btnAutoDetect.UseVisualStyleBackColor = true;
         this.btnAutoDetect.Click += new System.EventHandler(this.btnAutoDetect_Click);
         // 
         // BarcodeFieldDialog
         // 
         this.AcceptButton = this.btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.btnCancel;
         this.ClientSize = new System.Drawing.Size(336, 126);
         this.Controls.Add(this.btnAutoDetect);
         this.Controls.Add(this.cboxSymbology);
         this.Controls.Add(this.lblSymbology);
         this.Controls.Add(this.txtName);
         this.Controls.Add(this.lblName);
         this.Controls.Add(this.btnCancel);
         this.Controls.Add(this.btnOK);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "BarcodeFieldDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Barcode";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BarcodeFieldDialog_FormClosing);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button btnOK;
      private System.Windows.Forms.Button btnCancel;
      private System.Windows.Forms.TextBox txtName;
      private System.Windows.Forms.Label lblName;
      private System.Windows.Forms.Label lblSymbology;
      private System.Windows.Forms.ComboBox cboxSymbology;
      private System.Windows.Forms.Button btnAutoDetect;
   }
}