namespace OcrDemo
{
   partial class LoadResolutionDialog
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
         this._cancelButton = new System.Windows.Forms.Button();
         this._okButton = new System.Windows.Forms.Button();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this._yResolutionTextBox = new System.Windows.Forms.TextBox();
         this._xResolutionTextBox = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         // 
         // _cancelButton
         // 
         this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._cancelButton.Location = new System.Drawing.Point(238, 50);
         this._cancelButton.Name = "_cancelButton";
         this._cancelButton.Size = new System.Drawing.Size(75, 23);
         this._cancelButton.TabIndex = 2;
         this._cancelButton.Text = "Cancel";
         this._cancelButton.UseVisualStyleBackColor = true;
         // 
         // _okButton
         // 
         this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._okButton.Location = new System.Drawing.Point(238, 21);
         this._okButton.Name = "_okButton";
         this._okButton.Size = new System.Drawing.Size(75, 23);
         this._okButton.TabIndex = 1;
         this._okButton.Text = "OK";
         this._okButton.UseVisualStyleBackColor = true;
         this._okButton.Click += new System.EventHandler(this._okButton_Click);
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this._yResolutionTextBox);
         this.groupBox1.Controls.Add(this._xResolutionTextBox);
         this.groupBox1.Controls.Add(this.label2);
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Location = new System.Drawing.Point(12, 12);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(211, 89);
         this.groupBox1.TabIndex = 3;
         this.groupBox1.TabStop = false;
         // 
         // _yResolutionTextBox
         // 
         this._yResolutionTextBox.Location = new System.Drawing.Point(88, 52);
         this._yResolutionTextBox.MaxLength = 5;
         this._yResolutionTextBox.Name = "_yResolutionTextBox";
         this._yResolutionTextBox.Size = new System.Drawing.Size(100, 20);
         this._yResolutionTextBox.TabIndex = 3;
         // 
         // _xResolutionTextBox
         // 
         this._xResolutionTextBox.Location = new System.Drawing.Point(88, 26);
         this._xResolutionTextBox.MaxLength = 5;
         this._xResolutionTextBox.Name = "_xResolutionTextBox";
         this._xResolutionTextBox.Size = new System.Drawing.Size(100, 20);
         this._xResolutionTextBox.TabIndex = 2;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(15, 55);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(67, 13);
         this.label2.TabIndex = 1;
         this.label2.Text = "Y Resolution";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(15, 29);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(67, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "X Resolution";
         // 
         // LoadResolutionDialog
         // 
         this.AcceptButton = this._okButton;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._cancelButton;
         this.ClientSize = new System.Drawing.Size(325, 117);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this._okButton);
         this.Controls.Add(this._cancelButton);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "LoadResolutionDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "PDF Load Resolution Dialog";
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _cancelButton;
      private System.Windows.Forms.Button _okButton;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.TextBox _yResolutionTextBox;
      private System.Windows.Forms.TextBox _xResolutionTextBox;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label1;
   }
}