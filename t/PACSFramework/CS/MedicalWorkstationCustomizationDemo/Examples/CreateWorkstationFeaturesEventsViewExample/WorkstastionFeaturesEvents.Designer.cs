namespace Leadtools.Demos.Workstation.Customized
{
   partial class WorkstastionFeaturesEventsView
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
         this.EventsListView = new System.Windows.Forms.ListView();
         this.FeatureIdColumnHeader = new System.Windows.Forms.ColumnHeader();
         this.PublisherColumnHeader = new System.Windows.Forms.ColumnHeader();
         this.StartButton = new System.Windows.Forms.Button();
         this.StopButton = new System.Windows.Forms.Button();
         this.CloseButton = new System.Windows.Forms.Button();
         this.ClearButton = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // EventsListView
         // 
         this.EventsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.EventsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FeatureIdColumnHeader,
            this.PublisherColumnHeader});
         this.EventsListView.Location = new System.Drawing.Point(5, 5);
         this.EventsListView.MultiSelect = false;
         this.EventsListView.Name = "EventsListView";
         this.EventsListView.Size = new System.Drawing.Size(547, 376);
         this.EventsListView.TabIndex = 0;
         this.EventsListView.UseCompatibleStateImageBehavior = false;
         this.EventsListView.View = System.Windows.Forms.View.Details;
         // 
         // FeatureIdColumnHeader
         // 
         this.FeatureIdColumnHeader.Text = "Feature ID";
         this.FeatureIdColumnHeader.Width = 186;
         // 
         // PublisherColumnHeader
         // 
         this.PublisherColumnHeader.Text = "Publisher";
         this.PublisherColumnHeader.Width = 346;
         // 
         // StartButton
         // 
         this.StartButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.StartButton.Location = new System.Drawing.Point(5, 387);
         this.StartButton.Name = "StartButton";
         this.StartButton.Size = new System.Drawing.Size(75, 23);
         this.StartButton.TabIndex = 1;
         this.StartButton.Text = "Start";
         this.StartButton.UseVisualStyleBackColor = true;
         // 
         // StopButton
         // 
         this.StopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.StopButton.Location = new System.Drawing.Point(86, 387);
         this.StopButton.Name = "StopButton";
         this.StopButton.Size = new System.Drawing.Size(75, 23);
         this.StopButton.TabIndex = 2;
         this.StopButton.Text = "Stop";
         this.StopButton.UseVisualStyleBackColor = true;
         // 
         // CloseButton
         // 
         this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.CloseButton.Location = new System.Drawing.Point(473, 387);
         this.CloseButton.Name = "CloseButton";
         this.CloseButton.Size = new System.Drawing.Size(75, 23);
         this.CloseButton.TabIndex = 3;
         this.CloseButton.Text = "Close";
         this.CloseButton.UseVisualStyleBackColor = true;
         // 
         // ClearButton
         // 
         this.ClearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.ClearButton.Location = new System.Drawing.Point(167, 387);
         this.ClearButton.Name = "ClearButton";
         this.ClearButton.Size = new System.Drawing.Size(75, 23);
         this.ClearButton.TabIndex = 4;
         this.ClearButton.Text = "Clear";
         this.ClearButton.UseVisualStyleBackColor = true;
         // 
         // WorkstastionFeaturesEventsView
         // 
         this.AcceptButton = this.CloseButton;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(557, 416);
         this.Controls.Add(this.ClearButton);
         this.Controls.Add(this.CloseButton);
         this.Controls.Add(this.StopButton);
         this.Controls.Add(this.StartButton);
         this.Controls.Add(this.EventsListView);
         this.Name = "WorkstastionFeaturesEventsView";
         this.ShowIcon = false;
         this.Text = "Workstastion Features Events";
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.ListView EventsListView;
      private System.Windows.Forms.Button StartButton;
      private System.Windows.Forms.Button StopButton;
      private System.Windows.Forms.Button CloseButton;
      private System.Windows.Forms.Button ClearButton;
      private System.Windows.Forms.ColumnHeader FeatureIdColumnHeader;
      private System.Windows.Forms.ColumnHeader PublisherColumnHeader;
   }
}