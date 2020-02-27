Imports Microsoft.VisualBasic
Imports System
Namespace Leadtools.Demos
   Public Partial Class RawDialog
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
		 Me._gbMain = New System.Windows.Forms.GroupBox()
		 Me._cmbPalette = New System.Windows.Forms.ComboBox()
		 Me._cmbColorOrder = New System.Windows.Forms.ComboBox()
		 Me._cmbViewPerspective = New System.Windows.Forms.ComboBox()
		 Me._cbBitsPerPixel = New System.Windows.Forms.ComboBox()
		 Me._cmbFormat = New System.Windows.Forms.ComboBox()
		 Me._tbOffst = New System.Windows.Forms.TextBox()
		 Me._tbVertical = New System.Windows.Forms.TextBox()
		 Me._tbHorizontal = New System.Windows.Forms.TextBox()
		 Me._tbHeight = New System.Windows.Forms.TextBox()
		 Me._tbWidth = New System.Windows.Forms.TextBox()
		 Me._cbWhiteOnBlack = New System.Windows.Forms.CheckBox()
		 Me._cbPadLine4Bytes = New System.Windows.Forms.CheckBox()
		 Me._cbLSBFirst = New System.Windows.Forms.CheckBox()
		 Me._lblVertical = New System.Windows.Forms.Label()
		 Me._lblPalette = New System.Windows.Forms.Label()
		 Me._lblColorOrder = New System.Windows.Forms.Label()
		 Me._lblBitsPerPixel = New System.Windows.Forms.Label()
		 Me._lblHeight = New System.Windows.Forms.Label()
		 Me._lblViewPerspective = New System.Windows.Forms.Label()
		 Me._lblHorizontal = New System.Windows.Forms.Label()
		 Me._lblOffset = New System.Windows.Forms.Label()
		 Me._lblWidth = New System.Windows.Forms.Label()
		 Me._lblFormat = New System.Windows.Forms.Label()
		 Me._gbMain.SuspendLayout()
		 Me.SuspendLayout()
		 ' 
		 ' _btnCancel
		 ' 
		 Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		 Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._btnCancel.Location = New System.Drawing.Point(432, 55)
		 Me._btnCancel.Name = "_btnCancel"
		 Me._btnCancel.Size = New System.Drawing.Size(90, 27)
		 Me._btnCancel.TabIndex = 2
		 Me._btnCancel.Text = "Cancel"
		 Me._btnCancel.UseVisualStyleBackColor = True
		 ' 
		 ' _btnOk
		 ' 
		 Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
		 Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._btnOk.Location = New System.Drawing.Point(432, 18)
		 Me._btnOk.Name = "_btnOk"
		 Me._btnOk.Size = New System.Drawing.Size(90, 27)
		 Me._btnOk.TabIndex = 1
		 Me._btnOk.Text = "OK"
		 Me._btnOk.UseVisualStyleBackColor = True
'		 Me._btnOk.Click += New System.EventHandler(Me._btnOk_Click);
		 ' 
		 ' _gbMain
		 ' 
		 Me._gbMain.Controls.Add(Me._cmbPalette)
		 Me._gbMain.Controls.Add(Me._cmbColorOrder)
		 Me._gbMain.Controls.Add(Me._cmbViewPerspective)
		 Me._gbMain.Controls.Add(Me._cbBitsPerPixel)
		 Me._gbMain.Controls.Add(Me._cmbFormat)
		 Me._gbMain.Controls.Add(Me._tbOffst)
		 Me._gbMain.Controls.Add(Me._tbVertical)
		 Me._gbMain.Controls.Add(Me._tbHorizontal)
		 Me._gbMain.Controls.Add(Me._tbHeight)
		 Me._gbMain.Controls.Add(Me._tbWidth)
		 Me._gbMain.Controls.Add(Me._cbWhiteOnBlack)
		 Me._gbMain.Controls.Add(Me._cbPadLine4Bytes)
		 Me._gbMain.Controls.Add(Me._cbLSBFirst)
		 Me._gbMain.Controls.Add(Me._lblVertical)
		 Me._gbMain.Controls.Add(Me._lblPalette)
		 Me._gbMain.Controls.Add(Me._lblColorOrder)
		 Me._gbMain.Controls.Add(Me._lblBitsPerPixel)
		 Me._gbMain.Controls.Add(Me._lblHeight)
		 Me._gbMain.Controls.Add(Me._lblViewPerspective)
		 Me._gbMain.Controls.Add(Me._lblHorizontal)
		 Me._gbMain.Controls.Add(Me._lblOffset)
		 Me._gbMain.Controls.Add(Me._lblWidth)
		 Me._gbMain.Controls.Add(Me._lblFormat)
		 Me._gbMain.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._gbMain.Location = New System.Drawing.Point(10, 0)
		 Me._gbMain.Name = "_gbMain"
		 Me._gbMain.Size = New System.Drawing.Size(403, 415)
		 Me._gbMain.TabIndex = 0
		 Me._gbMain.TabStop = False
		 ' 
		 ' _cmbPalette
		 ' 
		 Me._cmbPalette.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me._cmbPalette.FormattingEnabled = True
		 Me._cmbPalette.Location = New System.Drawing.Point(173, 267)
		 Me._cmbPalette.Name = "_cmbPalette"
		 Me._cmbPalette.Size = New System.Drawing.Size(173, 24)
		 Me._cmbPalette.TabIndex = 19
		 ' 
		 ' _cmbColorOrder
		 ' 
		 Me._cmbColorOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me._cmbColorOrder.FormattingEnabled = True
		 Me._cmbColorOrder.Location = New System.Drawing.Point(173, 232)
		 Me._cmbColorOrder.Name = "_cmbColorOrder"
		 Me._cmbColorOrder.Size = New System.Drawing.Size(173, 24)
		 Me._cmbColorOrder.TabIndex = 17
		 ' 
		 ' _cmbViewPerspective
		 ' 
		 Me._cmbViewPerspective.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me._cmbViewPerspective.FormattingEnabled = True
		 Me._cmbViewPerspective.Location = New System.Drawing.Point(173, 197)
		 Me._cmbViewPerspective.Name = "_cmbViewPerspective"
		 Me._cmbViewPerspective.Size = New System.Drawing.Size(173, 24)
		 Me._cmbViewPerspective.TabIndex = 15
		 ' 
		 ' _cbBitsPerPixel
		 ' 
		 Me._cbBitsPerPixel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me._cbBitsPerPixel.FormattingEnabled = True
		 Me._cbBitsPerPixel.Location = New System.Drawing.Point(173, 163)
		 Me._cbBitsPerPixel.Name = "_cbBitsPerPixel"
		 Me._cbBitsPerPixel.Size = New System.Drawing.Size(173, 24)
		 Me._cbBitsPerPixel.TabIndex = 13
'		 Me._cbBitsPerPixel.SelectedIndexChanged += New System.EventHandler(Me._cbBitsPerPixel_SelectedIndexChanged);
		 ' 
		 ' _cmbFormat
		 ' 
		 Me._cmbFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me._cmbFormat.FormattingEnabled = True
		 Me._cmbFormat.Location = New System.Drawing.Point(173, 28)
		 Me._cmbFormat.Name = "_cmbFormat"
		 Me._cmbFormat.Size = New System.Drawing.Size(173, 24)
		 Me._cmbFormat.TabIndex = 1
'		 Me._cmbFormat.SelectedIndexChanged += New System.EventHandler(Me._cmbFormat_SelectedIndexChanged);
		 ' 
		 ' _tbOffst
		 ' 
		 Me._tbOffst.Location = New System.Drawing.Point(173, 129)
		 Me._tbOffst.Name = "_tbOffst"
		 Me._tbOffst.Size = New System.Drawing.Size(173, 22)
		 Me._tbOffst.TabIndex = 11
		 ' 
		 ' _tbVertical
		 ' 
		 Me._tbVertical.Location = New System.Drawing.Point(269, 96)
		 Me._tbVertical.Name = "_tbVertical"
		 Me._tbVertical.Size = New System.Drawing.Size(77, 22)
		 Me._tbVertical.TabIndex = 9
		 ' 
		 ' _tbHorizontal
		 ' 
		 Me._tbHorizontal.Location = New System.Drawing.Point(269, 62)
		 Me._tbHorizontal.Name = "_tbHorizontal"
		 Me._tbHorizontal.Size = New System.Drawing.Size(77, 22)
		 Me._tbHorizontal.TabIndex = 5
		 ' 
		 ' _tbHeight
		 ' 
		 Me._tbHeight.Location = New System.Drawing.Point(96, 96)
		 Me._tbHeight.Name = "_tbHeight"
		 Me._tbHeight.Size = New System.Drawing.Size(77, 22)
		 Me._tbHeight.TabIndex = 7
		 ' 
		 ' _tbWidth
		 ' 
		 Me._tbWidth.Location = New System.Drawing.Point(96, 62)
		 Me._tbWidth.Name = "_tbWidth"
		 Me._tbWidth.Size = New System.Drawing.Size(77, 22)
		 Me._tbWidth.TabIndex = 3
		 ' 
		 ' _cbWhiteOnBlack
		 ' 
		 Me._cbWhiteOnBlack.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._cbWhiteOnBlack.Location = New System.Drawing.Point(19, 377)
		 Me._cbWhiteOnBlack.Name = "_cbWhiteOnBlack"
		 Me._cbWhiteOnBlack.Size = New System.Drawing.Size(154, 28)
		 Me._cbWhiteOnBlack.TabIndex = 22
		 Me._cbWhiteOnBlack.Text = "White on Black"
		 Me._cbWhiteOnBlack.UseVisualStyleBackColor = True
		 ' 
		 ' _cbPadLine4Bytes
		 ' 
		 Me._cbPadLine4Bytes.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._cbPadLine4Bytes.Location = New System.Drawing.Point(19, 339)
		 Me._cbPadLine4Bytes.Name = "_cbPadLine4Bytes"
		 Me._cbPadLine4Bytes.Size = New System.Drawing.Size(154, 28)
		 Me._cbPadLine4Bytes.TabIndex = 21
		 Me._cbPadLine4Bytes.Text = "Pad Line 4 Bytes"
		 Me._cbPadLine4Bytes.UseVisualStyleBackColor = True
		 ' 
		 ' _cbLSBFirst
		 ' 
		 Me._cbLSBFirst.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._cbLSBFirst.Location = New System.Drawing.Point(19, 301)
		 Me._cbLSBFirst.Name = "_cbLSBFirst"
		 Me._cbLSBFirst.Size = New System.Drawing.Size(154, 28)
		 Me._cbLSBFirst.TabIndex = 20
		 Me._cbLSBFirst.Text = "Fill Order - LSB First"
		 Me._cbLSBFirst.UseVisualStyleBackColor = True
		 ' 
		 ' _lblVertical
		 ' 
		 Me._lblVertical.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblVertical.Location = New System.Drawing.Point(192, 98)
		 Me._lblVertical.Name = "_lblVertical"
		 Me._lblVertical.Size = New System.Drawing.Size(67, 19)
		 Me._lblVertical.TabIndex = 8
		 Me._lblVertical.Text = "Y Res"
		 Me._lblVertical.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' _lblPalette
		 ' 
		 Me._lblPalette.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblPalette.Location = New System.Drawing.Point(19, 269)
		 Me._lblPalette.Name = "_lblPalette"
		 Me._lblPalette.Size = New System.Drawing.Size(115, 18)
		 Me._lblPalette.TabIndex = 18
		 Me._lblPalette.Text = "Palette"
		 Me._lblPalette.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' _lblColorOrder
		 ' 
		 Me._lblColorOrder.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblColorOrder.Location = New System.Drawing.Point(19, 234)
		 Me._lblColorOrder.Name = "_lblColorOrder"
		 Me._lblColorOrder.Size = New System.Drawing.Size(115, 19)
		 Me._lblColorOrder.TabIndex = 16
		 Me._lblColorOrder.Text = "Color Order"
		 Me._lblColorOrder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' _lblBitsPerPixel
		 ' 
		 Me._lblBitsPerPixel.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblBitsPerPixel.Location = New System.Drawing.Point(19, 165)
		 Me._lblBitsPerPixel.Name = "_lblBitsPerPixel"
		 Me._lblBitsPerPixel.Size = New System.Drawing.Size(115, 18)
		 Me._lblBitsPerPixel.TabIndex = 12
		 Me._lblBitsPerPixel.Text = "Bits Per Pixel"
		 Me._lblBitsPerPixel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' _lblHeight
		 ' 
		 Me._lblHeight.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblHeight.Location = New System.Drawing.Point(19, 98)
		 Me._lblHeight.Name = "_lblHeight"
		 Me._lblHeight.Size = New System.Drawing.Size(58, 19)
		 Me._lblHeight.TabIndex = 6
		 Me._lblHeight.Text = "Height"
		 Me._lblHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' _lblViewPerspective
		 ' 
		 Me._lblViewPerspective.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblViewPerspective.Location = New System.Drawing.Point(19, 200)
		 Me._lblViewPerspective.Name = "_lblViewPerspective"
		 Me._lblViewPerspective.Size = New System.Drawing.Size(115, 18)
		 Me._lblViewPerspective.TabIndex = 14
		 Me._lblViewPerspective.Text = "View Perspective"
		 Me._lblViewPerspective.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' _lblHorizontal
		 ' 
		 Me._lblHorizontal.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblHorizontal.Location = New System.Drawing.Point(192, 65)
		 Me._lblHorizontal.Name = "_lblHorizontal"
		 Me._lblHorizontal.Size = New System.Drawing.Size(77, 18)
		 Me._lblHorizontal.TabIndex = 4
		 Me._lblHorizontal.Text = "X Res"
		 Me._lblHorizontal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' _lblOffset
		 ' 
		 Me._lblOffset.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblOffset.Location = New System.Drawing.Point(19, 132)
		 Me._lblOffset.Name = "_lblOffset"
		 Me._lblOffset.Size = New System.Drawing.Size(115, 18)
		 Me._lblOffset.TabIndex = 10
		 Me._lblOffset.Text = "Offset"
		 Me._lblOffset.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' _lblWidth
		 ' 
		 Me._lblWidth.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblWidth.Location = New System.Drawing.Point(19, 65)
		 Me._lblWidth.Name = "_lblWidth"
		 Me._lblWidth.Size = New System.Drawing.Size(48, 18)
		 Me._lblWidth.TabIndex = 2
		 Me._lblWidth.Text = "Width"
		 Me._lblWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' _lblFormat
		 ' 
		 Me._lblFormat.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._lblFormat.Location = New System.Drawing.Point(19, 30)
		 Me._lblFormat.Name = "_lblFormat"
		 Me._lblFormat.Size = New System.Drawing.Size(120, 18)
		 Me._lblFormat.TabIndex = 0
		 Me._lblFormat.Text = "Format"
		 Me._lblFormat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		 ' 
		 ' RawDialog
		 ' 
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(8F, 16F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.ClientSize = New System.Drawing.Size(534, 428)
		 Me.Controls.Add(Me._gbMain)
		 Me.Controls.Add(Me._btnCancel)
		 Me.Controls.Add(Me._btnOk)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		 Me.MaximizeBox = False
		 Me.MinimizeBox = False
		 Me.Name = "RawDialog"
		 Me.ShowInTaskbar = False
		 Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		 Me.Text = "RawDialog"
'		 Me.Load += New System.EventHandler(Me.RawDialog_Load);
		 Me._gbMain.ResumeLayout(False)
		 Me._gbMain.PerformLayout()
		 Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button
	  Private _gbMain As System.Windows.Forms.GroupBox
	  Private _lblVertical As System.Windows.Forms.Label
	  Private _lblColorOrder As System.Windows.Forms.Label
	  Private _lblBitsPerPixel As System.Windows.Forms.Label
	  Private _lblHeight As System.Windows.Forms.Label
	  Private _lblViewPerspective As System.Windows.Forms.Label
	  Private _lblHorizontal As System.Windows.Forms.Label
	  Private _lblOffset As System.Windows.Forms.Label
	  Private _lblWidth As System.Windows.Forms.Label
	  Private _lblFormat As System.Windows.Forms.Label
	  Private _lblPalette As System.Windows.Forms.Label
	  Private _cbLSBFirst As System.Windows.Forms.CheckBox
	  Private _cbWhiteOnBlack As System.Windows.Forms.CheckBox
	  Private _cbPadLine4Bytes As System.Windows.Forms.CheckBox
	  Private _tbOffst As System.Windows.Forms.TextBox
	  Private _tbVertical As System.Windows.Forms.TextBox
	  Private _tbHorizontal As System.Windows.Forms.TextBox
	  Private _tbHeight As System.Windows.Forms.TextBox
	  Private _tbWidth As System.Windows.Forms.TextBox
	  Private _cmbPalette As System.Windows.Forms.ComboBox
	  Private _cmbColorOrder As System.Windows.Forms.ComboBox
	  Private _cmbViewPerspective As System.Windows.Forms.ComboBox
	  Private WithEvents _cbBitsPerPixel As System.Windows.Forms.ComboBox
	  Private WithEvents _cmbFormat As System.Windows.Forms.ComboBox
   End Class
End Namespace