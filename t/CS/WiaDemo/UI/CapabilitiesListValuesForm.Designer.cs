namespace WiaDemo
{
   partial class CapabilitiesListValuesForm
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CapabilitiesListValuesForm));
         this.label1 = new System.Windows.Forms.Label();
         this._tbPropertyName = new System.Windows.Forms.TextBox();
         this._btnClose = new System.Windows.Forms.Button();
         this._lblValues = new System.Windows.Forms.Label();
         this._lbValues = new System.Windows.Forms.ListBox();
         this.SuspendLayout();
         // 
         // label1
         // 
         resources.ApplyResources(this.label1, "label1");
         this.label1.Name = "label1";
         // 
         // _tbPropertyName
         // 
         resources.ApplyResources(this._tbPropertyName, "_tbPropertyName");
         this._tbPropertyName.Name = "_tbPropertyName";
         this._tbPropertyName.ReadOnly = true;
         // 
         // _btnClose
         // 
         this._btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         resources.ApplyResources(this._btnClose, "_btnClose");
         this._btnClose.Name = "_btnClose";
         this._btnClose.UseVisualStyleBackColor = true;
         // 
         // _lblValues
         // 
         resources.ApplyResources(this._lblValues, "_lblValues");
         this._lblValues.Name = "_lblValues";
         // 
         // _lbValues
         // 
         this._lbValues.FormattingEnabled = true;
         resources.ApplyResources(this._lbValues, "_lbValues");
         this._lbValues.Name = "_lbValues";
         this._lbValues.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
         // 
         // CapabilitiesListValuesForm
         // 
         this.AcceptButton = this._btnClose;
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnClose;
         this.Controls.Add(this._lbValues);
         this.Controls.Add(this._lblValues);
         this.Controls.Add(this._btnClose);
         this.Controls.Add(this._tbPropertyName);
         this.Controls.Add(this.label1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.Name = "CapabilitiesListValuesForm";
         this.ShowInTaskbar = false;
         this.Load += new System.EventHandler(this.CapabilitiesListValuesForm_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox _tbPropertyName;
      private System.Windows.Forms.Button _btnClose;
      private System.Windows.Forms.Label _lblValues;
      private System.Windows.Forms.ListBox _lbValues;
   }
}