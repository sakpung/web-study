Namespace DicomTranDemo
   Partial Public Class J2kOptDlg
      ''' <summary>
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.IContainer = Nothing

      ''' <summary>
      ''' Clean up any resources being used.
      ''' </summary>
      ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      Protected Overrides Sub Dispose(ByVal disposing As Boolean)
         If disposing AndAlso (Not components Is Nothing) Then
            components.Dispose()
         End If
         MyBase.Dispose(disposing)
      End Sub

#Region "Windows Form Designer generated code"

      ''' <summary>
      ''' Required method for Designer support - do not modify
      ''' the contents of this method with the code editor.
      ''' </summary>
      Private Sub InitializeComponent()
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(J2kOptDlg))
         Me.groupBox1 = New System.Windows.Forms.GroupBox()
         Me.lblJ2KQFactor = New System.Windows.Forms.Label()
         Me.lblJ2KCompressionRatio = New System.Windows.Forms.Label()
         Me.lblJ2KTargetSize = New System.Windows.Forms.Label()
         Me.txtCompressionRatio = New System.Windows.Forms.TextBox()
         Me.txtQFactor = New System.Windows.Forms.TextBox()
         Me.chkUseEPHMarker = New System.Windows.Forms.CheckBox()
         Me.chkDerivedQuantization = New System.Windows.Forms.CheckBox()
         Me.chkUseSOPMarker = New System.Windows.Forms.CheckBox()
         Me.chkColorTransform = New System.Windows.Forms.CheckBox()
#If (Not LEADTOOLS_V19_OR_LATER) Then
         Me.txtExponent = New System.Windows.Forms.TextBox()
         Me.txtCodeBlockHeight = New System.Windows.Forms.TextBox()
         Me.txtCodeBlockWidth = New System.Windows.Forms.TextBox()
         Me.txtMantissa = New System.Windows.Forms.TextBox()
         Me.txtGuardBits = New System.Windows.Forms.TextBox()
         Me.chkErrorResilience = New System.Windows.Forms.CheckBox()
         Me.chkPredictableTermination = New System.Windows.Forms.CheckBox()
         Me.chkVerticallyCausal = New System.Windows.Forms.CheckBox()
         Me.chkTermination = New System.Windows.Forms.CheckBox()
         Me.chkResetContext = New System.Windows.Forms.CheckBox()
         Me.chkSelectiveACBypass = New System.Windows.Forms.CheckBox()
         Me.groupBox2 = New System.Windows.Forms.GroupBox()
         Me.groupBox2.SuspendLayout()
         Me.label9 = New System.Windows.Forms.Label()
         Me.label8 = New System.Windows.Forms.Label()
         Me.label7 = New System.Windows.Forms.Label()
         Me.label6 = New System.Windows.Forms.Label()
         Me.label5 = New System.Windows.Forms.Label()
#End If ' #If Not LEADTOOLS_V19_OR_LATER
         Me.txtDecompLevel = New System.Windows.Forms.TextBox()
         Me.txtTargetSize = New System.Windows.Forms.TextBox()
         Me.cmbJ2KProgressionOrder = New System.Windows.Forms.ComboBox()
         Me.cmbJ2kCompressionControl = New System.Windows.Forms.ComboBox()
         Me.label4 = New System.Windows.Forms.Label()
         Me.label3 = New System.Windows.Forms.Label()
         Me.label1 = New System.Windows.Forms.Label()
         Me.btnOk = New System.Windows.Forms.Button()
         Me.btnDefault = New System.Windows.Forms.Button()
         Me.btnCancel = New System.Windows.Forms.Button()
         Me.groupBox3 = New System.Windows.Forms.GroupBox()
         Me.txtYTOSIZ = New System.Windows.Forms.TextBox()
         Me.txtXTOSIZ = New System.Windows.Forms.TextBox()
         Me.txtYTSIZ = New System.Windows.Forms.TextBox()
         Me.txtXTSIZ = New System.Windows.Forms.TextBox()
         Me.txtYOSIZ = New System.Windows.Forms.TextBox()
         Me.txtXOSIZ = New System.Windows.Forms.TextBox()
         Me.label15 = New System.Windows.Forms.Label()
         Me.label14 = New System.Windows.Forms.Label()
         Me.label13 = New System.Windows.Forms.Label()
         Me.label12 = New System.Windows.Forms.Label()
         Me.label11 = New System.Windows.Forms.Label()
         Me.label10 = New System.Windows.Forms.Label()
         Me.groupBox1.SuspendLayout()

         Me.groupBox3.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' groupBox1
         ' 
         Me.groupBox1.Controls.Add(Me.lblJ2KQFactor)
         Me.groupBox1.Controls.Add(Me.lblJ2KCompressionRatio)
         Me.groupBox1.Controls.Add(Me.lblJ2KTargetSize)
         Me.groupBox1.Controls.Add(Me.txtCompressionRatio)
         Me.groupBox1.Controls.Add(Me.txtQFactor)
         Me.groupBox1.Controls.Add(Me.chkUseEPHMarker)
         Me.groupBox1.Controls.Add(Me.chkDerivedQuantization)
         Me.groupBox1.Controls.Add(Me.chkUseSOPMarker)
         Me.groupBox1.Controls.Add(Me.chkColorTransform)
#If Not LEADTOOLS_V19_OR_LATER Then
         Me.groupBox1.Controls.Add(Me.txtExponent)
         Me.groupBox1.Controls.Add(Me.txtCodeBlockHeight)
         Me.groupBox1.Controls.Add(Me.txtCodeBlockWidth)
         Me.groupBox1.Controls.Add(Me.txtMantissa)
         Me.groupBox1.Controls.Add(Me.txtGuardBits)
         Me.groupBox1.Controls.Add(Me.label9)
         Me.groupBox1.Controls.Add(Me.label8)
         Me.groupBox1.Controls.Add(Me.label7)
         Me.groupBox1.Controls.Add(Me.label6)
         Me.groupBox1.Controls.Add(Me.label5)
#End If ' #If Not LEADTOOLS_V19_OR_LATER
         Me.groupBox1.Controls.Add(Me.txtDecompLevel)
         Me.groupBox1.Controls.Add(Me.txtTargetSize)
         Me.groupBox1.Controls.Add(Me.cmbJ2KProgressionOrder)
         Me.groupBox1.Controls.Add(Me.cmbJ2kCompressionControl)
         Me.groupBox1.Controls.Add(Me.label4)
         Me.groupBox1.Controls.Add(Me.label3)
         Me.groupBox1.Controls.Add(Me.label1)
         Me.groupBox1.Location = New System.Drawing.Point(12, 12)
         Me.groupBox1.Name = "groupBox1"
#If Not LEADTOOLS_V19_OR_LATER Then
         Me.groupBox1.Size = New System.Drawing.Size(299, 348)
#Else
         Me.groupBox1.Size = New System.Drawing.Size(299, 180)
#End If ' #If Not LEADTOOLS_V19_OR_LATER
         Me.groupBox1.TabIndex = 0
         Me.groupBox1.TabStop = False
         Me.groupBox1.Text = "General"
         ' 
         ' lblJ2KQFactor
         ' 
         Me.lblJ2KQFactor.AutoSize = True
         Me.lblJ2KQFactor.Location = New System.Drawing.Point(11, 55)
         Me.lblJ2KQFactor.Name = "lblJ2KQFactor"
         Me.lblJ2KQFactor.Size = New System.Drawing.Size(75, 13)
         Me.lblJ2KQFactor.TabIndex = 6
         Me.lblJ2KQFactor.Text = "&Quality Factor:"
         ' 
         ' lblJ2KCompressionRatio
         ' 
         Me.lblJ2KCompressionRatio.AutoSize = True
         Me.lblJ2KCompressionRatio.Location = New System.Drawing.Point(11, 54)
         Me.lblJ2KCompressionRatio.Name = "lblJ2KCompressionRatio"
         Me.lblJ2KCompressionRatio.Size = New System.Drawing.Size(68, 13)
         Me.lblJ2KCompressionRatio.TabIndex = 6
         Me.lblJ2KCompressionRatio.Text = "C&omp. Ratio:"
         ' 
         ' lblJ2KTargetSize
         ' 
         Me.lblJ2KTargetSize.AutoSize = True
         Me.lblJ2KTargetSize.Location = New System.Drawing.Point(11, 55)
         Me.lblJ2KTargetSize.Name = "lblJ2KTargetSize"
         Me.lblJ2KTargetSize.Size = New System.Drawing.Size(118, 13)
         Me.lblJ2KTargetSize.TabIndex = 6
         Me.lblJ2KTargetSize.Text = "J2K Stream Si&ze(bytes):"
         ' 
         ' txtCompressionRatio
         ' 
         Me.txtCompressionRatio.Location = New System.Drawing.Point(158, 47)
         Me.txtCompressionRatio.Name = "txtCompressionRatio"
         Me.txtCompressionRatio.Size = New System.Drawing.Size(126, 20)
         Me.txtCompressionRatio.TabIndex = 6
         ' 
         ' txtQFactor
         ' 
         Me.txtQFactor.Enabled = False
         Me.txtQFactor.Location = New System.Drawing.Point(159, 48)
         Me.txtQFactor.Name = "txtQFactor"
         Me.txtQFactor.Size = New System.Drawing.Size(125, 20)
         Me.txtQFactor.TabIndex = 6
         ' 
         ' chkUseEPHMarker
         ' 
         Me.chkUseEPHMarker.AutoSize = True
#If Not LEADTOOLS_V19_OR_LATER Then
         Me.chkUseEPHMarker.Location = New System.Drawing.Point(159, 316)
#Else
         Me.chkUseEPHMarker.Location = New System.Drawing.Point(159, 160)
#End If ' #If Not LEADTOOLS_V19_OR_LATER
         Me.chkUseEPHMarker.Name = "chkUseEPHMarker"
         Me.chkUseEPHMarker.Size = New System.Drawing.Size(106, 17)
         Me.chkUseEPHMarker.TabIndex = 21
         Me.chkUseEPHMarker.Text = "Use EPH Mar&ker"
         Me.chkUseEPHMarker.UseVisualStyleBackColor = True
         ' 
         ' chkDerivedQuantization
         ' 
         Me.chkDerivedQuantization.AutoSize = True
#If Not LEADTOOLS_V19_OR_LATER Then
         Me.chkDerivedQuantization.Location = New System.Drawing.Point(159, 282)
#Else
         Me.chkDerivedQuantization.Location = New System.Drawing.Point(159, 130)
#End If ' #If Not LEADTOOLS_V19_OR_LATER
         Me.chkDerivedQuantization.Name = "chkDerivedQuantization"
         Me.chkDerivedQuantization.Size = New System.Drawing.Size(125, 17)
         Me.chkDerivedQuantization.TabIndex = 20
         Me.chkDerivedQuantization.Text = "Derived &Quantization"
         Me.chkDerivedQuantization.UseVisualStyleBackColor = True
         ' 
         ' chkUseSOPMarker
         ' 
         Me.chkUseSOPMarker.AutoSize = True
#If Not LEADTOOLS_V19_OR_LATER Then
         Me.chkUseSOPMarker.Location = New System.Drawing.Point(13, 316)
#Else
         Me.chkUseSOPMarker.Location = New System.Drawing.Point(13, 160)
#End If ' #If Not LEADTOOLS_V19_OR_LATER
         Me.chkUseSOPMarker.Name = "chkUseSOPMarker"
         Me.chkUseSOPMarker.Size = New System.Drawing.Size(106, 17)
         Me.chkUseSOPMarker.TabIndex = 19
         Me.chkUseSOPMarker.Text = "Use SOP Marke&r"
         Me.chkUseSOPMarker.UseVisualStyleBackColor = True
         ' 
         ' chkColorTransform
         ' 
         Me.chkColorTransform.AutoSize = True
#If Not LEADTOOLS_V19_OR_LATER Then
         Me.chkColorTransform.Location = New System.Drawing.Point(13, 282)
#Else
         Me.chkColorTransform.Location = New System.Drawing.Point(13, 130)
#End If ' #If Not LEADTOOLS_V19_OR_LATER
         Me.chkColorTransform.Name = "chkColorTransform"
         Me.chkColorTransform.Size = New System.Drawing.Size(126, 17)
         Me.chkColorTransform.TabIndex = 18
         Me.chkColorTransform.Text = "Use YUV &Colorspace"
         Me.chkColorTransform.UseVisualStyleBackColor = True
#If Not LEADTOOLS_V19_OR_LATER Then
         ' 
         ' txtExponent
         ' 
         Me.txtExponent.Location = New System.Drawing.Point(158, 183)
         Me.txtExponent.Name = "txtExponent"
         Me.txtExponent.Size = New System.Drawing.Size(126, 20)
         Me.txtExponent.TabIndex = 17
         ' 
         ' txtCodeBlockHeight
         ' 
         Me.txtCodeBlockHeight.Location = New System.Drawing.Point(159, 237)
         Me.txtCodeBlockHeight.Name = "txtCodeBlockHeight"
         Me.txtCodeBlockHeight.Size = New System.Drawing.Size(126, 20)
         Me.txtCodeBlockHeight.TabIndex = 16
         ' 
         ' txtCodeBlockWidth
         ' 
         Me.txtCodeBlockWidth.Location = New System.Drawing.Point(159, 210)
         Me.txtCodeBlockWidth.Name = "txtCodeBlockWidth"
         Me.txtCodeBlockWidth.Size = New System.Drawing.Size(126, 20)
         Me.txtCodeBlockWidth.TabIndex = 15
         ' 
         ' txtMantissa
         ' 
         Me.txtMantissa.Location = New System.Drawing.Point(159, 156)
         Me.txtMantissa.Name = "txtMantissa"
         Me.txtMantissa.Size = New System.Drawing.Size(126, 20)
         Me.txtMantissa.TabIndex = 14
         ' 
         ' txtGuardBits
         ' 
         Me.txtGuardBits.Location = New System.Drawing.Point(159, 129)
         Me.txtGuardBits.Name = "txtGuardBits"
         Me.txtGuardBits.Size = New System.Drawing.Size(126, 20)
         Me.txtGuardBits.TabIndex = 13
#End If ' #If Not LEADTOOLS_V19_OR_LATER
         ' 
         ' txtDecompLevel
         ' 
         Me.txtDecompLevel.Location = New System.Drawing.Point(159, 102)
         Me.txtDecompLevel.Name = "txtDecompLevel"
         Me.txtDecompLevel.Size = New System.Drawing.Size(126, 20)
         Me.txtDecompLevel.TabIndex = 12
         ' 
         ' txtTargetSize
         ' 
         Me.txtTargetSize.Location = New System.Drawing.Point(159, 47)
         Me.txtTargetSize.Name = "txtTargetSize"
         Me.txtTargetSize.Size = New System.Drawing.Size(126, 20)
         Me.txtTargetSize.TabIndex = 11
         ' 
         ' cmbJ2KProgressionOrder
         ' 
         Me.cmbJ2KProgressionOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me.cmbJ2KProgressionOrder.FormattingEnabled = True
         Me.cmbJ2KProgressionOrder.Location = New System.Drawing.Point(159, 74)
         Me.cmbJ2KProgressionOrder.Name = "cmbJ2KProgressionOrder"
         Me.cmbJ2KProgressionOrder.Size = New System.Drawing.Size(126, 21)
         Me.cmbJ2KProgressionOrder.TabIndex = 10
         ' 
         ' cmbJ2kCompressionControl
         ' 
         Me.cmbJ2kCompressionControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me.cmbJ2kCompressionControl.FormattingEnabled = True
         Me.cmbJ2kCompressionControl.Location = New System.Drawing.Point(159, 19)
         Me.cmbJ2kCompressionControl.Name = "cmbJ2kCompressionControl"
         Me.cmbJ2kCompressionControl.Size = New System.Drawing.Size(126, 21)
         Me.cmbJ2kCompressionControl.TabIndex = 9
         '		 Me.cmbJ2kCompressionControl.SelectedIndexChanged += New System.EventHandler(Me.cmbJ2kCompressionControl_SelectedIndexChanged);
#If Not LEADTOOLS_V19_OR_LATER Then
         ' 
         ' label9
         ' 
         Me.label9.AutoSize = True
         Me.label9.Location = New System.Drawing.Point(10, 244)
         Me.label9.Name = "label9"
         Me.label9.Size = New System.Drawing.Size(129, 13)
         Me.label9.TabIndex = 8
         Me.label9.Text = "Code Block &Height (2..64)"
         ' 
         ' label8
         ' 
         Me.label8.AutoSize = True
         Me.label8.Location = New System.Drawing.Point(10, 217)
         Me.label8.Name = "label8"
         Me.label8.Size = New System.Drawing.Size(126, 13)
         Me.label8.TabIndex = 7
         Me.label8.Text = "Code Block &Width (2..64)"
         ' 
         ' label7
         ' 
         Me.label7.AutoSize = True
         Me.label7.Location = New System.Drawing.Point(10, 190)
         Me.label7.Name = "label7"
         Me.label7.Size = New System.Drawing.Size(112, 13)
         Me.label7.TabIndex = 6
         Me.label7.Text = "Base Expo&nent (0..16)"
         ' 
         ' label6
         ' 
         Me.label6.AutoSize = True
         Me.label6.Location = New System.Drawing.Point(10, 163)
         Me.label6.Name = "label6"
         Me.label6.Size = New System.Drawing.Size(121, 13)
         Me.label6.TabIndex = 5
         Me.label6.Text = "Base Mantiss&a (0..2047)"
         ' 
         ' label5
         ' 
         Me.label5.AutoSize = True
         Me.label5.Location = New System.Drawing.Point(10, 136)
         Me.label5.Name = "label5"
         Me.label5.Size = New System.Drawing.Size(83, 13)
         Me.label5.TabIndex = 4
         Me.label5.Text = "&Guard Bits (0..7)"
#End If ' #If Not LEADTOOLS_V19_OR_LATER
         ' 
         ' label4
         ' 
         Me.label4.AutoSize = True
         Me.label4.Location = New System.Drawing.Point(10, 109)
         Me.label4.Name = "label4"
         Me.label4.Size = New System.Drawing.Size(106, 13)
         Me.label4.TabIndex = 3
         Me.label4.Text = "Decomposition &Level"
         ' 
         ' label3
         ' 
         Me.label3.AutoSize = True
         Me.label3.Location = New System.Drawing.Point(10, 82)
         Me.label3.Name = "label3"
         Me.label3.Size = New System.Drawing.Size(91, 13)
         Me.label3.TabIndex = 2
         Me.label3.Text = "Progressing O&rder"
         ' 
         ' label1
         ' 
         Me.label1.AutoSize = True
         Me.label1.Location = New System.Drawing.Point(10, 29)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(103, 13)
         Me.label1.TabIndex = 0
         Me.label1.Text = "Compre&ssion Control"
         ' 
         ' btnOk
         ' 
#If Not LEADTOOLS_V19_OR_LATER Then
         Me.btnOk.Location = New System.Drawing.Point(141, 375)
#Else
         Me.btnOk.Location = New System.Drawing.Point(141, 200)
#End If ' #If Not LEADTOOLS_V19_OR_LATER
         Me.btnOk.Name = "btnOk"
         Me.btnOk.Size = New System.Drawing.Size(75, 23)
         Me.btnOk.TabIndex = 0
         Me.btnOk.Text = "OK"
         Me.btnOk.UseVisualStyleBackColor = True
         '		 Me.btnOk.Click += New System.EventHandler(Me.btnOk_Click);
         ' 
         ' btnDefault
         ' 
#If Not LEADTOOLS_V19_OR_LATER Then
         Me.btnDefault.Location = New System.Drawing.Point(222, 375)
#Else
         Me.btnDefault.Location = New System.Drawing.Point(222, 200)
#End If ' #If Not LEADTOOLS_V19_OR_LATER
         Me.btnDefault.Name = "btnDefault"
         Me.btnDefault.Size = New System.Drawing.Size(75, 23)
         Me.btnDefault.TabIndex = 2
         Me.btnDefault.Text = "De&fault"
         Me.btnDefault.UseVisualStyleBackColor = True
         '		 Me.btnDefault.Click += New System.EventHandler(Me.btnDefault_Click);
         ' 
         ' btnCancel
         ' 
         Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
#If Not LEADTOOLS_V19_OR_LATER Then
         Me.btnCancel.Location = New System.Drawing.Point(303, 375)
#Else
         Me.btnCancel.Location = New System.Drawing.Point(303, 200)
#End If ' #If Not LEADTOOLS_V19_OR_LATER
         Me.btnCancel.Name = "btnCancel"
         Me.btnCancel.Size = New System.Drawing.Size(75, 23)
         Me.btnCancel.TabIndex = 3
         Me.btnCancel.Text = "Cancel"
         Me.btnCancel.UseVisualStyleBackColor = True
#If Not LEADTOOLS_V19_OR_LATER Then
         ' 
         ' groupBox2
         ' 
         Me.groupBox2.Controls.Add(Me.chkErrorResilience)
         Me.groupBox2.Controls.Add(Me.chkPredictableTermination)
         Me.groupBox2.Controls.Add(Me.chkVerticallyCausal)
         Me.groupBox2.Controls.Add(Me.chkTermination)
         Me.groupBox2.Controls.Add(Me.chkResetContext)
         Me.groupBox2.Controls.Add(Me.chkSelectiveACBypass)
         Me.groupBox2.Location = New System.Drawing.Point(317, 12)
         Me.groupBox2.Name = "groupBox2"
         Me.groupBox2.Size = New System.Drawing.Size(179, 171)
         Me.groupBox2.TabIndex = 4
         Me.groupBox2.TabStop = False
         Me.groupBox2.Text = "Arithmetic Encoder "
         ' 
         ' chkErrorResilience
         ' 
         Me.chkErrorResilience.AutoSize = True
         Me.chkErrorResilience.Location = New System.Drawing.Point(6, 141)
         Me.chkErrorResilience.Name = "chkErrorResilience"
         Me.chkErrorResilience.Size = New System.Drawing.Size(142, 17)
         Me.chkErrorResilience.TabIndex = 5
         Me.chkErrorResilience.Text = "&Error Resiliences Symbol"
         Me.chkErrorResilience.UseVisualStyleBackColor = True
         ' 
         ' chkPredictableTermination
         ' 
         Me.chkPredictableTermination.AutoSize = True
         Me.chkPredictableTermination.Location = New System.Drawing.Point(6, 117)
         Me.chkPredictableTermination.Name = "chkPredictableTermination"
         Me.chkPredictableTermination.Size = New System.Drawing.Size(134, 17)
         Me.chkPredictableTermination.TabIndex = 4
         Me.chkPredictableTermination.Text = "Pre&dictableTermination"
         Me.chkPredictableTermination.UseVisualStyleBackColor = True
         ' 
         ' chkVerticallyCausal
         ' 
         Me.chkVerticallyCausal.AutoSize = True
         Me.chkVerticallyCausal.Location = New System.Drawing.Point(6, 94)
         Me.chkVerticallyCausal.Name = "chkVerticallyCausal"
         Me.chkVerticallyCausal.Size = New System.Drawing.Size(142, 17)
         Me.chkVerticallyCausal.TabIndex = 3
         Me.chkVerticallyCausal.Text = "Vertically Causal C&ontext"
         Me.chkVerticallyCausal.UseVisualStyleBackColor = True
         ' 
         ' chkTermination
         ' 
         Me.chkTermination.AutoSize = True
         Me.chkTermination.Location = New System.Drawing.Point(6, 71)
         Me.chkTermination.Name = "chkTermination"
         Me.chkTermination.Size = New System.Drawing.Size(152, 17)
         Me.chkTermination.TabIndex = 2
         Me.chkTermination.Text = "Ter&mination On Each Pass"
         Me.chkTermination.UseVisualStyleBackColor = True
         ' 
         ' chkResetContext
         ' 
         Me.chkResetContext.AutoSize = True
         Me.chkResetContext.Location = New System.Drawing.Point(6, 48)
         Me.chkResetContext.Name = "chkResetContext"
         Me.chkResetContext.Size = New System.Drawing.Size(166, 17)
         Me.chkResetContext.TabIndex = 1
         Me.chkResetContext.Text = "Re&set Context On Boundaries"
         Me.chkResetContext.UseVisualStyleBackColor = True
         ' 
         ' chkSelectiveACBypass
         ' 
         Me.chkSelectiveACBypass.AutoSize = True
         Me.chkSelectiveACBypass.Location = New System.Drawing.Point(6, 25)
         Me.chkSelectiveACBypass.Name = "chkSelectiveACBypass"
         Me.chkSelectiveACBypass.Size = New System.Drawing.Size(124, 17)
         Me.chkSelectiveACBypass.TabIndex = 0
         Me.chkSelectiveACBypass.Text = "Selective AC &Bypass"
         Me.chkSelectiveACBypass.UseVisualStyleBackColor = True
#End If ' #If Not LEADTOOLS_V19_OR_LATER
         ' 
         ' groupBox3
         ' 
         Me.groupBox3.Controls.Add(Me.txtYTOSIZ)
         Me.groupBox3.Controls.Add(Me.txtXTOSIZ)
         Me.groupBox3.Controls.Add(Me.txtYTSIZ)
         Me.groupBox3.Controls.Add(Me.txtXTSIZ)
         Me.groupBox3.Controls.Add(Me.txtYOSIZ)
         Me.groupBox3.Controls.Add(Me.txtXOSIZ)
         Me.groupBox3.Controls.Add(Me.label15)
         Me.groupBox3.Controls.Add(Me.label14)
         Me.groupBox3.Controls.Add(Me.label13)
         Me.groupBox3.Controls.Add(Me.label12)
         Me.groupBox3.Controls.Add(Me.label11)
         Me.groupBox3.Controls.Add(Me.label10)
#If (Not LEADTOOLS_V19_OR_LATER) Then
         Me.groupBox3.Location = New System.Drawing.Point(317, 189)
         Me.groupBox3.Size = New System.Drawing.Size(179, 171)
#Else
		 Me.groupBox3.Location = New System.Drawing.Point(317, 12)
		 Me.groupBox3.Size = New System.Drawing.Size(179, 180)
#End If ' #if !LEADTOOLS_V19_OR_LATER
         Me.groupBox3.Name = "groupBox3"
         Me.groupBox3.TabIndex = 5
         Me.groupBox3.TabStop = False
         Me.groupBox3.Text = "Offset and Tiling"
         ' 
         ' txtYTOSIZ
         ' 
         Me.txtYTOSIZ.Location = New System.Drawing.Point(85, 142)
         Me.txtYTOSIZ.Name = "txtYTOSIZ"
         Me.txtYTOSIZ.Size = New System.Drawing.Size(63, 20)
         Me.txtYTOSIZ.TabIndex = 11
         ' 
         ' txtXTOSIZ
         ' 
         Me.txtXTOSIZ.Location = New System.Drawing.Point(85, 120)
         Me.txtXTOSIZ.Name = "txtXTOSIZ"
         Me.txtXTOSIZ.Size = New System.Drawing.Size(63, 20)
         Me.txtXTOSIZ.TabIndex = 10
         ' 
         ' txtYTSIZ
         ' 
         Me.txtYTSIZ.Location = New System.Drawing.Point(85, 94)
         Me.txtYTSIZ.Name = "txtYTSIZ"
         Me.txtYTSIZ.Size = New System.Drawing.Size(63, 20)
         Me.txtYTSIZ.TabIndex = 9
         ' 
         ' txtXTSIZ
         ' 
         Me.txtXTSIZ.Location = New System.Drawing.Point(85, 68)
         Me.txtXTSIZ.Name = "txtXTSIZ"
         Me.txtXTSIZ.Size = New System.Drawing.Size(63, 20)
         Me.txtXTSIZ.TabIndex = 8
         ' 
         ' txtYOSIZ
         ' 
         Me.txtYOSIZ.Location = New System.Drawing.Point(85, 42)
         Me.txtYOSIZ.Name = "txtYOSIZ"
         Me.txtYOSIZ.Size = New System.Drawing.Size(63, 20)
         Me.txtYOSIZ.TabIndex = 7
         ' 
         ' txtXOSIZ
         ' 
         Me.txtXOSIZ.Location = New System.Drawing.Point(85, 19)
         Me.txtXOSIZ.Name = "txtXOSIZ"
         Me.txtXOSIZ.Size = New System.Drawing.Size(63, 20)
         Me.txtXOSIZ.TabIndex = 6
         ' 
         ' label15
         ' 
         Me.label15.AutoSize = True
         Me.label15.Location = New System.Drawing.Point(20, 149)
         Me.label15.Name = "label15"
         Me.label15.Size = New System.Drawing.Size(41, 13)
         Me.label15.TabIndex = 5
         Me.label15.Text = "YTOsi&z"
         ' 
         ' label14
         ' 
         Me.label14.AutoSize = True
         Me.label14.Location = New System.Drawing.Point(20, 127)
         Me.label14.Name = "label14"
         Me.label14.Size = New System.Drawing.Size(41, 13)
         Me.label14.TabIndex = 4
         Me.label14.Text = "XTOsi&z"
         ' 
         ' label13
         ' 
         Me.label13.AutoSize = True
         Me.label13.Location = New System.Drawing.Point(20, 101)
         Me.label13.Name = "label13"
         Me.label13.Size = New System.Drawing.Size(33, 13)
         Me.label13.TabIndex = 3
         Me.label13.Text = "YTs&iz"
         ' 
         ' label12
         ' 
         Me.label12.AutoSize = True
         Me.label12.Location = New System.Drawing.Point(20, 75)
         Me.label12.Name = "label12"
         Me.label12.Size = New System.Drawing.Size(33, 13)
         Me.label12.TabIndex = 2
         Me.label12.Text = "X&Tsiz"
         ' 
         ' label11
         ' 
         Me.label11.AutoSize = True
         Me.label11.Location = New System.Drawing.Point(20, 49)
         Me.label11.Name = "label11"
         Me.label11.Size = New System.Drawing.Size(34, 13)
         Me.label11.TabIndex = 1
         Me.label11.Text = "&YOsiz"
         ' 
         ' label10
         ' 
         Me.label10.AutoSize = True
         Me.label10.Location = New System.Drawing.Point(20, 26)
         Me.label10.Name = "label10"
         Me.label10.Size = New System.Drawing.Size(34, 13)
         Me.label10.TabIndex = 0
         Me.label10.Text = "&XOsiz"
         ' 
         ' J2kOptDlg
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me.btnCancel
#If Not LEADTOOLS_V19_OR_LATER Then
         Me.ClientSize = New System.Drawing.Size(508, 410)
#Else
         Me.ClientSize = New System.Drawing.Size(508, 230)
#End If ' #If Not LEADTOOLS_V19_OR_LATER
         Me.Controls.Add(Me.groupBox3)
#If Not LEADTOOLS_V19_OR_LATER Then
         Me.Controls.Add(Me.groupBox2)
         Me.groupBox2.ResumeLayout(False)
         Me.groupBox2.PerformLayout()
#End If ' #If Not LEADTOOLS_V19_OR_LATER
         Me.Controls.Add(Me.btnCancel)
         Me.Controls.Add(Me.btnDefault)
         Me.Controls.Add(Me.btnOk)
         Me.Controls.Add(Me.groupBox1)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
         Me.Name = "J2kOptDlg"
         Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
         Me.Text = "JPEG 2000 options"
         '		 Me.Load += New System.EventHandler(Me.J2kOptDlg_Load);
         Me.groupBox1.ResumeLayout(False)
         Me.groupBox1.PerformLayout()
         Me.groupBox3.ResumeLayout(False)
         Me.groupBox3.PerformLayout()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private groupBox1 As System.Windows.Forms.GroupBox
      Private label1 As System.Windows.Forms.Label
#If Not LEADTOOLS_V19_OR_LATER Then
      Private txtExponent As System.Windows.Forms.TextBox
      Private txtCodeBlockHeight As System.Windows.Forms.TextBox
      Private txtCodeBlockWidth As System.Windows.Forms.TextBox
      Private txtMantissa As System.Windows.Forms.TextBox
      Private txtGuardBits As System.Windows.Forms.TextBox
      Private chkErrorResilience As System.Windows.Forms.CheckBox
      Private chkPredictableTermination As System.Windows.Forms.CheckBox
      Private chkVerticallyCausal As System.Windows.Forms.CheckBox
      Private chkTermination As System.Windows.Forms.CheckBox
      Private chkSelectiveACBypass As System.Windows.Forms.CheckBox
      Private chkResetContext As System.Windows.Forms.CheckBox
      Private label9 As System.Windows.Forms.Label
      Private label8 As System.Windows.Forms.Label
      Private label7 As System.Windows.Forms.Label
      Private label6 As System.Windows.Forms.Label
      Private label5 As System.Windows.Forms.Label
      Private groupBox2 As System.Windows.Forms.GroupBox
#End If ' #If Not LEADTOOLS_V19_OR_LATER
      Private txtDecompLevel As System.Windows.Forms.TextBox
      Private txtTargetSize As System.Windows.Forms.TextBox
      Private cmbJ2KProgressionOrder As System.Windows.Forms.ComboBox
      Private WithEvents cmbJ2kCompressionControl As System.Windows.Forms.ComboBox
      Private label4 As System.Windows.Forms.Label
      Private label3 As System.Windows.Forms.Label
      Private chkUseEPHMarker As System.Windows.Forms.CheckBox
      Private chkDerivedQuantization As System.Windows.Forms.CheckBox
      Private chkUseSOPMarker As System.Windows.Forms.CheckBox
      Private chkColorTransform As System.Windows.Forms.CheckBox
      Private WithEvents btnOk As System.Windows.Forms.Button
      Private WithEvents btnDefault As System.Windows.Forms.Button
      Private btnCancel As System.Windows.Forms.Button
      Private groupBox3 As System.Windows.Forms.GroupBox
      Private txtYTOSIZ As System.Windows.Forms.TextBox
      Private txtXTOSIZ As System.Windows.Forms.TextBox
      Private txtYTSIZ As System.Windows.Forms.TextBox
      Private txtXTSIZ As System.Windows.Forms.TextBox
      Private txtYOSIZ As System.Windows.Forms.TextBox
      Private txtXOSIZ As System.Windows.Forms.TextBox
      Private label15 As System.Windows.Forms.Label
      Private label14 As System.Windows.Forms.Label
      Private label13 As System.Windows.Forms.Label
      Private label12 As System.Windows.Forms.Label
      Private label11 As System.Windows.Forms.Label
      Private label10 As System.Windows.Forms.Label
      Private txtQFactor As System.Windows.Forms.TextBox
      Private txtCompressionRatio As System.Windows.Forms.TextBox
      Private lblJ2KTargetSize As System.Windows.Forms.Label
      Private lblJ2KCompressionRatio As System.Windows.Forms.Label
      Private lblJ2KQFactor As System.Windows.Forms.Label
   End Class
End Namespace