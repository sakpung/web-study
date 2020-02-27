namespace Leadtools.Medical.Winforms
{
   partial class StatusReport
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
         this.btnClose = new System.Windows.Forms.Button();
         this.btnClear = new System.Windows.Forms.Button();
         this.rtxtReport = new System.Windows.Forms.RichTextBox();
         this.panel1 = new System.Windows.Forms.Panel();
         this.panel2 = new System.Windows.Forms.Panel();
         this.panel1.SuspendLayout();
         this.panel2.SuspendLayout();
         this.SuspendLayout();
         // 
         // btnClose
         // 
         this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
         this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.btnClose.Location = new System.Drawing.Point(319, 2);
         this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.btnClose.Name = "btnClose";
         this.btnClose.Size = new System.Drawing.Size(68, 26);
         this.btnClose.TabIndex = 0;
         this.btnClose.Text = "Close";
         this.btnClose.UseVisualStyleBackColor = false;
         // 
         // btnClear
         // 
         this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
         this.btnClear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnClear.Location = new System.Drawing.Point(3, 2);
         this.btnClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.btnClear.Name = "btnClear";
         this.btnClear.Size = new System.Drawing.Size(68, 26);
         this.btnClear.TabIndex = 1;
         this.btnClear.Text = "Clear";
         this.btnClear.UseVisualStyleBackColor = false;
         // 
         // rtxtReport
         // 
         this.rtxtReport.BackColor = System.Drawing.Color.LightGray;
         this.rtxtReport.Dock = System.Windows.Forms.DockStyle.Fill;
         this.rtxtReport.Location = new System.Drawing.Point(0, 0);
         this.rtxtReport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.rtxtReport.Name = "rtxtReport";
         this.rtxtReport.ReadOnly = true;
         this.rtxtReport.Size = new System.Drawing.Size(389, 300);
         this.rtxtReport.TabIndex = 2;
         this.rtxtReport.Text = "";
         // 
         // panel1
         // 
         this.panel1.Controls.Add(this.rtxtReport);
         this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panel1.Location = new System.Drawing.Point(0, 0);
         this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(389, 300);
         this.panel1.TabIndex = 3;
         // 
         // panel2
         // 
         this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
         this.panel2.Controls.Add(this.btnClear);
         this.panel2.Controls.Add(this.btnClose);
         this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.panel2.Location = new System.Drawing.Point(0, 300);
         this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.panel2.Name = "panel2";
         this.panel2.Size = new System.Drawing.Size(389, 32);
         this.panel2.TabIndex = 0;
         // 
         // StatusReport
         // 
         this.AcceptButton = this.btnClose;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.SteelBlue;
         this.CancelButton = this.btnClose;
         this.ClientSize = new System.Drawing.Size(389, 332);
         this.Controls.Add(this.panel1);
         this.Controls.Add(this.panel2);
         this.ForeColor = System.Drawing.Color.White;
         this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "StatusReport";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.Text = "Status Report";
         this.panel1.ResumeLayout(false);
         this.panel2.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button btnClose;
      private System.Windows.Forms.Button btnClear;
      private System.Windows.Forms.RichTextBox rtxtReport;
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.Panel panel2;
   }
}