Imports Microsoft.VisualBasic
Imports System
Namespace MainDemo
   Public Partial Class InvertedTextDialog
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
		 Me._numMaxBlackPercent = New System.Windows.Forms.NumericUpDown()
		 Me._lblMaxBlackPercent = New System.Windows.Forms.Label()
		 Me._gbOptions = New System.Windows.Forms.GroupBox()
		 Me._lblUnits = New System.Windows.Forms.Label()
		 Me._lblMinBlackPercent = New System.Windows.Forms.Label()
		 Me._numMinBlackPercent = New System.Windows.Forms.NumericUpDown()
		 Me._lblMinInvertHeight = New System.Windows.Forms.Label()
		 Me._numMinInvertHeight = New System.Windows.Forms.NumericUpDown()
		 Me._lblMinInvertWidth = New System.Windows.Forms.Label()
		 Me._numMinInvertWidth = New System.Windows.Forms.NumericUpDown()
		 Me._btnCancel = New System.Windows.Forms.Button()
		 Me._cbUseDiagonals = New System.Windows.Forms.CheckBox()
		 Me._cbImageUnchanged = New System.Windows.Forms.CheckBox()
		 Me._btnOk = New System.Windows.Forms.Button()
		 Me._cbUseDpi = New System.Windows.Forms.CheckBox()
		 Me._gbFlags = New System.Windows.Forms.GroupBox()
		 CType(Me._numMaxBlackPercent, System.ComponentModel.ISupportInitialize).BeginInit()
		 Me._gbOptions.SuspendLayout()
		 CType(Me._numMinBlackPercent, System.ComponentModel.ISupportInitialize).BeginInit()
		 CType(Me._numMinInvertHeight, System.ComponentModel.ISupportInitialize).BeginInit()
		 CType(Me._numMinInvertWidth, System.ComponentModel.ISupportInitialize).BeginInit()
		 Me._gbFlags.SuspendLayout()
		 Me.SuspendLayout()
		 ' 
		 ' _lblUnitsHeight
		 ' 
		 Me._lblUnitsHeight.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblUnitsHeight.Location = New System.Drawing.Point(326, 102)
		 Me._lblUnitsHeight.Name = "_lblUnitsHeight"
		 Me._lblUnitsHeight.Size = New System.Drawing.Size(77, 26)
		 Me._lblUnitsHeight.TabIndex = 6
		 Me._lblUnitsHeight.Text = "Pixels"
		 Me._lblUnitsHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' _lblUnitsWidth
		 ' 
		 Me._lblUnitsWidth.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblUnitsWidth.Location = New System.Drawing.Point(326, 65)
		 Me._lblUnitsWidth.Name = "_lblUnitsWidth"
		 Me._lblUnitsWidth.Size = New System.Drawing.Size(77, 26)
		 Me._lblUnitsWidth.TabIndex = 3
		 Me._lblUnitsWidth.Text = "Pixels"
		 Me._lblUnitsWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' _numMaxBlackPercent
		 ' 
		 Me._numMaxBlackPercent.Location = New System.Drawing.Point(182, 175)
		 Me._numMaxBlackPercent.Name = "_numMaxBlackPercent"
		 Me._numMaxBlackPercent.Size = New System.Drawing.Size(135, 22)
		 Me._numMaxBlackPercent.TabIndex = 10
		 Me._numMaxBlackPercent.Value = New Decimal(New Integer() { 1, 0, 0, 0})
'		 Me._numMaxBlackPercent.Leave += New System.EventHandler(Me._num_Leave);
		 ' 
		 ' _lblMaxBlackPercent
		 ' 
		 Me._lblMaxBlackPercent.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblMaxBlackPercent.Location = New System.Drawing.Point(19, 175)
		 Me._lblMaxBlackPercent.Name = "_lblMaxBlackPercent"
		 Me._lblMaxBlackPercent.Size = New System.Drawing.Size(154, 27)
		 Me._lblMaxBlackPercent.TabIndex = 9
		 Me._lblMaxBlackPercent.Text = "Maximum Black Percent"
		 Me._lblMaxBlackPercent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' _gbOptions
		 ' 
		 Me._gbOptions.Controls.Add(Me._lblUnits)
		 Me._gbOptions.Controls.Add(Me._lblUnitsHeight)
		 Me._gbOptions.Controls.Add(Me._lblUnitsWidth)
		 Me._gbOptions.Controls.Add(Me._lblMaxBlackPercent)
		 Me._gbOptions.Controls.Add(Me._numMaxBlackPercent)
		 Me._gbOptions.Controls.Add(Me._lblMinBlackPercent)
		 Me._gbOptions.Controls.Add(Me._numMinBlackPercent)
		 Me._gbOptions.Controls.Add(Me._lblMinInvertHeight)
		 Me._gbOptions.Controls.Add(Me._numMinInvertHeight)
		 Me._gbOptions.Controls.Add(Me._lblMinInvertWidth)
		 Me._gbOptions.Controls.Add(Me._numMinInvertWidth)
		 Me._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._gbOptions.Location = New System.Drawing.Point(12, 123)
		 Me._gbOptions.Name = "_gbOptions"
		 Me._gbOptions.Size = New System.Drawing.Size(460, 222)
		 Me._gbOptions.TabIndex = 1
		 Me._gbOptions.TabStop = False
		 Me._gbOptions.Text = "Options"
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
		 ' _lblMinBlackPercent
		 ' 
		 Me._lblMinBlackPercent.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblMinBlackPercent.Location = New System.Drawing.Point(19, 138)
		 Me._lblMinBlackPercent.Name = "_lblMinBlackPercent"
		 Me._lblMinBlackPercent.Size = New System.Drawing.Size(154, 27)
		 Me._lblMinBlackPercent.TabIndex = 7
		 Me._lblMinBlackPercent.Text = "Minimum Black Percent"
		 Me._lblMinBlackPercent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' _numMinBlackPercent
		 ' 
		 Me._numMinBlackPercent.Location = New System.Drawing.Point(182, 138)
		 Me._numMinBlackPercent.Name = "_numMinBlackPercent"
		 Me._numMinBlackPercent.Size = New System.Drawing.Size(135, 22)
		 Me._numMinBlackPercent.TabIndex = 8
		 Me._numMinBlackPercent.Value = New Decimal(New Integer() { 1, 0, 0, 0})
'		 Me._numMinBlackPercent.Leave += New System.EventHandler(Me._num_Leave);
		 ' 
		 ' _lblMinInvertHeight
		 ' 
		 Me._lblMinInvertHeight.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblMinInvertHeight.Location = New System.Drawing.Point(19, 102)
		 Me._lblMinInvertHeight.Name = "_lblMinInvertHeight"
		 Me._lblMinInvertHeight.Size = New System.Drawing.Size(154, 26)
		 Me._lblMinInvertHeight.TabIndex = 4
		 Me._lblMinInvertHeight.Text = "Minimum Invert Height"
		 Me._lblMinInvertHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' _numMinInvertHeight
		 ' 
		 Me._numMinInvertHeight.Location = New System.Drawing.Point(182, 102)
		 Me._numMinInvertHeight.Maximum = New Decimal(New Integer() { 10000, 0, 0, 0})
		 Me._numMinInvertHeight.Name = "_numMinInvertHeight"
		 Me._numMinInvertHeight.Size = New System.Drawing.Size(135, 22)
		 Me._numMinInvertHeight.TabIndex = 5
		 Me._numMinInvertHeight.Value = New Decimal(New Integer() { 1, 0, 0, 0})
'		 Me._numMinInvertHeight.Leave += New System.EventHandler(Me._num_Leave);
		 ' 
		 ' _lblMinInvertWidth
		 ' 
		 Me._lblMinInvertWidth.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblMinInvertWidth.Location = New System.Drawing.Point(19, 65)
		 Me._lblMinInvertWidth.Name = "_lblMinInvertWidth"
		 Me._lblMinInvertWidth.Size = New System.Drawing.Size(154, 26)
		 Me._lblMinInvertWidth.TabIndex = 1
		 Me._lblMinInvertWidth.Text = "Minimum Invert Width"
		 Me._lblMinInvertWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' _numMinInvertWidth
		 ' 
		 Me._numMinInvertWidth.Location = New System.Drawing.Point(182, 65)
		 Me._numMinInvertWidth.Maximum = New Decimal(New Integer() { 10000, 0, 0, 0})
		 Me._numMinInvertWidth.Name = "_numMinInvertWidth"
		 Me._numMinInvertWidth.Size = New System.Drawing.Size(135, 22)
		 Me._numMinInvertWidth.TabIndex = 2
'		 Me._numMinInvertWidth.Leave += New System.EventHandler(Me._num_Leave);
		 ' 
		 ' _btnCancel
		 ' 
		 Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		 Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._btnCancel.Location = New System.Drawing.Point(386, 58)
		 Me._btnCancel.Name = "_btnCancel"
		 Me._btnCancel.Size = New System.Drawing.Size(86, 27)
		 Me._btnCancel.TabIndex = 3
		 Me._btnCancel.Text = "Cancel"
		 ' 
		 ' _cbUseDiagonals
		 ' 
		 Me._cbUseDiagonals.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._cbUseDiagonals.Location = New System.Drawing.Point(19, 60)
		 Me._cbUseDiagonals.Name = "_cbUseDiagonals"
		 Me._cbUseDiagonals.Size = New System.Drawing.Size(144, 28)
		 Me._cbUseDiagonals.TabIndex = 2
		 Me._cbUseDiagonals.Text = "Use Diagonals"
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
		 Me._btnOk.Location = New System.Drawing.Point(386, 21)
		 Me._btnOk.Name = "_btnOk"
		 Me._btnOk.Size = New System.Drawing.Size(86, 27)
		 Me._btnOk.TabIndex = 2
		 Me._btnOk.Text = "OK"
'		 Me._btnOk.Click += New System.EventHandler(Me._btnOk_Click);
		 ' 
		 ' _cbUseDpi
		 ' 
		 Me._cbUseDpi.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._cbUseDpi.Location = New System.Drawing.Point(182, 28)
		 Me._cbUseDpi.Name = "_cbUseDpi"
		 Me._cbUseDpi.Size = New System.Drawing.Size(144, 27)
		 Me._cbUseDpi.TabIndex = 1
		 Me._cbUseDpi.Text = "Use Dpi"
'		 Me._cbUseDpi.CheckedChanged += New System.EventHandler(Me._cbUseDpi_CheckedChanged);
		 ' 
		 ' _gbFlags
		 ' 
		 Me._gbFlags.Controls.Add(Me._cbUseDpi)
		 Me._gbFlags.Controls.Add(Me._cbUseDiagonals)
		 Me._gbFlags.Controls.Add(Me._cbImageUnchanged)
		 Me._gbFlags.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._gbFlags.Location = New System.Drawing.Point(12, 12)
		 Me._gbFlags.Name = "_gbFlags"
		 Me._gbFlags.Size = New System.Drawing.Size(345, 102)
		 Me._gbFlags.TabIndex = 0
		 Me._gbFlags.TabStop = False
		 Me._gbFlags.Text = "Flags"
		 ' 
		 ' InvertedTextDialog
		 ' 
		 Me.AcceptButton = Me._btnOk
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(8F, 16F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.CancelButton = Me._btnCancel
		 Me.ClientSize = New System.Drawing.Size(487, 356)
		 Me.Controls.Add(Me._gbOptions)
		 Me.Controls.Add(Me._btnCancel)
		 Me.Controls.Add(Me._btnOk)
		 Me.Controls.Add(Me._gbFlags)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		 Me.MaximizeBox = False
		 Me.MinimizeBox = False
		 Me.Name = "InvertedTextDialog"
		 Me.ShowInTaskbar = False
		 Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		 Me.Text = "Inverted Text"
'		 Me.Load += New System.EventHandler(Me.InvertedTextDialog_Load);
		 CType(Me._numMaxBlackPercent, System.ComponentModel.ISupportInitialize).EndInit()
		 Me._gbOptions.ResumeLayout(False)
		 CType(Me._numMinBlackPercent, System.ComponentModel.ISupportInitialize).EndInit()
		 CType(Me._numMinInvertHeight, System.ComponentModel.ISupportInitialize).EndInit()
		 CType(Me._numMinInvertWidth, System.ComponentModel.ISupportInitialize).EndInit()
		 Me._gbFlags.ResumeLayout(False)
		 Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private _lblUnitsHeight As System.Windows.Forms.Label
	  Private _lblUnitsWidth As System.Windows.Forms.Label
	  Private WithEvents _numMaxBlackPercent As System.Windows.Forms.NumericUpDown
	  Private _lblMaxBlackPercent As System.Windows.Forms.Label
	  Private _gbOptions As System.Windows.Forms.GroupBox
	  Private _lblUnits As System.Windows.Forms.Label
	  Private _lblMinBlackPercent As System.Windows.Forms.Label
	  Private WithEvents _numMinBlackPercent As System.Windows.Forms.NumericUpDown
	  Private _lblMinInvertHeight As System.Windows.Forms.Label
	  Private WithEvents _numMinInvertHeight As System.Windows.Forms.NumericUpDown
	  Private _lblMinInvertWidth As System.Windows.Forms.Label
	  Private WithEvents _numMinInvertWidth As System.Windows.Forms.NumericUpDown
	  Private _btnCancel As System.Windows.Forms.Button
	  Private _cbUseDiagonals As System.Windows.Forms.CheckBox
	  Private _cbImageUnchanged As System.Windows.Forms.CheckBox
	  Private WithEvents _btnOk As System.Windows.Forms.Button
	  Private WithEvents _cbUseDpi As System.Windows.Forms.CheckBox
	  Private _gbFlags As System.Windows.Forms.GroupBox
   End Class
End Namespace