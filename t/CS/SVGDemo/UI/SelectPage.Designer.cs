namespace SvgDemo
{
   partial class SelectPage
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
         this._selectPageGroupBox = new System.Windows.Forms.GroupBox();
         this._pageNumberTextBox = new System.Windows.Forms.TextBox();
         this._pageNumberLabel = new System.Windows.Forms.Label();
         this._okButton = new System.Windows.Forms.Button();
         this._cancelButton = new System.Windows.Forms.Button();
         this._selectPageGroupBox.SuspendLayout();
         this.SuspendLayout();
         // 
         // _selectPageGroupBox
         // 
         this._selectPageGroupBox.Controls.Add(this._pageNumberTextBox);
         this._selectPageGroupBox.Controls.Add(this._pageNumberLabel);
         this._selectPageGroupBox.Location = new System.Drawing.Point(12, 12);
         this._selectPageGroupBox.Name = "_selectPageGroupBox";
         this._selectPageGroupBox.Size = new System.Drawing.Size(203, 73);
         this._selectPageGroupBox.TabIndex = 1;
         this._selectPageGroupBox.TabStop = false;
         this._selectPageGroupBox.Text = "Select page to view";
         // 
         // _pageNumberTextBox
         // 
         this._pageNumberTextBox.Location = new System.Drawing.Point(87, 35);
         this._pageNumberTextBox.Name = "_pageNumberTextBox";
         this._pageNumberTextBox.Size = new System.Drawing.Size(100, 20);
         this._pageNumberTextBox.TabIndex = 1;
         this._pageNumberTextBox.TextChanged += new System.EventHandler(this._pageNumberTextBox_TextChanged);
         this._pageNumberTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._pageNumberTextBox_KeyPress);
         // 
         // _pageNumberLabel
         // 
         this._pageNumberLabel.AutoSize = true;
         this._pageNumberLabel.Location = new System.Drawing.Point(6, 37);
         this._pageNumberLabel.Name = "_pageNumberLabel";
         this._pageNumberLabel.Size = new System.Drawing.Size(75, 13);
         this._pageNumberLabel.TabIndex = 0;
         this._pageNumberLabel.Text = "Page Number:";
         // 
         // _okButton
         // 
         this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._okButton.Location = new System.Drawing.Point(221, 22);
         this._okButton.Name = "_okButton";
         this._okButton.Size = new System.Drawing.Size(75, 23);
         this._okButton.TabIndex = 2;
         this._okButton.Text = "OK";
         this._okButton.UseVisualStyleBackColor = true;
         // 
         // _cancelButton
         // 
         this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._cancelButton.Location = new System.Drawing.Point(221, 51);
         this._cancelButton.Name = "_cancelButton";
         this._cancelButton.Size = new System.Drawing.Size(75, 23);
         this._cancelButton.TabIndex = 3;
         this._cancelButton.Text = "Cancel";
         this._cancelButton.UseVisualStyleBackColor = true;
         // 
         // SelectPage
         // 
         this.AcceptButton = this._okButton;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._cancelButton;
         this.ClientSize = new System.Drawing.Size(307, 100);
         this.Controls.Add(this._cancelButton);
         this.Controls.Add(this._okButton);
         this.Controls.Add(this._selectPageGroupBox);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "SelectPage";
         this.Text = "SelectPage";
         this.Load += new System.EventHandler(this.SelectPage_Load);
         this._selectPageGroupBox.ResumeLayout(false);
         this._selectPageGroupBox.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _selectPageGroupBox;
      private System.Windows.Forms.TextBox _pageNumberTextBox;
      private System.Windows.Forms.Label _pageNumberLabel;
      private System.Windows.Forms.Button _okButton;
      private System.Windows.Forms.Button _cancelButton;
   }
}