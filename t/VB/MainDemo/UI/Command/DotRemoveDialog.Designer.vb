Imports Microsoft.VisualBasic
Imports System
Namespace MainDemo
   Public Partial Class DotRemoveDialog
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
		 Me._btnCancel = New System.Windows.Forms.Button()
		 Me._btnOk = New System.Windows.Forms.Button()
		 Me._gbFlags = New System.Windows.Forms.GroupBox()
		 Me._cbUseDiagonals = New System.Windows.Forms.CheckBox()
		 Me._cbUseSize = New System.Windows.Forms.CheckBox()
		 Me._cbUseDpi = New System.Windows.Forms.CheckBox()
		 Me._cbImageUnchanged = New System.Windows.Forms.CheckBox()
		 Me._gbOptions = New System.Windows.Forms.GroupBox()
		 Me._numMaxHeight = New System.Windows.Forms.NumericUpDown()
		 Me._numMaxWidth = New System.Windows.Forms.NumericUpDown()
		 Me._numMinHeight = New System.Windows.Forms.NumericUpDown()
		 Me._numMinWidth = New System.Windows.Forms.NumericUpDown()
		 Me._lblUnitsMaxHeight = New System.Windows.Forms.Label()
		 Me._lblUnitsMaxWidth = New System.Windows.Forms.Label()
		 Me._lblMaxHeight = New System.Windows.Forms.Label()
		 Me._lblUnitsMinHeight = New System.Windows.Forms.Label()
		 Me._lblMaxWidth = New System.Windows.Forms.Label()
		 Me._lblUnitsMinWidth = New System.Windows.Forms.Label()
		 Me._lblMinHeight = New System.Windows.Forms.Label()
		 Me._lblMinWidth = New System.Windows.Forms.Label()
		 Me._lblUnits = New System.Windows.Forms.Label()
		 Me._gbFlags.SuspendLayout()
		 Me._gbOptions.SuspendLayout()
		 CType(Me._numMaxHeight, System.ComponentModel.ISupportInitialize).BeginInit()
		 CType(Me._numMaxWidth, System.ComponentModel.ISupportInitialize).BeginInit()
		 CType(Me._numMinHeight, System.ComponentModel.ISupportInitialize).BeginInit()
		 CType(Me._numMinWidth, System.ComponentModel.ISupportInitialize).BeginInit()
		 Me.SuspendLayout()
		 ' 
		 ' _btnCancel
		 ' 
		 Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		 Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._btnCancel.Location = New System.Drawing.Point(374, 55)
		 Me._btnCancel.Name = "_btnCancel"
		 Me._btnCancel.Size = New System.Drawing.Size(90, 27)
		 Me._btnCancel.TabIndex = 3
		 Me._btnCancel.Text = "Cancel"
		 Me._btnCancel.UseVisualStyleBackColor = True
		 ' 
		 ' _btnOk
		 ' 
		 Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
		 Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._btnOk.Location = New System.Drawing.Point(374, 18)
		 Me._btnOk.Name = "_btnOk"
		 Me._btnOk.Size = New System.Drawing.Size(90, 27)
		 Me._btnOk.TabIndex = 2
		 Me._btnOk.Text = "OK"
		 Me._btnOk.UseVisualStyleBackColor = True
'		 Me._btnOk.Click += New System.EventHandler(Me._btnOk_Click);
		 ' 
		 ' _gbFlags
		 ' 
		 Me._gbFlags.Controls.Add(Me._cbUseDiagonals)
		 Me._gbFlags.Controls.Add(Me._cbUseSize)
		 Me._gbFlags.Controls.Add(Me._cbUseDpi)
		 Me._gbFlags.Controls.Add(Me._cbImageUnchanged)
		 Me._gbFlags.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._gbFlags.Location = New System.Drawing.Point(10, 9)
		 Me._gbFlags.Name = "_gbFlags"
		 Me._gbFlags.Size = New System.Drawing.Size(336, 102)
		 Me._gbFlags.TabIndex = 0
		 Me._gbFlags.TabStop = False
		 Me._gbFlags.Text = "Flags"
		 ' 
		 ' _cbUseDiagonals
		 ' 
		 Me._cbUseDiagonals.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._cbUseDiagonals.Location = New System.Drawing.Point(19, 60)
		 Me._cbUseDiagonals.Name = "_cbUseDiagonals"
		 Me._cbUseDiagonals.Size = New System.Drawing.Size(144, 28)
		 Me._cbUseDiagonals.TabIndex = 2
		 Me._cbUseDiagonals.Text = "Use Diagonals"
		 Me._cbUseDiagonals.UseVisualStyleBackColor = True
		 ' 
		 ' _cbUseSize
		 ' 
		 Me._cbUseSize.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._cbUseSize.Location = New System.Drawing.Point(182, 60)
		 Me._cbUseSize.Name = "_cbUseSize"
		 Me._cbUseSize.Size = New System.Drawing.Size(144, 28)
		 Me._cbUseSize.TabIndex = 3
		 Me._cbUseSize.Text = "Use Size"
		 Me._cbUseSize.UseVisualStyleBackColor = True
'		 Me._cbUseSize.CheckedChanged += New System.EventHandler(Me._cbUseSize_CheckedChanged);
		 ' 
		 ' _cbUseDpi
		 ' 
		 Me._cbUseDpi.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._cbUseDpi.Location = New System.Drawing.Point(182, 28)
		 Me._cbUseDpi.Name = "_cbUseDpi"
		 Me._cbUseDpi.Size = New System.Drawing.Size(144, 27)
		 Me._cbUseDpi.TabIndex = 1
		 Me._cbUseDpi.Text = "Use Dpi"
		 Me._cbUseDpi.UseVisualStyleBackColor = True
'		 Me._cbUseDpi.CheckedChanged += New System.EventHandler(Me._cbUseDpi_CheckedChanged);
		 ' 
		 ' _cbImageUnchanged
		 ' 
		 Me._cbImageUnchanged.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._cbImageUnchanged.Location = New System.Drawing.Point(19, 28)
		 Me._cbImageUnchanged.Name = "_cbImageUnchanged"
		 Me._cbImageUnchanged.Size = New System.Drawing.Size(144, 27)
		 Me._cbImageUnchanged.TabIndex = 0
		 Me._cbImageUnchanged.Text = "Image Unchanged"
		 Me._cbImageUnchanged.UseVisualStyleBackColor = True
		 ' 
		 ' _gbOptions
		 ' 
		 Me._gbOptions.Controls.Add(Me._numMaxHeight)
		 Me._gbOptions.Controls.Add(Me._numMaxWidth)
		 Me._gbOptions.Controls.Add(Me._numMinHeight)
		 Me._gbOptions.Controls.Add(Me._numMinWidth)
		 Me._gbOptions.Controls.Add(Me._lblUnitsMaxHeight)
		 Me._gbOptions.Controls.Add(Me._lblUnitsMaxWidth)
		 Me._gbOptions.Controls.Add(Me._lblMaxHeight)
		 Me._gbOptions.Controls.Add(Me._lblUnitsMinHeight)
		 Me._gbOptions.Controls.Add(Me._lblMaxWidth)
		 Me._gbOptions.Controls.Add(Me._lblUnitsMinWidth)
		 Me._gbOptions.Controls.Add(Me._lblMinHeight)
		 Me._gbOptions.Controls.Add(Me._lblMinWidth)
		 Me._gbOptions.Controls.Add(Me._lblUnits)
		 Me._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._gbOptions.Location = New System.Drawing.Point(10, 120)
		 Me._gbOptions.Name = "_gbOptions"
		 Me._gbOptions.Size = New System.Drawing.Size(451, 222)
		 Me._gbOptions.TabIndex = 1
		 Me._gbOptions.TabStop = False
		 Me._gbOptions.Text = "Pixels"
		 ' 
		 ' _numMaxHeight
		 ' 
		 Me._numMaxHeight.Location = New System.Drawing.Point(154, 185)
		 Me._numMaxHeight.Maximum = New Decimal(New Integer() { 10000, 0, 0, 0})
		 Me._numMaxHeight.Name = "_numMaxHeight"
		 Me._numMaxHeight.Size = New System.Drawing.Size(163, 22)
		 Me._numMaxHeight.TabIndex = 11
		 Me._numMaxHeight.Value = New Decimal(New Integer() { 1, 0, 0, 0})
'		 Me._numMaxHeight.Leave += New System.EventHandler(Me._num_Leave);
		 ' 
		 ' _numMaxWidth
		 ' 
		 Me._numMaxWidth.Location = New System.Drawing.Point(154, 148)
		 Me._numMaxWidth.Maximum = New Decimal(New Integer() { 10000, 0, 0, 0})
		 Me._numMaxWidth.Name = "_numMaxWidth"
		 Me._numMaxWidth.Size = New System.Drawing.Size(163, 22)
		 Me._numMaxWidth.TabIndex = 8
		 Me._numMaxWidth.Value = New Decimal(New Integer() { 1, 0, 0, 0})
'		 Me._numMaxWidth.Leave += New System.EventHandler(Me._num_Leave);
		 ' 
		 ' _numMinHeight
		 ' 
		 Me._numMinHeight.Location = New System.Drawing.Point(154, 111)
		 Me._numMinHeight.Maximum = New Decimal(New Integer() { 10000, 0, 0, 0})
		 Me._numMinHeight.Name = "_numMinHeight"
		 Me._numMinHeight.Size = New System.Drawing.Size(163, 22)
		 Me._numMinHeight.TabIndex = 5
		 Me._numMinHeight.Value = New Decimal(New Integer() { 1, 0, 0, 0})
'		 Me._numMinHeight.Leave += New System.EventHandler(Me._num_Leave);
		 ' 
		 ' _numMinWidth
		 ' 
		 Me._numMinWidth.Location = New System.Drawing.Point(154, 74)
		 Me._numMinWidth.Maximum = New Decimal(New Integer() { 10000, 0, 0, 0})
		 Me._numMinWidth.Name = "_numMinWidth"
		 Me._numMinWidth.Size = New System.Drawing.Size(163, 22)
		 Me._numMinWidth.TabIndex = 2
		 Me._numMinWidth.Value = New Decimal(New Integer() { 1, 0, 0, 0})
'		 Me._numMinWidth.Leave += New System.EventHandler(Me._num_Leave);
		 ' 
		 ' _lblUnitsMaxHeight
		 ' 
		 Me._lblUnitsMaxHeight.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblUnitsMaxHeight.Location = New System.Drawing.Point(336, 185)
		 Me._lblUnitsMaxHeight.Name = "_lblUnitsMaxHeight"
		 Me._lblUnitsMaxHeight.Size = New System.Drawing.Size(77, 26)
		 Me._lblUnitsMaxHeight.TabIndex = 12
		 Me._lblUnitsMaxHeight.Text = "Pixels"
		 Me._lblUnitsMaxHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' _lblUnitsMaxWidth
		 ' 
		 Me._lblUnitsMaxWidth.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblUnitsMaxWidth.Location = New System.Drawing.Point(336, 148)
		 Me._lblUnitsMaxWidth.Name = "_lblUnitsMaxWidth"
		 Me._lblUnitsMaxWidth.Size = New System.Drawing.Size(77, 26)
		 Me._lblUnitsMaxWidth.TabIndex = 9
		 Me._lblUnitsMaxWidth.Text = "Pixels"
		 Me._lblUnitsMaxWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' _lblMaxHeight
		 ' 
		 Me._lblMaxHeight.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblMaxHeight.Location = New System.Drawing.Point(19, 185)
		 Me._lblMaxHeight.Name = "_lblMaxHeight"
		 Me._lblMaxHeight.Size = New System.Drawing.Size(125, 26)
		 Me._lblMaxHeight.TabIndex = 10
		 Me._lblMaxHeight.Text = "Maximum Height"
		 Me._lblMaxHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' _lblUnitsMinHeight
		 ' 
		 Me._lblUnitsMinHeight.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblUnitsMinHeight.Location = New System.Drawing.Point(336, 110)
		 Me._lblUnitsMinHeight.Name = "_lblUnitsMinHeight"
		 Me._lblUnitsMinHeight.Size = New System.Drawing.Size(77, 26)
		 Me._lblUnitsMinHeight.TabIndex = 6
		 Me._lblUnitsMinHeight.Text = "Pixels"
		 Me._lblUnitsMinHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' _lblMaxWidth
		 ' 
		 Me._lblMaxWidth.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblMaxWidth.Location = New System.Drawing.Point(19, 148)
		 Me._lblMaxWidth.Name = "_lblMaxWidth"
		 Me._lblMaxWidth.Size = New System.Drawing.Size(125, 26)
		 Me._lblMaxWidth.TabIndex = 7
		 Me._lblMaxWidth.Text = "Maximum Width"
		 Me._lblMaxWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' _lblUnitsMinWidth
		 ' 
		 Me._lblUnitsMinWidth.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblUnitsMinWidth.Location = New System.Drawing.Point(336, 73)
		 Me._lblUnitsMinWidth.Name = "_lblUnitsMinWidth"
		 Me._lblUnitsMinWidth.Size = New System.Drawing.Size(77, 26)
		 Me._lblUnitsMinWidth.TabIndex = 3
		 Me._lblUnitsMinWidth.Text = "Pixels"
		 Me._lblUnitsMinWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' _lblMinHeight
		 ' 
		 Me._lblMinHeight.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblMinHeight.Location = New System.Drawing.Point(19, 111)
		 Me._lblMinHeight.Name = "_lblMinHeight"
		 Me._lblMinHeight.Size = New System.Drawing.Size(125, 26)
		 Me._lblMinHeight.TabIndex = 4
		 Me._lblMinHeight.Text = "Minimum Height"
		 Me._lblMinHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' _lblMinWidth
		 ' 
		 Me._lblMinWidth.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblMinWidth.Location = New System.Drawing.Point(19, 74)
		 Me._lblMinWidth.Name = "_lblMinWidth"
		 Me._lblMinWidth.Size = New System.Drawing.Size(125, 26)
		 Me._lblMinWidth.TabIndex = 1
		 Me._lblMinWidth.Text = "Minimum Width"
		 Me._lblMinWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' _lblUnits
		 ' 
		 Me._lblUnits.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblUnits.Location = New System.Drawing.Point(29, 28)
		 Me._lblUnits.Name = "_lblUnits"
		 Me._lblUnits.Size = New System.Drawing.Size(297, 26)
		 Me._lblUnits.TabIndex = 0
		 Me._lblUnits.Text = "Units of 1/1000 inch means 1000 is an inch."
		 Me._lblUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' DotRemoveDialog
		 ' 
		 Me.AcceptButton = Me._btnOk
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(8F, 16F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.CancelButton = Me._btnCancel
		 Me.ClientSize = New System.Drawing.Size(474, 357)
		 Me.Controls.Add(Me._gbOptions)
		 Me.Controls.Add(Me._gbFlags)
		 Me.Controls.Add(Me._btnCancel)
		 Me.Controls.Add(Me._btnOk)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		 Me.MaximizeBox = False
		 Me.MinimizeBox = False
		 Me.Name = "DotRemoveDialog"
		 Me.ShowInTaskbar = False
		 Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		 Me.Text = "Dot Remove"
		 Me._gbFlags.ResumeLayout(False)
		 Me._gbOptions.ResumeLayout(False)
		 CType(Me._numMaxHeight, System.ComponentModel.ISupportInitialize).EndInit()
		 CType(Me._numMaxWidth, System.ComponentModel.ISupportInitialize).EndInit()
		 CType(Me._numMinHeight, System.ComponentModel.ISupportInitialize).EndInit()
		 CType(Me._numMinWidth, System.ComponentModel.ISupportInitialize).EndInit()
		 Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button
	  Private _gbFlags As System.Windows.Forms.GroupBox
	  Private _gbOptions As System.Windows.Forms.GroupBox
	  Private _cbUseDiagonals As System.Windows.Forms.CheckBox
	  Private WithEvents _cbUseSize As System.Windows.Forms.CheckBox
	  Private WithEvents _cbUseDpi As System.Windows.Forms.CheckBox
	  Private _cbImageUnchanged As System.Windows.Forms.CheckBox
	  Private _lblUnits As System.Windows.Forms.Label
	  Private _lblUnitsMaxHeight As System.Windows.Forms.Label
	  Private _lblUnitsMaxWidth As System.Windows.Forms.Label
	  Private _lblMaxHeight As System.Windows.Forms.Label
	  Private _lblUnitsMinHeight As System.Windows.Forms.Label
	  Private _lblMaxWidth As System.Windows.Forms.Label
	  Private _lblUnitsMinWidth As System.Windows.Forms.Label
	  Private _lblMinHeight As System.Windows.Forms.Label
	  Private _lblMinWidth As System.Windows.Forms.Label
	  Private WithEvents _numMaxHeight As System.Windows.Forms.NumericUpDown
	  Private WithEvents _numMaxWidth As System.Windows.Forms.NumericUpDown
	  Private WithEvents _numMinHeight As System.Windows.Forms.NumericUpDown
	  Private WithEvents _numMinWidth As System.Windows.Forms.NumericUpDown
   End Class
End Namespace