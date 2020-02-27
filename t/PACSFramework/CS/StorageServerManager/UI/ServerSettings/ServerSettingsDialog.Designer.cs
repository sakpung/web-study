namespace Leadtools.Demos.StorageServer.UI
{
   partial class ServerSettingsDialog
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
         this.panel1 = new System.Windows.Forms.Panel();
         this.treeView1 = new System.Windows.Forms.TreeView();
         this.PagesContainerPanel = new System.Windows.Forms.Panel();
         this.panel2 = new System.Windows.Forms.Panel();
         this.panel4 = new System.Windows.Forms.Panel();
         this.ApplyChangesButton = new System.Windows.Forms.Button();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.OKButton = new System.Windows.Forms.Button();
         this.CancelChangesButton = new System.Windows.Forms.Button();
         this.panel1.SuspendLayout();
         this.panel2.SuspendLayout();
         this.panel4.SuspendLayout();
         this.SuspendLayout();
         // 
         // panel1
         // 
         this.panel1.Controls.Add(this.treeView1);
         this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
         this.panel1.Location = new System.Drawing.Point(0, 0);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(250, 524);
         this.panel1.TabIndex = 2;
         // 
         // treeView1
         // 
         this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.treeView1.HideSelection = false;
         this.treeView1.Location = new System.Drawing.Point(8, 12);
         this.treeView1.Name = "treeView1";
         this.treeView1.Size = new System.Drawing.Size(230, 470);
         this.treeView1.TabIndex = 0;
         // 
         // PagesContainerPanel
         // 
         this.PagesContainerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.PagesContainerPanel.Location = new System.Drawing.Point(3, 12);
         this.PagesContainerPanel.Name = "PagesContainerPanel";
         this.PagesContainerPanel.Size = new System.Drawing.Size(920, 465);
         this.PagesContainerPanel.TabIndex = 0;
         // 
         // panel2
         // 
         this.panel2.Controls.Add(this.PagesContainerPanel);
         this.panel2.Controls.Add(this.panel4);
         this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panel2.Location = new System.Drawing.Point(250, 0);
         this.panel2.Name = "panel2";
         this.panel2.Size = new System.Drawing.Size(934, 524);
         this.panel2.TabIndex = 3;
         // 
         // panel4
         // 
         this.panel4.Controls.Add(this.ApplyChangesButton);
         this.panel4.Controls.Add(this.groupBox1);
         this.panel4.Controls.Add(this.OKButton);
         this.panel4.Controls.Add(this.CancelChangesButton);
         this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.panel4.Location = new System.Drawing.Point(0, 482);
         this.panel4.Name = "panel4";
         this.panel4.Size = new System.Drawing.Size(934, 42);
         this.panel4.TabIndex = 1;
         // 
         // ApplyChangesButton
         // 
         this.ApplyChangesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.ApplyChangesButton.Location = new System.Drawing.Point(848, 10);
         this.ApplyChangesButton.Name = "ApplyChangesButton";
         this.ApplyChangesButton.Size = new System.Drawing.Size(75, 23);
         this.ApplyChangesButton.TabIndex = 11;
         this.ApplyChangesButton.Text = "Apply";
         this.ApplyChangesButton.UseVisualStyleBackColor = true;
         // 
         // groupBox1
         // 
         this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
         this.groupBox1.Location = new System.Drawing.Point(0, 0);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(934, 2);
         this.groupBox1.TabIndex = 10;
         this.groupBox1.TabStop = false;
         // 
         // OKButton
         // 
         this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.OKButton.Location = new System.Drawing.Point(688, 10);
         this.OKButton.Name = "OKButton";
         this.OKButton.Size = new System.Drawing.Size(75, 23);
         this.OKButton.TabIndex = 8;
         this.OKButton.Text = "OK";
         this.OKButton.UseVisualStyleBackColor = true;
         // 
         // CancelChangesButton
         // 
         this.CancelChangesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.CancelChangesButton.CausesValidation = false;
         this.CancelChangesButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.CancelChangesButton.Location = new System.Drawing.Point(768, 10);
         this.CancelChangesButton.Name = "CancelChangesButton";
         this.CancelChangesButton.Size = new System.Drawing.Size(75, 23);
         this.CancelChangesButton.TabIndex = 7;
         this.CancelChangesButton.Text = "Cancel";
         this.CancelChangesButton.UseVisualStyleBackColor = true;
         // 
         // ServerSettingsDialog
         // 
         this.AcceptButton = this.OKButton;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
         this.CancelButton = this.CancelChangesButton;
         this.ClientSize = new System.Drawing.Size(1184, 524);
         this.Controls.Add(this.panel2);
         this.Controls.Add(this.panel1);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ServerSettingsDialog";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Server Settings Dialog";
         this.panel1.ResumeLayout(false);
         this.panel2.ResumeLayout(false);
         this.panel4.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.TreeView treeView1;
      private System.Windows.Forms.Panel PagesContainerPanel;
      private System.Windows.Forms.Panel panel2;
      private System.Windows.Forms.Panel panel4;
      private System.Windows.Forms.Button OKButton;
      private System.Windows.Forms.Button CancelChangesButton;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.Button ApplyChangesButton;
   }
}