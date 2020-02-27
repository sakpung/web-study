namespace Leadtools.Demos
{
   partial class ImagesDownloadDialog
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImagesDownloadDialog));
          this.label1 = new System.Windows.Forms.Label();
          this.linkLabel1 = new System.Windows.Forms.LinkLabel();
          this._btnOK = new System.Windows.Forms.Button();
          this._chkBoxDontShowThisAgain = new System.Windows.Forms.CheckBox();
          this.SuspendLayout();
          // 
          // label1
          // 
          resources.ApplyResources(this.label1, "label1");
          this.label1.Name = "label1";
          // 
          // linkLabel1
          // 
          resources.ApplyResources(this.linkLabel1, "linkLabel1");
          this.linkLabel1.Name = "linkLabel1";
          this.linkLabel1.TabStop = true;
          this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
          // 
          // _btnOK
          // 
          this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
          resources.ApplyResources(this._btnOK, "_btnOK");
          this._btnOK.Name = "_btnOK";
          this._btnOK.UseVisualStyleBackColor = true;
          this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
          // 
          // _chkBoxDontShowThisAgain
          // 
          resources.ApplyResources(this._chkBoxDontShowThisAgain, "_chkBoxDontShowThisAgain");
          this._chkBoxDontShowThisAgain.Name = "_chkBoxDontShowThisAgain";
          this._chkBoxDontShowThisAgain.UseVisualStyleBackColor = true;
          // 
          // ImagesDownloadDialog
          // 
          this.AcceptButton = this._btnOK;
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this._btnOK;
          this.Controls.Add(this._chkBoxDontShowThisAgain);
          this.Controls.Add(this._btnOK);
          this.Controls.Add(this.linkLabel1);
          this.Controls.Add(this.label1);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "ImagesDownloadDialog";
          this.ShowIcon = false;
          this.ResumeLayout(false);
          this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.LinkLabel linkLabel1;
      private System.Windows.Forms.Button _btnOK;
      private System.Windows.Forms.CheckBox _chkBoxDontShowThisAgain;
   }
}