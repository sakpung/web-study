namespace Leadtools.Wizard.Pages
{
   partial class WelcomeTemplatePage
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
         this.contentPanel = new System.Windows.Forms.Panel();
         this.DescriptionLabel = new System.Windows.Forms.Label();
         this.HeaderTitleLabel = new System.Windows.Forms.Label();
         this.sidePanel = new System.Windows.Forms.Panel();
         this.RightBannerPictureBox = new System.Windows.Forms.PictureBox();
         this.contentPanel.SuspendLayout();
         this.sidePanel.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.RightBannerPictureBox)).BeginInit();
         this.SuspendLayout();
         // 
         // contentPanel
         // 
         this.contentPanel.Controls.Add(this.DescriptionLabel);
         this.contentPanel.Controls.Add(this.HeaderTitleLabel);
         this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
         this.contentPanel.Location = new System.Drawing.Point(190, 0);
         this.contentPanel.Name = "contentPanel";
         this.contentPanel.Size = new System.Drawing.Size(581, 502);
         this.contentPanel.TabIndex = 2;
         // 
         // DescriptionLabel
         // 
         this.DescriptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.DescriptionLabel.AutoEllipsis = true;
         this.DescriptionLabel.Location = new System.Drawing.Point(39, 157);
         this.DescriptionLabel.Name = "DescriptionLabel";
         this.DescriptionLabel.Size = new System.Drawing.Size(508, 121);
         this.DescriptionLabel.TabIndex = 1;
         this.DescriptionLabel.Text = "Descriptions...";
         // 
         // HeaderTitleLabel
         // 
         this.HeaderTitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.HeaderTitleLabel.AutoEllipsis = true;
         this.HeaderTitleLabel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
         this.HeaderTitleLabel.Location = new System.Drawing.Point(38, 43);
         this.HeaderTitleLabel.Name = "HeaderTitleLabel";
         this.HeaderTitleLabel.Size = new System.Drawing.Size(509, 92);
         this.HeaderTitleLabel.TabIndex = 0;
         this.HeaderTitleLabel.Text = "Enter Title Here...";
         // 
         // sidePanel
         // 
         this.sidePanel.Controls.Add(this.RightBannerPictureBox);
         this.sidePanel.Dock = System.Windows.Forms.DockStyle.Left;
         this.sidePanel.Location = new System.Drawing.Point(0, 0);
         this.sidePanel.Name = "sidePanel";
         this.sidePanel.Size = new System.Drawing.Size(190, 502);
         this.sidePanel.TabIndex = 1;
         // 
         // RightBannerPictureBox
         // 
         this.RightBannerPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
         this.RightBannerPictureBox.Location = new System.Drawing.Point(0, 0);
         this.RightBannerPictureBox.Name = "RightBannerPictureBox";
         this.RightBannerPictureBox.Size = new System.Drawing.Size(190, 502);
         this.RightBannerPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
         this.RightBannerPictureBox.TabIndex = 1;
         this.RightBannerPictureBox.TabStop = false;
         // 
         // WelcomeTemplatePage
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.contentPanel);
         this.Controls.Add(this.sidePanel);
         this.Name = "WelcomeTemplatePage";
         this.Size = new System.Drawing.Size(771, 502);
         this.contentPanel.ResumeLayout(false);
         this.sidePanel.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.RightBannerPictureBox)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Panel sidePanel;
      protected System.Windows.Forms.PictureBox RightBannerPictureBox;
      public System.Windows.Forms.Label DescriptionLabel;
      public System.Windows.Forms.Label HeaderTitleLabel;
      protected System.Windows.Forms.Panel contentPanel;
   }
}
