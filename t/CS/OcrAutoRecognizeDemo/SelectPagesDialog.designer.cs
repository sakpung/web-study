namespace OcrAutoRecognizeDemo
{
   partial class SelectPagesDialog
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
         this._okButton = new System.Windows.Forms.Button();
         this._cancelButton = new System.Windows.Forms.Button();
         this._pagesGroupBox = new System.Windows.Forms.GroupBox();
         this._lastPageCheckBox = new System.Windows.Forms.CheckBox();
         this._allPagesCheckBox = new System.Windows.Forms.CheckBox();
         this._toPageTextBox = new System.Windows.Forms.TextBox();
         this._toPageLabel = new System.Windows.Forms.Label();
         this._fromPageTextBox = new System.Windows.Forms.TextBox();
         this._fromLabel = new System.Windows.Forms.Label();
         this._pagesGroupBox.SuspendLayout();
         this.SuspendLayout();
         // 
         // _okButton
         // 
         this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._okButton.Location = new System.Drawing.Point(295, 26);
         this._okButton.Name = "_okButton";
         this._okButton.Size = new System.Drawing.Size(75, 23);
         this._okButton.TabIndex = 1;
         this._okButton.Text = "OK";
         this._okButton.UseVisualStyleBackColor = true;
         this._okButton.Click += new System.EventHandler(this._okButton_Click);
         // 
         // _cancelButton
         // 
         this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._cancelButton.Location = new System.Drawing.Point(295, 55);
         this._cancelButton.Name = "_cancelButton";
         this._cancelButton.Size = new System.Drawing.Size(75, 23);
         this._cancelButton.TabIndex = 2;
         this._cancelButton.Text = "Cancel";
         this._cancelButton.UseVisualStyleBackColor = true;
         // 
         // _pagesGroupBox
         // 
         this._pagesGroupBox.Controls.Add(this._lastPageCheckBox);
         this._pagesGroupBox.Controls.Add(this._allPagesCheckBox);
         this._pagesGroupBox.Controls.Add(this._toPageTextBox);
         this._pagesGroupBox.Controls.Add(this._toPageLabel);
         this._pagesGroupBox.Controls.Add(this._fromPageTextBox);
         this._pagesGroupBox.Controls.Add(this._fromLabel);
         this._pagesGroupBox.Location = new System.Drawing.Point(13, 13);
         this._pagesGroupBox.Name = "_pagesGroupBox";
         this._pagesGroupBox.Size = new System.Drawing.Size(267, 138);
         this._pagesGroupBox.TabIndex = 0;
         this._pagesGroupBox.TabStop = false;
         // 
         // _lastPageCheckBox
         // 
         this._lastPageCheckBox.AutoSize = true;
         this._lastPageCheckBox.Location = new System.Drawing.Point(99, 104);
         this._lastPageCheckBox.Name = "_lastPageCheckBox";
         this._lastPageCheckBox.Size = new System.Drawing.Size(73, 17);
         this._lastPageCheckBox.TabIndex = 5;
         this._lastPageCheckBox.Text = "Last page";
         this._lastPageCheckBox.UseVisualStyleBackColor = true;
         this._lastPageCheckBox.CheckedChanged += new System.EventHandler(this._lastPageCheckBox_CheckedChanged);
         // 
         // _allPagesCheckBox
         // 
         this._allPagesCheckBox.AutoSize = true;
         this._allPagesCheckBox.Location = new System.Drawing.Point(24, 19);
         this._allPagesCheckBox.Name = "_allPagesCheckBox";
         this._allPagesCheckBox.Size = new System.Drawing.Size(69, 17);
         this._allPagesCheckBox.TabIndex = 0;
         this._allPagesCheckBox.Text = "All pages";
         this._allPagesCheckBox.UseVisualStyleBackColor = true;
         this._allPagesCheckBox.CheckedChanged += new System.EventHandler(this._allPagesCheckBox_CheckedChanged);
         // 
         // _toPageTextBox
         // 
         this._toPageTextBox.Location = new System.Drawing.Point(99, 77);
         this._toPageTextBox.Name = "_toPageTextBox";
         this._toPageTextBox.Size = new System.Drawing.Size(100, 20);
         this._toPageTextBox.TabIndex = 4;
         // 
         // _toPageLabel
         // 
         this._toPageLabel.AutoSize = true;
         this._toPageLabel.Location = new System.Drawing.Point(43, 77);
         this._toPageLabel.Name = "_toPageLabel";
         this._toPageLabel.Size = new System.Drawing.Size(50, 13);
         this._toPageLabel.TabIndex = 3;
         this._toPageLabel.Text = "To page:";
         // 
         // _fromPageTextBox
         // 
         this._fromPageTextBox.Location = new System.Drawing.Point(99, 51);
         this._fromPageTextBox.Name = "_fromPageTextBox";
         this._fromPageTextBox.Size = new System.Drawing.Size(100, 20);
         this._fromPageTextBox.TabIndex = 2;
         // 
         // _fromLabel
         // 
         this._fromLabel.AutoSize = true;
         this._fromLabel.Location = new System.Drawing.Point(33, 54);
         this._fromLabel.Name = "_fromLabel";
         this._fromLabel.Size = new System.Drawing.Size(60, 13);
         this._fromLabel.TabIndex = 1;
         this._fromLabel.Text = "From page:";
         // 
         // SelectPagesDialog
         // 
         this.AcceptButton = this._okButton;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._cancelButton;
         this.ClientSize = new System.Drawing.Size(382, 166);
         this.Controls.Add(this._pagesGroupBox);
         this.Controls.Add(this._cancelButton);
         this.Controls.Add(this._okButton);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "SelectPagesDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Select Image Pages";
         this._pagesGroupBox.ResumeLayout(false);
         this._pagesGroupBox.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _okButton;
      private System.Windows.Forms.Button _cancelButton;
      private System.Windows.Forms.GroupBox _pagesGroupBox;
      private System.Windows.Forms.Label _fromLabel;
      private System.Windows.Forms.TextBox _fromPageTextBox;
      private System.Windows.Forms.TextBox _toPageTextBox;
      private System.Windows.Forms.Label _toPageLabel;
      private System.Windows.Forms.CheckBox _allPagesCheckBox;
      private System.Windows.Forms.CheckBox _lastPageCheckBox;
   }
}