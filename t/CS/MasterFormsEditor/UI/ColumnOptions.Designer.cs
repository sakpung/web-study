namespace CSMasterFormsEditor
{
   partial class ColumnOptions
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColumnOptions));
         this._gbFieldMethod = new System.Windows.Forms.GroupBox();
         this._chkEnableIcr = new System.Windows.Forms.CheckBox();
         this._chkEnableOcr = new System.Windows.Forms.CheckBox();
         this._gbFieldTextType = new System.Windows.Forms.GroupBox();
         this._rbtextTypeNum = new System.Windows.Forms.RadioButton();
         this._rbTextTypeChar = new System.Windows.Forms.RadioButton();
         this._gb_OcrColumnOption = new System.Windows.Forms.GroupBox();
         this._gbOMRFrame = new System.Windows.Forms.GroupBox();
         this._rbOMRWithoutFrame = new System.Windows.Forms.RadioButton();
         this._rbOMRWithFrame = new System.Windows.Forms.RadioButton();
         this._rbOMRAutoFrame = new System.Windows.Forms.RadioButton();
         this._gbOMRSensitivity = new System.Windows.Forms.GroupBox();
         this._rbOMRSensitivityHighest = new System.Windows.Forms.RadioButton();
         this._rbOMRSensitivityHigh = new System.Windows.Forms.RadioButton();
         this._rbOMRSensitivityLowest = new System.Windows.Forms.RadioButton();
         this._rbOMRSensitivityLow = new System.Windows.Forms.RadioButton();
         this._gb_OmrColumnOptions = new System.Windows.Forms.GroupBox();
         this._gbBounds = new System.Windows.Forms.GroupBox();
         this._nudHeight = new System.Windows.Forms.NumericUpDown();
         this._nudWidth = new System.Windows.Forms.NumericUpDown();
         this._nudTop = new System.Windows.Forms.NumericUpDown();
         this._nudLeft = new System.Windows.Forms.NumericUpDown();
         this._lblFieldHeight = new System.Windows.Forms.Label();
         this._lblFieldWidth = new System.Windows.Forms.Label();
         this._lblFieldTop = new System.Windows.Forms.Label();
         this._lblFieldLeft = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this._txt_ColumnOptionsFieldName = new System.Windows.Forms.TextBox();
         this._gbKeyColumn = new System.Windows.Forms.GroupBox();
         this._cbIsKeyColumn = new System.Windows.Forms.CheckBox();
         this._gbDropoutOptions = new System.Windows.Forms.GroupBox();
         this._chkDropoutWords = new System.Windows.Forms.CheckBox();
         this._chkDropoutCells = new System.Windows.Forms.CheckBox();
         this._btnOK = new System.Windows.Forms.Button();
         this._gbFieldMethod.SuspendLayout();
         this._gbFieldTextType.SuspendLayout();
         this._gb_OcrColumnOption.SuspendLayout();
         this._gbOMRFrame.SuspendLayout();
         this._gbOMRSensitivity.SuspendLayout();
         this._gb_OmrColumnOptions.SuspendLayout();
         this._gbBounds.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._nudHeight)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._nudWidth)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._nudTop)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._nudLeft)).BeginInit();
         this._gbKeyColumn.SuspendLayout();
         this._gbDropoutOptions.SuspendLayout();
         this.SuspendLayout();
         // 
         // _gbFieldMethod
         // 
         this._gbFieldMethod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this._gbFieldMethod.Controls.Add(this._chkEnableIcr);
         this._gbFieldMethod.Controls.Add(this._chkEnableOcr);
         this._gbFieldMethod.Location = new System.Drawing.Point(153, 26);
         this._gbFieldMethod.Name = "_gbFieldMethod";
         this._gbFieldMethod.Size = new System.Drawing.Size(101, 74);
         this._gbFieldMethod.TabIndex = 15;
         this._gbFieldMethod.TabStop = false;
         this._gbFieldMethod.Text = "Method";
         // 
         // _chkEnableIcr
         // 
         this._chkEnableIcr.AutoSize = true;
         this._chkEnableIcr.Checked = true;
         this._chkEnableIcr.CheckState = System.Windows.Forms.CheckState.Checked;
         this._chkEnableIcr.Location = new System.Drawing.Point(10, 42);
         this._chkEnableIcr.Name = "_chkEnableIcr";
         this._chkEnableIcr.Size = new System.Drawing.Size(80, 17);
         this._chkEnableIcr.TabIndex = 7;
         this._chkEnableIcr.Text = "Enable ICR";
         this._chkEnableIcr.TextAlign = System.Drawing.ContentAlignment.TopLeft;
         this._chkEnableIcr.UseVisualStyleBackColor = true;
         this._chkEnableIcr.CheckedChanged += new System.EventHandler(this.OptionsChanged);
         // 
         // _chkEnableOcr
         // 
         this._chkEnableOcr.AutoSize = true;
         this._chkEnableOcr.Checked = true;
         this._chkEnableOcr.CheckState = System.Windows.Forms.CheckState.Checked;
         this._chkEnableOcr.Location = new System.Drawing.Point(10, 19);
         this._chkEnableOcr.Name = "_chkEnableOcr";
         this._chkEnableOcr.Size = new System.Drawing.Size(85, 17);
         this._chkEnableOcr.TabIndex = 6;
         this._chkEnableOcr.Text = "Enable OCR";
         this._chkEnableOcr.UseVisualStyleBackColor = true;
         this._chkEnableOcr.CheckedChanged += new System.EventHandler(this.OptionsChanged);
         // 
         // _gbFieldTextType
         // 
         this._gbFieldTextType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this._gbFieldTextType.Controls.Add(this._rbtextTypeNum);
         this._gbFieldTextType.Controls.Add(this._rbTextTypeChar);
         this._gbFieldTextType.Location = new System.Drawing.Point(6, 19);
         this._gbFieldTextType.Name = "_gbFieldTextType";
         this._gbFieldTextType.Size = new System.Drawing.Size(101, 75);
         this._gbFieldTextType.TabIndex = 16;
         this._gbFieldTextType.TabStop = false;
         this._gbFieldTextType.Text = "Text Type";
         // 
         // _rbtextTypeNum
         // 
         this._rbtextTypeNum.AutoSize = true;
         this._rbtextTypeNum.Location = new System.Drawing.Point(10, 45);
         this._rbtextTypeNum.Name = "_rbtextTypeNum";
         this._rbtextTypeNum.Size = new System.Drawing.Size(72, 17);
         this._rbtextTypeNum.TabIndex = 9;
         this._rbtextTypeNum.Text = "Numerical";
         this._rbtextTypeNum.UseVisualStyleBackColor = true;
         this._rbtextTypeNum.CheckedChanged += new System.EventHandler(this.OptionsChanged);
         // 
         // _rbTextTypeChar
         // 
         this._rbTextTypeChar.AutoSize = true;
         this._rbTextTypeChar.Location = new System.Drawing.Point(10, 19);
         this._rbTextTypeChar.Name = "_rbTextTypeChar";
         this._rbTextTypeChar.Size = new System.Drawing.Size(71, 17);
         this._rbTextTypeChar.TabIndex = 8;
         this._rbTextTypeChar.Text = "Character";
         this._rbTextTypeChar.UseVisualStyleBackColor = true;
         this._rbTextTypeChar.CheckedChanged += new System.EventHandler(this.OptionsChanged);
         // 
         // _gb_OcrColumnOption
         // 
         this._gb_OcrColumnOption.Controls.Add(this._gbFieldTextType);
         this._gb_OcrColumnOption.Controls.Add(this._gbFieldMethod);
         this._gb_OcrColumnOption.Location = new System.Drawing.Point(12, 52);
         this._gb_OcrColumnOption.Name = "_gb_OcrColumnOption";
         this._gb_OcrColumnOption.Size = new System.Drawing.Size(260, 100);
         this._gb_OcrColumnOption.TabIndex = 17;
         this._gb_OcrColumnOption.TabStop = false;
         this._gb_OcrColumnOption.Text = "Ocr Options";
         // 
         // _gbOMRFrame
         // 
         this._gbOMRFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this._gbOMRFrame.Controls.Add(this._rbOMRWithoutFrame);
         this._gbOMRFrame.Controls.Add(this._rbOMRWithFrame);
         this._gbOMRFrame.Controls.Add(this._rbOMRAutoFrame);
         this._gbOMRFrame.Location = new System.Drawing.Point(130, 38);
         this._gbOMRFrame.Name = "_gbOMRFrame";
         this._gbOMRFrame.Size = new System.Drawing.Size(113, 94);
         this._gbOMRFrame.TabIndex = 18;
         this._gbOMRFrame.TabStop = false;
         this._gbOMRFrame.Text = "Frame";
         // 
         // _rbOMRWithoutFrame
         // 
         this._rbOMRWithoutFrame.AutoSize = true;
         this._rbOMRWithoutFrame.Location = new System.Drawing.Point(10, 71);
         this._rbOMRWithoutFrame.Name = "_rbOMRWithoutFrame";
         this._rbOMRWithoutFrame.Size = new System.Drawing.Size(94, 17);
         this._rbOMRWithoutFrame.TabIndex = 13;
         this._rbOMRWithoutFrame.TabStop = true;
         this._rbOMRWithoutFrame.Text = "Without Frame";
         this._rbOMRWithoutFrame.UseVisualStyleBackColor = true;
         this._rbOMRWithoutFrame.CheckedChanged += new System.EventHandler(this.OptionsChanged);
         // 
         // _rbOMRWithFrame
         // 
         this._rbOMRWithFrame.AutoSize = true;
         this._rbOMRWithFrame.Location = new System.Drawing.Point(10, 45);
         this._rbOMRWithFrame.Name = "_rbOMRWithFrame";
         this._rbOMRWithFrame.Size = new System.Drawing.Size(79, 17);
         this._rbOMRWithFrame.TabIndex = 12;
         this._rbOMRWithFrame.TabStop = true;
         this._rbOMRWithFrame.Text = "With Frame";
         this._rbOMRWithFrame.UseVisualStyleBackColor = true;
         this._rbOMRWithFrame.CheckedChanged += new System.EventHandler(this.OptionsChanged);
         // 
         // _rbOMRAutoFrame
         // 
         this._rbOMRAutoFrame.AutoSize = true;
         this._rbOMRAutoFrame.Location = new System.Drawing.Point(10, 19);
         this._rbOMRAutoFrame.Name = "_rbOMRAutoFrame";
         this._rbOMRAutoFrame.Size = new System.Drawing.Size(47, 17);
         this._rbOMRAutoFrame.TabIndex = 11;
         this._rbOMRAutoFrame.TabStop = true;
         this._rbOMRAutoFrame.Text = "Auto";
         this._rbOMRAutoFrame.UseVisualStyleBackColor = true;
         this._rbOMRAutoFrame.CheckedChanged += new System.EventHandler(this.OptionsChanged);
         // 
         // _gbOMRSensitivity
         // 
         this._gbOMRSensitivity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this._gbOMRSensitivity.Controls.Add(this._rbOMRSensitivityHighest);
         this._gbOMRSensitivity.Controls.Add(this._rbOMRSensitivityHigh);
         this._gbOMRSensitivity.Controls.Add(this._rbOMRSensitivityLowest);
         this._gbOMRSensitivity.Controls.Add(this._rbOMRSensitivityLow);
         this._gbOMRSensitivity.Location = new System.Drawing.Point(22, 38);
         this._gbOMRSensitivity.Name = "_gbOMRSensitivity";
         this._gbOMRSensitivity.Size = new System.Drawing.Size(101, 121);
         this._gbOMRSensitivity.TabIndex = 19;
         this._gbOMRSensitivity.TabStop = false;
         this._gbOMRSensitivity.Text = "Sensitivity";
         // 
         // _rbOMRSensitivityHighest
         // 
         this._rbOMRSensitivityHighest.AutoSize = true;
         this._rbOMRSensitivityHighest.Location = new System.Drawing.Point(10, 99);
         this._rbOMRSensitivityHighest.Name = "_rbOMRSensitivityHighest";
         this._rbOMRSensitivityHighest.Size = new System.Drawing.Size(61, 17);
         this._rbOMRSensitivityHighest.TabIndex = 11;
         this._rbOMRSensitivityHighest.TabStop = true;
         this._rbOMRSensitivityHighest.Text = "Highest";
         this._rbOMRSensitivityHighest.UseVisualStyleBackColor = true;
         this._rbOMRSensitivityHighest.CheckedChanged += new System.EventHandler(this.OptionsChanged);
         // 
         // _rbOMRSensitivityHigh
         // 
         this._rbOMRSensitivityHigh.AutoSize = true;
         this._rbOMRSensitivityHigh.Location = new System.Drawing.Point(10, 71);
         this._rbOMRSensitivityHigh.Name = "_rbOMRSensitivityHigh";
         this._rbOMRSensitivityHigh.Size = new System.Drawing.Size(47, 17);
         this._rbOMRSensitivityHigh.TabIndex = 10;
         this._rbOMRSensitivityHigh.TabStop = true;
         this._rbOMRSensitivityHigh.Text = "High";
         this._rbOMRSensitivityHigh.UseVisualStyleBackColor = true;
         this._rbOMRSensitivityHigh.CheckedChanged += new System.EventHandler(this.OptionsChanged);
         // 
         // _rbOMRSensitivityLowest
         // 
         this._rbOMRSensitivityLowest.AutoSize = true;
         this._rbOMRSensitivityLowest.Location = new System.Drawing.Point(10, 19);
         this._rbOMRSensitivityLowest.Name = "_rbOMRSensitivityLowest";
         this._rbOMRSensitivityLowest.Size = new System.Drawing.Size(59, 17);
         this._rbOMRSensitivityLowest.TabIndex = 9;
         this._rbOMRSensitivityLowest.TabStop = true;
         this._rbOMRSensitivityLowest.Text = "Lowest";
         this._rbOMRSensitivityLowest.UseVisualStyleBackColor = true;
         this._rbOMRSensitivityLowest.CheckedChanged += new System.EventHandler(this.OptionsChanged);
         // 
         // _rbOMRSensitivityLow
         // 
         this._rbOMRSensitivityLow.AutoSize = true;
         this._rbOMRSensitivityLow.Location = new System.Drawing.Point(10, 45);
         this._rbOMRSensitivityLow.Name = "_rbOMRSensitivityLow";
         this._rbOMRSensitivityLow.Size = new System.Drawing.Size(45, 17);
         this._rbOMRSensitivityLow.TabIndex = 8;
         this._rbOMRSensitivityLow.TabStop = true;
         this._rbOMRSensitivityLow.Text = "Low";
         this._rbOMRSensitivityLow.UseVisualStyleBackColor = true;
         this._rbOMRSensitivityLow.CheckedChanged += new System.EventHandler(this.OptionsChanged);
         // 
         // _gb_OmrColumnOptions
         // 
         this._gb_OmrColumnOptions.Controls.Add(this._gbOMRSensitivity);
         this._gb_OmrColumnOptions.Controls.Add(this._gbOMRFrame);
         this._gb_OmrColumnOptions.Location = new System.Drawing.Point(12, 158);
         this._gb_OmrColumnOptions.Name = "_gb_OmrColumnOptions";
         this._gb_OmrColumnOptions.Size = new System.Drawing.Size(260, 165);
         this._gb_OmrColumnOptions.TabIndex = 20;
         this._gb_OmrColumnOptions.TabStop = false;
         this._gb_OmrColumnOptions.Text = "Omr Options";
         // 
         // _gbBounds
         // 
         this._gbBounds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this._gbBounds.Controls.Add(this._nudHeight);
         this._gbBounds.Controls.Add(this._nudWidth);
         this._gbBounds.Controls.Add(this._nudTop);
         this._gbBounds.Controls.Add(this._nudLeft);
         this._gbBounds.Controls.Add(this._lblFieldHeight);
         this._gbBounds.Controls.Add(this._lblFieldWidth);
         this._gbBounds.Controls.Add(this._lblFieldTop);
         this._gbBounds.Controls.Add(this._lblFieldLeft);
         this._gbBounds.Location = new System.Drawing.Point(12, 435);
         this._gbBounds.Name = "_gbBounds";
         this._gbBounds.Size = new System.Drawing.Size(237, 66);
         this._gbBounds.TabIndex = 21;
         this._gbBounds.TabStop = false;
         this._gbBounds.Text = "Bounds";
         // 
         // _nudHeight
         // 
         this._nudHeight.Location = new System.Drawing.Point(170, 39);
         this._nudHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
         this._nudHeight.Name = "_nudHeight";
         this._nudHeight.Size = new System.Drawing.Size(60, 20);
         this._nudHeight.TabIndex = 16;
         this._nudHeight.ValueChanged += new System.EventHandler(this.OptionsChanged);
         // 
         // _nudWidth
         // 
         this._nudWidth.Location = new System.Drawing.Point(170, 14);
         this._nudWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
         this._nudWidth.Name = "_nudWidth";
         this._nudWidth.Size = new System.Drawing.Size(60, 20);
         this._nudWidth.TabIndex = 15;
         this._nudWidth.ValueChanged += new System.EventHandler(this.OptionsChanged);
         // 
         // _nudTop
         // 
         this._nudTop.Location = new System.Drawing.Point(47, 39);
         this._nudTop.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
         this._nudTop.Name = "_nudTop";
         this._nudTop.Size = new System.Drawing.Size(60, 20);
         this._nudTop.TabIndex = 14;
         this._nudTop.ValueChanged += new System.EventHandler(this.OptionsChanged);
         // 
         // _nudLeft
         // 
         this._nudLeft.Location = new System.Drawing.Point(47, 14);
         this._nudLeft.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
         this._nudLeft.Name = "_nudLeft";
         this._nudLeft.Size = new System.Drawing.Size(60, 20);
         this._nudLeft.TabIndex = 13;
         this._nudLeft.ValueChanged += new System.EventHandler(this.OptionsChanged);
         // 
         // _lblFieldHeight
         // 
         this._lblFieldHeight.AutoSize = true;
         this._lblFieldHeight.Location = new System.Drawing.Point(129, 41);
         this._lblFieldHeight.Name = "_lblFieldHeight";
         this._lblFieldHeight.Size = new System.Drawing.Size(38, 13);
         this._lblFieldHeight.TabIndex = 12;
         this._lblFieldHeight.Text = "Height";
         // 
         // _lblFieldWidth
         // 
         this._lblFieldWidth.AutoSize = true;
         this._lblFieldWidth.Location = new System.Drawing.Point(129, 16);
         this._lblFieldWidth.Name = "_lblFieldWidth";
         this._lblFieldWidth.Size = new System.Drawing.Size(35, 13);
         this._lblFieldWidth.TabIndex = 10;
         this._lblFieldWidth.Text = "Width";
         // 
         // _lblFieldTop
         // 
         this._lblFieldTop.AutoSize = true;
         this._lblFieldTop.Location = new System.Drawing.Point(7, 41);
         this._lblFieldTop.Name = "_lblFieldTop";
         this._lblFieldTop.Size = new System.Drawing.Size(26, 13);
         this._lblFieldTop.TabIndex = 8;
         this._lblFieldTop.Text = "Top";
         // 
         // _lblFieldLeft
         // 
         this._lblFieldLeft.AutoSize = true;
         this._lblFieldLeft.Location = new System.Drawing.Point(7, 16);
         this._lblFieldLeft.Name = "_lblFieldLeft";
         this._lblFieldLeft.Size = new System.Drawing.Size(25, 13);
         this._lblFieldLeft.TabIndex = 7;
         this._lblFieldLeft.Text = "Left";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(13, 13);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(44, 13);
         this.label1.TabIndex = 22;
         this.label1.Text = "Name : ";
         // 
         // _txt_ColumnOptionsFieldName
         // 
         this._txt_ColumnOptionsFieldName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this._txt_ColumnOptionsFieldName.Location = new System.Drawing.Point(56, 13);
         this._txt_ColumnOptionsFieldName.Name = "_txt_ColumnOptionsFieldName";
         this._txt_ColumnOptionsFieldName.Size = new System.Drawing.Size(199, 20);
         this._txt_ColumnOptionsFieldName.TabIndex = 23;
         this._txt_ColumnOptionsFieldName.TextChanged += new System.EventHandler(this.OptionsChanged);
         // 
         // _gbKeyColumn
         // 
         this._gbKeyColumn.Controls.Add(this._cbIsKeyColumn);
         this._gbKeyColumn.Location = new System.Drawing.Point(12, 386);
         this._gbKeyColumn.Name = "_gbKeyColumn";
         this._gbKeyColumn.Size = new System.Drawing.Size(260, 43);
         this._gbKeyColumn.TabIndex = 24;
         this._gbKeyColumn.TabStop = false;
         this._gbKeyColumn.Text = "Key Column";
         // 
         // _cbIsKeyColumn
         // 
         this._cbIsKeyColumn.AutoSize = true;
         this._cbIsKeyColumn.Location = new System.Drawing.Point(7, 20);
         this._cbIsKeyColumn.Name = "_cbIsKeyColumn";
         this._cbIsKeyColumn.Size = new System.Drawing.Size(82, 17);
         this._cbIsKeyColumn.TabIndex = 0;
         this._cbIsKeyColumn.Text = "Key Column";
         this._cbIsKeyColumn.UseVisualStyleBackColor = true;
         this._cbIsKeyColumn.CheckedChanged += new System.EventHandler(this._cbIsKeyColumn_CheckedChanged);
         // 
         // _gbDropoutOptions
         // 
         this._gbDropoutOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this._gbDropoutOptions.Controls.Add(this._chkDropoutCells);
         this._gbDropoutOptions.Controls.Add(this._chkDropoutWords);
         this._gbDropoutOptions.Location = new System.Drawing.Point(12, 329);
         this._gbDropoutOptions.Name = "_gbDropoutOptions";
         this._gbDropoutOptions.Size = new System.Drawing.Size(260, 51);
         this._gbDropoutOptions.TabIndex = 25;
         this._gbDropoutOptions.TabStop = false;
         this._gbDropoutOptions.Text = "Dropout";
         // 
         // _chkDropoutWords
         // 
         this._chkDropoutWords.AutoSize = true;
         this._chkDropoutWords.Location = new System.Drawing.Point(10, 19);
         this._chkDropoutWords.Name = "_chkDropoutWords";
         this._chkDropoutWords.Size = new System.Drawing.Size(57, 17);
         this._chkDropoutWords.TabIndex = 7;
         this._chkDropoutWords.Text = "Words";
         this._chkDropoutWords.UseVisualStyleBackColor = true;
         // 
         // _chkDropoutCells
         // 
         this._chkDropoutCells.AutoSize = true;
         this._chkDropoutCells.Location = new System.Drawing.Point(102, 19);
         this._chkDropoutCells.Name = "_chkDropoutCells";
         this._chkDropoutCells.Size = new System.Drawing.Size(87, 17);
         this._chkDropoutCells.TabIndex = 8;
         this._chkDropoutCells.Text = "Cells Borders";
         this._chkDropoutCells.UseVisualStyleBackColor = true;
         // 
         // _btnOK
         // 
         this._btnOK.Location = new System.Drawing.Point(77, 507);
         this._btnOK.Name = "_btnOK";
         this._btnOK.Size = new System.Drawing.Size(132, 33);
         this._btnOK.TabIndex = 26;
         this._btnOK.Text = "OK";
         this._btnOK.UseVisualStyleBackColor = true;
         this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
         // 
         // ColumnOptions
         // 
         this.AcceptButton = this._btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(284, 547);
         this.Controls.Add(this._btnOK);
         this.Controls.Add(this._gbDropoutOptions);
         this.Controls.Add(this._gbKeyColumn);
         this.Controls.Add(this._txt_ColumnOptionsFieldName);
         this.Controls.Add(this.label1);
         this.Controls.Add(this._gbBounds);
         this.Controls.Add(this._gb_OmrColumnOptions);
         this.Controls.Add(this._gb_OcrColumnOption);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "ColumnOptions";
         this.Text = "Column Options";
         this._gbFieldMethod.ResumeLayout(false);
         this._gbFieldMethod.PerformLayout();
         this._gbFieldTextType.ResumeLayout(false);
         this._gbFieldTextType.PerformLayout();
         this._gb_OcrColumnOption.ResumeLayout(false);
         this._gbOMRFrame.ResumeLayout(false);
         this._gbOMRFrame.PerformLayout();
         this._gbOMRSensitivity.ResumeLayout(false);
         this._gbOMRSensitivity.PerformLayout();
         this._gb_OmrColumnOptions.ResumeLayout(false);
         this._gbBounds.ResumeLayout(false);
         this._gbBounds.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._nudHeight)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._nudWidth)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._nudTop)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._nudLeft)).EndInit();
         this._gbKeyColumn.ResumeLayout(false);
         this._gbKeyColumn.PerformLayout();
         this._gbDropoutOptions.ResumeLayout(false);
         this._gbDropoutOptions.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.GroupBox _gbFieldMethod;
      private System.Windows.Forms.CheckBox _chkEnableIcr;
      private System.Windows.Forms.CheckBox _chkEnableOcr;
      private System.Windows.Forms.GroupBox _gbFieldTextType;
      private System.Windows.Forms.RadioButton _rbtextTypeNum;
      private System.Windows.Forms.RadioButton _rbTextTypeChar;
      private System.Windows.Forms.GroupBox _gb_OcrColumnOption;
      private System.Windows.Forms.GroupBox _gbOMRFrame;
      private System.Windows.Forms.RadioButton _rbOMRWithoutFrame;
      private System.Windows.Forms.RadioButton _rbOMRWithFrame;
      private System.Windows.Forms.RadioButton _rbOMRAutoFrame;
      private System.Windows.Forms.GroupBox _gbOMRSensitivity;
      private System.Windows.Forms.RadioButton _rbOMRSensitivityHighest;
      private System.Windows.Forms.RadioButton _rbOMRSensitivityHigh;
      private System.Windows.Forms.RadioButton _rbOMRSensitivityLowest;
      private System.Windows.Forms.RadioButton _rbOMRSensitivityLow;
      private System.Windows.Forms.GroupBox _gb_OmrColumnOptions;
      private System.Windows.Forms.GroupBox _gbBounds;
      private System.Windows.Forms.Label _lblFieldHeight;
      private System.Windows.Forms.Label _lblFieldWidth;
      private System.Windows.Forms.Label _lblFieldTop;
      private System.Windows.Forms.Label _lblFieldLeft;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox _txt_ColumnOptionsFieldName;
      private System.Windows.Forms.NumericUpDown _nudHeight;
      private System.Windows.Forms.NumericUpDown _nudWidth;
      private System.Windows.Forms.NumericUpDown _nudTop;
      private System.Windows.Forms.NumericUpDown _nudLeft;
      private System.Windows.Forms.GroupBox _gbKeyColumn;
      private System.Windows.Forms.CheckBox _cbIsKeyColumn;
      private System.Windows.Forms.GroupBox _gbDropoutOptions;
      private System.Windows.Forms.CheckBox _chkDropoutWords;
      private System.Windows.Forms.CheckBox _chkDropoutCells;
      private System.Windows.Forms.Button _btnOK;
   }
}