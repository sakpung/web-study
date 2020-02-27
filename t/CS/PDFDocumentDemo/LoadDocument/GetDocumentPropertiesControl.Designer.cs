namespace PDFDocumentDemo.LoadDocument
{
   partial class GetDocumentPropertiesControl
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GetDocumentPropertiesControl));
         this._fileTypeLabel = new System.Windows.Forms.Label();
         this._encryptionLabel = new System.Windows.Forms.Label();
         this._createDocumentLabel = new System.Windows.Forms.Label();
         this._fileTypeValueLabel = new System.Windows.Forms.Label();
         this._encryptionValueLabel = new System.Windows.Forms.Label();
         this._createDocumentValueLabel = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // _fileTypeLabel
         // 
         resources.ApplyResources(this._fileTypeLabel, "_fileTypeLabel");
         this._fileTypeLabel.Name = "_fileTypeLabel";
         // 
         // _encryptionLabel
         // 
         resources.ApplyResources(this._encryptionLabel, "_encryptionLabel");
         this._encryptionLabel.Name = "_encryptionLabel";
         // 
         // _createDocumentLabel
         // 
         resources.ApplyResources(this._createDocumentLabel, "_createDocumentLabel");
         this._createDocumentLabel.Name = "_createDocumentLabel";
         // 
         // _fileTypeValueLabel
         // 
         resources.ApplyResources(this._fileTypeValueLabel, "_fileTypeValueLabel");
         this._fileTypeValueLabel.Name = "_fileTypeValueLabel";
         // 
         // _encryptionValueLabel
         // 
         resources.ApplyResources(this._encryptionValueLabel, "_encryptionValueLabel");
         this._encryptionValueLabel.Name = "_encryptionValueLabel";
         // 
         // _createDocumentValueLabel
         // 
         resources.ApplyResources(this._createDocumentValueLabel, "_createDocumentValueLabel");
         this._createDocumentValueLabel.Name = "_createDocumentValueLabel";
         // 
         // GetDocumentPropertiesControl
         // 
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this._createDocumentValueLabel);
         this.Controls.Add(this._encryptionValueLabel);
         this.Controls.Add(this._fileTypeValueLabel);
         this.Controls.Add(this._createDocumentLabel);
         this.Controls.Add(this._encryptionLabel);
         this.Controls.Add(this._fileTypeLabel);
         this.Name = "GetDocumentPropertiesControl";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label _fileTypeLabel;
      private System.Windows.Forms.Label _encryptionLabel;
      private System.Windows.Forms.Label _createDocumentLabel;
      private System.Windows.Forms.Label _fileTypeValueLabel;
      private System.Windows.Forms.Label _encryptionValueLabel;
      private System.Windows.Forms.Label _createDocumentValueLabel;
   }
}
