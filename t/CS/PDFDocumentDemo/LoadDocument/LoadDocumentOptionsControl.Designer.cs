namespace PDFDocumentDemo.LoadDocument
{
   partial class LoadDocumentOptionsControl
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadDocumentOptionsControl));
         this._pagesInfoLabel = new System.Windows.Forms.Label();
         this._objectsGroupBox = new System.Windows.Forms.GroupBox();
         this._readFontsCheckBox = new System.Windows.Forms.CheckBox();
         this._parseDigitalSignaturesCheckBox = new System.Windows.Forms.CheckBox();
         this._parseChunksCheckBox = new System.Windows.Forms.CheckBox();
         this._parseObjectsInfoLabel = new System.Windows.Forms.Label();
         this._parseObjectsCheckBox = new System.Windows.Forms.CheckBox();
         this._readInternalLinksCheckBox = new System.Windows.Forms.CheckBox();
         this._readBookmarksCheckBox = new System.Windows.Forms.CheckBox();
         this._pagesGroupBox = new System.Windows.Forms.GroupBox();
         this._resolutionGroupBox = new System.Windows.Forms.GroupBox();
         this._resolutionHelpLabel = new System.Windows.Forms.Label();
         this._resolutionComboBox = new System.Windows.Forms.ComboBox();
         this._objectsGroupBox.SuspendLayout();
         this._pagesGroupBox.SuspendLayout();
         this._resolutionGroupBox.SuspendLayout();
         this.SuspendLayout();
         // 
         // _pagesInfoLabel
         // 
         resources.ApplyResources(this._pagesInfoLabel, "_pagesInfoLabel");
         this._pagesInfoLabel.Name = "_pagesInfoLabel";
         // 
         // _objectsGroupBox
         // 
         this._objectsGroupBox.Controls.Add(this._readFontsCheckBox);
         this._objectsGroupBox.Controls.Add(this._parseDigitalSignaturesCheckBox);
         this._objectsGroupBox.Controls.Add(this._parseChunksCheckBox);
         this._objectsGroupBox.Controls.Add(this._parseObjectsInfoLabel);
         this._objectsGroupBox.Controls.Add(this._parseObjectsCheckBox);
         this._objectsGroupBox.Controls.Add(this._readInternalLinksCheckBox);
         this._objectsGroupBox.Controls.Add(this._readBookmarksCheckBox);
         resources.ApplyResources(this._objectsGroupBox, "_objectsGroupBox");
         this._objectsGroupBox.Name = "_objectsGroupBox";
         this._objectsGroupBox.TabStop = false;
         // 
         // _readFontsCheckBox
         // 
         resources.ApplyResources(this._readFontsCheckBox, "_readFontsCheckBox");
         this._readFontsCheckBox.Name = "_readFontsCheckBox";
         this._readFontsCheckBox.UseVisualStyleBackColor = true;
         // 
         // _parseDigitalSignaturesCheckBox
         // 
         resources.ApplyResources(this._parseDigitalSignaturesCheckBox, "_parseDigitalSignaturesCheckBox");
         this._parseDigitalSignaturesCheckBox.Name = "_parseDigitalSignaturesCheckBox";
         this._parseDigitalSignaturesCheckBox.UseVisualStyleBackColor = true;
         this._parseDigitalSignaturesCheckBox.CheckedChanged += new System.EventHandler(this._parseDigitalSignaturesCheckBox_CheckedChanged);
         // 
         // _parseChunksCheckBox
         // 
         resources.ApplyResources(this._parseChunksCheckBox, "_parseChunksCheckBox");
         this._parseChunksCheckBox.Name = "_parseChunksCheckBox";
         this._parseChunksCheckBox.UseVisualStyleBackColor = true;
         // 
         // _parseObjectsInfoLabel
         // 
         resources.ApplyResources(this._parseObjectsInfoLabel, "_parseObjectsInfoLabel");
         this._parseObjectsInfoLabel.Name = "_parseObjectsInfoLabel";
         // 
         // _parseObjectsCheckBox
         // 
         resources.ApplyResources(this._parseObjectsCheckBox, "_parseObjectsCheckBox");
         this._parseObjectsCheckBox.Name = "_parseObjectsCheckBox";
         this._parseObjectsCheckBox.UseVisualStyleBackColor = true;
         // 
         // _readInternalLinksCheckBox
         // 
         resources.ApplyResources(this._readInternalLinksCheckBox, "_readInternalLinksCheckBox");
         this._readInternalLinksCheckBox.Name = "_readInternalLinksCheckBox";
         this._readInternalLinksCheckBox.UseVisualStyleBackColor = true;
         // 
         // _readBookmarksCheckBox
         // 
         resources.ApplyResources(this._readBookmarksCheckBox, "_readBookmarksCheckBox");
         this._readBookmarksCheckBox.Name = "_readBookmarksCheckBox";
         this._readBookmarksCheckBox.UseVisualStyleBackColor = true;
         // 
         // _pagesGroupBox
         // 
         this._pagesGroupBox.Controls.Add(this._pagesInfoLabel);
         resources.ApplyResources(this._pagesGroupBox, "_pagesGroupBox");
         this._pagesGroupBox.Name = "_pagesGroupBox";
         this._pagesGroupBox.TabStop = false;
         // 
         // _resolutionGroupBox
         // 
         this._resolutionGroupBox.Controls.Add(this._resolutionHelpLabel);
         this._resolutionGroupBox.Controls.Add(this._resolutionComboBox);
         resources.ApplyResources(this._resolutionGroupBox, "_resolutionGroupBox");
         this._resolutionGroupBox.Name = "_resolutionGroupBox";
         this._resolutionGroupBox.TabStop = false;
         // 
         // _resolutionHelpLabel
         // 
         resources.ApplyResources(this._resolutionHelpLabel, "_resolutionHelpLabel");
         this._resolutionHelpLabel.Name = "_resolutionHelpLabel";
         // 
         // _resolutionComboBox
         // 
         this._resolutionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._resolutionComboBox.FormattingEnabled = true;
         resources.ApplyResources(this._resolutionComboBox, "_resolutionComboBox");
         this._resolutionComboBox.Name = "_resolutionComboBox";
         // 
         // LoadDocumentOptionsControl
         // 
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this._objectsGroupBox);
         this.Controls.Add(this._pagesGroupBox);
         this.Controls.Add(this._resolutionGroupBox);
         this.Name = "LoadDocumentOptionsControl";
         this._objectsGroupBox.ResumeLayout(false);
         this._objectsGroupBox.PerformLayout();
         this._pagesGroupBox.ResumeLayout(false);
         this._pagesGroupBox.PerformLayout();
         this._resolutionGroupBox.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Label _pagesInfoLabel;
      private System.Windows.Forms.GroupBox _objectsGroupBox;
      private System.Windows.Forms.CheckBox _parseChunksCheckBox;
      private System.Windows.Forms.Label _parseObjectsInfoLabel;
      private System.Windows.Forms.CheckBox _parseObjectsCheckBox;
      private System.Windows.Forms.CheckBox _readInternalLinksCheckBox;
      private System.Windows.Forms.CheckBox _readBookmarksCheckBox;
      private System.Windows.Forms.GroupBox _pagesGroupBox;
      private System.Windows.Forms.GroupBox _resolutionGroupBox;
      private System.Windows.Forms.Label _resolutionHelpLabel;
      private System.Windows.Forms.ComboBox _resolutionComboBox;
      private System.Windows.Forms.CheckBox _parseDigitalSignaturesCheckBox;
      private System.Windows.Forms.CheckBox _readFontsCheckBox;
   }
}
