Imports Microsoft.VisualBasic
Imports System

Partial Public Class PaintPropertiesDialog
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
      Me._cbFastPaint = New System.Windows.Forms.CheckBox
      Me._btnApply = New System.Windows.Forms.Button
      Me._gbOptions = New System.Windows.Forms.GroupBox
      Me._cbHalftonePrint = New System.Windows.Forms.CheckBox
      Me._cbIndexedPaint = New System.Windows.Forms.CheckBox
      Me._cbPaintScaling = New System.Windows.Forms.ComboBox
      Me._lblPaintScaling = New System.Windows.Forms.Label
      Me._cbBitonalScaling = New System.Windows.Forms.ComboBox
      Me._cbDithering = New System.Windows.Forms.ComboBox
      Me._lblDithering = New System.Windows.Forms.Label
      Me._lblBitonalScaling = New System.Windows.Forms.Label
      Me._cbPalette = New System.Windows.Forms.ComboBox
      Me._lblPalette = New System.Windows.Forms.Label
      Me._cbOperation = New System.Windows.Forms.ComboBox
      Me._lblOperation = New System.Windows.Forms.Label
      Me._cbEngine = New System.Windows.Forms.ComboBox
      Me._lblEngine = New System.Windows.Forms.Label
      Me._btnCancel = New System.Windows.Forms.Button
      Me._btnOk = New System.Windows.Forms.Button
      Me._gbOptions.SuspendLayout()
      Me.SuspendLayout()
      '
      '_cbFastPaint
      '
      Me._cbFastPaint.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._cbFastPaint.Location = New System.Drawing.Point(22, 97)
      Me._cbFastPaint.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
      Me._cbFastPaint.Name = "_cbFastPaint"
      Me._cbFastPaint.Size = New System.Drawing.Size(100, 23)
      Me._cbFastPaint.TabIndex = 4
      Me._cbFastPaint.Text = "&Fast Paint"
      '
      '_btnApply
      '
      Me._btnApply.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnApply.Location = New System.Drawing.Point(326, 208)
      Me._btnApply.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
      Me._btnApply.Name = "_btnApply"
      Me._btnApply.Size = New System.Drawing.Size(68, 22)
      Me._btnApply.TabIndex = 31
      Me._btnApply.Text = "&Apply"
      '
      '_gbOptions
      '
      Me._gbOptions.Controls.Add(Me._cbFastPaint)
      Me._gbOptions.Controls.Add(Me._cbHalftonePrint)
      Me._gbOptions.Controls.Add(Me._cbIndexedPaint)
      Me._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._gbOptions.Location = New System.Drawing.Point(261, 6)
      Me._gbOptions.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
      Me._gbOptions.Name = "_gbOptions"
      Me._gbOptions.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
      Me._gbOptions.Size = New System.Drawing.Size(137, 180)
      Me._gbOptions.TabIndex = 28
      Me._gbOptions.TabStop = False
      Me._gbOptions.Text = "&Other Paint Options:"
      '
      '_cbHalftonePrint
      '
      Me._cbHalftonePrint.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._cbHalftonePrint.Location = New System.Drawing.Point(22, 67)
      Me._cbHalftonePrint.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
      Me._cbHalftonePrint.Name = "_cbHalftonePrint"
      Me._cbHalftonePrint.Size = New System.Drawing.Size(100, 22)
      Me._cbHalftonePrint.TabIndex = 3
      Me._cbHalftonePrint.Text = "&Halftone Print"
      '
      '_cbIndexedPaint
      '
      Me._cbIndexedPaint.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._cbIndexedPaint.Location = New System.Drawing.Point(22, 36)
      Me._cbIndexedPaint.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
      Me._cbIndexedPaint.Name = "_cbIndexedPaint"
      Me._cbIndexedPaint.Size = New System.Drawing.Size(100, 22)
      Me._cbIndexedPaint.TabIndex = 2
      Me._cbIndexedPaint.Text = "&Indexed Paint"
      '
      '_cbPaintScaling
      '
      Me._cbPaintScaling.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cbPaintScaling.Location = New System.Drawing.Point(139, 163)
      Me._cbPaintScaling.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
      Me._cbPaintScaling.Name = "_cbPaintScaling"
      Me._cbPaintScaling.Size = New System.Drawing.Size(110, 21)
      Me._cbPaintScaling.TabIndex = 27
      '
      '_lblPaintScaling
      '
      Me._lblPaintScaling.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._lblPaintScaling.Location = New System.Drawing.Point(9, 162)
      Me._lblPaintScaling.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
      Me._lblPaintScaling.Name = "_lblPaintScaling"
      Me._lblPaintScaling.Size = New System.Drawing.Size(122, 21)
      Me._lblPaintScaling.TabIndex = 26
      Me._lblPaintScaling.Text = "Paint &Scaling:"
      Me._lblPaintScaling.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      '_cbBitonalScaling
      '
      Me._cbBitonalScaling.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cbBitonalScaling.Location = New System.Drawing.Point(139, 133)
      Me._cbBitonalScaling.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
      Me._cbBitonalScaling.Name = "_cbBitonalScaling"
      Me._cbBitonalScaling.Size = New System.Drawing.Size(110, 21)
      Me._cbBitonalScaling.TabIndex = 25
      '
      '_cbDithering
      '
      Me._cbDithering.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cbDithering.Location = New System.Drawing.Point(139, 73)
      Me._cbDithering.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
      Me._cbDithering.Name = "_cbDithering"
      Me._cbDithering.Size = New System.Drawing.Size(110, 21)
      Me._cbDithering.TabIndex = 21
      '
      '_lblDithering
      '
      Me._lblDithering.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._lblDithering.Location = New System.Drawing.Point(9, 72)
      Me._lblDithering.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
      Me._lblDithering.Name = "_lblDithering"
      Me._lblDithering.Size = New System.Drawing.Size(122, 22)
      Me._lblDithering.TabIndex = 20
      Me._lblDithering.Text = "&Dithering:"
      Me._lblDithering.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      '_lblBitonalScaling
      '
      Me._lblBitonalScaling.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._lblBitonalScaling.Location = New System.Drawing.Point(9, 132)
      Me._lblBitonalScaling.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
      Me._lblBitonalScaling.Name = "_lblBitonalScaling"
      Me._lblBitonalScaling.Size = New System.Drawing.Size(122, 22)
      Me._lblBitonalScaling.TabIndex = 24
      Me._lblBitonalScaling.Text = "&Bitonal Scaling:"
      Me._lblBitonalScaling.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      '_cbPalette
      '
      Me._cbPalette.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cbPalette.Location = New System.Drawing.Point(139, 103)
      Me._cbPalette.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
      Me._cbPalette.Name = "_cbPalette"
      Me._cbPalette.Size = New System.Drawing.Size(110, 21)
      Me._cbPalette.TabIndex = 23
      '
      '_lblPalette
      '
      Me._lblPalette.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._lblPalette.Location = New System.Drawing.Point(9, 102)
      Me._lblPalette.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
      Me._lblPalette.Name = "_lblPalette"
      Me._lblPalette.Size = New System.Drawing.Size(122, 22)
      Me._lblPalette.TabIndex = 22
      Me._lblPalette.Text = "&Palette:"
      Me._lblPalette.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      '_cbOperation
      '
      Me._cbOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cbOperation.Location = New System.Drawing.Point(139, 43)
      Me._cbOperation.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
      Me._cbOperation.Name = "_cbOperation"
      Me._cbOperation.Size = New System.Drawing.Size(110, 21)
      Me._cbOperation.TabIndex = 19
      '
      '_lblOperation
      '
      Me._lblOperation.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._lblOperation.Location = New System.Drawing.Point(9, 42)
      Me._lblOperation.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
      Me._lblOperation.Name = "_lblOperation"
      Me._lblOperation.Size = New System.Drawing.Size(122, 22)
      Me._lblOperation.TabIndex = 18
      Me._lblOperation.Text = "&Raster Operation (ROP):"
      Me._lblOperation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      '_cbEngine
      '
      Me._cbEngine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cbEngine.Location = New System.Drawing.Point(139, 13)
      Me._cbEngine.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
      Me._cbEngine.Name = "_cbEngine"
      Me._cbEngine.Size = New System.Drawing.Size(110, 21)
      Me._cbEngine.TabIndex = 17
      '
      '_lblEngine
      '
      Me._lblEngine.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._lblEngine.Location = New System.Drawing.Point(9, 12)
      Me._lblEngine.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
      Me._lblEngine.Name = "_lblEngine"
      Me._lblEngine.Size = New System.Drawing.Size(122, 22)
      Me._lblEngine.TabIndex = 16
      Me._lblEngine.Text = "&Engine:"
      Me._lblEngine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      '_btnCancel
      '
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnCancel.Location = New System.Drawing.Point(254, 208)
      Me._btnCancel.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(68, 22)
      Me._btnCancel.TabIndex = 30
      Me._btnCancel.Text = "Cancel"
      '
      '_btnOk
      '
      Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnOk.Location = New System.Drawing.Point(182, 208)
      Me._btnOk.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.Size = New System.Drawing.Size(68, 22)
      Me._btnOk.TabIndex = 29
      Me._btnOk.Text = "OK"
      '
      'PaintPropertiesDialog
      '
      Me.AcceptButton = Me._btnOk
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._btnCancel
      Me.ClientSize = New System.Drawing.Size(407, 240)
      Me.Controls.Add(Me._btnApply)
      Me.Controls.Add(Me._gbOptions)
      Me.Controls.Add(Me._cbPaintScaling)
      Me.Controls.Add(Me._lblPaintScaling)
      Me.Controls.Add(Me._cbBitonalScaling)
      Me.Controls.Add(Me._cbDithering)
      Me.Controls.Add(Me._lblDithering)
      Me.Controls.Add(Me._lblBitonalScaling)
      Me.Controls.Add(Me._cbPalette)
      Me.Controls.Add(Me._lblPalette)
      Me.Controls.Add(Me._cbOperation)
      Me.Controls.Add(Me._lblOperation)
      Me.Controls.Add(Me._cbEngine)
      Me.Controls.Add(Me._lblEngine)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnOk)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "PaintPropertiesDialog"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Paint Properties"
      Me._gbOptions.ResumeLayout(False)
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private WithEvents _cbFastPaint As System.Windows.Forms.CheckBox
   Private WithEvents _btnApply As System.Windows.Forms.Button
   Private _gbOptions As System.Windows.Forms.GroupBox
   Private WithEvents _cbHalftonePrint As System.Windows.Forms.CheckBox
   Private WithEvents _cbIndexedPaint As System.Windows.Forms.CheckBox
   Private WithEvents _cbPaintScaling As System.Windows.Forms.ComboBox
   Private _lblPaintScaling As System.Windows.Forms.Label
   Private WithEvents _cbBitonalScaling As System.Windows.Forms.ComboBox
   Private WithEvents _cbDithering As System.Windows.Forms.ComboBox
   Private _lblDithering As System.Windows.Forms.Label
   Private _lblBitonalScaling As System.Windows.Forms.Label
   Private WithEvents _cbPalette As System.Windows.Forms.ComboBox
   Private _lblPalette As System.Windows.Forms.Label
   Private WithEvents _cbOperation As System.Windows.Forms.ComboBox
   Private _lblOperation As System.Windows.Forms.Label
   Private WithEvents _cbEngine As System.Windows.Forms.ComboBox
   Private _lblEngine As System.Windows.Forms.Label
   Private _btnCancel As System.Windows.Forms.Button
   Private WithEvents _btnOk As System.Windows.Forms.Button
End Class
