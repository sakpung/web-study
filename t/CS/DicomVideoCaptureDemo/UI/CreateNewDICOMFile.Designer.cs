namespace DicomVideoCaptureDemo.UI
{
   partial class CreateNewDICOMFile
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateNewDICOMFile));
         this._lstBx = new System.Windows.Forms.ListBox();
         this._btn_OK = new System.Windows.Forms.Button();
         this._btn_Cancel = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // _lstBx
         // 
         this._lstBx.FormattingEnabled = true;
         this._lstBx.Location = new System.Drawing.Point(13, 13);
         this._lstBx.Name = "_lstBx";
         this._lstBx.Size = new System.Drawing.Size(259, 199);
         this._lstBx.TabIndex = 0;
         this._lstBx.DoubleClick += new System.EventHandler(this._lstBx_DoubleClick);
         // 
         // _btn_OK
         // 
         this._btn_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btn_OK.Location = new System.Drawing.Point(105, 227);
         this._btn_OK.Name = "_btn_OK";
         this._btn_OK.Size = new System.Drawing.Size(75, 23);
         this._btn_OK.TabIndex = 1;
         this._btn_OK.Text = "OK";
         this._btn_OK.UseVisualStyleBackColor = true;
         this._btn_OK.Click += new System.EventHandler(this._btn_OK_Click);
         // 
         // _btn_Cancel
         // 
         this._btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btn_Cancel.Location = new System.Drawing.Point(197, 227);
         this._btn_Cancel.Name = "_btn_Cancel";
         this._btn_Cancel.Size = new System.Drawing.Size(75, 23);
         this._btn_Cancel.TabIndex = 2;
         this._btn_Cancel.Text = "Cancel";
         this._btn_Cancel.UseVisualStyleBackColor = true;
         // 
         // CreateNewDICOMFile
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(284, 262);
         this.Controls.Add(this._btn_Cancel);
         this.Controls.Add(this._btn_OK);
         this.Controls.Add(this._lstBx);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "CreateNewDICOMFile";
         this.Text = "Create New DICOM File";
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.ListBox _lstBx;
      private System.Windows.Forms.Button _btn_OK;
      private System.Windows.Forms.Button _btn_Cancel;
   }
}