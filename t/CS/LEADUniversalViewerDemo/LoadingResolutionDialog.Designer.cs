namespace LEADUniversalViewer
{
   partial class LoadingResolutionDialog
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
            this._txtInfo = new System.Windows.Forms.TextBox();
            this._cmbResolutions = new System.Windows.Forms.ComboBox();
            this._chkChangeResolution = new System.Windows.Forms.CheckBox();
            this._tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._btnOK = new System.Windows.Forms.Button();
            this._tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            //
            // txtInfo
            //
            this._txtInfo.Location = new System.Drawing.Point(5, 3);
            this._txtInfo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._txtInfo.Multiline = true;
            this._txtInfo.Name = "txtInfo";
            this._txtInfo.ReadOnly = true;
            this._txtInfo.Size = new System.Drawing.Size(442, 189);
            this._txtInfo.TabIndex = 0;
            //
            // cmbResolutions
            //
            this._cmbResolutions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbResolutions.Enabled = false;
            this._cmbResolutions.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cmbResolutions.FormattingEnabled = true;
            this._cmbResolutions.Items.AddRange(new object[] {
            "72",
            "96",
            "100",
            "150",
            "200",
            "250",
            "300",
            "400",
            "600"});
            this._cmbResolutions.Location = new System.Drawing.Point(256, 3);
            this._cmbResolutions.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._cmbResolutions.Name = "cmbResolutions";
            this._cmbResolutions.Size = new System.Drawing.Size(56, 26);
            this._cmbResolutions.TabIndex = 1;
            this._cmbResolutions.SelectedIndexChanged += new System.EventHandler(this.cmbResolutions_SelectedIndexChanged);
            //
            // chkChangeResolution
            //
            this._chkChangeResolution.AutoSize = true;
            this._chkChangeResolution.Dock = System.Windows.Forms.DockStyle.Fill;
            this._chkChangeResolution.Location = new System.Drawing.Point(4, 3);
            this._chkChangeResolution.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._chkChangeResolution.Name = "chkChangeResolution";
            this._chkChangeResolution.Size = new System.Drawing.Size(244, 20);
            this._chkChangeResolution.TabIndex = 2;
            this._chkChangeResolution.Text = "Change documents loading resolution";
            this._chkChangeResolution.UseVisualStyleBackColor = true;
            this._chkChangeResolution.CheckedChanged += new System.EventHandler(this.chkChangeResolution_CheckedChanged);
            //
            // tableLayoutPanel1
            //
            this._tableLayoutPanel1.ColumnCount = 2;
            this._tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this._tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._tableLayoutPanel1.Controls.Add(this._chkChangeResolution, 0, 0);
            this._tableLayoutPanel1.Controls.Add(this._cmbResolutions, 1, 0);
            this._tableLayoutPanel1.Location = new System.Drawing.Point(5, 197);
            this._tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._tableLayoutPanel1.Name = "tableLayoutPanel1";
            this._tableLayoutPanel1.RowCount = 1;
            this._tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tableLayoutPanel1.Size = new System.Drawing.Size(316, 26);
            this._tableLayoutPanel1.TabIndex = 3;
            //
            // btnOK
            //
            this._btnOK.Location = new System.Drawing.Point(386, 197);
            this._btnOK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._btnOK.Name = "btnOK";
            this._btnOK.Size = new System.Drawing.Size(61, 26);
            this._btnOK.TabIndex = 4;
            this._btnOK.Text = "OK";
            this._btnOK.UseVisualStyleBackColor = true;
            this._btnOK.Click += new System.EventHandler(this.btnOK_Click);
            //
            // LoadingResolutionDialog
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 228);
            this.Controls.Add(this._btnOK);
            this.Controls.Add(this._tableLayoutPanel1);
            this.Controls.Add(this._txtInfo);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "LoadingResolutionDialog";
            this.Text = "Loading resolution";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoadingResolutionDialog_FormClosing);
            this.Load += new System.EventHandler(this.LoadingResolutionDialog_Load);
            this._tableLayoutPanel1.ResumeLayout(false);
            this._tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.TextBox _txtInfo;
      private System.Windows.Forms.ComboBox _cmbResolutions;
      private System.Windows.Forms.CheckBox _chkChangeResolution;
      private System.Windows.Forms.TableLayoutPanel _tableLayoutPanel1;
      private System.Windows.Forms.Button _btnOK;
   }
}