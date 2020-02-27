namespace OcrMultiEngineDemo
{
   partial class RecognizedWordsDialog
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecognizedWordsDialog));
          this._closeButton = new System.Windows.Forms.Button();
          this._pagesListBox = new System.Windows.Forms.ListBox();
          this._wordsListBox = new System.Windows.Forms.ListBox();
          this.SuspendLayout();
          // 
          // _closeButton
          // 
          this._closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          resources.ApplyResources(this._closeButton, "_closeButton");
          this._closeButton.Name = "_closeButton";
          this._closeButton.UseVisualStyleBackColor = true;
          // 
          // _pagesListBox
          // 
          this._pagesListBox.FormattingEnabled = true;
          resources.ApplyResources(this._pagesListBox, "_pagesListBox");
          this._pagesListBox.Name = "_pagesListBox";
          this._pagesListBox.SelectedIndexChanged += new System.EventHandler(this._pagesListBox_SelectedIndexChanged);
          // 
          // _wordsListBox
          // 
          resources.ApplyResources(this._wordsListBox, "_wordsListBox");
          this._wordsListBox.FormattingEnabled = true;
          this._wordsListBox.Name = "_wordsListBox";
          // 
          // RecognizedWordsDialog
          // 
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this._closeButton;
          this.Controls.Add(this._wordsListBox);
          this.Controls.Add(this._pagesListBox);
          this.Controls.Add(this._closeButton);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "RecognizedWordsDialog";
          this.ShowInTaskbar = false;
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _closeButton;
      private System.Windows.Forms.ListBox _pagesListBox;
      private System.Windows.Forms.ListBox _wordsListBox;
   }
}