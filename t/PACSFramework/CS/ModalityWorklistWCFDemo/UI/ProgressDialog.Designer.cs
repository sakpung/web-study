namespace ModalityWorklistWCFDemo.UI
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
            this.labelProgressInfo = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelProgressInfo
            // 
            this.labelProgressInfo.AutoSize = true;
            this.labelProgressInfo.Location = new System.Drawing.Point(12, 29);
            this.labelProgressInfo.Name = "labelProgressInfo";
            this.labelProgressInfo.Size = new System.Drawing.Size(35, 13);
            this.labelProgressInfo.TabIndex = 0;
            this.labelProgressInfo.Text = "label1";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(15, 46);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(363, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 1;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(302, 76);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // ProgressDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 115);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.labelProgressInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProgressDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ProgressDialog";
            this.Shown += new System.EventHandler(this.ProgressDialog_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelProgressInfo;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button buttonCancel;
    }
}