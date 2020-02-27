namespace OcrModulesDemo
{
   partial class MainForm
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
         if(disposing)
            CleanUp();

         if(disposing && (components != null))
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
         this._lblDocumentFormat = new System.Windows.Forms.Label();
         this._splitContainer = new System.Windows.Forms.SplitContainer();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this._btnClearZones = new System.Windows.Forms.Button();
         this._btnRecognize = new System.Windows.Forms.Button();
         this._btnBrowseImageFile = new System.Windows.Forms.Button();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this._omrOptionsButton = new System.Windows.Forms.Button();
         this._documentFormatSelector = new Leadtools.Demos.DocumentFormatSelector();
         this._cbViewFinalDocument = new System.Windows.Forms.CheckBox();
         this._cmbOcrModules = new System.Windows.Forms.ComboBox();
         this._lblOcrModules = new System.Windows.Forms.Label();
         this._statusBar = new System.Windows.Forms.StatusStrip();
         this._lblImageFileName = new System.Windows.Forms.ToolStripStatusLabel();
         //((System.ComponentModel.ISupportInitialize)(this._splitContainer)).BeginInit();
         this._splitContainer.Panel1.SuspendLayout();
         this._splitContainer.SuspendLayout();
         this.groupBox2.SuspendLayout();
         this.groupBox1.SuspendLayout();
         this._statusBar.SuspendLayout();
         this.SuspendLayout();
         // 
         // _lblDocumentFormat
         // 
         this._lblDocumentFormat.AutoSize = true;
         this._lblDocumentFormat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._lblDocumentFormat.Location = new System.Drawing.Point(6, 103);
         this._lblDocumentFormat.Name = "_lblDocumentFormat";
         this._lblDocumentFormat.Size = new System.Drawing.Size(92, 13);
         this._lblDocumentFormat.TabIndex = 3;
         this._lblDocumentFormat.Text = "Document &Format";
         // 
         // _splitContainer
         // 
         this._splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
         this._splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
         this._splitContainer.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._splitContainer.IsSplitterFixed = true;
         this._splitContainer.Location = new System.Drawing.Point(0, 0);
         this._splitContainer.Name = "_splitContainer";
         // 
         // _splitContainer.Panel1
         // 
         this._splitContainer.Panel1.AutoScroll = true;
         this._splitContainer.Panel1.BackColor = System.Drawing.SystemColors.Control;
         this._splitContainer.Panel1.Controls.Add(this.groupBox2);
         this._splitContainer.Panel1.Controls.Add(this.groupBox1);
         this._splitContainer.Panel1MinSize = 0;
         this._splitContainer.Panel2MinSize = 0;
         this._splitContainer.Size = new System.Drawing.Size(801, 524);
         this._splitContainer.SplitterDistance = 283;
         this._splitContainer.TabIndex = 0;
         // 
         // groupBox2
         // 
         this.groupBox2.Controls.Add(this._btnClearZones);
         this.groupBox2.Controls.Add(this._btnRecognize);
         this.groupBox2.Controls.Add(this._btnBrowseImageFile);
         this.groupBox2.Location = new System.Drawing.Point(10, 194);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(266, 183);
         this.groupBox2.TabIndex = 1;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Action";
         // 
         // _btnClearZones
         // 
         this._btnClearZones.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._btnClearZones.Location = new System.Drawing.Point(6, 122);
         this._btnClearZones.Name = "_btnClearZones";
         this._btnClearZones.Size = new System.Drawing.Size(254, 45);
         this._btnClearZones.TabIndex = 2;
         this._btnClearZones.Text = "&Clear Zones";
         this._btnClearZones.UseVisualStyleBackColor = true;
         this._btnClearZones.Click += new System.EventHandler(this._btnClearZones_Click);
         // 
         // _btnRecognize
         // 
         this._btnRecognize.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._btnRecognize.Location = new System.Drawing.Point(6, 71);
         this._btnRecognize.Name = "_btnRecognize";
         this._btnRecognize.Size = new System.Drawing.Size(254, 45);
         this._btnRecognize.TabIndex = 1;
         this._btnRecognize.Text = "&Recognize and Save Results";
         this._btnRecognize.UseVisualStyleBackColor = true;
         this._btnRecognize.Click += new System.EventHandler(this._btnRecognize_Click);
         // 
         // _btnBrowseImageFile
         // 
         this._btnBrowseImageFile.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._btnBrowseImageFile.Location = new System.Drawing.Point(6, 20);
         this._btnBrowseImageFile.Name = "_btnBrowseImageFile";
         this._btnBrowseImageFile.Size = new System.Drawing.Size(254, 45);
         this._btnBrowseImageFile.TabIndex = 0;
         this._btnBrowseImageFile.Text = "&Open...";
         this._btnBrowseImageFile.UseVisualStyleBackColor = true;
         this._btnBrowseImageFile.Click += new System.EventHandler(this._btnBrowseImageFile_Click);
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this._omrOptionsButton);
         this.groupBox1.Controls.Add(this._documentFormatSelector);
         this.groupBox1.Controls.Add(this._cbViewFinalDocument);
         this.groupBox1.Controls.Add(this._cmbOcrModules);
         this.groupBox1.Controls.Add(this._lblOcrModules);
         this.groupBox1.Controls.Add(this._lblDocumentFormat);
         this.groupBox1.Location = new System.Drawing.Point(10, 11);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(266, 177);
         this.groupBox1.TabIndex = 0;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Options";
         // 
         // _omrOptionsButton
         // 
         this._omrOptionsButton.Location = new System.Drawing.Point(6, 65);
         this._omrOptionsButton.Name = "_omrOptionsButton";
         this._omrOptionsButton.Size = new System.Drawing.Size(254, 23);
         this._omrOptionsButton.TabIndex = 2;
         this._omrOptionsButton.Text = "Change OMR Options...";
         this._omrOptionsButton.UseVisualStyleBackColor = true;
         this._omrOptionsButton.Click += new System.EventHandler(this._omrOptionsButton_Click);
         // 
         // _documentFormatSelector
         // 
         this._documentFormatSelector.FormatHasOptions = true;
         this._documentFormatSelector.Location = new System.Drawing.Point(9, 119);
         this._documentFormatSelector.Name = "_documentFormatSelector";
         this._documentFormatSelector.Size = new System.Drawing.Size(251, 23);
         this._documentFormatSelector.TabIndex = 4;
         this._documentFormatSelector.TotalPages = 0;
         this._documentFormatSelector.SelectedFormatChanged += new System.EventHandler<System.EventArgs>(this._documentFormatSelector_SelectedFormatChanged);
         // 
         // _cbViewFinalDocument
         // 
         this._cbViewFinalDocument.AutoSize = true;
         this._cbViewFinalDocument.Location = new System.Drawing.Point(6, 148);
         this._cbViewFinalDocument.Name = "_cbViewFinalDocument";
         this._cbViewFinalDocument.Size = new System.Drawing.Size(124, 17);
         this._cbViewFinalDocument.TabIndex = 5;
         this._cbViewFinalDocument.Text = "&View Final Document";
         this._cbViewFinalDocument.UseVisualStyleBackColor = true;
         // 
         // _cmbOcrModules
         // 
         this._cmbOcrModules.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbOcrModules.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._cmbOcrModules.FormattingEnabled = true;
         this._cmbOcrModules.Location = new System.Drawing.Point(6, 37);
         this._cmbOcrModules.Name = "_cmbOcrModules";
         this._cmbOcrModules.Size = new System.Drawing.Size(254, 21);
         this._cmbOcrModules.TabIndex = 1;
         this._cmbOcrModules.SelectedIndexChanged += new System.EventHandler(this._cmbOcrModules_SelectedIndexChanged);
         // 
         // _lblOcrModules
         // 
         this._lblOcrModules.AutoSize = true;
         this._lblOcrModules.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._lblOcrModules.Location = new System.Drawing.Point(3, 21);
         this._lblOcrModules.Name = "_lblOcrModules";
         this._lblOcrModules.Size = new System.Drawing.Size(152, 13);
         this._lblOcrModules.TabIndex = 0;
         this._lblOcrModules.Text = "OCR &Modules And Fill Methods";
         // 
         // _statusBar
         // 
         this._statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._lblImageFileName});
         this._statusBar.Location = new System.Drawing.Point(0, 524);
         this._statusBar.Name = "_statusBar";
         this._statusBar.Size = new System.Drawing.Size(801, 22);
         this._statusBar.TabIndex = 1;
         this._statusBar.Text = "statusStrip1";
         // 
         // _lblImageFileName
         // 
         this._lblImageFileName.AutoSize = false;
         this._lblImageFileName.BackColor = System.Drawing.SystemColors.Control;
         this._lblImageFileName.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
         this._lblImageFileName.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
         this._lblImageFileName.ForeColor = System.Drawing.Color.Blue;
         this._lblImageFileName.Margin = new System.Windows.Forms.Padding(1, 3, 1, 2);
         this._lblImageFileName.Name = "_lblImageFileName";
         this._lblImageFileName.Size = new System.Drawing.Size(220, 17);
         this._lblImageFileName.Text = "Ready";
         this._lblImageFileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // MainForm
         // 
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
         this.BackColor = System.Drawing.SystemColors.AppWorkspace;
         this.ClientSize = new System.Drawing.Size(801, 546);
         this.Controls.Add(this._splitContainer);
         this.Controls.Add(this._statusBar);
         this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "MainForm";
         this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "OCR Modules Demo";
         this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
         this.Resize += new System.EventHandler(this.MainForm_Resize);
         this._splitContainer.Panel1.ResumeLayout(false);
         //((System.ComponentModel.ISupportInitialize)(this._splitContainer)).EndInit();
         this._splitContainer.ResumeLayout(false);
         this.groupBox2.ResumeLayout(false);
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this._statusBar.ResumeLayout(false);
         this._statusBar.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label _lblDocumentFormat;
      private System.Windows.Forms.SplitContainer _splitContainer;
      private System.Windows.Forms.ComboBox _cmbOcrModules;
      private System.Windows.Forms.Label _lblOcrModules;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.Button _btnRecognize;
      private System.Windows.Forms.Button _btnBrowseImageFile;
      private System.Windows.Forms.CheckBox _cbViewFinalDocument;
      private System.Windows.Forms.StatusStrip _statusBar;
      private System.Windows.Forms.ToolStripStatusLabel _lblImageFileName;
      private System.Windows.Forms.Button _btnClearZones;
      private Leadtools.Demos.DocumentFormatSelector _documentFormatSelector;
      private System.Windows.Forms.Button _omrOptionsButton;







   }
}

