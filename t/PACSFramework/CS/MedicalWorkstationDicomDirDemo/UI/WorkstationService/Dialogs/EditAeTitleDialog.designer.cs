namespace Leadtools.Demos.Workstation
{
    partial class EditAeTitleDialog
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
           this.AETitleTextBox = new System.Windows.Forms.TextBox();
           this.AeTitleLabel = new System.Windows.Forms.Label();
           this.HostNameTextBox = new System.Windows.Forms.TextBox();
           this.PortLabel = new System.Windows.Forms.Label();
           this.PortNumericUpDown = new System.Windows.Forms.NumericUpDown();
           this.SecurePortNumericUpDown = new System.Windows.Forms.NumericUpDown();
           this.SecurePortLabel = new System.Windows.Forms.Label();
           this.OkButton = new System.Windows.Forms.Button();
           this.CancelDialogButton = new System.Windows.Forms.Button();
           this.AeErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
           this.label1 = new System.Windows.Forms.Label();
           ((System.ComponentModel.ISupportInitialize)(this.PortNumericUpDown)).BeginInit();
           ((System.ComponentModel.ISupportInitialize)(this.SecurePortNumericUpDown)).BeginInit();
           ((System.ComponentModel.ISupportInitialize)(this.AeErrorProvider)).BeginInit();
           this.SuspendLayout();
           // 
           // AETitleTextBox
           // 
           this.AETitleTextBox.Location = new System.Drawing.Point(107, 12);
           this.AETitleTextBox.Name = "AETitleTextBox";
           this.AETitleTextBox.Size = new System.Drawing.Size(191, 20);
           this.AETitleTextBox.TabIndex = 1;
           this.AETitleTextBox.TextChanged += new System.EventHandler(this.AETitle_TextChanged);
           // 
           // AeTitleLabel
           // 
           this.AeTitleLabel.AutoSize = true;
           this.AeTitleLabel.Location = new System.Drawing.Point(12, 13);
           this.AeTitleLabel.Name = "AeTitleLabel";
           this.AeTitleLabel.Size = new System.Drawing.Size(47, 13);
           this.AeTitleLabel.TabIndex = 0;
           this.AeTitleLabel.Text = "AE Title:";
           // 
           // HostNameTextBox
           // 
           this.HostNameTextBox.Location = new System.Drawing.Point(107, 38);
           this.HostNameTextBox.Name = "HostNameTextBox";
           this.HostNameTextBox.Size = new System.Drawing.Size(191, 20);
           this.HostNameTextBox.TabIndex = 3;
           // 
           // PortLabel
           // 
           this.PortLabel.AutoSize = true;
           this.PortLabel.Location = new System.Drawing.Point(12, 66);
           this.PortLabel.Name = "PortLabel";
           this.PortLabel.Size = new System.Drawing.Size(29, 13);
           this.PortLabel.TabIndex = 6;
           this.PortLabel.Text = "Port:";
           // 
           // PortNumericUpDown
           // 
           this.PortNumericUpDown.Location = new System.Drawing.Point(107, 64);
           this.PortNumericUpDown.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
           this.PortNumericUpDown.Name = "PortNumericUpDown";
           this.PortNumericUpDown.Size = new System.Drawing.Size(54, 20);
           this.PortNumericUpDown.TabIndex = 7;
           // 
           // SecurePortNumericUpDown
           // 
           this.SecurePortNumericUpDown.Location = new System.Drawing.Point(107, 90);
           this.SecurePortNumericUpDown.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
           this.SecurePortNumericUpDown.Name = "SecurePortNumericUpDown";
           this.SecurePortNumericUpDown.Size = new System.Drawing.Size(54, 20);
           this.SecurePortNumericUpDown.TabIndex = 9;
           // 
           // SecurePortLabel
           // 
           this.SecurePortLabel.AutoSize = true;
           this.SecurePortLabel.Location = new System.Drawing.Point(12, 97);
           this.SecurePortLabel.Name = "SecurePortLabel";
           this.SecurePortLabel.Size = new System.Drawing.Size(66, 13);
           this.SecurePortLabel.TabIndex = 8;
           this.SecurePortLabel.Text = "Secure Port:";
           // 
           // OkButton
           // 
           this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
           this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
           this.OkButton.Location = new System.Drawing.Point(141, 129);
           this.OkButton.Name = "OkButton";
           this.OkButton.Size = new System.Drawing.Size(75, 23);
           this.OkButton.TabIndex = 10;
           this.OkButton.Text = "OK";
           this.OkButton.UseVisualStyleBackColor = true;
           // 
           // CancelDialogButton
           // 
           this.CancelDialogButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
           this.CancelDialogButton.CausesValidation = false;
           this.CancelDialogButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
           this.CancelDialogButton.Location = new System.Drawing.Point(222, 129);
           this.CancelDialogButton.Name = "CancelDialogButton";
           this.CancelDialogButton.Size = new System.Drawing.Size(75, 23);
           this.CancelDialogButton.TabIndex = 11;
           this.CancelDialogButton.Text = "Cancel";
           this.CancelDialogButton.UseVisualStyleBackColor = true;
           // 
           // AeErrorProvider
           // 
           this.AeErrorProvider.ContainerControl = this;
           // 
           // label1
           // 
           this.label1.AutoSize = true;
           this.label1.Location = new System.Drawing.Point(12, 38);
           this.label1.Name = "label1";
           this.label1.Size = new System.Drawing.Size(88, 13);
           this.label1.TabIndex = 12;
           this.label1.Text = "Host/IP Address:";
           // 
           // EditAeTitleDialog
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.CancelButton = this.CancelDialogButton;
           this.ClientSize = new System.Drawing.Size(304, 157);
           this.Controls.Add(this.label1);
           this.Controls.Add(this.CancelDialogButton);
           this.Controls.Add(this.OkButton);
           this.Controls.Add(this.SecurePortNumericUpDown);
           this.Controls.Add(this.SecurePortLabel);
           this.Controls.Add(this.PortNumericUpDown);
           this.Controls.Add(this.PortLabel);
           this.Controls.Add(this.HostNameTextBox);
           this.Controls.Add(this.AETitleTextBox);
           this.Controls.Add(this.AeTitleLabel);
           this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
           this.MaximizeBox = false;
           this.MinimizeBox = false;
           this.Name = "EditAeTitleDialog";
           this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
           this.Text = "EditAeTitleDialog";
           this.Load += new System.EventHandler(this.EditAeTitleDialog_Load);
           this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditAeTitleDialog_FormClosing);
           ((System.ComponentModel.ISupportInitialize)(this.PortNumericUpDown)).EndInit();
           ((System.ComponentModel.ISupportInitialize)(this.SecurePortNumericUpDown)).EndInit();
           ((System.ComponentModel.ISupportInitialize)(this.AeErrorProvider)).EndInit();
           this.ResumeLayout(false);
           this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.TextBox AETitleTextBox;
        protected System.Windows.Forms.Label AeTitleLabel;
        protected System.Windows.Forms.TextBox HostNameTextBox;
        protected System.Windows.Forms.Label PortLabel;
        protected System.Windows.Forms.NumericUpDown PortNumericUpDown;
        protected System.Windows.Forms.NumericUpDown SecurePortNumericUpDown;
        protected System.Windows.Forms.Label SecurePortLabel;
        protected System.Windows.Forms.Button OkButton;
        protected System.Windows.Forms.Button CancelDialogButton;
        protected System.Windows.Forms.ErrorProvider AeErrorProvider;
        protected System.Windows.Forms.Label label1;

    }
}