namespace Leadtools.Ccow.Dialogs
{
   partial class SubjectListDialog
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
         this.label1 = new System.Windows.Forms.Label();
         this.listViewSubjects = new System.Windows.Forms.ListView();
         this.button1 = new System.Windows.Forms.Button();
         this.button2 = new System.Windows.Forms.Button();
         this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(13, 13);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(48, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Subjects";
         // 
         // listViewSubjects
         // 
         this.listViewSubjects.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
         this.listViewSubjects.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
         this.listViewSubjects.Location = new System.Drawing.Point(12, 29);
         this.listViewSubjects.Name = "listViewSubjects";
         this.listViewSubjects.Size = new System.Drawing.Size(296, 165);
         this.listViewSubjects.TabIndex = 1;
         this.listViewSubjects.UseCompatibleStateImageBehavior = false;
         this.listViewSubjects.View = System.Windows.Forms.View.Details;
         // 
         // button1
         // 
         this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.button1.Location = new System.Drawing.Point(233, 203);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(75, 23);
         this.button1.TabIndex = 2;
         this.button1.Text = "Cancel";
         this.button1.UseVisualStyleBackColor = true;
         // 
         // button2
         // 
         this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.button2.Location = new System.Drawing.Point(151, 203);
         this.button2.Name = "button2";
         this.button2.Size = new System.Drawing.Size(75, 23);
         this.button2.TabIndex = 3;
         this.button2.Text = "OK";
         this.button2.UseVisualStyleBackColor = true;
         // 
         // SubjectListDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(320, 238);
         this.Controls.Add(this.button2);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.listViewSubjects);
         this.Controls.Add(this.label1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "SubjectListDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Add Dependent Subjects";
         this.Load += new System.EventHandler(this.SubjectListDialog_Load);
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SubjectListDialog_FormClosing);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.ListView listViewSubjects;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.Button button2;
      private System.Windows.Forms.ColumnHeader columnHeader1;
   }
}