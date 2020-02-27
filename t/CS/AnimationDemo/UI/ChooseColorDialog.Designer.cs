namespace AnimationDemo
{
   partial class ChooseColorDialog
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
         this._gpBitmapColors = new System.Windows.Forms.GroupBox();
         this._gpCurrentColor = new System.Windows.Forms.GroupBox();
         this.label1 = new System.Windows.Forms.Label();
         this._gpRGB = new System.Windows.Forms.GroupBox();
         this._txtBlue = new System.Windows.Forms.TextBox();
         this._txtGreen = new System.Windows.Forms.TextBox();
         this._txtRed = new System.Windows.Forms.TextBox();
         this._lblBlue = new System.Windows.Forms.Label();
         this._lblGreen = new System.Windows.Forms.Label();
         this._lblRed = new System.Windows.Forms.Label();
         this.panel1 = new System.Windows.Forms.Panel();
         this._btnOK = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this._gpCurrentColor.SuspendLayout();
         this._gpRGB.SuspendLayout();
         this.SuspendLayout();
         // 
         // _gpBitmapColors
         // 
         this._gpBitmapColors.Location = new System.Drawing.Point(12, 8);
         this._gpBitmapColors.Name = "_gpBitmapColors";
         this._gpBitmapColors.Size = new System.Drawing.Size(400, 44);
         this._gpBitmapColors.TabIndex = 0;
         this._gpBitmapColors.TabStop = false;
         this._gpBitmapColors.Text = "Bitmap Colors";
         // 
         // _gpCurrentColor
         // 
         this._gpCurrentColor.Controls.Add(this.label1);
         this._gpCurrentColor.Controls.Add(this._gpRGB);
         this._gpCurrentColor.Controls.Add(this.panel1);
         this._gpCurrentColor.Location = new System.Drawing.Point(12, 68);
         this._gpCurrentColor.Name = "_gpCurrentColor";
         this._gpCurrentColor.Size = new System.Drawing.Size(314, 113);
         this._gpCurrentColor.TabIndex = 1;
         this._gpCurrentColor.TabStop = false;
         this._gpCurrentColor.Text = "Bitmap Colors";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(13, 49);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(34, 13);
         this.label1.TabIndex = 8;
         this.label1.Text = "Color:";
         // 
         // _gpRGB
         // 
         this._gpRGB.Controls.Add(this._txtBlue);
         this._gpRGB.Controls.Add(this._txtGreen);
         this._gpRGB.Controls.Add(this._txtRed);
         this._gpRGB.Controls.Add(this._lblBlue);
         this._gpRGB.Controls.Add(this._lblGreen);
         this._gpRGB.Controls.Add(this._lblRed);
         this._gpRGB.Location = new System.Drawing.Point(198, 13);
         this._gpRGB.Name = "_gpRGB";
         this._gpRGB.Size = new System.Drawing.Size(107, 94);
         this._gpRGB.TabIndex = 7;
         this._gpRGB.TabStop = false;
         // 
         // _txtBlue
         // 
         this._txtBlue.Location = new System.Drawing.Point(53, 62);
         this._txtBlue.Name = "_txtBlue";
         this._txtBlue.ReadOnly = true;
         this._txtBlue.Size = new System.Drawing.Size(48, 20);
         this._txtBlue.TabIndex = 6;
         // 
         // _txtGreen
         // 
         this._txtGreen.Location = new System.Drawing.Point(53, 38);
         this._txtGreen.Name = "_txtGreen";
         this._txtGreen.ReadOnly = true;
         this._txtGreen.Size = new System.Drawing.Size(48, 20);
         this._txtGreen.TabIndex = 5;
         // 
         // _txtRed
         // 
         this._txtRed.Location = new System.Drawing.Point(53, 14);
         this._txtRed.Name = "_txtRed";
         this._txtRed.ReadOnly = true;
         this._txtRed.Size = new System.Drawing.Size(48, 20);
         this._txtRed.TabIndex = 4;
         // 
         // _lblBlue
         // 
         this._lblBlue.AutoSize = true;
         this._lblBlue.Location = new System.Drawing.Point(11, 65);
         this._lblBlue.Name = "_lblBlue";
         this._lblBlue.Size = new System.Drawing.Size(31, 13);
         this._lblBlue.TabIndex = 3;
         this._lblBlue.Text = "Blue:";
         // 
         // _lblGreen
         // 
         this._lblGreen.AutoSize = true;
         this._lblGreen.Location = new System.Drawing.Point(11, 41);
         this._lblGreen.Name = "_lblGreen";
         this._lblGreen.Size = new System.Drawing.Size(39, 13);
         this._lblGreen.TabIndex = 2;
         this._lblGreen.Text = "Green:";
         // 
         // _lblRed
         // 
         this._lblRed.AutoSize = true;
         this._lblRed.Location = new System.Drawing.Point(11, 17);
         this._lblRed.Name = "_lblRed";
         this._lblRed.Size = new System.Drawing.Size(30, 13);
         this._lblRed.TabIndex = 1;
         this._lblRed.Text = "Red:";
         // 
         // panel1
         // 
         this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.panel1.Location = new System.Drawing.Point(63, 30);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(119, 62);
         this.panel1.TabIndex = 0;
         // 
         // _btnOK
         // 
         this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOK.Location = new System.Drawing.Point(337, 83);
         this._btnOK.Name = "_btnOK";
         this._btnOK.Size = new System.Drawing.Size(75, 23);
         this._btnOK.TabIndex = 0;
         this._btnOK.Text = "&OK";
         this._btnOK.UseVisualStyleBackColor = true;
         this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(337, 112);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(75, 23);
         this._btnCancel.TabIndex = 2;
         this._btnCancel.Text = "&Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // ChooseColorDialog
         // 
         this.AcceptButton = this._btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(421, 199);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOK);
         this.Controls.Add(this._gpCurrentColor);
         this.Controls.Add(this._gpBitmapColors);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ChooseColorDialog";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Choose color";
         this.Load += new System.EventHandler(this.ColorDialog_Load);
         this._gpCurrentColor.ResumeLayout(false);
         this._gpCurrentColor.PerformLayout();
         this._gpRGB.ResumeLayout(false);
         this._gpRGB.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _gpBitmapColors;
      private System.Windows.Forms.GroupBox _gpCurrentColor;
      private System.Windows.Forms.Button _btnOK;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.Label _lblBlue;
      private System.Windows.Forms.Label _lblGreen;
      private System.Windows.Forms.Label _lblRed;
      private System.Windows.Forms.GroupBox _gpRGB;
      private System.Windows.Forms.TextBox _txtBlue;
      private System.Windows.Forms.TextBox _txtGreen;
      private System.Windows.Forms.TextBox _txtRed;
      private System.Windows.Forms.Label label1;
   }
}