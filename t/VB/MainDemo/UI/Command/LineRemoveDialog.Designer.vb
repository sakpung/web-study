Imports Microsoft.VisualBasic
Imports System
Namespace MainDemo
   Public Partial Class LineRemoveDialog
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
		 Me._lblUnitsHeight = New System.Windows.Forms.Label()
		 Me._lblUnitsWidth = New System.Windows.Forms.Label()
		 Me._lblUnits = New System.Windows.Forms.Label()
		 Me._lblWall = New System.Windows.Forms.Label()
		 Me._numWall = New System.Windows.Forms.NumericUpDown()
		 Me._cbUseDpi = New System.Windows.Forms.CheckBox()
		 Me._cbUseGap = New System.Windows.Forms.CheckBox()
		 Me._cbUseVariance = New System.Windows.Forms.CheckBox()
		 Me._lblMinLineLength = New System.Windows.Forms.Label()
		 Me._numMinLineLength = New System.Windows.Forms.NumericUpDown()
		 Me._lblMaxWallPercent = New System.Windows.Forms.Label()
		 Me._numMaxWallPercent = New System.Windows.Forms.NumericUpDown()
		 Me._gbOptions = New System.Windows.Forms.GroupBox()
		 Me._lblMaxLineWidth = New System.Windows.Forms.Label()
		 Me._numMaxLineWidth = New System.Windows.Forms.NumericUpDown()
		 Me._numLineVariance = New System.Windows.Forms.NumericUpDown()
		 Me._lblGapLength = New System.Windows.Forms.Label()
		 Me._lblLineVariance = New System.Windows.Forms.Label()
		 Me._numGapLength = New System.Windows.Forms.NumericUpDown()
		 Me._btnCancel = New System.Windows.Forms.Button()
		 Me._cbRemoveEntire = New System.Windows.Forms.CheckBox()
		 Me._rbVertical = New System.Windows.Forms.RadioButton()
		 Me._cbImageUnchanged = New System.Windows.Forms.CheckBox()
		 Me._btnOk = New System.Windows.Forms.Button()
		 Me._gbBorder = New System.Windows.Forms.GroupBox()
		 Me._rbHorizontal = New System.Windows.Forms.RadioButton()
		 Me._gbFlags = New System.Windows.Forms.GroupBox()
		 CType(Me._numWall, System.ComponentModel.ISupportInitialize).BeginInit()
		 CType(Me._numMinLineLength, System.ComponentModel.ISupportInitialize).BeginInit()
		 CType(Me._numMaxWallPercent, System.ComponentModel.ISupportInitialize).BeginInit()
		 Me._gbOptions.SuspendLayout()
		 CType(Me._numMaxLineWidth, System.ComponentModel.ISupportInitialize).BeginInit()
		 CType(Me._numLineVariance, System.ComponentModel.ISupportInitialize).BeginInit()
		 CType(Me._numGapLength, System.ComponentModel.ISupportInitialize).BeginInit()
		 Me._gbBorder.SuspendLayout()
		 Me._gbFlags.SuspendLayout()
		 Me.SuspendLayout()
		 ' 
		 ' _lblUnitsHeight
		 ' 
		 Me._lblUnitsHeight.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblUnitsHeight.Location = New System.Drawing.Point(307, 203)
		 Me._lblUnitsHeight.Name = "_lblUnitsHeight"
		 Me._lblUnitsHeight.Size = New System.Drawing.Size(77, 27)
		 Me._lblUnitsHeight.TabIndex = 12
		 Me._lblUnitsHeight.Text = "Pixels"
		 Me._lblUnitsHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' _lblUnitsWidth
		 ' 
		 Me._lblUnitsWidth.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblUnitsWidth.Location = New System.Drawing.Point(307, 129)
		 Me._lblUnitsWidth.Name = "_lblUnitsWidth"
		 Me._lblUnitsWidth.Size = New System.Drawing.Size(77, 27)
		 Me._lblUnitsWidth.TabIndex = 7
		 Me._lblUnitsWidth.Text = "Pixels"
		 Me._lblUnitsWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' _lblUnits
		 ' 
		 Me._lblUnits.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblUnits.Location = New System.Drawing.Point(19, 28)
		 Me._lblUnits.Name = "_lblUnits"
		 Me._lblUnits.Size = New System.Drawing.Size(298, 26)
		 Me._lblUnits.TabIndex = 0
		 Me._lblUnits.Text = "Units of 1/1000 inch means 1000 is an inch."
		 ' 
		 ' _lblWall
		 ' 
		 Me._lblWall.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblWall.Location = New System.Drawing.Point(19, 240)
		 Me._lblWall.Name = "_lblWall"
		 Me._lblWall.Size = New System.Drawing.Size(125, 27)
		 Me._lblWall.TabIndex = 13
		 Me._lblWall.Text = "Wall"
		 Me._lblWall.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' _numWall
		 ' 
		 Me._numWall.Location = New System.Drawing.Point(154, 240)
		 Me._numWall.Maximum = New Decimal(New Integer() { 10000, 0, 0, 0})
		 Me._numWall.Name = "_numWall"
		 Me._numWall.Size = New System.Drawing.Size(144, 22)
		 Me._numWall.TabIndex = 14
'		 Me._numWall.Leave += New System.EventHandler(Me._num_Leave);
		 ' 
		 ' _cbUseDpi
		 ' 
		 Me._cbUseDpi.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._cbUseDpi.Location = New System.Drawing.Point(19, 157)
		 Me._cbUseDpi.Name = "_cbUseDpi"
		 Me._cbUseDpi.Size = New System.Drawing.Size(144, 28)
		 Me._cbUseDpi.TabIndex = 4
		 Me._cbUseDpi.Text = "Use Dpi"
'		 Me._cbUseDpi.CheckedChanged += New System.EventHandler(Me._cbUseDpi_CheckedChanged);
		 ' 
		 ' _cbUseGap
		 ' 
		 Me._cbUseGap.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._cbUseGap.Location = New System.Drawing.Point(19, 125)
		 Me._cbUseGap.Name = "_cbUseGap"
		 Me._cbUseGap.Size = New System.Drawing.Size(144, 27)
		 Me._cbUseGap.TabIndex = 3
		 Me._cbUseGap.Text = "Use Gap"
'		 Me._cbUseGap.CheckedChanged += New System.EventHandler(Me._cbUseGap_CheckedChanged);
		 ' 
		 ' _cbUseVariance
		 ' 
		 Me._cbUseVariance.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._cbUseVariance.Location = New System.Drawing.Point(19, 92)
		 Me._cbUseVariance.Name = "_cbUseVariance"
		 Me._cbUseVariance.Size = New System.Drawing.Size(144, 28)
		 Me._cbUseVariance.TabIndex = 2
		 Me._cbUseVariance.Text = "Use Variance"
'		 Me._cbUseVariance.CheckedChanged += New System.EventHandler(Me._cbUseVariance_CheckedChanged);
		 ' 
		 ' _lblMinLineLength
		 ' 
		 Me._lblMinLineLength.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblMinLineLength.Location = New System.Drawing.Point(19, 203)
		 Me._lblMinLineLength.Name = "_lblMinLineLength"
		 Me._lblMinLineLength.Size = New System.Drawing.Size(125, 27)
		 Me._lblMinLineLength.TabIndex = 10
		 Me._lblMinLineLength.Text = "Min Line Length"
		 Me._lblMinLineLength.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' _numMinLineLength
		 ' 
		 Me._numMinLineLength.Location = New System.Drawing.Point(154, 203)
		 Me._numMinLineLength.Maximum = New Decimal(New Integer() { 10000, 0, 0, 0})
		 Me._numMinLineLength.Name = "_numMinLineLength"
		 Me._numMinLineLength.Size = New System.Drawing.Size(144, 22)
		 Me._numMinLineLength.TabIndex = 11
'		 Me._numMinLineLength.Leave += New System.EventHandler(Me._num_Leave);
		 ' 
		 ' _lblMaxWallPercent
		 ' 
		 Me._lblMaxWallPercent.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblMaxWallPercent.Location = New System.Drawing.Point(19, 166)
		 Me._lblMaxWallPercent.Name = "_lblMaxWallPercent"
		 Me._lblMaxWallPercent.Size = New System.Drawing.Size(125, 27)
		 Me._lblMaxWallPercent.TabIndex = 8
		 Me._lblMaxWallPercent.Text = "Max Wall Percent"
		 Me._lblMaxWallPercent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' _numMaxWallPercent
		 ' 
		 Me._numMaxWallPercent.Location = New System.Drawing.Point(154, 166)
		 Me._numMaxWallPercent.Name = "_numMaxWallPercent"
		 Me._numMaxWallPercent.Size = New System.Drawing.Size(144, 22)
		 Me._numMaxWallPercent.TabIndex = 9
'		 Me._numMaxWallPercent.Leave += New System.EventHandler(Me._num_Leave);
		 ' 
		 ' _gbOptions
		 ' 
		 Me._gbOptions.Controls.Add(Me._lblUnitsHeight)
		 Me._gbOptions.Controls.Add(Me._lblUnitsWidth)
		 Me._gbOptions.Controls.Add(Me._lblUnits)
		 Me._gbOptions.Controls.Add(Me._lblWall)
		 Me._gbOptions.Controls.Add(Me._numWall)
		 Me._gbOptions.Controls.Add(Me._lblMinLineLength)
		 Me._gbOptions.Controls.Add(Me._numMinLineLength)
		 Me._gbOptions.Controls.Add(Me._lblMaxWallPercent)
		 Me._gbOptions.Controls.Add(Me._numMaxWallPercent)
		 Me._gbOptions.Controls.Add(Me._lblMaxLineWidth)
		 Me._gbOptions.Controls.Add(Me._numMaxLineWidth)
		 Me._gbOptions.Controls.Add(Me._numLineVariance)
		 Me._gbOptions.Controls.Add(Me._lblGapLength)
		 Me._gbOptions.Controls.Add(Me._lblLineVariance)
		 Me._gbOptions.Controls.Add(Me._numGapLength)
		 Me._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._gbOptions.Location = New System.Drawing.Point(14, 224)
		 Me._gbOptions.Name = "_gbOptions"
		 Me._gbOptions.Size = New System.Drawing.Size(432, 286)
		 Me._gbOptions.TabIndex = 2
		 Me._gbOptions.TabStop = False
		 Me._gbOptions.Text = "Options"
		 ' 
		 ' _lblMaxLineWidth
		 ' 
		 Me._lblMaxLineWidth.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblMaxLineWidth.Location = New System.Drawing.Point(19, 129)
		 Me._lblMaxLineWidth.Name = "_lblMaxLineWidth"
		 Me._lblMaxLineWidth.Size = New System.Drawing.Size(125, 27)
		 Me._lblMaxLineWidth.TabIndex = 5
		 Me._lblMaxLineWidth.Text = "Max Line Width"
		 Me._lblMaxLineWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' _numMaxLineWidth
		 ' 
		 Me._numMaxLineWidth.Location = New System.Drawing.Point(154, 129)
		 Me._numMaxLineWidth.Maximum = New Decimal(New Integer() { 10000, 0, 0, 0})
		 Me._numMaxLineWidth.Name = "_numMaxLineWidth"
		 Me._numMaxLineWidth.Size = New System.Drawing.Size(144, 22)
		 Me._numMaxLineWidth.TabIndex = 6
'		 Me._numMaxLineWidth.Leave += New System.EventHandler(Me._num_Leave);
		 ' 
		 ' _numLineVariance
		 ' 
		 Me._numLineVariance.Location = New System.Drawing.Point(154, 92)
		 Me._numLineVariance.Maximum = New Decimal(New Integer() { 10000, 0, 0, 0})
		 Me._numLineVariance.Name = "_numLineVariance"
		 Me._numLineVariance.Size = New System.Drawing.Size(144, 22)
		 Me._numLineVariance.TabIndex = 4
'		 Me._numLineVariance.Leave += New System.EventHandler(Me._num_Leave);
		 ' 
		 ' _lblGapLength
		 ' 
		 Me._lblGapLength.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblGapLength.Location = New System.Drawing.Point(19, 55)
		 Me._lblGapLength.Name = "_lblGapLength"
		 Me._lblGapLength.Size = New System.Drawing.Size(125, 27)
		 Me._lblGapLength.TabIndex = 1
		 Me._lblGapLength.Text = "Gap Length"
		 Me._lblGapLength.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' _lblLineVariance
		 ' 
		 Me._lblLineVariance.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblLineVariance.Location = New System.Drawing.Point(19, 92)
		 Me._lblLineVariance.Name = "_lblLineVariance"
		 Me._lblLineVariance.Size = New System.Drawing.Size(125, 27)
		 Me._lblLineVariance.TabIndex = 3
		 Me._lblLineVariance.Text = "Line Variance"
		 Me._lblLineVariance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' _numGapLength
		 ' 
		 Me._numGapLength.Location = New System.Drawing.Point(154, 55)
		 Me._numGapLength.Maximum = New Decimal(New Integer() { 10000, 0, 0, 0})
		 Me._numGapLength.Name = "_numGapLength"
		 Me._numGapLength.Size = New System.Drawing.Size(144, 22)
		 Me._numGapLength.TabIndex = 2
		 Me._numGapLength.Value = New Decimal(New Integer() { 1, 0, 0, 0})
'		 Me._numGapLength.Leave += New System.EventHandler(Me._num_Leave);
		 ' 
		 ' _btnCancel
		 ' 
		 Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		 Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._btnCancel.Location = New System.Drawing.Point(359, 57)
		 Me._btnCancel.Name = "_btnCancel"
		 Me._btnCancel.Size = New System.Drawing.Size(90, 27)
		 Me._btnCancel.TabIndex = 4
		 Me._btnCancel.Text = "Cancel"
		 ' 
		 ' _cbRemoveEntire
		 ' 
		 Me._cbRemoveEntire.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._cbRemoveEntire.Location = New System.Drawing.Point(19, 60)
		 Me._cbRemoveEntire.Name = "_cbRemoveEntire"
		 Me._cbRemoveEntire.Size = New System.Drawing.Size(144, 28)
		 Me._cbRemoveEntire.TabIndex = 1
		 Me._cbRemoveEntire.Text = "Remove Entire"
		 ' 
		 ' _rbVertical
		 ' 
		 Me._rbVertical.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._rbVertical.Location = New System.Drawing.Point(19, 60)
		 Me._rbVertical.Name = "_rbVertical"
		 Me._rbVertical.Size = New System.Drawing.Size(77, 28)
		 Me._rbVertical.TabIndex = 1
		 Me._rbVertical.Text = "Vertical"
		 ' 
		 ' _cbImageUnchanged
		 ' 
		 Me._cbImageUnchanged.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._cbImageUnchanged.Location = New System.Drawing.Point(19, 28)
		 Me._cbImageUnchanged.Name = "_cbImageUnchanged"
		 Me._cbImageUnchanged.Size = New System.Drawing.Size(144, 27)
		 Me._cbImageUnchanged.TabIndex = 0
		 Me._cbImageUnchanged.Text = "Image Unchanged"
		 ' 
		 ' _btnOk
		 ' 
		 Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
		 Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._btnOk.Location = New System.Drawing.Point(359, 20)
		 Me._btnOk.Name = "_btnOk"
		 Me._btnOk.Size = New System.Drawing.Size(90, 27)
		 Me._btnOk.TabIndex = 3
		 Me._btnOk.Text = "OK"
'		 Me._btnOk.Click += New System.EventHandler(Me._btnOk_Click);
		 ' 
		 ' _gbBorder
		 ' 
		 Me._gbBorder.Controls.Add(Me._rbVertical)
		 Me._gbBorder.Controls.Add(Me._rbHorizontal)
		 Me._gbBorder.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._gbBorder.Location = New System.Drawing.Point(206, 11)
		 Me._gbBorder.Name = "_gbBorder"
		 Me._gbBorder.Size = New System.Drawing.Size(124, 203)
		 Me._gbBorder.TabIndex = 1
		 Me._gbBorder.TabStop = False
		 Me._gbBorder.Text = "Remove"
		 ' 
		 ' _rbHorizontal
		 ' 
		 Me._rbHorizontal.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._rbHorizontal.Location = New System.Drawing.Point(19, 28)
		 Me._rbHorizontal.Name = "_rbHorizontal"
		 Me._rbHorizontal.Size = New System.Drawing.Size(96, 27)
		 Me._rbHorizontal.TabIndex = 0
		 Me._rbHorizontal.Text = "Horizontal"
		 ' 
		 ' _gbFlags
		 ' 
		 Me._gbFlags.Controls.Add(Me._cbUseDpi)
		 Me._gbFlags.Controls.Add(Me._cbUseGap)
		 Me._gbFlags.Controls.Add(Me._cbUseVariance)
		 Me._gbFlags.Controls.Add(Me._cbRemoveEntire)
		 Me._gbFlags.Controls.Add(Me._cbImageUnchanged)
		 Me._gbFlags.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._gbFlags.Location = New System.Drawing.Point(14, 11)
		 Me._gbFlags.Name = "_gbFlags"
		 Me._gbFlags.Size = New System.Drawing.Size(182, 203)
		 Me._gbFlags.TabIndex = 0
		 Me._gbFlags.TabStop = False
		 Me._gbFlags.Text = "Flags"
		 ' 
		 ' LineRemoveDialog
		 ' 
		 Me.AcceptButton = Me._btnOk
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(8F, 16F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.CancelButton = Me._btnCancel
		 Me.ClientSize = New System.Drawing.Size(462, 524)
		 Me.Controls.Add(Me._gbOptions)
		 Me.Controls.Add(Me._btnCancel)
		 Me.Controls.Add(Me._btnOk)
		 Me.Controls.Add(Me._gbBorder)
		 Me.Controls.Add(Me._gbFlags)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		 Me.MaximizeBox = False
		 Me.MinimizeBox = False
		 Me.Name = "LineRemoveDialog"
		 Me.ShowInTaskbar = False
		 Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		 Me.Text = "Line Remove"
'		 Me.Load += New System.EventHandler(Me.LineRemoveDialog_Load);
		 CType(Me._numWall, System.ComponentModel.ISupportInitialize).EndInit()
		 CType(Me._numMinLineLength, System.ComponentModel.ISupportInitialize).EndInit()
		 CType(Me._numMaxWallPercent, System.ComponentModel.ISupportInitialize).EndInit()
		 Me._gbOptions.ResumeLayout(False)
		 CType(Me._numMaxLineWidth, System.ComponentModel.ISupportInitialize).EndInit()
		 CType(Me._numLineVariance, System.ComponentModel.ISupportInitialize).EndInit()
		 CType(Me._numGapLength, System.ComponentModel.ISupportInitialize).EndInit()
		 Me._gbBorder.ResumeLayout(False)
		 Me._gbFlags.ResumeLayout(False)
		 Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private _lblUnitsHeight As System.Windows.Forms.Label
	  Private _lblUnitsWidth As System.Windows.Forms.Label
	  Private _lblUnits As System.Windows.Forms.Label
	  Private _lblWall As System.Windows.Forms.Label
	  Private WithEvents _numWall As System.Windows.Forms.NumericUpDown
	  Private WithEvents _cbUseDpi As System.Windows.Forms.CheckBox
	  Private WithEvents _cbUseGap As System.Windows.Forms.CheckBox
	  Private WithEvents _cbUseVariance As System.Windows.Forms.CheckBox
	  Private _lblMinLineLength As System.Windows.Forms.Label
	  Private WithEvents _numMinLineLength As System.Windows.Forms.NumericUpDown
	  Private _lblMaxWallPercent As System.Windows.Forms.Label
	  Private WithEvents _numMaxWallPercent As System.Windows.Forms.NumericUpDown
	  Private _gbOptions As System.Windows.Forms.GroupBox
	  Private _lblMaxLineWidth As System.Windows.Forms.Label
	  Private WithEvents _numMaxLineWidth As System.Windows.Forms.NumericUpDown
	  Private WithEvents _numLineVariance As System.Windows.Forms.NumericUpDown
	  Private _lblGapLength As System.Windows.Forms.Label
	  Private _lblLineVariance As System.Windows.Forms.Label
	  Private WithEvents _numGapLength As System.Windows.Forms.NumericUpDown
	  Private _btnCancel As System.Windows.Forms.Button
	  Private _cbRemoveEntire As System.Windows.Forms.CheckBox
	  Private _rbVertical As System.Windows.Forms.RadioButton
	  Private _cbImageUnchanged As System.Windows.Forms.CheckBox
	  Private WithEvents _btnOk As System.Windows.Forms.Button
	  Private _gbBorder As System.Windows.Forms.GroupBox
	  Private _rbHorizontal As System.Windows.Forms.RadioButton
	  Private _gbFlags As System.Windows.Forms.GroupBox
   End Class
End Namespace