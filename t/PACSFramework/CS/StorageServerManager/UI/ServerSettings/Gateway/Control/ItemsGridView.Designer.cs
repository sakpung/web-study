namespace Leadtools.Demos.StorageServer.UI
{
   partial class ItemsGridView
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemsGridView));
         this.ContainerGroupBox = new System.Windows.Forms.GroupBox();
         this.ItemsDataGridView = new System.Windows.Forms.DataGridView();
         this.MainToolStrip = new System.Windows.Forms.ToolStrip();
         this.AddItemToolStrip = new System.Windows.Forms.ToolStripButton();
         this.ModifyToolStripButton = new System.Windows.Forms.ToolStripButton();
         this.DeleteToolStripButton = new System.Windows.Forms.ToolStripButton();
         this.ContainerGroupBox.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.ItemsDataGridView)).BeginInit();
         this.MainToolStrip.SuspendLayout();
         this.SuspendLayout();
         // 
         // ContainerGroupBox
         // 
         this.ContainerGroupBox.Controls.Add(this.ItemsDataGridView);
         this.ContainerGroupBox.Controls.Add(this.MainToolStrip);
         this.ContainerGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
         this.ContainerGroupBox.Location = new System.Drawing.Point(0, 0);
         this.ContainerGroupBox.Name = "ContainerGroupBox";
         this.ContainerGroupBox.Size = new System.Drawing.Size(581, 504);
         this.ContainerGroupBox.TabIndex = 0;
         this.ContainerGroupBox.TabStop = false;
         this.ContainerGroupBox.Text = "Title";
         // 
         // ItemsDataGridView
         // 
         this.ItemsDataGridView.AllowUserToAddRows = false;
         this.ItemsDataGridView.AllowUserToDeleteRows = false;
         this.ItemsDataGridView.AllowUserToResizeColumns = false;
         this.ItemsDataGridView.AllowUserToResizeRows = false;
         this.ItemsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
         this.ItemsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.ItemsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
         this.ItemsDataGridView.Location = new System.Drawing.Point(3, 55);
         this.ItemsDataGridView.MultiSelect = false;
         this.ItemsDataGridView.Name = "ItemsDataGridView";
         this.ItemsDataGridView.ReadOnly = true;
         this.ItemsDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
         this.ItemsDataGridView.RowHeadersVisible = false;
         this.ItemsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
         this.ItemsDataGridView.Size = new System.Drawing.Size(575, 446);
         this.ItemsDataGridView.TabIndex = 1;
         // 
         // MainToolStrip
         // 
         this.MainToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
         this.MainToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
         this.MainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddItemToolStrip,
            this.ModifyToolStripButton,
            this.DeleteToolStripButton});
         this.MainToolStrip.Location = new System.Drawing.Point(3, 16);
         this.MainToolStrip.Name = "MainToolStrip";
         this.MainToolStrip.Size = new System.Drawing.Size(575, 39);
         this.MainToolStrip.Stretch = true;
         this.MainToolStrip.TabIndex = 0;
         this.MainToolStrip.Text = "toolStrip1";
         // 
         // AddItemToolStrip
         // 
         this.AddItemToolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.AddItemToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("AddItemToolStrip.Image")));
         this.AddItemToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.AddItemToolStrip.Name = "AddItemToolStrip";
         this.AddItemToolStrip.Size = new System.Drawing.Size(36, 36);
         this.AddItemToolStrip.Text = "toolStripButton1";
         // 
         // ModifyToolStripButton
         // 
         this.ModifyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.ModifyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ModifyToolStripButton.Image")));
         this.ModifyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ModifyToolStripButton.Name = "ModifyToolStripButton";
         this.ModifyToolStripButton.Size = new System.Drawing.Size(36, 36);
         this.ModifyToolStripButton.Text = "toolStripButton1";
         // 
         // DeleteToolStripButton
         // 
         this.DeleteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.DeleteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteToolStripButton.Image")));
         this.DeleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.DeleteToolStripButton.Name = "DeleteToolStripButton";
         this.DeleteToolStripButton.Size = new System.Drawing.Size(36, 36);
         this.DeleteToolStripButton.Text = "toolStripButton1";
         // 
         // ItemsGridView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.ContainerGroupBox);
         this.Name = "ItemsGridView";
         this.Size = new System.Drawing.Size(581, 504);
         this.ContainerGroupBox.ResumeLayout(false);
         this.ContainerGroupBox.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.ItemsDataGridView)).EndInit();
         this.MainToolStrip.ResumeLayout(false);
         this.MainToolStrip.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox ContainerGroupBox;
      internal System.Windows.Forms.DataGridView ItemsDataGridView;
      internal System.Windows.Forms.ToolStrip MainToolStrip;
      private System.Windows.Forms.ToolStripButton AddItemToolStrip;
      private System.Windows.Forms.ToolStripButton ModifyToolStripButton;
      private System.Windows.Forms.ToolStripButton DeleteToolStripButton;
   }
}
