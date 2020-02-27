namespace Leadtools.Wizard.Pages
{
   partial class InternalTemplatePage
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
         this.TopBannerPanel = new System.Windows.Forms.Panel();
         this.IconPictureBox = new System.Windows.Forms.PictureBox();
         this.TitleDescriptionLabel = new System.Windows.Forms.Label();
         this.TitleLabel = new System.Windows.Forms.Label();
         this.TopBannerPanel.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.IconPictureBox)).BeginInit();
         this.SuspendLayout();
         // 
         // TopBannerPanel
         // 
         this.TopBannerPanel.BackColor = System.Drawing.Color.White;
         this.TopBannerPanel.Controls.Add(this.IconPictureBox);
         this.TopBannerPanel.Controls.Add(this.TitleDescriptionLabel);
         this.TopBannerPanel.Controls.Add(this.TitleLabel);
         this.TopBannerPanel.Dock = System.Windows.Forms.DockStyle.Top;
         this.TopBannerPanel.Location = new System.Drawing.Point(0, 0);
         this.TopBannerPanel.Name = "TopBannerPanel";
         this.TopBannerPanel.Size = new System.Drawing.Size(666, 107);
         this.TopBannerPanel.TabIndex = 0;
         // 
         // IconPictureBox
         // 
         this.IconPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.IconPictureBox.Location = new System.Drawing.Point(552, 16);
         this.IconPictureBox.Name = "IconPictureBox";
         this.IconPictureBox.Size = new System.Drawing.Size(105, 60);
         this.IconPictureBox.TabIndex = 2;
         this.IconPictureBox.TabStop = false;
         // 
         // TitleDescriptionLabel
         // 
         this.TitleDescriptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.TitleDescriptionLabel.AutoEllipsis = true;
         this.TitleDescriptionLabel.Location = new System.Drawing.Point(44, 61);
         this.TitleDescriptionLabel.Name = "TitleDescriptionLabel";
         this.TitleDescriptionLabel.Size = new System.Drawing.Size(463, 39);
         this.TitleDescriptionLabel.TabIndex = 1;
         this.TitleDescriptionLabel.Text = "Enter Description Here...";
         // 
         // TitleLabel
         // 
         this.TitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.TitleLabel.AutoEllipsis = true;
         this.TitleLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
         this.TitleLabel.Location = new System.Drawing.Point(22, 16);
         this.TitleLabel.Name = "TitleLabel";
         this.TitleLabel.Size = new System.Drawing.Size(485, 38);
         this.TitleLabel.TabIndex = 0;
         this.TitleLabel.Text = "Enter Title Here";
         // 
         // InternalTemplatePage
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
         this.Controls.Add(this.TopBannerPanel);
         this.Name = "InternalTemplatePage";
         this.Size = new System.Drawing.Size(666, 494);
         this.TopBannerPanel.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.IconPictureBox)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      protected System.Windows.Forms.Panel TopBannerPanel;
      protected System.Windows.Forms.Label TitleDescriptionLabel;
      protected System.Windows.Forms.Label TitleLabel;
      protected System.Windows.Forms.PictureBox IconPictureBox;
   }
}
