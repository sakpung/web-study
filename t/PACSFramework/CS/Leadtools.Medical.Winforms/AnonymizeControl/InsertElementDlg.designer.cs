namespace Leadtools.Medical.Winforms.Anonymize
{
   partial class InsertElementDlg
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
         this.label2 = new System.Windows.Forms.Label();
         this.buttonSearch = new System.Windows.Forms.Button();
         this.textBoxSearch = new System.Windows.Forms.TextBox();
         this.buttonOK = new System.Windows.Forms.Button();
         this.buttonCancel = new System.Windows.Forms.Button();
         this.label1 = new System.Windows.Forms.Label();
         this.listViewTags = new System.Windows.Forms.ListView();
         this.columnHeaderTag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeaderVr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.SuspendLayout();
         // 
         // label2
         // 
         this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(264, 12);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(44, 13);
         this.label2.TabIndex = 17;
         this.label2.Text = "Search:";
         // 
         // buttonSearch
         // 
         this.buttonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonSearch.Location = new System.Drawing.Point(541, 2);
         this.buttonSearch.Name = "buttonSearch";
         this.buttonSearch.Size = new System.Drawing.Size(75, 23);
         this.buttonSearch.TabIndex = 16;
         this.buttonSearch.Text = "Search";
         this.buttonSearch.UseVisualStyleBackColor = true;
         this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
         // 
         // textBoxSearch
         // 
         this.textBoxSearch.AcceptsReturn = true;
         this.textBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.textBoxSearch.Location = new System.Drawing.Point(314, 5);
         this.textBoxSearch.Name = "textBoxSearch";
         this.textBoxSearch.Size = new System.Drawing.Size(227, 20);
         this.textBoxSearch.TabIndex = 15;
         this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
         this.textBoxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSearch_KeyDown);
         // 
         // buttonOK
         // 
         this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonOK.Location = new System.Drawing.Point(459, 426);
         this.buttonOK.Name = "buttonOK";
         this.buttonOK.Size = new System.Drawing.Size(75, 23);
         this.buttonOK.TabIndex = 12;
         this.buttonOK.Text = "&OK";
         this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
         // 
         // buttonCancel
         // 
         this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.buttonCancel.Location = new System.Drawing.Point(540, 426);
         this.buttonCancel.Name = "buttonCancel";
         this.buttonCancel.Size = new System.Drawing.Size(75, 23);
         this.buttonCancel.TabIndex = 11;
         this.buttonCancel.Text = "&Cancel";
         // 
         // label1
         // 
         this.label1.Location = new System.Drawing.Point(11, 6);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(100, 16);
         this.label1.TabIndex = 10;
         this.label1.Text = "Tag:";
         // 
         // listViewTags
         // 
         this.listViewTags.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.listViewTags.CheckBoxes = true;
         this.listViewTags.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderTag,
            this.columnHeaderName,
            this.columnHeaderVr});
         this.listViewTags.FullRowSelect = true;
         this.listViewTags.HideSelection = false;
         this.listViewTags.Location = new System.Drawing.Point(13, 28);
         this.listViewTags.Name = "listViewTags";
         this.listViewTags.Size = new System.Drawing.Size(601, 381);
         this.listViewTags.TabIndex = 18;
         this.listViewTags.UseCompatibleStateImageBehavior = false;
         this.listViewTags.View = System.Windows.Forms.View.Details;
         this.listViewTags.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewTags_ColumnClick);
         this.listViewTags.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listViewTags_ItemCheck);
         this.listViewTags.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewTags_ItemChecked);
         // 
         // columnHeaderTag
         // 
         this.columnHeaderTag.Text = "Tag";
         this.columnHeaderTag.Width = 119;
         // 
         // columnHeaderName
         // 
         this.columnHeaderName.Text = "Name";
         this.columnHeaderName.Width = 328;
         // 
         // columnHeaderVr
         // 
         this.columnHeaderVr.Text = "VR";
         this.columnHeaderVr.Width = 328;
         // 
         // InsertElementDlg
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.AutoSize = true;
         this.ClientSize = new System.Drawing.Size(626, 463);
         this.Controls.Add(this.listViewTags);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.buttonSearch);
         this.Controls.Add(this.textBoxSearch);
         this.Controls.Add(this.buttonOK);
         this.Controls.Add(this.buttonCancel);
         this.Controls.Add(this.label1);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "InsertElementDlg";
         this.ShowInTaskbar = false;
         this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Insert Element";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InsertElementDlg_FormClosing);
         this.Load += new System.EventHandler(this.InsertElementDlg_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Button buttonSearch;
      private System.Windows.Forms.TextBox textBoxSearch;
      private System.Windows.Forms.Button buttonOK;
      private System.Windows.Forms.Button buttonCancel;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.ListView listViewTags;
      private System.Windows.Forms.ColumnHeader columnHeaderTag;
      private System.Windows.Forms.ColumnHeader columnHeaderName;
      private System.Windows.Forms.ColumnHeader columnHeaderVr;

   }
}