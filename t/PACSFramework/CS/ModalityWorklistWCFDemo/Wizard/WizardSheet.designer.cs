namespace Leadtools.Wizard
{
   partial class WizardSheet
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
         this.pnlButtons = new System.Windows.Forms.Panel();
         this.buttonShowHelp = new System.Windows.Forms.Button();
         this.buttonOption1 = new System.Windows.Forms.Button();
         this.buttonAbout = new System.Windows.Forms.Button();
         this.etchedLine1 = new Leadtools.Wizard.EtchedLine();
         this.btnFinish = new System.Windows.Forms.Button();
         this.btnCancel = new System.Windows.Forms.Button();
         this.btnNext = new System.Windows.Forms.Button();
         this.btnBack = new System.Windows.Forms.Button();
         this.pnlPages = new System.Windows.Forms.Panel();
         this.pnlButtons.SuspendLayout();
         this.SuspendLayout();
         // 
         // pnlButtons
         // 
         this.pnlButtons.BackColor = System.Drawing.SystemColors.Control;
         this.pnlButtons.Controls.Add(this.buttonShowHelp);
         this.pnlButtons.Controls.Add(this.buttonOption1);
         this.pnlButtons.Controls.Add(this.buttonAbout);
         this.pnlButtons.Controls.Add(this.etchedLine1);
         this.pnlButtons.Controls.Add(this.btnFinish);
         this.pnlButtons.Controls.Add(this.btnCancel);
         this.pnlButtons.Controls.Add(this.btnNext);
         this.pnlButtons.Controls.Add(this.btnBack);
         this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.pnlButtons.Location = new System.Drawing.Point(0, 513);
         this.pnlButtons.Name = "pnlButtons";
         this.pnlButtons.Size = new System.Drawing.Size(796, 46);
         this.pnlButtons.TabIndex = 0;
         // 
         // buttonShowHelp
         // 
         this.buttonShowHelp.Location = new System.Drawing.Point(98, 11);
         this.buttonShowHelp.Name = "buttonShowHelp";
         this.buttonShowHelp.Size = new System.Drawing.Size(83, 29);
         this.buttonShowHelp.TabIndex = 9;
         this.buttonShowHelp.Text = "Show Help";
         this.buttonShowHelp.UseVisualStyleBackColor = true;
         this.buttonShowHelp.Click += new System.EventHandler(this.buttonShowHelp_Click);
         // 
         // buttonOption1
         // 
         this.buttonOption1.Location = new System.Drawing.Point(184, 11);
         this.buttonOption1.Name = "buttonOption1";
         this.buttonOption1.Size = new System.Drawing.Size(83, 29);
         this.buttonOption1.TabIndex = 8;
         this.buttonOption1.Text = "Option1";
         this.buttonOption1.UseVisualStyleBackColor = true;
         // 
         // buttonAbout
         // 
         this.buttonAbout.Location = new System.Drawing.Point(12, 11);
         this.buttonAbout.Name = "buttonAbout";
         this.buttonAbout.Size = new System.Drawing.Size(83, 29);
         this.buttonAbout.TabIndex = 7;
         this.buttonAbout.Text = "About...";
         this.buttonAbout.UseVisualStyleBackColor = true;
         this.buttonAbout.Click += new System.EventHandler(this.buttonAbout_Click);
         // 
         // etchedLine1
         // 
         this.etchedLine1.BackColor = System.Drawing.SystemColors.Control;
         this.etchedLine1.DarkColor = System.Drawing.SystemColors.ControlDark;
         this.etchedLine1.Dock = System.Windows.Forms.DockStyle.Top;
         this.etchedLine1.LightColor = System.Drawing.SystemColors.ControlLightLight;
         this.etchedLine1.Location = new System.Drawing.Point(0, 0);
         this.etchedLine1.Name = "etchedLine1";
         this.etchedLine1.Size = new System.Drawing.Size(796, 9);
         this.etchedLine1.TabIndex = 4;
         this.etchedLine1.TabStop = false;
         // 
         // btnFinish
         // 
         this.btnFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnFinish.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.btnFinish.Location = new System.Drawing.Point(586, 11);
         this.btnFinish.Name = "btnFinish";
         this.btnFinish.Size = new System.Drawing.Size(83, 29);
         this.btnFinish.TabIndex = 3;
         this.btnFinish.Text = "Finish";
         this.btnFinish.UseVisualStyleBackColor = true;
         // 
         // btnCancel
         // 
         this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point(707, 11);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(83, 29);
         this.btnCancel.TabIndex = 2;
         this.btnCancel.Text = "Cancel";
         this.btnCancel.UseVisualStyleBackColor = true;
         // 
         // btnNext
         // 
         this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnNext.Location = new System.Drawing.Point(586, 11);
         this.btnNext.Name = "btnNext";
         this.btnNext.Size = new System.Drawing.Size(83, 29);
         this.btnNext.TabIndex = 1;
         this.btnNext.Text = "&Next >";
         this.btnNext.UseVisualStyleBackColor = true;
         // 
         // btnBack
         // 
         this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnBack.Location = new System.Drawing.Point(497, 11);
         this.btnBack.Name = "btnBack";
         this.btnBack.Size = new System.Drawing.Size(83, 29);
         this.btnBack.TabIndex = 0;
         this.btnBack.Text = "< &Back";
         this.btnBack.UseVisualStyleBackColor = true;
         // 
         // pnlPages
         // 
         this.pnlPages.BackColor = System.Drawing.SystemColors.Control;
         this.pnlPages.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlPages.ForeColor = System.Drawing.SystemColors.ControlText;
         this.pnlPages.Location = new System.Drawing.Point(0, 0);
         this.pnlPages.Name = "pnlPages";
         this.pnlPages.Size = new System.Drawing.Size(796, 513);
         this.pnlPages.TabIndex = 1;
         // 
         // WizardSheet
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.pnlPages);
         this.Controls.Add(this.pnlButtons);
         this.Font = new System.Drawing.Font("Arial", 8F);
         this.Name = "WizardSheet";
         this.Size = new System.Drawing.Size(796, 559);
         this.pnlButtons.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Panel pnlButtons;
      private System.Windows.Forms.Button btnCancel;
      private System.Windows.Forms.Button btnNext;
      private System.Windows.Forms.Button btnBack;
      private System.Windows.Forms.Button btnFinish;
      private EtchedLine etchedLine1;
      private System.Windows.Forms.Panel pnlPages;
      private System.Windows.Forms.Button buttonAbout;
      private System.Windows.Forms.Button buttonOption1;
      private System.Windows.Forms.Button buttonShowHelp;
   }
}
