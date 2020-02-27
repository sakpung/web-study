namespace PDFFormsDemo
{
   partial class GoToPageDailog
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
         this._pageLabel = new System.Windows.Forms.Label();
         this._ofLabel = new System.Windows.Forms.Label();
         this._pagesCountLabel = new System.Windows.Forms.Label();
         this._pageNumberTextBox = new System.Windows.Forms.TextBox();
         this._okButton = new System.Windows.Forms.Button();
         this._cancelButton = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // _pageLabel
         // 
         this._pageLabel.AutoSize = true;
         this._pageLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._pageLabel.Location = new System.Drawing.Point(45, 14);
         this._pageLabel.Name = "_pageLabel";
         this._pageLabel.Size = new System.Drawing.Size(43, 19);
         this._pageLabel.TabIndex = 0;
         this._pageLabel.Text = "Page";
         // 
         // _ofLabel
         // 
         this._ofLabel.AutoSize = true;
         this._ofLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._ofLabel.Location = new System.Drawing.Point(154, 14);
         this._ofLabel.Name = "_ofLabel";
         this._ofLabel.Size = new System.Drawing.Size(23, 19);
         this._ofLabel.TabIndex = 1;
         this._ofLabel.Text = "of";
         // 
         // _pagesCountLabel
         // 
         this._pagesCountLabel.AutoSize = true;
         this._pagesCountLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._pagesCountLabel.Location = new System.Drawing.Point(183, 14);
         this._pagesCountLabel.Name = "_pagesCountLabel";
         this._pagesCountLabel.Size = new System.Drawing.Size(18, 19);
         this._pagesCountLabel.TabIndex = 2;
         this._pagesCountLabel.Text = "_";
         // 
         // _pageNumberTextBox
         // 
         this._pageNumberTextBox.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._pageNumberTextBox.Location = new System.Drawing.Point(94, 11);
         this._pageNumberTextBox.Name = "_pageNumberTextBox";
         this._pageNumberTextBox.Size = new System.Drawing.Size(54, 27);
         this._pageNumberTextBox.TabIndex = 3;
         this._pageNumberTextBox.Text = "1";
         // 
         // _okButton
         // 
         this._okButton.Location = new System.Drawing.Point(21, 44);
         this._okButton.Name = "_okButton";
         this._okButton.Size = new System.Drawing.Size(101, 23);
         this._okButton.TabIndex = 4;
         this._okButton.Text = "Ok";
         this._okButton.UseVisualStyleBackColor = true;
         this._okButton.Click += new System.EventHandler(this._okButton_Click);
         // 
         // _cancelButton
         // 
         this._cancelButton.Location = new System.Drawing.Point(128, 44);
         this._cancelButton.Name = "_cancelButton";
         this._cancelButton.Size = new System.Drawing.Size(101, 23);
         this._cancelButton.TabIndex = 5;
         this._cancelButton.Text = "Cancel";
         this._cancelButton.UseVisualStyleBackColor = true;
         this._cancelButton.Click += new System.EventHandler(this._cancelButton_Click);
         // 
         // GoToPageDailog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(247, 79);
         this.ControlBox = false;
         this.Controls.Add(this._cancelButton);
         this.Controls.Add(this._okButton);
         this.Controls.Add(this._pageNumberTextBox);
         this.Controls.Add(this._pagesCountLabel);
         this.Controls.Add(this._ofLabel);
         this.Controls.Add(this._pageLabel);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Name = "GoToPageDailog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Go To Page";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label _pageLabel;
      private System.Windows.Forms.Label _ofLabel;
      private System.Windows.Forms.Label _pagesCountLabel;
      private System.Windows.Forms.TextBox _pageNumberTextBox;
      private System.Windows.Forms.Button _okButton;
      private System.Windows.Forms.Button _cancelButton;
   }
}