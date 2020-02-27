namespace DicomDemo
{
   partial class ModifyTablesDlg
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
         this.groupBoxUidTable = new System.Windows.Forms.GroupBox();
         this.buttonUidFile = new System.Windows.Forms.Button();
         this.textBoxUidFile = new System.Windows.Forms.TextBox();
         this.buttonShowUidTable = new System.Windows.Forms.Button();
         this.buttonResetUidTable = new System.Windows.Forms.Button();
         this.buttonLoadUidTable = new System.Windows.Forms.Button();
         this.groupBoxElementTagTable = new System.Windows.Forms.GroupBox();
         this.buttonTagFile = new System.Windows.Forms.Button();
         this.buttonResetTagTable = new System.Windows.Forms.Button();
         this.textBoxTagFile = new System.Windows.Forms.TextBox();
         this.buttonLoadTagTable = new System.Windows.Forms.Button();
         this.buttonTagTable = new System.Windows.Forms.Button();
         this.groupBoxIodTable = new System.Windows.Forms.GroupBox();
         this.buttonIodFile = new System.Windows.Forms.Button();
         this.buttonResetIodTable = new System.Windows.Forms.Button();
         this.textBoxIodFile = new System.Windows.Forms.TextBox();
         this.buttonLoadIodTable = new System.Windows.Forms.Button();
         this.buttonShowIodTable = new System.Windows.Forms.Button();
         this.groupBoxContextGroupTable = new System.Windows.Forms.GroupBox();
         this.buttonContextGroupFile = new System.Windows.Forms.Button();
         this.buttonResetContextGroupTable = new System.Windows.Forms.Button();
         this.textBoxContextGroupFile = new System.Windows.Forms.TextBox();
         this.buttonLoadContextGroupTable = new System.Windows.Forms.Button();
         this.buttonShowContextGroupTable = new System.Windows.Forms.Button();
         this.buttonClose = new System.Windows.Forms.Button();
         this.groupBoxUidTable.SuspendLayout();
         this.groupBoxElementTagTable.SuspendLayout();
         this.groupBoxIodTable.SuspendLayout();
         this.groupBoxContextGroupTable.SuspendLayout();
         this.SuspendLayout();
         // 
         // groupBoxUidTable
         // 
         this.groupBoxUidTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBoxUidTable.Controls.Add(this.buttonUidFile);
         this.groupBoxUidTable.Controls.Add(this.textBoxUidFile);
         this.groupBoxUidTable.Controls.Add(this.buttonShowUidTable);
         this.groupBoxUidTable.Controls.Add(this.buttonResetUidTable);
         this.groupBoxUidTable.Controls.Add(this.buttonLoadUidTable);
         this.groupBoxUidTable.Location = new System.Drawing.Point(8, 9);
         this.groupBoxUidTable.Name = "groupBoxUidTable";
         this.groupBoxUidTable.Size = new System.Drawing.Size(696, 100);
         this.groupBoxUidTable.TabIndex = 0;
         this.groupBoxUidTable.TabStop = false;
         this.groupBoxUidTable.Text = "UID Table";
         // 
         // buttonUidFile
         // 
         this.buttonUidFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonUidFile.Location = new System.Drawing.Point(656, 16);
         this.buttonUidFile.Name = "buttonUidFile";
         this.buttonUidFile.Size = new System.Drawing.Size(32, 23);
         this.buttonUidFile.TabIndex = 4;
         this.buttonUidFile.Text = "...";
         this.buttonUidFile.UseVisualStyleBackColor = true;
         this.buttonUidFile.Click += new System.EventHandler(this.buttonUidFile_Click);
         // 
         // textBoxUidFile
         // 
         this.textBoxUidFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.textBoxUidFile.Location = new System.Drawing.Point(120, 17);
         this.textBoxUidFile.Name = "textBoxUidFile";
         this.textBoxUidFile.Size = new System.Drawing.Size(528, 20);
         this.textBoxUidFile.TabIndex = 3;
         // 
         // buttonShowUidTable
         // 
         this.buttonShowUidTable.Location = new System.Drawing.Point(16, 64);
         this.buttonShowUidTable.Name = "buttonShowUidTable";
         this.buttonShowUidTable.Size = new System.Drawing.Size(96, 23);
         this.buttonShowUidTable.TabIndex = 2;
         this.buttonShowUidTable.Text = "Show...";
         this.buttonShowUidTable.UseVisualStyleBackColor = true;
         this.buttonShowUidTable.Click += new System.EventHandler(this.buttonShowUidTable_Click);
         // 
         // buttonResetUidTable
         // 
         this.buttonResetUidTable.Location = new System.Drawing.Point(16, 40);
         this.buttonResetUidTable.Name = "buttonResetUidTable";
         this.buttonResetUidTable.Size = new System.Drawing.Size(96, 23);
         this.buttonResetUidTable.TabIndex = 1;
         this.buttonResetUidTable.Text = "Reset...";
         this.buttonResetUidTable.UseVisualStyleBackColor = true;
         this.buttonResetUidTable.Click += new System.EventHandler(this.buttonResetUidTable_Click);
         // 
         // buttonLoadUidTable
         // 
         this.buttonLoadUidTable.Location = new System.Drawing.Point(16, 16);
         this.buttonLoadUidTable.Name = "buttonLoadUidTable";
         this.buttonLoadUidTable.Size = new System.Drawing.Size(96, 23);
         this.buttonLoadUidTable.TabIndex = 0;
         this.buttonLoadUidTable.Text = "Load from file-->";
         this.buttonLoadUidTable.UseVisualStyleBackColor = true;
         this.buttonLoadUidTable.Click += new System.EventHandler(this.buttonLoadUidTable_Click);
         // 
         // groupBoxElementTagTable
         // 
         this.groupBoxElementTagTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBoxElementTagTable.Controls.Add(this.buttonTagFile);
         this.groupBoxElementTagTable.Controls.Add(this.buttonResetTagTable);
         this.groupBoxElementTagTable.Controls.Add(this.textBoxTagFile);
         this.groupBoxElementTagTable.Controls.Add(this.buttonLoadTagTable);
         this.groupBoxElementTagTable.Controls.Add(this.buttonTagTable);
         this.groupBoxElementTagTable.Location = new System.Drawing.Point(8, 110);
         this.groupBoxElementTagTable.Name = "groupBoxElementTagTable";
         this.groupBoxElementTagTable.Size = new System.Drawing.Size(696, 100);
         this.groupBoxElementTagTable.TabIndex = 1;
         this.groupBoxElementTagTable.TabStop = false;
         this.groupBoxElementTagTable.Text = "Element Tag Table";
         // 
         // buttonTagFile
         // 
         this.buttonTagFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonTagFile.Location = new System.Drawing.Point(656, 19);
         this.buttonTagFile.Name = "buttonTagFile";
         this.buttonTagFile.Size = new System.Drawing.Size(32, 23);
         this.buttonTagFile.TabIndex = 9;
         this.buttonTagFile.Text = "...";
         this.buttonTagFile.UseVisualStyleBackColor = true;
         this.buttonTagFile.Click += new System.EventHandler(this.buttonTagFile_Click);
         // 
         // buttonResetTagTable
         // 
         this.buttonResetTagTable.Location = new System.Drawing.Point(16, 43);
         this.buttonResetTagTable.Name = "buttonResetTagTable";
         this.buttonResetTagTable.Size = new System.Drawing.Size(96, 23);
         this.buttonResetTagTable.TabIndex = 6;
         this.buttonResetTagTable.Text = "Reset...";
         this.buttonResetTagTable.UseVisualStyleBackColor = true;
         this.buttonResetTagTable.Click += new System.EventHandler(this.buttonResetTagTable_Click);
         // 
         // textBoxTagFile
         // 
         this.textBoxTagFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.textBoxTagFile.Location = new System.Drawing.Point(120, 20);
         this.textBoxTagFile.Name = "textBoxTagFile";
         this.textBoxTagFile.Size = new System.Drawing.Size(528, 20);
         this.textBoxTagFile.TabIndex = 8;
         // 
         // buttonLoadTagTable
         // 
         this.buttonLoadTagTable.Location = new System.Drawing.Point(16, 19);
         this.buttonLoadTagTable.Name = "buttonLoadTagTable";
         this.buttonLoadTagTable.Size = new System.Drawing.Size(96, 23);
         this.buttonLoadTagTable.TabIndex = 5;
         this.buttonLoadTagTable.Text = "Load from file-->";
         this.buttonLoadTagTable.UseVisualStyleBackColor = true;
         this.buttonLoadTagTable.Click += new System.EventHandler(this.buttonLoadTagTable_Click);
         // 
         // buttonTagTable
         // 
         this.buttonTagTable.Location = new System.Drawing.Point(16, 67);
         this.buttonTagTable.Name = "buttonTagTable";
         this.buttonTagTable.Size = new System.Drawing.Size(96, 23);
         this.buttonTagTable.TabIndex = 7;
         this.buttonTagTable.Text = "Show...";
         this.buttonTagTable.UseVisualStyleBackColor = true;
         this.buttonTagTable.Click += new System.EventHandler(this.buttonTagTable_Click);
         // 
         // groupBoxIodTable
         // 
         this.groupBoxIodTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBoxIodTable.Controls.Add(this.buttonIodFile);
         this.groupBoxIodTable.Controls.Add(this.buttonResetIodTable);
         this.groupBoxIodTable.Controls.Add(this.textBoxIodFile);
         this.groupBoxIodTable.Controls.Add(this.buttonLoadIodTable);
         this.groupBoxIodTable.Controls.Add(this.buttonShowIodTable);
         this.groupBoxIodTable.Location = new System.Drawing.Point(8, 211);
         this.groupBoxIodTable.Name = "groupBoxIodTable";
         this.groupBoxIodTable.Size = new System.Drawing.Size(696, 100);
         this.groupBoxIodTable.TabIndex = 2;
         this.groupBoxIodTable.TabStop = false;
         this.groupBoxIodTable.Text = "IOD Table";
         // 
         // buttonIodFile
         // 
         this.buttonIodFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonIodFile.Location = new System.Drawing.Point(656, 19);
         this.buttonIodFile.Name = "buttonIodFile";
         this.buttonIodFile.Size = new System.Drawing.Size(32, 23);
         this.buttonIodFile.TabIndex = 14;
         this.buttonIodFile.Text = "...";
         this.buttonIodFile.UseVisualStyleBackColor = true;
         this.buttonIodFile.Click += new System.EventHandler(this.buttonIodFile_Click);
         // 
         // buttonResetIodTable
         // 
         this.buttonResetIodTable.Location = new System.Drawing.Point(16, 43);
         this.buttonResetIodTable.Name = "buttonResetIodTable";
         this.buttonResetIodTable.Size = new System.Drawing.Size(96, 23);
         this.buttonResetIodTable.TabIndex = 11;
         this.buttonResetIodTable.Text = "Reset...";
         this.buttonResetIodTable.UseVisualStyleBackColor = true;
         this.buttonResetIodTable.Click += new System.EventHandler(this.buttonResetIodTable_Click);
         // 
         // textBoxIodFile
         // 
         this.textBoxIodFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.textBoxIodFile.Location = new System.Drawing.Point(120, 20);
         this.textBoxIodFile.Name = "textBoxIodFile";
         this.textBoxIodFile.Size = new System.Drawing.Size(528, 20);
         this.textBoxIodFile.TabIndex = 13;
         // 
         // buttonLoadIodTable
         // 
         this.buttonLoadIodTable.Location = new System.Drawing.Point(16, 19);
         this.buttonLoadIodTable.Name = "buttonLoadIodTable";
         this.buttonLoadIodTable.Size = new System.Drawing.Size(96, 23);
         this.buttonLoadIodTable.TabIndex = 10;
         this.buttonLoadIodTable.Text = "Load from file-->";
         this.buttonLoadIodTable.UseVisualStyleBackColor = true;
         this.buttonLoadIodTable.Click += new System.EventHandler(this.buttonLoadIodTable_Click);
         // 
         // buttonShowIodTable
         // 
         this.buttonShowIodTable.Location = new System.Drawing.Point(16, 67);
         this.buttonShowIodTable.Name = "buttonShowIodTable";
         this.buttonShowIodTable.Size = new System.Drawing.Size(96, 23);
         this.buttonShowIodTable.TabIndex = 12;
         this.buttonShowIodTable.Text = "Show...";
         this.buttonShowIodTable.UseVisualStyleBackColor = true;
         this.buttonShowIodTable.Click += new System.EventHandler(this.buttonShowIodTable_Click);
         // 
         // groupBoxContextGroupTable
         // 
         this.groupBoxContextGroupTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBoxContextGroupTable.Controls.Add(this.buttonContextGroupFile);
         this.groupBoxContextGroupTable.Controls.Add(this.buttonResetContextGroupTable);
         this.groupBoxContextGroupTable.Controls.Add(this.textBoxContextGroupFile);
         this.groupBoxContextGroupTable.Controls.Add(this.buttonLoadContextGroupTable);
         this.groupBoxContextGroupTable.Controls.Add(this.buttonShowContextGroupTable);
         this.groupBoxContextGroupTable.Location = new System.Drawing.Point(8, 312);
         this.groupBoxContextGroupTable.Name = "groupBoxContextGroupTable";
         this.groupBoxContextGroupTable.Size = new System.Drawing.Size(696, 100);
         this.groupBoxContextGroupTable.TabIndex = 3;
         this.groupBoxContextGroupTable.TabStop = false;
         this.groupBoxContextGroupTable.Text = "Context Group Table";
         // 
         // buttonContextGroupFile
         // 
         this.buttonContextGroupFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonContextGroupFile.Location = new System.Drawing.Point(656, 19);
         this.buttonContextGroupFile.Name = "buttonContextGroupFile";
         this.buttonContextGroupFile.Size = new System.Drawing.Size(32, 23);
         this.buttonContextGroupFile.TabIndex = 19;
         this.buttonContextGroupFile.Text = "...";
         this.buttonContextGroupFile.UseVisualStyleBackColor = true;
         this.buttonContextGroupFile.Click += new System.EventHandler(this.buttonContextGroupFile_Click);
         // 
         // buttonResetContextGroupTable
         // 
         this.buttonResetContextGroupTable.Location = new System.Drawing.Point(16, 43);
         this.buttonResetContextGroupTable.Name = "buttonResetContextGroupTable";
         this.buttonResetContextGroupTable.Size = new System.Drawing.Size(96, 23);
         this.buttonResetContextGroupTable.TabIndex = 16;
         this.buttonResetContextGroupTable.Text = "Reset...";
         this.buttonResetContextGroupTable.UseVisualStyleBackColor = true;
         this.buttonResetContextGroupTable.Click += new System.EventHandler(this.buttonResetContextGroupTable_Click);
         // 
         // textBoxContextGroupFile
         // 
         this.textBoxContextGroupFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.textBoxContextGroupFile.Location = new System.Drawing.Point(120, 20);
         this.textBoxContextGroupFile.Name = "textBoxContextGroupFile";
         this.textBoxContextGroupFile.Size = new System.Drawing.Size(528, 20);
         this.textBoxContextGroupFile.TabIndex = 18;
         // 
         // buttonLoadContextGroupTable
         // 
         this.buttonLoadContextGroupTable.Location = new System.Drawing.Point(16, 19);
         this.buttonLoadContextGroupTable.Name = "buttonLoadContextGroupTable";
         this.buttonLoadContextGroupTable.Size = new System.Drawing.Size(96, 23);
         this.buttonLoadContextGroupTable.TabIndex = 15;
         this.buttonLoadContextGroupTable.Text = "Load from file-->";
         this.buttonLoadContextGroupTable.UseVisualStyleBackColor = true;
         this.buttonLoadContextGroupTable.Click += new System.EventHandler(this.buttonLoadContextGroupTable_Click);
         // 
         // buttonShowContextGroupTable
         // 
         this.buttonShowContextGroupTable.Location = new System.Drawing.Point(16, 67);
         this.buttonShowContextGroupTable.Name = "buttonShowContextGroupTable";
         this.buttonShowContextGroupTable.Size = new System.Drawing.Size(96, 23);
         this.buttonShowContextGroupTable.TabIndex = 17;
         this.buttonShowContextGroupTable.Text = "Show...";
         this.buttonShowContextGroupTable.UseVisualStyleBackColor = true;
         this.buttonShowContextGroupTable.Click += new System.EventHandler(this.buttonShowContextGroupTable_Click);
         // 
         // buttonClose
         // 
         this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.buttonClose.Location = new System.Drawing.Point(632, 424);
         this.buttonClose.Name = "buttonClose";
         this.buttonClose.Size = new System.Drawing.Size(75, 23);
         this.buttonClose.TabIndex = 4;
         this.buttonClose.Text = "Close";
         this.buttonClose.UseVisualStyleBackColor = true;
         this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
         // 
         // ModifyTablesDlg
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.buttonClose;
         this.ClientSize = new System.Drawing.Size(729, 469);
         this.Controls.Add(this.buttonClose);
         this.Controls.Add(this.groupBoxContextGroupTable);
         this.Controls.Add(this.groupBoxIodTable);
         this.Controls.Add(this.groupBoxElementTagTable);
         this.Controls.Add(this.groupBoxUidTable);
         this.MinimizeBox = false;
         this.Name = "ModifyTablesDlg";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Modify Tables";
         this.Load += new System.EventHandler(this.ModifyTablesDlg_Load);
         this.groupBoxUidTable.ResumeLayout(false);
         this.groupBoxUidTable.PerformLayout();
         this.groupBoxElementTagTable.ResumeLayout(false);
         this.groupBoxElementTagTable.PerformLayout();
         this.groupBoxIodTable.ResumeLayout(false);
         this.groupBoxIodTable.PerformLayout();
         this.groupBoxContextGroupTable.ResumeLayout(false);
         this.groupBoxContextGroupTable.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox groupBoxUidTable;
      private System.Windows.Forms.GroupBox groupBoxElementTagTable;
      private System.Windows.Forms.GroupBox groupBoxIodTable;
      private System.Windows.Forms.GroupBox groupBoxContextGroupTable;
      private System.Windows.Forms.Button buttonUidFile;
      private System.Windows.Forms.TextBox textBoxUidFile;
      private System.Windows.Forms.Button buttonShowUidTable;
      private System.Windows.Forms.Button buttonResetUidTable;
      private System.Windows.Forms.Button buttonLoadUidTable;
      private System.Windows.Forms.Button buttonTagFile;
      private System.Windows.Forms.Button buttonResetTagTable;
      private System.Windows.Forms.TextBox textBoxTagFile;
      private System.Windows.Forms.Button buttonLoadTagTable;
      private System.Windows.Forms.Button buttonTagTable;
      private System.Windows.Forms.Button buttonIodFile;
      private System.Windows.Forms.Button buttonResetIodTable;
      private System.Windows.Forms.TextBox textBoxIodFile;
      private System.Windows.Forms.Button buttonLoadIodTable;
      private System.Windows.Forms.Button buttonShowIodTable;
      private System.Windows.Forms.Button buttonContextGroupFile;
      private System.Windows.Forms.Button buttonResetContextGroupTable;
      private System.Windows.Forms.TextBox textBoxContextGroupFile;
      private System.Windows.Forms.Button buttonLoadContextGroupTable;
      private System.Windows.Forms.Button buttonShowContextGroupTable;
      private System.Windows.Forms.Button buttonClose;
   }
}