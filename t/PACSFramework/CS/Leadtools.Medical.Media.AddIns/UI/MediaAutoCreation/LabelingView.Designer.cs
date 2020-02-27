namespace Leadtools.Medical.Media.AddIns.UI
{
   partial class LabelingView
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
         this.components = new System.ComponentModel.Container();
         this.ClientRequestedTextRadioButton = new System.Windows.Forms.RadioButton();
         this.ImageRadioButton = new System.Windows.Forms.RadioButton();
         this.CustomRadioButton = new System.Windows.Forms.RadioButton();
         this.ImageTextBox = new System.Windows.Forms.TextBox();
         this.BrowseImageButton = new System.Windows.Forms.Button();
         this.CustomTextBox = new System.Windows.Forms.TextBox();
         this.DicomTagsButton = new System.Windows.Forms.Button();
         this.DicomTagsListBox = new System.Windows.Forms.ListBox();
         this.InsertDicomTagButton = new System.Windows.Forms.Button();
         this.ValidationErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
         this.CancelLabelButton = new System.Windows.Forms.Button();
         this.OKButton = new System.Windows.Forms.Button();
         ((System.ComponentModel.ISupportInitialize)(this.ValidationErrorProvider)).BeginInit();
         this.SuspendLayout();
         // 
         // ClientRequestedTextRadioButton
         // 
         this.ClientRequestedTextRadioButton.AutoSize = true;
         this.ClientRequestedTextRadioButton.Location = new System.Drawing.Point(12, 12);
         this.ClientRequestedTextRadioButton.Name = "ClientRequestedTextRadioButton";
         this.ClientRequestedTextRadioButton.Size = new System.Drawing.Size(130, 17);
         this.ClientRequestedTextRadioButton.TabIndex = 0;
         this.ClientRequestedTextRadioButton.TabStop = true;
         this.ClientRequestedTextRadioButton.Text = "Client Requested Text";
         this.ClientRequestedTextRadioButton.UseVisualStyleBackColor = true;
         // 
         // ImageRadioButton
         // 
         this.ImageRadioButton.AutoSize = true;
         this.ImageRadioButton.Location = new System.Drawing.Point(12, 35);
         this.ImageRadioButton.Name = "ImageRadioButton";
         this.ImageRadioButton.Size = new System.Drawing.Size(54, 17);
         this.ImageRadioButton.TabIndex = 1;
         this.ImageRadioButton.TabStop = true;
         this.ImageRadioButton.Text = "Image";
         this.ImageRadioButton.UseVisualStyleBackColor = true;
         // 
         // CustomRadioButton
         // 
         this.CustomRadioButton.AutoSize = true;
         this.CustomRadioButton.Location = new System.Drawing.Point(12, 81);
         this.CustomRadioButton.Name = "CustomRadioButton";
         this.CustomRadioButton.Size = new System.Drawing.Size(60, 17);
         this.CustomRadioButton.TabIndex = 2;
         this.CustomRadioButton.TabStop = true;
         this.CustomRadioButton.Text = "Custom";
         this.CustomRadioButton.UseVisualStyleBackColor = true;
         // 
         // ImageTextBox
         // 
         this.ImageTextBox.Location = new System.Drawing.Point(31, 57);
         this.ImageTextBox.Name = "ImageTextBox";
         this.ImageTextBox.ReadOnly = true;
         this.ImageTextBox.Size = new System.Drawing.Size(259, 20);
         this.ImageTextBox.TabIndex = 3;
         // 
         // BrowseImageButton
         // 
         this.BrowseImageButton.Location = new System.Drawing.Point(296, 54);
         this.BrowseImageButton.Name = "BrowseImageButton";
         this.BrowseImageButton.Size = new System.Drawing.Size(75, 23);
         this.BrowseImageButton.TabIndex = 4;
         this.BrowseImageButton.Text = "Browse...";
         this.BrowseImageButton.UseVisualStyleBackColor = true;
         // 
         // CustomTextBox
         // 
         this.CustomTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.CustomTextBox.Location = new System.Drawing.Point(31, 104);
         this.CustomTextBox.Multiline = true;
         this.CustomTextBox.Name = "CustomTextBox";
         this.CustomTextBox.Size = new System.Drawing.Size(340, 62);
         this.CustomTextBox.TabIndex = 5;
         // 
         // DicomTagsButton
         // 
         this.DicomTagsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.DicomTagsButton.Location = new System.Drawing.Point(275, 298);
         this.DicomTagsButton.Name = "DicomTagsButton";
         this.DicomTagsButton.Size = new System.Drawing.Size(96, 23);
         this.DicomTagsButton.TabIndex = 6;
         this.DicomTagsButton.Text = "DICOM Tags>>";
         this.DicomTagsButton.UseVisualStyleBackColor = true;
         // 
         // DicomTagsListBox
         // 
         this.DicomTagsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.DicomTagsListBox.FormattingEnabled = true;
         this.DicomTagsListBox.Location = new System.Drawing.Point(31, 173);
         this.DicomTagsListBox.Name = "DicomTagsListBox";
         this.DicomTagsListBox.Size = new System.Drawing.Size(340, 121);
         this.DicomTagsListBox.TabIndex = 7;
         // 
         // InsertDicomTagButton
         // 
         this.InsertDicomTagButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.InsertDicomTagButton.Location = new System.Drawing.Point(71, 328);
         this.InsertDicomTagButton.Name = "InsertDicomTagButton";
         this.InsertDicomTagButton.Size = new System.Drawing.Size(96, 23);
         this.InsertDicomTagButton.TabIndex = 8;
         this.InsertDicomTagButton.Text = "Insert";
         this.InsertDicomTagButton.UseVisualStyleBackColor = true;
         // 
         // ValidationErrorProvider
         // 
         this.ValidationErrorProvider.ContainerControl = this;
         // 
         // CancelLabelButton
         // 
         this.CancelLabelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.CancelLabelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.CancelLabelButton.Location = new System.Drawing.Point(275, 328);
         this.CancelLabelButton.Name = "CancelLabelButton";
         this.CancelLabelButton.Size = new System.Drawing.Size(96, 23);
         this.CancelLabelButton.TabIndex = 11;
         this.CancelLabelButton.Text = "Cancel";
         this.CancelLabelButton.UseVisualStyleBackColor = true;
         // 
         // OKButton
         // 
         this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.OKButton.Location = new System.Drawing.Point(173, 328);
         this.OKButton.Name = "OKButton";
         this.OKButton.Size = new System.Drawing.Size(96, 23);
         this.OKButton.TabIndex = 12;
         this.OKButton.Text = "OK";
         this.OKButton.UseVisualStyleBackColor = true;
         // 
         // LabelingView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.CancelLabelButton;
         this.ClientSize = new System.Drawing.Size(378, 357);
         this.Controls.Add(this.OKButton);
         this.Controls.Add(this.CancelLabelButton);
         this.Controls.Add(this.InsertDicomTagButton);
         this.Controls.Add(this.DicomTagsButton);
         this.Controls.Add(this.CustomTextBox);
         this.Controls.Add(this.BrowseImageButton);
         this.Controls.Add(this.ImageTextBox);
         this.Controls.Add(this.CustomRadioButton);
         this.Controls.Add(this.ImageRadioButton);
         this.Controls.Add(this.ClientRequestedTextRadioButton);
         this.Controls.Add(this.DicomTagsListBox);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "LabelingView";
         this.ShowInTaskbar = false;
         this.Text = "Labeling";
         ((System.ComponentModel.ISupportInitialize)(this.ValidationErrorProvider)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.RadioButton ClientRequestedTextRadioButton;
      private System.Windows.Forms.RadioButton ImageRadioButton;
      private System.Windows.Forms.RadioButton CustomRadioButton;
      private System.Windows.Forms.TextBox ImageTextBox;
      private System.Windows.Forms.Button BrowseImageButton;
      private System.Windows.Forms.TextBox CustomTextBox;
      private System.Windows.Forms.Button DicomTagsButton;
      private System.Windows.Forms.ListBox DicomTagsListBox;
      private System.Windows.Forms.Button InsertDicomTagButton;
      private System.Windows.Forms.ErrorProvider ValidationErrorProvider;
      private System.Windows.Forms.Button OKButton;
      private System.Windows.Forms.Button CancelLabelButton;
   }
}