namespace OcrMultiThreadingDemo
{
   partial class GatherInformationControl
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
         if(disposing && (components != null))
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GatherInformationControl));
         this._lblTitle = new System.Windows.Forms.Label();
         this._btnDestinationDirectoryBrowse = new System.Windows.Forms.Button();
         this._tbDestinationDirectory = new System.Windows.Forms.TextBox();
         this._tbFilter = new System.Windows.Forms.TextBox();
         this._btnSourceDirectoryBrowse = new System.Windows.Forms.Button();
         this._tbSourceDirectory = new System.Windows.Forms.TextBox();
         this._lblSourceDirectory = new System.Windows.Forms.Label();
         this._lblFilter = new System.Windows.Forms.Label();
         this._lblDestinationDirectory = new System.Windows.Forms.Label();
         this._lblFormat = new System.Windows.Forms.Label();
         this._btnGo = new System.Windows.Forms.Button();
         this._pnlSep1 = new System.Windows.Forms.Panel();
         this._cbLoopContinuously = new System.Windows.Forms.CheckBox();
         this._documentFormatSelector = new Leadtools.Demos.DocumentFormatSelector();
         this.SuspendLayout();
         // 
         // _lblTitle
         // 
         this._lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this._lblTitle.Location = new System.Drawing.Point(16, 23);
         this._lblTitle.Name = "_lblTitle";
         this._lblTitle.Size = new System.Drawing.Size(797, 141);
         this._lblTitle.TabIndex = 0;
         this._lblTitle.Text = resources.GetString("_lblTitle.Text");
         // 
         // _btnDestinationDirectoryBrowse
         // 
         this._btnDestinationDirectoryBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this._btnDestinationDirectoryBrowse.Location = new System.Drawing.Point(788, 232);
         this._btnDestinationDirectoryBrowse.Name = "_btnDestinationDirectoryBrowse";
         this._btnDestinationDirectoryBrowse.Size = new System.Drawing.Size(25, 23);
         this._btnDestinationDirectoryBrowse.TabIndex = 8;
         this._btnDestinationDirectoryBrowse.Text = "...";
         this._btnDestinationDirectoryBrowse.UseVisualStyleBackColor = true;
         this._btnDestinationDirectoryBrowse.Click += new System.EventHandler(this._btnDestinationDirectoryBrowse_Click);
         // 
         // _tbDestinationDirectory
         // 
         this._tbDestinationDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this._tbDestinationDirectory.Location = new System.Drawing.Point(194, 234);
         this._tbDestinationDirectory.Name = "_tbDestinationDirectory";
         this._tbDestinationDirectory.Size = new System.Drawing.Size(589, 20);
         this._tbDestinationDirectory.TabIndex = 7;
         this._tbDestinationDirectory.TextChanged += new System.EventHandler(this._tb_TextChanged);
         // 
         // _tbFilter
         // 
         this._tbFilter.Location = new System.Drawing.Point(194, 208);
         this._tbFilter.Name = "_tbFilter";
         this._tbFilter.Size = new System.Drawing.Size(198, 20);
         this._tbFilter.TabIndex = 5;
         this._tbFilter.TextChanged += new System.EventHandler(this._tb_TextChanged);
         // 
         // _btnSourceDirectoryBrowse
         // 
         this._btnSourceDirectoryBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this._btnSourceDirectoryBrowse.Location = new System.Drawing.Point(788, 180);
         this._btnSourceDirectoryBrowse.Name = "_btnSourceDirectoryBrowse";
         this._btnSourceDirectoryBrowse.Size = new System.Drawing.Size(25, 23);
         this._btnSourceDirectoryBrowse.TabIndex = 3;
         this._btnSourceDirectoryBrowse.Text = "...";
         this._btnSourceDirectoryBrowse.UseVisualStyleBackColor = true;
         this._btnSourceDirectoryBrowse.Click += new System.EventHandler(this._btnSourceDirectoryBrowse_Click);
         // 
         // _tbSourceDirectory
         // 
         this._tbSourceDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this._tbSourceDirectory.Location = new System.Drawing.Point(194, 182);
         this._tbSourceDirectory.Name = "_tbSourceDirectory";
         this._tbSourceDirectory.Size = new System.Drawing.Size(589, 20);
         this._tbSourceDirectory.TabIndex = 2;
         this._tbSourceDirectory.TextChanged += new System.EventHandler(this._tb_TextChanged);
         // 
         // _lblSourceDirectory
         // 
         this._lblSourceDirectory.Location = new System.Drawing.Point(3, 180);
         this._lblSourceDirectory.Name = "_lblSourceDirectory";
         this._lblSourceDirectory.Size = new System.Drawing.Size(164, 23);
         this._lblSourceDirectory.TabIndex = 1;
         this._lblSourceDirectory.Text = "&Source directory:";
         this._lblSourceDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         // 
         // _lblFilter
         // 
         this._lblFilter.Location = new System.Drawing.Point(3, 206);
         this._lblFilter.Name = "_lblFilter";
         this._lblFilter.Size = new System.Drawing.Size(164, 23);
         this._lblFilter.TabIndex = 4;
         this._lblFilter.Text = "Source &files filter:";
         this._lblFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         // 
         // _lblDestinationDirectory
         // 
         this._lblDestinationDirectory.Location = new System.Drawing.Point(3, 232);
         this._lblDestinationDirectory.Name = "_lblDestinationDirectory";
         this._lblDestinationDirectory.Size = new System.Drawing.Size(164, 23);
         this._lblDestinationDirectory.TabIndex = 6;
         this._lblDestinationDirectory.Text = "&Destination directory:";
         this._lblDestinationDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         // 
         // _lblFormat
         // 
         this._lblFormat.Location = new System.Drawing.Point(3, 258);
         this._lblFormat.Name = "_lblFormat";
         this._lblFormat.Size = new System.Drawing.Size(164, 23);
         this._lblFormat.TabIndex = 9;
         this._lblFormat.Text = "Destination d&ocument format:";
         this._lblFormat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         // 
         // _btnGo
         // 
         this._btnGo.Location = new System.Drawing.Point(193, 355);
         this._btnGo.Name = "_btnGo";
         this._btnGo.Size = new System.Drawing.Size(75, 23);
         this._btnGo.TabIndex = 16;
         this._btnGo.Text = "&Go";
         this._btnGo.UseVisualStyleBackColor = true;
         this._btnGo.Click += new System.EventHandler(this._btnGo_Click);
         // 
         // _pnlSep1
         // 
         this._pnlSep1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this._pnlSep1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._pnlSep1.Location = new System.Drawing.Point(193, 341);
         this._pnlSep1.Name = "_pnlSep1";
         this._pnlSep1.Size = new System.Drawing.Size(620, 4);
         this._pnlSep1.TabIndex = 15;
         // 
         // _cbLoopContinuously
         // 
         this._cbLoopContinuously.AutoSize = true;
         this._cbLoopContinuously.Location = new System.Drawing.Point(194, 314);
         this._cbLoopContinuously.Name = "_cbLoopContinuously";
         this._cbLoopContinuously.Size = new System.Drawing.Size(112, 17);
         this._cbLoopContinuously.TabIndex = 14;
         this._cbLoopContinuously.Text = "Loo&p continuously";
         this._cbLoopContinuously.UseVisualStyleBackColor = true;
         // 
         // _documentFormatSelector
         // 
         this._documentFormatSelector.FormatHasOptions = true;
         this._documentFormatSelector.Location = new System.Drawing.Point(194, 258);
         this._documentFormatSelector.Name = "_documentFormatSelector";
         this._documentFormatSelector.Size = new System.Drawing.Size(257, 23);
         this._documentFormatSelector.TabIndex = 10;
         this._documentFormatSelector.TotalPages = 0;
         this._documentFormatSelector.SelectedFormatChanged += new System.EventHandler<System.EventArgs>(this._documentFormatSelector_SelectedFormatChanged);
         // 
         // GatherInformationControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this._cbLoopContinuously);
         this.Controls.Add(this._documentFormatSelector);
         this.Controls.Add(this._pnlSep1);
         this.Controls.Add(this._btnGo);
         this.Controls.Add(this._lblFormat);
         this.Controls.Add(this._lblDestinationDirectory);
         this.Controls.Add(this._lblFilter);
         this.Controls.Add(this._lblSourceDirectory);
         this.Controls.Add(this._btnDestinationDirectoryBrowse);
         this.Controls.Add(this._tbDestinationDirectory);
         this.Controls.Add(this._tbFilter);
         this.Controls.Add(this._btnSourceDirectoryBrowse);
         this.Controls.Add(this._tbSourceDirectory);
         this.Controls.Add(this._lblTitle);
         this.Name = "GatherInformationControl";
         this.Size = new System.Drawing.Size(830, 401);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label _lblTitle;
      private System.Windows.Forms.Button _btnDestinationDirectoryBrowse;
      private System.Windows.Forms.TextBox _tbDestinationDirectory;
      private System.Windows.Forms.TextBox _tbFilter;
      private System.Windows.Forms.Button _btnSourceDirectoryBrowse;
      private System.Windows.Forms.TextBox _tbSourceDirectory;
      private System.Windows.Forms.Label _lblSourceDirectory;
      private System.Windows.Forms.Label _lblFilter;
      private System.Windows.Forms.Label _lblDestinationDirectory;
      private System.Windows.Forms.Label _lblFormat;
      private System.Windows.Forms.Button _btnGo;
      private System.Windows.Forms.Panel _pnlSep1;
      private Leadtools.Demos.DocumentFormatSelector _documentFormatSelector;
      private System.Windows.Forms.CheckBox _cbLoopContinuously;
   }
}
