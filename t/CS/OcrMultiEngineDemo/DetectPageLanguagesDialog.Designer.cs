namespace OcrMultiEngineDemo
{
   partial class DetectPageLanguagesDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetectPageLanguagesDialog));
         this._gbInstalledLanguages = new System.Windows.Forms.GroupBox();
         this._lbSuggestedLanguages = new System.Windows.Forms.ListBox();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this._lbPageLanguages = new System.Windows.Forms.ListBox();
         this._btnDetectLanguages = new System.Windows.Forms.Button();
         this._btnClose = new System.Windows.Forms.Button();
         this._gbInstalledLanguages.SuspendLayout();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         // 
         // _gbInstalledLanguages
         // 
         this._gbInstalledLanguages.Controls.Add(this._lbSuggestedLanguages);
         resources.ApplyResources(this._gbInstalledLanguages, "_gbInstalledLanguages");
         this._gbInstalledLanguages.Name = "_gbInstalledLanguages";
         this._gbInstalledLanguages.TabStop = false;
         // 
         // _lbSuggestedLanguages
         // 
         this._lbSuggestedLanguages.FormattingEnabled = true;
         resources.ApplyResources(this._lbSuggestedLanguages, "_lbSuggestedLanguages");
         this._lbSuggestedLanguages.Name = "_lbSuggestedLanguages";
         this._lbSuggestedLanguages.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
         this._lbSuggestedLanguages.SelectedIndexChanged += new System.EventHandler(this._lbSuggestedLanguages_SelectedIndexChanged);
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this._lbPageLanguages);
         resources.ApplyResources(this.groupBox1, "groupBox1");
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.TabStop = false;
         // 
         // _lbPageLanguages
         // 
         this._lbPageLanguages.FormattingEnabled = true;
         resources.ApplyResources(this._lbPageLanguages, "_lbPageLanguages");
         this._lbPageLanguages.Name = "_lbPageLanguages";
         // 
         // _btnDetectLanguages
         // 
         resources.ApplyResources(this._btnDetectLanguages, "_btnDetectLanguages");
         this._btnDetectLanguages.Name = "_btnDetectLanguages";
         this._btnDetectLanguages.UseVisualStyleBackColor = true;
         this._btnDetectLanguages.Click += new System.EventHandler(this._btnDetectLanguages_Click);
         // 
         // _btnClose
         // 
         this._btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         resources.ApplyResources(this._btnClose, "_btnClose");
         this._btnClose.Name = "_btnClose";
         this._btnClose.UseVisualStyleBackColor = true;
         // 
         // DetectPageLanguagesDialog
         // 
         this.AcceptButton = this._btnClose;
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnClose;
         this.Controls.Add(this._btnClose);
         this.Controls.Add(this._btnDetectLanguages);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this._gbInstalledLanguages);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.Name = "DetectPageLanguagesDialog";
         this.Load += new System.EventHandler(this.DetectPageLanguagesDialog_Load);
         this._gbInstalledLanguages.ResumeLayout(false);
         this.groupBox1.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _gbInstalledLanguages;
      private System.Windows.Forms.ListBox _lbSuggestedLanguages;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.ListBox _lbPageLanguages;
      private System.Windows.Forms.Button _btnDetectLanguages;
      private System.Windows.Forms.Button _btnClose;
   }
}