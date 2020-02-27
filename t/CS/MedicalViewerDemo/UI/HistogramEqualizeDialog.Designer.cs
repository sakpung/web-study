namespace MedicalViewerDemo
{
   partial class HistogramEqualizeDialog
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
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this._gbOptions = new System.Windows.Forms.GroupBox();
         this._cbColorSpace = new System.Windows.Forms.ComboBox();
         this._lblColorSpace = new System.Windows.Forms.Label();
         this._btnApply = new System.Windows.Forms.Button();
         this._gbOptions.SuspendLayout();
         this.SuspendLayout();
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnCancel.Location = new System.Drawing.Point(203, 83);
         this._btnCancel.Margin = new System.Windows.Forms.Padding(2);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(68, 22);
         this._btnCancel.TabIndex = 2;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
         // 
         // _btnOk
         // 
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnOk.Location = new System.Drawing.Point(109, 83);
         this._btnOk.Margin = new System.Windows.Forms.Padding(2);
         this._btnOk.Name = "_btnOk";
         this._btnOk.Size = new System.Drawing.Size(68, 22);
         this._btnOk.TabIndex = 1;
         this._btnOk.Text = "OK";
         this._btnOk.UseVisualStyleBackColor = true;
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // _gbOptions
         // 
         this._gbOptions.Controls.Add(this._cbColorSpace);
         this._gbOptions.Controls.Add(this._lblColorSpace);
         this._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._gbOptions.Location = new System.Drawing.Point(11, 11);
         this._gbOptions.Margin = new System.Windows.Forms.Padding(2);
         this._gbOptions.Name = "_gbOptions";
         this._gbOptions.Padding = new System.Windows.Forms.Padding(2);
         this._gbOptions.Size = new System.Drawing.Size(265, 56);
         this._gbOptions.TabIndex = 0;
         this._gbOptions.TabStop = false;
         // 
         // _cbColorSpace
         // 
         this._cbColorSpace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cbColorSpace.FormattingEnabled = true;
         this._cbColorSpace.Items.AddRange(new object[] {
            "RGB Space",
            "YUV Space",
            "Gray Space"});
         this._cbColorSpace.Location = new System.Drawing.Point(4, 23);
         this._cbColorSpace.Margin = new System.Windows.Forms.Padding(2);
         this._cbColorSpace.Name = "_cbColorSpace";
         this._cbColorSpace.Size = new System.Drawing.Size(257, 21);
         this._cbColorSpace.TabIndex = 1;
         // 
         // _lblColorSpace
         // 
         this._lblColorSpace.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblColorSpace.Location = new System.Drawing.Point(4, 0);
         this._lblColorSpace.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this._lblColorSpace.Name = "_lblColorSpace";
         this._lblColorSpace.Size = new System.Drawing.Size(65, 21);
         this._lblColorSpace.TabIndex = 0;
         this._lblColorSpace.Text = "Color Space";
         this._lblColorSpace.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _btnApply
         // 
         this._btnApply.Location = new System.Drawing.Point(15, 83);
         this._btnApply.Name = "_btnApply";
         this._btnApply.Size = new System.Drawing.Size(68, 22);
         this._btnApply.TabIndex = 3;
         this._btnApply.Text = "Apply";
         this._btnApply.UseVisualStyleBackColor = true;
         this._btnApply.Click += new System.EventHandler(this._btnApply_Click);
         // 
         // HistogramEqualizeDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(289, 116);
         this.Controls.Add(this._btnApply);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.Controls.Add(this._gbOptions);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Margin = new System.Windows.Forms.Padding(2);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "HistogramEqualizeDialog";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Histo Equalize";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HistogramEqualizeDialog_FormClosing);
         this._gbOptions.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.GroupBox _gbOptions;
      private System.Windows.Forms.ComboBox _cbColorSpace;
      private System.Windows.Forms.Label _lblColorSpace;
      private System.Windows.Forms.Button _btnApply;
   }
}