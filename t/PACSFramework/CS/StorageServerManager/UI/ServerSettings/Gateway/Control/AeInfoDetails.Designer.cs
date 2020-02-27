namespace Leadtools.Demos.StorageServer.UI
{
   partial class AeInfoDetails
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
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.AETitleTextBox = new System.Windows.Forms.TextBox();
         this.SecureCheckBox = new System.Windows.Forms.CheckBox();
         this.PortNumericUpDown = new System.Windows.Forms.NumericUpDown();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.RejectChangesButton = new System.Windows.Forms.Button();
         this.ConfirmChangesButton = new System.Windows.Forms.Button();
         this.IpAddressComboBox = new System.Windows.Forms.ComboBox();
         this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
         ((System.ComponentModel.ISupportInitialize)(this.PortNumericUpDown)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(12, 13);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(47, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "AE Title:";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(12, 40);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(48, 13);
         this.label2.TabIndex = 2;
         this.label2.Text = "Address:";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(12, 68);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(29, 13);
         this.label3.TabIndex = 4;
         this.label3.Text = "Port:";
         // 
         // AETitleTextBox
         // 
         this.AETitleTextBox.Location = new System.Drawing.Point(66, 9);
         this.AETitleTextBox.Name = "AETitleTextBox";
         this.AETitleTextBox.Size = new System.Drawing.Size(187, 20);
         this.AETitleTextBox.TabIndex = 1;
         // 
         // SecureCheckBox
         // 
         this.SecureCheckBox.AutoSize = true;
         this.SecureCheckBox.Location = new System.Drawing.Point(169, 66);
         this.SecureCheckBox.Name = "SecureCheckBox";
         this.SecureCheckBox.Size = new System.Drawing.Size(89, 17);
         this.SecureCheckBox.TabIndex = 6;
         this.SecureCheckBox.Text = "Secure (TLS)";
         this.SecureCheckBox.UseVisualStyleBackColor = true;
         // 
         // PortNumericUpDown
         // 
         this.PortNumericUpDown.Location = new System.Drawing.Point(66, 64);
         this.PortNumericUpDown.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
         this.PortNumericUpDown.Name = "PortNumericUpDown";
         this.PortNumericUpDown.Size = new System.Drawing.Size(64, 20);
         this.PortNumericUpDown.TabIndex = 5;
         // 
         // groupBox1
         // 
         this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox1.Location = new System.Drawing.Point(-34, 89);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(319, 3);
         this.groupBox1.TabIndex = 8;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "groupBox1";
         // 
         // RejectChangesButton
         // 
         this.RejectChangesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.RejectChangesButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.RejectChangesButton.Location = new System.Drawing.Point(178, 98);
         this.RejectChangesButton.Name = "RejectChangesButton";
         this.RejectChangesButton.Size = new System.Drawing.Size(75, 23);
         this.RejectChangesButton.TabIndex = 8;
         this.RejectChangesButton.Text = "Cancel";
         this.RejectChangesButton.UseVisualStyleBackColor = true;
         // 
         // ConfirmChangesButton
         // 
         this.ConfirmChangesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.ConfirmChangesButton.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.ConfirmChangesButton.Location = new System.Drawing.Point(97, 98);
         this.ConfirmChangesButton.Name = "ConfirmChangesButton";
         this.ConfirmChangesButton.Size = new System.Drawing.Size(75, 23);
         this.ConfirmChangesButton.TabIndex = 7;
         this.ConfirmChangesButton.Text = "OK";
         this.ConfirmChangesButton.UseVisualStyleBackColor = true;
         // 
         // IpAddressComboBox
         // 
         this.IpAddressComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.IpAddressComboBox.FormattingEnabled = true;
         this.IpAddressComboBox.Location = new System.Drawing.Point(66, 36);
         this.IpAddressComboBox.Name = "IpAddressComboBox";
         this.IpAddressComboBox.Size = new System.Drawing.Size(187, 21);
         this.IpAddressComboBox.TabIndex = 3;
         // 
         // errorProvider1
         // 
         this.errorProvider1.ContainerControl = this;
         // 
         // AeInfoDetails
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(259, 130);
         this.ControlBox = false;
         this.Controls.Add(this.IpAddressComboBox);
         this.Controls.Add(this.ConfirmChangesButton);
         this.Controls.Add(this.RejectChangesButton);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.PortNumericUpDown);
         this.Controls.Add(this.SecureCheckBox);
         this.Controls.Add(this.AETitleTextBox);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Name = "AeInfoDetails";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "AeInfoDetails";
         ((System.ComponentModel.ISupportInitialize)(this.PortNumericUpDown)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.TextBox AETitleTextBox;
      private System.Windows.Forms.CheckBox SecureCheckBox;
      private System.Windows.Forms.NumericUpDown PortNumericUpDown;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.Button RejectChangesButton;
      private System.Windows.Forms.Button ConfirmChangesButton;
      private System.Windows.Forms.ComboBox IpAddressComboBox;
      private System.Windows.Forms.ErrorProvider errorProvider1;
   }
}