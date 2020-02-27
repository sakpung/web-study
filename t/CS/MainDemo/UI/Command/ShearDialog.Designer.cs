namespace MainDemo
{
   partial class ShearDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShearDialog));
         this._gb = new System.Windows.Forms.GroupBox();
         this._lblDirection = new System.Windows.Forms.Label();
         this._gbDirection = new System.Windows.Forms.GroupBox();
         this._btnFillColor = new System.Windows.Forms.Button();
         this._pnlFillColor = new System.Windows.Forms.Panel();
         this._lblFillColor = new System.Windows.Forms.Label();
         this._numAngle = new System.Windows.Forms.NumericUpDown();
         this._lblAngle = new System.Windows.Forms.Label();
         this._rbHorizontal = new System.Windows.Forms.RadioButton();
         this._rbVertical = new System.Windows.Forms.RadioButton();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this._gb.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numAngle)).BeginInit();
         this.SuspendLayout();
         // 
         // _gb
         // 
         this._gb.Controls.Add(this._lblDirection);
         this._gb.Controls.Add(this._gbDirection);
         this._gb.Controls.Add(this._btnFillColor);
         this._gb.Controls.Add(this._pnlFillColor);
         this._gb.Controls.Add(this._lblFillColor);
         this._gb.Controls.Add(this._numAngle);
         this._gb.Controls.Add(this._lblAngle);
         this._gb.Controls.Add(this._rbHorizontal);
         this._gb.Controls.Add(this._rbVertical);
         this._gb.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gb, "_gb");
         this._gb.Name = "_gb";
         this._gb.TabStop = false;
         // 
         // _lblDirection
         // 
         this._lblDirection.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblDirection, "_lblDirection");
         this._lblDirection.Name = "_lblDirection";
         // 
         // _gbDirection
         // 
         this._gbDirection.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbDirection, "_gbDirection");
         this._gbDirection.Name = "_gbDirection";
         this._gbDirection.TabStop = false;
         // 
         // _btnFillColor
         // 
         resources.ApplyResources(this._btnFillColor, "_btnFillColor");
         this._btnFillColor.Name = "_btnFillColor";
         this._btnFillColor.Click += new System.EventHandler(this._btnFillColor_Click);
         // 
         // _pnlFillColor
         // 
         this._pnlFillColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         resources.ApplyResources(this._pnlFillColor, "_pnlFillColor");
         this._pnlFillColor.Name = "_pnlFillColor";
         this._pnlFillColor.Paint += new System.Windows.Forms.PaintEventHandler(this._pnlFillColor_Paint);
         // 
         // _lblFillColor
         // 
         this._lblFillColor.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblFillColor, "_lblFillColor");
         this._lblFillColor.Name = "_lblFillColor";
         // 
         // _numAngle
         // 
         resources.ApplyResources(this._numAngle, "_numAngle");
         this._numAngle.Maximum = new decimal(new int[] {
            45,
            0,
            0,
            0});
         this._numAngle.Name = "_numAngle";
         this._numAngle.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _lblAngle
         // 
         this._lblAngle.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblAngle, "_lblAngle");
         this._lblAngle.Name = "_lblAngle";
         // 
         // _rbHorizontal
         // 
         resources.ApplyResources(this._rbHorizontal, "_rbHorizontal");
         this._rbHorizontal.Name = "_rbHorizontal";
         // 
         // _rbVertical
         // 
         resources.ApplyResources(this._rbVertical, "_rbVertical");
         this._rbVertical.Name = "_rbVertical";
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         resources.ApplyResources(this._btnCancel, "_btnCancel");
         this._btnCancel.Name = "_btnCancel";
         // 
         // _btnOk
         // 
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         resources.ApplyResources(this._btnOk, "_btnOk");
         this._btnOk.Name = "_btnOk";
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // ShearDialog
         // 
         this.AcceptButton = this._btnOk;
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.Controls.Add(this._gb);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ShearDialog";
         this.ShowInTaskbar = false;
         this.Load += new System.EventHandler(this.ShearDialog_Load);
         this._gb.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this._numAngle)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _gb;
      private System.Windows.Forms.Label _lblDirection;
      private System.Windows.Forms.GroupBox _gbDirection;
      private System.Windows.Forms.Button _btnFillColor;
      private System.Windows.Forms.Panel _pnlFillColor;
      private System.Windows.Forms.Label _lblFillColor;
      private System.Windows.Forms.NumericUpDown _numAngle;
      private System.Windows.Forms.Label _lblAngle;
      private System.Windows.Forms.RadioButton _rbHorizontal;
      private System.Windows.Forms.RadioButton _rbVertical;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
   }
}