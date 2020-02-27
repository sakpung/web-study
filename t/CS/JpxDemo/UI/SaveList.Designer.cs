namespace JPXDemo
{
   partial class SaveList
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveList));
         this._lblAvailableImages = new System.Windows.Forms.Label();
         this._lstAvailableImages = new System.Windows.Forms.ListBox();
         this._lstSelectedImages = new System.Windows.Forms.ListBox();
         this._lblSelectedImages = new System.Windows.Forms.Label();
         this._btnAdd = new System.Windows.Forms.Button();
         this._btnRemove = new System.Windows.Forms.Button();
         this._btnAddAll = new System.Windows.Forms.Button();
         this._btnRemoveAll = new System.Windows.Forms.Button();
         this._btnUp = new System.Windows.Forms.Button();
         this._btnDown = new System.Windows.Forms.Button();
         this._lblFileName = new System.Windows.Forms.Label();
         this._txtFileName = new System.Windows.Forms.TextBox();
         this._btnBrowse = new System.Windows.Forms.Button();
         this._btnSave = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this._lblBPP = new System.Windows.Forms.Label();
         this._cbBPP = new System.Windows.Forms.ComboBox();
         this.label1 = new System.Windows.Forms.Label();
         this._cbQualityFactor = new System.Windows.Forms.ComboBox();
         this.SuspendLayout();
         // 
         // _lblAvailableImages
         // 
         this._lblAvailableImages.AutoSize = true;
         this._lblAvailableImages.Location = new System.Drawing.Point(5, 9);
         this._lblAvailableImages.Name = "_lblAvailableImages";
         this._lblAvailableImages.Size = new System.Drawing.Size(87, 13);
         this._lblAvailableImages.TabIndex = 0;
         this._lblAvailableImages.Text = "&Available Images";
         // 
         // _lstAvailableImages
         // 
         this._lstAvailableImages.FormattingEnabled = true;
         this._lstAvailableImages.Location = new System.Drawing.Point(8, 27);
         this._lstAvailableImages.Name = "_lstAvailableImages";
         this._lstAvailableImages.Size = new System.Drawing.Size(234, 186);
         this._lstAvailableImages.TabIndex = 1;
         // 
         // _lstSelectedImages
         // 
         this._lstSelectedImages.FormattingEnabled = true;
         this._lstSelectedImages.Location = new System.Drawing.Point(292, 27);
         this._lstSelectedImages.Name = "_lstSelectedImages";
         this._lstSelectedImages.Size = new System.Drawing.Size(234, 186);
         this._lstSelectedImages.TabIndex = 3;
         // 
         // _lblSelectedImages
         // 
         this._lblSelectedImages.AutoSize = true;
         this._lblSelectedImages.Location = new System.Drawing.Point(299, 9);
         this._lblSelectedImages.Name = "_lblSelectedImages";
         this._lblSelectedImages.Size = new System.Drawing.Size(86, 13);
         this._lblSelectedImages.TabIndex = 2;
         this._lblSelectedImages.Text = "Se&lected Images";
         // 
         // _btnAdd
         // 
         this._btnAdd.Location = new System.Drawing.Point(250, 30);
         this._btnAdd.Name = "_btnAdd";
         this._btnAdd.Size = new System.Drawing.Size(32, 23);
         this._btnAdd.TabIndex = 4;
         this._btnAdd.Text = ">";
         this._btnAdd.UseVisualStyleBackColor = true;
         this._btnAdd.Click += new System.EventHandler(this._btnAdd_Click);
         // 
         // _btnRemove
         // 
         this._btnRemove.Location = new System.Drawing.Point(250, 59);
         this._btnRemove.Name = "_btnRemove";
         this._btnRemove.Size = new System.Drawing.Size(32, 23);
         this._btnRemove.TabIndex = 5;
         this._btnRemove.Text = "<";
         this._btnRemove.UseVisualStyleBackColor = true;
         this._btnRemove.Click += new System.EventHandler(this._btnRemove_Click);
         // 
         // _btnAddAll
         // 
         this._btnAddAll.Location = new System.Drawing.Point(250, 88);
         this._btnAddAll.Name = "_btnAddAll";
         this._btnAddAll.Size = new System.Drawing.Size(32, 23);
         this._btnAddAll.TabIndex = 6;
         this._btnAddAll.Text = ">>";
         this._btnAddAll.UseVisualStyleBackColor = true;
         this._btnAddAll.Click += new System.EventHandler(this._btnAddAll_Click);
         // 
         // _btnRemoveAll
         // 
         this._btnRemoveAll.Location = new System.Drawing.Point(250, 117);
         this._btnRemoveAll.Name = "_btnRemoveAll";
         this._btnRemoveAll.Size = new System.Drawing.Size(32, 23);
         this._btnRemoveAll.TabIndex = 7;
         this._btnRemoveAll.Text = "<<";
         this._btnRemoveAll.UseVisualStyleBackColor = true;
         this._btnRemoveAll.Click += new System.EventHandler(this._btnRemoveAll_Click);
         // 
         // _btnUp
         // 
         this._btnUp.Image = ((System.Drawing.Image)(resources.GetObject("_btnUp.Image")));
         this._btnUp.Location = new System.Drawing.Point(247, 158);
         this._btnUp.Name = "_btnUp";
         this._btnUp.Size = new System.Drawing.Size(41, 23);
         this._btnUp.TabIndex = 8;
         this._btnUp.UseVisualStyleBackColor = true;
         this._btnUp.Click += new System.EventHandler(this._btnUp_Click);
         // 
         // _btnDown
         // 
         this._btnDown.Image = ((System.Drawing.Image)(resources.GetObject("_btnDown.Image")));
         this._btnDown.Location = new System.Drawing.Point(247, 187);
         this._btnDown.Name = "_btnDown";
         this._btnDown.Size = new System.Drawing.Size(41, 23);
         this._btnDown.TabIndex = 9;
         this._btnDown.UseVisualStyleBackColor = true;
         this._btnDown.Click += new System.EventHandler(this._btnDown_Click);
         // 
         // _lblFileName
         // 
         this._lblFileName.AutoSize = true;
         this._lblFileName.Location = new System.Drawing.Point(5, 217);
         this._lblFileName.Name = "_lblFileName";
         this._lblFileName.Size = new System.Drawing.Size(54, 13);
         this._lblFileName.TabIndex = 10;
         this._lblFileName.Text = "File Name";
         // 
         // _txtFileName
         // 
         this._txtFileName.Location = new System.Drawing.Point(8, 233);
         this._txtFileName.Name = "_txtFileName";
         this._txtFileName.ReadOnly = true;
         this._txtFileName.Size = new System.Drawing.Size(440, 20);
         this._txtFileName.TabIndex = 11;
         // 
         // _btnBrowse
         // 
         this._btnBrowse.Location = new System.Drawing.Point(455, 231);
         this._btnBrowse.Name = "_btnBrowse";
         this._btnBrowse.Size = new System.Drawing.Size(75, 23);
         this._btnBrowse.TabIndex = 12;
         this._btnBrowse.Text = "&Browse";
         this._btnBrowse.UseVisualStyleBackColor = true;
         this._btnBrowse.Click += new System.EventHandler(this._btnBrowse_Click);
         // 
         // _btnSave
         // 
         this._btnSave.Location = new System.Drawing.Point(375, 263);
         this._btnSave.Name = "_btnSave";
         this._btnSave.Size = new System.Drawing.Size(75, 23);
         this._btnSave.TabIndex = 13;
         this._btnSave.Text = "&Save";
         this._btnSave.UseVisualStyleBackColor = true;
         this._btnSave.Click += new System.EventHandler(this._btnSave_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(455, 263);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(75, 23);
         this._btnCancel.TabIndex = 14;
         this._btnCancel.Text = "&Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // _lblBPP
         // 
         this._lblBPP.AutoSize = true;
         this._lblBPP.Location = new System.Drawing.Point(5, 268);
         this._lblBPP.Name = "_lblBPP";
         this._lblBPP.Size = new System.Drawing.Size(28, 13);
         this._lblBPP.TabIndex = 15;
         this._lblBPP.Text = "BP&P";
         // 
         // _cbBPP
         // 
         this._cbBPP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cbBPP.FormattingEnabled = true;
         this._cbBPP.Location = new System.Drawing.Point(34, 265);
         this._cbBPP.Name = "_cbBPP";
         this._cbBPP.Size = new System.Drawing.Size(43, 21);
         this._cbBPP.TabIndex = 16;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(86, 268);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(72, 13);
         this.label1.TabIndex = 17;
         this.label1.Text = "&Quality Factor";
         // 
         // _cbQualityFactor
         // 
         this._cbQualityFactor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cbQualityFactor.FormattingEnabled = true;
         this._cbQualityFactor.Location = new System.Drawing.Point(165, 265);
         this._cbQualityFactor.Name = "_cbQualityFactor";
         this._cbQualityFactor.Size = new System.Drawing.Size(77, 21);
         this._cbQualityFactor.TabIndex = 34;
         // 
         // SaveList
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(534, 293);
         this.Controls.Add(this._cbQualityFactor);
         this.Controls.Add(this.label1);
         this.Controls.Add(this._cbBPP);
         this.Controls.Add(this._lblBPP);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnSave);
         this.Controls.Add(this._btnBrowse);
         this.Controls.Add(this._txtFileName);
         this.Controls.Add(this._lblFileName);
         this.Controls.Add(this._btnDown);
         this.Controls.Add(this._btnUp);
         this.Controls.Add(this._btnRemoveAll);
         this.Controls.Add(this._btnAddAll);
         this.Controls.Add(this._btnRemove);
         this.Controls.Add(this._btnAdd);
         this.Controls.Add(this._lstSelectedImages);
         this.Controls.Add(this._lblSelectedImages);
         this.Controls.Add(this._lstAvailableImages);
         this.Controls.Add(this._lblAvailableImages);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "SaveList";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Save List";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label _lblAvailableImages;
      private System.Windows.Forms.ListBox _lstAvailableImages;
      private System.Windows.Forms.ListBox _lstSelectedImages;
      private System.Windows.Forms.Label _lblSelectedImages;
      private System.Windows.Forms.Button _btnAdd;
      private System.Windows.Forms.Button _btnRemove;
      private System.Windows.Forms.Button _btnAddAll;
      private System.Windows.Forms.Button _btnRemoveAll;
      private System.Windows.Forms.Button _btnUp;
      private System.Windows.Forms.Button _btnDown;
      private System.Windows.Forms.Label _lblFileName;
      private System.Windows.Forms.TextBox _txtFileName;
      private System.Windows.Forms.Button _btnBrowse;
      private System.Windows.Forms.Button _btnSave;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Label _lblBPP;
      private System.Windows.Forms.ComboBox _cbBPP;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.ComboBox _cbQualityFactor;
   }
}