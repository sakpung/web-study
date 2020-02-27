namespace MainDemo
{
   partial class SpatialDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpatialDialog));
         this._grbOptions = new System.Windows.Forms.GroupBox();
         this._cbFilter = new System.Windows.Forms.ComboBox();
         this._lblFilter = new System.Windows.Forms.Label();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this._grbOptions.SuspendLayout();
         this.SuspendLayout();
         // 
         // _grbOptions
         // 
         this._grbOptions.Controls.Add(this._cbFilter);
         this._grbOptions.Controls.Add(this._lblFilter);
         this._grbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._grbOptions, "_grbOptions");
         this._grbOptions.Name = "_grbOptions";
         this._grbOptions.TabStop = false;
         // 
         // _cbFilter
         // 
         this._cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         resources.ApplyResources(this._cbFilter, "_cbFilter");
         this._cbFilter.Name = "_cbFilter";
         // 
         // _lblFilter
         // 
         this._lblFilter.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblFilter, "_lblFilter");
         this._lblFilter.Name = "_lblFilter";
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
         // 
         // SpatialDialog
         // 
         this.AcceptButton = this._btnOk;
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.Controls.Add(this._grbOptions);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "SpatialDialog";
         this.ShowInTaskbar = false;
         this.Load += new System.EventHandler(this.SpatialDialog_Load);
         this._grbOptions.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _grbOptions;
      private System.Windows.Forms.ComboBox _cbFilter;
      private System.Windows.Forms.Label _lblFilter;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
   }
}