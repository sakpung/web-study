namespace PDFDocumentDemo
{
   partial class DocumentPropertiesDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocumentPropertiesDialog));
         this._okButton = new System.Windows.Forms.Button();
         this._notesLabel = new System.Windows.Forms.Label();
         this._fileNameLabel = new System.Windows.Forms.Label();
         this._fileNameTextBox = new System.Windows.Forms.TextBox();
         this._numberOfPagesTextBox = new System.Windows.Forms.TextBox();
         this._numberOfPagesLabel = new System.Windows.Forms.Label();
         this._pageSizeTextBox = new System.Windows.Forms.TextBox();
         this._pageSizeLabel = new System.Windows.Forms.Label();
         this._isEncryptedTextBox = new System.Windows.Forms.TextBox();
         this._isEncryptedLabel = new System.Windows.Forms.Label();
         this._versionTextBox = new System.Windows.Forms.TextBox();
         this._versionLabel = new System.Windows.Forms.Label();
         this._isPdfATextBox = new System.Windows.Forms.TextBox();
         this._isPdfALabel = new System.Windows.Forms.Label();
         this._documentPropertiesControl = new PDFDocumentDemo.DocumentPropertiesControl();
         this._isLinearizedTextBox = new System.Windows.Forms.TextBox();
         this._isLinearizedLabel = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // _okButton
         // 
         this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
         resources.ApplyResources(this._okButton, "_okButton");
         this._okButton.Name = "_okButton";
         this._okButton.UseVisualStyleBackColor = true;
         // 
         // _notesLabel
         // 
         resources.ApplyResources(this._notesLabel, "_notesLabel");
         this._notesLabel.Name = "_notesLabel";
         // 
         // _fileNameLabel
         // 
         resources.ApplyResources(this._fileNameLabel, "_fileNameLabel");
         this._fileNameLabel.Name = "_fileNameLabel";
         // 
         // _fileNameTextBox
         // 
         resources.ApplyResources(this._fileNameTextBox, "_fileNameTextBox");
         this._fileNameTextBox.Name = "_fileNameTextBox";
         this._fileNameTextBox.ReadOnly = true;
         // 
         // _numberOfPagesTextBox
         // 
         resources.ApplyResources(this._numberOfPagesTextBox, "_numberOfPagesTextBox");
         this._numberOfPagesTextBox.Name = "_numberOfPagesTextBox";
         this._numberOfPagesTextBox.ReadOnly = true;
         // 
         // _numberOfPagesLabel
         // 
         resources.ApplyResources(this._numberOfPagesLabel, "_numberOfPagesLabel");
         this._numberOfPagesLabel.Name = "_numberOfPagesLabel";
         // 
         // _pageSizeTextBox
         // 
         resources.ApplyResources(this._pageSizeTextBox, "_pageSizeTextBox");
         this._pageSizeTextBox.Name = "_pageSizeTextBox";
         this._pageSizeTextBox.ReadOnly = true;
         // 
         // _pageSizeLabel
         // 
         resources.ApplyResources(this._pageSizeLabel, "_pageSizeLabel");
         this._pageSizeLabel.Name = "_pageSizeLabel";
         // 
         // _isEncryptedTextBox
         // 
         resources.ApplyResources(this._isEncryptedTextBox, "_isEncryptedTextBox");
         this._isEncryptedTextBox.Name = "_isEncryptedTextBox";
         this._isEncryptedTextBox.ReadOnly = true;
         // 
         // _isEncryptedLabel
         // 
         resources.ApplyResources(this._isEncryptedLabel, "_isEncryptedLabel");
         this._isEncryptedLabel.Name = "_isEncryptedLabel";
         // 
         // _versionTextBox
         // 
         resources.ApplyResources(this._versionTextBox, "_versionTextBox");
         this._versionTextBox.Name = "_versionTextBox";
         this._versionTextBox.ReadOnly = true;
         // 
         // _versionLabel
         // 
         resources.ApplyResources(this._versionLabel, "_versionLabel");
         this._versionLabel.Name = "_versionLabel";
         // 
         // _isPdfATextBox
         // 
         this._isPdfATextBox.BackColor = System.Drawing.SystemColors.Control;
         resources.ApplyResources(this._isPdfATextBox, "_isPdfATextBox");
         this._isPdfATextBox.Name = "_isPdfATextBox";
         // 
         // _isPdfALabel
         // 
         resources.ApplyResources(this._isPdfALabel, "_isPdfALabel");
         this._isPdfALabel.Name = "_isPdfALabel";
         // 
         // _documentPropertiesControl
         // 
         resources.ApplyResources(this._documentPropertiesControl, "_documentPropertiesControl");
         this._documentPropertiesControl.Name = "_documentPropertiesControl";
         // 
         // _isLinearizedTextBox
         // 
         resources.ApplyResources(this._isLinearizedTextBox, "_isLinearizedTextBox");
         this._isLinearizedTextBox.Name = "_isLinearizedTextBox";
         this._isLinearizedTextBox.ReadOnly = true;
         // 
         // _isLinearizedLabel
         // 
         resources.ApplyResources(this._isLinearizedLabel, "_isLinearizedLabel");
         this._isLinearizedLabel.Name = "_isLinearizedLabel";
         // 
         // DocumentPropertiesDialog
         // 
         this.AcceptButton = this._okButton;
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._okButton;
         this.Controls.Add(this._isLinearizedTextBox);
         this.Controls.Add(this._isLinearizedLabel);
         this.Controls.Add(this._documentPropertiesControl);
         this.Controls.Add(this._isPdfALabel);
         this.Controls.Add(this._isPdfATextBox);
         this.Controls.Add(this._versionTextBox);
         this.Controls.Add(this._versionLabel);
         this.Controls.Add(this._isEncryptedTextBox);
         this.Controls.Add(this._isEncryptedLabel);
         this.Controls.Add(this._pageSizeTextBox);
         this.Controls.Add(this._pageSizeLabel);
         this.Controls.Add(this._numberOfPagesTextBox);
         this.Controls.Add(this._numberOfPagesLabel);
         this.Controls.Add(this._fileNameTextBox);
         this.Controls.Add(this._fileNameLabel);
         this.Controls.Add(this._notesLabel);
         this.Controls.Add(this._okButton);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "DocumentPropertiesDialog";
         this.ShowInTaskbar = false;
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button _okButton;
      private System.Windows.Forms.Label _notesLabel;
      private System.Windows.Forms.Label _fileNameLabel;
      private System.Windows.Forms.TextBox _fileNameTextBox;
      private System.Windows.Forms.TextBox _numberOfPagesTextBox;
      private System.Windows.Forms.Label _numberOfPagesLabel;
      private System.Windows.Forms.TextBox _pageSizeTextBox;
      private System.Windows.Forms.Label _pageSizeLabel;
      private System.Windows.Forms.TextBox _isEncryptedTextBox;
      private System.Windows.Forms.Label _isEncryptedLabel;
      private System.Windows.Forms.TextBox _versionTextBox;
      private System.Windows.Forms.Label _versionLabel;
      private DocumentPropertiesControl _documentPropertiesControl;
      private System.Windows.Forms.TextBox _isPdfATextBox;
      private System.Windows.Forms.Label _isPdfALabel;
      private System.Windows.Forms.TextBox _isLinearizedTextBox;
      private System.Windows.Forms.Label _isLinearizedLabel;
   }
}