namespace Leadtools.Medical.Forwarder.AddIn.Dialogs
{
   partial class ConfigureDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigureDialog));
         this.panel1 = new System.Windows.Forms.Panel();
         this.button2 = new System.Windows.Forms.Button();
         this.button1 = new System.Windows.Forms.Button();
         this.forwardManager = new Leadtools.Medical.Winforms.Forwarder.ForwardManagerConfigurationView();
         this.panel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // panel1
         // 
         this.panel1.Controls.Add(this.button2);
         this.panel1.Controls.Add(this.button1);
         this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.panel1.Location = new System.Drawing.Point(0, 376);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(594, 45);
         this.panel1.TabIndex = 2;
         // 
         // button2
         // 
         this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.button2.Location = new System.Drawing.Point(426, 10);
         this.button2.Name = "button2";
         this.button2.Size = new System.Drawing.Size(75, 23);
         this.button2.TabIndex = 1;
         this.button2.Text = "&OK";
         this.button2.UseVisualStyleBackColor = true;
         // 
         // button1
         // 
         this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.button1.Location = new System.Drawing.Point(507, 10);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(75, 23);
         this.button1.TabIndex = 2;
         this.button1.Text = "&Cancel";
         this.button1.UseVisualStyleBackColor = true;
         // 
         // forwardManager
         // 
         this.forwardManager.Dock = System.Windows.Forms.DockStyle.Fill;
         this.forwardManager.EnableTools = true;
         this.forwardManager.Location = new System.Drawing.Point(0, 0);
         this.forwardManager.Name = "forwardManager";
         this.forwardManager.Size = new System.Drawing.Size(594, 376);
         this.forwardManager.TabIndex = 3;
         // 
         // ConfigureDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(594, 421);
         this.Controls.Add(this.forwardManager);
         this.Controls.Add(this.panel1);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ConfigureDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Forwarder Configuration";
         this.Load += new System.EventHandler(this.ConfigureDialog_Load);
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfigureDialog_FormClosing);
         this.panel1.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.Button button2;
      private System.Windows.Forms.Button button1;
      private Leadtools.Medical.Winforms.Forwarder.ForwardManagerConfigurationView forwardManager;
   }
}