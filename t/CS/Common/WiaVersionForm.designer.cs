namespace Leadtools.Demos
{
   partial class WiaVersionForm
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WiaVersionForm));
         this._lbWiaVersions = new System.Windows.Forms.ListBox();
         this._btnOk = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // _lbWiaVersions
         // 
         resources.ApplyResources(this._lbWiaVersions, "_lbWiaVersions");
         this._lbWiaVersions.FormattingEnabled = true;
         this._lbWiaVersions.Name = "_lbWiaVersions";
         this._lbWiaVersions.SelectedIndexChanged += new System.EventHandler(this._lbWiaVersions_SelectedIndexChanged);
         this._lbWiaVersions.DoubleClick += new System.EventHandler(this._lbWiaVersions_DoubleClick);
         // 
         // _btnOk
         // 
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         resources.ApplyResources(this._btnOk, "_btnOk");
         this._btnOk.Name = "_btnOk";
         this._btnOk.UseVisualStyleBackColor = true;
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         resources.ApplyResources(this._btnCancel, "_btnCancel");
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // WiaVersionForm
         // 
         this.AcceptButton = this._btnOk;
         this.CancelButton = this._btnCancel;
         resources.ApplyResources(this, "$this");
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.Controls.Add(this._lbWiaVersions);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "WiaVersionForm";
         this.ShowIcon = false;
         this.Load += new System.EventHandler(this.WiaVersionForm_Load);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.ListBox _lbWiaVersions;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Button _btnCancel;
   }
}