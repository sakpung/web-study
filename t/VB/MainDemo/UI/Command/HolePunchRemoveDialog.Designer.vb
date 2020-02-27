Imports Microsoft.VisualBasic
Imports System
Namespace MainDemo
   Public Partial Class HolePunchRemoveDialog
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
         Me._btnCancel = New System.Windows.Forms.Button
         Me._btnOk = New System.Windows.Forms.Button
         Me._gbLocation = New System.Windows.Forms.GroupBox
         Me._rbButtonBottom = New System.Windows.Forms.RadioButton
         Me._rbButtonRight = New System.Windows.Forms.RadioButton
         Me._rbButtonTop = New System.Windows.Forms.RadioButton
         Me._rbButtonLeft = New System.Windows.Forms.RadioButton
         Me._gbFlags = New System.Windows.Forms.GroupBox
         Me._cbUseSize = New System.Windows.Forms.CheckBox
         Me._cbUseDpi = New System.Windows.Forms.CheckBox
         Me._cbUseLocation = New System.Windows.Forms.CheckBox
         Me._cbUseCount = New System.Windows.Forms.CheckBox
         Me._cbImageUnchanged = New System.Windows.Forms.CheckBox
         Me._gbOptions = New System.Windows.Forms.GroupBox
         Me._numMaxHeight = New System.Windows.Forms.NumericUpDown
         Me._numMaxWidth = New System.Windows.Forms.NumericUpDown
         Me._numMaxCount = New System.Windows.Forms.NumericUpDown
         Me._numMinHeight = New System.Windows.Forms.NumericUpDown
         Me._numMinCount = New System.Windows.Forms.NumericUpDown
         Me._numMinWidth = New System.Windows.Forms.NumericUpDown
         Me._lblUnitsMaxHeight = New System.Windows.Forms.Label
         Me._lblUnitsMaxWidth = New System.Windows.Forms.Label
         Me._lblMaxHeight = New System.Windows.Forms.Label
         Me._lblUnitsMinHeight = New System.Windows.Forms.Label
         Me._lblMaxWidth = New System.Windows.Forms.Label
         Me._lblUnitsMinWidth = New System.Windows.Forms.Label
         Me._lblMaxCount = New System.Windows.Forms.Label
         Me._lblMinHeight = New System.Windows.Forms.Label
         Me._lblMinCount = New System.Windows.Forms.Label
         Me._lblMinWidth = New System.Windows.Forms.Label
         Me._lblUnits = New System.Windows.Forms.Label
         Me._gbLocation.SuspendLayout()
         Me._gbFlags.SuspendLayout()
         Me._gbOptions.SuspendLayout()
         CType(Me._numMaxHeight, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me._numMaxWidth, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me._numMaxCount, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me._numMinHeight, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me._numMinCount, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me._numMinWidth, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.SuspendLayout()
         '
         '_btnCancel
         '
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnCancel.Location = New System.Drawing.Point(260, 45)
         Me._btnCancel.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.Size = New System.Drawing.Size(68, 22)
         Me._btnCancel.TabIndex = 4
         Me._btnCancel.Text = "Cancel"
         Me._btnCancel.UseVisualStyleBackColor = True
         '
         '_btnOk
         '
         Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
         Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnOk.Location = New System.Drawing.Point(260, 15)
         Me._btnOk.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me._btnOk.Name = "_btnOk"
         Me._btnOk.Size = New System.Drawing.Size(68, 22)
         Me._btnOk.TabIndex = 3
         Me._btnOk.Text = "OK"
         Me._btnOk.UseVisualStyleBackColor = True
         '
         '_gbLocation
         '
         Me._gbLocation.Controls.Add(Me._rbButtonBottom)
         Me._gbLocation.Controls.Add(Me._rbButtonRight)
         Me._gbLocation.Controls.Add(Me._rbButtonTop)
         Me._gbLocation.Controls.Add(Me._rbButtonLeft)
         Me._gbLocation.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._gbLocation.Location = New System.Drawing.Point(152, 7)
         Me._gbLocation.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me._gbLocation.Name = "_gbLocation"
         Me._gbLocation.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me._gbLocation.Size = New System.Drawing.Size(86, 165)
         Me._gbLocation.TabIndex = 1
         Me._gbLocation.TabStop = False
         Me._gbLocation.Text = "Location"
         '
         '_rbButtonBottom
         '
         Me._rbButtonBottom.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._rbButtonBottom.Location = New System.Drawing.Point(14, 107)
         Me._rbButtonBottom.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me._rbButtonBottom.Name = "_rbButtonBottom"
         Me._rbButtonBottom.Size = New System.Drawing.Size(65, 22)
         Me._rbButtonBottom.TabIndex = 3
         Me._rbButtonBottom.TabStop = True
         Me._rbButtonBottom.Text = "Bottom"
         Me._rbButtonBottom.UseVisualStyleBackColor = True
         '
         '_rbButtonRight
         '
         Me._rbButtonRight.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._rbButtonRight.Location = New System.Drawing.Point(14, 79)
         Me._rbButtonRight.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me._rbButtonRight.Name = "_rbButtonRight"
         Me._rbButtonRight.Size = New System.Drawing.Size(65, 22)
         Me._rbButtonRight.TabIndex = 2
         Me._rbButtonRight.TabStop = True
         Me._rbButtonRight.Text = "Right"
         Me._rbButtonRight.UseVisualStyleBackColor = True
         '
         '_rbButtonTop
         '
         Me._rbButtonTop.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._rbButtonTop.Location = New System.Drawing.Point(14, 50)
         Me._rbButtonTop.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me._rbButtonTop.Name = "_rbButtonTop"
         Me._rbButtonTop.Size = New System.Drawing.Size(65, 22)
         Me._rbButtonTop.TabIndex = 1
         Me._rbButtonTop.TabStop = True
         Me._rbButtonTop.Text = "Top"
         Me._rbButtonTop.UseVisualStyleBackColor = True
         '
         '_rbButtonLeft
         '
         Me._rbButtonLeft.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._rbButtonLeft.Location = New System.Drawing.Point(14, 23)
         Me._rbButtonLeft.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me._rbButtonLeft.Name = "_rbButtonLeft"
         Me._rbButtonLeft.Size = New System.Drawing.Size(65, 22)
         Me._rbButtonLeft.TabIndex = 0
         Me._rbButtonLeft.TabStop = True
         Me._rbButtonLeft.Text = "Left"
         Me._rbButtonLeft.UseVisualStyleBackColor = True
         '
         '_gbFlags
         '
         Me._gbFlags.Controls.Add(Me._cbUseSize)
         Me._gbFlags.Controls.Add(Me._cbUseDpi)
         Me._gbFlags.Controls.Add(Me._cbUseLocation)
         Me._gbFlags.Controls.Add(Me._cbUseCount)
         Me._gbFlags.Controls.Add(Me._cbImageUnchanged)
         Me._gbFlags.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._gbFlags.Location = New System.Drawing.Point(8, 7)
         Me._gbFlags.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me._gbFlags.Name = "_gbFlags"
         Me._gbFlags.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me._gbFlags.Size = New System.Drawing.Size(136, 165)
         Me._gbFlags.TabIndex = 0
         Me._gbFlags.TabStop = False
         Me._gbFlags.Text = "Flags"
         '
         '_cbUseSize
         '
         Me._cbUseSize.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._cbUseSize.Location = New System.Drawing.Point(14, 135)
         Me._cbUseSize.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me._cbUseSize.Name = "_cbUseSize"
         Me._cbUseSize.Size = New System.Drawing.Size(108, 22)
         Me._cbUseSize.TabIndex = 4
         Me._cbUseSize.Text = "Use Size"
         Me._cbUseSize.UseVisualStyleBackColor = True
         '
         '_cbUseDpi
         '
         Me._cbUseDpi.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._cbUseDpi.Location = New System.Drawing.Point(14, 107)
         Me._cbUseDpi.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me._cbUseDpi.Name = "_cbUseDpi"
         Me._cbUseDpi.Size = New System.Drawing.Size(108, 22)
         Me._cbUseDpi.TabIndex = 3
         Me._cbUseDpi.Text = "Use Dpi"
         Me._cbUseDpi.UseVisualStyleBackColor = True
         '
         '_cbUseLocation
         '
         Me._cbUseLocation.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._cbUseLocation.Location = New System.Drawing.Point(14, 79)
         Me._cbUseLocation.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me._cbUseLocation.Name = "_cbUseLocation"
         Me._cbUseLocation.Size = New System.Drawing.Size(108, 22)
         Me._cbUseLocation.TabIndex = 2
         Me._cbUseLocation.Text = "Use Location"
         Me._cbUseLocation.UseVisualStyleBackColor = True
         '
         '_cbUseCount
         '
         Me._cbUseCount.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._cbUseCount.Location = New System.Drawing.Point(14, 50)
         Me._cbUseCount.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me._cbUseCount.Name = "_cbUseCount"
         Me._cbUseCount.Size = New System.Drawing.Size(108, 22)
         Me._cbUseCount.TabIndex = 1
         Me._cbUseCount.Text = "Use Count"
         Me._cbUseCount.UseVisualStyleBackColor = True
         '
         '_cbImageUnchanged
         '
         Me._cbImageUnchanged.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._cbImageUnchanged.Location = New System.Drawing.Point(14, 23)
         Me._cbImageUnchanged.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me._cbImageUnchanged.Name = "_cbImageUnchanged"
         Me._cbImageUnchanged.Size = New System.Drawing.Size(108, 22)
         Me._cbImageUnchanged.TabIndex = 0
         Me._cbImageUnchanged.Text = "Image Unchanged"
         Me._cbImageUnchanged.UseVisualStyleBackColor = True
         '
         '_gbOptions
         '
         Me._gbOptions.Controls.Add(Me._numMaxHeight)
         Me._gbOptions.Controls.Add(Me._numMaxWidth)
         Me._gbOptions.Controls.Add(Me._numMaxCount)
         Me._gbOptions.Controls.Add(Me._numMinHeight)
         Me._gbOptions.Controls.Add(Me._numMinCount)
         Me._gbOptions.Controls.Add(Me._numMinWidth)
         Me._gbOptions.Controls.Add(Me._lblUnitsMaxHeight)
         Me._gbOptions.Controls.Add(Me._lblUnitsMaxWidth)
         Me._gbOptions.Controls.Add(Me._lblMaxHeight)
         Me._gbOptions.Controls.Add(Me._lblUnitsMinHeight)
         Me._gbOptions.Controls.Add(Me._lblMaxWidth)
         Me._gbOptions.Controls.Add(Me._lblUnitsMinWidth)
         Me._gbOptions.Controls.Add(Me._lblMaxCount)
         Me._gbOptions.Controls.Add(Me._lblMinHeight)
         Me._gbOptions.Controls.Add(Me._lblMinCount)
         Me._gbOptions.Controls.Add(Me._lblMinWidth)
         Me._gbOptions.Controls.Add(Me._lblUnits)
         Me._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._gbOptions.Location = New System.Drawing.Point(8, 180)
         Me._gbOptions.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me._gbOptions.Name = "_gbOptions"
         Me._gbOptions.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me._gbOptions.Size = New System.Drawing.Size(316, 240)
         Me._gbOptions.TabIndex = 2
         Me._gbOptions.TabStop = False
         Me._gbOptions.Text = "Options"
         '
         '_numMaxHeight
         '
         Me._numMaxHeight.Location = New System.Drawing.Point(116, 202)
         Me._numMaxHeight.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me._numMaxHeight.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
         Me._numMaxHeight.Name = "_numMaxHeight"
         Me._numMaxHeight.Size = New System.Drawing.Size(100, 20)
         Me._numMaxHeight.TabIndex = 15
         Me._numMaxHeight.Value = New Decimal(New Integer() {1, 0, 0, 0})
         '
         '_numMaxWidth
         '
         Me._numMaxWidth.Location = New System.Drawing.Point(116, 172)
         Me._numMaxWidth.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me._numMaxWidth.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
         Me._numMaxWidth.Name = "_numMaxWidth"
         Me._numMaxWidth.Size = New System.Drawing.Size(100, 20)
         Me._numMaxWidth.TabIndex = 12
         Me._numMaxWidth.Value = New Decimal(New Integer() {1, 0, 0, 0})
         '
         '_numMaxCount
         '
         Me._numMaxCount.Location = New System.Drawing.Point(116, 83)
         Me._numMaxCount.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me._numMaxCount.Maximum = New Decimal(New Integer() {300, 0, 0, 0})
         Me._numMaxCount.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
         Me._numMaxCount.Name = "_numMaxCount"
         Me._numMaxCount.Size = New System.Drawing.Size(100, 20)
         Me._numMaxCount.TabIndex = 4
         Me._numMaxCount.Value = New Decimal(New Integer() {2, 0, 0, 0})
         '
         '_numMinHeight
         '
         Me._numMinHeight.Location = New System.Drawing.Point(116, 142)
         Me._numMinHeight.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me._numMinHeight.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
         Me._numMinHeight.Name = "_numMinHeight"
         Me._numMinHeight.Size = New System.Drawing.Size(100, 20)
         Me._numMinHeight.TabIndex = 9
         Me._numMinHeight.Value = New Decimal(New Integer() {1, 0, 0, 0})
         '
         '_numMinCount
         '
         Me._numMinCount.Location = New System.Drawing.Point(116, 53)
         Me._numMinCount.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me._numMinCount.Maximum = New Decimal(New Integer() {300, 0, 0, 0})
         Me._numMinCount.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
         Me._numMinCount.Name = "_numMinCount"
         Me._numMinCount.Size = New System.Drawing.Size(100, 20)
         Me._numMinCount.TabIndex = 2
         Me._numMinCount.Value = New Decimal(New Integer() {2, 0, 0, 0})
         '
         '_numMinWidth
         '
         Me._numMinWidth.Location = New System.Drawing.Point(116, 112)
         Me._numMinWidth.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me._numMinWidth.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
         Me._numMinWidth.Name = "_numMinWidth"
         Me._numMinWidth.Size = New System.Drawing.Size(100, 20)
         Me._numMinWidth.TabIndex = 6
         Me._numMinWidth.Value = New Decimal(New Integer() {1, 0, 0, 0})
         '
         '_lblUnitsMaxHeight
         '
         Me._lblUnitsMaxHeight.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblUnitsMaxHeight.Location = New System.Drawing.Point(224, 202)
         Me._lblUnitsMaxHeight.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
         Me._lblUnitsMaxHeight.Name = "_lblUnitsMaxHeight"
         Me._lblUnitsMaxHeight.Size = New System.Drawing.Size(58, 21)
         Me._lblUnitsMaxHeight.TabIndex = 16
         Me._lblUnitsMaxHeight.Text = "Pixels"
         Me._lblUnitsMaxHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         '
         '_lblUnitsMaxWidth
         '
         Me._lblUnitsMaxWidth.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblUnitsMaxWidth.Location = New System.Drawing.Point(224, 172)
         Me._lblUnitsMaxWidth.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
         Me._lblUnitsMaxWidth.Name = "_lblUnitsMaxWidth"
         Me._lblUnitsMaxWidth.Size = New System.Drawing.Size(58, 21)
         Me._lblUnitsMaxWidth.TabIndex = 13
         Me._lblUnitsMaxWidth.Text = "Pixels"
         Me._lblUnitsMaxWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         '
         '_lblMaxHeight
         '
         Me._lblMaxHeight.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblMaxHeight.Location = New System.Drawing.Point(14, 202)
         Me._lblMaxHeight.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
         Me._lblMaxHeight.Name = "_lblMaxHeight"
         Me._lblMaxHeight.Size = New System.Drawing.Size(94, 21)
         Me._lblMaxHeight.TabIndex = 14
         Me._lblMaxHeight.Text = "Maximum Height"
         Me._lblMaxHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         '
         '_lblUnitsMinHeight
         '
         Me._lblUnitsMinHeight.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblUnitsMinHeight.Location = New System.Drawing.Point(224, 142)
         Me._lblUnitsMinHeight.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
         Me._lblUnitsMinHeight.Name = "_lblUnitsMinHeight"
         Me._lblUnitsMinHeight.Size = New System.Drawing.Size(58, 21)
         Me._lblUnitsMinHeight.TabIndex = 10
         Me._lblUnitsMinHeight.Text = "Pixels"
         Me._lblUnitsMinHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         '
         '_lblMaxWidth
         '
         Me._lblMaxWidth.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblMaxWidth.Location = New System.Drawing.Point(14, 172)
         Me._lblMaxWidth.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
         Me._lblMaxWidth.Name = "_lblMaxWidth"
         Me._lblMaxWidth.Size = New System.Drawing.Size(94, 21)
         Me._lblMaxWidth.TabIndex = 11
         Me._lblMaxWidth.Text = "Maximum Width"
         Me._lblMaxWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         '
         '_lblUnitsMinWidth
         '
         Me._lblUnitsMinWidth.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblUnitsMinWidth.Location = New System.Drawing.Point(224, 112)
         Me._lblUnitsMinWidth.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
         Me._lblUnitsMinWidth.Name = "_lblUnitsMinWidth"
         Me._lblUnitsMinWidth.Size = New System.Drawing.Size(58, 21)
         Me._lblUnitsMinWidth.TabIndex = 7
         Me._lblUnitsMinWidth.Text = "Pixels"
         Me._lblUnitsMinWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         '
         '_lblMaxCount
         '
         Me._lblMaxCount.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblMaxCount.Location = New System.Drawing.Point(14, 83)
         Me._lblMaxCount.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
         Me._lblMaxCount.Name = "_lblMaxCount"
         Me._lblMaxCount.Size = New System.Drawing.Size(94, 21)
         Me._lblMaxCount.TabIndex = 3
         Me._lblMaxCount.Text = "Maximum Count"
         Me._lblMaxCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         '
         '_lblMinHeight
         '
         Me._lblMinHeight.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblMinHeight.Location = New System.Drawing.Point(14, 142)
         Me._lblMinHeight.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
         Me._lblMinHeight.Name = "_lblMinHeight"
         Me._lblMinHeight.Size = New System.Drawing.Size(94, 21)
         Me._lblMinHeight.TabIndex = 8
         Me._lblMinHeight.Text = "Minimum Height"
         Me._lblMinHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         '
         '_lblMinCount
         '
         Me._lblMinCount.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblMinCount.Location = New System.Drawing.Point(14, 53)
         Me._lblMinCount.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
         Me._lblMinCount.Name = "_lblMinCount"
         Me._lblMinCount.Size = New System.Drawing.Size(94, 21)
         Me._lblMinCount.TabIndex = 1
         Me._lblMinCount.Text = "Minimum Count"
         Me._lblMinCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         '
         '_lblMinWidth
         '
         Me._lblMinWidth.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblMinWidth.Location = New System.Drawing.Point(14, 112)
         Me._lblMinWidth.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
         Me._lblMinWidth.Name = "_lblMinWidth"
         Me._lblMinWidth.Size = New System.Drawing.Size(94, 21)
         Me._lblMinWidth.TabIndex = 5
         Me._lblMinWidth.Text = "Minimum Width"
         Me._lblMinWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         '
         '_lblUnits
         '
         Me._lblUnits.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblUnits.Location = New System.Drawing.Point(14, 23)
         Me._lblUnits.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
         Me._lblUnits.Name = "_lblUnits"
         Me._lblUnits.Size = New System.Drawing.Size(223, 21)
         Me._lblUnits.TabIndex = 0
         Me._lblUnits.Text = "Units of 1/1000 inch means 1000 is an inch."
         Me._lblUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         '
         'HolePunchRemoveDialog
         '
         Me.AcceptButton = Me._btnOk
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me._btnCancel
         Me.ClientSize = New System.Drawing.Size(334, 430)
         Me.Controls.Add(Me._gbOptions)
         Me.Controls.Add(Me._gbFlags)
         Me.Controls.Add(Me._gbLocation)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._btnOk)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "HolePunchRemoveDialog"
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Hole Punch Remove"
         Me._gbLocation.ResumeLayout(False)
         Me._gbFlags.ResumeLayout(False)
         Me._gbOptions.ResumeLayout(False)
         CType(Me._numMaxHeight, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me._numMaxWidth, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me._numMaxCount, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me._numMinHeight, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me._numMinCount, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me._numMinWidth, System.ComponentModel.ISupportInitialize).EndInit()
         Me.ResumeLayout(False)

      End Sub

	  #End Region

	  Private _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button
	  Private _gbLocation As System.Windows.Forms.GroupBox
	  Private _gbFlags As System.Windows.Forms.GroupBox
	  Private WithEvents _cbUseSize As System.Windows.Forms.CheckBox
	  Private WithEvents _cbUseDpi As System.Windows.Forms.CheckBox
	  Private WithEvents _cbUseLocation As System.Windows.Forms.CheckBox
	  Private WithEvents _cbUseCount As System.Windows.Forms.CheckBox
	  Private _cbImageUnchanged As System.Windows.Forms.CheckBox
	  Private _gbOptions As System.Windows.Forms.GroupBox
	  Private _rbButtonLeft As System.Windows.Forms.RadioButton
	  Private _rbButtonBottom As System.Windows.Forms.RadioButton
	  Private _rbButtonRight As System.Windows.Forms.RadioButton
	  Private _rbButtonTop As System.Windows.Forms.RadioButton
	  Private WithEvents _numMaxHeight As System.Windows.Forms.NumericUpDown
	  Private WithEvents _numMaxWidth As System.Windows.Forms.NumericUpDown
	  Private WithEvents _numMinHeight As System.Windows.Forms.NumericUpDown
	  Private WithEvents _numMinWidth As System.Windows.Forms.NumericUpDown
	  Private _lblUnitsMaxHeight As System.Windows.Forms.Label
	  Private _lblUnitsMaxWidth As System.Windows.Forms.Label
	  Private _lblMaxHeight As System.Windows.Forms.Label
	  Private _lblUnitsMinHeight As System.Windows.Forms.Label
	  Private _lblMaxWidth As System.Windows.Forms.Label
	  Private _lblUnitsMinWidth As System.Windows.Forms.Label
	  Private _lblMinHeight As System.Windows.Forms.Label
	  Private _lblMinWidth As System.Windows.Forms.Label
	  Private _lblUnits As System.Windows.Forms.Label
	  Private WithEvents _numMaxCount As System.Windows.Forms.NumericUpDown
	  Private WithEvents _numMinCount As System.Windows.Forms.NumericUpDown
	  Private _lblMaxCount As System.Windows.Forms.Label
	  Private _lblMinCount As System.Windows.Forms.Label
   End Class
End Namespace