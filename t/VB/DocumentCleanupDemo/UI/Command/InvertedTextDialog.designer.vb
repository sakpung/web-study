Imports Microsoft.VisualBasic
Imports System
Namespace DocumentCleanupDemo

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
		  Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InvertedTextDialog))
		  Me._btnOk = New System.Windows.Forms.Button()
		  Me._btnCancel = New System.Windows.Forms.Button()
		  Me._gb1 = New System.Windows.Forms.GroupBox()
		  Me._cbUseDPI = New System.Windows.Forms.CheckBox()
		  Me._tbDPI = New System.Windows.Forms.TextBox()
		  Me._gb2 = New System.Windows.Forms.GroupBox()
		  Me._lbl4 = New System.Windows.Forms.Label()
		  Me._lbl3 = New System.Windows.Forms.Label()
		  Me._tbMinimumInvertHeight = New System.Windows.Forms.TextBox()
		  Me._lblMinimumInvertHeight = New System.Windows.Forms.Label()
		  Me._tbMinimumInvertWidth = New System.Windows.Forms.TextBox()
		  Me._lblMinimumInvertWidth = New System.Windows.Forms.Label()
		  Me._gb3 = New System.Windows.Forms.GroupBox()
		  Me._tbMaximumBlackPercent = New System.Windows.Forms.TextBox()
		  Me._tbMinimumBlackPercent = New System.Windows.Forms.TextBox()
		  Me._lblMaximumBlackPercent = New System.Windows.Forms.Label()
		  Me._lblMinimumBlackPercent = New System.Windows.Forms.Label()
		  Me._gb1.SuspendLayout()
		  Me._gb2.SuspendLayout()
		  Me._gb3.SuspendLayout()
		  Me.SuspendLayout()
		  ' 
		  ' _btnOk
		  ' 
		  Me._btnOk.Location = New System.Drawing.Point(277, 12)
		  Me._btnOk.Name = "_btnOk"
		  Me._btnOk.Size = New System.Drawing.Size(75, 23)
		  Me._btnOk.TabIndex = 0
		  Me._btnOk.Text = "OK"
		  Me._btnOk.UseVisualStyleBackColor = True
'		  Me._btnOk.Click += New System.EventHandler(Me._btnOk_Click);
		  ' 
		  ' _btnCancel
		  ' 
		  Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		  Me._btnCancel.Location = New System.Drawing.Point(277, 41)
		  Me._btnCancel.Name = "_btnCancel"
		  Me._btnCancel.Size = New System.Drawing.Size(75, 23)
		  Me._btnCancel.TabIndex = 1
		  Me._btnCancel.Text = "Cancel"
		  Me._btnCancel.UseVisualStyleBackColor = True
'		  Me._btnCancel.Click += New System.EventHandler(Me._btnCancel_Click);
		  ' 
		  ' _gb1
		  ' 
		  Me._gb1.Controls.Add(Me._cbUseDPI)
		  Me._gb1.Controls.Add(Me._tbDPI)
		  Me._gb1.Location = New System.Drawing.Point(12, 12)
		  Me._gb1.Name = "_gb1"
		  Me._gb1.Size = New System.Drawing.Size(259, 58)
		  Me._gb1.TabIndex = 2
		  Me._gb1.TabStop = False
		  Me._gb1.Text = "Flags"
		  ' 
		  ' _cbUseDPI
		  ' 
		  Me._cbUseDPI.AutoSize = True
		  Me._cbUseDPI.Location = New System.Drawing.Point(21, 25)
		  Me._cbUseDPI.Name = "_cbUseDPI"
		  Me._cbUseDPI.Size = New System.Drawing.Size(66, 17)
		  Me._cbUseDPI.TabIndex = 2
		  Me._cbUseDPI.Text = "Use DPI"
		  Me._cbUseDPI.UseVisualStyleBackColor = True
		  ' 
		  ' _tbDPI
		  ' 
		  Me._tbDPI.Enabled = False
		  Me._tbDPI.Location = New System.Drawing.Point(94, 22)
		  Me._tbDPI.Name = "_tbDPI"
		  Me._tbDPI.Size = New System.Drawing.Size(100, 20)
		  Me._tbDPI.TabIndex = 1
		  ' 
		  ' _gb2
		  ' 
		  Me._gb2.Controls.Add(Me._lbl4)
		  Me._gb2.Controls.Add(Me._lbl3)
		  Me._gb2.Controls.Add(Me._tbMinimumInvertHeight)
		  Me._gb2.Controls.Add(Me._lblMinimumInvertHeight)
		  Me._gb2.Controls.Add(Me._tbMinimumInvertWidth)
		  Me._gb2.Controls.Add(Me._lblMinimumInvertWidth)
		  Me._gb2.Location = New System.Drawing.Point(12, 76)
		  Me._gb2.Name = "_gb2"
		  Me._gb2.Size = New System.Drawing.Size(259, 79)
		  Me._gb2.TabIndex = 3
		  Me._gb2.TabStop = False
		  Me._gb2.Text = "Inverted Text Dimensions"
		  ' 
		  ' _lbl4
		  ' 
		  Me._lbl4.AutoSize = True
		  Me._lbl4.Location = New System.Drawing.Point(200, 58)
		  Me._lbl4.Name = "_lbl4"
		  Me._lbl4.Size = New System.Drawing.Size(29, 13)
		  Me._lbl4.TabIndex = 7
		  Me._lbl4.Text = "_lbl4"
		  ' 
		  ' _lbl3
		  ' 
		  Me._lbl3.AutoSize = True
		  Me._lbl3.Location = New System.Drawing.Point(200, 32)
		  Me._lbl3.Name = "_lbl3"
		  Me._lbl3.Size = New System.Drawing.Size(29, 13)
		  Me._lbl3.TabIndex = 6
		  Me._lbl3.Text = "_lbl3"
		  ' 
		  ' _tbMinimumInvertHeight
		  ' 
		  Me._tbMinimumInvertHeight.Location = New System.Drawing.Point(133, 51)
		  Me._tbMinimumInvertHeight.Name = "_tbMinimumInvertHeight"
		  Me._tbMinimumInvertHeight.Size = New System.Drawing.Size(60, 20)
		  Me._tbMinimumInvertHeight.TabIndex = 5
'		  Me._tbMinimumInvertHeight.TextChanged += New System.EventHandler(Me._tbMinimumInvertHeight_TextChanged);
		  ' 
		  ' _lblMinimumInvertHeight
		  ' 
		  Me._lblMinimumInvertHeight.AutoSize = True
		  Me._lblMinimumInvertHeight.Location = New System.Drawing.Point(18, 52)
		  Me._lblMinimumInvertHeight.Name = "_lblMinimumInvertHeight"
		  Me._lblMinimumInvertHeight.Size = New System.Drawing.Size(112, 13)
		  Me._lblMinimumInvertHeight.TabIndex = 4
		  Me._lblMinimumInvertHeight.Text = "Minimum Invert Height"
		  ' 
		  ' _tbMinimumInvertWidth
		  ' 
		  Me._tbMinimumInvertWidth.Location = New System.Drawing.Point(133, 25)
		  Me._tbMinimumInvertWidth.Name = "_tbMinimumInvertWidth"
		  Me._tbMinimumInvertWidth.Size = New System.Drawing.Size(60, 20)
		  Me._tbMinimumInvertWidth.TabIndex = 3
'		  Me._tbMinimumInvertWidth.TextChanged += New System.EventHandler(Me._tbMinimumInvertWidth_TextChanged);
		  ' 
		  ' _lblMinimumInvertWidth
		  ' 
		  Me._lblMinimumInvertWidth.AutoSize = True
		  Me._lblMinimumInvertWidth.Location = New System.Drawing.Point(18, 25)
		  Me._lblMinimumInvertWidth.Name = "_lblMinimumInvertWidth"
		  Me._lblMinimumInvertWidth.Size = New System.Drawing.Size(109, 13)
		  Me._lblMinimumInvertWidth.TabIndex = 0
		  Me._lblMinimumInvertWidth.Text = "Minimum Invert Width"
		  ' 
		  ' _gb3
		  ' 
		  Me._gb3.Controls.Add(Me._tbMaximumBlackPercent)
		  Me._gb3.Controls.Add(Me._tbMinimumBlackPercent)
		  Me._gb3.Controls.Add(Me._lblMaximumBlackPercent)
		  Me._gb3.Controls.Add(Me._lblMinimumBlackPercent)
		  Me._gb3.Location = New System.Drawing.Point(12, 161)
		  Me._gb3.Name = "_gb3"
		  Me._gb3.Size = New System.Drawing.Size(259, 79)
		  Me._gb3.TabIndex = 4
		  Me._gb3.TabStop = False
		  Me._gb3.Text = "Opacity"
		  ' 
		  ' _tbMaximumBlackPercent
		  ' 
		  Me._tbMaximumBlackPercent.Location = New System.Drawing.Point(133, 43)
		  Me._tbMaximumBlackPercent.Name = "_tbMaximumBlackPercent"
		  Me._tbMaximumBlackPercent.Size = New System.Drawing.Size(60, 20)
		  Me._tbMaximumBlackPercent.TabIndex = 9
'		  Me._tbMaximumBlackPercent.TextChanged += New System.EventHandler(Me._tbMaximumBlackPercent_TextChanged);
		  ' 
		  ' _tbMinimumBlackPercent
		  ' 
		  Me._tbMinimumBlackPercent.Location = New System.Drawing.Point(133, 17)
		  Me._tbMinimumBlackPercent.Name = "_tbMinimumBlackPercent"
		  Me._tbMinimumBlackPercent.Size = New System.Drawing.Size(60, 20)
		  Me._tbMinimumBlackPercent.TabIndex = 8
'		  Me._tbMinimumBlackPercent.TextChanged += New System.EventHandler(Me._tbMinimumBlackPercent_TextChanged);
		  ' 
		  ' _lblMaximumBlackPercent
		  ' 
		  Me._lblMaximumBlackPercent.AutoSize = True
		  Me._lblMaximumBlackPercent.Location = New System.Drawing.Point(9, 50)
		  Me._lblMaximumBlackPercent.Name = "_lblMaximumBlackPercent"
		  Me._lblMaximumBlackPercent.Size = New System.Drawing.Size(121, 13)
		  Me._lblMaximumBlackPercent.TabIndex = 9
		  Me._lblMaximumBlackPercent.Text = "Maximum Black Percent"
		  ' 
		  ' _lblMinimumBlackPercent
		  ' 
		  Me._lblMinimumBlackPercent.AutoSize = True
		  Me._lblMinimumBlackPercent.Location = New System.Drawing.Point(9, 24)
		  Me._lblMinimumBlackPercent.Name = "_lblMinimumBlackPercent"
		  Me._lblMinimumBlackPercent.Size = New System.Drawing.Size(118, 13)
		  Me._lblMinimumBlackPercent.TabIndex = 8
		  Me._lblMinimumBlackPercent.Text = "Minimum Black Percent"
		  ' 
		  ' InvertedTextDialog
		  ' 
		  Me.AcceptButton = Me._btnOk
		  Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		  Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		  Me.CancelButton = Me._btnCancel
		  Me.ClientSize = New System.Drawing.Size(359, 251)
		  Me.Controls.Add(Me._gb3)
		  Me.Controls.Add(Me._gb2)
		  Me.Controls.Add(Me._gb1)
		  Me.Controls.Add(Me._btnCancel)
		  Me.Controls.Add(Me._btnOk)
		  Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		  Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
		  Me.MaximizeBox = False
		  Me.MinimizeBox = False
		  Me.Name = "InvertedTextDialog"
		  Me.Text = "Inverted Text"
		  Me._gb1.ResumeLayout(False)
		  Me._gb1.PerformLayout()
		  Me._gb2.ResumeLayout(False)
		  Me._gb2.PerformLayout()
		  Me._gb3.ResumeLayout(False)
		  Me._gb3.PerformLayout()
		  Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private WithEvents _btnOk As System.Windows.Forms.Button
	  Private WithEvents _btnCancel As System.Windows.Forms.Button
	  Private _gb1 As System.Windows.Forms.GroupBox
	  Private _tbDPI As System.Windows.Forms.TextBox
	  Private _gb2 As System.Windows.Forms.GroupBox
	  Private _gb3 As System.Windows.Forms.GroupBox
	  Private _cbUseDPI As System.Windows.Forms.CheckBox
	  Private _lbl4 As System.Windows.Forms.Label
	  Private _lbl3 As System.Windows.Forms.Label
	  Private WithEvents _tbMinimumInvertHeight As System.Windows.Forms.TextBox
	  Private _lblMinimumInvertHeight As System.Windows.Forms.Label
	  Private WithEvents _tbMinimumInvertWidth As System.Windows.Forms.TextBox
	  Private _lblMinimumInvertWidth As System.Windows.Forms.Label
	  Private _lblMaximumBlackPercent As System.Windows.Forms.Label
	  Private _lblMinimumBlackPercent As System.Windows.Forms.Label
	  Private WithEvents _tbMaximumBlackPercent As System.Windows.Forms.TextBox
	  Private WithEvents _tbMinimumBlackPercent As System.Windows.Forms.TextBox
   End Class
End Namespace