namespace MainDemo
{
   partial class ImageInformationDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageInformationDialog));
         this._btnOk = new System.Windows.Forms.Button();
         this._lblPage = new System.Windows.Forms.Label();
         this._btnPagePrevious = new System.Windows.Forms.Button();
         this._btnPageFirst = new System.Windows.Forms.Button();
         this._btnPageLast = new System.Windows.Forms.Button();
         this._btnPageNext = new System.Windows.Forms.Button();
         this._lvInfo = new System.Windows.Forms.ListView();
         this._chItem = new System.Windows.Forms.ColumnHeader();
         this._chValue = new System.Windows.Forms.ColumnHeader();
         this._btnPalette = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // _btnOk
         // 
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         resources.ApplyResources(this._btnOk, "_btnOk");
         this._btnOk.Name = "_btnOk";
         this._btnOk.UseVisualStyleBackColor = true;
         // 
         // _lblPage
         // 
         this._lblPage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._lblPage.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblPage, "_lblPage");
         this._lblPage.Name = "_lblPage";
         // 
         // _btnPagePrevious
         // 
         resources.ApplyResources(this._btnPagePrevious, "_btnPagePrevious");
         this._btnPagePrevious.Name = "_btnPagePrevious";
         this._btnPagePrevious.UseVisualStyleBackColor = true;
         this._btnPagePrevious.Click += new System.EventHandler(this._btnPagePrevious_Click);
         // 
         // _btnPageFirst
         // 
         resources.ApplyResources(this._btnPageFirst, "_btnPageFirst");
         this._btnPageFirst.Name = "_btnPageFirst";
         this._btnPageFirst.UseVisualStyleBackColor = true;
         this._btnPageFirst.Click += new System.EventHandler(this._btnPageFirst_Click);
         // 
         // _btnPageLast
         // 
         resources.ApplyResources(this._btnPageLast, "_btnPageLast");
         this._btnPageLast.Name = "_btnPageLast";
         this._btnPageLast.UseVisualStyleBackColor = true;
         this._btnPageLast.Click += new System.EventHandler(this._btnPageLast_Click);
         // 
         // _btnPageNext
         // 
         resources.ApplyResources(this._btnPageNext, "_btnPageNext");
         this._btnPageNext.Name = "_btnPageNext";
         this._btnPageNext.UseVisualStyleBackColor = true;
         this._btnPageNext.Click += new System.EventHandler(this._btnPageNext_Click);
         // 
         // _lvInfo
         // 
         this._lvInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._chItem,
            this._chValue});
         this._lvInfo.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
         this._lvInfo.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("_lvInfo.Items"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("_lvInfo.Items1"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("_lvInfo.Items2"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("_lvInfo.Items3"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("_lvInfo.Items4"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("_lvInfo.Items5"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("_lvInfo.Items6"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("_lvInfo.Items7"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("_lvInfo.Items8"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("_lvInfo.Items9"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("_lvInfo.Items10"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("_lvInfo.Items11"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("_lvInfo.Items12"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("_lvInfo.Items13"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("_lvInfo.Items14"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("_lvInfo.Items15")))});
         resources.ApplyResources(this._lvInfo, "_lvInfo");
         this._lvInfo.Name = "_lvInfo";
         this._lvInfo.UseCompatibleStateImageBehavior = false;
         this._lvInfo.View = System.Windows.Forms.View.Details;
         // 
         // _chItem
         // 
         resources.ApplyResources(this._chItem, "_chItem");
         // 
         // _chValue
         // 
         resources.ApplyResources(this._chValue, "_chValue");
         // 
         // _btnPalette
         // 
         resources.ApplyResources(this._btnPalette, "_btnPalette");
         this._btnPalette.Name = "_btnPalette";
         this._btnPalette.UseVisualStyleBackColor = true;
         this._btnPalette.Click += new System.EventHandler(this._btnPalette_Click);
         // 
         // ImageInformationDialog
         // 
         this.AcceptButton = this._btnOk;
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnOk;
         this.Controls.Add(this._btnPalette);
         this.Controls.Add(this._lvInfo);
         this.Controls.Add(this._btnPageNext);
         this.Controls.Add(this._btnPageLast);
         this.Controls.Add(this._btnPageFirst);
         this.Controls.Add(this._btnPagePrevious);
         this.Controls.Add(this._lblPage);
         this.Controls.Add(this._btnOk);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ImageInformationDialog";
         this.ShowInTaskbar = false;
         this.Load += new System.EventHandler(this.ImageInformationDialog_Load);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Label _lblPage;
      private System.Windows.Forms.Button _btnPagePrevious;
      private System.Windows.Forms.Button _btnPageFirst;
      private System.Windows.Forms.Button _btnPageLast;
      private System.Windows.Forms.Button _btnPageNext;
      private System.Windows.Forms.ListView _lvInfo;
      private System.Windows.Forms.Button _btnPalette;
      private System.Windows.Forms.ColumnHeader _chItem;
      private System.Windows.Forms.ColumnHeader _chValue;
   }
}