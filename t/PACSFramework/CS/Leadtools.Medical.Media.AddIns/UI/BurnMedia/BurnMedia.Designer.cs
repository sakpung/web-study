namespace Leadtools.Medical.Media.AddIns.UI
{
   partial class BurnMedia
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
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.CloseButton = new System.Windows.Forms.Button();
         this.BurnMediaControl = new Leadtools.Medical.Media.AddIns.UI.BurnMediaView();
         this.panel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // panel1
         // 
         this.panel1.Controls.Add(this.groupBox1);
         this.panel1.Controls.Add(this.CloseButton);
         this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.panel1.Location = new System.Drawing.Point(0, 302);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(424, 35);
         this.panel1.TabIndex = 1;
         // 
         // groupBox1
         // 
         this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
         this.groupBox1.Location = new System.Drawing.Point(0, 0);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(424, 3);
         this.groupBox1.TabIndex = 1;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "groupBox1";
         // 
         // CloseButton
         // 
         this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.CloseButton.Location = new System.Drawing.Point(344, 6);
         this.CloseButton.Name = "CloseButton";
         this.CloseButton.Size = new System.Drawing.Size(75, 23);
         this.CloseButton.TabIndex = 0;
         this.CloseButton.Text = "Close";
         this.CloseButton.UseVisualStyleBackColor = true;
         // 
         // BurnMediaControl
         // 
         this.BurnMediaControl.Dock = System.Windows.Forms.DockStyle.Fill;
         this.BurnMediaControl.Location = new System.Drawing.Point(0, 0);
         this.BurnMediaControl.Name = "BurnMediaControl";
         this.BurnMediaControl.SelectedDrive = null;
         this.BurnMediaControl.SelectedSpeed = null;
         this.BurnMediaControl.Size = new System.Drawing.Size(424, 337);
         this.BurnMediaControl.TabIndex = 0;
         // 
         // BurnMedia
         // 
         this.AcceptButton = this.CloseButton;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(424, 337);
         this.Controls.Add(this.panel1);
         this.Controls.Add(this.BurnMediaControl);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "BurnMedia";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.Text = "Burn Media";
         this.panel1.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.Button CloseButton;
      private System.Windows.Forms.GroupBox groupBox1;
      public BurnMediaView BurnMediaControl;
   }
}