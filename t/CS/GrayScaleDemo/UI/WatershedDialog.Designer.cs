namespace GrayScaleDemo
{
   partial class WatershedDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WatershedDialog));
         this._btnOK = new System.Windows.Forms.Button();
         this._btnReset = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // _btnOK
         // 
         resources.ApplyResources(this._btnOK, "_btnOK");
         this._btnOK.Name = "_btnOK";
         this._btnOK.UseVisualStyleBackColor = true;
         this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
         // 
         // _btnReset
         // 
         resources.ApplyResources(this._btnReset, "_btnReset");
         this._btnReset.Name = "_btnReset";
         this._btnReset.UseVisualStyleBackColor = true;
         this._btnReset.Click += new System.EventHandler(this._btnReset_Click);
         // 
         // _btnCancel
         // 
         resources.ApplyResources(this._btnCancel, "_btnCancel");
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
         // 
         // WatershedDialog
         // 
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnReset);
         this.Controls.Add(this._btnOK);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "WatershedDialog";
         this.TopMost = true;
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WatershedDialog_FormClosing);
         this.Load += new System.EventHandler(this.WatershedDialog_Load);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _btnOK;
      private System.Windows.Forms.Button _btnReset;
      private System.Windows.Forms.Button _btnCancel;
   }
}