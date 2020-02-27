namespace DicomDemo
{
    partial class Page5
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtElementValue = new System.Windows.Forms.TextBox();
            this.lstEmptyTags = new DicomDemo.MyListView();
            this.columnTag = new System.Windows.Forms.ColumnHeader();
            this.columnDescription = new System.Windows.Forms.ColumnHeader();
            this.columnValue = new System.Windows.Forms.ColumnHeader();
            this.treeDSResult = new DicomDemo.MyTreeView();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(530, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "The list below specifies required tags that must have values (Type 1 tags).  Doub" +
                "le click each tag and assign it ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "a proper value.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 419);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Element Value: ";
            // 
            // txtElementValue
            // 
            this.txtElementValue.Location = new System.Drawing.Point(103, 416);
            this.txtElementValue.Name = "txtElementValue";
            this.txtElementValue.ReadOnly = true;
            this.txtElementValue.Size = new System.Drawing.Size(496, 20);
            this.txtElementValue.TabIndex = 4;
            this.txtElementValue.TabStop = false;
            // 
            // lstEmptyTags
            // 
            this.lstEmptyTags.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnTag,
            this.columnDescription,
            this.columnValue});
            this.lstEmptyTags.FullRowSelect = true;
            this.lstEmptyTags.Location = new System.Drawing.Point(19, 64);
            this.lstEmptyTags.MultiSelect = false;
            this.lstEmptyTags.Name = "lstEmptyTags";
            this.lstEmptyTags.Size = new System.Drawing.Size(580, 160);
            this.lstEmptyTags.TabIndex = 0;
            this.lstEmptyTags.UseCompatibleStateImageBehavior = false;
            this.lstEmptyTags.View = System.Windows.Forms.View.Details;
            this.lstEmptyTags.DoubleClick += new System.EventHandler(this.lstEmptyTags_DoubleClick);
            this.lstEmptyTags.SelectedIndexChanged += new System.EventHandler(this.lstEmptyTags_SelectedIndexChanged);
            // 
            // columnTag
            // 
            this.columnTag.Text = "Tag";
            this.columnTag.Width = 95;
            // 
            // columnDescription
            // 
            this.columnDescription.Text = "Description";
            this.columnDescription.Width = 233;
            // 
            // columnValue
            // 
            this.columnValue.Text = "Value";
            this.columnValue.Width = 189;
            // 
            // treeDSResult
            // 
            this.treeDSResult.Location = new System.Drawing.Point(19, 240);
            this.treeDSResult.Name = "treeDSResult";
            this.treeDSResult.Size = new System.Drawing.Size(580, 160);
            this.treeDSResult.TabIndex = 1;
            this.treeDSResult.DoubleClick += new System.EventHandler(this.treeDSResult_DoubleClick);
            this.treeDSResult.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeDSResult_AfterSelect);
            // 
            // Page5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstEmptyTags);
            this.Controls.Add(this.txtElementValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.treeDSResult);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Page5";
            this.Size = new System.Drawing.Size(618, 452);
            this.VisibleChanged += new System.EventHandler(this.Page5_VisibleChanged);
            this.Load += new System.EventHandler(this.Page5_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private MyTreeView treeDSResult;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtElementValue;
        private MyListView lstEmptyTags;
        private System.Windows.Forms.ColumnHeader columnTag;
        private System.Windows.Forms.ColumnHeader columnDescription;
        private System.Windows.Forms.ColumnHeader columnValue;
    }
}
