namespace OmrProcessingDemo.UI.ResultsPanel
{
   partial class ResultSearchDialog
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
         this.lblFindWhat = new System.Windows.Forms.Label();
         this.txtSearch = new System.Windows.Forms.TextBox();
         this.btnFindNext = new System.Windows.Forms.Button();
         this.btnClose = new System.Windows.Forms.Button();
         this.grpDirection = new System.Windows.Forms.GroupBox();
         this.rdbtnBackward = new System.Windows.Forms.RadioButton();
         this.rdbtnForward = new System.Windows.Forms.RadioButton();
         this.grpSearchIn = new System.Windows.Forms.GroupBox();
         this.rdbtnSearchbyCols = new System.Windows.Forms.RadioButton();
         this.rdbtnSearchbyRows = new System.Windows.Forms.RadioButton();
         this.chkMatchCase = new System.Windows.Forms.CheckBox();
         this.grpDirection.SuspendLayout();
         this.grpSearchIn.SuspendLayout();
         this.SuspendLayout();
         // 
         // lblFindWhat
         // 
         this.lblFindWhat.AutoSize = true;
         this.lblFindWhat.Location = new System.Drawing.Point(12, 9);
         this.lblFindWhat.Name = "lblFindWhat";
         this.lblFindWhat.Size = new System.Drawing.Size(56, 13);
         this.lblFindWhat.TabIndex = 0;
         this.lblFindWhat.Text = "F&ind what:";
         // 
         // txtSearch
         // 
         this.txtSearch.Location = new System.Drawing.Point(74, 6);
         this.txtSearch.Name = "txtSearch";
         this.txtSearch.Size = new System.Drawing.Size(228, 20);
         this.txtSearch.TabIndex = 1;
         // 
         // btnFindNext
         // 
         this.btnFindNext.Location = new System.Drawing.Point(308, 6);
         this.btnFindNext.Name = "btnFindNext";
         this.btnFindNext.Size = new System.Drawing.Size(75, 23);
         this.btnFindNext.TabIndex = 3;
         this.btnFindNext.Text = "&Find Next";
         this.btnFindNext.UseVisualStyleBackColor = true;
         this.btnFindNext.Click += new System.EventHandler(this.btnFindNext_Click);
         // 
         // btnClose
         // 
         this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnClose.Location = new System.Drawing.Point(308, 105);
         this.btnClose.Name = "btnClose";
         this.btnClose.Size = new System.Drawing.Size(75, 23);
         this.btnClose.TabIndex = 5;
         this.btnClose.Text = "Close";
         this.btnClose.UseVisualStyleBackColor = true;
         // 
         // grpDirection
         // 
         this.grpDirection.Controls.Add(this.rdbtnBackward);
         this.grpDirection.Controls.Add(this.rdbtnForward);
         this.grpDirection.Location = new System.Drawing.Point(188, 54);
         this.grpDirection.Name = "grpDirection";
         this.grpDirection.Size = new System.Drawing.Size(114, 74);
         this.grpDirection.TabIndex = 2;
         this.grpDirection.TabStop = false;
         this.grpDirection.Text = "Search Direction";
         // 
         // rdbtnBackward
         // 
         this.rdbtnBackward.AutoSize = true;
         this.rdbtnBackward.Location = new System.Drawing.Point(17, 43);
         this.rdbtnBackward.Name = "rdbtnBackward";
         this.rdbtnBackward.Size = new System.Drawing.Size(73, 17);
         this.rdbtnBackward.TabIndex = 1;
         this.rdbtnBackward.Text = "&Backward";
         this.rdbtnBackward.UseVisualStyleBackColor = true;
         // 
         // rdbtnForward
         // 
         this.rdbtnForward.AutoSize = true;
         this.rdbtnForward.Checked = true;
         this.rdbtnForward.Location = new System.Drawing.Point(17, 19);
         this.rdbtnForward.Name = "rdbtnForward";
         this.rdbtnForward.Size = new System.Drawing.Size(63, 17);
         this.rdbtnForward.TabIndex = 0;
         this.rdbtnForward.TabStop = true;
         this.rdbtnForward.Text = "&Forward";
         this.rdbtnForward.UseVisualStyleBackColor = true;
         // 
         // grpSearchIn
         // 
         this.grpSearchIn.Controls.Add(this.rdbtnSearchbyCols);
         this.grpSearchIn.Controls.Add(this.rdbtnSearchbyRows);
         this.grpSearchIn.Location = new System.Drawing.Point(74, 54);
         this.grpSearchIn.Name = "grpSearchIn";
         this.grpSearchIn.Size = new System.Drawing.Size(108, 74);
         this.grpSearchIn.TabIndex = 6;
         this.grpSearchIn.TabStop = false;
         this.grpSearchIn.Text = "Search In";
         // 
         // rdbtnSearchbyCols
         // 
         this.rdbtnSearchbyCols.AutoSize = true;
         this.rdbtnSearchbyCols.Location = new System.Drawing.Point(6, 43);
         this.rdbtnSearchbyCols.Name = "rdbtnSearchbyCols";
         this.rdbtnSearchbyCols.Size = new System.Drawing.Size(65, 17);
         this.rdbtnSearchbyCols.TabIndex = 1;
         this.rdbtnSearchbyCols.Text = "&Columns";
         this.rdbtnSearchbyCols.UseVisualStyleBackColor = true;
         this.rdbtnSearchbyCols.CheckedChanged += new System.EventHandler(this.rdbtnSearchby_CheckedChanged);
         // 
         // rdbtnSearchbyRows
         // 
         this.rdbtnSearchbyRows.AutoSize = true;
         this.rdbtnSearchbyRows.Checked = true;
         this.rdbtnSearchbyRows.Location = new System.Drawing.Point(6, 19);
         this.rdbtnSearchbyRows.Name = "rdbtnSearchbyRows";
         this.rdbtnSearchbyRows.Size = new System.Drawing.Size(52, 17);
         this.rdbtnSearchbyRows.TabIndex = 0;
         this.rdbtnSearchbyRows.TabStop = true;
         this.rdbtnSearchbyRows.Text = "&Rows";
         this.rdbtnSearchbyRows.UseVisualStyleBackColor = true;
         this.rdbtnSearchbyRows.CheckedChanged += new System.EventHandler(this.rdbtnSearchby_CheckedChanged);
         // 
         // chkMatchCase
         // 
         this.chkMatchCase.AutoSize = true;
         this.chkMatchCase.Location = new System.Drawing.Point(74, 32);
         this.chkMatchCase.Name = "chkMatchCase";
         this.chkMatchCase.Size = new System.Drawing.Size(83, 17);
         this.chkMatchCase.TabIndex = 7;
         this.chkMatchCase.Text = "&Match Case";
         this.chkMatchCase.UseVisualStyleBackColor = true;
         // 
         // ResultSearchDialog
         // 
         this.AcceptButton = this.btnFindNext;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.btnClose;
         this.ClientSize = new System.Drawing.Size(395, 137);
         this.Controls.Add(this.chkMatchCase);
         this.Controls.Add(this.grpSearchIn);
         this.Controls.Add(this.grpDirection);
         this.Controls.Add(this.btnClose);
         this.Controls.Add(this.btnFindNext);
         this.Controls.Add(this.txtSearch);
         this.Controls.Add(this.lblFindWhat);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ResultSearchDialog";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Search";
         this.grpDirection.ResumeLayout(false);
         this.grpDirection.PerformLayout();
         this.grpSearchIn.ResumeLayout(false);
         this.grpSearchIn.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label lblFindWhat;
      private System.Windows.Forms.TextBox txtSearch;
      private System.Windows.Forms.Button btnFindNext;
      private System.Windows.Forms.Button btnClose;
      private System.Windows.Forms.GroupBox grpDirection;
      private System.Windows.Forms.RadioButton rdbtnBackward;
      private System.Windows.Forms.RadioButton rdbtnForward;
      private System.Windows.Forms.GroupBox grpSearchIn;
      private System.Windows.Forms.RadioButton rdbtnSearchbyCols;
      private System.Windows.Forms.RadioButton rdbtnSearchbyRows;
      private System.Windows.Forms.CheckBox chkMatchCase;
   }
}