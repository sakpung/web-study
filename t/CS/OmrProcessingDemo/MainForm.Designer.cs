namespace OmrProcessingDemo
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
         this.statusStrip1 = new System.Windows.Forms.StatusStrip();
         this.tbcMain = new System.Windows.Forms.TabControl();
         this.tbTemplate = new System.Windows.Forms.TabPage();
         this.tbProcess = new System.Windows.Forms.TabPage();
         this.tbResults = new System.Windows.Forms.TabPage();
         this.tbcMain.SuspendLayout();
         this.SuspendLayout();
         // 
         // statusStrip1
         // 
         this.statusStrip1.Location = new System.Drawing.Point(0, 522);
         this.statusStrip1.Name = "statusStrip1";
         this.statusStrip1.Size = new System.Drawing.Size(1026, 22);
         this.statusStrip1.TabIndex = 1;
         this.statusStrip1.Text = "statusStrip1";
         // 
         // tbcMain
         // 
         this.tbcMain.Appearance = System.Windows.Forms.TabAppearance.Buttons;
         this.tbcMain.Controls.Add(this.tbTemplate);
         this.tbcMain.Controls.Add(this.tbProcess);
         this.tbcMain.Controls.Add(this.tbResults);
         this.tbcMain.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tbcMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.tbcMain.Location = new System.Drawing.Point(0, 0);
         this.tbcMain.Name = "tbcMain";
         this.tbcMain.SelectedIndex = 0;
         this.tbcMain.Size = new System.Drawing.Size(1026, 522);
         this.tbcMain.TabIndex = 3;
         // 
         // tbTemplate
         // 
         this.tbTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.tbTemplate.Location = new System.Drawing.Point(4, 32);
         this.tbTemplate.Name = "tbTemplate";
         this.tbTemplate.Padding = new System.Windows.Forms.Padding(3);
         this.tbTemplate.RightToLeft = System.Windows.Forms.RightToLeft.No;
         this.tbTemplate.Size = new System.Drawing.Size(1018, 486);
         this.tbTemplate.TabIndex = 0;
         this.tbTemplate.Text = "   Template Editor  ";
         this.tbTemplate.UseVisualStyleBackColor = true;
         // 
         // tbProcess
         // 
         this.tbProcess.BackColor = System.Drawing.SystemColors.ControlDark;
         this.tbProcess.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.tbProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.tbProcess.Location = new System.Drawing.Point(4, 32);
         this.tbProcess.Name = "tbProcess";
         this.tbProcess.Padding = new System.Windows.Forms.Padding(3);
         this.tbProcess.Size = new System.Drawing.Size(1018, 486);
         this.tbProcess.TabIndex = 1;
         this.tbProcess.Text = "   Process Worksheets   ";
         // 
         // tbResults
         // 
         this.tbResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.tbResults.Location = new System.Drawing.Point(4, 32);
         this.tbResults.Name = "tbResults";
         this.tbResults.Size = new System.Drawing.Size(1018, 486);
         this.tbResults.TabIndex = 2;
         this.tbResults.Text = "   Review Results  ";
         this.tbResults.UseVisualStyleBackColor = true;
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1026, 544);
         this.Controls.Add(this.tbcMain);
         this.Controls.Add(this.statusStrip1);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "MainForm";
         this.Text = "LEADTOOLS for .Net C# OMR Processing Demo";
         this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
         this.Load += new System.EventHandler(this.Form1_Load);
         this.Shown += new System.EventHandler(this.MainForm_Shown);
         this.tbcMain.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion
      private System.Windows.Forms.StatusStrip statusStrip1;
      private System.Windows.Forms.TabControl tbcMain;
      private System.Windows.Forms.TabPage tbTemplate;
      private System.Windows.Forms.TabPage tbProcess;
      private System.Windows.Forms.TabPage tbResults;
   }
}

