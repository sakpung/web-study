namespace Leadtools.Medical.Winforms
{
   partial class StorageClassesTabControl
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
         this.tabControl1 = new System.Windows.Forms.TabControl();
         this.tabPageStorageClass = new System.Windows.Forms.TabPage();
         this.tabPageTransferSyntax = new System.Windows.Forms.TabPage();
         this.tabControl1.SuspendLayout();
         this.SuspendLayout();
         // 
         // tabControl1
         // 
         this.tabControl1.Controls.Add(this.tabPageStorageClass);
         this.tabControl1.Controls.Add(this.tabPageTransferSyntax);
         this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tabControl1.Location = new System.Drawing.Point(0, 0);
         this.tabControl1.Name = "tabControl1";
         this.tabControl1.SelectedIndex = 0;
         this.tabControl1.Size = new System.Drawing.Size(668, 387);
         this.tabControl1.TabIndex = 0;
         // 
         // tabPageStorageClass
         // 
         this.tabPageStorageClass.Location = new System.Drawing.Point(4, 22);
         this.tabPageStorageClass.Name = "tabPageStorageClass";
         this.tabPageStorageClass.Padding = new System.Windows.Forms.Padding(3);
         this.tabPageStorageClass.Size = new System.Drawing.Size(660, 361);
         this.tabPageStorageClass.TabIndex = 0;
         this.tabPageStorageClass.Text = "Storage Classes";
         this.tabPageStorageClass.UseVisualStyleBackColor = true;
         // 
         // tabPageTransferSyntax
         // 
         this.tabPageTransferSyntax.Location = new System.Drawing.Point(4, 22);
         this.tabPageTransferSyntax.Name = "tabPageTransferSyntax";
         this.tabPageTransferSyntax.Padding = new System.Windows.Forms.Padding(3);
         this.tabPageTransferSyntax.Size = new System.Drawing.Size(608, 310);
         this.tabPageTransferSyntax.TabIndex = 1;
         this.tabPageTransferSyntax.Text = "Transfer Syntax";
         this.tabPageTransferSyntax.UseVisualStyleBackColor = true;
         // 
         // StorageClassesTabControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.tabControl1);
         this.Name = "StorageClassesTabControl";
         this.Size = new System.Drawing.Size(668, 387);
         this.tabControl1.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TabControl tabControl1;
      private System.Windows.Forms.TabPage tabPageStorageClass;
      private System.Windows.Forms.TabPage tabPageTransferSyntax;
   }
}
