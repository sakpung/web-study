namespace CSMasterFormsEditor.UI
{
   partial class MasterFormsWizard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MasterFormsWizard));
            this._tbMain = new System.Windows.Forms.TabControl();
            this._tbAboutDemo = new System.Windows.Forms.TabPage();
            this._lblLink = new System.Windows.Forms.LinkLabel();
            this._lblAboutDemo = new System.Windows.Forms.Label();
            this._btnNextAbout = new System.Windows.Forms.Button();
            this._tbOptions = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._btnPrevOptions = new System.Windows.Forms.Button();
            this._btnNext = new System.Windows.Forms.Button();
            this._rdLoad = new System.Windows.Forms.RadioButton();
            this._rdCreate = new System.Windows.Forms.RadioButton();
            this._tbCreate = new System.Windows.Forms.TabPage();
            this._txtMasterFormsName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._btnMasterDirectory = new System.Windows.Forms.Button();
            this._btnPrevCreate = new System.Windows.Forms.Button();
            this._txtMasterFormsDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._btnNextCreate = new System.Windows.Forms.Button();
            this._tbAddPage = new System.Windows.Forms.TabPage();
            this._btnAcquirePage = new System.Windows.Forms.Button();
            this._txtPagePath = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._lblImagePath = new System.Windows.Forms.Label();
            this._btnPrevAddPage = new System.Windows.Forms.Button();
            this._rdFromScanner = new System.Windows.Forms.RadioButton();
            this._btnFinishCreate = new System.Windows.Forms.Button();
            this._rdFromDisk = new System.Windows.Forms.RadioButton();
            this._btnBrowsePage = new System.Windows.Forms.Button();
            this._tbLoad = new System.Windows.Forms.TabPage();
            this._btnBrowseMaster = new System.Windows.Forms.Button();
            this._txtMasterFormsPath = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this._btnPrevLoad = new System.Windows.Forms.Button();
            this._btnFinishLoad = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this._rbOmr = new System.Windows.Forms.RadioButton();
            this._rbIDCard = new System.Windows.Forms.RadioButton();
            this._rbNormal = new System.Windows.Forms.RadioButton();
            this._tbMain.SuspendLayout();
            this._tbAboutDemo.SuspendLayout();
            this._tbOptions.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this._tbCreate.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this._tbAddPage.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this._tbLoad.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tbMain
            // 
            this._tbMain.Controls.Add(this._tbAboutDemo);
            this._tbMain.Controls.Add(this._tbOptions);
            this._tbMain.Controls.Add(this._tbCreate);
            this._tbMain.Controls.Add(this._tbAddPage);
            this._tbMain.Controls.Add(this._tbLoad);
            this._tbMain.Location = new System.Drawing.Point(-4, -3);
            this._tbMain.Name = "_tbMain";
            this._tbMain.SelectedIndex = 0;
            this._tbMain.Size = new System.Drawing.Size(475, 215);
            this._tbMain.TabIndex = 0;
            // 
            // _tbAboutDemo
            // 
            this._tbAboutDemo.Controls.Add(this._lblLink);
            this._tbAboutDemo.Controls.Add(this._lblAboutDemo);
            this._tbAboutDemo.Controls.Add(this._btnNextAbout);
            this._tbAboutDemo.Location = new System.Drawing.Point(4, 22);
            this._tbAboutDemo.Name = "_tbAboutDemo";
            this._tbAboutDemo.Padding = new System.Windows.Forms.Padding(3);
            this._tbAboutDemo.Size = new System.Drawing.Size(467, 189);
            this._tbAboutDemo.TabIndex = 4;
            this._tbAboutDemo.Text = "About Demo";
            this._tbAboutDemo.UseVisualStyleBackColor = true;
            // 
            // _lblLink
            // 
            this._lblLink.AutoSize = true;
            this._lblLink.Location = new System.Drawing.Point(93, 137);
            this._lblLink.Name = "_lblLink";
            this._lblLink.Size = new System.Drawing.Size(257, 13);
            this._lblLink.TabIndex = 1;
            this._lblLink.TabStop = true;
            this._lblLink.Text = "How to Use LEADTOOLS Master Forms Editor Demo";
            this._lblLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._lblLink_LinkClicked);
            // 
            // _lblAboutDemo
            // 
            this._lblAboutDemo.Location = new System.Drawing.Point(20, 31);
            this._lblAboutDemo.Name = "_lblAboutDemo";
            this._lblAboutDemo.Size = new System.Drawing.Size(427, 97);
            this._lblAboutDemo.TabIndex = 0;
            this._lblAboutDemo.Text = resources.GetString("_lblAboutDemo.Text");
            // 
            // _btnNextAbout
            // 
            this._btnNextAbout.Location = new System.Drawing.Point(376, 160);
            this._btnNextAbout.Name = "_btnNextAbout";
            this._btnNextAbout.Size = new System.Drawing.Size(88, 23);
            this._btnNextAbout.TabIndex = 2;
            this._btnNextAbout.Text = "&Next";
            this._btnNextAbout.UseVisualStyleBackColor = true;
            this._btnNextAbout.Click += new System.EventHandler(this._btnNextAbout_Click);
            // 
            // _tbOptions
            // 
            this._tbOptions.Controls.Add(this.groupBox1);
            this._tbOptions.Location = new System.Drawing.Point(4, 22);
            this._tbOptions.Name = "_tbOptions";
            this._tbOptions.Padding = new System.Windows.Forms.Padding(3);
            this._tbOptions.Size = new System.Drawing.Size(467, 189);
            this._tbOptions.TabIndex = 0;
            this._tbOptions.Text = "Master forms options";
            this._tbOptions.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._btnPrevOptions);
            this.groupBox1.Controls.Add(this._btnNext);
            this.groupBox1.Controls.Add(this._rdLoad);
            this.groupBox1.Controls.Add(this._rdCreate);
            this.groupBox1.Location = new System.Drawing.Point(13, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(454, 166);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Master Forms";
            // 
            // _btnPrevOptions
            // 
            this._btnPrevOptions.Location = new System.Drawing.Point(269, 133);
            this._btnPrevOptions.Name = "_btnPrevOptions";
            this._btnPrevOptions.Size = new System.Drawing.Size(88, 23);
            this._btnPrevOptions.TabIndex = 5;
            this._btnPrevOptions.Text = "&Previous";
            this._btnPrevOptions.UseVisualStyleBackColor = true;
            this._btnPrevOptions.Click += new System.EventHandler(this._btnPrevOptions_Click);
            // 
            // _btnNext
            // 
            this._btnNext.Location = new System.Drawing.Point(363, 133);
            this._btnNext.Name = "_btnNext";
            this._btnNext.Size = new System.Drawing.Size(88, 23);
            this._btnNext.TabIndex = 0;
            this._btnNext.Text = "&Next";
            this._btnNext.UseVisualStyleBackColor = true;
            this._btnNext.Click += new System.EventHandler(this._btnNext_Click);
            // 
            // _rdLoad
            // 
            this._rdLoad.AutoSize = true;
            this._rdLoad.Location = new System.Drawing.Point(15, 85);
            this._rdLoad.Name = "_rdLoad";
            this._rdLoad.Size = new System.Drawing.Size(184, 17);
            this._rdLoad.TabIndex = 4;
            this._rdLoad.Text = "Load/Edit existing master form set";
            this._rdLoad.UseVisualStyleBackColor = true;
            // 
            // _rdCreate
            // 
            this._rdCreate.AutoSize = true;
            this._rdCreate.Checked = true;
            this._rdCreate.Location = new System.Drawing.Point(15, 54);
            this._rdCreate.Name = "_rdCreate";
            this._rdCreate.Size = new System.Drawing.Size(162, 17);
            this._rdCreate.TabIndex = 3;
            this._rdCreate.TabStop = true;
            this._rdCreate.Text = "Create a new master form set";
            this._rdCreate.UseVisualStyleBackColor = true;
            // 
            // _tbCreate
            // 
            this._tbCreate.Controls.Add(this._txtMasterFormsName);
            this._tbCreate.Controls.Add(this.groupBox2);
            this._tbCreate.Location = new System.Drawing.Point(4, 22);
            this._tbCreate.Name = "_tbCreate";
            this._tbCreate.Padding = new System.Windows.Forms.Padding(3);
            this._tbCreate.Size = new System.Drawing.Size(467, 189);
            this._tbCreate.TabIndex = 1;
            this._tbCreate.Text = "Create Master Form";
            this._tbCreate.UseVisualStyleBackColor = true;
            // 
            // _txtMasterFormsName
            // 
            this._txtMasterFormsName.Location = new System.Drawing.Point(129, 75);
            this._txtMasterFormsName.Name = "_txtMasterFormsName";
            this._txtMasterFormsName.Size = new System.Drawing.Size(331, 20);
            this._txtMasterFormsName.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._btnMasterDirectory);
            this.groupBox2.Controls.Add(this._btnPrevCreate);
            this.groupBox2.Controls.Add(this._txtMasterFormsDirectory);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this._btnNextCreate);
            this.groupBox2.Location = new System.Drawing.Point(13, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(454, 166);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Create Master Form";
            // 
            // _btnMasterDirectory
            // 
            this._btnMasterDirectory.Location = new System.Drawing.Point(421, 94);
            this._btnMasterDirectory.Name = "_btnMasterDirectory";
            this._btnMasterDirectory.Size = new System.Drawing.Size(27, 20);
            this._btnMasterDirectory.TabIndex = 5;
            this._btnMasterDirectory.Text = "...";
            this._btnMasterDirectory.UseVisualStyleBackColor = true;
            this._btnMasterDirectory.Click += new System.EventHandler(this._btnMasterDirectory_Click);
            // 
            // _btnPrevCreate
            // 
            this._btnPrevCreate.Location = new System.Drawing.Point(269, 133);
            this._btnPrevCreate.Name = "_btnPrevCreate";
            this._btnPrevCreate.Size = new System.Drawing.Size(88, 23);
            this._btnPrevCreate.TabIndex = 6;
            this._btnPrevCreate.Text = "&Previous";
            this._btnPrevCreate.UseVisualStyleBackColor = true;
            this._btnPrevCreate.Click += new System.EventHandler(this._btnPrevCreate_Click);
            // 
            // _txtMasterFormsDirectory
            // 
            this._txtMasterFormsDirectory.Location = new System.Drawing.Point(116, 94);
            this._txtMasterFormsDirectory.Name = "_txtMasterFormsDirectory";
            this._txtMasterFormsDirectory.Size = new System.Drawing.Size(298, 20);
            this._txtMasterFormsDirectory.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Master Forms Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Save To";
            // 
            // _btnNextCreate
            // 
            this._btnNextCreate.Location = new System.Drawing.Point(363, 133);
            this._btnNextCreate.Name = "_btnNextCreate";
            this._btnNextCreate.Size = new System.Drawing.Size(88, 23);
            this._btnNextCreate.TabIndex = 2;
            this._btnNextCreate.Text = "&Next";
            this._btnNextCreate.UseVisualStyleBackColor = true;
            this._btnNextCreate.Click += new System.EventHandler(this._btnNextCreate_Click);
            // 
            // _tbAddPage
            // 
            this._tbAddPage.Controls.Add(this._btnAcquirePage);
            this._tbAddPage.Controls.Add(this._txtPagePath);
            this._tbAddPage.Controls.Add(this.groupBox3);
            this._tbAddPage.Location = new System.Drawing.Point(4, 22);
            this._tbAddPage.Name = "_tbAddPage";
            this._tbAddPage.Size = new System.Drawing.Size(467, 189);
            this._tbAddPage.TabIndex = 3;
            this._tbAddPage.Text = "Add Page";
            this._tbAddPage.UseVisualStyleBackColor = true;
            // 
            // _btnAcquirePage
            // 
            this._btnAcquirePage.Location = new System.Drawing.Point(150, 124);
            this._btnAcquirePage.Name = "_btnAcquirePage";
            this._btnAcquirePage.Size = new System.Drawing.Size(179, 21);
            this._btnAcquirePage.TabIndex = 12;
            this._btnAcquirePage.Text = "Acquire Page";
            this._btnAcquirePage.UseVisualStyleBackColor = true;
            this._btnAcquirePage.Visible = false;
            this._btnAcquirePage.Click += new System.EventHandler(this._btnAcquirePage_Click);
            // 
            // _txtPagePath
            // 
            this._txtPagePath.Location = new System.Drawing.Point(87, 125);
            this._txtPagePath.Name = "_txtPagePath";
            this._txtPagePath.Size = new System.Drawing.Size(340, 20);
            this._txtPagePath.TabIndex = 6;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Controls.Add(this._lblImagePath);
            this.groupBox3.Controls.Add(this._btnPrevAddPage);
            this.groupBox3.Controls.Add(this._rdFromScanner);
            this.groupBox3.Controls.Add(this._btnFinishCreate);
            this.groupBox3.Controls.Add(this._rdFromDisk);
            this.groupBox3.Controls.Add(this._btnBrowsePage);
            this.groupBox3.Location = new System.Drawing.Point(13, 27);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(454, 166);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Add Page";
            // 
            // _lblImagePath
            // 
            this._lblImagePath.AutoSize = true;
            this._lblImagePath.Location = new System.Drawing.Point(6, 101);
            this._lblImagePath.Name = "_lblImagePath";
            this._lblImagePath.Size = new System.Drawing.Size(61, 13);
            this._lblImagePath.TabIndex = 13;
            this._lblImagePath.Text = "Image Path";
            // 
            // _btnPrevAddPage
            // 
            this._btnPrevAddPage.Location = new System.Drawing.Point(269, 133);
            this._btnPrevAddPage.Name = "_btnPrevAddPage";
            this._btnPrevAddPage.Size = new System.Drawing.Size(88, 23);
            this._btnPrevAddPage.TabIndex = 14;
            this._btnPrevAddPage.Text = "&Previous";
            this._btnPrevAddPage.UseVisualStyleBackColor = true;
            this._btnPrevAddPage.Click += new System.EventHandler(this._btnPrevAddPage_Click);
            // 
            // _rdFromScanner
            // 
            this._rdFromScanner.AutoSize = true;
            this._rdFromScanner.Location = new System.Drawing.Point(54, 58);
            this._rdFromScanner.Name = "_rdFromScanner";
            this._rdFromScanner.Size = new System.Drawing.Size(91, 17);
            this._rdFromScanner.TabIndex = 8;
            this._rdFromScanner.Text = "From Scanner";
            this._rdFromScanner.UseVisualStyleBackColor = true;
            this._rdFromScanner.CheckedChanged += new System.EventHandler(this._rdFromScanner_CheckedChanged);
            // 
            // _btnFinishCreate
            // 
            this._btnFinishCreate.Location = new System.Drawing.Point(363, 133);
            this._btnFinishCreate.Name = "_btnFinishCreate";
            this._btnFinishCreate.Size = new System.Drawing.Size(88, 23);
            this._btnFinishCreate.TabIndex = 11;
            this._btnFinishCreate.Text = "&Finish";
            this._btnFinishCreate.UseVisualStyleBackColor = true;
            this._btnFinishCreate.Click += new System.EventHandler(this._btnFinishCreate_Click);
            // 
            // _rdFromDisk
            // 
            this._rdFromDisk.AutoSize = true;
            this._rdFromDisk.Checked = true;
            this._rdFromDisk.Location = new System.Drawing.Point(54, 19);
            this._rdFromDisk.Name = "_rdFromDisk";
            this._rdFromDisk.Size = new System.Drawing.Size(72, 17);
            this._rdFromDisk.TabIndex = 7;
            this._rdFromDisk.TabStop = true;
            this._rdFromDisk.Text = "From Disk";
            this._rdFromDisk.UseVisualStyleBackColor = true;
            this._rdFromDisk.CheckedChanged += new System.EventHandler(this._rdFromDisk_CheckedChanged);
            // 
            // _btnBrowsePage
            // 
            this._btnBrowsePage.Location = new System.Drawing.Point(421, 97);
            this._btnBrowsePage.Name = "_btnBrowsePage";
            this._btnBrowsePage.Size = new System.Drawing.Size(27, 20);
            this._btnBrowsePage.TabIndex = 10;
            this._btnBrowsePage.Text = "...";
            this._btnBrowsePage.UseVisualStyleBackColor = true;
            this._btnBrowsePage.Click += new System.EventHandler(this._btnBrowsePage_Click);
            // 
            // _tbLoad
            // 
            this._tbLoad.Controls.Add(this._btnBrowseMaster);
            this._tbLoad.Controls.Add(this._txtMasterFormsPath);
            this._tbLoad.Controls.Add(this.groupBox4);
            this._tbLoad.Location = new System.Drawing.Point(4, 22);
            this._tbLoad.Name = "_tbLoad";
            this._tbLoad.Size = new System.Drawing.Size(467, 189);
            this._tbLoad.TabIndex = 2;
            this._tbLoad.Text = "Load Master Form";
            this._tbLoad.UseVisualStyleBackColor = true;
            // 
            // _btnBrowseMaster
            // 
            this._btnBrowseMaster.Location = new System.Drawing.Point(434, 83);
            this._btnBrowseMaster.Name = "_btnBrowseMaster";
            this._btnBrowseMaster.Size = new System.Drawing.Size(27, 20);
            this._btnBrowseMaster.TabIndex = 1;
            this._btnBrowseMaster.Text = "...";
            this._btnBrowseMaster.UseVisualStyleBackColor = true;
            this._btnBrowseMaster.Click += new System.EventHandler(this._btnBrowse_Click);
            // 
            // _txtMasterFormsPath
            // 
            this._txtMasterFormsPath.Location = new System.Drawing.Point(122, 83);
            this._txtMasterFormsPath.Name = "_txtMasterFormsPath";
            this._txtMasterFormsPath.Size = new System.Drawing.Size(306, 20);
            this._txtMasterFormsPath.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this._btnPrevLoad);
            this.groupBox4.Controls.Add(this._btnFinishLoad);
            this.groupBox4.Location = new System.Drawing.Point(13, 27);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(454, 166);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Load Master Form";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Master Forms Path";
            // 
            // _btnPrevLoad
            // 
            this._btnPrevLoad.Location = new System.Drawing.Point(269, 133);
            this._btnPrevLoad.Name = "_btnPrevLoad";
            this._btnPrevLoad.Size = new System.Drawing.Size(88, 23);
            this._btnPrevLoad.TabIndex = 4;
            this._btnPrevLoad.Text = "&Previous";
            this._btnPrevLoad.UseVisualStyleBackColor = true;
            this._btnPrevLoad.Click += new System.EventHandler(this._btnPrevLoad_Click);
            // 
            // _btnFinishLoad
            // 
            this._btnFinishLoad.Location = new System.Drawing.Point(363, 133);
            this._btnFinishLoad.Name = "_btnFinishLoad";
            this._btnFinishLoad.Size = new System.Drawing.Size(88, 23);
            this._btnFinishLoad.TabIndex = 2;
            this._btnFinishLoad.Text = "&Finish";
            this._btnFinishLoad.UseVisualStyleBackColor = true;
            this._btnFinishLoad.Click += new System.EventHandler(this._btnFinish_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this._rbOmr);
            this.groupBox5.Controls.Add(this._rbIDCard);
            this.groupBox5.Controls.Add(this._rbNormal);
            this.groupBox5.Location = new System.Drawing.Point(195, 19);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(253, 44);
            this.groupBox5.TabIndex = 15;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Page Type";
            // 
            // _rbOmr
            // 
            this._rbOmr.AutoSize = true;
            this._rbOmr.Location = new System.Drawing.Point(170, 19);
            this._rbOmr.Name = "_rbOmr";
            this._rbOmr.Size = new System.Drawing.Size(44, 17);
            this._rbOmr.TabIndex = 26;
            this._rbOmr.Text = "Omr";
            this._rbOmr.UseVisualStyleBackColor = true;
            // 
            // _rbIDCard
            // 
            this._rbIDCard.AutoSize = true;
            this._rbIDCard.Location = new System.Drawing.Point(87, 19);
            this._rbIDCard.Name = "_rbIDCard";
            this._rbIDCard.Size = new System.Drawing.Size(61, 17);
            this._rbIDCard.TabIndex = 25;
            this._rbIDCard.Text = "ID Card";
            this._rbIDCard.UseVisualStyleBackColor = true;
            // 
            // _rbNormal
            // 
            this._rbNormal.AutoSize = true;
            this._rbNormal.Checked = true;
            this._rbNormal.Location = new System.Drawing.Point(7, 19);
            this._rbNormal.Name = "_rbNormal";
            this._rbNormal.Size = new System.Drawing.Size(58, 17);
            this._rbNormal.TabIndex = 24;
            this._rbNormal.TabStop = true;
            this._rbNormal.Text = "Normal";
            this._rbNormal.UseVisualStyleBackColor = true;
            // 
            // MasterFormsWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 224);
            this.Controls.Add(this._tbMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MasterFormsWizard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LEADTOOLS Master Form Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MasterFormsWizard_FormClosing);
            this.Load += new System.EventHandler(this.MasterFormsWizard_Load);
            this._tbMain.ResumeLayout(false);
            this._tbAboutDemo.ResumeLayout(false);
            this._tbAboutDemo.PerformLayout();
            this._tbOptions.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this._tbCreate.ResumeLayout(false);
            this._tbCreate.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this._tbAddPage.ResumeLayout(false);
            this._tbAddPage.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this._tbLoad.ResumeLayout(false);
            this._tbLoad.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TabControl _tbMain;
      private System.Windows.Forms.TabPage _tbOptions;
      private System.Windows.Forms.TabPage _tbCreate;
      private System.Windows.Forms.Button _btnNext;
      private System.Windows.Forms.RadioButton _rdLoad;
      private System.Windows.Forms.RadioButton _rdCreate;
      private System.Windows.Forms.TabPage _tbLoad;
      private System.Windows.Forms.Button _btnFinishLoad;
      private System.Windows.Forms.Button _btnBrowseMaster;
      private System.Windows.Forms.TextBox _txtMasterFormsPath;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox _txtMasterFormsName;
      private System.Windows.Forms.Button _btnNextCreate;
      private System.Windows.Forms.TabPage _tbAddPage;
      private System.Windows.Forms.Button _btnFinishCreate;
      private System.Windows.Forms.Button _btnBrowsePage;
      private System.Windows.Forms.TextBox _txtPagePath;
      private System.Windows.Forms.RadioButton _rdFromScanner;
      private System.Windows.Forms.RadioButton _rdFromDisk;
      private System.Windows.Forms.Button _btnAcquirePage;
      private System.Windows.Forms.Button _btnMasterDirectory;
      private System.Windows.Forms.TextBox _txtMasterFormsDirectory;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label _lblImagePath;
      private System.Windows.Forms.Button _btnPrevCreate;
      private System.Windows.Forms.Button _btnPrevAddPage;
      private System.Windows.Forms.Button _btnPrevLoad;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.GroupBox groupBox3;
      private System.Windows.Forms.GroupBox groupBox4;
      private System.Windows.Forms.TabPage _tbAboutDemo;
      private System.Windows.Forms.LinkLabel _lblLink;
      private System.Windows.Forms.Label _lblAboutDemo;
      private System.Windows.Forms.Button _btnNextAbout;
      private System.Windows.Forms.Button _btnPrevOptions;
      private System.Windows.Forms.GroupBox groupBox5;
      private System.Windows.Forms.RadioButton _rbOmr;
      private System.Windows.Forms.RadioButton _rbIDCard;
      private System.Windows.Forms.RadioButton _rbNormal;
   }
}