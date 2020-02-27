namespace MainDemo
{
   partial class SwapColorsDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SwapColorsDialog));
         this._gbOptions = new System.Windows.Forms.GroupBox();
         this._cbType = new System.Windows.Forms.ComboBox();
         this._labelType = new System.Windows.Forms.Label();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this._gbOptions.SuspendLayout();
         this.SuspendLayout();
         // 
         // _gbOptions
         // 
         this._gbOptions.Controls.Add(this._cbType);
         this._gbOptions.Controls.Add(this._labelType);
         this._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbOptions, "_gbOptions");
         this._gbOptions.Name = "_gbOptions";
         this._gbOptions.TabStop = false;
         // 
         // _cbType
         // 
         this._cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         resources.ApplyResources(this._cbType, "_cbType");
         this._cbType.Name = "_cbType";
         // 
         // _labelType
         // 
         this._labelType.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._labelType, "_labelType");
         this._labelType.Name = "_labelType";
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
         // SwapColorsDialog
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
         this.Name = "SwapColorsDialog";
         this.ShowInTaskbar = false;
         this.Load += new System.EventHandler(this.SwapColorsDialog_Load);
         this._gbOptions.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _gbOptions;
      private System.Windows.Forms.ComboBox _cbType;
      private System.Windows.Forms.Label _labelType;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
   }
}