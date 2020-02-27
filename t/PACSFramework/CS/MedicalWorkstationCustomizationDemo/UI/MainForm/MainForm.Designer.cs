namespace Leadtools.Demos.Workstation.UI
{
   partial class MainForm
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
         this.DescriptionPanel = new Leadtools.Medical.Workstation.UI.AutoHidePanel();
         this.label1 = new System.Windows.Forms.Label();
         this.DescriptionPanel.SuspendLayout();
         this.SuspendLayout();
         // 
         // DescriptionPanel
         // 
         this.DescriptionPanel.AutoHide = false;
         this.DescriptionPanel.BackColor = System.Drawing.Color.Black;
         this.DescriptionPanel.Controls.Add(this.label1);
         this.DescriptionPanel.Dock = System.Windows.Forms.DockStyle.Left;
         this.DescriptionPanel.EnableResizing = false;
         this.DescriptionPanel.Location = new System.Drawing.Point(0, 0);
         this.DescriptionPanel.Name = "DescriptionPanel";
         this.DescriptionPanel.Size = new System.Drawing.Size(201, 618);
         this.DescriptionPanel.State = Leadtools.Medical.Workstation.UI.AutoHidePanelState.Expanded;
         this.DescriptionPanel.StickPinAttached = ((System.Drawing.Bitmap)(resources.GetObject("DescriptionPanel.StickPinAttached")));
         this.DescriptionPanel.StickPinUnattached = ((System.Drawing.Bitmap)(resources.GetObject("DescriptionPanel.StickPinUnattached")));
         this.DescriptionPanel.TabIndex = 0;
         this.DescriptionPanel.TopLevel = false;
         // 
         // label1
         // 
         this.label1.BackColor = System.Drawing.Color.DarkGray;
         this.label1.Dock = System.Windows.Forms.DockStyle.Top;
         this.label1.Location = new System.Drawing.Point(0, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(201, 20);
         this.label1.TabIndex = 3;
         this.label1.Text = "Description";
         this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(898, 618);
         this.Controls.Add(this.DescriptionPanel);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "MainForm";
         this.Text = "Workstation Customization Demo";
         this.DescriptionPanel.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      public Leadtools.Medical.Workstation.UI.AutoHidePanel DescriptionPanel;
      private System.Windows.Forms.Label label1;

   }
}