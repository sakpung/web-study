namespace FormsDemo
{
   partial class MainForm
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
         this._chImage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this._chOperation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this._chTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this._lvLastOperation = new System.Windows.Forms.ListView();
         this._txtMasterFormRespository = new System.Windows.Forms.TextBox();
         this._lblMasterFormRespository = new System.Windows.Forms.Label();
         this._btnBrowseMasterFormRespository = new System.Windows.Forms.Button();
         this.menuStrip1 = new System.Windows.Forms.MenuStrip();
         this._menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemLaunchMasterFormsEditor = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemRecognition = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemRecognizeScannedForms = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemRecognizeSingleForm = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemRecognizeMultipleForms = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemOptions = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemObjectManagers = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemOCRManager = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemBarcodeManager = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemDefaultManager = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemRecognizeFirstPageOnly = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemEngine = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemLanguages = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemComponents = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemHowto = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
         this._lblTimingInformation = new System.Windows.Forms.Label();
         this._lblFormName = new System.Windows.Forms.Label();
         this._lblStatus = new System.Windows.Forms.Label();
         this._pbProgress = new System.Windows.Forms.ProgressBar();
         this._btnCancel = new System.Windows.Forms.Button();
         this._rb_OCR = new System.Windows.Forms.RadioButton();
         this._rb_OCR_ICR = new System.Windows.Forms.RadioButton();
         this._rb_DL = new System.Windows.Forms.RadioButton();
         this._rb_Invoice = new System.Windows.Forms.RadioButton();
         this._rb_OMR = new System.Windows.Forms.RadioButton();
         this.menuStrip1.SuspendLayout();
         this.SuspendLayout();
         // 
         // _chImage
         // 
         this._chImage.Text = "Image File";
         this._chImage.Width = 117;
         // 
         // _chOperation
         // 
         this._chOperation.Text = "Operation";
         this._chOperation.Width = 199;
         // 
         // _chTime
         // 
         this._chTime.Text = "Time (seconds)";
         this._chTime.Width = 90;
         // 
         // _lvLastOperation
         // 
         this._lvLastOperation.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._chImage,
            this._chOperation,
            this._chTime});
         this._lvLastOperation.Location = new System.Drawing.Point(12, 241);
         this._lvLastOperation.Name = "_lvLastOperation";
         this._lvLastOperation.Size = new System.Drawing.Size(416, 158);
         this._lvLastOperation.TabIndex = 7;
         this._lvLastOperation.UseCompatibleStateImageBehavior = false;
         this._lvLastOperation.View = System.Windows.Forms.View.Details;
         // 
         // _txtMasterFormRespository
         // 
         this._txtMasterFormRespository.Location = new System.Drawing.Point(12, 69);
         this._txtMasterFormRespository.Name = "_txtMasterFormRespository";
         this._txtMasterFormRespository.ReadOnly = true;
         this._txtMasterFormRespository.Size = new System.Drawing.Size(416, 20);
         this._txtMasterFormRespository.TabIndex = 10;
         // 
         // _lblMasterFormRespository
         // 
         this._lblMasterFormRespository.AutoSize = true;
         this._lblMasterFormRespository.Location = new System.Drawing.Point(12, 40);
         this._lblMasterFormRespository.Name = "_lblMasterFormRespository";
         this._lblMasterFormRespository.Size = new System.Drawing.Size(123, 13);
         this._lblMasterFormRespository.TabIndex = 11;
         this._lblMasterFormRespository.Text = "Master Form Respository";
         // 
         // _btnBrowseMasterFormRespository
         // 
         this._btnBrowseMasterFormRespository.Location = new System.Drawing.Point(434, 68);
         this._btnBrowseMasterFormRespository.Name = "_btnBrowseMasterFormRespository";
         this._btnBrowseMasterFormRespository.Size = new System.Drawing.Size(37, 21);
         this._btnBrowseMasterFormRespository.TabIndex = 12;
         this._btnBrowseMasterFormRespository.Text = "...";
         this._btnBrowseMasterFormRespository.UseVisualStyleBackColor = true;
         this._btnBrowseMasterFormRespository.Click += new System.EventHandler(this._btnBrowseMasterFormRespository_Click);
         // 
         // menuStrip1
         // 
         this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuItemFile,
            this._menuItemRecognition,
            this._menuItemOptions,
            this._menuItemEngine,
            this._menuItemHelp});
         this.menuStrip1.Location = new System.Drawing.Point(0, 0);
         this.menuStrip1.Name = "menuStrip1";
         this.menuStrip1.Size = new System.Drawing.Size(487, 24);
         this.menuStrip1.TabIndex = 13;
         this.menuStrip1.Text = "menuStrip1";
         // 
         // _menuItemFile
         // 
         this._menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuItemLaunchMasterFormsEditor,
            this._menuItemExit});
         this._menuItemFile.Name = "_menuItemFile";
         this._menuItemFile.Size = new System.Drawing.Size(37, 20);
         this._menuItemFile.Text = "File";
         // 
         // _menuItemLaunchMasterFormsEditor
         // 
         this._menuItemLaunchMasterFormsEditor.Name = "_menuItemLaunchMasterFormsEditor";
         this._menuItemLaunchMasterFormsEditor.Size = new System.Drawing.Size(222, 22);
         this._menuItemLaunchMasterFormsEditor.Text = "Launch Master Forms Editor";
         this._menuItemLaunchMasterFormsEditor.Click += new System.EventHandler(this._menuItemLaunchMasterFormsEditor_Click);
         // 
         // _menuItemExit
         // 
         this._menuItemExit.Name = "_menuItemExit";
         this._menuItemExit.Size = new System.Drawing.Size(222, 22);
         this._menuItemExit.Text = "Exit";
         this._menuItemExit.Click += new System.EventHandler(this._menuItemExit_Click);
         // 
         // _menuItemRecognition
         // 
         this._menuItemRecognition.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuItemRecognizeScannedForms,
            this._menuItemRecognizeSingleForm,
            this._menuItemRecognizeMultipleForms});
         this._menuItemRecognition.Name = "_menuItemRecognition";
         this._menuItemRecognition.Size = new System.Drawing.Size(83, 20);
         this._menuItemRecognition.Text = "Recognition";
         // 
         // _menuItemRecognizeScannedForms
         // 
         this._menuItemRecognizeScannedForms.Name = "_menuItemRecognizeScannedForms";
         this._menuItemRecognizeScannedForms.Size = new System.Drawing.Size(212, 22);
         this._menuItemRecognizeScannedForms.Text = "Recognize Scanned Forms";
         this._menuItemRecognizeScannedForms.Click += new System.EventHandler(this._menuItemRecognizeScannedForms_Click);
         // 
         // _menuItemRecognizeSingleForm
         // 
         this._menuItemRecognizeSingleForm.Name = "_menuItemRecognizeSingleForm";
         this._menuItemRecognizeSingleForm.Size = new System.Drawing.Size(212, 22);
         this._menuItemRecognizeSingleForm.Text = "Recognize Single Form";
         this._menuItemRecognizeSingleForm.Click += new System.EventHandler(this._menuItemRecognizeSingleForm_Click);
         // 
         // _menuItemRecognizeMultipleForms
         // 
         this._menuItemRecognizeMultipleForms.Name = "_menuItemRecognizeMultipleForms";
         this._menuItemRecognizeMultipleForms.Size = new System.Drawing.Size(212, 22);
         this._menuItemRecognizeMultipleForms.Text = "Recognize Multiple Forms";
         this._menuItemRecognizeMultipleForms.Click += new System.EventHandler(this._menuItemRecognizeMultipleForms_Click);
         // 
         // _menuItemOptions
         // 
         this._menuItemOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuItemObjectManagers,
            this._menuItemRecognizeFirstPageOnly});
         this._menuItemOptions.Name = "_menuItemOptions";
         this._menuItemOptions.Size = new System.Drawing.Size(61, 20);
         this._menuItemOptions.Text = "Options";
         // 
         // _menuItemObjectManagers
         // 
         this._menuItemObjectManagers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuItemOCRManager,
            this._menuItemBarcodeManager,
            this._menuItemDefaultManager});
         this._menuItemObjectManagers.Name = "_menuItemObjectManagers";
         this._menuItemObjectManagers.Size = new System.Drawing.Size(210, 22);
         this._menuItemObjectManagers.Text = "Object Managers";
         // 
         // _menuItemOCRManager
         // 
         this._menuItemOCRManager.Checked = true;
         this._menuItemOCRManager.CheckOnClick = true;
         this._menuItemOCRManager.CheckState = System.Windows.Forms.CheckState.Checked;
         this._menuItemOCRManager.Name = "_menuItemOCRManager";
         this._menuItemOCRManager.Size = new System.Drawing.Size(205, 22);
         this._menuItemOCRManager.Text = "OCR Object Manager";
         this._menuItemOCRManager.Click += new System.EventHandler(this.RecognitionOptionsChanged);
         // 
         // _menuItemBarcodeManager
         // 
         this._menuItemBarcodeManager.CheckOnClick = true;
         this._menuItemBarcodeManager.Name = "_menuItemBarcodeManager";
         this._menuItemBarcodeManager.Size = new System.Drawing.Size(205, 22);
         this._menuItemBarcodeManager.Text = "Barcode Object Manager";
         this._menuItemBarcodeManager.Click += new System.EventHandler(this.RecognitionOptionsChanged);
         // 
         // _menuItemDefaultManager
         // 
         this._menuItemDefaultManager.CheckOnClick = true;
         this._menuItemDefaultManager.Name = "_menuItemDefaultManager";
         this._menuItemDefaultManager.Size = new System.Drawing.Size(205, 22);
         this._menuItemDefaultManager.Text = "Default Objects Manager";
         this._menuItemDefaultManager.Click += new System.EventHandler(this.RecognitionOptionsChanged);
         // 
         // _menuItemRecognizeFirstPageOnly
         // 
         this._menuItemRecognizeFirstPageOnly.Checked = true;
         this._menuItemRecognizeFirstPageOnly.CheckOnClick = true;
         this._menuItemRecognizeFirstPageOnly.CheckState = System.Windows.Forms.CheckState.Checked;
         this._menuItemRecognizeFirstPageOnly.Name = "_menuItemRecognizeFirstPageOnly";
         this._menuItemRecognizeFirstPageOnly.Size = new System.Drawing.Size(210, 22);
         this._menuItemRecognizeFirstPageOnly.Text = "Recognize First Page Only";
         this._menuItemRecognizeFirstPageOnly.Click += new System.EventHandler(this.RecognitionOptionsChanged);
         // 
         // _menuItemEngine
         // 
         this._menuItemEngine.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuItemLanguages,
            this._menuItemComponents});
         this._menuItemEngine.Name = "_menuItemEngine";
         this._menuItemEngine.Size = new System.Drawing.Size(55, 20);
         this._menuItemEngine.Text = "Engine";
         // 
         // _menuItemLanguages
         // 
         this._menuItemLanguages.Name = "_menuItemLanguages";
         this._menuItemLanguages.Size = new System.Drawing.Size(143, 22);
         this._menuItemLanguages.Text = "Languages";
         this._menuItemLanguages.Click += new System.EventHandler(this._menuItemLanguages_Click);
         // 
         // _menuItemComponents
         // 
         this._menuItemComponents.Name = "_menuItemComponents";
         this._menuItemComponents.Size = new System.Drawing.Size(143, 22);
         this._menuItemComponents.Text = "Components";
         this._menuItemComponents.Click += new System.EventHandler(this._menuItemComponents_Click);
         // 
         // _menuItemHelp
         // 
         this._menuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuItemHowto,
            this._menuItemAbout});
         this._menuItemHelp.Name = "_menuItemHelp";
         this._menuItemHelp.Size = new System.Drawing.Size(44, 20);
         this._menuItemHelp.Text = "Help";
         // 
         // _menuItemHowto
         // 
         this._menuItemHowto.Name = "_menuItemHowto";
         this._menuItemHowto.Size = new System.Drawing.Size(116, 22);
         this._menuItemHowto.Text = "How To";
         this._menuItemHowto.Click += new System.EventHandler(this._btnHowTo_Click);
         // 
         // _menuItemAbout
         // 
         this._menuItemAbout.Name = "_menuItemAbout";
         this._menuItemAbout.Size = new System.Drawing.Size(116, 22);
         this._menuItemAbout.Text = "About";
         this._menuItemAbout.Click += new System.EventHandler(this._menuItemAbout_Click);
         // 
         // _lblTimingInformation
         // 
         this._lblTimingInformation.AutoSize = true;
         this._lblTimingInformation.Location = new System.Drawing.Point(12, 210);
         this._lblTimingInformation.Name = "_lblTimingInformation";
         this._lblTimingInformation.Size = new System.Drawing.Size(93, 13);
         this._lblTimingInformation.TabIndex = 14;
         this._lblTimingInformation.Text = "Timing Information";
         // 
         // _lblFormName
         // 
         this._lblFormName.AutoSize = true;
         this._lblFormName.Location = new System.Drawing.Point(9, 420);
         this._lblFormName.Name = "_lblFormName";
         this._lblFormName.Size = new System.Drawing.Size(61, 13);
         this._lblFormName.TabIndex = 15;
         this._lblFormName.Text = "Form Name";
         // 
         // _lblStatus
         // 
         this._lblStatus.AutoSize = true;
         this._lblStatus.Location = new System.Drawing.Point(9, 450);
         this._lblStatus.Name = "_lblStatus";
         this._lblStatus.Size = new System.Drawing.Size(37, 13);
         this._lblStatus.TabIndex = 16;
         this._lblStatus.Text = "Status";
         // 
         // _pbProgress
         // 
         this._pbProgress.Location = new System.Drawing.Point(12, 482);
         this._pbProgress.Name = "_pbProgress";
         this._pbProgress.Size = new System.Drawing.Size(416, 23);
         this._pbProgress.TabIndex = 17;
         // 
         // _btnCancel
         // 
         this._btnCancel.Location = new System.Drawing.Point(12, 524);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(82, 26);
         this._btnCancel.TabIndex = 18;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
         // 
         // _rb_OCR
         // 
         this._rb_OCR.AutoSize = true;
         this._rb_OCR.Checked = true;
         this._rb_OCR.Location = new System.Drawing.Point(12, 95);
         this._rb_OCR.Name = "_rb_OCR";
         this._rb_OCR.Size = new System.Drawing.Size(42, 17);
         this._rb_OCR.TabIndex = 19;
         this._rb_OCR.TabStop = true;
         this._rb_OCR.Text = "Ocr";
         this._rb_OCR.UseVisualStyleBackColor = true;
         this._rb_OCR.CheckedChanged += new System.EventHandler(this._rb_Respository_CheckedChanged);
         // 
         // _rb_OCR_ICR
         // 
         this._rb_OCR_ICR.AutoSize = true;
         this._rb_OCR_ICR.Location = new System.Drawing.Point(12, 118);
         this._rb_OCR_ICR.Name = "_rb_OCR_ICR";
         this._rb_OCR_ICR.Size = new System.Drawing.Size(60, 17);
         this._rb_OCR_ICR.TabIndex = 20;
         this._rb_OCR_ICR.Text = "Ocr_Icr";
         this._rb_OCR_ICR.UseVisualStyleBackColor = true;
         this._rb_OCR_ICR.CheckedChanged += new System.EventHandler(this._rb_Respository_CheckedChanged);
         // 
         // _rb_DL
         // 
         this._rb_DL.AutoSize = true;
         this._rb_DL.Location = new System.Drawing.Point(12, 141);
         this._rb_DL.Name = "_rb_DL";
         this._rb_DL.Size = new System.Drawing.Size(98, 17);
         this._rb_DL.TabIndex = 21;
         this._rb_DL.Text = "Driving License";
         this._rb_DL.UseVisualStyleBackColor = true;
         this._rb_DL.CheckedChanged += new System.EventHandler(this._rb_Respository_CheckedChanged);
         // 
         // _rb_Invoice
         // 
         this._rb_Invoice.AutoSize = true;
         this._rb_Invoice.Location = new System.Drawing.Point(12, 164);
         this._rb_Invoice.Name = "_rb_Invoice";
         this._rb_Invoice.Size = new System.Drawing.Size(60, 17);
         this._rb_Invoice.TabIndex = 22;
         this._rb_Invoice.Text = "Invoice";
         this._rb_Invoice.UseVisualStyleBackColor = true;
         this._rb_Invoice.CheckedChanged += new System.EventHandler(this._rb_Respository_CheckedChanged);
         // 
         // _rb_OMR
         // 
         this._rb_OMR.AutoSize = true;
         this._rb_OMR.Location = new System.Drawing.Point(12, 187);
         this._rb_OMR.Name = "_rb_OMR";
         this._rb_OMR.Size = new System.Drawing.Size(44, 17);
         this._rb_OMR.TabIndex = 23;
         this._rb_OMR.Text = "Omr";
         this._rb_OMR.UseVisualStyleBackColor = true;
         this._rb_OMR.CheckedChanged += new System.EventHandler(this._rb_Respository_CheckedChanged);
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(487, 575);
         this.Controls.Add(this._rb_OMR);
         this.Controls.Add(this._rb_Invoice);
         this.Controls.Add(this._rb_DL);
         this.Controls.Add(this._rb_OCR_ICR);
         this.Controls.Add(this._rb_OCR);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._pbProgress);
         this.Controls.Add(this._lblStatus);
         this.Controls.Add(this._lblFormName);
         this.Controls.Add(this._lblTimingInformation);
         this.Controls.Add(this._btnBrowseMasterFormRespository);
         this.Controls.Add(this._lblMasterFormRespository);
         this.Controls.Add(this._txtMasterFormRespository);
         this.Controls.Add(this._lvLastOperation);
         this.Controls.Add(this.menuStrip1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MainMenuStrip = this.menuStrip1;
         this.MaximizeBox = false;
         this.Name = "MainForm";
         this.Text = "LEADTOOLS Forms Demo";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
         this.menuStrip1.ResumeLayout(false);
         this.menuStrip1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.ColumnHeader _chImage;
      private System.Windows.Forms.ColumnHeader _chOperation;
      private System.Windows.Forms.ColumnHeader _chTime;
      private System.Windows.Forms.ListView _lvLastOperation;
      private System.Windows.Forms.TextBox _txtMasterFormRespository;
      private System.Windows.Forms.Label _lblMasterFormRespository;
      private System.Windows.Forms.Button _btnBrowseMasterFormRespository;
      private System.Windows.Forms.MenuStrip menuStrip1;
      private System.Windows.Forms.ToolStripMenuItem _menuItemFile;
      private System.Windows.Forms.ToolStripMenuItem _menuItemExit;
      private System.Windows.Forms.ToolStripMenuItem _menuItemRecognition;
      private System.Windows.Forms.ToolStripMenuItem _menuItemRecognizeScannedForms;
      private System.Windows.Forms.ToolStripMenuItem _menuItemRecognizeSingleForm;
      private System.Windows.Forms.ToolStripMenuItem _menuItemRecognizeMultipleForms;
      private System.Windows.Forms.ToolStripMenuItem _menuItemHelp;
      private System.Windows.Forms.ToolStripMenuItem _menuItemHowto;
      private System.Windows.Forms.ToolStripMenuItem _menuItemAbout;
      private System.Windows.Forms.ToolStripMenuItem _menuItemRecognizeFirstPageOnly;
      private System.Windows.Forms.Label _lblTimingInformation;
      private System.Windows.Forms.ToolStripMenuItem _menuItemObjectManagers;
      private System.Windows.Forms.ToolStripMenuItem _menuItemOCRManager;
      private System.Windows.Forms.ToolStripMenuItem _menuItemBarcodeManager;
      private System.Windows.Forms.ToolStripMenuItem _menuItemDefaultManager;
      private System.Windows.Forms.ToolStripMenuItem _menuItemOptions;
      private System.Windows.Forms.Label _lblFormName;
      private System.Windows.Forms.Label _lblStatus;
      private System.Windows.Forms.ProgressBar _pbProgress;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.ToolStripMenuItem _menuItemLaunchMasterFormsEditor;
      private System.Windows.Forms.ToolStripMenuItem _menuItemEngine;
      private System.Windows.Forms.ToolStripMenuItem _menuItemLanguages;
      private System.Windows.Forms.ToolStripMenuItem _menuItemComponents;
      private System.Windows.Forms.RadioButton _rb_OCR;
      private System.Windows.Forms.RadioButton _rb_OCR_ICR;
      private System.Windows.Forms.RadioButton _rb_DL;
      private System.Windows.Forms.RadioButton _rb_Invoice;
      private System.Windows.Forms.RadioButton _rb_OMR;

   }
}

