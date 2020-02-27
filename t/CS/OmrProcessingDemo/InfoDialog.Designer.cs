namespace OmrProcessingDemo
{
   partial class InfoDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoDialog));
         this.btnClose = new System.Windows.Forms.Button();
         this.chkShowOnStartup = new System.Windows.Forms.CheckBox();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.label6 = new System.Windows.Forms.Label();
         this.label7 = new System.Windows.Forms.Label();
         this.label8 = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // btnClose
         // 
         this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnClose.Location = new System.Drawing.Point(223, 308);
         this.btnClose.Name = "btnClose";
         this.btnClose.Size = new System.Drawing.Size(75, 23);
         this.btnClose.TabIndex = 0;
         this.btnClose.Text = "&Close";
         this.btnClose.UseVisualStyleBackColor = true;
         this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
         // 
         // chkShowOnStartup
         // 
         this.chkShowOnStartup.AutoSize = true;
         this.chkShowOnStartup.Location = new System.Drawing.Point(93, 312);
         this.chkShowOnStartup.Name = "chkShowOnStartup";
         this.chkShowOnStartup.Size = new System.Drawing.Size(124, 17);
         this.chkShowOnStartup.TabIndex = 1;
         this.chkShowOnStartup.Text = "Show this on Startup";
         this.chkShowOnStartup.UseVisualStyleBackColor = true;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(33, 281);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(334, 13);
         this.label1.TabIndex = 2;
         this.label1.Text = "This dialog can be found via Template Editor -> Help -> Information";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(85, 9);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(249, 13);
         this.label2.TabIndex = 3;
         this.label2.Text = "This demo is used for processing OMR worksheets.";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label3.Location = new System.Drawing.Point(12, 36);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(119, 16);
         this.label3.TabIndex = 4;
         this.label3.Text = "Template Editor";
         // 
         // label4
         // 
         this.label4.Location = new System.Drawing.Point(39, 63);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(342, 56);
         this.label4.TabIndex = 5;
         this.label4.Text = "The Template Editor allows construction of a template to use when recognizing OMR" +
    " worksheets highlighting regions of interest.  Different OMR regions can be sele" +
    "cted for processing.";
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label5.Location = new System.Drawing.Point(12, 119);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(151, 16);
         this.label5.TabIndex = 6;
         this.label5.Text = "Process Worksheets";
         // 
         // label6
         // 
         this.label6.Location = new System.Drawing.Point(39, 144);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(342, 43);
         this.label6.TabIndex = 7;
         this.label6.Text = "This allows the selection of worksheets to be processed using the loaded template" +
    ".  An Answer Key can also be included.";
         // 
         // label7
         // 
         this.label7.AutoSize = true;
         this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label7.Location = new System.Drawing.Point(12, 187);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(115, 16);
         this.label7.TabIndex = 8;
         this.label7.Text = "Review Results";
         // 
         // label8
         // 
         this.label8.Location = new System.Drawing.Point(39, 214);
         this.label8.Name = "label8";
         this.label8.Size = new System.Drawing.Size(339, 46);
         this.label8.TabIndex = 9;
         this.label8.Text = "Review Results presents the processed OMR marks for review.  Values can be verifi" +
    "ed, modified, filtered, and exported.  Results can also be saved into workspace " +
    "files for future use.";
         // 
         // InfoDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.btnClose;
         this.ClientSize = new System.Drawing.Size(400, 343);
         this.Controls.Add(this.label8);
         this.Controls.Add(this.label7);
         this.Controls.Add(this.label6);
         this.Controls.Add(this.label5);
         this.Controls.Add(this.label4);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.chkShowOnStartup);
         this.Controls.Add(this.btnClose);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "InfoDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "LEADTOOLS for .Net C# OMR Processing Demo";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InfoDialog_FormClosing);
         this.Load += new System.EventHandler(this.InfoDialog_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button btnClose;
      private System.Windows.Forms.CheckBox chkShowOnStartup;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.Label label8;
   }
}