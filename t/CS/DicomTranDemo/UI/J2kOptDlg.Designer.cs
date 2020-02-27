namespace DicomTranDemo
{
   partial class J2kOptDlg
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(J2kOptDlg));
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.lblJ2KQFactor = new System.Windows.Forms.Label();
         this.lblJ2KCompressionRatio = new System.Windows.Forms.Label();
         this.lblJ2KTargetSize = new System.Windows.Forms.Label();
         this.txtCompressionRatio = new System.Windows.Forms.TextBox();
         this.txtQFactor = new System.Windows.Forms.TextBox();
         this.chkUseEPHMarker = new System.Windows.Forms.CheckBox();
         this.chkDerivedQuantization = new System.Windows.Forms.CheckBox();
         this.chkUseSOPMarker = new System.Windows.Forms.CheckBox();
         this.chkColorTransform = new System.Windows.Forms.CheckBox();
#if !LEADTOOLS_V19_OR_LATER
         this.txtExponent = new System.Windows.Forms.TextBox();
         this.txtCodeBlockHeight = new System.Windows.Forms.TextBox();
         this.txtCodeBlockWidth = new System.Windows.Forms.TextBox();
         this.txtMantissa = new System.Windows.Forms.TextBox();
         this.txtGuardBits = new System.Windows.Forms.TextBox();
         this.chkErrorResilience = new System.Windows.Forms.CheckBox();
         this.chkPredictableTermination = new System.Windows.Forms.CheckBox();
         this.chkVerticallyCausal = new System.Windows.Forms.CheckBox();
         this.chkTermination = new System.Windows.Forms.CheckBox();
         this.chkResetContext = new System.Windows.Forms.CheckBox();
         this.chkSelectiveACBypass = new System.Windows.Forms.CheckBox();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.groupBox2.SuspendLayout();
         this.label9 = new System.Windows.Forms.Label();
         this.label8 = new System.Windows.Forms.Label();
         this.label7 = new System.Windows.Forms.Label();
         this.label6 = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
#endif // #if !LEADTOOLS_V19_OR_LATER
         this.txtDecompLevel = new System.Windows.Forms.TextBox();
         this.txtTargetSize = new System.Windows.Forms.TextBox();
         this.cmbJ2KProgressionOrder = new System.Windows.Forms.ComboBox();
         this.cmbJ2kCompressionControl = new System.Windows.Forms.ComboBox();
         this.label4 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.btnOk = new System.Windows.Forms.Button();
         this.btnDefault = new System.Windows.Forms.Button();
         this.btnCancel = new System.Windows.Forms.Button();
         this.groupBox3 = new System.Windows.Forms.GroupBox();
         this.txtYTOSIZ = new System.Windows.Forms.TextBox();
         this.txtXTOSIZ = new System.Windows.Forms.TextBox();
         this.txtYTSIZ = new System.Windows.Forms.TextBox();
         this.txtXTSIZ = new System.Windows.Forms.TextBox();
         this.txtYOSIZ = new System.Windows.Forms.TextBox();
         this.txtXOSIZ = new System.Windows.Forms.TextBox();
         this.label15 = new System.Windows.Forms.Label();
         this.label14 = new System.Windows.Forms.Label();
         this.label13 = new System.Windows.Forms.Label();
         this.label12 = new System.Windows.Forms.Label();
         this.label11 = new System.Windows.Forms.Label();
         this.label10 = new System.Windows.Forms.Label();
         this.groupBox1.SuspendLayout();
         
         this.groupBox3.SuspendLayout();
         this.SuspendLayout();
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.lblJ2KQFactor);
         this.groupBox1.Controls.Add(this.lblJ2KCompressionRatio);
         this.groupBox1.Controls.Add(this.lblJ2KTargetSize);
         this.groupBox1.Controls.Add(this.txtCompressionRatio);
         this.groupBox1.Controls.Add(this.txtQFactor);
         this.groupBox1.Controls.Add(this.chkUseEPHMarker);
         this.groupBox1.Controls.Add(this.chkDerivedQuantization);
         this.groupBox1.Controls.Add(this.chkUseSOPMarker);
         this.groupBox1.Controls.Add(this.chkColorTransform);
#if !LEADTOOLS_V19_OR_LATER
         this.groupBox1.Controls.Add(this.txtExponent);
         this.groupBox1.Controls.Add(this.txtCodeBlockHeight);
         this.groupBox1.Controls.Add(this.txtCodeBlockWidth);
         this.groupBox1.Controls.Add(this.txtMantissa);
         this.groupBox1.Controls.Add(this.txtGuardBits);
         this.groupBox1.Controls.Add(this.label9);
         this.groupBox1.Controls.Add(this.label8);
         this.groupBox1.Controls.Add(this.label7);
         this.groupBox1.Controls.Add(this.label6);
         this.groupBox1.Controls.Add(this.label5);
#endif // #if !LEADTOOLS_V19_OR_LATER
         this.groupBox1.Controls.Add(this.txtDecompLevel);
         this.groupBox1.Controls.Add(this.txtTargetSize);
         this.groupBox1.Controls.Add(this.cmbJ2KProgressionOrder);
         this.groupBox1.Controls.Add(this.cmbJ2kCompressionControl);
         this.groupBox1.Controls.Add(this.label4);
         this.groupBox1.Controls.Add(this.label3);
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Location = new System.Drawing.Point(12, 12);
         this.groupBox1.Name = "groupBox1";
#if !LEADTOOLS_V19_OR_LATER
         this.groupBox1.Size = new System.Drawing.Size(299, 348);
#else
         this.groupBox1.Size = new System.Drawing.Size(299, 180);
#endif // #if !LEADTOOLS_V19_OR_LATER
         this.groupBox1.TabIndex = 0;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "General";
         // 
         // lblJ2KQFactor
         // 
         this.lblJ2KQFactor.AutoSize = true;
         this.lblJ2KQFactor.Location = new System.Drawing.Point(11, 55);
         this.lblJ2KQFactor.Name = "lblJ2KQFactor";
         this.lblJ2KQFactor.Size = new System.Drawing.Size(75, 13);
         this.lblJ2KQFactor.TabIndex = 6;
         this.lblJ2KQFactor.Text = "&Quality Factor:";
         // 
         // lblJ2KCompressionRatio
         // 
         this.lblJ2KCompressionRatio.AutoSize = true;
         this.lblJ2KCompressionRatio.Location = new System.Drawing.Point(11, 54);
         this.lblJ2KCompressionRatio.Name = "lblJ2KCompressionRatio";
         this.lblJ2KCompressionRatio.Size = new System.Drawing.Size(68, 13);
         this.lblJ2KCompressionRatio.TabIndex = 6;
         this.lblJ2KCompressionRatio.Text = "C&omp. Ratio:";
         // 
         // lblJ2KTargetSize
         // 
         this.lblJ2KTargetSize.AutoSize = true;
         this.lblJ2KTargetSize.Location = new System.Drawing.Point(11, 55);
         this.lblJ2KTargetSize.Name = "lblJ2KTargetSize";
         this.lblJ2KTargetSize.Size = new System.Drawing.Size(118, 13);
         this.lblJ2KTargetSize.TabIndex = 6;
         this.lblJ2KTargetSize.Text = "J2K Stream Si&ze(bytes):";
         // 
         // txtCompressionRatio
         // 
         this.txtCompressionRatio.Location = new System.Drawing.Point(158, 47);
         this.txtCompressionRatio.Name = "txtCompressionRatio";
         this.txtCompressionRatio.Size = new System.Drawing.Size(126, 20);
         this.txtCompressionRatio.TabIndex = 6;
         // 
         // txtQFactor
         // 
         this.txtQFactor.Enabled = false;
         this.txtQFactor.Location = new System.Drawing.Point(159, 48);
         this.txtQFactor.Name = "txtQFactor";
         this.txtQFactor.Size = new System.Drawing.Size(125, 20);
         this.txtQFactor.TabIndex = 6;
         // 
         // chkUseEPHMarker
         // 
         this.chkUseEPHMarker.AutoSize = true;
#if !LEADTOOLS_V19_OR_LATER
         this.chkUseEPHMarker.Location = new System.Drawing.Point(159, 316);
#else
         this.chkUseEPHMarker.Location = new System.Drawing.Point(159, 160);
#endif // #if !LEADTOOLS_V19_OR_LATER
         this.chkUseEPHMarker.Name = "chkUseEPHMarker";
         this.chkUseEPHMarker.Size = new System.Drawing.Size(106, 17);
         this.chkUseEPHMarker.TabIndex = 21;
         this.chkUseEPHMarker.Text = "Use EPH Mar&ker";
         this.chkUseEPHMarker.UseVisualStyleBackColor = true;
         // 
         // chkDerivedQuantization
         // 
         this.chkDerivedQuantization.AutoSize = true;
#if !LEADTOOLS_V19_OR_LATER
         this.chkDerivedQuantization.Location = new System.Drawing.Point(159, 282);
#else
         this.chkDerivedQuantization.Location = new System.Drawing.Point(159, 130);
#endif // #if !LEADTOOLS_V19_OR_LATER
         this.chkDerivedQuantization.Name = "chkDerivedQuantization";
         this.chkDerivedQuantization.Size = new System.Drawing.Size(125, 17);
         this.chkDerivedQuantization.TabIndex = 20;
         this.chkDerivedQuantization.Text = "Derived &Quantization";
         this.chkDerivedQuantization.UseVisualStyleBackColor = true;
         // 
         // chkUseSOPMarker
         // 
         this.chkUseSOPMarker.AutoSize = true;
#if !LEADTOOLS_V19_OR_LATER
         this.chkUseSOPMarker.Location = new System.Drawing.Point(13, 316);
#else
         this.chkUseSOPMarker.Location = new System.Drawing.Point(13, 160);
#endif // #if !LEADTOOLS_V19_OR_LATER
         this.chkUseSOPMarker.Name = "chkUseSOPMarker";
         this.chkUseSOPMarker.Size = new System.Drawing.Size(106, 17);
         this.chkUseSOPMarker.TabIndex = 19;
         this.chkUseSOPMarker.Text = "Use SOP Marke&r";
         this.chkUseSOPMarker.UseVisualStyleBackColor = true;
         // 
         // chkColorTransform
         // 
         this.chkColorTransform.AutoSize = true;
#if !LEADTOOLS_V19_OR_LATER
         this.chkColorTransform.Location = new System.Drawing.Point(13, 282);
#else
         this.chkColorTransform.Location = new System.Drawing.Point(13, 130);
#endif // #if !LEADTOOLS_V19_OR_LATER
         this.chkColorTransform.Name = "chkColorTransform";
         this.chkColorTransform.Size = new System.Drawing.Size(126, 17);
         this.chkColorTransform.TabIndex = 18;
         this.chkColorTransform.Text = "Use YUV &Colorspace";
         this.chkColorTransform.UseVisualStyleBackColor = true;
#if !LEADTOOLS_V19_OR_LATER
         // 
         // txtExponent
         // 
         this.txtExponent.Location = new System.Drawing.Point(158, 183);
         this.txtExponent.Name = "txtExponent";
         this.txtExponent.Size = new System.Drawing.Size(126, 20);
         this.txtExponent.TabIndex = 17;
         // 
         // txtCodeBlockHeight
         // 
         this.txtCodeBlockHeight.Location = new System.Drawing.Point(159, 237);
         this.txtCodeBlockHeight.Name = "txtCodeBlockHeight";
         this.txtCodeBlockHeight.Size = new System.Drawing.Size(126, 20);
         this.txtCodeBlockHeight.TabIndex = 16;
         // 
         // txtCodeBlockWidth
         // 
         this.txtCodeBlockWidth.Location = new System.Drawing.Point(159, 210);
         this.txtCodeBlockWidth.Name = "txtCodeBlockWidth";
         this.txtCodeBlockWidth.Size = new System.Drawing.Size(126, 20);
         this.txtCodeBlockWidth.TabIndex = 15;
         // 
         // txtMantissa
         // 
         this.txtMantissa.Location = new System.Drawing.Point(159, 156);
         this.txtMantissa.Name = "txtMantissa";
         this.txtMantissa.Size = new System.Drawing.Size(126, 20);
         this.txtMantissa.TabIndex = 14;
         // 
         // txtGuardBits
         // 
         this.txtGuardBits.Location = new System.Drawing.Point(159, 129);
         this.txtGuardBits.Name = "txtGuardBits";
         this.txtGuardBits.Size = new System.Drawing.Size(126, 20);
         this.txtGuardBits.TabIndex = 13;
#endif // #if !LEADTOOLS_V19_OR_LATER
         // 
         // txtDecompLevel
         // 
         this.txtDecompLevel.Location = new System.Drawing.Point(159, 102);
         this.txtDecompLevel.Name = "txtDecompLevel";
         this.txtDecompLevel.Size = new System.Drawing.Size(126, 20);
         this.txtDecompLevel.TabIndex = 12;
         // 
         // txtTargetSize
         // 
         this.txtTargetSize.Location = new System.Drawing.Point(159, 47);
         this.txtTargetSize.Name = "txtTargetSize";
         this.txtTargetSize.Size = new System.Drawing.Size(126, 20);
         this.txtTargetSize.TabIndex = 11;
         // 
         // cmbJ2KProgressionOrder
         // 
         this.cmbJ2KProgressionOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbJ2KProgressionOrder.FormattingEnabled = true;
         this.cmbJ2KProgressionOrder.Location = new System.Drawing.Point(159, 74);
         this.cmbJ2KProgressionOrder.Name = "cmbJ2KProgressionOrder";
         this.cmbJ2KProgressionOrder.Size = new System.Drawing.Size(126, 21);
         this.cmbJ2KProgressionOrder.TabIndex = 10;
         // 
         // cmbJ2kCompressionControl
         // 
         this.cmbJ2kCompressionControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbJ2kCompressionControl.FormattingEnabled = true;
         this.cmbJ2kCompressionControl.Location = new System.Drawing.Point(159, 19);
         this.cmbJ2kCompressionControl.Name = "cmbJ2kCompressionControl";
         this.cmbJ2kCompressionControl.Size = new System.Drawing.Size(126, 21);
         this.cmbJ2kCompressionControl.TabIndex = 9;
         this.cmbJ2kCompressionControl.SelectedIndexChanged += new System.EventHandler(this.cmbJ2kCompressionControl_SelectedIndexChanged);
#if !LEADTOOLS_V19_OR_LATER
         // 
         // label9
         // 
         this.label9.AutoSize = true;
         this.label9.Location = new System.Drawing.Point(10, 244);
         this.label9.Name = "label9";
         this.label9.Size = new System.Drawing.Size(129, 13);
         this.label9.TabIndex = 8;
         this.label9.Text = "Code Block &Height (2..64)";
         // 
         // label8
         // 
         this.label8.AutoSize = true;
         this.label8.Location = new System.Drawing.Point(10, 217);
         this.label8.Name = "label8";
         this.label8.Size = new System.Drawing.Size(126, 13);
         this.label8.TabIndex = 7;
         this.label8.Text = "Code Block &Width (2..64)";
         // 
         // label7
         // 
         this.label7.AutoSize = true;
         this.label7.Location = new System.Drawing.Point(10, 190);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(112, 13);
         this.label7.TabIndex = 6;
         this.label7.Text = "Base Expo&nent (0..16)";
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(10, 163);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(121, 13);
         this.label6.TabIndex = 5;
         this.label6.Text = "Base Mantiss&a (0..2047)";
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(10, 136);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(83, 13);
         this.label5.TabIndex = 4;
         this.label5.Text = "&Guard Bits (0..7)";
#endif // #if !LEADTOOLS_V19_OR_LATER
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(10, 109);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(106, 13);
         this.label4.TabIndex = 3;
         this.label4.Text = "Decomposition &Level";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(10, 82);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(91, 13);
         this.label3.TabIndex = 2;
         this.label3.Text = "Progressing O&rder";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(10, 29);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(103, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Compre&ssion Control";
         // 
         // btnOk
         // 
#if !LEADTOOLS_V19_OR_LATER
         this.btnOk.Location = new System.Drawing.Point(141, 375);
#else
         this.btnOk.Location = new System.Drawing.Point(141, 200);
#endif // #if !LEADTOOLS_V19_OR_LATER
         this.btnOk.Name = "btnOk";
         this.btnOk.Size = new System.Drawing.Size(75, 23);
         this.btnOk.TabIndex = 0;
         this.btnOk.Text = "OK";
         this.btnOk.UseVisualStyleBackColor = true;
         this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
         // 
         // btnDefault
         // 
#if !LEADTOOLS_V19_OR_LATER
         this.btnDefault.Location = new System.Drawing.Point(222, 375);
#else
         this.btnDefault.Location = new System.Drawing.Point(222, 200);
#endif // #if !LEADTOOLS_V19_OR_LATER
         this.btnDefault.Name = "btnDefault";
         this.btnDefault.Size = new System.Drawing.Size(75, 23);
         this.btnDefault.TabIndex = 2;
         this.btnDefault.Text = "De&fault";
         this.btnDefault.UseVisualStyleBackColor = true;
         this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
         // 
         // btnCancel
         // 
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
#if !LEADTOOLS_V19_OR_LATER
         this.btnCancel.Location = new System.Drawing.Point(303, 375);
#else
         this.btnCancel.Location = new System.Drawing.Point(303, 200);
#endif // #if !LEADTOOLS_V19_OR_LATER
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(75, 23);
         this.btnCancel.TabIndex = 3;
         this.btnCancel.Text = "Cancel";
         this.btnCancel.UseVisualStyleBackColor = true;
#if !LEADTOOLS_V19_OR_LATER
         // 
         // groupBox2
         // 
         this.groupBox2.Controls.Add(this.chkErrorResilience);
         this.groupBox2.Controls.Add(this.chkPredictableTermination);
         this.groupBox2.Controls.Add(this.chkVerticallyCausal);
         this.groupBox2.Controls.Add(this.chkTermination);
         this.groupBox2.Controls.Add(this.chkResetContext);
         this.groupBox2.Controls.Add(this.chkSelectiveACBypass);
         this.groupBox2.Location = new System.Drawing.Point(317, 12);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(179, 171);
         this.groupBox2.TabIndex = 4;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Arithmetic Encoder ";
         // 
         // chkErrorResilience
         // 
         this.chkErrorResilience.AutoSize = true;
         this.chkErrorResilience.Location = new System.Drawing.Point(6, 141);
         this.chkErrorResilience.Name = "chkErrorResilience";
         this.chkErrorResilience.Size = new System.Drawing.Size(142, 17);
         this.chkErrorResilience.TabIndex = 5;
         this.chkErrorResilience.Text = "&Error Resiliences Symbol";
         this.chkErrorResilience.UseVisualStyleBackColor = true;
         // 
         // chkPredictableTermination
         // 
         this.chkPredictableTermination.AutoSize = true;
         this.chkPredictableTermination.Location = new System.Drawing.Point(6, 117);
         this.chkPredictableTermination.Name = "chkPredictableTermination";
         this.chkPredictableTermination.Size = new System.Drawing.Size(134, 17);
         this.chkPredictableTermination.TabIndex = 4;
         this.chkPredictableTermination.Text = "Pre&dictableTermination";
         this.chkPredictableTermination.UseVisualStyleBackColor = true;
         // 
         // chkVerticallyCausal
         // 
         this.chkVerticallyCausal.AutoSize = true;
         this.chkVerticallyCausal.Location = new System.Drawing.Point(6, 94);
         this.chkVerticallyCausal.Name = "chkVerticallyCausal";
         this.chkVerticallyCausal.Size = new System.Drawing.Size(142, 17);
         this.chkVerticallyCausal.TabIndex = 3;
         this.chkVerticallyCausal.Text = "Vertically Causal C&ontext";
         this.chkVerticallyCausal.UseVisualStyleBackColor = true;
         // 
         // chkTermination
         // 
         this.chkTermination.AutoSize = true;
         this.chkTermination.Location = new System.Drawing.Point(6, 71);
         this.chkTermination.Name = "chkTermination";
         this.chkTermination.Size = new System.Drawing.Size(152, 17);
         this.chkTermination.TabIndex = 2;
         this.chkTermination.Text = "Ter&mination On Each Pass";
         this.chkTermination.UseVisualStyleBackColor = true;
         // 
         // chkResetContext
         // 
         this.chkResetContext.AutoSize = true;
         this.chkResetContext.Location = new System.Drawing.Point(6, 48);
         this.chkResetContext.Name = "chkResetContext";
         this.chkResetContext.Size = new System.Drawing.Size(166, 17);
         this.chkResetContext.TabIndex = 1;
         this.chkResetContext.Text = "Re&set Context On Boundaries";
         this.chkResetContext.UseVisualStyleBackColor = true;
         // 
         // chkSelectiveACBypass
         // 
         this.chkSelectiveACBypass.AutoSize = true;
         this.chkSelectiveACBypass.Location = new System.Drawing.Point(6, 25);
         this.chkSelectiveACBypass.Name = "chkSelectiveACBypass";
         this.chkSelectiveACBypass.Size = new System.Drawing.Size(124, 17);
         this.chkSelectiveACBypass.TabIndex = 0;
         this.chkSelectiveACBypass.Text = "Selective AC &Bypass";
         this.chkSelectiveACBypass.UseVisualStyleBackColor = true;
#endif // #if !LEADTOOLS_V19_OR_LATER
         // 
         // groupBox3
         // 
         this.groupBox3.Controls.Add(this.txtYTOSIZ);
         this.groupBox3.Controls.Add(this.txtXTOSIZ);
         this.groupBox3.Controls.Add(this.txtYTSIZ);
         this.groupBox3.Controls.Add(this.txtXTSIZ);
         this.groupBox3.Controls.Add(this.txtYOSIZ);
         this.groupBox3.Controls.Add(this.txtXOSIZ);
         this.groupBox3.Controls.Add(this.label15);
         this.groupBox3.Controls.Add(this.label14);
         this.groupBox3.Controls.Add(this.label13);
         this.groupBox3.Controls.Add(this.label12);
         this.groupBox3.Controls.Add(this.label11);
         this.groupBox3.Controls.Add(this.label10);
#if !LEADTOOLS_V19_OR_LATER
         this.groupBox3.Location = new System.Drawing.Point(317, 189);
         this.groupBox3.Size = new System.Drawing.Size(179, 171);
#else
         this.groupBox3.Location = new System.Drawing.Point(317, 12);
         this.groupBox3.Size = new System.Drawing.Size(179, 180);
#endif // #if !LEADTOOLS_V19_OR_LATER
         this.groupBox3.Name = "groupBox3";
         this.groupBox3.TabIndex = 5;
         this.groupBox3.TabStop = false;
         this.groupBox3.Text = "Offset and Tiling";
         // 
         // txtYTOSIZ
         // 
         this.txtYTOSIZ.Location = new System.Drawing.Point(85, 142);
         this.txtYTOSIZ.Name = "txtYTOSIZ";
         this.txtYTOSIZ.Size = new System.Drawing.Size(63, 20);
         this.txtYTOSIZ.TabIndex = 11;
         // 
         // txtXTOSIZ
         // 
         this.txtXTOSIZ.Location = new System.Drawing.Point(85, 120);
         this.txtXTOSIZ.Name = "txtXTOSIZ";
         this.txtXTOSIZ.Size = new System.Drawing.Size(63, 20);
         this.txtXTOSIZ.TabIndex = 10;
         // 
         // txtYTSIZ
         // 
         this.txtYTSIZ.Location = new System.Drawing.Point(85, 94);
         this.txtYTSIZ.Name = "txtYTSIZ";
         this.txtYTSIZ.Size = new System.Drawing.Size(63, 20);
         this.txtYTSIZ.TabIndex = 9;
         // 
         // txtXTSIZ
         // 
         this.txtXTSIZ.Location = new System.Drawing.Point(85, 68);
         this.txtXTSIZ.Name = "txtXTSIZ";
         this.txtXTSIZ.Size = new System.Drawing.Size(63, 20);
         this.txtXTSIZ.TabIndex = 8;
         // 
         // txtYOSIZ
         // 
         this.txtYOSIZ.Location = new System.Drawing.Point(85, 42);
         this.txtYOSIZ.Name = "txtYOSIZ";
         this.txtYOSIZ.Size = new System.Drawing.Size(63, 20);
         this.txtYOSIZ.TabIndex = 7;
         // 
         // txtXOSIZ
         // 
         this.txtXOSIZ.Location = new System.Drawing.Point(85, 19);
         this.txtXOSIZ.Name = "txtXOSIZ";
         this.txtXOSIZ.Size = new System.Drawing.Size(63, 20);
         this.txtXOSIZ.TabIndex = 6;
         // 
         // label15
         // 
         this.label15.AutoSize = true;
         this.label15.Location = new System.Drawing.Point(20, 149);
         this.label15.Name = "label15";
         this.label15.Size = new System.Drawing.Size(41, 13);
         this.label15.TabIndex = 5;
         this.label15.Text = "YTOsi&z";
         // 
         // label14
         // 
         this.label14.AutoSize = true;
         this.label14.Location = new System.Drawing.Point(20, 127);
         this.label14.Name = "label14";
         this.label14.Size = new System.Drawing.Size(41, 13);
         this.label14.TabIndex = 4;
         this.label14.Text = "XTOsi&z";
         // 
         // label13
         // 
         this.label13.AutoSize = true;
         this.label13.Location = new System.Drawing.Point(20, 101);
         this.label13.Name = "label13";
         this.label13.Size = new System.Drawing.Size(33, 13);
         this.label13.TabIndex = 3;
         this.label13.Text = "YTs&iz";
         // 
         // label12
         // 
         this.label12.AutoSize = true;
         this.label12.Location = new System.Drawing.Point(20, 75);
         this.label12.Name = "label12";
         this.label12.Size = new System.Drawing.Size(33, 13);
         this.label12.TabIndex = 2;
         this.label12.Text = "X&Tsiz";
         // 
         // label11
         // 
         this.label11.AutoSize = true;
         this.label11.Location = new System.Drawing.Point(20, 49);
         this.label11.Name = "label11";
         this.label11.Size = new System.Drawing.Size(34, 13);
         this.label11.TabIndex = 1;
         this.label11.Text = "&YOsiz";
         // 
         // label10
         // 
         this.label10.AutoSize = true;
         this.label10.Location = new System.Drawing.Point(20, 26);
         this.label10.Name = "label10";
         this.label10.Size = new System.Drawing.Size(34, 13);
         this.label10.TabIndex = 0;
         this.label10.Text = "&XOsiz";
         // 
         // J2kOptDlg
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.btnCancel;
#if !LEADTOOLS_V19_OR_LATER
         this.ClientSize = new System.Drawing.Size(508, 410);
#else
         this.ClientSize = new System.Drawing.Size(508, 230);
#endif // #if !LEADTOOLS_V19_OR_LATER
         this.Controls.Add(this.groupBox3);
#if !LEADTOOLS_V19_OR_LATER
         this.Controls.Add(this.groupBox2);
         this.groupBox2.ResumeLayout(false);
         this.groupBox2.PerformLayout();
#endif // #if !LEADTOOLS_V19_OR_LATER
         this.Controls.Add(this.btnCancel);
         this.Controls.Add(this.btnDefault);
         this.Controls.Add(this.btnOk);
         this.Controls.Add(this.groupBox1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "J2kOptDlg";
         this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
         this.Text = "JPEG 2000 options";
         this.Load += new System.EventHandler(this.J2kOptDlg_Load);
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.groupBox3.ResumeLayout(false);
         this.groupBox3.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.Label label1;
#if !LEADTOOLS_V19_OR_LATER
      private System.Windows.Forms.TextBox txtExponent;
      private System.Windows.Forms.TextBox txtCodeBlockHeight;
      private System.Windows.Forms.TextBox txtCodeBlockWidth;
      private System.Windows.Forms.TextBox txtMantissa;
      private System.Windows.Forms.TextBox txtGuardBits;
      private System.Windows.Forms.CheckBox chkErrorResilience;
      private System.Windows.Forms.CheckBox chkPredictableTermination;
      private System.Windows.Forms.CheckBox chkVerticallyCausal;
      private System.Windows.Forms.CheckBox chkTermination;
      private System.Windows.Forms.CheckBox chkSelectiveACBypass;
      private System.Windows.Forms.CheckBox chkResetContext;
      private System.Windows.Forms.Label label9;
      private System.Windows.Forms.Label label8;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.GroupBox groupBox2;
#endif // #if !LEADTOOLS_V19_OR_LATER
      private System.Windows.Forms.TextBox txtDecompLevel;
      private System.Windows.Forms.TextBox txtTargetSize;
      private System.Windows.Forms.ComboBox cmbJ2KProgressionOrder;
      private System.Windows.Forms.ComboBox cmbJ2kCompressionControl;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.CheckBox chkUseEPHMarker;
      private System.Windows.Forms.CheckBox chkDerivedQuantization;
      private System.Windows.Forms.CheckBox chkUseSOPMarker;
      private System.Windows.Forms.CheckBox chkColorTransform;
      private System.Windows.Forms.Button btnOk;
      private System.Windows.Forms.Button btnDefault;
      private System.Windows.Forms.Button btnCancel;
      private System.Windows.Forms.GroupBox groupBox3;
      private System.Windows.Forms.TextBox txtYTOSIZ;
      private System.Windows.Forms.TextBox txtXTOSIZ;
      private System.Windows.Forms.TextBox txtYTSIZ;
      private System.Windows.Forms.TextBox txtXTSIZ;
      private System.Windows.Forms.TextBox txtYOSIZ;
      private System.Windows.Forms.TextBox txtXOSIZ;
      private System.Windows.Forms.Label label15;
      private System.Windows.Forms.Label label14;
      private System.Windows.Forms.Label label13;
      private System.Windows.Forms.Label label12;
      private System.Windows.Forms.Label label11;
      private System.Windows.Forms.Label label10;
      private System.Windows.Forms.TextBox txtQFactor;
      private System.Windows.Forms.TextBox txtCompressionRatio;
      private System.Windows.Forms.Label lblJ2KTargetSize;
      private System.Windows.Forms.Label lblJ2KCompressionRatio;
      private System.Windows.Forms.Label lblJ2KQFactor;
   }
}