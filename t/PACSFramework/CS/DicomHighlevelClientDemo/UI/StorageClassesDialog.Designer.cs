namespace DicomDemo.UI
{
   partial class StorageClassesDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StorageClassesDialog));
         this.buttonCancel = new System.Windows.Forms.Button();
         this.buttonOK = new System.Windows.Forms.Button();
         this._listViewClasses = new System.Windows.Forms.ListView();
         this.columnHeaderUid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.buttonSelectAll = new System.Windows.Forms.Button();
         this.buttonUnselectAll = new System.Windows.Forms.Button();
         this.labelInstructions = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // buttonCancel
         // 
         this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonCancel.CausesValidation = false;
         this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.buttonCancel.Location = new System.Drawing.Point(472, 623);
         this.buttonCancel.Name = "buttonCancel";
         this.buttonCancel.Size = new System.Drawing.Size(75, 23);
         this.buttonCancel.TabIndex = 10;
         this.buttonCancel.Text = "&Cancel";
         // 
         // buttonOK
         // 
         this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.buttonOK.Location = new System.Drawing.Point(387, 623);
         this.buttonOK.Name = "buttonOK";
         this.buttonOK.Size = new System.Drawing.Size(75, 23);
         this.buttonOK.TabIndex = 9;
         this.buttonOK.Text = "&OK";
         // 
         // _listViewClasses
         // 
         this._listViewClasses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this._listViewClasses.CheckBoxes = true;
         this._listViewClasses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderUid,
            this.columnHeaderName});
         this._listViewClasses.FullRowSelect = true;
         this._listViewClasses.Location = new System.Drawing.Point(12, 62);
         this._listViewClasses.Name = "_listViewClasses";
         this._listViewClasses.Size = new System.Drawing.Size(534, 544);
         this._listViewClasses.TabIndex = 11;
         this._listViewClasses.UseCompatibleStateImageBehavior = false;
         this._listViewClasses.View = System.Windows.Forms.View.Details;
         // 
         // columnHeaderUid
         // 
         this.columnHeaderUid.Text = "SOP Class UID";
         // 
         // columnHeaderName
         // 
         this.columnHeaderName.Text = "SOP Class Name";
         // 
         // buttonSelectAll
         // 
         this.buttonSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.buttonSelectAll.Location = new System.Drawing.Point(12, 623);
         this.buttonSelectAll.Name = "buttonSelectAll";
         this.buttonSelectAll.Size = new System.Drawing.Size(75, 23);
         this.buttonSelectAll.TabIndex = 12;
         this.buttonSelectAll.Text = "Select All";
         this.buttonSelectAll.UseVisualStyleBackColor = true;
         this.buttonSelectAll.Click += new System.EventHandler(this.buttonSelectAll_Click);
         // 
         // buttonUnselectAll
         // 
         this.buttonUnselectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.buttonUnselectAll.Location = new System.Drawing.Point(94, 623);
         this.buttonUnselectAll.Name = "buttonUnselectAll";
         this.buttonUnselectAll.Size = new System.Drawing.Size(75, 23);
         this.buttonUnselectAll.TabIndex = 13;
         this.buttonUnselectAll.Text = "Unselect All";
         this.buttonUnselectAll.UseVisualStyleBackColor = true;
         this.buttonUnselectAll.Click += new System.EventHandler(this.buttonUnselectAll_Click);
         // 
         // labelInstructions
         // 
         this.labelInstructions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.labelInstructions.Location = new System.Drawing.Point(12, 9);
         this.labelInstructions.Name = "labelInstructions";
         this.labelInstructions.Size = new System.Drawing.Size(535, 38);
         this.labelInstructions.TabIndex = 14;
         this.labelInstructions.Text = "label1";
         // 
         // StorageClassesDialog
         // 
         this.AcceptButton = this.buttonOK;
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
         this.CancelButton = this.buttonCancel;
         this.ClientSize = new System.Drawing.Size(558, 658);
         this.Controls.Add(this.labelInstructions);
         this.Controls.Add(this.buttonUnselectAll);
         this.Controls.Add(this.buttonSelectAll);
         this.Controls.Add(this._listViewClasses);
         this.Controls.Add(this.buttonCancel);
         this.Controls.Add(this.buttonOK);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "StorageClassesDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "C-GET Storage Classes";
         this.Load += new System.EventHandler(this.StorageClassesDialog_Load);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button buttonCancel;
      private System.Windows.Forms.Button buttonOK;
      private System.Windows.Forms.ListView _listViewClasses;
      private System.Windows.Forms.Button buttonSelectAll;
      private System.Windows.Forms.Button buttonUnselectAll;
      private System.Windows.Forms.ColumnHeader columnHeaderUid;
      private System.Windows.Forms.ColumnHeader columnHeaderName;
      private System.Windows.Forms.Label labelInstructions;
   }
}