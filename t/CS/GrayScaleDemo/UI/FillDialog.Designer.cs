namespace GrayScaleDemo
{
   partial class FillDialog
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
         this._pnlLevel = new System.Windows.Forms.Panel();
         this._numLevel = new System.Windows.Forms.NumericUpDown();
         this._lblLevel = new System.Windows.Forms.Label();
         this._pnlColor = new System.Windows.Forms.Panel();
         this._pnlRevColor = new System.Windows.Forms.Panel();
         this._btnDlgColor = new System.Windows.Forms.Button();
         this._lblColor = new System.Windows.Forms.Label();
         this._btnOk = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this._pnlLevel.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numLevel)).BeginInit();
         this._pnlColor.SuspendLayout();
         this.SuspendLayout();
         // 
         // _pnlLevel
         // 
         this._pnlLevel.Controls.Add(this._numLevel);
         this._pnlLevel.Controls.Add(this._lblLevel);
         this._pnlLevel.Location = new System.Drawing.Point(12, 12);
         this._pnlLevel.Name = "_pnlLevel";
         this._pnlLevel.Size = new System.Drawing.Size(236, 54);
         this._pnlLevel.TabIndex = 0;
         // 
         // _numLevel
         // 
         this._numLevel.Location = new System.Drawing.Point(108, 21);
         this._numLevel.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
         this._numLevel.Name = "_numLevel";
         this._numLevel.Size = new System.Drawing.Size(120, 20);
         this._numLevel.TabIndex = 1;
         // 
         // _lblLevel
         // 
         this._lblLevel.AutoSize = true;
         this._lblLevel.Location = new System.Drawing.Point(21, 23);
         this._lblLevel.Name = "_lblLevel";
         this._lblLevel.Size = new System.Drawing.Size(81, 13);
         this._lblLevel.TabIndex = 0;
         this._lblLevel.Text = "Fill Color Level :";
         // 
         // _pnlColor
         // 
         this._pnlColor.Controls.Add(this._pnlRevColor);
         this._pnlColor.Controls.Add(this._btnDlgColor);
         this._pnlColor.Controls.Add(this._lblColor);
         this._pnlColor.Location = new System.Drawing.Point(12, 17);
         this._pnlColor.Name = "_pnlColor";
         this._pnlColor.Size = new System.Drawing.Size(236, 54);
         this._pnlColor.TabIndex = 1;
         // 
         // _pnlRevColor
         // 
         this._pnlRevColor.Location = new System.Drawing.Point(128, 16);
         this._pnlRevColor.Name = "_pnlRevColor";
         this._pnlRevColor.Size = new System.Drawing.Size(90, 26);
         this._pnlRevColor.TabIndex = 2;
         // 
         // _btnDlgColor
         // 
         this._btnDlgColor.Location = new System.Drawing.Point(90, 16);
         this._btnDlgColor.Name = "_btnDlgColor";
         this._btnDlgColor.Size = new System.Drawing.Size(32, 26);
         this._btnDlgColor.TabIndex = 1;
         this._btnDlgColor.Text = "...";
         this._btnDlgColor.UseVisualStyleBackColor = true;
         this._btnDlgColor.Click += new System.EventHandler(this._btnDlgColor_Click);
         // 
         // _lblColor
         // 
         this._lblColor.AutoSize = true;
         this._lblColor.Location = new System.Drawing.Point(21, 23);
         this._lblColor.Name = "_lblColor";
         this._lblColor.Size = new System.Drawing.Size(37, 13);
         this._lblColor.TabIndex = 0;
         this._lblColor.Text = "Color :";
         // 
         // _btnOk
         // 
         this._btnOk.Location = new System.Drawing.Point(59, 86);
         this._btnOk.Name = "_btnOk";
         this._btnOk.Size = new System.Drawing.Size(68, 25);
         this._btnOk.TabIndex = 2;
         this._btnOk.Text = "OK";
         this._btnOk.UseVisualStyleBackColor = true;
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.Location = new System.Drawing.Point(134, 85);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(68, 25);
         this._btnCancel.TabIndex = 3;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
         // 
         // FillDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(260, 122);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.Controls.Add(this._pnlColor);
         this.Controls.Add(this._pnlLevel);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "FillDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Fill";
         this.Load += new System.EventHandler(this.FillDialog_Load);
         this._pnlLevel.ResumeLayout(false);
         this._pnlLevel.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numLevel)).EndInit();
         this._pnlColor.ResumeLayout(false);
         this._pnlColor.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Panel _pnlLevel;
      private System.Windows.Forms.NumericUpDown _numLevel;
      private System.Windows.Forms.Label _lblLevel;
      private System.Windows.Forms.Panel _pnlColor;
      private System.Windows.Forms.Button _btnDlgColor;
      private System.Windows.Forms.Label _lblColor;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Panel _pnlRevColor;
   }
}