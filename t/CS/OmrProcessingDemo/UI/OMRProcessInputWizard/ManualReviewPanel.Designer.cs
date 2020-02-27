namespace OmrProcessingDemo.UI
{
   partial class ManualReviewPanel
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
         this.grpValidation = new System.Windows.Forms.GroupBox();
         this.lblFilterTemplates = new System.Windows.Forms.Label();
         this.rdbtnCustomize = new System.Windows.Forms.RadioButton();
         this.rdbtnIncorrectOnly = new System.Windows.Forms.RadioButton();
         this.rdbtnCorrect = new System.Windows.Forms.RadioButton();
         this.rdbtnChangedOrModified = new System.Windows.Forms.RadioButton();
         this.rdbtnCommonIssues = new System.Windows.Forms.RadioButton();
         this.chkModified = new System.Windows.Forms.CheckBox();
         this.chkAlreadyReviewed = new System.Windows.Forms.CheckBox();
         this.chkDisagree = new System.Windows.Forms.CheckBox();
         this.chkAgree = new System.Windows.Forms.CheckBox();
         this.chkExactlyOne = new System.Windows.Forms.CheckBox();
         this.label1 = new System.Windows.Forms.Label();
         this.chkThreshold = new System.Windows.Forms.CheckBox();
         this.nudThreshold = new System.Windows.Forms.NumericUpDown();
         this.grpValidation.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.nudThreshold)).BeginInit();
         this.SuspendLayout();
         // 
         // grpValidation
         // 
         this.grpValidation.Controls.Add(this.lblFilterTemplates);
         this.grpValidation.Controls.Add(this.rdbtnCustomize);
         this.grpValidation.Controls.Add(this.rdbtnIncorrectOnly);
         this.grpValidation.Controls.Add(this.rdbtnCorrect);
         this.grpValidation.Controls.Add(this.rdbtnChangedOrModified);
         this.grpValidation.Controls.Add(this.rdbtnCommonIssues);
         this.grpValidation.Controls.Add(this.chkModified);
         this.grpValidation.Controls.Add(this.chkAlreadyReviewed);
         this.grpValidation.Controls.Add(this.chkDisagree);
         this.grpValidation.Controls.Add(this.chkAgree);
         this.grpValidation.Controls.Add(this.chkExactlyOne);
         this.grpValidation.Controls.Add(this.label1);
         this.grpValidation.Controls.Add(this.chkThreshold);
         this.grpValidation.Controls.Add(this.nudThreshold);
         this.grpValidation.Location = new System.Drawing.Point(3, 3);
         this.grpValidation.Name = "grpValidation";
         this.grpValidation.Size = new System.Drawing.Size(611, 192);
         this.grpValidation.TabIndex = 0;
         this.grpValidation.TabStop = false;
         this.grpValidation.Text = "Manually review";
         // 
         // lblFilterTemplates
         // 
         this.lblFilterTemplates.AutoSize = true;
         this.lblFilterTemplates.Location = new System.Drawing.Point(16, 19);
         this.lblFilterTemplates.Name = "lblFilterTemplates";
         this.lblFilterTemplates.Size = new System.Drawing.Size(81, 13);
         this.lblFilterTemplates.TabIndex = 16;
         this.lblFilterTemplates.Text = "Filter Templates";
         // 
         // rdbtnCustomize
         // 
         this.rdbtnCustomize.AutoSize = true;
         this.rdbtnCustomize.Location = new System.Drawing.Point(375, 35);
         this.rdbtnCustomize.Name = "rdbtnCustomize";
         this.rdbtnCustomize.Size = new System.Drawing.Size(73, 17);
         this.rdbtnCustomize.TabIndex = 15;
         this.rdbtnCustomize.TabStop = true;
         this.rdbtnCustomize.Text = "C&ustomize";
         this.rdbtnCustomize.UseVisualStyleBackColor = true;
         this.rdbtnCustomize.CheckedChanged += new System.EventHandler(this.rdbtnCustomize_CheckedChanged);
         // 
         // rdbtnIncorrectOnly
         // 
         this.rdbtnIncorrectOnly.AutoSize = true;
         this.rdbtnIncorrectOnly.Location = new System.Drawing.Point(258, 62);
         this.rdbtnIncorrectOnly.Name = "rdbtnIncorrectOnly";
         this.rdbtnIncorrectOnly.Size = new System.Drawing.Size(91, 17);
         this.rdbtnIncorrectOnly.TabIndex = 14;
         this.rdbtnIncorrectOnly.TabStop = true;
         this.rdbtnIncorrectOnly.Text = "Incorr&ect Only";
         this.rdbtnIncorrectOnly.UseVisualStyleBackColor = true;
         this.rdbtnIncorrectOnly.CheckedChanged += new System.EventHandler(this.rdbtnIncorrectOnly_CheckedChanged);
         // 
         // rdbtnCorrect
         // 
         this.rdbtnCorrect.AutoSize = true;
         this.rdbtnCorrect.Location = new System.Drawing.Point(258, 35);
         this.rdbtnCorrect.Name = "rdbtnCorrect";
         this.rdbtnCorrect.Size = new System.Drawing.Size(83, 17);
         this.rdbtnCorrect.TabIndex = 13;
         this.rdbtnCorrect.TabStop = true;
         this.rdbtnCorrect.Text = "C&orrect Only";
         this.rdbtnCorrect.UseVisualStyleBackColor = true;
         this.rdbtnCorrect.CheckedChanged += new System.EventHandler(this.rdbtnCorrect_CheckedChanged);
         // 
         // rdbtnChangedOrModified
         // 
         this.rdbtnChangedOrModified.AutoSize = true;
         this.rdbtnChangedOrModified.Location = new System.Drawing.Point(73, 62);
         this.rdbtnChangedOrModified.Name = "rdbtnChangedOrModified";
         this.rdbtnChangedOrModified.Size = new System.Drawing.Size(137, 17);
         this.rdbtnChangedOrModified.TabIndex = 12;
         this.rdbtnChangedOrModified.TabStop = true;
         this.rdbtnChangedOrModified.Text = "Re&viewed and Modified";
         this.rdbtnChangedOrModified.UseVisualStyleBackColor = true;
         this.rdbtnChangedOrModified.CheckedChanged += new System.EventHandler(this.rdbtnChangedOrModified_CheckedChanged);
         // 
         // rdbtnCommonIssues
         // 
         this.rdbtnCommonIssues.AutoSize = true;
         this.rdbtnCommonIssues.Location = new System.Drawing.Point(73, 35);
         this.rdbtnCommonIssues.Name = "rdbtnCommonIssues";
         this.rdbtnCommonIssues.Size = new System.Drawing.Size(99, 17);
         this.rdbtnCommonIssues.TabIndex = 11;
         this.rdbtnCommonIssues.TabStop = true;
         this.rdbtnCommonIssues.Text = "&Common Issues";
         this.rdbtnCommonIssues.UseVisualStyleBackColor = true;
         this.rdbtnCommonIssues.CheckedChanged += new System.EventHandler(this.rdbtnCommonIssues_CheckedChanged);
         // 
         // chkModified
         // 
         this.chkModified.AutoSize = true;
         this.chkModified.Location = new System.Drawing.Point(368, 141);
         this.chkModified.Name = "chkModified";
         this.chkModified.Size = new System.Drawing.Size(184, 17);
         this.chkModified.TabIndex = 10;
         this.chkModified.Text = "&modified from their original values.";
         this.chkModified.UseVisualStyleBackColor = true;
         this.chkModified.CheckedChanged += new System.EventHandler(this.chkFilter_CheckedChanged);
         // 
         // chkAlreadyReviewed
         // 
         this.chkAlreadyReviewed.AutoSize = true;
         this.chkAlreadyReviewed.Location = new System.Drawing.Point(368, 166);
         this.chkAlreadyReviewed.Name = "chkAlreadyReviewed";
         this.chkAlreadyReviewed.Size = new System.Drawing.Size(184, 17);
         this.chkAlreadyReviewed.TabIndex = 9;
         this.chkAlreadyReviewed.Text = "that have already been &reviewed.";
         this.chkAlreadyReviewed.UseVisualStyleBackColor = true;
         this.chkAlreadyReviewed.CheckedChanged += new System.EventHandler(this.chkFilter_CheckedChanged);
         // 
         // chkDisagree
         // 
         this.chkDisagree.AutoSize = true;
         this.chkDisagree.Location = new System.Drawing.Point(19, 166);
         this.chkDisagree.Name = "chkDisagree";
         this.chkDisagree.Size = new System.Drawing.Size(333, 17);
         this.chkDisagree.TabIndex = 8;
         this.chkDisagree.Text = "with a &different value as the answer key. (I. E., incorrect answers)";
         this.chkDisagree.UseVisualStyleBackColor = true;
         this.chkDisagree.CheckedChanged += new System.EventHandler(this.chkFilter_CheckedChanged);
         // 
         // chkAgree
         // 
         this.chkAgree.AutoSize = true;
         this.chkAgree.Location = new System.Drawing.Point(19, 141);
         this.chkAgree.Name = "chkAgree";
         this.chkAgree.Size = new System.Drawing.Size(321, 17);
         this.chkAgree.TabIndex = 7;
         this.chkAgree.Text = "with the &same value as the answer key. (I. E., correct answers)\r\n";
         this.chkAgree.UseVisualStyleBackColor = true;
         this.chkAgree.CheckedChanged += new System.EventHandler(this.chkFilter_CheckedChanged);
         // 
         // chkExactlyOne
         // 
         this.chkExactlyOne.AutoSize = true;
         this.chkExactlyOne.Checked = true;
         this.chkExactlyOne.CheckState = System.Windows.Forms.CheckState.Checked;
         this.chkExactlyOne.Location = new System.Drawing.Point(368, 116);
         this.chkExactlyOne.Name = "chkExactlyOne";
         this.chkExactlyOne.Size = new System.Drawing.Size(227, 17);
         this.chkExactlyOne.TabIndex = 6;
         this.chkExactlyOne.Text = "&that don\'t have exactly one bubble filled in.";
         this.chkExactlyOne.UseVisualStyleBackColor = true;
         this.chkExactlyOne.CheckedChanged += new System.EventHandler(this.chkFilter_CheckedChanged);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(6, 91);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(80, 13);
         this.label1.TabIndex = 5;
         this.label1.Text = "Available Filters";
         this.label1.Visible = false;
         // 
         // chkThreshold
         // 
         this.chkThreshold.AutoSize = true;
         this.chkThreshold.Checked = true;
         this.chkThreshold.CheckState = System.Windows.Forms.CheckState.Checked;
         this.chkThreshold.Location = new System.Drawing.Point(19, 116);
         this.chkThreshold.Name = "chkThreshold";
         this.chkThreshold.Size = new System.Drawing.Size(215, 17);
         this.chkThreshold.TabIndex = 4;
         this.chkThreshold.Text = "&with OMR confidence values lower than";
         this.chkThreshold.UseVisualStyleBackColor = true;
         this.chkThreshold.CheckedChanged += new System.EventHandler(this.chkThreshold_CheckedChanged);
         // 
         // nudThreshold
         // 
         this.nudThreshold.Location = new System.Drawing.Point(240, 115);
         this.nudThreshold.Name = "nudThreshold";
         this.nudThreshold.Size = new System.Drawing.Size(51, 20);
         this.nudThreshold.TabIndex = 3;
         this.nudThreshold.Value = new decimal(new int[] {
            73,
            0,
            0,
            0});
         // 
         // ManualReviewPanel
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.grpValidation);
         this.Name = "ManualReviewPanel";
         this.Size = new System.Drawing.Size(617, 198);
         this.grpValidation.ResumeLayout(false);
         this.grpValidation.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.nudThreshold)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox grpValidation;
      private System.Windows.Forms.CheckBox chkDisagree;
      private System.Windows.Forms.CheckBox chkAgree;
      private System.Windows.Forms.CheckBox chkExactlyOne;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.CheckBox chkThreshold;
      private System.Windows.Forms.NumericUpDown nudThreshold;
      private System.Windows.Forms.CheckBox chkAlreadyReviewed;
      private System.Windows.Forms.CheckBox chkModified;
      private System.Windows.Forms.RadioButton rdbtnCustomize;
      private System.Windows.Forms.RadioButton rdbtnIncorrectOnly;
      private System.Windows.Forms.RadioButton rdbtnCorrect;
      private System.Windows.Forms.RadioButton rdbtnChangedOrModified;
      private System.Windows.Forms.RadioButton rdbtnCommonIssues;
      private System.Windows.Forms.Label lblFilterTemplates;
   }
}
