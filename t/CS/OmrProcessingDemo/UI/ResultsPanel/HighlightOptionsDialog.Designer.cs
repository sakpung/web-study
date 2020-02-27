namespace OmrProcessingDemo.UI
{
   partial class HighlightOptionsDialog
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
         this.btnOk = new System.Windows.Forms.Button();
         this.btnCancel = new System.Windows.Forms.Button();
         this.chkCorrect = new System.Windows.Forms.CheckBox();
         this.chkIncorrect = new System.Windows.Forms.CheckBox();
         this.chkCorrectModified = new System.Windows.Forms.CheckBox();
         this.chkIncorrectModified = new System.Windows.Forms.CheckBox();
         this.btnCorrect = new System.Windows.Forms.Button();
         this.btnIncorrect = new System.Windows.Forms.Button();
         this.btnModCorrect = new System.Windows.Forms.Button();
         this.btnModIncorrect = new System.Windows.Forms.Button();
         this.chkExpected = new System.Windows.Forms.CheckBox();
         this.btnExpected = new System.Windows.Forms.Button();
         this.chkReview = new System.Windows.Forms.CheckBox();
         this.btnReview = new System.Windows.Forms.Button();
         this.btnCriteria = new System.Windows.Forms.Button();
         this.btnApply = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // btnOk
         // 
         this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.btnOk.Location = new System.Drawing.Point(143, 205);
         this.btnOk.Name = "btnOk";
         this.btnOk.Size = new System.Drawing.Size(75, 23);
         this.btnOk.TabIndex = 0;
         this.btnOk.Text = "OK";
         this.btnOk.UseVisualStyleBackColor = true;
         // 
         // btnCancel
         // 
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point(224, 205);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(75, 23);
         this.btnCancel.TabIndex = 1;
         this.btnCancel.Text = "Cancel";
         this.btnCancel.UseVisualStyleBackColor = true;
         // 
         // chkCorrect
         // 
         this.chkCorrect.AutoSize = true;
         this.chkCorrect.Location = new System.Drawing.Point(28, 22);
         this.chkCorrect.Name = "chkCorrect";
         this.chkCorrect.Size = new System.Drawing.Size(119, 17);
         this.chkCorrect.TabIndex = 2;
         this.chkCorrect.Text = "Correct Responses:";
         this.chkCorrect.UseVisualStyleBackColor = true;
         this.chkCorrect.CheckedChanged += new System.EventHandler(this.rdbtn_CheckChanged);
         // 
         // chkIncorrect
         // 
         this.chkIncorrect.AutoSize = true;
         this.chkIncorrect.Location = new System.Drawing.Point(28, 46);
         this.chkIncorrect.Name = "chkIncorrect";
         this.chkIncorrect.Size = new System.Drawing.Size(127, 17);
         this.chkIncorrect.TabIndex = 3;
         this.chkIncorrect.Text = "Incorrect Responses:";
         this.chkIncorrect.UseVisualStyleBackColor = true;
         this.chkIncorrect.CheckedChanged += new System.EventHandler(this.rdbtn_CheckChanged);
         // 
         // chkCorrectModified
         // 
         this.chkCorrectModified.AutoSize = true;
         this.chkCorrectModified.Location = new System.Drawing.Point(28, 70);
         this.chkCorrectModified.Name = "chkCorrectModified";
         this.chkCorrectModified.Size = new System.Drawing.Size(170, 17);
         this.chkCorrectModified.TabIndex = 4;
         this.chkCorrectModified.Text = "Reviewed Correct Responses:";
         this.chkCorrectModified.UseVisualStyleBackColor = true;
         this.chkCorrectModified.CheckedChanged += new System.EventHandler(this.rdbtn_CheckChanged);
         // 
         // chkIncorrectModified
         // 
         this.chkIncorrectModified.AutoSize = true;
         this.chkIncorrectModified.Location = new System.Drawing.Point(28, 94);
         this.chkIncorrectModified.Name = "chkIncorrectModified";
         this.chkIncorrectModified.Size = new System.Drawing.Size(178, 17);
         this.chkIncorrectModified.TabIndex = 5;
         this.chkIncorrectModified.Text = "Reviewed Incorrect Responses:";
         this.chkIncorrectModified.UseVisualStyleBackColor = true;
         this.chkIncorrectModified.CheckedChanged += new System.EventHandler(this.rdbtn_CheckChanged);
         // 
         // btnCorrect
         // 
         this.btnCorrect.Location = new System.Drawing.Point(224, 18);
         this.btnCorrect.Name = "btnCorrect";
         this.btnCorrect.Size = new System.Drawing.Size(75, 23);
         this.btnCorrect.TabIndex = 6;
         this.btnCorrect.Text = "Change";
         this.btnCorrect.UseVisualStyleBackColor = true;
         this.btnCorrect.Click += new System.EventHandler(this.btnColorChange_Click);
         // 
         // btnIncorrect
         // 
         this.btnIncorrect.Location = new System.Drawing.Point(224, 42);
         this.btnIncorrect.Name = "btnIncorrect";
         this.btnIncorrect.Size = new System.Drawing.Size(75, 23);
         this.btnIncorrect.TabIndex = 7;
         this.btnIncorrect.Text = "Change";
         this.btnIncorrect.UseVisualStyleBackColor = true;
         this.btnIncorrect.Click += new System.EventHandler(this.btnColorChange_Click);
         // 
         // btnModCorrect
         // 
         this.btnModCorrect.Location = new System.Drawing.Point(224, 66);
         this.btnModCorrect.Name = "btnModCorrect";
         this.btnModCorrect.Size = new System.Drawing.Size(75, 23);
         this.btnModCorrect.TabIndex = 8;
         this.btnModCorrect.Text = "Change";
         this.btnModCorrect.UseVisualStyleBackColor = true;
         this.btnModCorrect.Click += new System.EventHandler(this.btnColorChange_Click);
         // 
         // btnModIncorrect
         // 
         this.btnModIncorrect.Location = new System.Drawing.Point(224, 90);
         this.btnModIncorrect.Name = "btnModIncorrect";
         this.btnModIncorrect.Size = new System.Drawing.Size(75, 23);
         this.btnModIncorrect.TabIndex = 9;
         this.btnModIncorrect.Text = "Change";
         this.btnModIncorrect.UseVisualStyleBackColor = true;
         this.btnModIncorrect.Click += new System.EventHandler(this.btnColorChange_Click);
         // 
         // chkExpected
         // 
         this.chkExpected.AutoSize = true;
         this.chkExpected.Location = new System.Drawing.Point(28, 118);
         this.chkExpected.Name = "chkExpected";
         this.chkExpected.Size = new System.Drawing.Size(85, 17);
         this.chkExpected.TabIndex = 10;
         this.chkExpected.Text = "Answer Key:";
         this.chkExpected.UseVisualStyleBackColor = true;
         this.chkExpected.CheckedChanged += new System.EventHandler(this.rdbtn_CheckChanged);
         // 
         // btnExpected
         // 
         this.btnExpected.Location = new System.Drawing.Point(224, 114);
         this.btnExpected.Name = "btnExpected";
         this.btnExpected.Size = new System.Drawing.Size(75, 23);
         this.btnExpected.TabIndex = 11;
         this.btnExpected.Text = "Change";
         this.btnExpected.UseVisualStyleBackColor = true;
         this.btnExpected.Click += new System.EventHandler(this.btnColorChange_Click);
         // 
         // chkReview
         // 
         this.chkReview.AutoSize = true;
         this.chkReview.Location = new System.Drawing.Point(28, 142);
         this.chkReview.Name = "chkReview";
         this.chkReview.Size = new System.Drawing.Size(99, 17);
         this.chkReview.TabIndex = 12;
         this.chkReview.Text = "Needs Review:";
         this.chkReview.UseVisualStyleBackColor = true;
         this.chkReview.CheckedChanged += new System.EventHandler(this.rdbtn_CheckChanged);
         // 
         // btnReview
         // 
         this.btnReview.Location = new System.Drawing.Point(224, 138);
         this.btnReview.Name = "btnReview";
         this.btnReview.Size = new System.Drawing.Size(75, 23);
         this.btnReview.TabIndex = 13;
         this.btnReview.Text = "Change";
         this.btnReview.UseVisualStyleBackColor = true;
         this.btnReview.Click += new System.EventHandler(this.btnColorChange_Click);
         // 
         // btnCriteria
         // 
         this.btnCriteria.Location = new System.Drawing.Point(133, 138);
         this.btnCriteria.Name = "btnCriteria";
         this.btnCriteria.Size = new System.Drawing.Size(24, 23);
         this.btnCriteria.TabIndex = 14;
         this.btnCriteria.Text = "...";
         this.btnCriteria.UseVisualStyleBackColor = true;
         this.btnCriteria.Click += new System.EventHandler(this.btnCriteria_Click);
         // 
         // btnApply
         // 
         this.btnApply.Location = new System.Drawing.Point(12, 205);
         this.btnApply.Name = "btnApply";
         this.btnApply.Size = new System.Drawing.Size(75, 23);
         this.btnApply.TabIndex = 15;
         this.btnApply.Text = "&Apply";
         this.btnApply.UseVisualStyleBackColor = true;
         this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
         // 
         // HighlightOptionsDialog
         // 
         this.AcceptButton = this.btnOk;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.btnCancel;
         this.ClientSize = new System.Drawing.Size(314, 241);
         this.Controls.Add(this.btnApply);
         this.Controls.Add(this.btnCriteria);
         this.Controls.Add(this.btnReview);
         this.Controls.Add(this.chkReview);
         this.Controls.Add(this.btnExpected);
         this.Controls.Add(this.chkExpected);
         this.Controls.Add(this.btnModIncorrect);
         this.Controls.Add(this.btnModCorrect);
         this.Controls.Add(this.btnIncorrect);
         this.Controls.Add(this.btnCorrect);
         this.Controls.Add(this.chkIncorrectModified);
         this.Controls.Add(this.chkCorrectModified);
         this.Controls.Add(this.chkIncorrect);
         this.Controls.Add(this.chkCorrect);
         this.Controls.Add(this.btnCancel);
         this.Controls.Add(this.btnOk);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "HighlightOptionsDialog";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Change Color Code";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HighlightOptionsDialog_FormClosing);
         this.Shown += new System.EventHandler(this.HighlightOptionsDialog_Shown);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button btnOk;
      private System.Windows.Forms.Button btnCancel;
      private System.Windows.Forms.CheckBox chkCorrect;
      private System.Windows.Forms.CheckBox chkIncorrect;
      private System.Windows.Forms.CheckBox chkCorrectModified;
      private System.Windows.Forms.CheckBox chkIncorrectModified;
      private System.Windows.Forms.Button btnCorrect;
      private System.Windows.Forms.Button btnIncorrect;
      private System.Windows.Forms.Button btnModCorrect;
      private System.Windows.Forms.Button btnModIncorrect;
      private System.Windows.Forms.CheckBox chkExpected;
      private System.Windows.Forms.Button btnExpected;
      private System.Windows.Forms.CheckBox chkReview;
      private System.Windows.Forms.Button btnReview;
      private System.Windows.Forms.Button btnCriteria;
      private System.Windows.Forms.Button btnApply;
   }
}