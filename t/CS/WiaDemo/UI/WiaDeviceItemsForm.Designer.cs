namespace WiaDemo
{
   partial class WiaDeviceItemsForm
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WiaDeviceItemsForm));
         this._tvWiaDeviceItems = new System.Windows.Forms.TreeView();
         this._btnOk = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // _tvWiaDeviceItems
         // 
         resources.ApplyResources(this._tvWiaDeviceItems, "_tvWiaDeviceItems");
         this._tvWiaDeviceItems.Name = "_tvWiaDeviceItems";
         this._tvWiaDeviceItems.DoubleClick += new System.EventHandler(this._tvWiaDeviceItems_DoubleClick);
         this._tvWiaDeviceItems.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this._tvWiaDeviceItems_AfterSelect);
         // 
         // _btnOk
         // 
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
         // WiaDeviceItemsForm
         // 
         this.AcceptButton = this._btnOk;
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.Controls.Add(this._tvWiaDeviceItems);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.Name = "WiaDeviceItemsForm";
         this.ShowInTaskbar = false;
         this.Load += new System.EventHandler(this.WiaDeviceItemsForm_Load);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TreeView _tvWiaDeviceItems;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Button _btnCancel;
   }
}