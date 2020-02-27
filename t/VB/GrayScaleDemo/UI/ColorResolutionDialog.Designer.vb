
Partial Class ColorResolutionDialog
   ''' <summary>
   ''' Required designer variable.
   ''' </summary>
   Private components As System.ComponentModel.IContainer = Nothing

   ''' <summary>
   ''' Clean up any resources being used.
   ''' </summary>
   ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
   Protected Overrides Sub Dispose(disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
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
      Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(ColorResolutionDialog))
      Me._btnCancel = New System.Windows.Forms.Button()
      Me._btnOk = New System.Windows.Forms.Button()
      Me._grbOptions = New System.Windows.Forms.GroupBox()
      Me._cbDither = New System.Windows.Forms.ComboBox()
      Me._cbPalette = New System.Windows.Forms.ComboBox()
      Me._cbOrder = New System.Windows.Forms.ComboBox()
      Me._cbBitsPerPixel = New System.Windows.Forms.ComboBox()
      Me._lblDither = New System.Windows.Forms.Label()
      Me._lblPalette = New System.Windows.Forms.Label()
      Me._lblOrder = New System.Windows.Forms.Label()
      Me._lblBitsPerPixel = New System.Windows.Forms.Label()
      Me._tsZoomLevel = New System.Windows.Forms.ToolStrip()
      Me._tsbtnNormal = New System.Windows.Forms.ToolStripButton()
      Me._tsbtnFit = New System.Windows.Forms.ToolStripButton()
      Me._lblseparator2 = New System.Windows.Forms.Label()
      Me._lblseparator1 = New System.Windows.Forms.Label()
      Me._pbProgress = New System.Windows.Forms.ProgressBar()
      Me._lblAfter = New System.Windows.Forms.Label()
      Me._lblBefore = New System.Windows.Forms.Label()
      Me._lblAfterlabel = New System.Windows.Forms.Label()
      Me._lblBeforelabel = New System.Windows.Forms.Label()
      Me._grbOptions.SuspendLayout()
      Me._tsZoomLevel.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      resources.ApplyResources(Me._btnCancel, "_btnCancel")
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      ' 
      ' _btnOk
      ' 
      Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
      resources.ApplyResources(Me._btnOk, "_btnOk")
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.UseVisualStyleBackColor = True
      ' 
      ' _grbOptions
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
      resources.ApplyResources(Me._grbOptions, "_grbOptions")
      Me._grbOptions.Name = "_grbOptions"
      Me._grbOptions.TabStop = False
      ' 
      ' _cbDither
      ' 
      Me._cbDither.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cbDither.FormattingEnabled = True
      resources.ApplyResources(Me._cbDither, "_cbDither")
      Me._cbDither.Name = "_cbDither"
      ' 
      ' _cbPalette
      ' 
      Me._cbPalette.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cbPalette.FormattingEnabled = True
      resources.ApplyResources(Me._cbPalette, "_cbPalette")
      Me._cbPalette.Name = "_cbPalette"
      ' 
      ' _cbOrder
      ' 
      Me._cbOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cbOrder.FormattingEnabled = True
      resources.ApplyResources(Me._cbOrder, "_cbOrder")
      Me._cbOrder.Name = "_cbOrder"
      ' 
      ' _cbBitsPerPixel
      ' 
      Me._cbBitsPerPixel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cbBitsPerPixel.FormattingEnabled = True
      resources.ApplyResources(Me._cbBitsPerPixel, "_cbBitsPerPixel")
      Me._cbBitsPerPixel.Name = "_cbBitsPerPixel"
      ' 
      ' _lblDither
      ' 
      Me._lblDither.FlatStyle = System.Windows.Forms.FlatStyle.System
      resources.ApplyResources(Me._lblDither, "_lblDither")
      Me._lblDither.Name = "_lblDither"
      ' 
      ' _lblPalette
      ' 
      Me._lblPalette.FlatStyle = System.Windows.Forms.FlatStyle.System
      resources.ApplyResources(Me._lblPalette, "_lblPalette")
      Me._lblPalette.Name = "_lblPalette"
      ' 
      ' _lblOrder
      ' 
      Me._lblOrder.FlatStyle = System.Windows.Forms.FlatStyle.System
      resources.ApplyResources(Me._lblOrder, "_lblOrder")
      Me._lblOrder.Name = "_lblOrder"
      ' 
      ' _lblBitsPerPixel
      ' 
      Me._lblBitsPerPixel.FlatStyle = System.Windows.Forms.FlatStyle.System
      resources.ApplyResources(Me._lblBitsPerPixel, "_lblBitsPerPixel")
      Me._lblBitsPerPixel.Name = "_lblBitsPerPixel"
      ' 
      ' _tsZoomLevel
      ' 
      Me._tsZoomLevel.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._tsbtnNormal, Me._tsbtnFit})
      resources.ApplyResources(Me._tsZoomLevel, "_tsZoomLevel")
      Me._tsZoomLevel.Name = "_tsZoomLevel"
      Me._tsZoomLevel.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
      ' 
      ' _tsbtnNormal
      ' 
      Me._tsbtnNormal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      resources.ApplyResources(Me._tsbtnNormal, "_tsbtnNormal")
      Me._tsbtnNormal.Name = "_tsbtnNormal"
      ' 
      ' _tsbtnFit
      ' 
      Me._tsbtnFit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      resources.ApplyResources(Me._tsbtnFit, "_tsbtnFit")
      Me._tsbtnFit.Name = "_tsbtnFit"
      ' 
      ' _lblseparator2
      ' 
      Me._lblseparator2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      resources.ApplyResources(Me._lblseparator2, "_lblseparator2")
      Me._lblseparator2.Name = "_lblseparator2"
      ' 
      ' _lblseparator1
      ' 
      Me._lblseparator1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      resources.ApplyResources(Me._lblseparator1, "_lblseparator1")
      Me._lblseparator1.Name = "_lblseparator1"
      ' 
      ' _pbProgress
      ' 
      resources.ApplyResources(Me._pbProgress, "_pbProgress")
      Me._pbProgress.Name = "_pbProgress"
      ' 
      ' _lblAfter
      ' 
      Me._lblAfter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      resources.ApplyResources(Me._lblAfter, "_lblAfter")
      Me._lblAfter.Name = "_lblAfter"
      ' 
      ' _lblBefore
      ' 
      Me._lblBefore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      resources.ApplyResources(Me._lblBefore, "_lblBefore")
      Me._lblBefore.Name = "_lblBefore"
      ' 
      ' _lblAfterlabel
      ' 
      resources.ApplyResources(Me._lblAfterlabel, "_lblAfterlabel")
      Me._lblAfterlabel.Name = "_lblAfterlabel"
      ' 
      ' _lblBeforelabel
      ' 
      resources.ApplyResources(Me._lblBeforelabel, "_lblBeforelabel")
      Me._lblBeforelabel.Name = "_lblBeforelabel"
      ' 
      ' ColorResolutionDialog
      ' 
      Me.AcceptButton = Me._btnOk
      resources.ApplyResources(Me, "$this")
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._btnCancel
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
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "ColorResolutionDialog"
      Me.ShowIcon = False
      Me.ShowInTaskbar = False
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