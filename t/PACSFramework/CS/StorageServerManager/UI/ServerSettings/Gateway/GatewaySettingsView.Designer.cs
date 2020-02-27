namespace Leadtools.Demos.StorageServer.UI
{
   partial class GatewaySettingsView
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
         this.splitContainer1 = new System.Windows.Forms.SplitContainer();
         this.label1 = new System.Windows.Forms.Label();
         this.NumberOfTimesToUseSecondaryServerNumericUpDown = new System.Windows.Forms.NumericUpDown();
         this.GatewaysItemsGridView = new Leadtools.Demos.StorageServer.UI.ItemsGridView();
         this.RemoteServersItemsGridView = new Leadtools.Demos.StorageServer.UI.ItemsGridView();
         this.splitContainer1.Panel1.SuspendLayout();
         this.splitContainer1.Panel2.SuspendLayout();
         this.splitContainer1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.NumberOfTimesToUseSecondaryServerNumericUpDown)).BeginInit();
         this.SuspendLayout();
         // 
         // splitContainer1
         // 
         this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.splitContainer1.Location = new System.Drawing.Point(0, 0);
         this.splitContainer1.Name = "splitContainer1";
         this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
         // 
         // splitContainer1.Panel1
         // 
         this.splitContainer1.Panel1.Controls.Add(this.GatewaysItemsGridView);
         // 
         // splitContainer1.Panel2
         // 
         this.splitContainer1.Panel2.Controls.Add(this.RemoteServersItemsGridView);
         this.splitContainer1.Size = new System.Drawing.Size(672, 481);
         this.splitContainer1.SplitterDistance = 244;
         this.splitContainer1.TabIndex = 0;
         // 
         // label1
         // 
         this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(3, 486);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(287, 13);
         this.label1.TabIndex = 1;
         this.label1.Text = "Number of times to use remote server when a previous fails:";
         // 
         // NumberOfTimesToUseSecondaryServerNumericUpDown
         // 
         this.NumberOfTimesToUseSecondaryServerNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.NumberOfTimesToUseSecondaryServerNumericUpDown.Location = new System.Drawing.Point(292, 484);
         this.NumberOfTimesToUseSecondaryServerNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this.NumberOfTimesToUseSecondaryServerNumericUpDown.Name = "NumberOfTimesToUseSecondaryServerNumericUpDown";
         this.NumberOfTimesToUseSecondaryServerNumericUpDown.Size = new System.Drawing.Size(58, 20);
         this.NumberOfTimesToUseSecondaryServerNumericUpDown.TabIndex = 2;
         this.NumberOfTimesToUseSecondaryServerNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         // 
         // GatewaysItemsGridView
         // 
         this.GatewaysItemsGridView.CanAdd = true;
         this.GatewaysItemsGridView.DataMember = "";
         this.GatewaysItemsGridView.DataSource = null;
         this.GatewaysItemsGridView.Dock = System.Windows.Forms.DockStyle.Fill;
         this.GatewaysItemsGridView.Location = new System.Drawing.Point(0, 0);
         this.GatewaysItemsGridView.Name = "GatewaysItemsGridView";
         this.GatewaysItemsGridView.Size = new System.Drawing.Size(672, 244);
         this.GatewaysItemsGridView.TabIndex = 0;
         this.GatewaysItemsGridView.Title = "Gateways";
         // 
         // RemoteServersItemsGridView
         // 
         this.RemoteServersItemsGridView.CanAdd = true;
         this.RemoteServersItemsGridView.DataMember = "";
         this.RemoteServersItemsGridView.DataSource = null;
         this.RemoteServersItemsGridView.Dock = System.Windows.Forms.DockStyle.Fill;
         this.RemoteServersItemsGridView.Location = new System.Drawing.Point(0, 0);
         this.RemoteServersItemsGridView.Name = "RemoteServersItemsGridView";
         this.RemoteServersItemsGridView.Size = new System.Drawing.Size(672, 233);
         this.RemoteServersItemsGridView.TabIndex = 1;
         this.RemoteServersItemsGridView.Title = "Remote Servers";
         // 
         // GatewaySettingsView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.label1);
         this.Controls.Add(this.NumberOfTimesToUseSecondaryServerNumericUpDown);
         this.Controls.Add(this.splitContainer1);
         this.Name = "GatewaySettingsView";
         this.Size = new System.Drawing.Size(672, 509);
         this.splitContainer1.Panel1.ResumeLayout(false);
         this.splitContainer1.Panel2.ResumeLayout(false);
         this.splitContainer1.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.NumberOfTimesToUseSecondaryServerNumericUpDown)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.SplitContainer splitContainer1;
      public ItemsGridView GatewaysItemsGridView;
      public ItemsGridView RemoteServersItemsGridView;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.NumericUpDown NumberOfTimesToUseSecondaryServerNumericUpDown;
   }
}
