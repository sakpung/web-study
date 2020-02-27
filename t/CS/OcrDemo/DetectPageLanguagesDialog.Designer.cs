namespace OcrDemo
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
         this._gbInstalledLanguages.Location = new System.Drawing.Point(12, 12);
         this._gbInstalledLanguages.Name = "_gbInstalledLanguages";
         this._gbInstalledLanguages.Size = new System.Drawing.Size(217, 319);
         this._gbInstalledLanguages.TabIndex = 1;
         this._gbInstalledLanguages.TabStop = false;
         this._gbInstalledLanguages.Text = "Languages to choose from:";
         // 
         // _lbSuggestedLanguages
         // 
         this._lbSuggestedLanguages.FormattingEnabled = true;
         this._lbSuggestedLanguages.HorizontalScrollbar = true;
         this._lbSuggestedLanguages.Location = new System.Drawing.Point(6, 19);
         this._lbSuggestedLanguages.Name = "_lbSuggestedLanguages";
         this._lbSuggestedLanguages.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
         this._lbSuggestedLanguages.Size = new System.Drawing.Size(204, 290);
         this._lbSuggestedLanguages.TabIndex = 0;
         this._lbSuggestedLanguages.SelectedIndexChanged += new System.EventHandler(this._lbSuggestedLanguages_SelectedIndexChanged);
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this._lbPageLanguages);
         this.groupBox1.Location = new System.Drawing.Point(364, 12);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(217, 290);
         this.groupBox1.TabIndex = 2;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Detected page Languages";
         // 
         // _lbPageLanguages
         // 
         this._lbPageLanguages.FormattingEnabled = true;
         this._lbPageLanguages.Location = new System.Drawing.Point(6, 19);
         this._lbPageLanguages.Name = "_lbPageLanguages";
         this._lbPageLanguages.Size = new System.Drawing.Size(204, 264);
         this._lbPageLanguages.TabIndex = 0;
         // 
         // _btnDetectLanguages
         // 
         this._btnDetectLanguages.Location = new System.Drawing.Point(236, 153);
         this._btnDetectLanguages.Name = "_btnDetectLanguages";
         this._btnDetectLanguages.Size = new System.Drawing.Size(122, 36);
         this._btnDetectLanguages.TabIndex = 3;
         this._btnDetectLanguages.Text = "&Detect languages";
         this._btnDetectLanguages.UseVisualStyleBackColor = true;
         this._btnDetectLanguages.Click += new System.EventHandler(this._btnDetectLanguages_Click);
         // 
         // _btnClose
         // 
         this._btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnClose.Location = new System.Drawing.Point(507, 308);
         this._btnClose.Name = "_btnClose";
         this._btnClose.Size = new System.Drawing.Size(75, 23);
         this._btnClose.TabIndex = 5;
         this._btnClose.Text = "&Close";
         this._btnClose.UseVisualStyleBackColor = true;
         // 
         // DetectPageLanguagesDialog
         // 
         this.AcceptButton = this._btnClose;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnClose;
         this.ClientSize = new System.Drawing.Size(594, 343);
         this.Controls.Add(this._btnClose);
         this.Controls.Add(this._btnDetectLanguages);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this._gbInstalledLanguages);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.Name = "DetectPageLanguagesDialog";
         this.Text = "Detect Page Languages";
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