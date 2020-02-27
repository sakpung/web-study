namespace WiaDemo
{
   partial class WiaPropertiesErrorsForm
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WiaPropertiesErrorsForm));
         this._btnOk = new System.Windows.Forms.Button();
         this._btnClear = new System.Windows.Forms.Button();
         this._lvErrors = new System.Windows.Forms.ListView();
         this.SuspendLayout();
         // 
         // _btnOk
         // 
         resources.ApplyResources(this._btnOk, "_btnOk");
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnOk.Name = "_btnOk";
         this._btnOk.UseVisualStyleBackColor = true;
         // 
         // _btnClear
         // 
         resources.ApplyResources(this._btnClear, "_btnClear");
         this._btnClear.Name = "_btnClear";
         this._btnClear.UseVisualStyleBackColor = true;
         this._btnClear.Click += new System.EventHandler(this._btnClear_Click);
         // 
         // _lvErrors
         // 
         resources.ApplyResources(this._lvErrors, "_lvErrors");
         this._lvErrors.FullRowSelect = true;
         this._lvErrors.GridLines = true;
         this._lvErrors.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
         this._lvErrors.Name = "_lvErrors";
         this._lvErrors.UseCompatibleStateImageBehavior = false;
         this._lvErrors.View = System.Windows.Forms.View.Details;
         // 
         // WiaPropertiesErrorsForm
         // 
         this.AcceptButton = this._btnOk;
         this.CancelButton = this._btnOk;
         resources.ApplyResources(this, "$this");
         this.Controls.Add(this._lvErrors);
         this.Controls.Add(this._btnClear);
         this.Controls.Add(this._btnOk);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.Name = "WiaPropertiesErrorsForm";
         this.ShowInTaskbar = false;
         this.Load += new System.EventHandler(this.WiaPropertiesErrorsForm_Load);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Button _btnClear;
      private System.Windows.Forms.ListView _lvErrors;


   }
}