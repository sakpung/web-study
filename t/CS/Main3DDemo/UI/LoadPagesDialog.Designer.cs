namespace Main3DDemo
{
   partial class LoadPagesDialog
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
           this.groupBox1 = new System.Windows.Forms.GroupBox();
           this._chkLoad = new System.Windows.Forms.CheckBox();
           this._txtLastPage = new Main3DDemo.NumericTextBox();
           this._txtFirstPage = new Main3DDemo.NumericTextBox();
           this._lblLastPage = new System.Windows.Forms.Label();
           this._lblFirstPage = new System.Windows.Forms.Label();
           this._lblLoadPages = new System.Windows.Forms.Label();
           this._btnOK = new System.Windows.Forms.Button();
           this._btnCancel = new System.Windows.Forms.Button();
           this.groupBox1.SuspendLayout();
           this.SuspendLayout();
           // 
           // groupBox1
           // 
           this.groupBox1.Controls.Add(this._chkLoad);
           this.groupBox1.Controls.Add(this._txtLastPage);
           this.groupBox1.Controls.Add(this._txtFirstPage);
           this.groupBox1.Controls.Add(this._lblLastPage);
           this.groupBox1.Controls.Add(this._lblFirstPage);
           this.groupBox1.Controls.Add(this._lblLoadPages);
           this.groupBox1.Location = new System.Drawing.Point(10, 4);
           this.groupBox1.Name = "groupBox1";
           this.groupBox1.Size = new System.Drawing.Size(221, 212);
           this.groupBox1.TabIndex = 0;
           this.groupBox1.TabStop = false;
           // 
           // _chkLoad
           // 
           this._chkLoad.AutoSize = true;
           this._chkLoad.Location = new System.Drawing.Point(13, 180);
           this._chkLoad.Name = "_chkLoad";
           this._chkLoad.Size = new System.Drawing.Size(95, 17);
           this._chkLoad.TabIndex = 5;
           this._chkLoad.Text = "&Load All Pages";
           this._chkLoad.UseVisualStyleBackColor = true;
           this._chkLoad.CheckedChanged += new System.EventHandler(this._chkLoad_CheckedChanged);
           // 
           // _txtLastPage
           // 
           this._txtLastPage.Location = new System.Drawing.Point(80, 144);
           this._txtLastPage.MaximumAllowed = 1000;
           this._txtLastPage.MinimumAllowed = -1000;
           this._txtLastPage.Name = "_txtLastPage";
           this._txtLastPage.Size = new System.Drawing.Size(82, 20);
           this._txtLastPage.TabIndex = 4;
           this._txtLastPage.Text = "0";
           this._txtLastPage.Value = 0;
           // 
           // _txtFirstPage
           // 
           this._txtFirstPage.Location = new System.Drawing.Point(80, 111);
           this._txtFirstPage.MaximumAllowed = 1000;
           this._txtFirstPage.MinimumAllowed = -1000;
           this._txtFirstPage.Name = "_txtFirstPage";
           this._txtFirstPage.Size = new System.Drawing.Size(82, 20);
           this._txtFirstPage.TabIndex = 3;
           this._txtFirstPage.Text = "0";
           this._txtFirstPage.Value = 0;
           // 
           // _lblLastPage
           // 
           this._lblLastPage.AutoSize = true;
           this._lblLastPage.Location = new System.Drawing.Point(13, 144);
           this._lblLastPage.Name = "_lblLastPage";
           this._lblLastPage.Size = new System.Drawing.Size(54, 13);
           this._lblLastPage.TabIndex = 2;
           this._lblLastPage.Text = "&Last Page";
           // 
           // _lblFirstPage
           // 
           this._lblFirstPage.AutoSize = true;
           this._lblFirstPage.Location = new System.Drawing.Point(13, 114);
           this._lblFirstPage.Name = "_lblFirstPage";
           this._lblFirstPage.Size = new System.Drawing.Size(55, 13);
           this._lblFirstPage.TabIndex = 1;
           this._lblFirstPage.Text = "&First Page";
           // 
           // _lblLoadPages
           // 
           this._lblLoadPages.Location = new System.Drawing.Point(17, 16);
           this._lblLoadPages.Name = "_lblLoadPages";
           this._lblLoadPages.Size = new System.Drawing.Size(186, 92);
           this._lblLoadPages.TabIndex = 0;
           // 
           // _btnOK
           // 
           this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
           this._btnOK.Location = new System.Drawing.Point(237, 12);
           this._btnOK.Name = "_btnOK";
           this._btnOK.Size = new System.Drawing.Size(73, 24);
           this._btnOK.TabIndex = 34;
           this._btnOK.Text = "&OK";
           this._btnOK.UseVisualStyleBackColor = true;
           this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
           // 
           // _btnCancel
           // 
           this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
           this._btnCancel.Location = new System.Drawing.Point(237, 42);
           this._btnCancel.Name = "_btnCancel";
           this._btnCancel.Size = new System.Drawing.Size(73, 24);
           this._btnCancel.TabIndex = 35;
           this._btnCancel.Text = "&Cancel";
           this._btnCancel.UseVisualStyleBackColor = true;
           // 
           // LoadPagesDialog
           // 
           this.AcceptButton = this._btnOK;
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.CancelButton = this._btnCancel;
           this.ClientSize = new System.Drawing.Size(322, 228);
           this.Controls.Add(this._btnOK);
           this.Controls.Add(this._btnCancel);
           this.Controls.Add(this.groupBox1);
           this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
           this.MaximizeBox = false;
           this.MinimizeBox = false;
           this.Name = "LoadPagesDialog";
           this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
           this.Text = "Load Pages";
           this.groupBox1.ResumeLayout(false);
           this.groupBox1.PerformLayout();
           this.ResumeLayout(false);

        }

        #endregion

      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.Button _btnOK;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.CheckBox _chkLoad;
      private NumericTextBox _txtLastPage;
      private NumericTextBox _txtFirstPage;
      private System.Windows.Forms.Label _lblLastPage;
      private System.Windows.Forms.Label _lblFirstPage;
      private System.Windows.Forms.Label _lblLoadPages;
    }
}