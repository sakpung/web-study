namespace WiaDemo
{
   partial class SupportedCapabilitiesForm
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupportedCapabilitiesForm));
         this._btnClose = new System.Windows.Forms.Button();
         this.label1 = new System.Windows.Forms.Label();
         this._lvCapabilities = new System.Windows.Forms.ListView();
         this._lblCapabilitiesCount = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // _btnClose
         // 
         resources.ApplyResources(this._btnClose, "_btnClose");
         this._btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnClose.Name = "_btnClose";
         this._btnClose.UseVisualStyleBackColor = true;
         // 
         // label1
         // 
         resources.ApplyResources(this.label1, "label1");
         this.label1.Name = "label1";
         // 
         // _lvCapabilities
         // 
         resources.ApplyResources(this._lvCapabilities, "_lvCapabilities");
         this._lvCapabilities.FullRowSelect = true;
         this._lvCapabilities.GridLines = true;
         this._lvCapabilities.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
         this._lvCapabilities.MultiSelect = false;
         this._lvCapabilities.Name = "_lvCapabilities";
         this._lvCapabilities.UseCompatibleStateImageBehavior = false;
         this._lvCapabilities.View = System.Windows.Forms.View.Details;
         this._lvCapabilities.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this._lvCapabilities_MouseDoubleClick);
         // 
         // _lblCapabilitiesCount
         // 
         resources.ApplyResources(this._lblCapabilitiesCount, "_lblCapabilitiesCount");
         this._lblCapabilitiesCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._lblCapabilitiesCount.Name = "_lblCapabilitiesCount";
         // 
         // SupportedCapabilitiesForm
         // 
         this.AcceptButton = this._btnClose;
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnClose;
         this.Controls.Add(this._lblCapabilitiesCount);
         this.Controls.Add(this._lvCapabilities);
         this.Controls.Add(this.label1);
         this.Controls.Add(this._btnClose);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "SupportedCapabilitiesForm";
         this.ShowInTaskbar = false;
         this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
         this.Load += new System.EventHandler(this.SupportedCapabilitiesForm_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button _btnClose;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.ListView _lvCapabilities;
      private System.Windows.Forms.Label _lblCapabilitiesCount;
   }
}