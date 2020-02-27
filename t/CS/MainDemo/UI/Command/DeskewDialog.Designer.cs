namespace MainDemo
{
   partial class DeskewDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeskewDialog));
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this._gbOptions = new System.Windows.Forms.GroupBox();
         this._pnlFillColor = new System.Windows.Forms.Panel();
         this._btnFillColor = new System.Windows.Forms.Button();
         this._rbNoFill = new System.Windows.Forms.RadioButton();
         this._rbFill = new System.Windows.Forms.RadioButton();
         this._lblFillColor = new System.Windows.Forms.Label();
         this._gbOptions.SuspendLayout();
         this.SuspendLayout();
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         resources.ApplyResources(this._btnCancel, "_btnCancel");
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // _btnOk
         // 
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         resources.ApplyResources(this._btnOk, "_btnOk");
         this._btnOk.Name = "_btnOk";
         this._btnOk.UseVisualStyleBackColor = true;
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // _gbOptions
         // 
         this._gbOptions.Controls.Add(this._pnlFillColor);
         this._gbOptions.Controls.Add(this._btnFillColor);
         this._gbOptions.Controls.Add(this._rbNoFill);
         this._gbOptions.Controls.Add(this._rbFill);
         this._gbOptions.Controls.Add(this._lblFillColor);
         this._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbOptions, "_gbOptions");
         this._gbOptions.Name = "_gbOptions";
         this._gbOptions.TabStop = false;
         // 
         // _pnlFillColor
         // 
         this._pnlFillColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         resources.ApplyResources(this._pnlFillColor, "_pnlFillColor");
         this._pnlFillColor.Name = "_pnlFillColor";
         this._pnlFillColor.Paint += new System.Windows.Forms.PaintEventHandler(this._pnlFillColor_Paint);
         // 
         // _btnFillColor
         // 
         resources.ApplyResources(this._btnFillColor, "_btnFillColor");
         this._btnFillColor.Name = "_btnFillColor";
         this._btnFillColor.UseVisualStyleBackColor = true;
         this._btnFillColor.Click += new System.EventHandler(this._btnFillColor_Click);
         // 
         // _rbNoFill
         // 
         resources.ApplyResources(this._rbNoFill, "_rbNoFill");
         this._rbNoFill.Name = "_rbNoFill";
         this._rbNoFill.TabStop = true;
         this._rbNoFill.UseVisualStyleBackColor = true;
         this._rbNoFill.CheckedChanged += new System.EventHandler(this._rb_CheckedChanged);
         // 
         // _rbFill
         // 
         resources.ApplyResources(this._rbFill, "_rbFill");
         this._rbFill.Name = "_rbFill";
         this._rbFill.TabStop = true;
         this._rbFill.UseVisualStyleBackColor = true;
         this._rbFill.CheckedChanged += new System.EventHandler(this._rb_CheckedChanged);
         // 
         // _lblFillColor
         // 
         this._lblFillColor.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblFillColor, "_lblFillColor");
         this._lblFillColor.Name = "_lblFillColor";
         // 
         // DeskewDialog
         // 
         this.AcceptButton = this._btnOk;
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.Controls.Add(this._gbOptions);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "DeskewDialog";
         this.ShowInTaskbar = false;
         this.Load += new System.EventHandler(this.DeskewDialog_Load);
         this._gbOptions.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.GroupBox _gbOptions;
      private System.Windows.Forms.Label _lblFillColor;
      private System.Windows.Forms.Panel _pnlFillColor;
      private System.Windows.Forms.Button _btnFillColor;
      private System.Windows.Forms.RadioButton _rbNoFill;
      private System.Windows.Forms.RadioButton _rbFill;
   }
}