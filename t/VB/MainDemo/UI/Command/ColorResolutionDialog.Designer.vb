Imports Microsoft.VisualBasic
Imports System
Namespace MainDemo
   Public Partial Class ColorResolutionDialog
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ColorResolutionDialog))
         Me._btnCancel = New System.Windows.Forms.Button
         Me._btnOk = New System.Windows.Forms.Button
         Me._grbOptions = New System.Windows.Forms.GroupBox
         Me._cbDither = New System.Windows.Forms.ComboBox
         Me._cbPalette = New System.Windows.Forms.ComboBox
         Me._cbOrder = New System.Windows.Forms.ComboBox
         Me._cbBitsPerPixel = New System.Windows.Forms.ComboBox
         Me._lblDither = New System.Windows.Forms.Label
         Me._lblPalette = New System.Windows.Forms.Label
         Me._lblOrder = New System.Windows.Forms.Label
         Me._lblBitsPerPixel = New System.Windows.Forms.Label
         Me._tsZoomLevel = New System.Windows.Forms.ToolStrip
         Me._tsbtnNormal = New System.Windows.Forms.ToolStripButton
         Me._tsbtnFit = New System.Windows.Forms.ToolStripButton
         Me._lblseparator2 = New System.Windows.Forms.Label
         Me._lblseparator1 = New System.Windows.Forms.Label
         Me._pbProgress = New System.Windows.Forms.ProgressBar
         Me._lblAfter = New System.Windows.Forms.Label
         Me._lblBefore = New System.Windows.Forms.Label
         Me._lblAfterlabel = New System.Windows.Forms.Label
         Me._lblBeforelabel = New System.Windows.Forms.Label
         Me._grbOptions.SuspendLayout()
         Me._tsZoomLevel.SuspendLayout()
         Me.SuspendLayout()
         '
         '_btnCancel
         '
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnCancel.Location = New System.Drawing.Point(310, 283)
         Me._btnCancel.Margin = New System.Windows.Forms.Padding(2)
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.Size = New System.Drawing.Size(68, 22)
         Me._btnCancel.TabIndex = 2
         Me._btnCancel.Text = "Cancel"
         Me._btnCancel.UseVisualStyleBackColor = True
         '
         '_btnOk
         '
         Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
         Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnOk.Location = New System.Drawing.Point(310, 251)
         Me._btnOk.Margin = New System.Windows.Forms.Padding(2)
         Me._btnOk.Name = "_btnOk"
         Me._btnOk.Size = New System.Drawing.Size(68, 22)
         Me._btnOk.TabIndex = 1
         Me._btnOk.Text = "OK"
         Me._btnOk.UseVisualStyleBackColor = True
         '
         '_grbOptions
         '
         Me._grbOptions.Controls.Add(Me._cbDither)
         Me._grbOptions.Controls.Add(Me._cbPalette)
         Me._grbOptions.Controls.Add(Me._cbOrder)
         Me._grbOptions.Controls.Add(Me._cbBitsPerPixel)
         Me._grbOptions.Controls.Add(Me._lblDither)
         Me._grbOptions.Controls.Add(Me._lblPalette)
         Me._grbOptions.Controls.Add(Me._lblOrder)
         Me._grbOptions.Controls.Add(Me._lblBitsPerPixel)
         Me._grbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._grbOptions.Location = New System.Drawing.Point(8, 245)
         Me._grbOptions.Margin = New System.Windows.Forms.Padding(2)
         Me._grbOptions.Name = "_grbOptions"
         Me._grbOptions.Padding = New System.Windows.Forms.Padding(2)
         Me._grbOptions.Size = New System.Drawing.Size(288, 150)
         Me._grbOptions.TabIndex = 0
         Me._grbOptions.TabStop = False
         '
         '_cbDither
         '
         Me._cbDither.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cbDither.FormattingEnabled = True
         Me._cbDither.Location = New System.Drawing.Point(108, 112)
         Me._cbDither.Margin = New System.Windows.Forms.Padding(2)
         Me._cbDither.Name = "_cbDither"
         Me._cbDither.Size = New System.Drawing.Size(147, 21)
         Me._cbDither.TabIndex = 7
         '
         '_cbPalette
         '
         Me._cbPalette.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cbPalette.FormattingEnabled = True
         Me._cbPalette.Location = New System.Drawing.Point(108, 83)
         Me._cbPalette.Margin = New System.Windows.Forms.Padding(2)
         Me._cbPalette.Name = "_cbPalette"
         Me._cbPalette.Size = New System.Drawing.Size(147, 21)
         Me._cbPalette.TabIndex = 5
         '
         '_cbOrder
         '
         Me._cbOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cbOrder.FormattingEnabled = True
         Me._cbOrder.Location = New System.Drawing.Point(108, 53)
         Me._cbOrder.Margin = New System.Windows.Forms.Padding(2)
         Me._cbOrder.Name = "_cbOrder"
         Me._cbOrder.Size = New System.Drawing.Size(147, 21)
         Me._cbOrder.TabIndex = 3
         '
         '_cbBitsPerPixel
         '
         Me._cbBitsPerPixel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cbBitsPerPixel.FormattingEnabled = True
         Me._cbBitsPerPixel.Location = New System.Drawing.Point(108, 23)
         Me._cbBitsPerPixel.Margin = New System.Windows.Forms.Padding(2)
         Me._cbBitsPerPixel.Name = "_cbBitsPerPixel"
         Me._cbBitsPerPixel.Size = New System.Drawing.Size(147, 21)
         Me._cbBitsPerPixel.TabIndex = 1
         '
         '_lblDither
         '
         Me._lblDither.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblDither.Location = New System.Drawing.Point(14, 112)
         Me._lblDither.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
         Me._lblDither.Name = "_lblDither"
         Me._lblDither.Size = New System.Drawing.Size(86, 22)
         Me._lblDither.TabIndex = 6
         Me._lblDither.Text = "Dither"
         Me._lblDither.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         '
         '_lblPalette
         '
         Me._lblPalette.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblPalette.Location = New System.Drawing.Point(14, 83)
         Me._lblPalette.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
         Me._lblPalette.Name = "_lblPalette"
         Me._lblPalette.Size = New System.Drawing.Size(86, 22)
         Me._lblPalette.TabIndex = 4
         Me._lblPalette.Text = "Palette"
         Me._lblPalette.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         '
         '_lblOrder
         '
         Me._lblOrder.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblOrder.Location = New System.Drawing.Point(14, 53)
         Me._lblOrder.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
         Me._lblOrder.Name = "_lblOrder"
         Me._lblOrder.Size = New System.Drawing.Size(86, 22)
         Me._lblOrder.TabIndex = 2
         Me._lblOrder.Text = "Order:"
         Me._lblOrder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         '
         '_lblBitsPerPixel
         '
         Me._lblBitsPerPixel.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblBitsPerPixel.Location = New System.Drawing.Point(14, 23)
         Me._lblBitsPerPixel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
         Me._lblBitsPerPixel.Name = "_lblBitsPerPixel"
         Me._lblBitsPerPixel.Size = New System.Drawing.Size(86, 22)
         Me._lblBitsPerPixel.TabIndex = 0
         Me._lblBitsPerPixel.Text = "Bits Per Pixel:"
         Me._lblBitsPerPixel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         '
         '_tsZoomLevel
         '
         Me._tsZoomLevel.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._tsbtnNormal, Me._tsbtnFit})
         Me._tsZoomLevel.Location = New System.Drawing.Point(0, 0)
         Me._tsZoomLevel.Name = "_tsZoomLevel"
         Me._tsZoomLevel.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
         Me._tsZoomLevel.Size = New System.Drawing.Size(385, 25)
         Me._tsZoomLevel.TabIndex = 8
         Me._tsZoomLevel.Text = "Zoom Level"
         '
         '_tsbtnNormal
         '
         Me._tsbtnNormal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._tsbtnNormal.Image = CType(resources.GetObject("_tsbtnNormal.Image"), System.Drawing.Image)
         Me._tsbtnNormal.ImageTransparentColor = System.Drawing.Color.Silver
         Me._tsbtnNormal.Name = "_tsbtnNormal"
         Me._tsbtnNormal.Size = New System.Drawing.Size(23, 22)
         Me._tsbtnNormal.Text = "Normal"
         '
         '_tsbtnFit
         '
         Me._tsbtnFit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
         Me._tsbtnFit.Image = CType(resources.GetObject("_tsbtnFit.Image"), System.Drawing.Image)
         Me._tsbtnFit.ImageTransparentColor = System.Drawing.Color.Silver
         Me._tsbtnFit.Name = "_tsbtnFit"
         Me._tsbtnFit.Size = New System.Drawing.Size(23, 22)
         Me._tsbtnFit.Text = "Fit"
         '
         '_lblseparator2
         '
         Me._lblseparator2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._lblseparator2.Location = New System.Drawing.Point(3, 401)
         Me._lblseparator2.Name = "_lblseparator2"
         Me._lblseparator2.Size = New System.Drawing.Size(379, 3)
         Me._lblseparator2.TabIndex = 13
         '
         '_lblseparator1
         '
         Me._lblseparator1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._lblseparator1.Location = New System.Drawing.Point(3, 235)
         Me._lblseparator1.Name = "_lblseparator1"
         Me._lblseparator1.Size = New System.Drawing.Size(379, 3)
         Me._lblseparator1.TabIndex = 14
         '
         '_pbProgress
         '
         Me._pbProgress.Location = New System.Drawing.Point(1, 407)
         Me._pbProgress.Name = "_pbProgress"
         Me._pbProgress.Size = New System.Drawing.Size(381, 19)
         Me._pbProgress.TabIndex = 12
         '
         '_lblAfter
         '
         Me._lblAfter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
         Me._lblAfter.Location = New System.Drawing.Point(196, 30)
         Me._lblAfter.Name = "_lblAfter"
         Me._lblAfter.Size = New System.Drawing.Size(183, 177)
         Me._lblAfter.TabIndex = 10
         Me._lblAfter.Visible = False
         '
         '_lblBefore
         '
         Me._lblBefore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
         Me._lblBefore.Location = New System.Drawing.Point(5, 30)
         Me._lblBefore.Name = "_lblBefore"
         Me._lblBefore.Size = New System.Drawing.Size(183, 177)
         Me._lblBefore.TabIndex = 11
         Me._lblBefore.Visible = False
         '
         '_lblAfterlabel
         '
         Me._lblAfterlabel.Location = New System.Drawing.Point(196, 210)
         Me._lblAfterlabel.Name = "_lblAfterlabel"
         Me._lblAfterlabel.Size = New System.Drawing.Size(183, 24)
         Me._lblAfterlabel.TabIndex = 16
         Me._lblAfterlabel.Text = "After"
         Me._lblAfterlabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
         '
         '_lblBeforelabel
         '
         Me._lblBeforelabel.Location = New System.Drawing.Point(5, 210)
         Me._lblBeforelabel.Name = "_lblBeforelabel"
         Me._lblBeforelabel.Size = New System.Drawing.Size(183, 24)
         Me._lblBeforelabel.TabIndex = 15
         Me._lblBeforelabel.Text = "Before"
         Me._lblBeforelabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
         '
         'ColorResolutionDialog
         '
         Me.AcceptButton = Me._btnOk
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me._btnCancel
         Me.ClientSize = New System.Drawing.Size(385, 429)
         Me.Controls.Add(Me._lblAfterlabel)
         Me.Controls.Add(Me._lblBeforelabel)
         Me.Controls.Add(Me._lblseparator2)
         Me.Controls.Add(Me._lblseparator1)
         Me.Controls.Add(Me._pbProgress)
         Me.Controls.Add(Me._lblAfter)
         Me.Controls.Add(Me._lblBefore)
         Me.Controls.Add(Me._tsZoomLevel)
         Me.Controls.Add(Me._grbOptions)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._btnOk)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.Margin = New System.Windows.Forms.Padding(2)
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "ColorResolutionDialog"
         Me.ShowIcon = False
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Color Resolution"
         Me._grbOptions.ResumeLayout(False)
         Me._tsZoomLevel.ResumeLayout(False)
         Me._tsZoomLevel.PerformLayout()
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub
	  #End Region

	  Private _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button
	  Private _grbOptions As System.Windows.Forms.GroupBox
	  Private _lblBitsPerPixel As System.Windows.Forms.Label
	  Private WithEvents _cbDither As System.Windows.Forms.ComboBox
	  Private WithEvents _cbPalette As System.Windows.Forms.ComboBox
	  Private WithEvents _cbOrder As System.Windows.Forms.ComboBox
	  Private WithEvents _cbBitsPerPixel As System.Windows.Forms.ComboBox
	  Private _lblDither As System.Windows.Forms.Label
	  Private _lblPalette As System.Windows.Forms.Label
	  Private _lblOrder As System.Windows.Forms.Label
      Private _tsZoomLevel As System.Windows.Forms.ToolStrip
      Private WithEvents _tsbtnNormal As System.Windows.Forms.ToolStripButton
      Private WithEvents _tsbtnFit As System.Windows.Forms.ToolStripButton
	  Private _lblseparator2 As System.Windows.Forms.Label
	  Private _lblseparator1 As System.Windows.Forms.Label
	  Private _pbProgress As System.Windows.Forms.ProgressBar
	  Private _lblAfter As System.Windows.Forms.Label
	  Private _lblBefore As System.Windows.Forms.Label
	  Private _lblAfterlabel As System.Windows.Forms.Label
	  Private _lblBeforelabel As System.Windows.Forms.Label
   End Class
End Namespace