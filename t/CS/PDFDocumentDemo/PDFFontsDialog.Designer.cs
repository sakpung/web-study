namespace PDFDocumentDemo
{
   partial class PDFFontsDialog
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
            this._okButton = new System.Windows.Forms.Button();
            this._fontsGroupBox = new System.Windows.Forms.GroupBox();
            this._fontsListView = new System.Windows.Forms.ListView();
            this._faceNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._typeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._encodingColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._fontsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // _okButton
            // 
            this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._okButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._okButton.Location = new System.Drawing.Point(415, 261);
            this._okButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(75, 23);
            this._okButton.TabIndex = 1;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = true;
            // 
            // _fontsGroupBox
            // 
            this._fontsGroupBox.Controls.Add(this._fontsListView);
            this._fontsGroupBox.Location = new System.Drawing.Point(9, 8);
            this._fontsGroupBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._fontsGroupBox.Name = "_fontsGroupBox";
            this._fontsGroupBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._fontsGroupBox.Size = new System.Drawing.Size(481, 239);
            this._fontsGroupBox.TabIndex = 0;
            this._fontsGroupBox.TabStop = false;
            this._fontsGroupBox.Text = "&Fonts used in this Document";
            // 
            // _fontsListView
            // 
            this._fontsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._faceNameColumnHeader,
            this._typeColumnHeader,
            this._encodingColumnHeader});
            this._fontsListView.Location = new System.Drawing.Point(15, 24);
            this._fontsListView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._fontsListView.Name = "_fontsListView";
            this._fontsListView.Size = new System.Drawing.Size(447, 202);
            this._fontsListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this._fontsListView.TabIndex = 0;
            this._fontsListView.UseCompatibleStateImageBehavior = false;
            this._fontsListView.View = System.Windows.Forms.View.Details;
            // 
            // _faceNameColumnHeader
            // 
            this._faceNameColumnHeader.Text = "Face Name";
            this._faceNameColumnHeader.Width = 120;
            // 
            // _typeColumnHeader
            // 
            this._typeColumnHeader.Text = "Type";
            this._typeColumnHeader.Width = 120;
            // 
            // _encodingColumnHeader
            // 
            this._encodingColumnHeader.Text = "Encoding";
            this._encodingColumnHeader.Width = 180;
            // 
            // PDFFontsDialog
            // 
            this.AcceptButton = this._okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._okButton;
            this.ClientSize = new System.Drawing.Size(503, 292);
            this.ControlBox = false;
            this.Controls.Add(this._fontsGroupBox);
            this.Controls.Add(this._okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PDFFontsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Fonts";
            this._fontsGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _okButton;
      private System.Windows.Forms.GroupBox _fontsGroupBox;
      private System.Windows.Forms.ListView _fontsListView;
      private System.Windows.Forms.ColumnHeader _faceNameColumnHeader;
      private System.Windows.Forms.ColumnHeader _typeColumnHeader;
      private System.Windows.Forms.ColumnHeader _encodingColumnHeader;
   }
}