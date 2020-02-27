namespace Leadtools.Demos.StorageServer.UI
{
   partial class ControlPanelView
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
         this.panel1 = new System.Windows.Forms.Panel();
         this.NotesRichTextBox = new System.Windows.Forms.RichTextBox();
         this.panel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // AddinsTableLayoutPanel
         // 
         this.AddinsTableLayoutPanel.AutoScroll = true;
         this.AddinsTableLayoutPanel.AutoSize = true;
         this.AddinsTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
         this.AddinsTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
         this.AddinsTableLayoutPanel.Name = "AddinsTableLayoutPanel";
         this.AddinsTableLayoutPanel.Padding = new System.Windows.Forms.Padding(10);
         this.AddinsTableLayoutPanel.Size = new System.Drawing.Size(614, 101);
         this.AddinsTableLayoutPanel.TabIndex = 0;
         // 
         // panel1
         // 
         this.panel1.Controls.Add(this.NotesRichTextBox);
         this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.panel1.Location = new System.Drawing.Point(0, 101);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(614, 261);
         this.panel1.TabIndex = 1;
         // 
         // NotesRichTextBox
         // 
         this.NotesRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
         this.NotesRichTextBox.Location = new System.Drawing.Point(0, 0);
         this.NotesRichTextBox.Name = "NotesRichTextBox";
         this.NotesRichTextBox.ReadOnly = true;
         this.NotesRichTextBox.Size = new System.Drawing.Size(614, 261);
         this.NotesRichTextBox.TabIndex = 0;
         this.NotesRichTextBox.Text = "";
         // 
         // ControlPanelView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.White;
         this.Controls.Add(this.AddinsTableLayoutPanel);
         this.Controls.Add(this.panel1);
         this.Name = "ControlPanelView";
         this.Size = new System.Drawing.Size(614, 362);
         this.panel1.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.FlowLayoutPanel AddinsTableLayoutPanel;
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.RichTextBox NotesRichTextBox;

   }
}
