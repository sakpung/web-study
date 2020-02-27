namespace WebViewerConfiguration
{
    partial class MissingComponents
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
            this.btnClose = new System.Windows.Forms.Button();
            this.lblErrorDetails = new System.Windows.Forms.Label();
            this.btnViewGuide = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(244, 80);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(141, 36);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblErrorDetails
            // 
            this.lblErrorDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblErrorDetails.AutoEllipsis = true;
            this.lblErrorDetails.Location = new System.Drawing.Point(12, 9);
            this.lblErrorDetails.Name = "lblErrorDetails";
            this.lblErrorDetails.Size = new System.Drawing.Size(440, 51);
            this.lblErrorDetails.TabIndex = 9;
            this.lblErrorDetails.Text = "label3";
            this.lblErrorDetails.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnViewGuide
            // 
            this.btnViewGuide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewGuide.Location = new System.Drawing.Point(79, 80);
            this.btnViewGuide.Name = "btnViewGuide";
            this.btnViewGuide.Size = new System.Drawing.Size(143, 36);
            this.btnViewGuide.TabIndex = 10;
            this.btnViewGuide.Text = "View Configuration Guide...";
            this.btnViewGuide.UseVisualStyleBackColor = true;
            this.btnViewGuide.Click += new System.EventHandler(this.btnViewGuide_Click);
            // 
            // MissingComponents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 128);
            this.Controls.Add(this.btnViewGuide);
            this.Controls.Add(this.lblErrorDetails);
            this.Controls.Add(this.btnClose);
            this.Name = "MissingComponents";
            this.Text = "MissingComponents";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblErrorDetails;
        private System.Windows.Forms.Button btnViewGuide;
    }
}