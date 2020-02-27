namespace PDFDocumentDemo.LoadDocument
{
   partial class ReadPDFDocumentControl
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

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReadPDFDocumentControl));
         this._readObjectsValueLabel = new System.Windows.Forms.Label();
         this._readDocumentStructureValueLabel = new System.Windows.Forms.Label();
         this._readObjectsLabel = new System.Windows.Forms.Label();
         this._readDocumentStructureLabel = new System.Windows.Forms.Label();
         this._readObjectsProgressBar = new System.Windows.Forms.ProgressBar();
         this._errorsGroupBox = new System.Windows.Forms.GroupBox();
         this._errorsLabel = new System.Windows.Forms.Label();
         this._copyToClipboardButton = new System.Windows.Forms.Button();
         this._errorsListBox = new System.Windows.Forms.ListBox();
         this._stopButton = new System.Windows.Forms.Button();
         this._errorsGroupBox.SuspendLayout();
         this.SuspendLayout();
         // 
         // _readObjectsValueLabel
         // 
         resources.ApplyResources(this._readObjectsValueLabel, "_readObjectsValueLabel");
         this._readObjectsValueLabel.Name = "_readObjectsValueLabel";
         // 
         // _readDocumentStructureValueLabel
         // 
         resources.ApplyResources(this._readDocumentStructureValueLabel, "_readDocumentStructureValueLabel");
         this._readDocumentStructureValueLabel.Name = "_readDocumentStructureValueLabel";
         // 
         // _readObjectsLabel
         // 
         resources.ApplyResources(this._readObjectsLabel, "_readObjectsLabel");
         this._readObjectsLabel.Name = "_readObjectsLabel";
         // 
         // _readDocumentStructureLabel
         // 
         resources.ApplyResources(this._readDocumentStructureLabel, "_readDocumentStructureLabel");
         this._readDocumentStructureLabel.Name = "_readDocumentStructureLabel";
         // 
         // _readObjectsProgressBar
         // 
         resources.ApplyResources(this._readObjectsProgressBar, "_readObjectsProgressBar");
         this._readObjectsProgressBar.Name = "_readObjectsProgressBar";
         // 
         // _errorsGroupBox
         // 
         this._errorsGroupBox.Controls.Add(this._errorsLabel);
         this._errorsGroupBox.Controls.Add(this._copyToClipboardButton);
         this._errorsGroupBox.Controls.Add(this._errorsListBox);
         resources.ApplyResources(this._errorsGroupBox, "_errorsGroupBox");
         this._errorsGroupBox.Name = "_errorsGroupBox";
         this._errorsGroupBox.TabStop = false;
         // 
         // _errorsLabel
         // 
         resources.ApplyResources(this._errorsLabel, "_errorsLabel");
         this._errorsLabel.Name = "_errorsLabel";
         // 
         // _copyToClipboardButton
         // 
         resources.ApplyResources(this._copyToClipboardButton, "_copyToClipboardButton");
         this._copyToClipboardButton.Name = "_copyToClipboardButton";
         this._copyToClipboardButton.UseVisualStyleBackColor = true;
         this._copyToClipboardButton.Click += new System.EventHandler(this._copyToClipboardButton_Click);
         // 
         // _errorsListBox
         // 
         this._errorsListBox.FormattingEnabled = true;
         resources.ApplyResources(this._errorsListBox, "_errorsListBox");
         this._errorsListBox.Name = "_errorsListBox";
         // 
         // _stopButton
         // 
         resources.ApplyResources(this._stopButton, "_stopButton");
         this._stopButton.Name = "_stopButton";
         this._stopButton.UseVisualStyleBackColor = true;
         this._stopButton.Click += new System.EventHandler(this._stopButton_Click);
         // 
         // ReadPDFDocumentControl
         // 
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this._stopButton);
         this.Controls.Add(this._errorsGroupBox);
         this.Controls.Add(this._readObjectsProgressBar);
         this.Controls.Add(this._readObjectsValueLabel);
         this.Controls.Add(this._readDocumentStructureValueLabel);
         this.Controls.Add(this._readObjectsLabel);
         this.Controls.Add(this._readDocumentStructureLabel);
         this.Name = "ReadPDFDocumentControl";
         this._errorsGroupBox.ResumeLayout(false);
         this._errorsGroupBox.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label _readObjectsValueLabel;
      private System.Windows.Forms.Label _readDocumentStructureValueLabel;
      private System.Windows.Forms.Label _readObjectsLabel;
      private System.Windows.Forms.Label _readDocumentStructureLabel;
      private System.Windows.Forms.ProgressBar _readObjectsProgressBar;
      private System.Windows.Forms.GroupBox _errorsGroupBox;
      private System.Windows.Forms.Button _copyToClipboardButton;
      private System.Windows.Forms.ListBox _errorsListBox;
      private System.Windows.Forms.Label _errorsLabel;
      private System.Windows.Forms.Button _stopButton;
   }
}
