namespace ModalityWorklistWCFDemo.UI.Pages
{
    partial class IntroductionPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
           System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IntroductionPage));
           ((System.ComponentModel.ISupportInitialize)(this.RightBannerPictureBox)).BeginInit();
           this.contentPanel.SuspendLayout();
           this.SuspendLayout();
           // 
           // DescriptionLabel
           // 
           this.DescriptionLabel.Size = new System.Drawing.Size(435, 270);
           this.DescriptionLabel.Text = resources.GetString("DescriptionLabel.Text");
           // 
           // HeaderTitleLabel
           // 
           this.HeaderTitleLabel.Text = "Modality Worklist WCF Demo Wizard";
           // 
           // IntroductionPage
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.Name = "IntroductionPage";
           ((System.ComponentModel.ISupportInitialize)(this.RightBannerPictureBox)).EndInit();
           this.contentPanel.ResumeLayout(false);
           this.ResumeLayout(false);

        }

        #endregion
    }
}
