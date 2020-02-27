namespace PDFFileDemo
{
   partial class DocumentPropertiesControl
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
         this._propertiesGroupBox = new System.Windows.Forms.GroupBox();
         this._modifiedTextBox = new System.Windows.Forms.TextBox();
         this._createdTextBox = new System.Windows.Forms.TextBox();
         this._modifiedDateTimePicker = new System.Windows.Forms.DateTimePicker();
         this._createdDateTimePicker = new System.Windows.Forms.DateTimePicker();
         this._modifiedLabel = new System.Windows.Forms.Label();
         this._createdLabel = new System.Windows.Forms.Label();
         this._producerTextBox = new System.Windows.Forms.TextBox();
         this._producerLabel = new System.Windows.Forms.Label();
         this._creatorTextBox = new System.Windows.Forms.TextBox();
         this._creatorLabel = new System.Windows.Forms.Label();
         this._keywordsTextBox = new System.Windows.Forms.TextBox();
         this._keywordsLabel = new System.Windows.Forms.Label();
         this._subjectTextBox = new System.Windows.Forms.TextBox();
         this._subjectLabel = new System.Windows.Forms.Label();
         this._authorTextBox = new System.Windows.Forms.TextBox();
         this._authorLabel = new System.Windows.Forms.Label();
         this._titleTextBox = new System.Windows.Forms.TextBox();
         this._titleLabel = new System.Windows.Forms.Label();
         this._propertiesGroupBox.SuspendLayout();
         this.SuspendLayout();
         // 
         // _propertiesGroupBox
         // 
         this._propertiesGroupBox.Controls.Add(this._modifiedTextBox);
         this._propertiesGroupBox.Controls.Add(this._createdTextBox);
         this._propertiesGroupBox.Controls.Add(this._modifiedDateTimePicker);
         this._propertiesGroupBox.Controls.Add(this._createdDateTimePicker);
         this._propertiesGroupBox.Controls.Add(this._modifiedLabel);
         this._propertiesGroupBox.Controls.Add(this._createdLabel);
         this._propertiesGroupBox.Controls.Add(this._producerTextBox);
         this._propertiesGroupBox.Controls.Add(this._producerLabel);
         this._propertiesGroupBox.Controls.Add(this._creatorTextBox);
         this._propertiesGroupBox.Controls.Add(this._creatorLabel);
         this._propertiesGroupBox.Controls.Add(this._keywordsTextBox);
         this._propertiesGroupBox.Controls.Add(this._keywordsLabel);
         this._propertiesGroupBox.Controls.Add(this._subjectTextBox);
         this._propertiesGroupBox.Controls.Add(this._subjectLabel);
         this._propertiesGroupBox.Controls.Add(this._authorTextBox);
         this._propertiesGroupBox.Controls.Add(this._authorLabel);
         this._propertiesGroupBox.Controls.Add(this._titleTextBox);
         this._propertiesGroupBox.Controls.Add(this._titleLabel);
         this._propertiesGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
         this._propertiesGroupBox.Location = new System.Drawing.Point(0, 0);
         this._propertiesGroupBox.Name = "_propertiesGroupBox";
         this._propertiesGroupBox.Size = new System.Drawing.Size(300, 246);
         this._propertiesGroupBox.TabIndex = 0;
         this._propertiesGroupBox.TabStop = false;
         this._propertiesGroupBox.Text = "Document properties:";
         // 
         // _modifiedTextBox
         // 
         this._modifiedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this._modifiedTextBox.Location = new System.Drawing.Point(79, 209);
         this._modifiedTextBox.Name = "_modifiedTextBox";
         this._modifiedTextBox.Size = new System.Drawing.Size(206, 20);
         this._modifiedTextBox.TabIndex = 19;
         // 
         // _createdTextBox
         // 
         this._createdTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this._createdTextBox.Location = new System.Drawing.Point(79, 183);
         this._createdTextBox.Name = "_createdTextBox";
         this._createdTextBox.Size = new System.Drawing.Size(206, 20);
         this._createdTextBox.TabIndex = 18;
         // 
         // _modifiedDateTimePicker
         // 
         this._modifiedDateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this._modifiedDateTimePicker.CustomFormat = "MM/dd/yyyy - hh:mm:ss tt";
         this._modifiedDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
         this._modifiedDateTimePicker.Location = new System.Drawing.Point(79, 209);
         this._modifiedDateTimePicker.Name = "_modifiedDateTimePicker";
         this._modifiedDateTimePicker.Size = new System.Drawing.Size(206, 20);
         this._modifiedDateTimePicker.TabIndex = 17;
         // 
         // _createdDateTimePicker
         // 
         this._createdDateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this._createdDateTimePicker.CustomFormat = "MM/dd/yyyy - hh:mm:ss tt";
         this._createdDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
         this._createdDateTimePicker.Location = new System.Drawing.Point(79, 183);
         this._createdDateTimePicker.Name = "_createdDateTimePicker";
         this._createdDateTimePicker.Size = new System.Drawing.Size(206, 20);
         this._createdDateTimePicker.TabIndex = 16;
         // 
         // _modifiedLabel
         // 
         this._modifiedLabel.AutoSize = true;
         this._modifiedLabel.Location = new System.Drawing.Point(21, 212);
         this._modifiedLabel.Name = "_modifiedLabel";
         this._modifiedLabel.Size = new System.Drawing.Size(50, 13);
         this._modifiedLabel.TabIndex = 14;
         this._modifiedLabel.Text = "Modified:";
         // 
         // _createdLabel
         // 
         this._createdLabel.AutoSize = true;
         this._createdLabel.Location = new System.Drawing.Point(24, 186);
         this._createdLabel.Name = "_createdLabel";
         this._createdLabel.Size = new System.Drawing.Size(47, 13);
         this._createdLabel.TabIndex = 12;
         this._createdLabel.Text = "Created:";
         // 
         // _producerTextBox
         // 
         this._producerTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this._producerTextBox.Location = new System.Drawing.Point(79, 157);
         this._producerTextBox.Name = "_producerTextBox";
         this._producerTextBox.Size = new System.Drawing.Size(206, 20);
         this._producerTextBox.TabIndex = 11;
         // 
         // _producerLabel
         // 
         this._producerLabel.AutoSize = true;
         this._producerLabel.Location = new System.Drawing.Point(18, 160);
         this._producerLabel.Name = "_producerLabel";
         this._producerLabel.Size = new System.Drawing.Size(53, 13);
         this._producerLabel.TabIndex = 10;
         this._producerLabel.Text = "Producer:";
         // 
         // _creatorTextBox
         // 
         this._creatorTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this._creatorTextBox.Location = new System.Drawing.Point(79, 131);
         this._creatorTextBox.Name = "_creatorTextBox";
         this._creatorTextBox.Size = new System.Drawing.Size(206, 20);
         this._creatorTextBox.TabIndex = 9;
         // 
         // _creatorLabel
         // 
         this._creatorLabel.AutoSize = true;
         this._creatorLabel.Location = new System.Drawing.Point(27, 134);
         this._creatorLabel.Name = "_creatorLabel";
         this._creatorLabel.Size = new System.Drawing.Size(44, 13);
         this._creatorLabel.TabIndex = 8;
         this._creatorLabel.Text = "Creator:";
         // 
         // _keywordsTextBox
         // 
         this._keywordsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this._keywordsTextBox.Location = new System.Drawing.Point(79, 105);
         this._keywordsTextBox.Name = "_keywordsTextBox";
         this._keywordsTextBox.Size = new System.Drawing.Size(206, 20);
         this._keywordsTextBox.TabIndex = 7;
         // 
         // _keywordsLabel
         // 
         this._keywordsLabel.AutoSize = true;
         this._keywordsLabel.Location = new System.Drawing.Point(15, 108);
         this._keywordsLabel.Name = "_keywordsLabel";
         this._keywordsLabel.Size = new System.Drawing.Size(56, 13);
         this._keywordsLabel.TabIndex = 6;
         this._keywordsLabel.Text = "Keywords:";
         // 
         // _subjectTextBox
         // 
         this._subjectTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this._subjectTextBox.Location = new System.Drawing.Point(79, 79);
         this._subjectTextBox.Name = "_subjectTextBox";
         this._subjectTextBox.Size = new System.Drawing.Size(206, 20);
         this._subjectTextBox.TabIndex = 5;
         // 
         // _subjectLabel
         // 
         this._subjectLabel.AutoSize = true;
         this._subjectLabel.Location = new System.Drawing.Point(25, 82);
         this._subjectLabel.Name = "_subjectLabel";
         this._subjectLabel.Size = new System.Drawing.Size(46, 13);
         this._subjectLabel.TabIndex = 4;
         this._subjectLabel.Text = "Subject:";
         // 
         // _authorTextBox
         // 
         this._authorTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this._authorTextBox.Location = new System.Drawing.Point(79, 53);
         this._authorTextBox.Name = "_authorTextBox";
         this._authorTextBox.Size = new System.Drawing.Size(206, 20);
         this._authorTextBox.TabIndex = 3;
         // 
         // _authorLabel
         // 
         this._authorLabel.AutoSize = true;
         this._authorLabel.Location = new System.Drawing.Point(30, 56);
         this._authorLabel.Name = "_authorLabel";
         this._authorLabel.Size = new System.Drawing.Size(41, 13);
         this._authorLabel.TabIndex = 2;
         this._authorLabel.Text = "Author:";
         // 
         // _titleTextBox
         // 
         this._titleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this._titleTextBox.Location = new System.Drawing.Point(79, 27);
         this._titleTextBox.Name = "_titleTextBox";
         this._titleTextBox.Size = new System.Drawing.Size(206, 20);
         this._titleTextBox.TabIndex = 1;
         // 
         // _titleLabel
         // 
         this._titleLabel.AutoSize = true;
         this._titleLabel.Location = new System.Drawing.Point(41, 30);
         this._titleLabel.Name = "_titleLabel";
         this._titleLabel.Size = new System.Drawing.Size(30, 13);
         this._titleLabel.TabIndex = 0;
         this._titleLabel.Text = "Title:";
         // 
         // DocumentPropertiesControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this._propertiesGroupBox);
         this.Name = "DocumentPropertiesControl";
         this.Size = new System.Drawing.Size(300, 246);
         this._propertiesGroupBox.ResumeLayout(false);
         this._propertiesGroupBox.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _propertiesGroupBox;
      private System.Windows.Forms.Label _titleLabel;
      private System.Windows.Forms.Label _createdLabel;
      private System.Windows.Forms.TextBox _producerTextBox;
      private System.Windows.Forms.Label _producerLabel;
      private System.Windows.Forms.TextBox _creatorTextBox;
      private System.Windows.Forms.Label _creatorLabel;
      private System.Windows.Forms.TextBox _keywordsTextBox;
      private System.Windows.Forms.Label _keywordsLabel;
      private System.Windows.Forms.TextBox _subjectTextBox;
      private System.Windows.Forms.Label _subjectLabel;
      private System.Windows.Forms.TextBox _authorTextBox;
      private System.Windows.Forms.Label _authorLabel;
      private System.Windows.Forms.TextBox _titleTextBox;
      private System.Windows.Forms.Label _modifiedLabel;
      private System.Windows.Forms.DateTimePicker _createdDateTimePicker;
      private System.Windows.Forms.DateTimePicker _modifiedDateTimePicker;
      private System.Windows.Forms.TextBox _modifiedTextBox;
      private System.Windows.Forms.TextBox _createdTextBox;
   }
}
