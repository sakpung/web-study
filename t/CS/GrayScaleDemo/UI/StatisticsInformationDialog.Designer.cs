namespace GrayScaleDemo
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
            System.Windows.Forms.ListViewItem listViewItem85 = new System.Windows.Forms.ListViewItem("Original Format:");
            System.Windows.Forms.ListViewItem listViewItem86 = new System.Windows.Forms.ListViewItem("Size:");
            System.Windows.Forms.ListViewItem listViewItem87 = new System.Windows.Forms.ListViewItem("Resolution:");
            System.Windows.Forms.ListViewItem listViewItem88 = new System.Windows.Forms.ListViewItem("Bits/Pixel:");
            System.Windows.Forms.ListViewItem listViewItem89 = new System.Windows.Forms.ListViewItem("Bytes/Line:");
            System.Windows.Forms.ListViewItem listViewItem90 = new System.Windows.Forms.ListViewItem("Data Size:");
            System.Windows.Forms.ListViewItem listViewItem91 = new System.Windows.Forms.ListViewItem("View Perspective:");
            System.Windows.Forms.ListViewItem listViewItem92 = new System.Windows.Forms.ListViewItem("Order:");
            System.Windows.Forms.ListViewItem listViewItem93 = new System.Windows.Forms.ListViewItem("Has Region:");
            System.Windows.Forms.ListViewItem listViewItem94 = new System.Windows.Forms.ListViewItem("Compression:");
            System.Windows.Forms.ListViewItem listViewItem95 = new System.Windows.Forms.ListViewItem("Memory:");
            System.Windows.Forms.ListViewItem listViewItem96 = new System.Windows.Forms.ListViewItem("Signed:");
            System.Windows.Forms.ListViewItem listViewItem97 = new System.Windows.Forms.ListViewItem("Gray Scale Mode:");
            System.Windows.Forms.ListViewItem listViewItem98 = new System.Windows.Forms.ListViewItem("Low Bit:");
            System.Windows.Forms.ListViewItem listViewItem99 = new System.Windows.Forms.ListViewItem("High Bit:");
            System.Windows.Forms.ListViewItem listViewItem100 = new System.Windows.Forms.ListViewItem("Mean:");
            System.Windows.Forms.ListViewItem listViewItem101 = new System.Windows.Forms.ListViewItem("Standard Deviation:");
            System.Windows.Forms.ListViewItem listViewItem102 = new System.Windows.Forms.ListViewItem("Median:");
            System.Windows.Forms.ListViewItem listViewItem103 = new System.Windows.Forms.ListViewItem("Minimum:");
            System.Windows.Forms.ListViewItem listViewItem104 = new System.Windows.Forms.ListViewItem("Maximum");
            System.Windows.Forms.ListViewItem listViewItem105 = new System.Windows.Forms.ListViewItem("Pixel Count:");
            this._btnOK = new System.Windows.Forms.Button();
            this._lvInfo = new System.Windows.Forms.ListView();
            this._chItem = new System.Windows.Forms.ColumnHeader();
            this._chValue = new System.Windows.Forms.ColumnHeader();
            this._btnPageNext = new System.Windows.Forms.Button();
            this._btnPageLast = new System.Windows.Forms.Button();
            this._btnPageFirst = new System.Windows.Forms.Button();
            this._btnPagePrevious = new System.Windows.Forms.Button();
            this._lblPage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _btnOK
            // 
            this._btnOK.Location = new System.Drawing.Point(116, 375);
            this._btnOK.Name = "_btnOK";
            this._btnOK.Size = new System.Drawing.Size(69, 22);
            this._btnOK.TabIndex = 1;
            this._btnOK.Text = "OK";
            this._btnOK.UseVisualStyleBackColor = true;
            this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
            // 
            // _lvInfo
            // 
            this._lvInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._chItem,
            this._chValue});
            this._lvInfo.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this._lvInfo.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem85,
            listViewItem86,
            listViewItem87,
            listViewItem88,
            listViewItem89,
            listViewItem90,
            listViewItem91,
            listViewItem92,
            listViewItem93,
            listViewItem94,
            listViewItem95,
            listViewItem96,
            listViewItem97,
            listViewItem98,
            listViewItem99,
            listViewItem100,
            listViewItem101,
            listViewItem102,
            listViewItem103,
            listViewItem104,
            listViewItem105});
            this._lvInfo.Location = new System.Drawing.Point(10, 69);
            this._lvInfo.Margin = new System.Windows.Forms.Padding(2);
            this._lvInfo.Name = "_lvInfo";
            this._lvInfo.Size = new System.Drawing.Size(280, 286);
            this._lvInfo.TabIndex = 6;
            this._lvInfo.UseCompatibleStateImageBehavior = false;
            this._lvInfo.View = System.Windows.Forms.View.Details;
            // 
            // _chItem
            // 
            this._chItem.Text = "Item";
            this._chItem.Width = 114;
            // 
            // _chValue
            // 
            this._chValue.Text = "Value";
            this._chValue.Width = 192;
            // 
            // _btnPageNext
            // 
            this._btnPageNext.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._btnPageNext.Location = new System.Drawing.Point(233, 36);
            this._btnPageNext.Margin = new System.Windows.Forms.Padding(2);
            this._btnPageNext.Name = "_btnPageNext";
            this._btnPageNext.Size = new System.Drawing.Size(28, 22);
            this._btnPageNext.TabIndex = 10;
            this._btnPageNext.Text = ">";
            this._btnPageNext.UseVisualStyleBackColor = true;
            this._btnPageNext.Click += new System.EventHandler(this._btnPageNext_Click);
            // 
            // _btnPageLast
            // 
            this._btnPageLast.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._btnPageLast.Location = new System.Drawing.Point(262, 36);
            this._btnPageLast.Margin = new System.Windows.Forms.Padding(2);
            this._btnPageLast.Name = "_btnPageLast";
            this._btnPageLast.Size = new System.Drawing.Size(28, 22);
            this._btnPageLast.TabIndex = 11;
            this._btnPageLast.Text = ">|";
            this._btnPageLast.UseVisualStyleBackColor = true;
            this._btnPageLast.Click += new System.EventHandler(this._btnPageLast_Click);
            // 
            // _btnPageFirst
            // 
            this._btnPageFirst.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._btnPageFirst.Location = new System.Drawing.Point(10, 36);
            this._btnPageFirst.Margin = new System.Windows.Forms.Padding(2);
            this._btnPageFirst.Name = "_btnPageFirst";
            this._btnPageFirst.Size = new System.Drawing.Size(28, 22);
            this._btnPageFirst.TabIndex = 7;
            this._btnPageFirst.Text = "|<";
            this._btnPageFirst.UseVisualStyleBackColor = true;
            this._btnPageFirst.Click += new System.EventHandler(this._btnPageFirst_Click);
            // 
            // _btnPagePrevious
            // 
            this._btnPagePrevious.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._btnPagePrevious.Location = new System.Drawing.Point(38, 36);
            this._btnPagePrevious.Margin = new System.Windows.Forms.Padding(2);
            this._btnPagePrevious.Name = "_btnPagePrevious";
            this._btnPagePrevious.Size = new System.Drawing.Size(28, 22);
            this._btnPagePrevious.TabIndex = 8;
            this._btnPagePrevious.Text = "<";
            this._btnPagePrevious.UseVisualStyleBackColor = true;
            this._btnPagePrevious.Click += new System.EventHandler(this._btnPagePrevious_Click);
            // 
            // _lblPage
            // 
            this._lblPage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._lblPage.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblPage.Location = new System.Drawing.Point(66, 36);
            this._lblPage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._lblPage.Name = "_lblPage";
            this._lblPage.Size = new System.Drawing.Size(166, 22);
            this._lblPage.TabIndex = 9;
            this._lblPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StatisticsInformationDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 409);
            this.Controls.Add(this._btnPageNext);
            this.Controls.Add(this._btnPageLast);
            this.Controls.Add(this._btnPageFirst);
            this.Controls.Add(this._btnPagePrevious);
            this.Controls.Add(this._lblPage);
            this.Controls.Add(this._lvInfo);
            this.Controls.Add(this._btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StatisticsInformationDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Image Information";
            this.Load += new System.EventHandler(this.StatisticsInformationDialog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _btnOK;
        private System.Windows.Forms.ListView _lvInfo;
        private System.Windows.Forms.ColumnHeader _chItem;
        private System.Windows.Forms.ColumnHeader _chValue;
        private System.Windows.Forms.Button _btnPageNext;
        private System.Windows.Forms.Button _btnPageLast;
        private System.Windows.Forms.Button _btnPageFirst;
        private System.Windows.Forms.Button _btnPagePrevious;
        private System.Windows.Forms.Label _lblPage;
    }
}