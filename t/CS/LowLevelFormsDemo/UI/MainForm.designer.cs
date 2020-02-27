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
         this._menuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemHowto = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
         this._chImage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this._pbProgress = new System.Windows.Forms.ProgressBar();
         this._lblStatus = new System.Windows.Forms.Label();
         this._lblFormName = new System.Windows.Forms.Label();
         this._lblTimingInformation = new System.Windows.Forms.Label();
         this._btnCancel = new System.Windows.Forms.Button();
         this._lblMasterFormRespository = new System.Windows.Forms.Label();
         this._txtMasterFormRespository = new System.Windows.Forms.TextBox();
         this._lvLastOperation = new System.Windows.Forms.ListView();
         this._chOperation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this._chTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this._btnBrowseMasterFormRespository = new System.Windows.Forms.Button();
         this._rb_OCR_ICR = new System.Windows.Forms.RadioButton();
         this._rb_OCR = new System.Windows.Forms.RadioButton();
         this._rb_DL = new System.Windows.Forms.RadioButton();
         this._rb_Invoice = new System.Windows.Forms.RadioButton();
         this._rb_Omr = new System.Windows.Forms.RadioButton();
         this.menuStrip1.SuspendLayout();
         this.SuspendLayout();
         // 
         // menuStrip1
         // 
         this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuItemFile,
            this._menuItemRecognition,
            this._menuItemOptions,
            this._menuItemHelp});
         this.menuStrip1.Location = new System.Drawing.Point(0, 0);
         this.menuStrip1.Name = "menuStrip1";
         this.menuStrip1.Size = new System.Drawing.Size(486, 24);
         this.menuStrip1.TabIndex = 14;
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
         this._menuItemOCRManager.Click += new System.EventHandler(this.ManagerChange_Click);
         // 
         // _menuItemBarcodeManager
         // 
         this._menuItemBarcodeManager.CheckOnClick = true;
         this._menuItemBarcodeManager.Name = "_menuItemBarcodeManager";
         this._menuItemBarcodeManager.Size = new System.Drawing.Size(205, 22);
         this._menuItemBarcodeManager.Text = "Barcode Object Manager";
         this._menuItemBarcodeManager.Click += new System.EventHandler(this.ManagerChange_Click);
         // 
         // _menuItemDefaultManager
         // 
         this._menuItemDefaultManager.CheckOnClick = true;
         this._menuItemDefaultManager.Name = "_menuItemDefaultManager";
         this._menuItemDefaultManager.Size = new System.Drawing.Size(205, 22);
         this._menuItemDefaultManager.Text = "Default Objects Manager";
         this._menuItemDefaultManager.Click += new System.EventHandler(this.ManagerChange_Click);
         // 
         // _menuItemRecognizeFirstPageOnly
         // 
         this._menuItemRecognizeFirstPageOnly.Checked = true;
         this._menuItemRecognizeFirstPageOnly.CheckOnClick = true;
         this._menuItemRecognizeFirstPageOnly.CheckState = System.Windows.Forms.CheckState.Checked;
         this._menuItemRecognizeFirstPageOnly.Name = "_menuItemRecognizeFirstPageOnly";
         this._menuItemRecognizeFirstPageOnly.Size = new System.Drawing.Size(210, 22);
         this._menuItemRecognizeFirstPageOnly.Text = "Recognize First Page Only";
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
         this._menuItemHowto.Click += new System.EventHandler(this._menuItemHowto_Click);
         // 
         // _menuItemAbout
         // 
         this._menuItemAbout.Name = "_menuItemAbout";
         this._menuItemAbout.Size = new System.Drawing.Size(116, 22);
         this._menuItemAbout.Text = "About";
         this._menuItemAbout.Click += new System.EventHandler(this._menuItemAbout_Click);
         // 
         // _chImage
         // 
         this._chImage.Text = "Image File";
         this._chImage.Width = 117;
         // 
         // _pbProgress
         // 
         this._pbProgress.Location = new System.Drawing.Point(9, 413);
         this._pbProgress.Name = "_pbProgress";
         this._pbProgress.Size = new System.Drawing.Size(416, 23);
         this._pbProgress.TabIndex = 27;
         // 
         // _lblStatus
         // 
         this._lblStatus.AutoSize = true;
         this._lblStatus.Location = new System.Drawing.Point(6, 381);
         this._lblStatus.Name = "_lblStatus";
         this._lblStatus.Size = new System.Drawing.Size(37, 13);
         this._lblStatus.TabIndex = 26;
         this._lblStatus.Text = "Status";
         // 
         // _lblFormName
         // 
         this._lblFormName.AutoSize = true;
         this._lblFormName.Location = new System.Drawing.Point(6, 351);
         this._lblFormName.Name = "_lblFormName";
         this._lblFormName.Size = new System.Drawing.Size(61, 13);
         this._lblFormName.TabIndex = 25;
         this._lblFormName.Text = "Form Name";
         // 
         // _lblTimingInformation
         // 
         this._lblTimingInformation.AutoSize = true;
         this._lblTimingInformation.Location = new System.Drawing.Point(9, 217);
         this._lblTimingInformation.Name = "_lblTimingInformation";
         this._lblTimingInformation.Size = new System.Drawing.Size(93, 13);
         this._lblTimingInformation.TabIndex = 24;
         this._lblTimingInformation.Text = "Timing Information";
         // 
         // _btnCancel
         // 
         this._btnCancel.Location = new System.Drawing.Point(9, 455);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(82, 26);
         this._btnCancel.TabIndex = 28;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
         // 
         // _lblMasterFormRespository
         // 
         this._lblMasterFormRespository.AutoSize = true;
         this._lblMasterFormRespository.Location = new System.Drawing.Point(12, 42);
         this._lblMasterFormRespository.Name = "_lblMasterFormRespository";
         this._lblMasterFormRespository.Size = new System.Drawing.Size(123, 13);
         this._lblMasterFormRespository.TabIndex = 21;
         this._lblMasterFormRespository.Text = "Master Form Respository";
         // 
         // _txtMasterFormRespository
         // 
         this._txtMasterFormRespository.Location = new System.Drawing.Point(12, 71);
         this._txtMasterFormRespository.Name = "_txtMasterFormRespository";
         this._txtMasterFormRespository.ReadOnly = true;
         this._txtMasterFormRespository.Size = new System.Drawing.Size(416, 20);
         this._txtMasterFormRespository.TabIndex = 20;
         // 
         // _lvLastOperation
         // 
         this._lvLastOperation.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._chImage,
            this._chOperation,
            this._chTime});
         this._lvLastOperation.Location = new System.Drawing.Point(9, 248);
         this._lvLastOperation.Name = "_lvLastOperation";
         this._lvLastOperation.Size = new System.Drawing.Size(416, 78);
         this._lvLastOperation.TabIndex = 19;
         this._lvLastOperation.UseCompatibleStateImageBehavior = false;
         this._lvLastOperation.View = System.Windows.Forms.View.Details;
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
         // _btnBrowseMasterFormRespository
         // 
         this._btnBrowseMasterFormRespository.Location = new System.Drawing.Point(434, 70);
         this._btnBrowseMasterFormRespository.Name = "_btnBrowseMasterFormRespository";
         this._btnBrowseMasterFormRespository.Size = new System.Drawing.Size(37, 21);
         this._btnBrowseMasterFormRespository.TabIndex = 22;
         this._btnBrowseMasterFormRespository.Text = "...";
         this._btnBrowseMasterFormRespository.UseVisualStyleBackColor = true;
         this._btnBrowseMasterFormRespository.Click += new System.EventHandler(this._btnBrowseMasterFormRespository_Click);
         // 
         // _rb_OCR_ICR
         // 
         this._rb_OCR_ICR.AutoSize = true;
         this._rb_OCR_ICR.Location = new System.Drawing.Point(12, 120);
         this._rb_OCR_ICR.Name = "_rb_OCR_ICR";
         this._rb_OCR_ICR.Size = new System.Drawing.Size(60, 17);
         this._rb_OCR_ICR.TabIndex = 30;
         this._rb_OCR_ICR.Text = "Ocr_Icr";
         this._rb_OCR_ICR.UseVisualStyleBackColor = true;
         this._rb_OCR_ICR.CheckedChanged += new System.EventHandler(this._rb_Respository_CheckedChanged);
         // 
         // _rb_OCR
         // 
         this._rb_OCR.AutoSize = true;
         this._rb_OCR.Checked = true;
         this._rb_OCR.Location = new System.Drawing.Point(12, 97);
         this._rb_OCR.Name = "_rb_OCR";
         this._rb_OCR.Size = new System.Drawing.Size(42, 17);
         this._rb_OCR.TabIndex = 29;
         this._rb_OCR.TabStop = true;
         this._rb_OCR.Text = "Ocr";
         this._rb_OCR.UseVisualStyleBackColor = true;
         this._rb_OCR.CheckedChanged += new System.EventHandler(this._rb_Respository_CheckedChanged);
         // 
         // _rb_DL
         // 
         this._rb_DL.AutoSize = true;
         this._rb_DL.Location = new System.Drawing.Point(12, 143);
         this._rb_DL.Name = "_rb_DL";
         this._rb_DL.Size = new System.Drawing.Size(98, 17);
         this._rb_DL.TabIndex = 31;
         this._rb_DL.Text = "Driving License";
         this._rb_DL.UseVisualStyleBackColor = true;
         this._rb_DL.CheckedChanged += new System.EventHandler(this._rb_Respository_CheckedChanged);
         // 
         // _rb_Invoice
         // 
         this._rb_Invoice.AutoSize = true;
         this._rb_Invoice.Location = new System.Drawing.Point(12, 166);
         this._rb_Invoice.Name = "_rb_Invoice";
         this._rb_Invoice.Size = new System.Drawing.Size(60, 17);
         this._rb_Invoice.TabIndex = 32;
         this._rb_Invoice.TabStop = true;
         this._rb_Invoice.Text = "Invoice";
         this._rb_Invoice.UseVisualStyleBackColor = true;
         this._rb_Invoice.CheckedChanged += new System.EventHandler(this._rb_Respository_CheckedChanged);
         // 
         // _rb_Omr
         // 
         this._rb_Omr.AutoSize = true;
         this._rb_Omr.Location = new System.Drawing.Point(12, 189);
         this._rb_Omr.Name = "_rb_Omr";
         this._rb_Omr.Size = new System.Drawing.Size(44, 17);
         this._rb_Omr.TabIndex = 33;
         this._rb_Omr.TabStop = true;
         this._rb_Omr.Text = "Omr";
         this._rb_Omr.UseVisualStyleBackColor = true;
         this._rb_Omr.CheckedChanged += new System.EventHandler(this._rb_Respository_CheckedChanged);
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(486, 487);
         this.Controls.Add(this._rb_Omr);
         this.Controls.Add(this._rb_Invoice);
         this.Controls.Add(this._rb_DL);
         this.Controls.Add(this._rb_OCR_ICR);
         this.Controls.Add(this._rb_OCR);
         this.Controls.Add(this._pbProgress);
         this.Controls.Add(this._lblStatus);
         this.Controls.Add(this._lblFormName);
         this.Controls.Add(this._lblTimingInformation);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._lblMasterFormRespository);
         this.Controls.Add(this._txtMasterFormRespository);
         this.Controls.Add(this._lvLastOperation);
         this.Controls.Add(this._btnBrowseMasterFormRespository);
         this.Controls.Add(this.menuStrip1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.Name = "MainForm";
         this.Text = "LEADTOOLS Low Level Forms Demo";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
         this.menuStrip1.ResumeLayout(false);
         this.menuStrip1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.MenuStrip menuStrip1;
      private System.Windows.Forms.ToolStripMenuItem _menuItemFile;
      private System.Windows.Forms.ToolStripMenuItem _menuItemExit;
      private System.Windows.Forms.ToolStripMenuItem _menuItemRecognition;
      private System.Windows.Forms.ToolStripMenuItem _menuItemRecognizeScannedForms;
      private System.Windows.Forms.ToolStripMenuItem _menuItemRecognizeSingleForm;
      private System.Windows.Forms.ToolStripMenuItem _menuItemRecognizeMultipleForms;
      private System.Windows.Forms.ToolStripMenuItem _menuItemOptions;
      private System.Windows.Forms.ToolStripMenuItem _menuItemObjectManagers;
      private System.Windows.Forms.ToolStripMenuItem _menuItemOCRManager;
      private System.Windows.Forms.ToolStripMenuItem _menuItemBarcodeManager;
      private System.Windows.Forms.ToolStripMenuItem _menuItemDefaultManager;
      private System.Windows.Forms.ToolStripMenuItem _menuItemRecognizeFirstPageOnly;
      private System.Windows.Forms.ToolStripMenuItem _menuItemHelp;
      private System.Windows.Forms.ToolStripMenuItem _menuItemHowto;
      private System.Windows.Forms.ToolStripMenuItem _menuItemAbout;
      private System.Windows.Forms.ColumnHeader _chImage;
      private System.Windows.Forms.ProgressBar _pbProgress;
      private System.Windows.Forms.Label _lblStatus;
      private System.Windows.Forms.Label _lblFormName;
      private System.Windows.Forms.Label _lblTimingInformation;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Label _lblMasterFormRespository;
      private System.Windows.Forms.TextBox _txtMasterFormRespository;
      private System.Windows.Forms.ListView _lvLastOperation;
      private System.Windows.Forms.ColumnHeader _chOperation;
      private System.Windows.Forms.ColumnHeader _chTime;
      private System.Windows.Forms.Button _btnBrowseMasterFormRespository;
      private System.Windows.Forms.ToolStripMenuItem _menuItemLaunchMasterFormsEditor;
      private System.Windows.Forms.RadioButton _rb_OCR_ICR;
      private System.Windows.Forms.RadioButton _rb_OCR;
      private System.Windows.Forms.RadioButton _rb_DL;
      private System.Windows.Forms.RadioButton _rb_Invoice;
      private System.Windows.Forms.RadioButton _rb_Omr;

   }
}

