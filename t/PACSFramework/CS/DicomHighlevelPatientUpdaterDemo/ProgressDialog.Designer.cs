namespace DicomDemo
{
    partial class ProgressDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgressDialog));
            this.ProgressLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.CancelOperationButton = new System.Windows.Forms.Button();
            this.ProgressInfoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ProgressLabel
            // 
            resources.ApplyResources(this.ProgressLabel, "ProgressLabel");
            this.ProgressLabel.Name = "ProgressLabel";
            // 
            // progressBar
            // 
            resources.ApplyResources(this.progressBar, "progressBar");
            this.progressBar.Name = "progressBar";
            // 
            // CancelOperationButton
            // 
            this.CancelOperationButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.CancelOperationButton, "CancelOperationButton");
            this.CancelOperationButton.Name = "CancelOperationButton";
            this.CancelOperationButton.UseVisualStyleBackColor = true;
            this.CancelOperationButton.Click += new System.EventHandler(this.CancelOperationButton_Click);
            // 
            // ProgressInfoLabel
            // 
            resources.ApplyResources(this.ProgressInfoLabel, "ProgressInfoLabel");
            this.ProgressInfoLabel.Name = "ProgressInfoLabel";
            // 
            // ProgressDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.ProgressInfoLabel);
            this.Controls.Add(this.CancelOperationButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.ProgressLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ProgressDialog";
            this.Load += new System.EventHandler(this.ProgressDialog_Load);
            this.Shown += new System.EventHandler(this.ProgressDialog_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ProgressLabel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label ProgressInfoLabel;
        private System.Windows.Forms.Button CancelOperationButton;
    }
}