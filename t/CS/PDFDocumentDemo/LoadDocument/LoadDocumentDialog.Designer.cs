namespace PDFDocumentDemo.LoadDocument
{
   partial class LoadDocumentDialog
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
         if(disposing && (components != null))
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadDocumentDialog));
         this._cancelButton = new System.Windows.Forms.Button();
         this._fileNameTextBox = new System.Windows.Forms.TextBox();
         this._okButton = new System.Windows.Forms.Button();
         this._mainWizardControl = new PDFDocumentDemo.WizardControl();
         this._propertiesTabPage = new System.Windows.Forms.TabPage();
         this._getDocumentPropertiesControl = new PDFDocumentDemo.LoadDocument.GetDocumentPropertiesControl();
         this._optionsTabPage = new System.Windows.Forms.TabPage();
         this._loadDocumentOptionsControl = new PDFDocumentDemo.LoadDocument.LoadDocumentOptionsControl();
         this._readTabPage = new System.Windows.Forms.TabPage();
         this._readPDFDocumentControl = new PDFDocumentDemo.LoadDocument.ReadPDFDocumentControl();
         this._mainWizardControl.SuspendLayout();
         this._propertiesTabPage.SuspendLayout();
         this._optionsTabPage.SuspendLayout();
         this._readTabPage.SuspendLayout();
         this.SuspendLayout();
         // 
         // _cancelButton
         // 
         this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         resources.ApplyResources(this._cancelButton, "_cancelButton");
         this._cancelButton.Name = "_cancelButton";
         this._cancelButton.UseVisualStyleBackColor = true;
         // 
         // _fileNameTextBox
         // 
         resources.ApplyResources(this._fileNameTextBox, "_fileNameTextBox");
         this._fileNameTextBox.Name = "_fileNameTextBox";
         this._fileNameTextBox.ReadOnly = true;
         this._fileNameTextBox.TabStop = false;
         // 
         // _okButton
         // 
         this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
         resources.ApplyResources(this._okButton, "_okButton");
         this._okButton.Name = "_okButton";
         this._okButton.UseVisualStyleBackColor = true;
         this._okButton.Click += new System.EventHandler(this._okButton_Click);
         // 
         // _mainWizardControl
         // 
         this._mainWizardControl.Controls.Add(this._propertiesTabPage);
         this._mainWizardControl.Controls.Add(this._optionsTabPage);
         this._mainWizardControl.Controls.Add(this._readTabPage);
         resources.ApplyResources(this._mainWizardControl, "_mainWizardControl");
         this._mainWizardControl.Name = "_mainWizardControl";
         this._mainWizardControl.SelectedIndex = 0;
         // 
         // _propertiesTabPage
         // 
         this._propertiesTabPage.Controls.Add(this._getDocumentPropertiesControl);
         resources.ApplyResources(this._propertiesTabPage, "_propertiesTabPage");
         this._propertiesTabPage.Name = "_propertiesTabPage";
         this._propertiesTabPage.UseVisualStyleBackColor = true;
         // 
         // _getDocumentPropertiesControl
         // 
         resources.ApplyResources(this._getDocumentPropertiesControl, "_getDocumentPropertiesControl");
         this._getDocumentPropertiesControl.Name = "_getDocumentPropertiesControl";
         // 
         // _optionsTabPage
         // 
         this._optionsTabPage.Controls.Add(this._loadDocumentOptionsControl);
         resources.ApplyResources(this._optionsTabPage, "_optionsTabPage");
         this._optionsTabPage.Name = "_optionsTabPage";
         this._optionsTabPage.UseVisualStyleBackColor = true;
         // 
         // _loadDocumentOptionsControl
         // 
         resources.ApplyResources(this._loadDocumentOptionsControl, "_loadDocumentOptionsControl");
         this._loadDocumentOptionsControl.Name = "_loadDocumentOptionsControl";
         // 
         // _readTabPage
         // 
         this._readTabPage.Controls.Add(this._readPDFDocumentControl);
         resources.ApplyResources(this._readTabPage, "_readTabPage");
         this._readTabPage.Name = "_readTabPage";
         this._readTabPage.UseVisualStyleBackColor = true;
         // 
         // _readPDFDocumentControl
         // 
         resources.ApplyResources(this._readPDFDocumentControl, "_readPDFDocumentControl");
         this._readPDFDocumentControl.Name = "_readPDFDocumentControl";
         // 
         // LoadDocumentDialog
         // 
         this.AcceptButton = this._okButton;
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._cancelButton;
         this.Controls.Add(this._okButton);
         this.Controls.Add(this._fileNameTextBox);
         this.Controls.Add(this._mainWizardControl);
         this.Controls.Add(this._cancelButton);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "LoadDocumentDialog";
         this.ShowInTaskbar = false;
         this._mainWizardControl.ResumeLayout(false);
         this._propertiesTabPage.ResumeLayout(false);
         this._optionsTabPage.ResumeLayout(false);
         this._readTabPage.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button _cancelButton;
      private WizardControl _mainWizardControl;
      private System.Windows.Forms.TabPage _propertiesTabPage;
      private GetDocumentPropertiesControl _getDocumentPropertiesControl;
      private System.Windows.Forms.TextBox _fileNameTextBox;
      private System.Windows.Forms.TabPage _optionsTabPage;
      private LoadDocumentOptionsControl _loadDocumentOptionsControl;
      private System.Windows.Forms.Button _okButton;
      private System.Windows.Forms.TabPage _readTabPage;
      private ReadPDFDocumentControl _readPDFDocumentControl;
   }
}