namespace CSMasterFormsEditor.UI
{
   partial class UpdateMasterFormsData
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateMasterFormsData));
         this._prgbar = new System.Windows.Forms.ProgressBar();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnConvert = new System.Windows.Forms.Button();
         this._btnBrowseSrcFolder = new System.Windows.Forms.Button();
         this._txtSrcFolder = new System.Windows.Forms.TextBox();
         this._lblSrcFolder = new System.Windows.Forms.Label();
         this._cbUseFullTextSearch = new System.Windows.Forms.CheckBox();
         this.SuspendLayout();
         // 
         // _prgbar
         // 
         this._prgbar.Dock = System.Windows.Forms.DockStyle.Bottom;
         this._prgbar.Location = new System.Drawing.Point(0, 122);
         this._prgbar.Name = "_prgbar";
         this._prgbar.Size = new System.Drawing.Size(610, 23);
         this._prgbar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
         this._prgbar.TabIndex = 14;
         // 
         // _btnCancel
         // 
         this._btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._btnCancel.Location = new System.Drawing.Point(450, 63);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(121, 38);
         this._btnCancel.TabIndex = 13;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
         // 
         // _btnConvert
         // 
         this._btnConvert.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._btnConvert.Location = new System.Drawing.Point(306, 63);
         this._btnConvert.Name = "_btnConvert";
         this._btnConvert.Size = new System.Drawing.Size(121, 38);
         this._btnConvert.TabIndex = 12;
         this._btnConvert.Text = "Convert";
         this._btnConvert.UseVisualStyleBackColor = true;
         this._btnConvert.Click += new System.EventHandler(this._btnConvert_Click);
         // 
         // _btnBrowseSrcFolder
         // 
         this._btnBrowseSrcFolder.Location = new System.Drawing.Point(578, 25);
         this._btnBrowseSrcFolder.Name = "_btnBrowseSrcFolder";
         this._btnBrowseSrcFolder.Size = new System.Drawing.Size(28, 20);
         this._btnBrowseSrcFolder.TabIndex = 11;
         this._btnBrowseSrcFolder.Text = "...";
         this._btnBrowseSrcFolder.UseVisualStyleBackColor = true;
         this._btnBrowseSrcFolder.Click += new System.EventHandler(this._btnBrowseSrcFolder_Click);
         // 
         // _txtSrcFolder
         // 
         this._txtSrcFolder.Location = new System.Drawing.Point(85, 25);
         this._txtSrcFolder.Name = "_txtSrcFolder";
         this._txtSrcFolder.Size = new System.Drawing.Size(487, 20);
         this._txtSrcFolder.TabIndex = 9;
         this._txtSrcFolder.TextChanged += new System.EventHandler(this._txtSrcFolder_TextChanged);
         // 
         // _lblSrcFolder
         // 
         this._lblSrcFolder.AutoSize = true;
         this._lblSrcFolder.Location = new System.Drawing.Point(6, 28);
         this._lblSrcFolder.Name = "_lblSrcFolder";
         this._lblSrcFolder.Size = new System.Drawing.Size(73, 13);
         this._lblSrcFolder.TabIndex = 10;
         this._lblSrcFolder.Text = "Source Folder";
         // 
         // _cbUseFullTextSearch
         // 
         this._cbUseFullTextSearch.AutoSize = true;
         this._cbUseFullTextSearch.Location = new System.Drawing.Point(85, 75);
         this._cbUseFullTextSearch.Name = "_cbUseFullTextSearch";
         this._cbUseFullTextSearch.Size = new System.Drawing.Size(187, 17);
         this._cbUseFullTextSearch.TabIndex = 15;
         this._cbUseFullTextSearch.Text = "Use/Generate full text search data";
         this._cbUseFullTextSearch.UseVisualStyleBackColor = true;
         this._cbUseFullTextSearch.Checked = true;
         // 
         // UpdateMasterFormsData
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(610, 145);
         this.Controls.Add(this._cbUseFullTextSearch);
         this.Controls.Add(this._prgbar);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnConvert);
         this.Controls.Add(this._btnBrowseSrcFolder);
         this.Controls.Add(this._txtSrcFolder);
         this.Controls.Add(this._lblSrcFolder);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.Name = "UpdateMasterFormsData";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Update Master Forms Data";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UpdateMasterFormsData_FormClosing);
         this.Load += new System.EventHandler(this.UpdateMasterFormsData_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.ProgressBar _prgbar;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnConvert;
      private System.Windows.Forms.Button _btnBrowseSrcFolder;
      private System.Windows.Forms.TextBox _txtSrcFolder;
      private System.Windows.Forms.Label _lblSrcFolder;
      private System.Windows.Forms.CheckBox _cbUseFullTextSearch;
   }
}