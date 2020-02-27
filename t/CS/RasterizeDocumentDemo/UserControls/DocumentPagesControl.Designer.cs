namespace RasterizeDocumentDemo.UserControls
{
   partial class DocumentPagesControl
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
         this._loadAllPagesCheckBox = new System.Windows.Forms.CheckBox();
         this._lastPageNumberTextBox = new System.Windows.Forms.TextBox();
         this._firstPageNumberTextBox = new System.Windows.Forms.TextBox();
         this._lastPageNumberLabel = new System.Windows.Forms.Label();
         this._pagesGroupBox = new System.Windows.Forms.GroupBox();
         this._firstPageNumberLabel = new System.Windows.Forms.Label();
         this._pagesGroupBox.SuspendLayout();
         this.SuspendLayout();
         // 
         // _loadAllPagesCheckBox
         // 
         this._loadAllPagesCheckBox.AutoSize = true;
         this._loadAllPagesCheckBox.Location = new System.Drawing.Point(47, 55);
         this._loadAllPagesCheckBox.Name = "_loadAllPagesCheckBox";
         this._loadAllPagesCheckBox.Size = new System.Drawing.Size(95, 17);
         this._loadAllPagesCheckBox.TabIndex = 4;
         this._loadAllPagesCheckBox.Text = "&Load all pages";
         this._loadAllPagesCheckBox.UseVisualStyleBackColor = true;
         this._loadAllPagesCheckBox.CheckedChanged += new System.EventHandler(this._loadAllPagesCheckBox_CheckedChanged);
         // 
         // _lastPageNumberTextBox
         // 
         this._lastPageNumberTextBox.Location = new System.Drawing.Point(366, 29);
         this._lastPageNumberTextBox.Name = "_lastPageNumberTextBox";
         this._lastPageNumberTextBox.Size = new System.Drawing.Size(100, 20);
         this._lastPageNumberTextBox.TabIndex = 3;
         // 
         // _firstPageNumberTextBox
         // 
         this._firstPageNumberTextBox.Location = new System.Drawing.Point(144, 29);
         this._firstPageNumberTextBox.Name = "_firstPageNumberTextBox";
         this._firstPageNumberTextBox.Size = new System.Drawing.Size(100, 20);
         this._firstPageNumberTextBox.TabIndex = 1;
         // 
         // _lastPageNumberLabel
         // 
         this._lastPageNumberLabel.AutoSize = true;
         this._lastPageNumberLabel.Location = new System.Drawing.Point(265, 32);
         this._lastPageNumberLabel.Name = "_lastPageNumberLabel";
         this._lastPageNumberLabel.Size = new System.Drawing.Size(95, 13);
         this._lastPageNumberLabel.TabIndex = 2;
         this._lastPageNumberLabel.Text = "&Last page number:";
         // 
         // _pagesGroupBox
         // 
         this._pagesGroupBox.Controls.Add(this._loadAllPagesCheckBox);
         this._pagesGroupBox.Controls.Add(this._lastPageNumberTextBox);
         this._pagesGroupBox.Controls.Add(this._firstPageNumberTextBox);
         this._pagesGroupBox.Controls.Add(this._lastPageNumberLabel);
         this._pagesGroupBox.Controls.Add(this._firstPageNumberLabel);
         this._pagesGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
         this._pagesGroupBox.Location = new System.Drawing.Point(0, 0);
         this._pagesGroupBox.Name = "_pagesGroupBox";
         this._pagesGroupBox.Size = new System.Drawing.Size(489, 86);
         this._pagesGroupBox.TabIndex = 0;
         this._pagesGroupBox.TabStop = false;
         this._pagesGroupBox.Text = "This document contains ### total &pages.  Select the pages you want to load:";
         // 
         // _firstPageNumberLabel
         // 
         this._firstPageNumberLabel.AutoSize = true;
         this._firstPageNumberLabel.Location = new System.Drawing.Point(44, 32);
         this._firstPageNumberLabel.Name = "_firstPageNumberLabel";
         this._firstPageNumberLabel.Size = new System.Drawing.Size(94, 13);
         this._firstPageNumberLabel.TabIndex = 0;
         this._firstPageNumberLabel.Text = "F&irst page number:";
         // 
         // DocumentPagesControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this._pagesGroupBox);
         this.Name = "DocumentPagesControl";
         this.Size = new System.Drawing.Size(489, 86);
         this._pagesGroupBox.ResumeLayout(false);
         this._pagesGroupBox.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.CheckBox _loadAllPagesCheckBox;
      private System.Windows.Forms.TextBox _lastPageNumberTextBox;
      private System.Windows.Forms.TextBox _firstPageNumberTextBox;
      private System.Windows.Forms.Label _lastPageNumberLabel;
      private System.Windows.Forms.GroupBox _pagesGroupBox;
      private System.Windows.Forms.Label _firstPageNumberLabel;
   }
}
