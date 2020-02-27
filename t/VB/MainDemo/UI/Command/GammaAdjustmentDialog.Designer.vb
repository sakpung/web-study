Imports Microsoft.VisualBasic
Imports System
Namespace MainDemo
   Partial Public Class GammaAdjustmentDialog
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GammaAdjustmentDialog))
         Me._gbOptions = New System.Windows.Forms.GroupBox
         Me._numValue = New System.Windows.Forms.NumericUpDown
         Me._btnCancel = New System.Windows.Forms.Button
         Me._btnOk = New System.Windows.Forms.Button
         Me._tsbtnNormal = New System.Windows.Forms.ToolStripButton
         Me._tsbtnFit = New System.Windows.Forms.ToolStripButton
         Me._pbProgress = New System.Windows.Forms.ProgressBar
         Me._tsZoomLevel = New System.Windows.Forms.ToolStrip
         Me._lblAfter = New System.Windows.Forms.Label
         Me._lblBefore = New System.Windows.Forms.Label
         Me._lblseparator1 = New System.Windows.Forms.Label
         Me._lblseparator2 = New System.Windows.Forms.Label
         Me._lblAfterlabel = New System.Windows.Forms.Label
         Me._lblBeforelabel = New System.Windows.Forms.Label
         Me._gbOptions.SuspendLayout()
         CType(Me._numValue, System.ComponentModel.ISupportInitialize).BeginInit()
         Me._tsZoomLevel.SuspendLayout()
         Me.SuspendLayout()
         '
         '_gbOptions
         '
         Me._gbOptions.Controls.Add(Me._numValue)
         Me._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._gbOptions.Location = New System.Drawing.Point(6, 255)
         Me._gbOptions.Margin = New System.Windows.Forms.Padding(2)
         Me._gbOptions.Name = "_gbOptions"
         Me._gbOptions.Padding = New System.Windows.Forms.Padding(2)
         Me._gbOptions.Size = New System.Drawing.Size(144, 60)
         Me._gbOptions.TabIndex = 4
         Me._gbOptions.TabStop = False
         Me._gbOptions.Text = "Gamma"
         '
         '_numValue
         '
         Me._numValue.BackColor = System.Drawing.SystemColors.Window
         Me._numValue.Location = New System.Drawing.Point(10, 23)
         Me._numValue.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
         Me._numValue.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
         Me._numValue.Name = "_numValue"
         Me._numValue.ReadOnly = True
         Me._numValue.Size = New System.Drawing.Size(121, 20)
         Me._numValue.TabIndex = 0
         Me._numValue.Value = New Decimal(New Integer() {10, 0, 0, 0})
         '
         '_btnCancel
         '
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnCancel.Location = New System.Drawing.Point(307, 291)
         Me._btnCancel.Margin = New System.Windows.Forms.Padding(2)
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.Size = New System.Drawing.Size(68, 22)
         Me._btnCancel.TabIndex = 6
         Me._btnCancel.Text = "Cancel"
         Me._btnCancel.UseVisualStyleBackColor = True
         '
         '_btnOk
         '
         Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
         Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnOk.Location = New System.Drawing.Point(307, 261)
         Me._btnOk.Margin = New System.Windows.Forms.Padding(2)
         Me._btnOk.Name = "_btnOk"
         Me._btnOk.Size = New System.Drawing.Size(68, 22)
         Me._btnOk.TabIndex = 5
         Me._btnOk.Text = "OK"
         Me._btnOk.UseVisualStyleBackColor = True
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
         '_pbProgress
         '
         Me._pbProgress.Location = New System.Drawing.Point(1, 335)
         Me._pbProgress.Name = "_pbProgress"
         Me._pbProgress.Size = New System.Drawing.Size(381, 19)
         Me._pbProgress.TabIndex = 8
         '
         '_tsZoomLevel
         '
         Me._tsZoomLevel.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._tsbtnNormal, Me._tsbtnFit})
         Me._tsZoomLevel.Location = New System.Drawing.Point(0, 0)
         Me._tsZoomLevel.Name = "_tsZoomLevel"
         Me._tsZoomLevel.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
         Me._tsZoomLevel.Size = New System.Drawing.Size(384, 25)
         Me._tsZoomLevel.TabIndex = 0
         Me._tsZoomLevel.Text = "Zoom Level"
         '
         '_lblAfter
         '
         Me._lblAfter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
         Me._lblAfter.Location = New System.Drawing.Point(196, 33)
         Me._lblAfter.Name = "_lblAfter"
         Me._lblAfter.Size = New System.Drawing.Size(183, 177)
         Me._lblAfter.TabIndex = 2
         Me._lblAfter.Visible = False
         '
         '_lblBefore
         '
         Me._lblBefore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
         Me._lblBefore.Location = New System.Drawing.Point(5, 33)
         Me._lblBefore.Name = "_lblBefore"
         Me._lblBefore.Size = New System.Drawing.Size(183, 177)
         Me._lblBefore.TabIndex = 1
         Me._lblBefore.Visible = False
         '
         '_lblseparator1
         '
         Me._lblseparator1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._lblseparator1.Location = New System.Drawing.Point(3, 239)
         Me._lblseparator1.Name = "_lblseparator1"
         Me._lblseparator1.Size = New System.Drawing.Size(379, 3)
         Me._lblseparator1.TabIndex = 3
         '
         '_lblseparator2
         '
         Me._lblseparator2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._lblseparator2.Location = New System.Drawing.Point(3, 329)
         Me._lblseparator2.Name = "_lblseparator2"
         Me._lblseparator2.Size = New System.Drawing.Size(379, 3)
         Me._lblseparator2.TabIndex = 7
         '
         '_lblAfterlabel
         '
         Me._lblAfterlabel.Location = New System.Drawing.Point(196, 213)
         Me._lblAfterlabel.Name = "_lblAfterlabel"
         Me._lblAfterlabel.Size = New System.Drawing.Size(183, 24)
         Me._lblAfterlabel.TabIndex = 11
         Me._lblAfterlabel.Text = "After"
         Me._lblAfterlabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
         '
         '_lblBeforelabel
         '
         Me._lblBeforelabel.Location = New System.Drawing.Point(5, 213)
         Me._lblBeforelabel.Name = "_lblBeforelabel"
         Me._lblBeforelabel.Size = New System.Drawing.Size(183, 24)
         Me._lblBeforelabel.TabIndex = 10
         Me._lblBeforelabel.Text = "Before"
         Me._lblBeforelabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
         '
         'GammaAdjustmentDialog
         '
         Me.ClientSize = New System.Drawing.Size(384, 358)
         Me.Controls.Add(Me._lblAfterlabel)
         Me.Controls.Add(Me._lblBeforelabel)
         Me.Controls.Add(Me._lblseparator2)
         Me.Controls.Add(Me._lblseparator1)
         Me.Controls.Add(Me._pbProgress)
         Me.Controls.Add(Me._tsZoomLevel)
         Me.Controls.Add(Me._lblAfter)
         Me.Controls.Add(Me._lblBefore)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._btnOk)
         Me.Controls.Add(Me._gbOptions)
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "GammaAdjustmentDialog"
         Me.ShowIcon = False
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Gamma Adjustment"
         Me._gbOptions.ResumeLayout(False)
         CType(Me._numValue, System.ComponentModel.ISupportInitialize).EndInit()
         Me._tsZoomLevel.ResumeLayout(False)
         Me._tsZoomLevel.PerformLayout()
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub
#End Region

      Private _gbOptions As System.Windows.Forms.GroupBox
      Private _btnCancel As System.Windows.Forms.Button
      Private WithEvents _btnOk As System.Windows.Forms.Button
      Private WithEvents _tsbtnNormal As System.Windows.Forms.ToolStripButton
      Private WithEvents _tsbtnFit As System.Windows.Forms.ToolStripButton
      Private _pbProgress As System.Windows.Forms.ProgressBar
      Private _tsZoomLevel As System.Windows.Forms.ToolStrip
      Private _lblAfter As System.Windows.Forms.Label
      Private _lblBefore As System.Windows.Forms.Label
      Private _lblseparator1 As System.Windows.Forms.Label
      Private _lblseparator2 As System.Windows.Forms.Label
      Private _lblAfterlabel As System.Windows.Forms.Label
      Private _lblBeforelabel As System.Windows.Forms.Label
      Friend WithEvents _numValue As System.Windows.Forms.NumericUpDown
   End Class
End Namespace
