namespace JPXDemo
{
   partial class SaveComposite
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveComposite));
         this._lblAvailableColorImages = new System.Windows.Forms.Label();
         this._cbAvailableColorImages = new System.Windows.Forms.ComboBox();
         this._grpOpacity = new System.Windows.Forms.GroupBox();
         this._rbPreopacity = new System.Windows.Forms.RadioButton();
         this._rbOpacity = new System.Windows.Forms.RadioButton();
         this._cbUseOpacity = new System.Windows.Forms.CheckBox();
         this._cbAvailableOpacityImages = new System.Windows.Forms.ComboBox();
         this._lblAvailableOpacityImages = new System.Windows.Forms.Label();
         this._btnAdd = new System.Windows.Forms.Button();
         this._lstColorImages = new System.Windows.Forms.ListBox();
         this._lblColorImages = new System.Windows.Forms.Label();
         this._lblOpacityImages = new System.Windows.Forms.Label();
         this._lstOpacityImages = new System.Windows.Forms.ListBox();
         this._lblPreOpacotyImages = new System.Windows.Forms.Label();
         this._lstPreOpacityImages = new System.Windows.Forms.ListBox();
         this._btnMoveUp = new System.Windows.Forms.Button();
         this._btnMoveDown = new System.Windows.Forms.Button();
         this._btnDelete = new System.Windows.Forms.Button();
         this._btnUp = new System.Windows.Forms.Button();
         this._btnDown = new System.Windows.Forms.Button();
         this.label1 = new System.Windows.Forms.Label();
         this._cbBPP = new System.Windows.Forms.ComboBox();
         this._lblBPP = new System.Windows.Forms.Label();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnSave = new System.Windows.Forms.Button();
         this._btnBrowse = new System.Windows.Forms.Button();
         this._txtFileName = new System.Windows.Forms.TextBox();
         this._lblFileName = new System.Windows.Forms.Label();
         this._cbQualityFactor = new System.Windows.Forms.ComboBox();
         this._grpOpacity.SuspendLayout();
         this.SuspendLayout();
         // 
         // _lblAvailableColorImages
         // 
         this._lblAvailableColorImages.AutoSize = true;
         this._lblAvailableColorImages.Location = new System.Drawing.Point(10, 10);
         this._lblAvailableColorImages.Name = "_lblAvailableColorImages";
         this._lblAvailableColorImages.Size = new System.Drawing.Size(114, 13);
         this._lblAvailableColorImages.TabIndex = 0;
         this._lblAvailableColorImages.Text = "Available Color Images";
         // 
         // _cbAvailableColorImages
         // 
         this._cbAvailableColorImages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cbAvailableColorImages.FormattingEnabled = true;
         this._cbAvailableColorImages.Location = new System.Drawing.Point(13, 31);
         this._cbAvailableColorImages.Name = "_cbAvailableColorImages";
         this._cbAvailableColorImages.Size = new System.Drawing.Size(181, 21);
         this._cbAvailableColorImages.TabIndex = 1;
         // 
         // _grpOpacity
         // 
         this._grpOpacity.Controls.Add(this._rbPreopacity);
         this._grpOpacity.Controls.Add(this._rbOpacity);
         this._grpOpacity.Controls.Add(this._cbUseOpacity);
         this._grpOpacity.Location = new System.Drawing.Point(408, 7);
         this._grpOpacity.Name = "_grpOpacity";
         this._grpOpacity.Size = new System.Drawing.Size(120, 75);
         this._grpOpacity.TabIndex = 2;
         this._grpOpacity.TabStop = false;
         // 
         // _rbPreopacity
         // 
         this._rbPreopacity.AutoSize = true;
         this._rbPreopacity.Location = new System.Drawing.Point(20, 48);
         this._rbPreopacity.Name = "_rbPreopacity";
         this._rbPreopacity.Size = new System.Drawing.Size(77, 17);
         this._rbPreopacity.TabIndex = 2;
         this._rbPreopacity.TabStop = true;
         this._rbPreopacity.Text = "PreOpacity";
         this._rbPreopacity.UseVisualStyleBackColor = true;
         // 
         // _rbOpacity
         // 
         this._rbOpacity.AutoSize = true;
         this._rbOpacity.Location = new System.Drawing.Point(20, 23);
         this._rbOpacity.Name = "_rbOpacity";
         this._rbOpacity.Size = new System.Drawing.Size(58, 17);
         this._rbOpacity.TabIndex = 1;
         this._rbOpacity.TabStop = true;
         this._rbOpacity.Text = "&Opaciy";
         this._rbOpacity.UseVisualStyleBackColor = true;
         // 
         // _cbUseOpacity
         // 
         this._cbUseOpacity.AutoSize = true;
         this._cbUseOpacity.Location = new System.Drawing.Point(6, 0);
         this._cbUseOpacity.Name = "_cbUseOpacity";
         this._cbUseOpacity.Size = new System.Drawing.Size(84, 17);
         this._cbUseOpacity.TabIndex = 0;
         this._cbUseOpacity.Text = "&Use Opacity";
         this._cbUseOpacity.UseVisualStyleBackColor = true;
         this._cbUseOpacity.CheckedChanged += new System.EventHandler(this._cbUseOpacity_CheckedChanged);
         // 
         // _cbAvailableOpacityImages
         // 
         this._cbAvailableOpacityImages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cbAvailableOpacityImages.FormattingEnabled = true;
         this._cbAvailableOpacityImages.Location = new System.Drawing.Point(214, 31);
         this._cbAvailableOpacityImages.Name = "_cbAvailableOpacityImages";
         this._cbAvailableOpacityImages.Size = new System.Drawing.Size(181, 21);
         this._cbAvailableOpacityImages.TabIndex = 4;
         // 
         // _lblAvailableOpacityImages
         // 
         this._lblAvailableOpacityImages.AutoSize = true;
         this._lblAvailableOpacityImages.Location = new System.Drawing.Point(211, 10);
         this._lblAvailableOpacityImages.Name = "_lblAvailableOpacityImages";
         this._lblAvailableOpacityImages.Size = new System.Drawing.Size(126, 13);
         this._lblAvailableOpacityImages.TabIndex = 3;
         this._lblAvailableOpacityImages.Text = "Available Opacity Images";
         // 
         // _btnAdd
         // 
         this._btnAdd.Location = new System.Drawing.Point(320, 59);
         this._btnAdd.Name = "_btnAdd";
         this._btnAdd.Size = new System.Drawing.Size(75, 23);
         this._btnAdd.TabIndex = 5;
         this._btnAdd.Text = "&Add";
         this._btnAdd.UseVisualStyleBackColor = true;
         this._btnAdd.Click += new System.EventHandler(this._btnAdd_Click);
         // 
         // _lstColorImages
         // 
         this._lstColorImages.FormattingEnabled = true;
         this._lstColorImages.Location = new System.Drawing.Point(7, 108);
         this._lstColorImages.Name = "_lstColorImages";
         this._lstColorImages.Size = new System.Drawing.Size(149, 147);
         this._lstColorImages.TabIndex = 6;
         this._lstColorImages.Click += new System.EventHandler(this._lst_Click);
         // 
         // _lblColorImages
         // 
         this._lblColorImages.AutoSize = true;
         this._lblColorImages.Location = new System.Drawing.Point(43, 90);
         this._lblColorImages.Name = "_lblColorImages";
         this._lblColorImages.Size = new System.Drawing.Size(68, 13);
         this._lblColorImages.TabIndex = 7;
         this._lblColorImages.Text = "Color Images";
         // 
         // _lblOpacityImages
         // 
         this._lblOpacityImages.AutoSize = true;
         this._lblOpacityImages.Location = new System.Drawing.Point(186, 90);
         this._lblOpacityImages.Name = "_lblOpacityImages";
         this._lblOpacityImages.Size = new System.Drawing.Size(80, 13);
         this._lblOpacityImages.TabIndex = 9;
         this._lblOpacityImages.Text = "Opacity Images";
         // 
         // _lstOpacityImages
         // 
         this._lstOpacityImages.FormattingEnabled = true;
         this._lstOpacityImages.Location = new System.Drawing.Point(156, 108);
         this._lstOpacityImages.Name = "_lstOpacityImages";
         this._lstOpacityImages.Size = new System.Drawing.Size(149, 147);
         this._lstOpacityImages.TabIndex = 8;
         this._lstOpacityImages.Click += new System.EventHandler(this._lst_Click);
         // 
         // _lblPreOpacotyImages
         // 
         this._lblPreOpacotyImages.AutoSize = true;
         this._lblPreOpacotyImages.Location = new System.Drawing.Point(329, 90);
         this._lblPreOpacotyImages.Name = "_lblPreOpacotyImages";
         this._lblPreOpacotyImages.Size = new System.Drawing.Size(96, 13);
         this._lblPreOpacotyImages.TabIndex = 11;
         this._lblPreOpacotyImages.Text = "PreOpacity Images";
         // 
         // _lstPreOpacityImages
         // 
         this._lstPreOpacityImages.FormattingEnabled = true;
         this._lstPreOpacityImages.Location = new System.Drawing.Point(305, 108);
         this._lstPreOpacityImages.Name = "_lstPreOpacityImages";
         this._lstPreOpacityImages.Size = new System.Drawing.Size(149, 147);
         this._lstPreOpacityImages.TabIndex = 10;
         this._lstPreOpacityImages.Click += new System.EventHandler(this._lst_Click);
         // 
         // _btnMoveUp
         // 
         this._btnMoveUp.Location = new System.Drawing.Point(460, 108);
         this._btnMoveUp.Name = "_btnMoveUp";
         this._btnMoveUp.Size = new System.Drawing.Size(75, 23);
         this._btnMoveUp.TabIndex = 12;
         this._btnMoveUp.Text = "Move U&p";
         this._btnMoveUp.UseVisualStyleBackColor = true;
         this._btnMoveUp.Click += new System.EventHandler(this._btnMoveUp_Click);
         // 
         // _btnMoveDown
         // 
         this._btnMoveDown.Location = new System.Drawing.Point(460, 136);
         this._btnMoveDown.Name = "_btnMoveDown";
         this._btnMoveDown.Size = new System.Drawing.Size(75, 23);
         this._btnMoveDown.TabIndex = 13;
         this._btnMoveDown.Text = "Move D&own";
         this._btnMoveDown.UseVisualStyleBackColor = true;
         this._btnMoveDown.Click += new System.EventHandler(this._btnMoveDown_Click);
         // 
         // _btnDelete
         // 
         this._btnDelete.Location = new System.Drawing.Point(460, 165);
         this._btnDelete.Name = "_btnDelete";
         this._btnDelete.Size = new System.Drawing.Size(75, 23);
         this._btnDelete.TabIndex = 14;
         this._btnDelete.Text = "D&elete";
         this._btnDelete.UseVisualStyleBackColor = true;
         this._btnDelete.Click += new System.EventHandler(this._btnDelete_Click);
         // 
         // _btnUp
         // 
         this._btnUp.Image = ((System.Drawing.Image)(resources.GetObject("_btnUp.Image")));
         this._btnUp.Location = new System.Drawing.Point(473, 203);
         this._btnUp.Name = "_btnUp";
         this._btnUp.Size = new System.Drawing.Size(49, 23);
         this._btnUp.TabIndex = 15;
         this._btnUp.UseVisualStyleBackColor = true;
         this._btnUp.Click += new System.EventHandler(this._btnUp_Click);
         // 
         // _btnDown
         // 
         this._btnDown.Image = ((System.Drawing.Image)(resources.GetObject("_btnDown.Image")));
         this._btnDown.Location = new System.Drawing.Point(473, 232);
         this._btnDown.Name = "_btnDown";
         this._btnDown.Size = new System.Drawing.Size(49, 23);
         this._btnDown.TabIndex = 16;
         this._btnDown.UseVisualStyleBackColor = true;
         this._btnDown.Click += new System.EventHandler(this._btnDown_Click);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(86, 306);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(72, 13);
         this.label1.TabIndex = 29;
         this.label1.Text = "&Quality Factor";
         // 
         // _cbBPP
         // 
         this._cbBPP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cbBPP.FormattingEnabled = true;
         this._cbBPP.Location = new System.Drawing.Point(37, 303);
         this._cbBPP.Name = "_cbBPP";
         this._cbBPP.Size = new System.Drawing.Size(43, 21);
         this._cbBPP.TabIndex = 28;
         // 
         // _lblBPP
         // 
         this._lblBPP.AutoSize = true;
         this._lblBPP.Location = new System.Drawing.Point(3, 306);
         this._lblBPP.Name = "_lblBPP";
         this._lblBPP.Size = new System.Drawing.Size(28, 13);
         this._lblBPP.TabIndex = 27;
         this._lblBPP.Text = "BP&P";
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(461, 301);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(75, 23);
         this._btnCancel.TabIndex = 26;
         this._btnCancel.Text = "&Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // _btnSave
         // 
         this._btnSave.Location = new System.Drawing.Point(380, 301);
         this._btnSave.Name = "_btnSave";
         this._btnSave.Size = new System.Drawing.Size(75, 23);
         this._btnSave.TabIndex = 25;
         this._btnSave.Text = "&Save";
         this._btnSave.UseVisualStyleBackColor = true;
         this._btnSave.Click += new System.EventHandler(this._btnSave_Click);
         // 
         // _btnBrowse
         // 
         this._btnBrowse.Location = new System.Drawing.Point(461, 272);
         this._btnBrowse.Name = "_btnBrowse";
         this._btnBrowse.Size = new System.Drawing.Size(75, 23);
         this._btnBrowse.TabIndex = 24;
         this._btnBrowse.Text = "&Browse";
         this._btnBrowse.UseVisualStyleBackColor = true;
         this._btnBrowse.Click += new System.EventHandler(this._btnBrowse_Click);
         // 
         // _txtFileName
         // 
         this._txtFileName.Location = new System.Drawing.Point(8, 275);
         this._txtFileName.Name = "_txtFileName";
         this._txtFileName.ReadOnly = true;
         this._txtFileName.Size = new System.Drawing.Size(447, 20);
         this._txtFileName.TabIndex = 23;
         // 
         // _lblFileName
         // 
         this._lblFileName.AutoSize = true;
         this._lblFileName.Location = new System.Drawing.Point(5, 259);
         this._lblFileName.Name = "_lblFileName";
         this._lblFileName.Size = new System.Drawing.Size(54, 13);
         this._lblFileName.TabIndex = 22;
         this._lblFileName.Text = "File Name";
         // 
         // _cbQualityFactor
         // 
         this._cbQualityFactor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cbQualityFactor.FormattingEnabled = true;
         this._cbQualityFactor.Location = new System.Drawing.Point(156, 303);
         this._cbQualityFactor.Name = "_cbQualityFactor";
         this._cbQualityFactor.Size = new System.Drawing.Size(77, 21);
         this._cbQualityFactor.TabIndex = 33;
         // 
         // SaveComposite
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(542, 330);
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
         this.Controls.Add(this._btnDelete);
         this.Controls.Add(this._btnMoveDown);
         this.Controls.Add(this._btnMoveUp);
         this.Controls.Add(this._lblPreOpacotyImages);
         this.Controls.Add(this._lstPreOpacityImages);
         this.Controls.Add(this._lblOpacityImages);
         this.Controls.Add(this._lstOpacityImages);
         this.Controls.Add(this._lblColorImages);
         this.Controls.Add(this._lstColorImages);
         this.Controls.Add(this._btnAdd);
         this.Controls.Add(this._cbAvailableOpacityImages);
         this.Controls.Add(this._lblAvailableOpacityImages);
         this.Controls.Add(this._grpOpacity);
         this.Controls.Add(this._cbAvailableColorImages);
         this.Controls.Add(this._lblAvailableColorImages);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "SaveComposite";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "SaveComposite";
         this._grpOpacity.ResumeLayout(false);
         this._grpOpacity.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label _lblAvailableColorImages;
      private System.Windows.Forms.ComboBox _cbAvailableColorImages;
      private System.Windows.Forms.GroupBox _grpOpacity;
      private System.Windows.Forms.RadioButton _rbPreopacity;
      private System.Windows.Forms.RadioButton _rbOpacity;
      private System.Windows.Forms.CheckBox _cbUseOpacity;
      private System.Windows.Forms.ComboBox _cbAvailableOpacityImages;
      private System.Windows.Forms.Label _lblAvailableOpacityImages;
      private System.Windows.Forms.Button _btnAdd;
      private System.Windows.Forms.ListBox _lstColorImages;
      private System.Windows.Forms.Label _lblColorImages;
      private System.Windows.Forms.Label _lblOpacityImages;
      private System.Windows.Forms.ListBox _lstOpacityImages;
      private System.Windows.Forms.Label _lblPreOpacotyImages;
      private System.Windows.Forms.ListBox _lstPreOpacityImages;
      private System.Windows.Forms.Button _btnMoveUp;
      private System.Windows.Forms.Button _btnMoveDown;
      private System.Windows.Forms.Button _btnDelete;
      private System.Windows.Forms.Button _btnUp;
      private System.Windows.Forms.Button _btnDown;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.ComboBox _cbBPP;
      private System.Windows.Forms.Label _lblBPP;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnSave;
      private System.Windows.Forms.Button _btnBrowse;
      private System.Windows.Forms.TextBox _txtFileName;
      private System.Windows.Forms.Label _lblFileName;
      private System.Windows.Forms.ComboBox _cbQualityFactor;
   }
}