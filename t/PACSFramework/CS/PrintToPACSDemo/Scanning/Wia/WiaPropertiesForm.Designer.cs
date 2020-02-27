namespace PrintToPACSDemo
{
   partial class WiaPropertiesForm
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
         this._numMaxPagesCount = new System.Windows.Forms.NumericUpDown();
         this._lblMaxPagesCount = new System.Windows.Forms.Label();
         this._gbTransferMode = new System.Windows.Forms.GroupBox();
         this._rdFileMode = new System.Windows.Forms.RadioButton();
         this._rdMemoryMode = new System.Windows.Forms.RadioButton();
         this._cmbCompression = new System.Windows.Forms.ComboBox();
         this._lblCompression = new System.Windows.Forms.Label();
         this._cmbImageDataType = new System.Windows.Forms.ComboBox();
         this._lblImageDataType = new System.Windows.Forms.Label();
         this._cmbFormat = new System.Windows.Forms.ComboBox();
         this._lblFormat = new System.Windows.Forms.Label();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this._cmbOrientation = new System.Windows.Forms.ComboBox();
         this._lblOrientation = new System.Windows.Forms.Label();
         this.groupBox3 = new System.Windows.Forms.GroupBox();
         this._cbAutoAdvance = new System.Windows.Forms.CheckBox();
         this._cbPrefeed = new System.Windows.Forms.CheckBox();
         this._cbNextPage = new System.Windows.Forms.CheckBox();
         this._cbBackFirst = new System.Windows.Forms.CheckBox();
         this._cbFrontFirst = new System.Windows.Forms.CheckBox();
         this._cbBackOnly = new System.Windows.Forms.CheckBox();
         this._cbFrontOnly = new System.Windows.Forms.CheckBox();
         this._cbDuplex = new System.Windows.Forms.CheckBox();
         this._cbFlatbed = new System.Windows.Forms.CheckBox();
         this._cbFeeder = new System.Windows.Forms.CheckBox();
         this.groupBox4 = new System.Windows.Forms.GroupBox();
         this._cbColored = new System.Windows.Forms.CheckBox();
         this._cbGrayscale = new System.Windows.Forms.CheckBox();
         this._cbText = new System.Windows.Forms.CheckBox();
         this._gbImageResolutionProperties = new System.Windows.Forms.GroupBox();
         this._cmbVerticalResolution = new System.Windows.Forms.ComboBox();
         this._cmbHorizontalResolution = new System.Windows.Forms.ComboBox();
         this._numHeight = new System.Windows.Forms.NumericUpDown();
         this._numWidth = new System.Windows.Forms.NumericUpDown();
         this._numYPos = new System.Windows.Forms.NumericUpDown();
         this._numXPos = new System.Windows.Forms.NumericUpDown();
         this._numVerticalResolution = new System.Windows.Forms.NumericUpDown();
         this._numVerticalScaling = new System.Windows.Forms.NumericUpDown();
         this._numHorizontalResolution = new System.Windows.Forms.NumericUpDown();
         this._numHorizontalScaling = new System.Windows.Forms.NumericUpDown();
         this._lblHeight = new System.Windows.Forms.Label();
         this._lblWidth = new System.Windows.Forms.Label();
         this._lblYPos = new System.Windows.Forms.Label();
         this._lblXPos = new System.Windows.Forms.Label();
         this._lblVerticalScaling = new System.Windows.Forms.Label();
         this._lblHorizontalScaling = new System.Windows.Forms.Label();
         this._lblVerticalResolution = new System.Windows.Forms.Label();
         this._lblHorizontalResolution = new System.Windows.Forms.Label();
         this._cmbRotationAngle = new System.Windows.Forms.ComboBox();
         this._lblRotationAngle = new System.Windows.Forms.Label();
         this._cmbBitsPerPixel = new System.Windows.Forms.ComboBox();
         this._lblBitsPerPixel = new System.Windows.Forms.Label();
         this._gbImageEffectsProperties = new System.Windows.Forms.GroupBox();
         this._numContrast = new System.Windows.Forms.NumericUpDown();
         this._numBrightness = new System.Windows.Forms.NumericUpDown();
         this._lblContrast = new System.Windows.Forms.Label();
         this._lblBrightness = new System.Windows.Forms.Label();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this.groupBox1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numMaxPagesCount)).BeginInit();
         this._gbTransferMode.SuspendLayout();
         this.groupBox2.SuspendLayout();
         this.groupBox3.SuspendLayout();
         this.groupBox4.SuspendLayout();
         this._gbImageResolutionProperties.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numHeight)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numWidth)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numYPos)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numXPos)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numVerticalResolution)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numVerticalScaling)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numHorizontalResolution)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numHorizontalScaling)).BeginInit();
         this._gbImageEffectsProperties.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numContrast)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numBrightness)).BeginInit();
         this.SuspendLayout();
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this._numMaxPagesCount);
         this.groupBox1.Controls.Add(this._lblMaxPagesCount);
         this.groupBox1.Controls.Add(this._gbTransferMode);
         this.groupBox1.Controls.Add(this._cmbCompression);
         this.groupBox1.Controls.Add(this._lblCompression);
         this.groupBox1.Controls.Add(this._cmbImageDataType);
         this.groupBox1.Controls.Add(this._lblImageDataType);
         this.groupBox1.Controls.Add(this._cmbFormat);
         this.groupBox1.Controls.Add(this._lblFormat);
         this.groupBox1.Location = new System.Drawing.Point(313, 12);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(295, 239);
         this.groupBox1.TabIndex = 1;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Scanner Properties";
         // 
         // _numMaxPagesCount
         // 
         this._numMaxPagesCount.Enabled = false;
         this._numMaxPagesCount.Location = new System.Drawing.Point(189, 175);
         this._numMaxPagesCount.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
         this._numMaxPagesCount.Name = "_numMaxPagesCount";
         this._numMaxPagesCount.Size = new System.Drawing.Size(100, 20);
         this._numMaxPagesCount.TabIndex = 29;
         this._numMaxPagesCount.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _lblMaxPagesCount
         // 
         this._lblMaxPagesCount.AutoSize = true;
         this._lblMaxPagesCount.Location = new System.Drawing.Point(6, 178);
         this._lblMaxPagesCount.Name = "_lblMaxPagesCount";
         this._lblMaxPagesCount.Size = new System.Drawing.Size(115, 13);
         this._lblMaxPagesCount.TabIndex = 27;
         this._lblMaxPagesCount.Text = "Maximum Pages Count";
         // 
         // _gbTransferMode
         // 
         this._gbTransferMode.Controls.Add(this._rdFileMode);
         this._gbTransferMode.Controls.Add(this._rdMemoryMode);
         this._gbTransferMode.Location = new System.Drawing.Point(6, 103);
         this._gbTransferMode.Name = "_gbTransferMode";
         this._gbTransferMode.Size = new System.Drawing.Size(283, 60);
         this._gbTransferMode.TabIndex = 26;
         this._gbTransferMode.TabStop = false;
         this._gbTransferMode.Text = "Transfer Mode";
         // 
         // _rdFileMode
         // 
         this._rdFileMode.AutoSize = true;
         this._rdFileMode.Enabled = false;
         this._rdFileMode.Location = new System.Drawing.Point(129, 23);
         this._rdFileMode.Name = "_rdFileMode";
         this._rdFileMode.Size = new System.Drawing.Size(71, 17);
         this._rdFileMode.TabIndex = 28;
         this._rdFileMode.TabStop = true;
         this._rdFileMode.Text = "File Mode";
         this._rdFileMode.UseVisualStyleBackColor = true;
         this._rdFileMode.Click += new System.EventHandler(this._rdFileMode_Click);
         // 
         // _rdMemoryMode
         // 
         this._rdMemoryMode.AutoSize = true;
         this._rdMemoryMode.Enabled = false;
         this._rdMemoryMode.Location = new System.Drawing.Point(6, 23);
         this._rdMemoryMode.Name = "_rdMemoryMode";
         this._rdMemoryMode.Size = new System.Drawing.Size(92, 17);
         this._rdMemoryMode.TabIndex = 27;
         this._rdMemoryMode.TabStop = true;
         this._rdMemoryMode.Text = "Memory Mode";
         this._rdMemoryMode.UseVisualStyleBackColor = true;
         this._rdMemoryMode.Click += new System.EventHandler(this._rdMemoryMode_Click);
         // 
         // _cmbCompression
         // 
         this._cmbCompression.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbCompression.Enabled = false;
         this._cmbCompression.FormattingEnabled = true;
         this._cmbCompression.Location = new System.Drawing.Point(135, 49);
         this._cmbCompression.Name = "_cmbCompression";
         this._cmbCompression.Size = new System.Drawing.Size(154, 21);
         this._cmbCompression.TabIndex = 25;
         // 
         // _lblCompression
         // 
         this._lblCompression.AutoSize = true;
         this._lblCompression.Location = new System.Drawing.Point(6, 52);
         this._lblCompression.Name = "_lblCompression";
         this._lblCompression.Size = new System.Drawing.Size(67, 13);
         this._lblCompression.TabIndex = 24;
         this._lblCompression.Text = "Compression";
         // 
         // _cmbImageDataType
         // 
         this._cmbImageDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbImageDataType.Enabled = false;
         this._cmbImageDataType.FormattingEnabled = true;
         this._cmbImageDataType.Location = new System.Drawing.Point(135, 76);
         this._cmbImageDataType.Name = "_cmbImageDataType";
         this._cmbImageDataType.Size = new System.Drawing.Size(154, 21);
         this._cmbImageDataType.TabIndex = 26;
         // 
         // _lblImageDataType
         // 
         this._lblImageDataType.AutoSize = true;
         this._lblImageDataType.Location = new System.Drawing.Point(6, 79);
         this._lblImageDataType.Name = "_lblImageDataType";
         this._lblImageDataType.Size = new System.Drawing.Size(89, 13);
         this._lblImageDataType.TabIndex = 22;
         this._lblImageDataType.Text = "Image Data Type";
         // 
         // _cmbFormat
         // 
         this._cmbFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbFormat.Enabled = false;
         this._cmbFormat.FormattingEnabled = true;
         this._cmbFormat.Location = new System.Drawing.Point(135, 22);
         this._cmbFormat.Name = "_cmbFormat";
         this._cmbFormat.Size = new System.Drawing.Size(154, 21);
         this._cmbFormat.TabIndex = 24;
         // 
         // _lblFormat
         // 
         this._lblFormat.AutoSize = true;
         this._lblFormat.Location = new System.Drawing.Point(6, 25);
         this._lblFormat.Name = "_lblFormat";
         this._lblFormat.Size = new System.Drawing.Size(39, 13);
         this._lblFormat.TabIndex = 20;
         this._lblFormat.Text = "Format";
         // 
         // groupBox2
         // 
         this.groupBox2.Controls.Add(this._cmbOrientation);
         this.groupBox2.Controls.Add(this._lblOrientation);
         this.groupBox2.Controls.Add(this.groupBox3);
         this.groupBox2.Controls.Add(this.groupBox4);
         this.groupBox2.Location = new System.Drawing.Point(12, 12);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(295, 239);
         this.groupBox2.TabIndex = 0;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Scanner Properties";
         // 
         // _cmbOrientation
         // 
         this._cmbOrientation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbOrientation.Enabled = false;
         this._cmbOrientation.FormattingEnabled = true;
         this._cmbOrientation.Location = new System.Drawing.Point(135, 205);
         this._cmbOrientation.Name = "_cmbOrientation";
         this._cmbOrientation.Size = new System.Drawing.Size(154, 21);
         this._cmbOrientation.TabIndex = 13;
         // 
         // _lblOrientation
         // 
         this._lblOrientation.AutoSize = true;
         this._lblOrientation.Location = new System.Drawing.Point(6, 208);
         this._lblOrientation.Name = "_lblOrientation";
         this._lblOrientation.Size = new System.Drawing.Size(58, 13);
         this._lblOrientation.TabIndex = 2;
         this._lblOrientation.Text = "Orientation";
         // 
         // groupBox3
         // 
         this.groupBox3.Controls.Add(this._cbAutoAdvance);
         this.groupBox3.Controls.Add(this._cbPrefeed);
         this.groupBox3.Controls.Add(this._cbNextPage);
         this.groupBox3.Controls.Add(this._cbBackFirst);
         this.groupBox3.Controls.Add(this._cbFrontFirst);
         this.groupBox3.Controls.Add(this._cbBackOnly);
         this.groupBox3.Controls.Add(this._cbFrontOnly);
         this.groupBox3.Controls.Add(this._cbDuplex);
         this.groupBox3.Controls.Add(this._cbFlatbed);
         this.groupBox3.Controls.Add(this._cbFeeder);
         this.groupBox3.Location = new System.Drawing.Point(6, 78);
         this.groupBox3.Name = "groupBox3";
         this.groupBox3.Size = new System.Drawing.Size(283, 121);
         this.groupBox3.TabIndex = 1;
         this.groupBox3.TabStop = false;
         this.groupBox3.Text = "Paper Source and Duplex Modes";
         // 
         // _cbAutoAdvance
         // 
         this._cbAutoAdvance.AutoSize = true;
         this._cbAutoAdvance.Enabled = false;
         this._cbAutoAdvance.Location = new System.Drawing.Point(6, 92);
         this._cbAutoAdvance.Name = "_cbAutoAdvance";
         this._cbAutoAdvance.Size = new System.Drawing.Size(94, 17);
         this._cbAutoAdvance.TabIndex = 12;
         this._cbAutoAdvance.Text = "Auto Advance";
         this._cbAutoAdvance.UseVisualStyleBackColor = true;
         this._cbAutoAdvance.Click += new System.EventHandler(this._cbAutoAdvance_Click);
         // 
         // _cbPrefeed
         // 
         this._cbPrefeed.AutoSize = true;
         this._cbPrefeed.Enabled = false;
         this._cbPrefeed.Location = new System.Drawing.Point(206, 69);
         this._cbPrefeed.Name = "_cbPrefeed";
         this._cbPrefeed.Size = new System.Drawing.Size(66, 17);
         this._cbPrefeed.TabIndex = 11;
         this._cbPrefeed.Text = "Pre-feed";
         this._cbPrefeed.UseVisualStyleBackColor = true;
         // 
         // _cbNextPage
         // 
         this._cbNextPage.AutoSize = true;
         this._cbNextPage.Enabled = false;
         this._cbNextPage.Location = new System.Drawing.Point(106, 69);
         this._cbNextPage.Name = "_cbNextPage";
         this._cbNextPage.Size = new System.Drawing.Size(76, 17);
         this._cbNextPage.TabIndex = 10;
         this._cbNextPage.Text = "Next Page";
         this._cbNextPage.UseVisualStyleBackColor = true;
         // 
         // _cbBackFirst
         // 
         this._cbBackFirst.AutoSize = true;
         this._cbBackFirst.Enabled = false;
         this._cbBackFirst.Location = new System.Drawing.Point(6, 69);
         this._cbBackFirst.Name = "_cbBackFirst";
         this._cbBackFirst.Size = new System.Drawing.Size(73, 17);
         this._cbBackFirst.TabIndex = 9;
         this._cbBackFirst.Text = "Back First";
         this._cbBackFirst.UseVisualStyleBackColor = true;
         // 
         // _cbFrontFirst
         // 
         this._cbFrontFirst.AutoSize = true;
         this._cbFrontFirst.Enabled = false;
         this._cbFrontFirst.Location = new System.Drawing.Point(206, 46);
         this._cbFrontFirst.Name = "_cbFrontFirst";
         this._cbFrontFirst.Size = new System.Drawing.Size(72, 17);
         this._cbFrontFirst.TabIndex = 8;
         this._cbFrontFirst.Text = "Front First";
         this._cbFrontFirst.UseVisualStyleBackColor = true;
         // 
         // _cbBackOnly
         // 
         this._cbBackOnly.AutoSize = true;
         this._cbBackOnly.Enabled = false;
         this._cbBackOnly.Location = new System.Drawing.Point(106, 46);
         this._cbBackOnly.Name = "_cbBackOnly";
         this._cbBackOnly.Size = new System.Drawing.Size(75, 17);
         this._cbBackOnly.TabIndex = 7;
         this._cbBackOnly.Text = "Back Only";
         this._cbBackOnly.UseVisualStyleBackColor = true;
         // 
         // _cbFrontOnly
         // 
         this._cbFrontOnly.AutoSize = true;
         this._cbFrontOnly.Enabled = false;
         this._cbFrontOnly.Location = new System.Drawing.Point(6, 46);
         this._cbFrontOnly.Name = "_cbFrontOnly";
         this._cbFrontOnly.Size = new System.Drawing.Size(74, 17);
         this._cbFrontOnly.TabIndex = 6;
         this._cbFrontOnly.Text = "Front Only";
         this._cbFrontOnly.UseVisualStyleBackColor = true;
         // 
         // _cbDuplex
         // 
         this._cbDuplex.AutoSize = true;
         this._cbDuplex.Enabled = false;
         this._cbDuplex.Location = new System.Drawing.Point(206, 23);
         this._cbDuplex.Name = "_cbDuplex";
         this._cbDuplex.Size = new System.Drawing.Size(59, 17);
         this._cbDuplex.TabIndex = 5;
         this._cbDuplex.Text = "Duplex";
         this._cbDuplex.UseVisualStyleBackColor = true;
         this._cbDuplex.Click += new System.EventHandler(this._cbDuplex_Click);
         // 
         // _cbFlatbed
         // 
         this._cbFlatbed.AutoSize = true;
         this._cbFlatbed.Enabled = false;
         this._cbFlatbed.Location = new System.Drawing.Point(106, 23);
         this._cbFlatbed.Name = "_cbFlatbed";
         this._cbFlatbed.Size = new System.Drawing.Size(61, 17);
         this._cbFlatbed.TabIndex = 4;
         this._cbFlatbed.Text = "Flatbed";
         this._cbFlatbed.UseVisualStyleBackColor = true;
         // 
         // _cbFeeder
         // 
         this._cbFeeder.AutoSize = true;
         this._cbFeeder.Enabled = false;
         this._cbFeeder.Location = new System.Drawing.Point(6, 23);
         this._cbFeeder.Name = "_cbFeeder";
         this._cbFeeder.Size = new System.Drawing.Size(59, 17);
         this._cbFeeder.TabIndex = 3;
         this._cbFeeder.Text = "Feeder";
         this._cbFeeder.UseVisualStyleBackColor = true;
         // 
         // groupBox4
         // 
         this.groupBox4.Controls.Add(this._cbColored);
         this.groupBox4.Controls.Add(this._cbGrayscale);
         this.groupBox4.Controls.Add(this._cbText);
         this.groupBox4.Location = new System.Drawing.Point(6, 19);
         this.groupBox4.Name = "groupBox4";
         this.groupBox4.Size = new System.Drawing.Size(283, 53);
         this.groupBox4.TabIndex = 0;
         this.groupBox4.TabStop = false;
         this.groupBox4.Text = "Image Type";
         // 
         // _cbColored
         // 
         this._cbColored.AutoSize = true;
         this._cbColored.Enabled = false;
         this._cbColored.Location = new System.Drawing.Point(6, 23);
         this._cbColored.Name = "_cbColored";
         this._cbColored.Size = new System.Drawing.Size(62, 17);
         this._cbColored.TabIndex = 0;
         this._cbColored.Text = "Colored";
         this._cbColored.UseVisualStyleBackColor = true;
         this._cbColored.Click += new System.EventHandler(this._cbColored_Click);
         // 
         // _cbGrayscale
         // 
         this._cbGrayscale.AutoSize = true;
         this._cbGrayscale.Enabled = false;
         this._cbGrayscale.Location = new System.Drawing.Point(106, 23);
         this._cbGrayscale.Name = "_cbGrayscale";
         this._cbGrayscale.Size = new System.Drawing.Size(73, 17);
         this._cbGrayscale.TabIndex = 1;
         this._cbGrayscale.Text = "Grayscale";
         this._cbGrayscale.UseVisualStyleBackColor = true;
         this._cbGrayscale.Click += new System.EventHandler(this._cbGrayscale_Click);
         // 
         // _cbText
         // 
         this._cbText.AutoSize = true;
         this._cbText.Enabled = false;
         this._cbText.Location = new System.Drawing.Point(206, 23);
         this._cbText.Name = "_cbText";
         this._cbText.Size = new System.Drawing.Size(47, 17);
         this._cbText.TabIndex = 2;
         this._cbText.Text = "Text";
         this._cbText.UseVisualStyleBackColor = true;
         this._cbText.Click += new System.EventHandler(this._cbText_Click);
         // 
         // _gbImageResolutionProperties
         // 
         this._gbImageResolutionProperties.Controls.Add(this._cmbVerticalResolution);
         this._gbImageResolutionProperties.Controls.Add(this._cmbHorizontalResolution);
         this._gbImageResolutionProperties.Controls.Add(this._numHeight);
         this._gbImageResolutionProperties.Controls.Add(this._numWidth);
         this._gbImageResolutionProperties.Controls.Add(this._numYPos);
         this._gbImageResolutionProperties.Controls.Add(this._numXPos);
         this._gbImageResolutionProperties.Controls.Add(this._numVerticalResolution);
         this._gbImageResolutionProperties.Controls.Add(this._numVerticalScaling);
         this._gbImageResolutionProperties.Controls.Add(this._numHorizontalResolution);
         this._gbImageResolutionProperties.Controls.Add(this._numHorizontalScaling);
         this._gbImageResolutionProperties.Controls.Add(this._lblHeight);
         this._gbImageResolutionProperties.Controls.Add(this._lblWidth);
         this._gbImageResolutionProperties.Controls.Add(this._lblYPos);
         this._gbImageResolutionProperties.Controls.Add(this._lblXPos);
         this._gbImageResolutionProperties.Controls.Add(this._lblVerticalScaling);
         this._gbImageResolutionProperties.Controls.Add(this._lblHorizontalScaling);
         this._gbImageResolutionProperties.Controls.Add(this._lblVerticalResolution);
         this._gbImageResolutionProperties.Controls.Add(this._lblHorizontalResolution);
         this._gbImageResolutionProperties.Controls.Add(this._cmbRotationAngle);
         this._gbImageResolutionProperties.Controls.Add(this._lblRotationAngle);
         this._gbImageResolutionProperties.Controls.Add(this._cmbBitsPerPixel);
         this._gbImageResolutionProperties.Controls.Add(this._lblBitsPerPixel);
         this._gbImageResolutionProperties.Location = new System.Drawing.Point(12, 257);
         this._gbImageResolutionProperties.Name = "_gbImageResolutionProperties";
         this._gbImageResolutionProperties.Size = new System.Drawing.Size(295, 294);
         this._gbImageResolutionProperties.TabIndex = 2;
         this._gbImageResolutionProperties.TabStop = false;
         this._gbImageResolutionProperties.Text = "Image Resolution Properties";
         // 
         // _cmbVerticalResolution
         // 
         this._cmbVerticalResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbVerticalResolution.FormattingEnabled = true;
         this._cmbVerticalResolution.Location = new System.Drawing.Point(135, 105);
         this._cmbVerticalResolution.Name = "_cmbVerticalResolution";
         this._cmbVerticalResolution.Size = new System.Drawing.Size(154, 21);
         this._cmbVerticalResolution.TabIndex = 17;
         this._cmbVerticalResolution.Visible = false;
         this._cmbVerticalResolution.SelectedIndexChanged += new System.EventHandler(this._cmbVerticalResolution_SelectedIndexChanged);
         // 
         // _cmbHorizontalResolution
         // 
         this._cmbHorizontalResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbHorizontalResolution.FormattingEnabled = true;
         this._cmbHorizontalResolution.Location = new System.Drawing.Point(135, 78);
         this._cmbHorizontalResolution.Name = "_cmbHorizontalResolution";
         this._cmbHorizontalResolution.Size = new System.Drawing.Size(154, 21);
         this._cmbHorizontalResolution.TabIndex = 16;
         this._cmbHorizontalResolution.Visible = false;
         this._cmbHorizontalResolution.SelectedIndexChanged += new System.EventHandler(this._cmbHorizontalResolution_SelectedIndexChanged);
         // 
         // _numHeight
         // 
         this._numHeight.Enabled = false;
         this._numHeight.Location = new System.Drawing.Point(189, 261);
         this._numHeight.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
         this._numHeight.Name = "_numHeight";
         this._numHeight.Size = new System.Drawing.Size(100, 20);
         this._numHeight.TabIndex = 23;
         this._numHeight.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _numWidth
         // 
         this._numWidth.Enabled = false;
         this._numWidth.Location = new System.Drawing.Point(189, 235);
         this._numWidth.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
         this._numWidth.Name = "_numWidth";
         this._numWidth.Size = new System.Drawing.Size(100, 20);
         this._numWidth.TabIndex = 22;
         this._numWidth.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _numYPos
         // 
         this._numYPos.Enabled = false;
         this._numYPos.Location = new System.Drawing.Point(189, 209);
         this._numYPos.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
         this._numYPos.Name = "_numYPos";
         this._numYPos.Size = new System.Drawing.Size(100, 20);
         this._numYPos.TabIndex = 21;
         this._numYPos.Leave += new System.EventHandler(this._numYPos_Leave);
         // 
         // _numXPos
         // 
         this._numXPos.Enabled = false;
         this._numXPos.Location = new System.Drawing.Point(189, 183);
         this._numXPos.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
         this._numXPos.Name = "_numXPos";
         this._numXPos.Size = new System.Drawing.Size(100, 20);
         this._numXPos.TabIndex = 20;
         this._numXPos.Leave += new System.EventHandler(this._numXPos_Leave);
         // 
         // _numVerticalResolution
         // 
         this._numVerticalResolution.Enabled = false;
         this._numVerticalResolution.ImeMode = System.Windows.Forms.ImeMode.NoControl;
         this._numVerticalResolution.Location = new System.Drawing.Point(189, 104);
         this._numVerticalResolution.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
         this._numVerticalResolution.Name = "_numVerticalResolution";
         this._numVerticalResolution.Size = new System.Drawing.Size(100, 20);
         this._numVerticalResolution.TabIndex = 17;
         this._numVerticalResolution.Leave += new System.EventHandler(this._numVerticalResolution_Leave);
         // 
         // _numVerticalScaling
         // 
         this._numVerticalScaling.Enabled = false;
         this._numVerticalScaling.Location = new System.Drawing.Point(189, 157);
         this._numVerticalScaling.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
         this._numVerticalScaling.Name = "_numVerticalScaling";
         this._numVerticalScaling.Size = new System.Drawing.Size(100, 20);
         this._numVerticalScaling.TabIndex = 19;
         this._numVerticalScaling.Leave += new System.EventHandler(this._numVerticalScaling_Leave);
         // 
         // _numHorizontalResolution
         // 
         this._numHorizontalResolution.Enabled = false;
         this._numHorizontalResolution.ImeMode = System.Windows.Forms.ImeMode.NoControl;
         this._numHorizontalResolution.Location = new System.Drawing.Point(189, 78);
         this._numHorizontalResolution.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
         this._numHorizontalResolution.Name = "_numHorizontalResolution";
         this._numHorizontalResolution.Size = new System.Drawing.Size(100, 20);
         this._numHorizontalResolution.TabIndex = 16;
         this._numHorizontalResolution.Leave += new System.EventHandler(this._numHorizontalResolution_Leave);
         // 
         // _numHorizontalScaling
         // 
         this._numHorizontalScaling.Enabled = false;
         this._numHorizontalScaling.Location = new System.Drawing.Point(189, 130);
         this._numHorizontalScaling.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
         this._numHorizontalScaling.Name = "_numHorizontalScaling";
         this._numHorizontalScaling.Size = new System.Drawing.Size(100, 20);
         this._numHorizontalScaling.TabIndex = 18;
         this._numHorizontalScaling.Leave += new System.EventHandler(this._numHorizontalScaling_Leave);
         // 
         // _lblHeight
         // 
         this._lblHeight.AutoSize = true;
         this._lblHeight.Location = new System.Drawing.Point(6, 263);
         this._lblHeight.Name = "_lblHeight";
         this._lblHeight.Size = new System.Drawing.Size(38, 13);
         this._lblHeight.TabIndex = 19;
         this._lblHeight.Text = "Height";
         // 
         // _lblWidth
         // 
         this._lblWidth.AutoSize = true;
         this._lblWidth.Location = new System.Drawing.Point(6, 237);
         this._lblWidth.Name = "_lblWidth";
         this._lblWidth.Size = new System.Drawing.Size(35, 13);
         this._lblWidth.TabIndex = 17;
         this._lblWidth.Text = "Width";
         // 
         // _lblYPos
         // 
         this._lblYPos.AutoSize = true;
         this._lblYPos.Location = new System.Drawing.Point(6, 211);
         this._lblYPos.Name = "_lblYPos";
         this._lblYPos.Size = new System.Drawing.Size(32, 13);
         this._lblYPos.TabIndex = 15;
         this._lblYPos.Text = "YPos";
         // 
         // _lblXPos
         // 
         this._lblXPos.AutoSize = true;
         this._lblXPos.Location = new System.Drawing.Point(6, 185);
         this._lblXPos.Name = "_lblXPos";
         this._lblXPos.Size = new System.Drawing.Size(32, 13);
         this._lblXPos.TabIndex = 13;
         this._lblXPos.Text = "XPos";
         // 
         // _lblVerticalScaling
         // 
         this._lblVerticalScaling.AutoSize = true;
         this._lblVerticalScaling.Location = new System.Drawing.Point(6, 159);
         this._lblVerticalScaling.Name = "_lblVerticalScaling";
         this._lblVerticalScaling.Size = new System.Drawing.Size(80, 13);
         this._lblVerticalScaling.TabIndex = 11;
         this._lblVerticalScaling.Text = "Vertical Scaling";
         // 
         // _lblHorizontalScaling
         // 
         this._lblHorizontalScaling.AutoSize = true;
         this._lblHorizontalScaling.Location = new System.Drawing.Point(6, 133);
         this._lblHorizontalScaling.Name = "_lblHorizontalScaling";
         this._lblHorizontalScaling.Size = new System.Drawing.Size(92, 13);
         this._lblHorizontalScaling.TabIndex = 9;
         this._lblHorizontalScaling.Text = "Horizontal Scaling";
         // 
         // _lblVerticalResolution
         // 
         this._lblVerticalResolution.AutoSize = true;
         this._lblVerticalResolution.Location = new System.Drawing.Point(6, 107);
         this._lblVerticalResolution.Name = "_lblVerticalResolution";
         this._lblVerticalResolution.Size = new System.Drawing.Size(95, 13);
         this._lblVerticalResolution.TabIndex = 7;
         this._lblVerticalResolution.Text = "Vertical Resolution";
         // 
         // _lblHorizontalResolution
         // 
         this._lblHorizontalResolution.AutoSize = true;
         this._lblHorizontalResolution.Location = new System.Drawing.Point(6, 81);
         this._lblHorizontalResolution.Name = "_lblHorizontalResolution";
         this._lblHorizontalResolution.Size = new System.Drawing.Size(107, 13);
         this._lblHorizontalResolution.TabIndex = 5;
         this._lblHorizontalResolution.Text = "Horizontal Resolution";
         // 
         // _cmbRotationAngle
         // 
         this._cmbRotationAngle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbRotationAngle.Enabled = false;
         this._cmbRotationAngle.FormattingEnabled = true;
         this._cmbRotationAngle.Location = new System.Drawing.Point(135, 51);
         this._cmbRotationAngle.Name = "_cmbRotationAngle";
         this._cmbRotationAngle.Size = new System.Drawing.Size(154, 21);
         this._cmbRotationAngle.TabIndex = 15;
         // 
         // _lblRotationAngle
         // 
         this._lblRotationAngle.AutoSize = true;
         this._lblRotationAngle.Location = new System.Drawing.Point(6, 54);
         this._lblRotationAngle.Name = "_lblRotationAngle";
         this._lblRotationAngle.Size = new System.Drawing.Size(77, 13);
         this._lblRotationAngle.TabIndex = 2;
         this._lblRotationAngle.Text = "Rotation Angle";
         // 
         // _cmbBitsPerPixel
         // 
         this._cmbBitsPerPixel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbBitsPerPixel.Enabled = false;
         this._cmbBitsPerPixel.FormattingEnabled = true;
         this._cmbBitsPerPixel.Location = new System.Drawing.Point(135, 24);
         this._cmbBitsPerPixel.Name = "_cmbBitsPerPixel";
         this._cmbBitsPerPixel.Size = new System.Drawing.Size(154, 21);
         this._cmbBitsPerPixel.TabIndex = 14;
         // 
         // _lblBitsPerPixel
         // 
         this._lblBitsPerPixel.AutoSize = true;
         this._lblBitsPerPixel.Location = new System.Drawing.Point(6, 27);
         this._lblBitsPerPixel.Name = "_lblBitsPerPixel";
         this._lblBitsPerPixel.Size = new System.Drawing.Size(68, 13);
         this._lblBitsPerPixel.TabIndex = 0;
         this._lblBitsPerPixel.Text = "Bits Per Pixel";
         // 
         // _gbImageEffectsProperties
         // 
         this._gbImageEffectsProperties.Controls.Add(this._numContrast);
         this._gbImageEffectsProperties.Controls.Add(this._numBrightness);
         this._gbImageEffectsProperties.Controls.Add(this._lblContrast);
         this._gbImageEffectsProperties.Controls.Add(this._lblBrightness);
         this._gbImageEffectsProperties.Location = new System.Drawing.Point(313, 257);
         this._gbImageEffectsProperties.Name = "_gbImageEffectsProperties";
         this._gbImageEffectsProperties.Size = new System.Drawing.Size(295, 88);
         this._gbImageEffectsProperties.TabIndex = 3;
         this._gbImageEffectsProperties.TabStop = false;
         this._gbImageEffectsProperties.Text = "Image Effects Properties";
         // 
         // _numContrast
         // 
         this._numContrast.Enabled = false;
         this._numContrast.Location = new System.Drawing.Point(189, 50);
         this._numContrast.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
         this._numContrast.Name = "_numContrast";
         this._numContrast.Size = new System.Drawing.Size(100, 20);
         this._numContrast.TabIndex = 31;
         this._numContrast.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _numBrightness
         // 
         this._numBrightness.Enabled = false;
         this._numBrightness.Location = new System.Drawing.Point(189, 24);
         this._numBrightness.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
         this._numBrightness.Name = "_numBrightness";
         this._numBrightness.Size = new System.Drawing.Size(100, 20);
         this._numBrightness.TabIndex = 30;
         this._numBrightness.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _lblContrast
         // 
         this._lblContrast.AutoSize = true;
         this._lblContrast.Location = new System.Drawing.Point(6, 53);
         this._lblContrast.Name = "_lblContrast";
         this._lblContrast.Size = new System.Drawing.Size(46, 13);
         this._lblContrast.TabIndex = 1;
         this._lblContrast.Text = "Contrast";
         // 
         // _lblBrightness
         // 
         this._lblBrightness.AutoSize = true;
         this._lblBrightness.Location = new System.Drawing.Point(6, 27);
         this._lblBrightness.Name = "_lblBrightness";
         this._lblBrightness.Size = new System.Drawing.Size(56, 13);
         this._lblBrightness.TabIndex = 0;
         this._lblBrightness.Text = "Brightness";
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(533, 528);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(75, 23);
         this._btnCancel.TabIndex = 33;
         this._btnCancel.Text = "&Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // _btnOk
         // 
         this._btnOk.Location = new System.Drawing.Point(452, 528);
         this._btnOk.Name = "_btnOk";
         this._btnOk.Size = new System.Drawing.Size(75, 23);
         this._btnOk.TabIndex = 32;
         this._btnOk.Text = "&OK";
         this._btnOk.UseVisualStyleBackColor = true;
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // WiaPropertiesForm
         // 
         this.AcceptButton = this._btnOk;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(620, 563);
         this.Controls.Add(this._btnOk);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._gbImageEffectsProperties);
         this.Controls.Add(this._gbImageResolutionProperties);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.groupBox2);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "WiaPropertiesForm";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "WIA Properties Dialog";
         this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WiaPropertiesForm_FormClosed);
         this.Load += new System.EventHandler(this.WiaPropertiesForm_Load);
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numMaxPagesCount)).EndInit();
         this._gbTransferMode.ResumeLayout(false);
         this._gbTransferMode.PerformLayout();
         this.groupBox2.ResumeLayout(false);
         this.groupBox2.PerformLayout();
         this.groupBox3.ResumeLayout(false);
         this.groupBox3.PerformLayout();
         this.groupBox4.ResumeLayout(false);
         this.groupBox4.PerformLayout();
         this._gbImageResolutionProperties.ResumeLayout(false);
         this._gbImageResolutionProperties.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numHeight)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numWidth)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numYPos)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numXPos)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numVerticalResolution)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numVerticalScaling)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numHorizontalResolution)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numHorizontalScaling)).EndInit();
         this._gbImageEffectsProperties.ResumeLayout(false);
         this._gbImageEffectsProperties.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numContrast)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numBrightness)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.Label _lblOrientation;
      private System.Windows.Forms.GroupBox groupBox3;
      private System.Windows.Forms.CheckBox _cbAutoAdvance;
      private System.Windows.Forms.CheckBox _cbPrefeed;
      private System.Windows.Forms.CheckBox _cbNextPage;
      private System.Windows.Forms.CheckBox _cbBackFirst;
      private System.Windows.Forms.CheckBox _cbFrontFirst;
      private System.Windows.Forms.CheckBox _cbBackOnly;
      private System.Windows.Forms.CheckBox _cbFrontOnly;
      private System.Windows.Forms.CheckBox _cbDuplex;
      private System.Windows.Forms.CheckBox _cbFlatbed;
      private System.Windows.Forms.CheckBox _cbFeeder;
      private System.Windows.Forms.GroupBox groupBox4;
      private System.Windows.Forms.CheckBox _cbColored;
      private System.Windows.Forms.CheckBox _cbGrayscale;
      private System.Windows.Forms.CheckBox _cbText;
      private System.Windows.Forms.ComboBox _cmbOrientation;
      private System.Windows.Forms.GroupBox _gbImageResolutionProperties;
      private System.Windows.Forms.Label _lblBitsPerPixel;
      private System.Windows.Forms.ComboBox _cmbRotationAngle;
      private System.Windows.Forms.Label _lblRotationAngle;
      private System.Windows.Forms.ComboBox _cmbBitsPerPixel;
      private System.Windows.Forms.Label _lblHorizontalResolution;
      private System.Windows.Forms.Label _lblHorizontalScaling;
      private System.Windows.Forms.Label _lblVerticalResolution;
      private System.Windows.Forms.Label _lblHeight;
      private System.Windows.Forms.Label _lblWidth;
      private System.Windows.Forms.Label _lblYPos;
      private System.Windows.Forms.Label _lblXPos;
      private System.Windows.Forms.Label _lblVerticalScaling;
      private System.Windows.Forms.ComboBox _cmbCompression;
      private System.Windows.Forms.Label _lblCompression;
      private System.Windows.Forms.ComboBox _cmbImageDataType;
      private System.Windows.Forms.Label _lblImageDataType;
      private System.Windows.Forms.ComboBox _cmbFormat;
      private System.Windows.Forms.Label _lblFormat;
      private System.Windows.Forms.GroupBox _gbTransferMode;
      private System.Windows.Forms.RadioButton _rdFileMode;
      private System.Windows.Forms.RadioButton _rdMemoryMode;
      private System.Windows.Forms.Label _lblMaxPagesCount;
      private System.Windows.Forms.GroupBox _gbImageEffectsProperties;
      private System.Windows.Forms.Label _lblContrast;
      private System.Windows.Forms.Label _lblBrightness;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.NumericUpDown _numHorizontalResolution;
      private System.Windows.Forms.NumericUpDown _numVerticalResolution;
      private System.Windows.Forms.NumericUpDown _numHeight;
      private System.Windows.Forms.NumericUpDown _numWidth;
      private System.Windows.Forms.NumericUpDown _numYPos;
      private System.Windows.Forms.NumericUpDown _numXPos;
      private System.Windows.Forms.NumericUpDown _numVerticalScaling;
      private System.Windows.Forms.NumericUpDown _numHorizontalScaling;
      private System.Windows.Forms.NumericUpDown _numMaxPagesCount;
      private System.Windows.Forms.NumericUpDown _numContrast;
      private System.Windows.Forms.NumericUpDown _numBrightness;
      private System.Windows.Forms.ComboBox _cmbHorizontalResolution;
      private System.Windows.Forms.ComboBox _cmbVerticalResolution;
   }
}