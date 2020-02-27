namespace OmrProcessingDemo.UI
{
   partial class TemplatePanel
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
         this.txtFilePath = new System.Windows.Forms.TextBox();
         this.btnBrowse = new System.Windows.Forms.Button();
         this.rdBtnFile = new System.Windows.Forms.RadioButton();
         this.rdbtnTemplate = new System.Windows.Forms.RadioButton();
         this.pnlThumbnail = new System.Windows.Forms.Panel();
         this.grpSelectSource = new System.Windows.Forms.GroupBox();
         this.grpSelectSource.SuspendLayout();
         this.SuspendLayout();
         // 
         // txtFilePath
         // 
         this.txtFilePath.Location = new System.Drawing.Point(28, 65);
         this.txtFilePath.Name = "txtFilePath";
         this.txtFilePath.Size = new System.Drawing.Size(310, 20);
         this.txtFilePath.TabIndex = 4;
         // 
         // btnBrowse
         // 
         this.btnBrowse.Location = new System.Drawing.Point(344, 65);
         this.btnBrowse.Name = "btnBrowse";
         this.btnBrowse.Size = new System.Drawing.Size(75, 23);
         this.btnBrowse.TabIndex = 5;
         this.btnBrowse.Text = "Browse";
         this.btnBrowse.UseVisualStyleBackColor = true;
         this.btnBrowse.Click += new System.EventHandler(this.btnTemplateBrowse_Click);
         // 
         // rdBtnFile
         // 
         this.rdBtnFile.AutoSize = true;
         this.rdBtnFile.Location = new System.Drawing.Point(6, 42);
         this.rdBtnFile.Name = "rdBtnFile";
         this.rdBtnFile.Size = new System.Drawing.Size(80, 17);
         this.rdBtnFile.TabIndex = 0;
         this.rdBtnFile.TabStop = true;
         this.rdBtnFile.Text = "File on Disk";
         this.rdBtnFile.UseVisualStyleBackColor = true;
         this.rdBtnFile.CheckedChanged += new System.EventHandler(this.rdBtnToggled);
         // 
         // rdbtnTemplate
         // 
         this.rdbtnTemplate.AutoSize = true;
         this.rdbtnTemplate.Location = new System.Drawing.Point(6, 19);
         this.rdbtnTemplate.Name = "rdbtnTemplate";
         this.rdbtnTemplate.Size = new System.Drawing.Size(151, 17);
         this.rdbtnTemplate.TabIndex = 21;
         this.rdbtnTemplate.TabStop = true;
         this.rdbtnTemplate.Text = "Use Constructed Template";
         this.rdbtnTemplate.UseVisualStyleBackColor = true;
         this.rdbtnTemplate.CheckedChanged += new System.EventHandler(this.rdBtnToggled);
         // 
         // pnlThumbnail
         // 
         this.pnlThumbnail.BackColor = System.Drawing.SystemColors.ControlDark;
         this.pnlThumbnail.Location = new System.Drawing.Point(448, 3);
         this.pnlThumbnail.Name = "pnlThumbnail";
         this.pnlThumbnail.Size = new System.Drawing.Size(169, 195);
         this.pnlThumbnail.TabIndex = 23;
         // 
         // grpSelectSource
         // 
         this.grpSelectSource.Controls.Add(this.rdbtnTemplate);
         this.grpSelectSource.Controls.Add(this.rdBtnFile);
         this.grpSelectSource.Controls.Add(this.txtFilePath);
         this.grpSelectSource.Controls.Add(this.btnBrowse);
         this.grpSelectSource.Location = new System.Drawing.Point(7, 6);
         this.grpSelectSource.Name = "grpSelectSource";
         this.grpSelectSource.Size = new System.Drawing.Size(435, 97);
         this.grpSelectSource.TabIndex = 24;
         this.grpSelectSource.TabStop = false;
         this.grpSelectSource.Text = "Select Source";
         // 
         // TemplatePanel
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.grpSelectSource);
         this.Controls.Add(this.pnlThumbnail);
         this.Name = "TemplatePanel";
         this.Size = new System.Drawing.Size(617, 198);
         this.grpSelectSource.ResumeLayout(false);
         this.grpSelectSource.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion
      private System.Windows.Forms.TextBox txtFilePath;
      private System.Windows.Forms.Button btnBrowse;
      private System.Windows.Forms.RadioButton rdBtnFile;
      private System.Windows.Forms.RadioButton rdbtnTemplate;
      private System.Windows.Forms.Panel pnlThumbnail;
      private System.Windows.Forms.GroupBox grpSelectSource;
   }
}