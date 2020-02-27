namespace OcrDemo.DocumentInfoControl
{
   partial class DocumentInfoControl
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
         System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Type",
            "None"}, -1);
         System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "Pages Count",
            "0"}, -1);
         this._titleLabel = new System.Windows.Forms.Label();
         this.columnHeaderProperty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeaderValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this._lvOcrDocumentInfo = new System.Windows.Forms.ListView();
         this.SuspendLayout();
         // 
         // _titleLabel
         // 
         this._titleLabel.Dock = System.Windows.Forms.DockStyle.Top;
         this._titleLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._titleLabel.Location = new System.Drawing.Point(0, 0);
         this._titleLabel.Name = "_titleLabel";
         this._titleLabel.Size = new System.Drawing.Size(180, 13);
         this._titleLabel.TabIndex = 2;
         this._titleLabel.Text = "OCR Document Information";
         this._titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // columnHeaderProperty
         // 
         this.columnHeaderProperty.Text = "Property";
         this.columnHeaderProperty.Width = 108;
         // 
         // columnHeaderValue
         // 
         this.columnHeaderValue.Text = "Value";
         this.columnHeaderValue.Width = 67;
         // 
         // _lvOcrDocumentInfo
         // 
         this._lvOcrDocumentInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderProperty,
            this.columnHeaderValue});
         this._lvOcrDocumentInfo.Dock = System.Windows.Forms.DockStyle.Fill;
         this._lvOcrDocumentInfo.FullRowSelect = true;
         this._lvOcrDocumentInfo.GridLines = true;
         this._lvOcrDocumentInfo.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
         this._lvOcrDocumentInfo.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
         this._lvOcrDocumentInfo.Location = new System.Drawing.Point(0, 13);
         this._lvOcrDocumentInfo.Name = "_lvOcrDocumentInfo";
         this._lvOcrDocumentInfo.Size = new System.Drawing.Size(180, 339);
         this._lvOcrDocumentInfo.TabIndex = 3;
         this._lvOcrDocumentInfo.UseCompatibleStateImageBehavior = false;
         this._lvOcrDocumentInfo.View = System.Windows.Forms.View.Details;
         // 
         // DocumentInfoControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this._lvOcrDocumentInfo);
         this.Controls.Add(this._titleLabel);
         this.Name = "DocumentInfoControl";
         this.Size = new System.Drawing.Size(180, 352);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Label _titleLabel;
      private System.Windows.Forms.ColumnHeader columnHeaderProperty;
      private System.Windows.Forms.ColumnHeader columnHeaderValue;
      private System.Windows.Forms.ListView _lvOcrDocumentInfo;
   }
}
