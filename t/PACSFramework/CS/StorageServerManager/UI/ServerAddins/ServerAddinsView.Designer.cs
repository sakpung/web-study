namespace Leadtools.Demos.StorageServer.UI
{
   partial class ServerAddinsView
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
         this.AddinsTableLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
         this.NoteLabel = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // AddinsTableLayoutPanel
         // 
         this.AddinsTableLayoutPanel.AutoScroll = true;
         this.AddinsTableLayoutPanel.AutoSize = true;
         this.AddinsTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
         this.AddinsTableLayoutPanel.Location = new System.Drawing.Point(0, 13);
         this.AddinsTableLayoutPanel.Name = "AddinsTableLayoutPanel";
         this.AddinsTableLayoutPanel.Padding = new System.Windows.Forms.Padding(10);
         this.AddinsTableLayoutPanel.Size = new System.Drawing.Size(614, 234);
         this.AddinsTableLayoutPanel.TabIndex = 0;
         // 
         // NoteLabel
         // 
         this.NoteLabel.AutoSize = true;
         this.NoteLabel.Dock = System.Windows.Forms.DockStyle.Top;
         this.NoteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.NoteLabel.Location = new System.Drawing.Point(0, 0);
         this.NoteLabel.Name = "NoteLabel";
         this.NoteLabel.Size = new System.Drawing.Size(41, 13);
         this.NoteLabel.TabIndex = 0;
         this.NoteLabel.Text = "label1";
         // 
         // ServerAddinsView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.White;
         this.Controls.Add(this.AddinsTableLayoutPanel);
         this.Controls.Add(this.NoteLabel);
         this.Name = "ServerAddinsView";
         this.Size = new System.Drawing.Size(614, 247);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.FlowLayoutPanel AddinsTableLayoutPanel;
      private System.Windows.Forms.Label NoteLabel;

   }
}
