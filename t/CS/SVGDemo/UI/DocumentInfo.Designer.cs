namespace SvgDemo
{
   partial class DocumentInfo
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
         System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("File Name:");
         System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Page Number:");
         System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Total Pages:");
         System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("Is Flat:");
         System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("Is Render Optimized:");
         System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("");
         System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("Bounds:");
         System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("Is Valid:");
         System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem("Is Trimmed:");
         System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem("Resolution:");
         System.Windows.Forms.ListViewItem listViewItem11 = new System.Windows.Forms.ListViewItem("Bounds:");
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocumentInfo));
         this._closeButton = new System.Windows.Forms.Button();
         this._documentInfo = new System.Windows.Forms.ListView();
         this._chItems = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this._chValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.SuspendLayout();
         // 
         // _closeButton
         // 
         this._closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._closeButton.Location = new System.Drawing.Point(134, 234);
         this._closeButton.Name = "_closeButton";
         this._closeButton.Size = new System.Drawing.Size(75, 23);
         this._closeButton.TabIndex = 1;
         this._closeButton.Text = "Close";
         this._closeButton.UseVisualStyleBackColor = true;
         this._closeButton.Click += new System.EventHandler(this._closeButton_Click);
         // 
         // _documentInfo
         // 
         this._documentInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._chItems,
            this._chValue});
         this._documentInfo.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8,
            listViewItem9,
            listViewItem10,
            listViewItem11});
         this._documentInfo.Location = new System.Drawing.Point(10, 12);
         this._documentInfo.Name = "_documentInfo";
         this._documentInfo.Size = new System.Drawing.Size(322, 211);
         this._documentInfo.TabIndex = 2;
         this._documentInfo.UseCompatibleStateImageBehavior = false;
         this._documentInfo.View = System.Windows.Forms.View.Details;
         // 
         // _chItems
         // 
         this._chItems.Text = "Items";
         this._chItems.Width = 118;
         // 
         // _chValue
         // 
         this._chValue.Text = "Value";
         this._chValue.Width = 200;
         // 
         // DocumentInfo
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._closeButton;
         this.ClientSize = new System.Drawing.Size(342, 266);
         this.Controls.Add(this._documentInfo);
         this.Controls.Add(this._closeButton);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "DocumentInfo";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Svg Document Information";
         this.Load += new System.EventHandler(this.DocumentInfo_Load);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _closeButton;
      private System.Windows.Forms.ListView _documentInfo;
      private System.Windows.Forms.ColumnHeader _chItems;
      private System.Windows.Forms.ColumnHeader _chValue;
   }
}