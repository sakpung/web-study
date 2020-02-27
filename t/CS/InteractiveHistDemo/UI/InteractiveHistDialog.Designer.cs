using Leadtools;

namespace InteractiveHist
{
   partial class InteractiveHistogramDialog
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

      private InteractiveHistogramDialogData _interactiveHistogramData;
      private RasterImage applyImage;
      private MainForm _mainForm;
      private bool _cancelRun;
      private bool _doApply;

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.components = new System.ComponentModel.Container();
         this._lblHistogram = new System.Windows.Forms.Label();
         this._cmRightClickOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
         this._cmiZoomToSelection = new System.Windows.Forms.ToolStripMenuItem();
         this._cmiFitGraph = new System.Windows.Forms.ToolStripMenuItem();
         this._cmiFullRangeView = new System.Windows.Forms.ToolStripMenuItem();
         this._grpView = new System.Windows.Forms.GroupBox();
         this._lblHelp = new System.Windows.Forms.Label();
         this._btnShowHideOptions = new System.Windows.Forms.Button();
         this._tabOptions = new System.Windows.Forms.TabControl();
         this._tpgSegmentation = new System.Windows.Forms.TabPage();
         this._chkSegApplyInProgress = new System.Windows.Forms.CheckBox();
         this._btnSegApplyLUT = new System.Windows.Forms.Button();
         this._grpSegmentationInfo = new System.Windows.Forms.GroupBox();
         this._rbSegThreshold = new System.Windows.Forms.RadioButton();
         this._rbSegGradient = new System.Windows.Forms.RadioButton();
         this._lblSegEndColor = new System.Windows.Forms.Label();
         this._btnSegEndColor = new System.Windows.Forms.Button();
         this._lblSegStartColor = new System.Windows.Forms.Label();
         this._btnSegStartColor = new System.Windows.Forms.Button();
         this._btnSegApply = new System.Windows.Forms.Button();
         this._grpSegSelInfo = new System.Windows.Forms.GroupBox();
         this._lblSegEndPtOccVal = new System.Windows.Forms.Label();
         this._lblSegEndPtOcc = new System.Windows.Forms.Label();
         this._lblSegEndPtClr = new System.Windows.Forms.Label();
         this._nudSegEndPt = new System.Windows.Forms.NumericUpDown();
         this._lblSegEndPt = new System.Windows.Forms.Label();
         this._lblSegStartPtOccVal = new System.Windows.Forms.Label();
         this._lblSegStartPtOcc = new System.Windows.Forms.Label();
         this._lblSegStartPtClr = new System.Windows.Forms.Label();
         this._nudSegStartPt = new System.Windows.Forms.NumericUpDown();
         this._lblSegStartPt = new System.Windows.Forms.Label();
         this._tpgGrayDistribution = new System.Windows.Forms.TabPage();
         this._chkGrayApplyInProgress = new System.Windows.Forms.CheckBox();
         this._btnGrayApplyLUT = new System.Windows.Forms.Button();
         this._grpGrySelInfo = new System.Windows.Forms.GroupBox();
         this._lblGryEndPtOccVal = new System.Windows.Forms.Label();
         this._lblGryEndPtOcc = new System.Windows.Forms.Label();
         this._lblGrayEndPtClr = new System.Windows.Forms.Label();
         this._nudGrayEndPt = new System.Windows.Forms.NumericUpDown();
         this._lblGryEndPt = new System.Windows.Forms.Label();
         this._lblGryStartPtOccVal = new System.Windows.Forms.Label();
         this._lblGryStartPtOcc = new System.Windows.Forms.Label();
         this._lblGrayStartPtClr = new System.Windows.Forms.Label();
         this._nudGrayStartPt = new System.Windows.Forms.NumericUpDown();
         this._lblGryStartPt = new System.Windows.Forms.Label();
         this._btnGrayApplyToBitmap = new System.Windows.Forms.Button();
         this._grpGrayDistributionInfo = new System.Windows.Forms.GroupBox();
         this._cbGraySelectionOnly = new System.Windows.Forms.CheckBox();
         this._lblGrayEndColor = new System.Windows.Forms.Label();
         this._btnGrayEndColor = new System.Windows.Forms.Button();
         this._lblGrayStartColor = new System.Windows.Forms.Label();
         this._btnGrayStartColor = new System.Windows.Forms.Button();
         this._txtGrayWidth = new System.Windows.Forms.TextBox();
         this._lblGrayWidth = new System.Windows.Forms.Label();
         this._txtGrayCenter = new System.Windows.Forms.TextBox();
         this._lblGrayCenter = new System.Windows.Forms.Label();
         this._nudGrayFactor = new System.Windows.Forms.NumericUpDown();
         this._cbGrayFunctionType = new System.Windows.Forms.ComboBox();
         this._lblGrayFactor = new System.Windows.Forms.Label();
         this._lblGrayFunctionType = new System.Windows.Forms.Label();
         this._tpgNoiseFilter = new System.Windows.Forms.TabPage();
         this._chkNoiseApplyInProgress = new System.Windows.Forms.CheckBox();
         this._btnNoiseApplyLUT = new System.Windows.Forms.Button();
         this._grpNoiseSelInfo = new System.Windows.Forms.GroupBox();
         this._lblNoiseEndPtOccVal = new System.Windows.Forms.Label();
         this._lblNoiseEndPtOcc = new System.Windows.Forms.Label();
         this._lblNoiseEndPtClr = new System.Windows.Forms.Label();
         this._nudNoiseEndPt = new System.Windows.Forms.NumericUpDown();
         this._lblNoiseEndPt = new System.Windows.Forms.Label();
         this._lblNoiseStartPtOccVal = new System.Windows.Forms.Label();
         this._lblNoiseStartPtOcc = new System.Windows.Forms.Label();
         this._lblNoiseStartPtClr = new System.Windows.Forms.Label();
         this._nudNoiseStartPt = new System.Windows.Forms.NumericUpDown();
         this._lblNoiseStartPt = new System.Windows.Forms.Label();
         this._btnNoiseApplyBitmap = new System.Windows.Forms.Button();
         this._grpNoiseFilterInfo = new System.Windows.Forms.GroupBox();
         this._lblNoiseReplaceColor = new System.Windows.Forms.Label();
         this._btnNoiseReplaceColor = new System.Windows.Forms.Button();
         this._cbNoiseReplaceWith = new System.Windows.Forms.ComboBox();
         this._lblNoiseReplaceWith = new System.Windows.Forms.Label();
         this._tpgRescaling = new System.Windows.Forms.TabPage();
         this._chkResApplyInProgress = new System.Windows.Forms.CheckBox();
         this._btnResApplyLUT = new System.Windows.Forms.Button();
         this._grpResSelInfo = new System.Windows.Forms.GroupBox();
         this._lblResEndPtOccVal = new System.Windows.Forms.Label();
         this._lblResEndPtOcc = new System.Windows.Forms.Label();
         this._lblResEndPtClr = new System.Windows.Forms.Label();
         this._nudResEndPt = new System.Windows.Forms.NumericUpDown();
         this._lblResEndPt = new System.Windows.Forms.Label();
         this._lblResStartPtOccVal = new System.Windows.Forms.Label();
         this._lblResStartPtOcc = new System.Windows.Forms.Label();
         this._lblResStartPtClr = new System.Windows.Forms.Label();
         this._nudResStartPt = new System.Windows.Forms.NumericUpDown();
         this._lblResStartPt = new System.Windows.Forms.Label();
         this._btnResApplyBitmap = new System.Windows.Forms.Button();
         this._grpRescalingInfor = new System.Windows.Forms.GroupBox();
         this._rbResShiftLeft = new System.Windows.Forms.RadioButton();
         this._rbResShiftRight = new System.Windows.Forms.RadioButton();
         this._nudResNewEnd = new System.Windows.Forms.NumericUpDown();
         this._lblResNewEnd = new System.Windows.Forms.Label();
         this._nudResNewStart = new System.Windows.Forms.NumericUpDown();
         this._lblResNewStart = new System.Windows.Forms.Label();
         this._nudResShiftAmount = new System.Windows.Forms.NumericUpDown();
         this._lblResShiftAmount = new System.Windows.Forms.Label();
         this._rbResNewSE = new System.Windows.Forms.RadioButton();
         this._rbResShift = new System.Windows.Forms.RadioButton();
         this._grpStatisticalInformation = new System.Windows.Forms.GroupBox();
         this._grpMouse = new System.Windows.Forms.GroupBox();
         this.label1 = new System.Windows.Forms.Label();
         this._lblMouseLevel = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this._lblMousePercent = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this._lblMouseCount = new System.Windows.Forms.Label();
         this._lblStdDev = new System.Windows.Forms.Label();
         this._lblSelStdDev = new System.Windows.Forms.Label();
         this._lblMedian = new System.Windows.Forms.Label();
         this._lblSelMedian = new System.Windows.Forms.Label();
         this._lblMean = new System.Windows.Forms.Label();
         this._lblSelMean = new System.Windows.Forms.Label();
         this._lblLevel = new System.Windows.Forms.Label();
         this._lblSelLevel = new System.Windows.Forms.Label();
         this._lblPercent = new System.Windows.Forms.Label();
         this._lblSelPercent = new System.Windows.Forms.Label();
         this._lblCount = new System.Windows.Forms.Label();
         this._lblSelCount = new System.Windows.Forms.Label();
         this._grpSelectionColor = new System.Windows.Forms.GroupBox();
         this._lblOuter = new System.Windows.Forms.Label();
         this._btnOuter = new System.Windows.Forms.Button();
         this._lblInner = new System.Windows.Forms.Label();
         this._btnInner = new System.Windows.Forms.Button();
         this._cbChannel = new System.Windows.Forms.ComboBox();
         this._lblChannel = new System.Windows.Forms.Label();
         this._cbSelectionType = new System.Windows.Forms.ComboBox();
         this._lblSelectionType = new System.Windows.Forms.Label();
         this._MainProgressBar = new System.Windows.Forms.ProgressBar();
         this._btnOk = new System.Windows.Forms.Button();
         this._btnUndo = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this._cmRightClickOptions.SuspendLayout();
         this._grpView.SuspendLayout();
         this._tabOptions.SuspendLayout();
         this._tpgSegmentation.SuspendLayout();
         this._grpSegmentationInfo.SuspendLayout();
         this._grpSegSelInfo.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._nudSegEndPt)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._nudSegStartPt)).BeginInit();
         this._tpgGrayDistribution.SuspendLayout();
         this._grpGrySelInfo.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._nudGrayEndPt)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._nudGrayStartPt)).BeginInit();
         this._grpGrayDistributionInfo.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._nudGrayFactor)).BeginInit();
         this._tpgNoiseFilter.SuspendLayout();
         this._grpNoiseSelInfo.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._nudNoiseEndPt)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._nudNoiseStartPt)).BeginInit();
         this._grpNoiseFilterInfo.SuspendLayout();
         this._tpgRescaling.SuspendLayout();
         this._grpResSelInfo.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._nudResEndPt)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._nudResStartPt)).BeginInit();
         this._grpRescalingInfor.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._nudResNewEnd)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._nudResNewStart)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._nudResShiftAmount)).BeginInit();
         this._grpStatisticalInformation.SuspendLayout();
         this._grpMouse.SuspendLayout();
         this._grpSelectionColor.SuspendLayout();
         this.SuspendLayout();
         // 
         // _lblHistogram
         // 
         this._lblHistogram.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._lblHistogram.ContextMenuStrip = this._cmRightClickOptions;
         this._lblHistogram.Location = new System.Drawing.Point(9, 16);
         this._lblHistogram.Name = "_lblHistogram";
         this._lblHistogram.Size = new System.Drawing.Size(305, 210);
         this._lblHistogram.TabIndex = 0;
         this._lblHistogram.MouseLeave += new System.EventHandler(this._lblHistogram_MouseLeave);
         this._lblHistogram.MouseDown += new System.Windows.Forms.MouseEventHandler(this._lblHistogram_MouseDown);
         this._lblHistogram.MouseMove += new System.Windows.Forms.MouseEventHandler(this._lblHistogram_MouseMove);
         this._lblHistogram.Paint += new System.Windows.Forms.PaintEventHandler(this._lblHistogram_Paint);
         this._lblHistogram.MouseUp += new System.Windows.Forms.MouseEventHandler(this._lblHistogram_MouseUp);
         // 
         // _cmRightClickOptions
         // 
         this._cmRightClickOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._cmiZoomToSelection,
            this._cmiFitGraph,
            this._cmiFullRangeView});
         this._cmRightClickOptions.Name = "_cmRightClickOptions";
         this._cmRightClickOptions.Size = new System.Drawing.Size(159, 70);
         this._cmRightClickOptions.Opening += new System.ComponentModel.CancelEventHandler(this._cmRightClickOptions_Opening);
         // 
         // _cmiZoomToSelection
         // 
         this._cmiZoomToSelection.Name = "_cmiZoomToSelection";
         this._cmiZoomToSelection.Size = new System.Drawing.Size(158, 22);
         this._cmiZoomToSelection.Text = "Zoom to selection";
         this._cmiZoomToSelection.Click += new System.EventHandler(this._cmiZoomToSelection_Click);
         // 
         // _cmiFitGraph
         // 
         this._cmiFitGraph.Name = "_cmiFitGraph";
         this._cmiFitGraph.Size = new System.Drawing.Size(158, 22);
         this._cmiFitGraph.Text = "Fit Graph";
         this._cmiFitGraph.Click += new System.EventHandler(this._cmiFitGraph_Click);
         // 
         // _cmiFullRangeView
         // 
         this._cmiFullRangeView.Name = "_cmiFullRangeView";
         this._cmiFullRangeView.Size = new System.Drawing.Size(158, 22);
         this._cmiFullRangeView.Text = "Full Range View";
         this._cmiFullRangeView.Click += new System.EventHandler(this._cmiFullRangeView_Click);
         // 
         // _grpView
         // 
         this._grpView.Controls.Add(this._lblHelp);
         this._grpView.Controls.Add(this._btnShowHideOptions);
         this._grpView.Controls.Add(this._tabOptions);
         this._grpView.Controls.Add(this._grpStatisticalInformation);
         this._grpView.Controls.Add(this._grpSelectionColor);
         this._grpView.Controls.Add(this._cbChannel);
         this._grpView.Controls.Add(this._lblChannel);
         this._grpView.Controls.Add(this._lblHistogram);
         this._grpView.Controls.Add(this._cbSelectionType);
         this._grpView.Controls.Add(this._lblSelectionType);
         this._grpView.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._grpView.Location = new System.Drawing.Point(3, 0);
         this._grpView.Name = "_grpView";
         this._grpView.Size = new System.Drawing.Size(425, 528);
         this._grpView.TabIndex = 1;
         this._grpView.TabStop = false;
         this._grpView.Text = "Histogram View";
         // 
         // _lblHelp
         // 
         this._lblHelp.AutoSize = true;
         this._lblHelp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._lblHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._lblHelp.ForeColor = System.Drawing.Color.Red;
         this._lblHelp.Location = new System.Drawing.Point(35, 414);
         this._lblHelp.Name = "_lblHelp";
         this._lblHelp.Size = new System.Drawing.Size(354, 15);
         this._lblHelp.TabIndex = 11;
         this._lblHelp.Text = "Left click selects the Start point, SHIFT + Left click selects the End point.";
         this._lblHelp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // _btnShowHideOptions
         // 
         this._btnShowHideOptions.Location = new System.Drawing.Point(321, 217);
         this._btnShowHideOptions.Name = "_btnShowHideOptions";
         this._btnShowHideOptions.Size = new System.Drawing.Size(96, 23);
         this._btnShowHideOptions.TabIndex = 6;
         this._btnShowHideOptions.Text = "Hide Options <<";
         this._btnShowHideOptions.UseVisualStyleBackColor = true;
         this._btnShowHideOptions.Click += new System.EventHandler(this._btnShowHideOptions_Click);
         // 
         // _tabOptions
         // 
         this._tabOptions.Controls.Add(this._tpgSegmentation);
         this._tabOptions.Controls.Add(this._tpgGrayDistribution);
         this._tabOptions.Controls.Add(this._tpgNoiseFilter);
         this._tabOptions.Controls.Add(this._tpgRescaling);
         this._tabOptions.Location = new System.Drawing.Point(6, 233);
         this._tabOptions.Name = "_tabOptions";
         this._tabOptions.SelectedIndex = 0;
         this._tabOptions.Size = new System.Drawing.Size(409, 176);
         this._tabOptions.TabIndex = 5;
         this._tabOptions.SelectedIndexChanged += new System.EventHandler(this._tabOptions_SelectedIndexChanged);
         // 
         // _tpgSegmentation
         // 
         this._tpgSegmentation.Controls.Add(this._chkSegApplyInProgress);
         this._tpgSegmentation.Controls.Add(this._btnSegApplyLUT);
         this._tpgSegmentation.Controls.Add(this._grpSegmentationInfo);
         this._tpgSegmentation.Controls.Add(this._btnSegApply);
         this._tpgSegmentation.Controls.Add(this._grpSegSelInfo);
         this._tpgSegmentation.Location = new System.Drawing.Point(4, 22);
         this._tpgSegmentation.Name = "_tpgSegmentation";
         this._tpgSegmentation.Padding = new System.Windows.Forms.Padding(3);
         this._tpgSegmentation.Size = new System.Drawing.Size(401, 150);
         this._tpgSegmentation.TabIndex = 0;
         this._tpgSegmentation.Text = "Segmentation";
         this._tpgSegmentation.UseVisualStyleBackColor = true;
         // 
         // _chkSegApplyInProgress
         // 
         this._chkSegApplyInProgress.AutoSize = true;
         this._chkSegApplyInProgress.Location = new System.Drawing.Point(12, 129);
         this._chkSegApplyInProgress.Name = "_chkSegApplyInProgress";
         this._chkSegApplyInProgress.Size = new System.Drawing.Size(94, 17);
         this._chkSegApplyInProgress.TabIndex = 10;
         this._chkSegApplyInProgress.Text = "Show Preview";
         this._chkSegApplyInProgress.UseVisualStyleBackColor = true;
         this._chkSegApplyInProgress.CheckedChanged += new System.EventHandler(this._chkApplyInProgress_CheckedChanged);
         // 
         // _btnSegApplyLUT
         // 
         this._btnSegApplyLUT.Location = new System.Drawing.Point(11, 103);
         this._btnSegApplyLUT.Name = "_btnSegApplyLUT";
         this._btnSegApplyLUT.Size = new System.Drawing.Size(73, 23);
         this._btnSegApplyLUT.TabIndex = 9;
         this._btnSegApplyLUT.Text = "LUT";
         this._btnSegApplyLUT.UseVisualStyleBackColor = true;
         this._btnSegApplyLUT.Click += new System.EventHandler(this._btnApplyLUT_Click);
         // 
         // _grpSegmentationInfo
         // 
         this._grpSegmentationInfo.Controls.Add(this._rbSegThreshold);
         this._grpSegmentationInfo.Controls.Add(this._rbSegGradient);
         this._grpSegmentationInfo.Controls.Add(this._lblSegEndColor);
         this._grpSegmentationInfo.Controls.Add(this._btnSegEndColor);
         this._grpSegmentationInfo.Controls.Add(this._lblSegStartColor);
         this._grpSegmentationInfo.Controls.Add(this._btnSegStartColor);
         this._grpSegmentationInfo.Location = new System.Drawing.Point(168, 0);
         this._grpSegmentationInfo.Name = "_grpSegmentationInfo";
         this._grpSegmentationInfo.Size = new System.Drawing.Size(177, 101);
         this._grpSegmentationInfo.TabIndex = 6;
         this._grpSegmentationInfo.TabStop = false;
         this._grpSegmentationInfo.Text = "Segmentation Information";
         // 
         // _rbSegThreshold
         // 
         this._rbSegThreshold.AutoSize = true;
         this._rbSegThreshold.Location = new System.Drawing.Point(95, 78);
         this._rbSegThreshold.Name = "_rbSegThreshold";
         this._rbSegThreshold.Size = new System.Drawing.Size(72, 17);
         this._rbSegThreshold.TabIndex = 9;
         this._rbSegThreshold.TabStop = true;
         this._rbSegThreshold.Text = "Threshold";
         this._rbSegThreshold.UseVisualStyleBackColor = true;
         this._rbSegThreshold.CheckedChanged += new System.EventHandler(this._rbSegThreshold_CheckedChanged);
         // 
         // _rbSegGradient
         // 
         this._rbSegGradient.AutoSize = true;
         this._rbSegGradient.Location = new System.Drawing.Point(7, 78);
         this._rbSegGradient.Name = "_rbSegGradient";
         this._rbSegGradient.Size = new System.Drawing.Size(65, 17);
         this._rbSegGradient.TabIndex = 8;
         this._rbSegGradient.TabStop = true;
         this._rbSegGradient.Text = "Gradient";
         this._rbSegGradient.UseVisualStyleBackColor = true;
         this._rbSegGradient.CheckedChanged += new System.EventHandler(this._rbSegGradient_CheckedChanged);
         // 
         // _lblSegEndColor
         // 
         this._lblSegEndColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._lblSegEndColor.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblSegEndColor.Location = new System.Drawing.Point(95, 47);
         this._lblSegEndColor.Name = "_lblSegEndColor";
         this._lblSegEndColor.Size = new System.Drawing.Size(75, 23);
         this._lblSegEndColor.TabIndex = 7;
         // 
         // _btnSegEndColor
         // 
         this._btnSegEndColor.Location = new System.Drawing.Point(7, 47);
         this._btnSegEndColor.Name = "_btnSegEndColor";
         this._btnSegEndColor.Size = new System.Drawing.Size(75, 23);
         this._btnSegEndColor.TabIndex = 6;
         this._btnSegEndColor.Text = "&End Color";
         this._btnSegEndColor.UseVisualStyleBackColor = true;
         this._btnSegEndColor.Click += new System.EventHandler(this._btnSegEndColor_Click);
         // 
         // _lblSegStartColor
         // 
         this._lblSegStartColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._lblSegStartColor.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblSegStartColor.Location = new System.Drawing.Point(95, 19);
         this._lblSegStartColor.Name = "_lblSegStartColor";
         this._lblSegStartColor.Size = new System.Drawing.Size(75, 23);
         this._lblSegStartColor.TabIndex = 5;
         // 
         // _btnSegStartColor
         // 
         this._btnSegStartColor.Location = new System.Drawing.Point(7, 19);
         this._btnSegStartColor.Name = "_btnSegStartColor";
         this._btnSegStartColor.Size = new System.Drawing.Size(75, 23);
         this._btnSegStartColor.TabIndex = 4;
         this._btnSegStartColor.Text = "&Start Color";
         this._btnSegStartColor.UseVisualStyleBackColor = true;
         this._btnSegStartColor.Click += new System.EventHandler(this._btnSegStartColor_Click);
         // 
         // _btnSegApply
         // 
         this._btnSegApply.Location = new System.Drawing.Point(90, 103);
         this._btnSegApply.Name = "_btnSegApply";
         this._btnSegApply.Size = new System.Drawing.Size(73, 23);
         this._btnSegApply.TabIndex = 5;
         this._btnSegApply.Text = "Bitmap Data";
         this._btnSegApply.UseVisualStyleBackColor = true;
         this._btnSegApply.Click += new System.EventHandler(this._btnApplyToBitmap_Click);
         // 
         // _grpSegSelInfo
         // 
         this._grpSegSelInfo.Controls.Add(this._lblSegEndPtOccVal);
         this._grpSegSelInfo.Controls.Add(this._lblSegEndPtOcc);
         this._grpSegSelInfo.Controls.Add(this._lblSegEndPtClr);
         this._grpSegSelInfo.Controls.Add(this._nudSegEndPt);
         this._grpSegSelInfo.Controls.Add(this._lblSegEndPt);
         this._grpSegSelInfo.Controls.Add(this._lblSegStartPtOccVal);
         this._grpSegSelInfo.Controls.Add(this._lblSegStartPtOcc);
         this._grpSegSelInfo.Controls.Add(this._lblSegStartPtClr);
         this._grpSegSelInfo.Controls.Add(this._nudSegStartPt);
         this._grpSegSelInfo.Controls.Add(this._lblSegStartPt);
         this._grpSegSelInfo.Location = new System.Drawing.Point(0, 0);
         this._grpSegSelInfo.Name = "_grpSegSelInfo";
         this._grpSegSelInfo.Size = new System.Drawing.Size(164, 101);
         this._grpSegSelInfo.TabIndex = 0;
         this._grpSegSelInfo.TabStop = false;
         this._grpSegSelInfo.Text = "Selection Information";
         // 
         // _lblSegEndPtOccVal
         // 
         this._lblSegEndPtOccVal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._lblSegEndPtOccVal.Location = new System.Drawing.Point(97, 72);
         this._lblSegEndPtOccVal.Name = "_lblSegEndPtOccVal";
         this._lblSegEndPtOccVal.Size = new System.Drawing.Size(57, 20);
         this._lblSegEndPtOccVal.TabIndex = 29;
         // 
         // _lblSegEndPtOcc
         // 
         this._lblSegEndPtOcc.AutoSize = true;
         this._lblSegEndPtOcc.Location = new System.Drawing.Point(96, 57);
         this._lblSegEndPtOcc.Name = "_lblSegEndPtOcc";
         this._lblSegEndPtOcc.Size = new System.Drawing.Size(63, 13);
         this._lblSegEndPtOcc.TabIndex = 28;
         this._lblSegEndPtOcc.Text = "Occurrence";
         // 
         // _lblSegEndPtClr
         // 
         this._lblSegEndPtClr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._lblSegEndPtClr.Location = new System.Drawing.Point(71, 72);
         this._lblSegEndPtClr.Name = "_lblSegEndPtClr";
         this._lblSegEndPtClr.Size = new System.Drawing.Size(21, 20);
         this._lblSegEndPtClr.TabIndex = 27;
         // 
         // _nudSegEndPt
         // 
         this._nudSegEndPt.Location = new System.Drawing.Point(7, 72);
         this._nudSegEndPt.Name = "_nudSegEndPt";
         this._nudSegEndPt.Size = new System.Drawing.Size(58, 20);
         this._nudSegEndPt.TabIndex = 26;
         this._nudSegEndPt.ValueChanged += new System.EventHandler(this._nudEndPt_ValueChanged);
         // 
         // _lblSegEndPt
         // 
         this._lblSegEndPt.AutoSize = true;
         this._lblSegEndPt.Location = new System.Drawing.Point(12, 57);
         this._lblSegEndPt.Name = "_lblSegEndPt";
         this._lblSegEndPt.Size = new System.Drawing.Size(53, 13);
         this._lblSegEndPt.TabIndex = 25;
         this._lblSegEndPt.Text = "&End Point";
         // 
         // _lblSegStartPtOccVal
         // 
         this._lblSegStartPtOccVal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._lblSegStartPtOccVal.Location = new System.Drawing.Point(97, 31);
         this._lblSegStartPtOccVal.Name = "_lblSegStartPtOccVal";
         this._lblSegStartPtOccVal.Size = new System.Drawing.Size(57, 20);
         this._lblSegStartPtOccVal.TabIndex = 24;
         // 
         // _lblSegStartPtOcc
         // 
         this._lblSegStartPtOcc.AutoSize = true;
         this._lblSegStartPtOcc.Location = new System.Drawing.Point(95, 15);
         this._lblSegStartPtOcc.Name = "_lblSegStartPtOcc";
         this._lblSegStartPtOcc.Size = new System.Drawing.Size(63, 13);
         this._lblSegStartPtOcc.TabIndex = 23;
         this._lblSegStartPtOcc.Text = "Occurrence";
         // 
         // _lblSegStartPtClr
         // 
         this._lblSegStartPtClr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._lblSegStartPtClr.Location = new System.Drawing.Point(71, 31);
         this._lblSegStartPtClr.Name = "_lblSegStartPtClr";
         this._lblSegStartPtClr.Size = new System.Drawing.Size(21, 20);
         this._lblSegStartPtClr.TabIndex = 22;
         // 
         // _nudSegStartPt
         // 
         this._nudSegStartPt.Location = new System.Drawing.Point(7, 30);
         this._nudSegStartPt.Name = "_nudSegStartPt";
         this._nudSegStartPt.Size = new System.Drawing.Size(58, 20);
         this._nudSegStartPt.TabIndex = 1;
         this._nudSegStartPt.ValueChanged += new System.EventHandler(this._nudStartPt_ValueChanged);
         // 
         // _lblSegStartPt
         // 
         this._lblSegStartPt.AutoSize = true;
         this._lblSegStartPt.Location = new System.Drawing.Point(11, 15);
         this._lblSegStartPt.Name = "_lblSegStartPt";
         this._lblSegStartPt.Size = new System.Drawing.Size(56, 13);
         this._lblSegStartPt.TabIndex = 0;
         this._lblSegStartPt.Text = "&Start Point";
         // 
         // _tpgGrayDistribution
         // 
         this._tpgGrayDistribution.Controls.Add(this._chkGrayApplyInProgress);
         this._tpgGrayDistribution.Controls.Add(this._btnGrayApplyLUT);
         this._tpgGrayDistribution.Controls.Add(this._grpGrySelInfo);
         this._tpgGrayDistribution.Controls.Add(this._btnGrayApplyToBitmap);
         this._tpgGrayDistribution.Controls.Add(this._grpGrayDistributionInfo);
         this._tpgGrayDistribution.Location = new System.Drawing.Point(4, 22);
         this._tpgGrayDistribution.Name = "_tpgGrayDistribution";
         this._tpgGrayDistribution.Padding = new System.Windows.Forms.Padding(3);
         this._tpgGrayDistribution.Size = new System.Drawing.Size(401, 150);
         this._tpgGrayDistribution.TabIndex = 1;
         this._tpgGrayDistribution.Text = "Gray Distribution";
         this._tpgGrayDistribution.UseVisualStyleBackColor = true;
         // 
         // _chkGrayApplyInProgress
         // 
         this._chkGrayApplyInProgress.AutoSize = true;
         this._chkGrayApplyInProgress.Location = new System.Drawing.Point(12, 129);
         this._chkGrayApplyInProgress.Name = "_chkGrayApplyInProgress";
         this._chkGrayApplyInProgress.Size = new System.Drawing.Size(94, 17);
         this._chkGrayApplyInProgress.TabIndex = 11;
         this._chkGrayApplyInProgress.Text = "Show Preview";
         this._chkGrayApplyInProgress.UseVisualStyleBackColor = true;
         this._chkGrayApplyInProgress.CheckedChanged += new System.EventHandler(this._chkApplyInProgress_CheckedChanged);
         // 
         // _btnGrayApplyLUT
         // 
         this._btnGrayApplyLUT.Location = new System.Drawing.Point(11, 103);
         this._btnGrayApplyLUT.Name = "_btnGrayApplyLUT";
         this._btnGrayApplyLUT.Size = new System.Drawing.Size(73, 23);
         this._btnGrayApplyLUT.TabIndex = 8;
         this._btnGrayApplyLUT.Text = "LUT";
         this._btnGrayApplyLUT.UseVisualStyleBackColor = true;
         this._btnGrayApplyLUT.Click += new System.EventHandler(this._btnApplyLUT_Click);
         // 
         // _grpGrySelInfo
         // 
         this._grpGrySelInfo.Controls.Add(this._lblGryEndPtOccVal);
         this._grpGrySelInfo.Controls.Add(this._lblGryEndPtOcc);
         this._grpGrySelInfo.Controls.Add(this._lblGrayEndPtClr);
         this._grpGrySelInfo.Controls.Add(this._nudGrayEndPt);
         this._grpGrySelInfo.Controls.Add(this._lblGryEndPt);
         this._grpGrySelInfo.Controls.Add(this._lblGryStartPtOccVal);
         this._grpGrySelInfo.Controls.Add(this._lblGryStartPtOcc);
         this._grpGrySelInfo.Controls.Add(this._lblGrayStartPtClr);
         this._grpGrySelInfo.Controls.Add(this._nudGrayStartPt);
         this._grpGrySelInfo.Controls.Add(this._lblGryStartPt);
         this._grpGrySelInfo.Location = new System.Drawing.Point(0, 0);
         this._grpGrySelInfo.Name = "_grpGrySelInfo";
         this._grpGrySelInfo.Size = new System.Drawing.Size(164, 101);
         this._grpGrySelInfo.TabIndex = 7;
         this._grpGrySelInfo.TabStop = false;
         this._grpGrySelInfo.Text = "Selection Information";
         // 
         // _lblGryEndPtOccVal
         // 
         this._lblGryEndPtOccVal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._lblGryEndPtOccVal.Location = new System.Drawing.Point(97, 73);
         this._lblGryEndPtOccVal.Name = "_lblGryEndPtOccVal";
         this._lblGryEndPtOccVal.Size = new System.Drawing.Size(57, 20);
         this._lblGryEndPtOccVal.TabIndex = 29;
         // 
         // _lblGryEndPtOcc
         // 
         this._lblGryEndPtOcc.AutoSize = true;
         this._lblGryEndPtOcc.Location = new System.Drawing.Point(96, 57);
         this._lblGryEndPtOcc.Name = "_lblGryEndPtOcc";
         this._lblGryEndPtOcc.Size = new System.Drawing.Size(63, 13);
         this._lblGryEndPtOcc.TabIndex = 28;
         this._lblGryEndPtOcc.Text = "Occurrence";
         // 
         // _lblGrayEndPtClr
         // 
         this._lblGrayEndPtClr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._lblGrayEndPtClr.Location = new System.Drawing.Point(71, 73);
         this._lblGrayEndPtClr.Name = "_lblGrayEndPtClr";
         this._lblGrayEndPtClr.Size = new System.Drawing.Size(21, 20);
         this._lblGrayEndPtClr.TabIndex = 27;
         // 
         // _nudGrayEndPt
         // 
         this._nudGrayEndPt.Location = new System.Drawing.Point(7, 72);
         this._nudGrayEndPt.Name = "_nudGrayEndPt";
         this._nudGrayEndPt.Size = new System.Drawing.Size(58, 20);
         this._nudGrayEndPt.TabIndex = 26;
         this._nudGrayEndPt.ValueChanged += new System.EventHandler(this._nudEndPt_ValueChanged);
         // 
         // _lblGryEndPt
         // 
         this._lblGryEndPt.AutoSize = true;
         this._lblGryEndPt.Location = new System.Drawing.Point(12, 57);
         this._lblGryEndPt.Name = "_lblGryEndPt";
         this._lblGryEndPt.Size = new System.Drawing.Size(53, 13);
         this._lblGryEndPt.TabIndex = 25;
         this._lblGryEndPt.Text = "&End Point";
         // 
         // _lblGryStartPtOccVal
         // 
         this._lblGryStartPtOccVal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._lblGryStartPtOccVal.Location = new System.Drawing.Point(97, 30);
         this._lblGryStartPtOccVal.Name = "_lblGryStartPtOccVal";
         this._lblGryStartPtOccVal.Size = new System.Drawing.Size(57, 20);
         this._lblGryStartPtOccVal.TabIndex = 24;
         // 
         // _lblGryStartPtOcc
         // 
         this._lblGryStartPtOcc.AutoSize = true;
         this._lblGryStartPtOcc.Location = new System.Drawing.Point(95, 15);
         this._lblGryStartPtOcc.Name = "_lblGryStartPtOcc";
         this._lblGryStartPtOcc.Size = new System.Drawing.Size(63, 13);
         this._lblGryStartPtOcc.TabIndex = 23;
         this._lblGryStartPtOcc.Text = "Occurrence";
         // 
         // _lblGrayStartPtClr
         // 
         this._lblGrayStartPtClr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._lblGrayStartPtClr.Location = new System.Drawing.Point(71, 30);
         this._lblGrayStartPtClr.Name = "_lblGrayStartPtClr";
         this._lblGrayStartPtClr.Size = new System.Drawing.Size(21, 20);
         this._lblGrayStartPtClr.TabIndex = 22;
         // 
         // _nudGrayStartPt
         // 
         this._nudGrayStartPt.Location = new System.Drawing.Point(7, 30);
         this._nudGrayStartPt.Name = "_nudGrayStartPt";
         this._nudGrayStartPt.Size = new System.Drawing.Size(58, 20);
         this._nudGrayStartPt.TabIndex = 1;
         this._nudGrayStartPt.ValueChanged += new System.EventHandler(this._nudStartPt_ValueChanged);
         // 
         // _lblGryStartPt
         // 
         this._lblGryStartPt.AutoSize = true;
         this._lblGryStartPt.Location = new System.Drawing.Point(11, 15);
         this._lblGryStartPt.Name = "_lblGryStartPt";
         this._lblGryStartPt.Size = new System.Drawing.Size(56, 13);
         this._lblGryStartPt.TabIndex = 0;
         this._lblGryStartPt.Text = "&Start Point";
         // 
         // _btnGrayApplyToBitmap
         // 
         this._btnGrayApplyToBitmap.Location = new System.Drawing.Point(90, 103);
         this._btnGrayApplyToBitmap.Name = "_btnGrayApplyToBitmap";
         this._btnGrayApplyToBitmap.Size = new System.Drawing.Size(73, 23);
         this._btnGrayApplyToBitmap.TabIndex = 6;
         this._btnGrayApplyToBitmap.Text = "Bitmap Data";
         this._btnGrayApplyToBitmap.UseVisualStyleBackColor = true;
         this._btnGrayApplyToBitmap.Click += new System.EventHandler(this._btnApplyToBitmap_Click);
         // 
         // _grpGrayDistributionInfo
         // 
         this._grpGrayDistributionInfo.Controls.Add(this._cbGraySelectionOnly);
         this._grpGrayDistributionInfo.Controls.Add(this._lblGrayEndColor);
         this._grpGrayDistributionInfo.Controls.Add(this._btnGrayEndColor);
         this._grpGrayDistributionInfo.Controls.Add(this._lblGrayStartColor);
         this._grpGrayDistributionInfo.Controls.Add(this._btnGrayStartColor);
         this._grpGrayDistributionInfo.Controls.Add(this._txtGrayWidth);
         this._grpGrayDistributionInfo.Controls.Add(this._lblGrayWidth);
         this._grpGrayDistributionInfo.Controls.Add(this._txtGrayCenter);
         this._grpGrayDistributionInfo.Controls.Add(this._lblGrayCenter);
         this._grpGrayDistributionInfo.Controls.Add(this._nudGrayFactor);
         this._grpGrayDistributionInfo.Controls.Add(this._cbGrayFunctionType);
         this._grpGrayDistributionInfo.Controls.Add(this._lblGrayFactor);
         this._grpGrayDistributionInfo.Controls.Add(this._lblGrayFunctionType);
         this._grpGrayDistributionInfo.Location = new System.Drawing.Point(168, 0);
         this._grpGrayDistributionInfo.Name = "_grpGrayDistributionInfo";
         this._grpGrayDistributionInfo.Size = new System.Drawing.Size(230, 101);
         this._grpGrayDistributionInfo.TabIndex = 2;
         this._grpGrayDistributionInfo.TabStop = false;
         this._grpGrayDistributionInfo.Text = "Gray Distribution Information";
         // 
         // _cbGraySelectionOnly
         // 
         this._cbGraySelectionOnly.AutoSize = true;
         this._cbGraySelectionOnly.Location = new System.Drawing.Point(5, 51);
         this._cbGraySelectionOnly.Name = "_cbGraySelectionOnly";
         this._cbGraySelectionOnly.Size = new System.Drawing.Size(94, 17);
         this._cbGraySelectionOnly.TabIndex = 11;
         this._cbGraySelectionOnly.Text = "Selection Only";
         this._cbGraySelectionOnly.UseVisualStyleBackColor = true;
         this._cbGraySelectionOnly.CheckedChanged += new System.EventHandler(this._cbGraySelectionOnly_CheckedChanged);
         // 
         // _lblGrayEndColor
         // 
         this._lblGrayEndColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._lblGrayEndColor.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblGrayEndColor.Location = new System.Drawing.Point(181, 71);
         this._lblGrayEndColor.Name = "_lblGrayEndColor";
         this._lblGrayEndColor.Size = new System.Drawing.Size(37, 20);
         this._lblGrayEndColor.TabIndex = 10;
         // 
         // _btnGrayEndColor
         // 
         this._btnGrayEndColor.Location = new System.Drawing.Point(113, 69);
         this._btnGrayEndColor.Name = "_btnGrayEndColor";
         this._btnGrayEndColor.Size = new System.Drawing.Size(64, 23);
         this._btnGrayEndColor.TabIndex = 9;
         this._btnGrayEndColor.Text = "&End Color";
         this._btnGrayEndColor.UseVisualStyleBackColor = true;
         this._btnGrayEndColor.Click += new System.EventHandler(this._btnGrayEndColor_Click);
         // 
         // _lblGrayStartColor
         // 
         this._lblGrayStartColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._lblGrayStartColor.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblGrayStartColor.Location = new System.Drawing.Point(72, 71);
         this._lblGrayStartColor.Name = "_lblGrayStartColor";
         this._lblGrayStartColor.Size = new System.Drawing.Size(37, 20);
         this._lblGrayStartColor.TabIndex = 8;
         // 
         // _btnGrayStartColor
         // 
         this._btnGrayStartColor.Location = new System.Drawing.Point(5, 69);
         this._btnGrayStartColor.Name = "_btnGrayStartColor";
         this._btnGrayStartColor.Size = new System.Drawing.Size(64, 23);
         this._btnGrayStartColor.TabIndex = 7;
         this._btnGrayStartColor.Text = "&Start Color";
         this._btnGrayStartColor.UseVisualStyleBackColor = true;
         this._btnGrayStartColor.Click += new System.EventHandler(this._btnGrayStartColor_Click);
         // 
         // _txtGrayWidth
         // 
         this._txtGrayWidth.Location = new System.Drawing.Point(179, 37);
         this._txtGrayWidth.Name = "_txtGrayWidth";
         this._txtGrayWidth.ReadOnly = true;
         this._txtGrayWidth.Size = new System.Drawing.Size(45, 20);
         this._txtGrayWidth.TabIndex = 5;
         // 
         // _lblGrayWidth
         // 
         this._lblGrayWidth.AutoSize = true;
         this._lblGrayWidth.Location = new System.Drawing.Point(143, 39);
         this._lblGrayWidth.Name = "_lblGrayWidth";
         this._lblGrayWidth.Size = new System.Drawing.Size(35, 13);
         this._lblGrayWidth.TabIndex = 6;
         this._lblGrayWidth.Text = "Width";
         // 
         // _txtGrayCenter
         // 
         this._txtGrayCenter.Location = new System.Drawing.Point(179, 14);
         this._txtGrayCenter.Name = "_txtGrayCenter";
         this._txtGrayCenter.ReadOnly = true;
         this._txtGrayCenter.Size = new System.Drawing.Size(45, 20);
         this._txtGrayCenter.TabIndex = 0;
         // 
         // _lblGrayCenter
         // 
         this._lblGrayCenter.AutoSize = true;
         this._lblGrayCenter.Location = new System.Drawing.Point(140, 15);
         this._lblGrayCenter.Name = "_lblGrayCenter";
         this._lblGrayCenter.Size = new System.Drawing.Size(38, 13);
         this._lblGrayCenter.TabIndex = 4;
         this._lblGrayCenter.Text = "Center";
         // 
         // _nudGrayFactor
         // 
         this._nudGrayFactor.Location = new System.Drawing.Point(94, 28);
         this._nudGrayFactor.Name = "_nudGrayFactor";
         this._nudGrayFactor.Size = new System.Drawing.Size(49, 20);
         this._nudGrayFactor.TabIndex = 3;
         this._nudGrayFactor.ValueChanged += new System.EventHandler(this._nudGrayFactor_ValueChanged);
         // 
         // _cbGrayFunctionType
         // 
         this._cbGrayFunctionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cbGrayFunctionType.FormattingEnabled = true;
         this._cbGrayFunctionType.Items.AddRange(new object[] {
            "Exponential",
            "Log",
            "Linear",
            "Sigmoid"});
         this._cbGrayFunctionType.Location = new System.Drawing.Point(6, 28);
         this._cbGrayFunctionType.Name = "_cbGrayFunctionType";
         this._cbGrayFunctionType.Size = new System.Drawing.Size(85, 21);
         this._cbGrayFunctionType.TabIndex = 2;
         this._cbGrayFunctionType.SelectedIndexChanged += new System.EventHandler(this._cbGrayFunctionType_SelectedIndexChanged);
         // 
         // _lblGrayFactor
         // 
         this._lblGrayFactor.AutoSize = true;
         this._lblGrayFactor.Location = new System.Drawing.Point(94, 15);
         this._lblGrayFactor.Name = "_lblGrayFactor";
         this._lblGrayFactor.Size = new System.Drawing.Size(37, 13);
         this._lblGrayFactor.TabIndex = 1;
         this._lblGrayFactor.Text = "Factor";
         // 
         // _lblGrayFunctionType
         // 
         this._lblGrayFunctionType.AutoSize = true;
         this._lblGrayFunctionType.Location = new System.Drawing.Point(3, 15);
         this._lblGrayFunctionType.Name = "_lblGrayFunctionType";
         this._lblGrayFunctionType.Size = new System.Drawing.Size(75, 13);
         this._lblGrayFunctionType.TabIndex = 0;
         this._lblGrayFunctionType.Text = "Function Type";
         // 
         // _tpgNoiseFilter
         // 
         this._tpgNoiseFilter.Controls.Add(this._chkNoiseApplyInProgress);
         this._tpgNoiseFilter.Controls.Add(this._btnNoiseApplyLUT);
         this._tpgNoiseFilter.Controls.Add(this._grpNoiseSelInfo);
         this._tpgNoiseFilter.Controls.Add(this._btnNoiseApplyBitmap);
         this._tpgNoiseFilter.Controls.Add(this._grpNoiseFilterInfo);
         this._tpgNoiseFilter.Location = new System.Drawing.Point(4, 22);
         this._tpgNoiseFilter.Name = "_tpgNoiseFilter";
         this._tpgNoiseFilter.Padding = new System.Windows.Forms.Padding(3);
         this._tpgNoiseFilter.Size = new System.Drawing.Size(401, 150);
         this._tpgNoiseFilter.TabIndex = 2;
         this._tpgNoiseFilter.Text = "Noise Filter";
         this._tpgNoiseFilter.UseVisualStyleBackColor = true;
         // 
         // _chkNoiseApplyInProgress
         // 
         this._chkNoiseApplyInProgress.AutoSize = true;
         this._chkNoiseApplyInProgress.Location = new System.Drawing.Point(12, 129);
         this._chkNoiseApplyInProgress.Name = "_chkNoiseApplyInProgress";
         this._chkNoiseApplyInProgress.Size = new System.Drawing.Size(94, 17);
         this._chkNoiseApplyInProgress.TabIndex = 11;
         this._chkNoiseApplyInProgress.Text = "Show Preview";
         this._chkNoiseApplyInProgress.UseVisualStyleBackColor = true;
         this._chkNoiseApplyInProgress.CheckedChanged += new System.EventHandler(this._chkApplyInProgress_CheckedChanged);
         // 
         // _btnNoiseApplyLUT
         // 
         this._btnNoiseApplyLUT.Location = new System.Drawing.Point(11, 103);
         this._btnNoiseApplyLUT.Name = "_btnNoiseApplyLUT";
         this._btnNoiseApplyLUT.Size = new System.Drawing.Size(73, 23);
         this._btnNoiseApplyLUT.TabIndex = 9;
         this._btnNoiseApplyLUT.Text = "LUT";
         this._btnNoiseApplyLUT.UseVisualStyleBackColor = true;
         this._btnNoiseApplyLUT.Click += new System.EventHandler(this._btnApplyLUT_Click);
         // 
         // _grpNoiseSelInfo
         // 
         this._grpNoiseSelInfo.Controls.Add(this._lblNoiseEndPtOccVal);
         this._grpNoiseSelInfo.Controls.Add(this._lblNoiseEndPtOcc);
         this._grpNoiseSelInfo.Controls.Add(this._lblNoiseEndPtClr);
         this._grpNoiseSelInfo.Controls.Add(this._nudNoiseEndPt);
         this._grpNoiseSelInfo.Controls.Add(this._lblNoiseEndPt);
         this._grpNoiseSelInfo.Controls.Add(this._lblNoiseStartPtOccVal);
         this._grpNoiseSelInfo.Controls.Add(this._lblNoiseStartPtOcc);
         this._grpNoiseSelInfo.Controls.Add(this._lblNoiseStartPtClr);
         this._grpNoiseSelInfo.Controls.Add(this._nudNoiseStartPt);
         this._grpNoiseSelInfo.Controls.Add(this._lblNoiseStartPt);
         this._grpNoiseSelInfo.Location = new System.Drawing.Point(0, 0);
         this._grpNoiseSelInfo.Name = "_grpNoiseSelInfo";
         this._grpNoiseSelInfo.Size = new System.Drawing.Size(164, 101);
         this._grpNoiseSelInfo.TabIndex = 7;
         this._grpNoiseSelInfo.TabStop = false;
         this._grpNoiseSelInfo.Text = "Selection Information";
         // 
         // _lblNoiseEndPtOccVal
         // 
         this._lblNoiseEndPtOccVal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._lblNoiseEndPtOccVal.Location = new System.Drawing.Point(97, 72);
         this._lblNoiseEndPtOccVal.Name = "_lblNoiseEndPtOccVal";
         this._lblNoiseEndPtOccVal.Size = new System.Drawing.Size(57, 20);
         this._lblNoiseEndPtOccVal.TabIndex = 29;
         // 
         // _lblNoiseEndPtOcc
         // 
         this._lblNoiseEndPtOcc.AutoSize = true;
         this._lblNoiseEndPtOcc.Location = new System.Drawing.Point(96, 57);
         this._lblNoiseEndPtOcc.Name = "_lblNoiseEndPtOcc";
         this._lblNoiseEndPtOcc.Size = new System.Drawing.Size(63, 13);
         this._lblNoiseEndPtOcc.TabIndex = 28;
         this._lblNoiseEndPtOcc.Text = "Occurrence";
         // 
         // _lblNoiseEndPtClr
         // 
         this._lblNoiseEndPtClr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._lblNoiseEndPtClr.Location = new System.Drawing.Point(71, 73);
         this._lblNoiseEndPtClr.Name = "_lblNoiseEndPtClr";
         this._lblNoiseEndPtClr.Size = new System.Drawing.Size(21, 20);
         this._lblNoiseEndPtClr.TabIndex = 27;
         // 
         // _nudNoiseEndPt
         // 
         this._nudNoiseEndPt.Location = new System.Drawing.Point(7, 72);
         this._nudNoiseEndPt.Name = "_nudNoiseEndPt";
         this._nudNoiseEndPt.Size = new System.Drawing.Size(58, 20);
         this._nudNoiseEndPt.TabIndex = 26;
         this._nudNoiseEndPt.ValueChanged += new System.EventHandler(this._nudEndPt_ValueChanged);
         // 
         // _lblNoiseEndPt
         // 
         this._lblNoiseEndPt.AutoSize = true;
         this._lblNoiseEndPt.Location = new System.Drawing.Point(12, 57);
         this._lblNoiseEndPt.Name = "_lblNoiseEndPt";
         this._lblNoiseEndPt.Size = new System.Drawing.Size(53, 13);
         this._lblNoiseEndPt.TabIndex = 25;
         this._lblNoiseEndPt.Text = "&End Point";
         // 
         // _lblNoiseStartPtOccVal
         // 
         this._lblNoiseStartPtOccVal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._lblNoiseStartPtOccVal.Location = new System.Drawing.Point(97, 30);
         this._lblNoiseStartPtOccVal.Name = "_lblNoiseStartPtOccVal";
         this._lblNoiseStartPtOccVal.Size = new System.Drawing.Size(57, 20);
         this._lblNoiseStartPtOccVal.TabIndex = 24;
         // 
         // _lblNoiseStartPtOcc
         // 
         this._lblNoiseStartPtOcc.AutoSize = true;
         this._lblNoiseStartPtOcc.Location = new System.Drawing.Point(95, 15);
         this._lblNoiseStartPtOcc.Name = "_lblNoiseStartPtOcc";
         this._lblNoiseStartPtOcc.Size = new System.Drawing.Size(63, 13);
         this._lblNoiseStartPtOcc.TabIndex = 23;
         this._lblNoiseStartPtOcc.Text = "Occurrence";
         // 
         // _lblNoiseStartPtClr
         // 
         this._lblNoiseStartPtClr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._lblNoiseStartPtClr.Location = new System.Drawing.Point(71, 31);
         this._lblNoiseStartPtClr.Name = "_lblNoiseStartPtClr";
         this._lblNoiseStartPtClr.Size = new System.Drawing.Size(21, 20);
         this._lblNoiseStartPtClr.TabIndex = 22;
         // 
         // _nudNoiseStartPt
         // 
         this._nudNoiseStartPt.Location = new System.Drawing.Point(7, 30);
         this._nudNoiseStartPt.Name = "_nudNoiseStartPt";
         this._nudNoiseStartPt.Size = new System.Drawing.Size(58, 20);
         this._nudNoiseStartPt.TabIndex = 1;
         this._nudNoiseStartPt.ValueChanged += new System.EventHandler(this._nudStartPt_ValueChanged);
         // 
         // _lblNoiseStartPt
         // 
         this._lblNoiseStartPt.AutoSize = true;
         this._lblNoiseStartPt.Location = new System.Drawing.Point(11, 15);
         this._lblNoiseStartPt.Name = "_lblNoiseStartPt";
         this._lblNoiseStartPt.Size = new System.Drawing.Size(56, 13);
         this._lblNoiseStartPt.TabIndex = 0;
         this._lblNoiseStartPt.Text = "&Start Point";
         // 
         // _btnNoiseApplyBitmap
         // 
         this._btnNoiseApplyBitmap.Location = new System.Drawing.Point(90, 103);
         this._btnNoiseApplyBitmap.Name = "_btnNoiseApplyBitmap";
         this._btnNoiseApplyBitmap.Size = new System.Drawing.Size(73, 23);
         this._btnNoiseApplyBitmap.TabIndex = 6;
         this._btnNoiseApplyBitmap.Text = "Bitmap Data";
         this._btnNoiseApplyBitmap.UseVisualStyleBackColor = true;
         this._btnNoiseApplyBitmap.Click += new System.EventHandler(this._btnApplyToBitmap_Click);
         // 
         // _grpNoiseFilterInfo
         // 
         this._grpNoiseFilterInfo.Controls.Add(this._lblNoiseReplaceColor);
         this._grpNoiseFilterInfo.Controls.Add(this._btnNoiseReplaceColor);
         this._grpNoiseFilterInfo.Controls.Add(this._cbNoiseReplaceWith);
         this._grpNoiseFilterInfo.Controls.Add(this._lblNoiseReplaceWith);
         this._grpNoiseFilterInfo.Location = new System.Drawing.Point(168, 0);
         this._grpNoiseFilterInfo.Name = "_grpNoiseFilterInfo";
         this._grpNoiseFilterInfo.Size = new System.Drawing.Size(212, 101);
         this._grpNoiseFilterInfo.TabIndex = 2;
         this._grpNoiseFilterInfo.TabStop = false;
         this._grpNoiseFilterInfo.Text = "Filter(Noise) Information";
         // 
         // _lblNoiseReplaceColor
         // 
         this._lblNoiseReplaceColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._lblNoiseReplaceColor.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblNoiseReplaceColor.Location = new System.Drawing.Point(103, 53);
         this._lblNoiseReplaceColor.Name = "_lblNoiseReplaceColor";
         this._lblNoiseReplaceColor.Size = new System.Drawing.Size(75, 23);
         this._lblNoiseReplaceColor.TabIndex = 3;
         // 
         // _btnNoiseReplaceColor
         // 
         this._btnNoiseReplaceColor.Location = new System.Drawing.Point(7, 53);
         this._btnNoiseReplaceColor.Name = "_btnNoiseReplaceColor";
         this._btnNoiseReplaceColor.Size = new System.Drawing.Size(90, 23);
         this._btnNoiseReplaceColor.TabIndex = 2;
         this._btnNoiseReplaceColor.Text = "&Replace Color";
         this._btnNoiseReplaceColor.UseVisualStyleBackColor = true;
         this._btnNoiseReplaceColor.Click += new System.EventHandler(this._btnNoiseReplaceColor_Click);
         // 
         // _cbNoiseReplaceWith
         // 
         this._cbNoiseReplaceWith.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cbNoiseReplaceWith.FormattingEnabled = true;
         this._cbNoiseReplaceWith.Items.AddRange(new object[] {
            "Start & End Points",
            "Min & Max Intesities",
            "Replacement Color",
            "Zero"});
         this._cbNoiseReplaceWith.Location = new System.Drawing.Point(82, 16);
         this._cbNoiseReplaceWith.Name = "_cbNoiseReplaceWith";
         this._cbNoiseReplaceWith.Size = new System.Drawing.Size(121, 21);
         this._cbNoiseReplaceWith.TabIndex = 1;
         this._cbNoiseReplaceWith.SelectedIndexChanged += new System.EventHandler(this._cbNoiseReplaceWith_SelectedIndexChanged);
         // 
         // _lblNoiseReplaceWith
         // 
         this._lblNoiseReplaceWith.AutoSize = true;
         this._lblNoiseReplaceWith.Location = new System.Drawing.Point(7, 19);
         this._lblNoiseReplaceWith.Name = "_lblNoiseReplaceWith";
         this._lblNoiseReplaceWith.Size = new System.Drawing.Size(72, 13);
         this._lblNoiseReplaceWith.TabIndex = 0;
         this._lblNoiseReplaceWith.Text = "Replace With";
         // 
         // _tpgRescaling
         // 
         this._tpgRescaling.Controls.Add(this._chkResApplyInProgress);
         this._tpgRescaling.Controls.Add(this._btnResApplyLUT);
         this._tpgRescaling.Controls.Add(this._grpResSelInfo);
         this._tpgRescaling.Controls.Add(this._btnResApplyBitmap);
         this._tpgRescaling.Controls.Add(this._grpRescalingInfor);
         this._tpgRescaling.Location = new System.Drawing.Point(4, 22);
         this._tpgRescaling.Name = "_tpgRescaling";
         this._tpgRescaling.Padding = new System.Windows.Forms.Padding(3);
         this._tpgRescaling.Size = new System.Drawing.Size(401, 150);
         this._tpgRescaling.TabIndex = 3;
         this._tpgRescaling.Text = "Rescaling";
         this._tpgRescaling.UseVisualStyleBackColor = true;
         // 
         // _chkResApplyInProgress
         // 
         this._chkResApplyInProgress.AutoSize = true;
         this._chkResApplyInProgress.Location = new System.Drawing.Point(12, 129);
         this._chkResApplyInProgress.Name = "_chkResApplyInProgress";
         this._chkResApplyInProgress.Size = new System.Drawing.Size(94, 17);
         this._chkResApplyInProgress.TabIndex = 11;
         this._chkResApplyInProgress.Text = "Show Preview";
         this._chkResApplyInProgress.UseVisualStyleBackColor = true;
         this._chkResApplyInProgress.CheckedChanged += new System.EventHandler(this._chkApplyInProgress_CheckedChanged);
         // 
         // _btnResApplyLUT
         // 
         this._btnResApplyLUT.Location = new System.Drawing.Point(11, 103);
         this._btnResApplyLUT.Name = "_btnResApplyLUT";
         this._btnResApplyLUT.Size = new System.Drawing.Size(73, 23);
         this._btnResApplyLUT.TabIndex = 9;
         this._btnResApplyLUT.Text = "LUT";
         this._btnResApplyLUT.UseVisualStyleBackColor = true;
         this._btnResApplyLUT.Click += new System.EventHandler(this._btnApplyLUT_Click);
         // 
         // _grpResSelInfo
         // 
         this._grpResSelInfo.Controls.Add(this._lblResEndPtOccVal);
         this._grpResSelInfo.Controls.Add(this._lblResEndPtOcc);
         this._grpResSelInfo.Controls.Add(this._lblResEndPtClr);
         this._grpResSelInfo.Controls.Add(this._nudResEndPt);
         this._grpResSelInfo.Controls.Add(this._lblResEndPt);
         this._grpResSelInfo.Controls.Add(this._lblResStartPtOccVal);
         this._grpResSelInfo.Controls.Add(this._lblResStartPtOcc);
         this._grpResSelInfo.Controls.Add(this._lblResStartPtClr);
         this._grpResSelInfo.Controls.Add(this._nudResStartPt);
         this._grpResSelInfo.Controls.Add(this._lblResStartPt);
         this._grpResSelInfo.Location = new System.Drawing.Point(0, 0);
         this._grpResSelInfo.Name = "_grpResSelInfo";
         this._grpResSelInfo.Size = new System.Drawing.Size(164, 101);
         this._grpResSelInfo.TabIndex = 7;
         this._grpResSelInfo.TabStop = false;
         this._grpResSelInfo.Text = "Selection Information";
         // 
         // _lblResEndPtOccVal
         // 
         this._lblResEndPtOccVal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._lblResEndPtOccVal.Location = new System.Drawing.Point(97, 72);
         this._lblResEndPtOccVal.Name = "_lblResEndPtOccVal";
         this._lblResEndPtOccVal.Size = new System.Drawing.Size(57, 20);
         this._lblResEndPtOccVal.TabIndex = 29;
         // 
         // _lblResEndPtOcc
         // 
         this._lblResEndPtOcc.AutoSize = true;
         this._lblResEndPtOcc.Location = new System.Drawing.Point(96, 57);
         this._lblResEndPtOcc.Name = "_lblResEndPtOcc";
         this._lblResEndPtOcc.Size = new System.Drawing.Size(63, 13);
         this._lblResEndPtOcc.TabIndex = 28;
         this._lblResEndPtOcc.Text = "Occurrence";
         // 
         // _lblResEndPtClr
         // 
         this._lblResEndPtClr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._lblResEndPtClr.Location = new System.Drawing.Point(71, 73);
         this._lblResEndPtClr.Name = "_lblResEndPtClr";
         this._lblResEndPtClr.Size = new System.Drawing.Size(21, 20);
         this._lblResEndPtClr.TabIndex = 27;
         // 
         // _nudResEndPt
         // 
         this._nudResEndPt.Location = new System.Drawing.Point(7, 72);
         this._nudResEndPt.Name = "_nudResEndPt";
         this._nudResEndPt.Size = new System.Drawing.Size(58, 20);
         this._nudResEndPt.TabIndex = 26;
         this._nudResEndPt.ValueChanged += new System.EventHandler(this._nudEndPt_ValueChanged);
         // 
         // _lblResEndPt
         // 
         this._lblResEndPt.AutoSize = true;
         this._lblResEndPt.Location = new System.Drawing.Point(12, 57);
         this._lblResEndPt.Name = "_lblResEndPt";
         this._lblResEndPt.Size = new System.Drawing.Size(53, 13);
         this._lblResEndPt.TabIndex = 25;
         this._lblResEndPt.Text = "&End Point";
         // 
         // _lblResStartPtOccVal
         // 
         this._lblResStartPtOccVal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._lblResStartPtOccVal.Location = new System.Drawing.Point(97, 30);
         this._lblResStartPtOccVal.Name = "_lblResStartPtOccVal";
         this._lblResStartPtOccVal.Size = new System.Drawing.Size(57, 20);
         this._lblResStartPtOccVal.TabIndex = 24;
         // 
         // _lblResStartPtOcc
         // 
         this._lblResStartPtOcc.AutoSize = true;
         this._lblResStartPtOcc.Location = new System.Drawing.Point(95, 15);
         this._lblResStartPtOcc.Name = "_lblResStartPtOcc";
         this._lblResStartPtOcc.Size = new System.Drawing.Size(63, 13);
         this._lblResStartPtOcc.TabIndex = 23;
         this._lblResStartPtOcc.Text = "Occurrence";
         // 
         // _lblResStartPtClr
         // 
         this._lblResStartPtClr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._lblResStartPtClr.Location = new System.Drawing.Point(71, 31);
         this._lblResStartPtClr.Name = "_lblResStartPtClr";
         this._lblResStartPtClr.Size = new System.Drawing.Size(21, 20);
         this._lblResStartPtClr.TabIndex = 22;
         // 
         // _nudResStartPt
         // 
         this._nudResStartPt.Location = new System.Drawing.Point(7, 30);
         this._nudResStartPt.Name = "_nudResStartPt";
         this._nudResStartPt.Size = new System.Drawing.Size(58, 20);
         this._nudResStartPt.TabIndex = 1;
         this._nudResStartPt.ValueChanged += new System.EventHandler(this._nudStartPt_ValueChanged);
         // 
         // _lblResStartPt
         // 
         this._lblResStartPt.AutoSize = true;
         this._lblResStartPt.Location = new System.Drawing.Point(11, 15);
         this._lblResStartPt.Name = "_lblResStartPt";
         this._lblResStartPt.Size = new System.Drawing.Size(56, 13);
         this._lblResStartPt.TabIndex = 0;
         this._lblResStartPt.Text = "&Start Point";
         // 
         // _btnResApplyBitmap
         // 
         this._btnResApplyBitmap.Location = new System.Drawing.Point(90, 103);
         this._btnResApplyBitmap.Name = "_btnResApplyBitmap";
         this._btnResApplyBitmap.Size = new System.Drawing.Size(73, 23);
         this._btnResApplyBitmap.TabIndex = 6;
         this._btnResApplyBitmap.Text = "Bitmap Data";
         this._btnResApplyBitmap.UseVisualStyleBackColor = true;
         this._btnResApplyBitmap.Click += new System.EventHandler(this._btnApplyToBitmap_Click);
         // 
         // _grpRescalingInfor
         // 
         this._grpRescalingInfor.Controls.Add(this._rbResShiftLeft);
         this._grpRescalingInfor.Controls.Add(this._rbResShiftRight);
         this._grpRescalingInfor.Controls.Add(this._nudResNewEnd);
         this._grpRescalingInfor.Controls.Add(this._lblResNewEnd);
         this._grpRescalingInfor.Controls.Add(this._nudResNewStart);
         this._grpRescalingInfor.Controls.Add(this._lblResNewStart);
         this._grpRescalingInfor.Controls.Add(this._nudResShiftAmount);
         this._grpRescalingInfor.Controls.Add(this._lblResShiftAmount);
         this._grpRescalingInfor.Controls.Add(this._rbResNewSE);
         this._grpRescalingInfor.Controls.Add(this._rbResShift);
         this._grpRescalingInfor.Location = new System.Drawing.Point(168, 0);
         this._grpRescalingInfor.Name = "_grpRescalingInfor";
         this._grpRescalingInfor.Size = new System.Drawing.Size(212, 124);
         this._grpRescalingInfor.TabIndex = 2;
         this._grpRescalingInfor.TabStop = false;
         this._grpRescalingInfor.Text = "Rescaling Information";
         // 
         // _rbResShiftLeft
         // 
         this._rbResShiftLeft.AutoCheck = false;
         this._rbResShiftLeft.AutoSize = true;
         this._rbResShiftLeft.Location = new System.Drawing.Point(135, 34);
         this._rbResShiftLeft.Name = "_rbResShiftLeft";
         this._rbResShiftLeft.Size = new System.Drawing.Size(67, 17);
         this._rbResShiftLeft.TabIndex = 38;
         this._rbResShiftLeft.TabStop = true;
         this._rbResShiftLeft.Text = "Shift Left";
         this._rbResShiftLeft.UseVisualStyleBackColor = true;
         this._rbResShiftLeft.Click += new System.EventHandler(this._rbRes_Click);
         this._rbResShiftLeft.CheckedChanged += new System.EventHandler(this._rbResShiftLeft_CheckedChanged);
         // 
         // _rbResShiftRight
         // 
         this._rbResShiftRight.AutoCheck = false;
         this._rbResShiftRight.AutoSize = true;
         this._rbResShiftRight.Location = new System.Drawing.Point(135, 13);
         this._rbResShiftRight.Name = "_rbResShiftRight";
         this._rbResShiftRight.Size = new System.Drawing.Size(74, 17);
         this._rbResShiftRight.TabIndex = 37;
         this._rbResShiftRight.TabStop = true;
         this._rbResShiftRight.Text = "Shift Right";
         this._rbResShiftRight.UseVisualStyleBackColor = true;
         this._rbResShiftRight.Click += new System.EventHandler(this._rbRes_Click);
         this._rbResShiftRight.CheckedChanged += new System.EventHandler(this._rbResShiftRight_CheckedChanged);
         // 
         // _nudResNewEnd
         // 
         this._nudResNewEnd.Location = new System.Drawing.Point(59, 99);
         this._nudResNewEnd.Name = "_nudResNewEnd";
         this._nudResNewEnd.Size = new System.Drawing.Size(58, 20);
         this._nudResNewEnd.TabIndex = 34;
         this._nudResNewEnd.ValueChanged += new System.EventHandler(this._nudResNewEnd_ValueChanged);
         // 
         // _lblResNewEnd
         // 
         this._lblResNewEnd.AutoSize = true;
         this._lblResNewEnd.Location = new System.Drawing.Point(5, 102);
         this._lblResNewEnd.Name = "_lblResNewEnd";
         this._lblResNewEnd.Size = new System.Drawing.Size(51, 13);
         this._lblResNewEnd.TabIndex = 33;
         this._lblResNewEnd.Text = "New End";
         // 
         // _nudResNewStart
         // 
         this._nudResNewStart.Location = new System.Drawing.Point(59, 76);
         this._nudResNewStart.Name = "_nudResNewStart";
         this._nudResNewStart.Size = new System.Drawing.Size(58, 20);
         this._nudResNewStart.TabIndex = 32;
         this._nudResNewStart.ValueChanged += new System.EventHandler(this._nudResNewStart_ValueChanged);
         // 
         // _lblResNewStart
         // 
         this._lblResNewStart.AutoSize = true;
         this._lblResNewStart.Location = new System.Drawing.Point(5, 79);
         this._lblResNewStart.Name = "_lblResNewStart";
         this._lblResNewStart.Size = new System.Drawing.Size(54, 13);
         this._lblResNewStart.TabIndex = 31;
         this._lblResNewStart.Text = "New Start";
         // 
         // _nudResShiftAmount
         // 
         this._nudResShiftAmount.Location = new System.Drawing.Point(71, 30);
         this._nudResShiftAmount.Name = "_nudResShiftAmount";
         this._nudResShiftAmount.Size = new System.Drawing.Size(58, 20);
         this._nudResShiftAmount.TabIndex = 30;
         this._nudResShiftAmount.ValueChanged += new System.EventHandler(this._nudResShiftAmount_ValueChanged);
         // 
         // _lblResShiftAmount
         // 
         this._lblResShiftAmount.AutoSize = true;
         this._lblResShiftAmount.Location = new System.Drawing.Point(3, 33);
         this._lblResShiftAmount.Name = "_lblResShiftAmount";
         this._lblResShiftAmount.Size = new System.Drawing.Size(67, 13);
         this._lblResShiftAmount.TabIndex = 2;
         this._lblResShiftAmount.Text = "Shift Amount";
         // 
         // _rbResNewSE
         // 
         this._rbResNewSE.AutoCheck = false;
         this._rbResNewSE.AutoSize = true;
         this._rbResNewSE.Location = new System.Drawing.Point(6, 55);
         this._rbResNewSE.Name = "_rbResNewSE";
         this._rbResNewSE.Size = new System.Drawing.Size(96, 17);
         this._rbResNewSE.TabIndex = 1;
         this._rbResNewSE.TabStop = true;
         this._rbResNewSE.Text = "New Start/End";
         this._rbResNewSE.UseVisualStyleBackColor = true;
         this._rbResNewSE.Click += new System.EventHandler(this._rbRes_Click);
         this._rbResNewSE.CheckedChanged += new System.EventHandler(this._rbResNewSE_CheckedChanged);
         // 
         // _rbResShift
         // 
         this._rbResShift.AutoCheck = false;
         this._rbResShift.AutoSize = true;
         this._rbResShift.Location = new System.Drawing.Point(7, 14);
         this._rbResShift.Name = "_rbResShift";
         this._rbResShift.Size = new System.Drawing.Size(46, 17);
         this._rbResShift.TabIndex = 0;
         this._rbResShift.TabStop = true;
         this._rbResShift.Text = "Shift";
         this._rbResShift.UseVisualStyleBackColor = true;
         this._rbResShift.Click += new System.EventHandler(this._rbRes_Click);
         this._rbResShift.CheckedChanged += new System.EventHandler(this._rbResShift_CheckedChanged);
         // 
         // _grpStatisticalInformation
         // 
         this._grpStatisticalInformation.Controls.Add(this._grpMouse);
         this._grpStatisticalInformation.Controls.Add(this._lblStdDev);
         this._grpStatisticalInformation.Controls.Add(this._lblSelStdDev);
         this._grpStatisticalInformation.Controls.Add(this._lblMedian);
         this._grpStatisticalInformation.Controls.Add(this._lblSelMedian);
         this._grpStatisticalInformation.Controls.Add(this._lblMean);
         this._grpStatisticalInformation.Controls.Add(this._lblSelMean);
         this._grpStatisticalInformation.Controls.Add(this._lblLevel);
         this._grpStatisticalInformation.Controls.Add(this._lblSelLevel);
         this._grpStatisticalInformation.Controls.Add(this._lblPercent);
         this._grpStatisticalInformation.Controls.Add(this._lblSelPercent);
         this._grpStatisticalInformation.Controls.Add(this._lblCount);
         this._grpStatisticalInformation.Controls.Add(this._lblSelCount);
         this._grpStatisticalInformation.Location = new System.Drawing.Point(6, 436);
         this._grpStatisticalInformation.Name = "_grpStatisticalInformation";
         this._grpStatisticalInformation.Size = new System.Drawing.Size(408, 88);
         this._grpStatisticalInformation.TabIndex = 4;
         this._grpStatisticalInformation.TabStop = false;
         this._grpStatisticalInformation.Text = "Statistical Information (Selection)";
         // 
         // _grpMouse
         // 
         this._grpMouse.Controls.Add(this.label1);
         this._grpMouse.Controls.Add(this._lblMouseLevel);
         this._grpMouse.Controls.Add(this.label2);
         this._grpMouse.Controls.Add(this._lblMousePercent);
         this._grpMouse.Controls.Add(this.label3);
         this._grpMouse.Controls.Add(this._lblMouseCount);
         this._grpMouse.Location = new System.Drawing.Point(280, 0);
         this._grpMouse.Name = "_grpMouse";
         this._grpMouse.Size = new System.Drawing.Size(128, 88);
         this._grpMouse.TabIndex = 22;
         this._grpMouse.TabStop = false;
         this._grpMouse.Text = "Mouse";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(7, 65);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(33, 13);
         this.label1.TabIndex = 25;
         this.label1.Text = "Level";
         // 
         // _lblMouseLevel
         // 
         this._lblMouseLevel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._lblMouseLevel.Location = new System.Drawing.Point(55, 62);
         this._lblMouseLevel.Name = "_lblMouseLevel";
         this._lblMouseLevel.Size = new System.Drawing.Size(66, 21);
         this._lblMouseLevel.TabIndex = 11;
         this._lblMouseLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(7, 42);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(44, 13);
         this.label2.TabIndex = 24;
         this.label2.Text = "Percent";
         // 
         // _lblMousePercent
         // 
         this._lblMousePercent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._lblMousePercent.Location = new System.Drawing.Point(55, 38);
         this._lblMousePercent.Name = "_lblMousePercent";
         this._lblMousePercent.Size = new System.Drawing.Size(66, 21);
         this._lblMousePercent.TabIndex = 8;
         this._lblMousePercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(7, 18);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(35, 13);
         this.label3.TabIndex = 23;
         this.label3.Text = "Count";
         // 
         // _lblMouseCount
         // 
         this._lblMouseCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._lblMouseCount.Location = new System.Drawing.Point(55, 14);
         this._lblMouseCount.Name = "_lblMouseCount";
         this._lblMouseCount.Size = new System.Drawing.Size(66, 21);
         this._lblMouseCount.TabIndex = 5;
         this._lblMouseCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // _lblStdDev
         // 
         this._lblStdDev.AutoSize = true;
         this._lblStdDev.Location = new System.Drawing.Point(161, 65);
         this._lblStdDev.Name = "_lblStdDev";
         this._lblStdDev.Size = new System.Drawing.Size(43, 13);
         this._lblStdDev.TabIndex = 21;
         this._lblStdDev.Text = "StdDev";
         // 
         // _lblSelStdDev
         // 
         this._lblSelStdDev.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._lblSelStdDev.Location = new System.Drawing.Point(206, 62);
         this._lblSelStdDev.Name = "_lblSelStdDev";
         this._lblSelStdDev.Size = new System.Drawing.Size(66, 21);
         this._lblSelStdDev.TabIndex = 19;
         this._lblSelStdDev.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // _lblMedian
         // 
         this._lblMedian.AutoSize = true;
         this._lblMedian.Location = new System.Drawing.Point(161, 42);
         this._lblMedian.Name = "_lblMedian";
         this._lblMedian.Size = new System.Drawing.Size(42, 13);
         this._lblMedian.TabIndex = 18;
         this._lblMedian.Text = "Median";
         // 
         // _lblSelMedian
         // 
         this._lblSelMedian.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._lblSelMedian.Location = new System.Drawing.Point(206, 38);
         this._lblSelMedian.Name = "_lblSelMedian";
         this._lblSelMedian.Size = new System.Drawing.Size(66, 21);
         this._lblSelMedian.TabIndex = 16;
         this._lblSelMedian.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // _lblMean
         // 
         this._lblMean.AutoSize = true;
         this._lblMean.Location = new System.Drawing.Point(161, 18);
         this._lblMean.Name = "_lblMean";
         this._lblMean.Size = new System.Drawing.Size(34, 13);
         this._lblMean.TabIndex = 15;
         this._lblMean.Text = "Mean";
         // 
         // _lblSelMean
         // 
         this._lblSelMean.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._lblSelMean.Location = new System.Drawing.Point(206, 14);
         this._lblSelMean.Name = "_lblSelMean";
         this._lblSelMean.Size = new System.Drawing.Size(66, 21);
         this._lblSelMean.TabIndex = 13;
         this._lblSelMean.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // _lblLevel
         // 
         this._lblLevel.AutoSize = true;
         this._lblLevel.Location = new System.Drawing.Point(9, 65);
         this._lblLevel.Name = "_lblLevel";
         this._lblLevel.Size = new System.Drawing.Size(33, 13);
         this._lblLevel.TabIndex = 12;
         this._lblLevel.Text = "Level";
         // 
         // _lblSelLevel
         // 
         this._lblSelLevel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._lblSelLevel.Location = new System.Drawing.Point(54, 62);
         this._lblSelLevel.Name = "_lblSelLevel";
         this._lblSelLevel.Size = new System.Drawing.Size(96, 21);
         this._lblSelLevel.TabIndex = 10;
         this._lblSelLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // _lblPercent
         // 
         this._lblPercent.AutoSize = true;
         this._lblPercent.Location = new System.Drawing.Point(9, 42);
         this._lblPercent.Name = "_lblPercent";
         this._lblPercent.Size = new System.Drawing.Size(44, 13);
         this._lblPercent.TabIndex = 9;
         this._lblPercent.Text = "Percent";
         // 
         // _lblSelPercent
         // 
         this._lblSelPercent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._lblSelPercent.Location = new System.Drawing.Point(54, 38);
         this._lblSelPercent.Name = "_lblSelPercent";
         this._lblSelPercent.Size = new System.Drawing.Size(96, 21);
         this._lblSelPercent.TabIndex = 7;
         this._lblSelPercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // _lblCount
         // 
         this._lblCount.AutoSize = true;
         this._lblCount.Location = new System.Drawing.Point(9, 18);
         this._lblCount.Name = "_lblCount";
         this._lblCount.Size = new System.Drawing.Size(35, 13);
         this._lblCount.TabIndex = 6;
         this._lblCount.Text = "Count";
         // 
         // _lblSelCount
         // 
         this._lblSelCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._lblSelCount.Location = new System.Drawing.Point(54, 14);
         this._lblSelCount.Name = "_lblSelCount";
         this._lblSelCount.Size = new System.Drawing.Size(96, 21);
         this._lblSelCount.TabIndex = 4;
         this._lblSelCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // _grpSelectionColor
         // 
         this._grpSelectionColor.Controls.Add(this._lblOuter);
         this._grpSelectionColor.Controls.Add(this._btnOuter);
         this._grpSelectionColor.Controls.Add(this._lblInner);
         this._grpSelectionColor.Controls.Add(this._btnInner);
         this._grpSelectionColor.Location = new System.Drawing.Point(323, 50);
         this._grpSelectionColor.Name = "_grpSelectionColor";
         this._grpSelectionColor.Size = new System.Drawing.Size(94, 124);
         this._grpSelectionColor.TabIndex = 3;
         this._grpSelectionColor.TabStop = false;
         this._grpSelectionColor.Text = "Selection Color";
         // 
         // _lblOuter
         // 
         this._lblOuter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._lblOuter.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblOuter.Location = new System.Drawing.Point(9, 95);
         this._lblOuter.Name = "_lblOuter";
         this._lblOuter.Size = new System.Drawing.Size(75, 23);
         this._lblOuter.TabIndex = 3;
         // 
         // _btnOuter
         // 
         this._btnOuter.Location = new System.Drawing.Point(9, 69);
         this._btnOuter.Name = "_btnOuter";
         this._btnOuter.Size = new System.Drawing.Size(75, 23);
         this._btnOuter.TabIndex = 2;
         this._btnOuter.Text = "&Outer";
         this._btnOuter.UseVisualStyleBackColor = true;
         this._btnOuter.Click += new System.EventHandler(this._btnOuter_Click);
         // 
         // _lblInner
         // 
         this._lblInner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._lblInner.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblInner.Location = new System.Drawing.Point(9, 41);
         this._lblInner.Name = "_lblInner";
         this._lblInner.Size = new System.Drawing.Size(75, 23);
         this._lblInner.TabIndex = 1;
         // 
         // _btnInner
         // 
         this._btnInner.Location = new System.Drawing.Point(9, 15);
         this._btnInner.Name = "_btnInner";
         this._btnInner.Size = new System.Drawing.Size(75, 23);
         this._btnInner.TabIndex = 0;
         this._btnInner.Text = "&Inner";
         this._btnInner.UseVisualStyleBackColor = true;
         this._btnInner.Click += new System.EventHandler(this._btnInner_Click);
         // 
         // _cbChannel
         // 
         this._cbChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cbChannel.FormattingEnabled = true;
         this._cbChannel.Items.AddRange(new object[] {
            "RGB",
            "Red",
            "Green",
            "Blue"});
         this._cbChannel.Location = new System.Drawing.Point(323, 25);
         this._cbChannel.Name = "_cbChannel";
         this._cbChannel.Size = new System.Drawing.Size(94, 21);
         this._cbChannel.TabIndex = 2;
         this._cbChannel.SelectedIndexChanged += new System.EventHandler(this._cbChannel_SelectedIndexChanged);
         // 
         // _lblChannel
         // 
         this._lblChannel.AutoSize = true;
         this._lblChannel.Location = new System.Drawing.Point(320, 9);
         this._lblChannel.Name = "_lblChannel";
         this._lblChannel.Size = new System.Drawing.Size(46, 13);
         this._lblChannel.TabIndex = 1;
         this._lblChannel.Text = "Channel";
         // 
         // _cbSelectionType
         // 
         this._cbSelectionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cbSelectionType.FormattingEnabled = true;
         this._cbSelectionType.Items.AddRange(new object[] {
            "All",
            "Inner Area",
            "Left Area",
            "Right Area"});
         this._cbSelectionType.Location = new System.Drawing.Point(323, 191);
         this._cbSelectionType.Name = "_cbSelectionType";
         this._cbSelectionType.Size = new System.Drawing.Size(94, 21);
         this._cbSelectionType.TabIndex = 0;
         this._cbSelectionType.SelectedIndexChanged += new System.EventHandler(this._cbSelectionType_SelectedIndexChanged);
         // 
         // _lblSelectionType
         // 
         this._lblSelectionType.AutoSize = true;
         this._lblSelectionType.Location = new System.Drawing.Point(320, 176);
         this._lblSelectionType.Name = "_lblSelectionType";
         this._lblSelectionType.Size = new System.Drawing.Size(78, 13);
         this._lblSelectionType.TabIndex = 1;
         this._lblSelectionType.Text = "Selection Type";
         // 
         // _MainProgressBar
         // 
         this._MainProgressBar.Location = new System.Drawing.Point(246, 538);
         this._MainProgressBar.Name = "_MainProgressBar";
         this._MainProgressBar.Size = new System.Drawing.Size(177, 17);
         this._MainProgressBar.TabIndex = 2;
         // 
         // _btnOk
         // 
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOk.Location = new System.Drawing.Point(3, 535);
         this._btnOk.Name = "_btnOk";
         this._btnOk.Size = new System.Drawing.Size(75, 23);
         this._btnOk.TabIndex = 3;
         this._btnOk.Text = "&Ok";
         this._btnOk.UseVisualStyleBackColor = true;
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // _btnUndo
         // 
         this._btnUndo.Location = new System.Drawing.Point(84, 535);
         this._btnUndo.Name = "_btnUndo";
         this._btnUndo.Size = new System.Drawing.Size(75, 23);
         this._btnUndo.TabIndex = 4;
         this._btnUndo.Text = "&Undo";
         this._btnUndo.UseVisualStyleBackColor = true;
         this._btnUndo.Click += new System.EventHandler(this._btnUndo_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(165, 535);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(75, 23);
         this._btnCancel.TabIndex = 5;
         this._btnCancel.Text = "&Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
         // 
         // InteractiveHistogramDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(432, 562);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnUndo);
         this.Controls.Add(this._btnOk);
         this.Controls.Add(this._MainProgressBar);
         this.Controls.Add(this._grpView);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "InteractiveHistogramDialog";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Interactive Histogram";
         this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.InteractiveHistogramDialog_FormClosed);
         this._cmRightClickOptions.ResumeLayout(false);
         this._grpView.ResumeLayout(false);
         this._grpView.PerformLayout();
         this._tabOptions.ResumeLayout(false);
         this._tpgSegmentation.ResumeLayout(false);
         this._tpgSegmentation.PerformLayout();
         this._grpSegmentationInfo.ResumeLayout(false);
         this._grpSegmentationInfo.PerformLayout();
         this._grpSegSelInfo.ResumeLayout(false);
         this._grpSegSelInfo.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._nudSegEndPt)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._nudSegStartPt)).EndInit();
         this._tpgGrayDistribution.ResumeLayout(false);
         this._tpgGrayDistribution.PerformLayout();
         this._grpGrySelInfo.ResumeLayout(false);
         this._grpGrySelInfo.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._nudGrayEndPt)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._nudGrayStartPt)).EndInit();
         this._grpGrayDistributionInfo.ResumeLayout(false);
         this._grpGrayDistributionInfo.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._nudGrayFactor)).EndInit();
         this._tpgNoiseFilter.ResumeLayout(false);
         this._tpgNoiseFilter.PerformLayout();
         this._grpNoiseSelInfo.ResumeLayout(false);
         this._grpNoiseSelInfo.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._nudNoiseEndPt)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._nudNoiseStartPt)).EndInit();
         this._grpNoiseFilterInfo.ResumeLayout(false);
         this._grpNoiseFilterInfo.PerformLayout();
         this._tpgRescaling.ResumeLayout(false);
         this._tpgRescaling.PerformLayout();
         this._grpResSelInfo.ResumeLayout(false);
         this._grpResSelInfo.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._nudResEndPt)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._nudResStartPt)).EndInit();
         this._grpRescalingInfor.ResumeLayout(false);
         this._grpRescalingInfor.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._nudResNewEnd)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._nudResNewStart)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._nudResShiftAmount)).EndInit();
         this._grpStatisticalInformation.ResumeLayout(false);
         this._grpStatisticalInformation.PerformLayout();
         this._grpMouse.ResumeLayout(false);
         this._grpMouse.PerformLayout();
         this._grpSelectionColor.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Label _lblHistogram;
      private System.Windows.Forms.GroupBox _grpView;
      private System.Windows.Forms.ProgressBar _MainProgressBar;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Button _btnUndo;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.GroupBox _grpSelectionColor;
      private System.Windows.Forms.ComboBox _cbChannel;
      private System.Windows.Forms.Label _lblChannel;
      private System.Windows.Forms.Label _lblOuter;
      private System.Windows.Forms.Button _btnOuter;
      private System.Windows.Forms.Label _lblInner;
      private System.Windows.Forms.Button _btnInner;
      private System.Windows.Forms.GroupBox _grpStatisticalInformation;
      private System.Windows.Forms.Label _lblSelCount;
      private System.Windows.Forms.Label _lblSelectionType;
      private System.Windows.Forms.ComboBox _cbSelectionType;
      private System.Windows.Forms.Label _lblStdDev;
      private System.Windows.Forms.Label _lblSelStdDev;
      private System.Windows.Forms.Label _lblMedian;
      private System.Windows.Forms.Label _lblSelMedian;
      private System.Windows.Forms.Label _lblMean;
      private System.Windows.Forms.Label _lblSelMean;
      private System.Windows.Forms.Label _lblLevel;
      private System.Windows.Forms.Label _lblMouseLevel;
      private System.Windows.Forms.Label _lblSelLevel;
      private System.Windows.Forms.Label _lblPercent;
      private System.Windows.Forms.Label _lblMousePercent;
      private System.Windows.Forms.Label _lblSelPercent;
      private System.Windows.Forms.Label _lblCount;
      private System.Windows.Forms.Label _lblMouseCount;
      private System.Windows.Forms.TabControl _tabOptions;
      private System.Windows.Forms.TabPage _tpgSegmentation;
      private System.Windows.Forms.TabPage _tpgGrayDistribution;
      private System.Windows.Forms.TabPage _tpgNoiseFilter;
      private System.Windows.Forms.TabPage _tpgRescaling;
      private System.Windows.Forms.GroupBox _grpSegSelInfo;
      private System.Windows.Forms.NumericUpDown _nudSegStartPt;
      private System.Windows.Forms.Label _lblSegStartPt;
      private System.Windows.Forms.Label _lblSegStartPtOccVal;
      private System.Windows.Forms.Label _lblSegStartPtOcc;
      private System.Windows.Forms.Label _lblSegStartPtClr;
      private System.Windows.Forms.Label _lblSegEndPtOccVal;
      private System.Windows.Forms.Label _lblSegEndPtOcc;
      private System.Windows.Forms.Label _lblSegEndPtClr;
      private System.Windows.Forms.NumericUpDown _nudSegEndPt;
      private System.Windows.Forms.Label _lblSegEndPt;
      private System.Windows.Forms.Button _btnShowHideOptions;
      private System.Windows.Forms.Button _btnSegApply;
      private System.Windows.Forms.GroupBox _grpGrayDistributionInfo;
      private System.Windows.Forms.ComboBox _cbGrayFunctionType;
      private System.Windows.Forms.Label _lblGrayFactor;
      private System.Windows.Forms.Label _lblGrayFunctionType;
      private System.Windows.Forms.NumericUpDown _nudGrayFactor;
      private System.Windows.Forms.GroupBox _grpNoiseFilterInfo;
      private System.Windows.Forms.ComboBox _cbNoiseReplaceWith;
      private System.Windows.Forms.Label _lblNoiseReplaceWith;
      private System.Windows.Forms.Label _lblNoiseReplaceColor;
      private System.Windows.Forms.Button _btnNoiseReplaceColor;
      private System.Windows.Forms.GroupBox _grpRescalingInfor;
      private System.Windows.Forms.Button _btnGrayApplyToBitmap;
      private System.Windows.Forms.Button _btnNoiseApplyBitmap;
      private System.Windows.Forms.Button _btnResApplyBitmap;
      private System.Windows.Forms.HScrollBar _hsRange;
      private System.Windows.Forms.GroupBox _grpGrySelInfo;
      private System.Windows.Forms.Label _lblGryEndPtOccVal;
      private System.Windows.Forms.Label _lblGryEndPtOcc;
      private System.Windows.Forms.Label _lblGrayEndPtClr;
      private System.Windows.Forms.NumericUpDown _nudGrayEndPt;
      private System.Windows.Forms.Label _lblGryEndPt;
      private System.Windows.Forms.Label _lblGryStartPtOccVal;
      private System.Windows.Forms.Label _lblGryStartPtOcc;
      private System.Windows.Forms.Label _lblGrayStartPtClr;
      private System.Windows.Forms.NumericUpDown _nudGrayStartPt;
      private System.Windows.Forms.Label _lblGryStartPt;
      private System.Windows.Forms.GroupBox _grpNoiseSelInfo;
      private System.Windows.Forms.Label _lblNoiseEndPtOccVal;
      private System.Windows.Forms.Label _lblNoiseEndPtOcc;
      private System.Windows.Forms.Label _lblNoiseEndPtClr;
      private System.Windows.Forms.NumericUpDown _nudNoiseEndPt;
      private System.Windows.Forms.Label _lblNoiseEndPt;
      private System.Windows.Forms.Label _lblNoiseStartPtOccVal;
      private System.Windows.Forms.Label _lblNoiseStartPtOcc;
      private System.Windows.Forms.Label _lblNoiseStartPtClr;
      private System.Windows.Forms.NumericUpDown _nudNoiseStartPt;
      private System.Windows.Forms.Label _lblNoiseStartPt;
      private System.Windows.Forms.GroupBox _grpResSelInfo;
      private System.Windows.Forms.Label _lblResEndPtOccVal;
      private System.Windows.Forms.Label _lblResEndPtOcc;
      private System.Windows.Forms.Label _lblResEndPtClr;
      private System.Windows.Forms.NumericUpDown _nudResEndPt;
      private System.Windows.Forms.Label _lblResEndPt;
      private System.Windows.Forms.Label _lblResStartPtOccVal;
      private System.Windows.Forms.Label _lblResStartPtOcc;
      private System.Windows.Forms.Label _lblResStartPtClr;
      private System.Windows.Forms.NumericUpDown _nudResStartPt;
      private System.Windows.Forms.Label _lblResStartPt;
      private System.Windows.Forms.GroupBox _grpSegmentationInfo;
      private System.Windows.Forms.RadioButton _rbSegGradient;
      private System.Windows.Forms.Label _lblSegEndColor;
      private System.Windows.Forms.Button _btnSegEndColor;
      private System.Windows.Forms.Label _lblSegStartColor;
      private System.Windows.Forms.Button _btnSegStartColor;
      private System.Windows.Forms.RadioButton _rbSegThreshold;
      private System.Windows.Forms.Label _lblGrayCenter;
      private System.Windows.Forms.Label _lblGrayEndColor;
      private System.Windows.Forms.Button _btnGrayEndColor;
      private System.Windows.Forms.Label _lblGrayStartColor;
      private System.Windows.Forms.Button _btnGrayStartColor;
      private System.Windows.Forms.TextBox _txtGrayWidth;
      private System.Windows.Forms.Label _lblGrayWidth;
      private System.Windows.Forms.TextBox _txtGrayCenter;
      private System.Windows.Forms.CheckBox _cbGraySelectionOnly;
      private System.Windows.Forms.Label _lblResShiftAmount;
      private System.Windows.Forms.RadioButton _rbResNewSE;
      private System.Windows.Forms.RadioButton _rbResShift;
      private System.Windows.Forms.NumericUpDown _nudResShiftAmount;
      private System.Windows.Forms.NumericUpDown _nudResNewEnd;
      private System.Windows.Forms.Label _lblResNewEnd;
      private System.Windows.Forms.NumericUpDown _nudResNewStart;
      private System.Windows.Forms.Label _lblResNewStart;
      private System.Windows.Forms.GroupBox _grpMouse;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Button _btnGrayApplyLUT;
      private System.Windows.Forms.Button _btnSegApplyLUT;
      private System.Windows.Forms.Button _btnNoiseApplyLUT;
      private System.Windows.Forms.Button _btnResApplyLUT;
      private System.Windows.Forms.ContextMenuStrip _cmRightClickOptions;
      private System.Windows.Forms.ToolStripMenuItem _cmiZoomToSelection;
      private System.Windows.Forms.ToolStripMenuItem _cmiFitGraph;
      private System.Windows.Forms.ToolStripMenuItem _cmiFullRangeView;
      private System.Windows.Forms.RadioButton _rbResShiftLeft;
      private System.Windows.Forms.RadioButton _rbResShiftRight;
      private System.Windows.Forms.Label _lblHelp;
      private System.Windows.Forms.CheckBox _chkSegApplyInProgress;
      private System.Windows.Forms.CheckBox _chkGrayApplyInProgress;
      private System.Windows.Forms.CheckBox _chkNoiseApplyInProgress;
      private System.Windows.Forms.CheckBox _chkResApplyInProgress;
   }
}