Imports Microsoft.VisualBasic
Imports System
Namespace DocumentCleanupDemo
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
		  Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DotRemoveDialog))
		  Me._gbFlags = New System.Windows.Forms.GroupBox()
		  Me._tbDPI = New System.Windows.Forms.TextBox()
		  Me._cbUseDiagonals = New System.Windows.Forms.CheckBox()
		  Me._cbUseDotDimensions = New System.Windows.Forms.CheckBox()
		  Me._cbUseDPI = New System.Windows.Forms.CheckBox()
		  Me._gbDotDimensions = New System.Windows.Forms.GroupBox()
		  Me._lbl5 = New System.Windows.Forms.Label()
		  Me._lbl6 = New System.Windows.Forms.Label()
		  Me._lbl7 = New System.Windows.Forms.Label()
		  Me._lbl8 = New System.Windows.Forms.Label()
		  Me._lblMaximumDotHeight = New System.Windows.Forms.Label()
		  Me._lblMaximumDotWidth = New System.Windows.Forms.Label()
		  Me._lblMinimumDotHeight = New System.Windows.Forms.Label()
		  Me._lblMinimumDotWidth = New System.Windows.Forms.Label()
		  Me._tbMaximumDotHeight = New System.Windows.Forms.TextBox()
		  Me._tbMaximumDotWidth = New System.Windows.Forms.TextBox()
		  Me._tbMinimumDotHeight = New System.Windows.Forms.TextBox()
		  Me._tbMinimumDotWidth = New System.Windows.Forms.TextBox()
		  Me._btnOk = New System.Windows.Forms.Button()
		  Me._btnCancel = New System.Windows.Forms.Button()
		  Me._gbFlags.SuspendLayout()
		  Me._gbDotDimensions.SuspendLayout()
		  Me.SuspendLayout()
		  ' 
		  ' _gbFlags
		  ' 
		  Me._gbFlags.Controls.Add(Me._tbDPI)
		  Me._gbFlags.Controls.Add(Me._cbUseDiagonals)
		  Me._gbFlags.Controls.Add(Me._cbUseDotDimensions)
		  Me._gbFlags.Controls.Add(Me._cbUseDPI)
		  Me._gbFlags.Location = New System.Drawing.Point(12, 12)
		  Me._gbFlags.Name = "_gbFlags"
		  Me._gbFlags.Size = New System.Drawing.Size(281, 100)
		  Me._gbFlags.TabIndex = 0
		  Me._gbFlags.TabStop = False
		  Me._gbFlags.Text = "Flags"
		  ' 
		  ' _tbDPI
		  ' 
		  Me._tbDPI.Enabled = False
		  Me._tbDPI.Location = New System.Drawing.Point(96, 19)
		  Me._tbDPI.Name = "_tbDPI"
		  Me._tbDPI.Size = New System.Drawing.Size(100, 20)
		  Me._tbDPI.TabIndex = 3
		  ' 
		  ' _cbUseDiagonals
		  ' 
		  Me._cbUseDiagonals.AutoSize = True
		  Me._cbUseDiagonals.Location = New System.Drawing.Point(24, 65)
		  Me._cbUseDiagonals.Name = "_cbUseDiagonals"
		  Me._cbUseDiagonals.Size = New System.Drawing.Size(95, 17)
		  Me._cbUseDiagonals.TabIndex = 2
		  Me._cbUseDiagonals.Text = "Use Diagonals"
		  Me._cbUseDiagonals.UseVisualStyleBackColor = True
		  ' 
		  ' _cbUseDotDimensions
		  ' 
		  Me._cbUseDotDimensions.AutoSize = True
		  Me._cbUseDotDimensions.Location = New System.Drawing.Point(24, 42)
		  Me._cbUseDotDimensions.Name = "_cbUseDotDimensions"
		  Me._cbUseDotDimensions.Size = New System.Drawing.Size(122, 17)
		  Me._cbUseDotDimensions.TabIndex = 1
		  Me._cbUseDotDimensions.Text = "Use Dot Dimensions"
		  Me._cbUseDotDimensions.UseVisualStyleBackColor = True
'		  Me._cbUseDotDimensions.CheckedChanged += New System.EventHandler(Me._cbUseDotDimensions_CheckedChanged);
		  ' 
		  ' _cbUseDPI
		  ' 
		  Me._cbUseDPI.AutoSize = True
		  Me._cbUseDPI.Location = New System.Drawing.Point(24, 19)
		  Me._cbUseDPI.Name = "_cbUseDPI"
		  Me._cbUseDPI.Size = New System.Drawing.Size(66, 17)
		  Me._cbUseDPI.TabIndex = 0
		  Me._cbUseDPI.Text = "Use DPI"
		  Me._cbUseDPI.UseVisualStyleBackColor = True
		  ' 
		  ' _gbDotDimensions
		  ' 
		  Me._gbDotDimensions.Controls.Add(Me._lbl5)
		  Me._gbDotDimensions.Controls.Add(Me._lbl6)
		  Me._gbDotDimensions.Controls.Add(Me._lbl7)
		  Me._gbDotDimensions.Controls.Add(Me._lbl8)
		  Me._gbDotDimensions.Controls.Add(Me._lblMaximumDotHeight)
		  Me._gbDotDimensions.Controls.Add(Me._lblMaximumDotWidth)
		  Me._gbDotDimensions.Controls.Add(Me._lblMinimumDotHeight)
		  Me._gbDotDimensions.Controls.Add(Me._lblMinimumDotWidth)
		  Me._gbDotDimensions.Controls.Add(Me._tbMaximumDotHeight)
		  Me._gbDotDimensions.Controls.Add(Me._tbMaximumDotWidth)
		  Me._gbDotDimensions.Controls.Add(Me._tbMinimumDotHeight)
		  Me._gbDotDimensions.Controls.Add(Me._tbMinimumDotWidth)
		  Me._gbDotDimensions.Location = New System.Drawing.Point(12, 118)
		  Me._gbDotDimensions.Name = "_gbDotDimensions"
		  Me._gbDotDimensions.Size = New System.Drawing.Size(281, 152)
		  Me._gbDotDimensions.TabIndex = 1
		  Me._gbDotDimensions.TabStop = False
		  Me._gbDotDimensions.Text = "Dot Dimensions"
		  ' 
		  ' _lbl5
		  ' 
		  Me._lbl5.AutoSize = True
		  Me._lbl5.Location = New System.Drawing.Point(211, 117)
		  Me._lbl5.Name = "_lbl5"
		  Me._lbl5.Size = New System.Drawing.Size(29, 13)
		  Me._lbl5.TabIndex = 11
		  Me._lbl5.Text = "_lbl5"
		  ' 
		  ' _lbl6
		  ' 
		  Me._lbl6.AutoSize = True
		  Me._lbl6.Location = New System.Drawing.Point(211, 91)
		  Me._lbl6.Name = "_lbl6"
		  Me._lbl6.Size = New System.Drawing.Size(29, 13)
		  Me._lbl6.TabIndex = 10
		  Me._lbl6.Text = "_lbl6"
		  ' 
		  ' _lbl7
		  ' 
		  Me._lbl7.AutoSize = True
		  Me._lbl7.Location = New System.Drawing.Point(211, 65)
		  Me._lbl7.Name = "_lbl7"
		  Me._lbl7.Size = New System.Drawing.Size(29, 13)
		  Me._lbl7.TabIndex = 9
		  Me._lbl7.Text = "_lbl7"
		  ' 
		  ' _lbl8
		  ' 
		  Me._lbl8.AutoSize = True
		  Me._lbl8.Location = New System.Drawing.Point(211, 39)
		  Me._lbl8.Name = "_lbl8"
		  Me._lbl8.Size = New System.Drawing.Size(29, 13)
		  Me._lbl8.TabIndex = 8
		  Me._lbl8.Text = "_lbl8"
		  ' 
		  ' _lblMaximumDotHeight
		  ' 
		  Me._lblMaximumDotHeight.AutoSize = True
		  Me._lblMaximumDotHeight.Location = New System.Drawing.Point(21, 117)
		  Me._lblMaximumDotHeight.Name = "_lblMaximumDotHeight"
		  Me._lblMaximumDotHeight.Size = New System.Drawing.Size(105, 13)
		  Me._lblMaximumDotHeight.TabIndex = 7
		  Me._lblMaximumDotHeight.Text = "Maximum Dot Height"
		  ' 
		  ' _lblMaximumDotWidth
		  ' 
		  Me._lblMaximumDotWidth.AutoSize = True
		  Me._lblMaximumDotWidth.Location = New System.Drawing.Point(21, 91)
		  Me._lblMaximumDotWidth.Name = "_lblMaximumDotWidth"
		  Me._lblMaximumDotWidth.Size = New System.Drawing.Size(102, 13)
		  Me._lblMaximumDotWidth.TabIndex = 6
		  Me._lblMaximumDotWidth.Text = "Maximum Dot Width"
		  ' 
		  ' _lblMinimumDotHeight
		  ' 
		  Me._lblMinimumDotHeight.AutoSize = True
		  Me._lblMinimumDotHeight.Location = New System.Drawing.Point(21, 65)
		  Me._lblMinimumDotHeight.Name = "_lblMinimumDotHeight"
		  Me._lblMinimumDotHeight.Size = New System.Drawing.Size(102, 13)
		  Me._lblMinimumDotHeight.TabIndex = 5
		  Me._lblMinimumDotHeight.Text = "Minimum Dot Height"
		  ' 
		  ' _lblMinimumDotWidth
		  ' 
		  Me._lblMinimumDotWidth.AutoSize = True
		  Me._lblMinimumDotWidth.Location = New System.Drawing.Point(21, 39)
		  Me._lblMinimumDotWidth.Name = "_lblMinimumDotWidth"
		  Me._lblMinimumDotWidth.Size = New System.Drawing.Size(99, 13)
		  Me._lblMinimumDotWidth.TabIndex = 4
		  Me._lblMinimumDotWidth.Text = "Minimum Dot Width"
		  ' 
		  ' _tbMaximumDotHeight
		  ' 
		  Me._tbMaximumDotHeight.Location = New System.Drawing.Point(131, 110)
		  Me._tbMaximumDotHeight.Name = "_tbMaximumDotHeight"
		  Me._tbMaximumDotHeight.Size = New System.Drawing.Size(62, 20)
		  Me._tbMaximumDotHeight.TabIndex = 3
'		  Me._tbMaximumDotHeight.TextChanged += New System.EventHandler(Me._tbMaximumDotHeight_TextChanged);
		  ' 
		  ' _tbMaximumDotWidth
		  ' 
		  Me._tbMaximumDotWidth.Location = New System.Drawing.Point(131, 84)
		  Me._tbMaximumDotWidth.Name = "_tbMaximumDotWidth"
		  Me._tbMaximumDotWidth.Size = New System.Drawing.Size(62, 20)
		  Me._tbMaximumDotWidth.TabIndex = 2
'		  Me._tbMaximumDotWidth.TextChanged += New System.EventHandler(Me._tbMaximumDotWidth_TextChanged);
		  ' 
		  ' _tbMinimumDotHeight
		  ' 
		  Me._tbMinimumDotHeight.Location = New System.Drawing.Point(131, 58)
		  Me._tbMinimumDotHeight.Name = "_tbMinimumDotHeight"
		  Me._tbMinimumDotHeight.Size = New System.Drawing.Size(62, 20)
		  Me._tbMinimumDotHeight.TabIndex = 1
'		  Me._tbMinimumDotHeight.TextChanged += New System.EventHandler(Me._tbMinimumDotHeight_TextChanged);
		  ' 
		  ' _tbMinimumDotWidth
		  ' 
		  Me._tbMinimumDotWidth.Location = New System.Drawing.Point(131, 32)
		  Me._tbMinimumDotWidth.Name = "_tbMinimumDotWidth"
		  Me._tbMinimumDotWidth.Size = New System.Drawing.Size(62, 20)
		  Me._tbMinimumDotWidth.TabIndex = 0
'		  Me._tbMinimumDotWidth.TextChanged += New System.EventHandler(Me._tbMinimumDotWidth_TextChanged);
		  ' 
		  ' _btnOk
		  ' 
		  Me._btnOk.Location = New System.Drawing.Point(299, 12)
		  Me._btnOk.Name = "_btnOk"
		  Me._btnOk.Size = New System.Drawing.Size(75, 23)
		  Me._btnOk.TabIndex = 2
		  Me._btnOk.Text = "OK"
		  Me._btnOk.UseVisualStyleBackColor = True
'		  Me._btnOk.Click += New System.EventHandler(Me._btnOk_Click);
		  ' 
		  ' _btnCancel
		  ' 
		  Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		  Me._btnCancel.Location = New System.Drawing.Point(299, 41)
		  Me._btnCancel.Name = "_btnCancel"
		  Me._btnCancel.Size = New System.Drawing.Size(75, 23)
		  Me._btnCancel.TabIndex = 3
		  Me._btnCancel.Text = "Cancel"
		  Me._btnCancel.UseVisualStyleBackColor = True
'		  Me._btnCancel.Click += New System.EventHandler(Me._btnCancel_Click);
		  ' 
		  ' DotRemoveDialog
		  ' 
		  Me.AcceptButton = Me._btnOk
		  Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		  Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		  Me.CancelButton = Me._btnCancel
		  Me.ClientSize = New System.Drawing.Size(384, 282)
		  Me.Controls.Add(Me._btnCancel)
		  Me.Controls.Add(Me._btnOk)
		  Me.Controls.Add(Me._gbDotDimensions)
		  Me.Controls.Add(Me._gbFlags)
		  Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		  Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
		  Me.MaximizeBox = False
		  Me.MinimizeBox = False
		  Me.Name = "DotRemoveDialog"
		  Me.Text = "Dot Removal"
		  Me._gbFlags.ResumeLayout(False)
		  Me._gbFlags.PerformLayout()
		  Me._gbDotDimensions.ResumeLayout(False)
		  Me._gbDotDimensions.PerformLayout()
		  Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private _gbFlags As System.Windows.Forms.GroupBox
	  Private _tbDPI As System.Windows.Forms.TextBox
	  Private _cbUseDiagonals As System.Windows.Forms.CheckBox
	  Private WithEvents _cbUseDotDimensions As System.Windows.Forms.CheckBox
	  Private _cbUseDPI As System.Windows.Forms.CheckBox
	  Private _gbDotDimensions As System.Windows.Forms.GroupBox
	  Private _lbl5 As System.Windows.Forms.Label
	  Private _lbl6 As System.Windows.Forms.Label
	  Private _lbl7 As System.Windows.Forms.Label
	  Private _lbl8 As System.Windows.Forms.Label
	  Private _lblMaximumDotHeight As System.Windows.Forms.Label
	  Private _lblMaximumDotWidth As System.Windows.Forms.Label
	  Private _lblMinimumDotHeight As System.Windows.Forms.Label
	  Private _lblMinimumDotWidth As System.Windows.Forms.Label
	  Private WithEvents _tbMaximumDotHeight As System.Windows.Forms.TextBox
	  Private WithEvents _tbMaximumDotWidth As System.Windows.Forms.TextBox
	  Private WithEvents _tbMinimumDotHeight As System.Windows.Forms.TextBox
	  Private WithEvents _tbMinimumDotWidth As System.Windows.Forms.TextBox
	  Private WithEvents _btnOk As System.Windows.Forms.Button
	  Private WithEvents _btnCancel As System.Windows.Forms.Button
   End Class
End Namespace