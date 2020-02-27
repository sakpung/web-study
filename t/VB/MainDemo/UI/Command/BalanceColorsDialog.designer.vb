Imports Microsoft.VisualBasic
Imports System
Namespace MainDemo
   Partial Public Class BalanceColorsDialog
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BalanceColorsDialog))
         Me._gbRedWeights = New System.Windows.Forms.GroupBox
         Me._lblBlueinRedWeight = New System.Windows.Forms.Label
         Me._lblGreeninRedWeight = New System.Windows.Forms.Label
         Me._lblRedinRedWeight = New System.Windows.Forms.Label
         Me._numBlueinRedWeight = New System.Windows.Forms.NumericUpDown
         Me._numGreeninRedWeight = New System.Windows.Forms.NumericUpDown
         Me._numRedinRedWeight = New System.Windows.Forms.NumericUpDown
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
         Me._gbGreenWeights = New System.Windows.Forms.GroupBox
         Me._lblBlueinGreenWeight = New System.Windows.Forms.Label
         Me._lblGreeninGreenWeight = New System.Windows.Forms.Label
         Me._lblRedinGreenWeight = New System.Windows.Forms.Label
         Me._numBlueinGreenWeight = New System.Windows.Forms.NumericUpDown
         Me._numGreeninGreenWeight = New System.Windows.Forms.NumericUpDown
         Me._numRedinGreenWeight = New System.Windows.Forms.NumericUpDown
         Me._gbBlueWeights = New System.Windows.Forms.GroupBox
         Me._lblBlueinBlueWeight = New System.Windows.Forms.Label
         Me._lblGreeninBlueWeight = New System.Windows.Forms.Label
         Me._lblRedinBlueWeight = New System.Windows.Forms.Label
         Me._numBlueinBlueWeight = New System.Windows.Forms.NumericUpDown
         Me._numGreeninBlueWeight = New System.Windows.Forms.NumericUpDown
         Me._numRedinBlueWeight = New System.Windows.Forms.NumericUpDown
         Me._gbRedWeights.SuspendLayout()
         CType(Me._numBlueinRedWeight, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me._numGreeninRedWeight, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me._numRedinRedWeight, System.ComponentModel.ISupportInitialize).BeginInit()
         Me._tsZoomLevel.SuspendLayout()
         Me._gbGreenWeights.SuspendLayout()
         CType(Me._numBlueinGreenWeight, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me._numGreeninGreenWeight, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me._numRedinGreenWeight, System.ComponentModel.ISupportInitialize).BeginInit()
         Me._gbBlueWeights.SuspendLayout()
         CType(Me._numBlueinBlueWeight, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me._numGreeninBlueWeight, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me._numRedinBlueWeight, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.SuspendLayout()
         '
         '_gbRedWeights
         '
         Me._gbRedWeights.Controls.Add(Me._lblBlueinRedWeight)
         Me._gbRedWeights.Controls.Add(Me._lblGreeninRedWeight)
         Me._gbRedWeights.Controls.Add(Me._lblRedinRedWeight)
         Me._gbRedWeights.Controls.Add(Me._numBlueinRedWeight)
         Me._gbRedWeights.Controls.Add(Me._numGreeninRedWeight)
         Me._gbRedWeights.Controls.Add(Me._numRedinRedWeight)
         Me._gbRedWeights.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._gbRedWeights.Location = New System.Drawing.Point(6, 248)
         Me._gbRedWeights.Margin = New System.Windows.Forms.Padding(2)
         Me._gbRedWeights.Name = "_gbRedWeights"
         Me._gbRedWeights.Padding = New System.Windows.Forms.Padding(2)
         Me._gbRedWeights.Size = New System.Drawing.Size(292, 49)
         Me._gbRedWeights.TabIndex = 6
         Me._gbRedWeights.TabStop = False
         Me._gbRedWeights.Text = "Red Weights"
         '
         '_lblBlueinRedWeight
         '
         Me._lblBlueinRedWeight.AutoSize = True
         Me._lblBlueinRedWeight.Location = New System.Drawing.Point(206, 23)
         Me._lblBlueinRedWeight.Name = "_lblBlueinRedWeight"
         Me._lblBlueinRedWeight.Size = New System.Drawing.Size(28, 13)
         Me._lblBlueinRedWeight.TabIndex = 4
         Me._lblBlueinRedWeight.Text = "Blue"
         '
         '_lblGreeninRedWeight
         '
         Me._lblGreeninRedWeight.AutoSize = True
         Me._lblGreeninRedWeight.Location = New System.Drawing.Point(107, 23)
         Me._lblGreeninRedWeight.Name = "_lblGreeninRedWeight"
         Me._lblGreeninRedWeight.Size = New System.Drawing.Size(36, 13)
         Me._lblGreeninRedWeight.TabIndex = 2
         Me._lblGreeninRedWeight.Text = "Green"
         '
         '_lblRedinRedWeight
         '
         Me._lblRedinRedWeight.AutoSize = True
         Me._lblRedinRedWeight.Location = New System.Drawing.Point(11, 23)
         Me._lblRedinRedWeight.Name = "_lblRedinRedWeight"
         Me._lblRedinRedWeight.Size = New System.Drawing.Size(27, 13)
         Me._lblRedinRedWeight.TabIndex = 0
         Me._lblRedinRedWeight.Text = "Red"
         '
         '_numBlueinRedWeight
         '
         Me._numBlueinRedWeight.BackColor = System.Drawing.SystemColors.Window
         Me._numBlueinRedWeight.Location = New System.Drawing.Point(240, 20)
         Me._numBlueinRedWeight.Margin = New System.Windows.Forms.Padding(2)
         Me._numBlueinRedWeight.Name = "_numBlueinRedWeight"
         Me._numBlueinRedWeight.Size = New System.Drawing.Size(41, 20)
         Me._numBlueinRedWeight.TabIndex = 5
         '
         '_numGreeninRedWeight
         '
         Me._numGreeninRedWeight.BackColor = System.Drawing.SystemColors.Window
         Me._numGreeninRedWeight.Location = New System.Drawing.Point(148, 20)
         Me._numGreeninRedWeight.Margin = New System.Windows.Forms.Padding(2)
         Me._numGreeninRedWeight.Name = "_numGreeninRedWeight"
         Me._numGreeninRedWeight.Size = New System.Drawing.Size(41, 20)
         Me._numGreeninRedWeight.TabIndex = 3
         '
         '_numRedinRedWeight
         '
         Me._numRedinRedWeight.BackColor = System.Drawing.SystemColors.Window
         Me._numRedinRedWeight.Location = New System.Drawing.Point(47, 20)
         Me._numRedinRedWeight.Margin = New System.Windows.Forms.Padding(2)
         Me._numRedinRedWeight.Name = "_numRedinRedWeight"
         Me._numRedinRedWeight.Size = New System.Drawing.Size(41, 20)
         Me._numRedinRedWeight.TabIndex = 1
         '
         '_btnCancel
         '
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnCancel.Location = New System.Drawing.Point(310, 283)
         Me._btnCancel.Margin = New System.Windows.Forms.Padding(2)
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.Size = New System.Drawing.Size(68, 22)
         Me._btnCancel.TabIndex = 10
         Me._btnCancel.Text = "Cancel"
         Me._btnCancel.UseVisualStyleBackColor = True
         '
         '_btnOk
         '
         Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
         Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnOk.Location = New System.Drawing.Point(310, 253)
         Me._btnOk.Margin = New System.Windows.Forms.Padding(2)
         Me._btnOk.Name = "_btnOk"
         Me._btnOk.Size = New System.Drawing.Size(68, 22)
         Me._btnOk.TabIndex = 9
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
         Me._pbProgress.Location = New System.Drawing.Point(1, 424)
         Me._pbProgress.Name = "_pbProgress"
         Me._pbProgress.Size = New System.Drawing.Size(381, 19)
         Me._pbProgress.TabIndex = 12
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
         Me._lblseparator1.Location = New System.Drawing.Point(3, 240)
         Me._lblseparator1.Name = "_lblseparator1"
         Me._lblseparator1.Size = New System.Drawing.Size(379, 3)
         Me._lblseparator1.TabIndex = 5
         '
         '_lblseparator2
         '
         Me._lblseparator2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._lblseparator2.Location = New System.Drawing.Point(3, 418)
         Me._lblseparator2.Name = "_lblseparator2"
         Me._lblseparator2.Size = New System.Drawing.Size(379, 3)
         Me._lblseparator2.TabIndex = 11
         '
         '_lblAfterlabel
         '
         Me._lblAfterlabel.Location = New System.Drawing.Point(196, 213)
         Me._lblAfterlabel.Name = "_lblAfterlabel"
         Me._lblAfterlabel.Size = New System.Drawing.Size(183, 24)
         Me._lblAfterlabel.TabIndex = 4
         Me._lblAfterlabel.Text = "After"
         Me._lblAfterlabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
         '
         '_lblBeforelabel
         '
         Me._lblBeforelabel.Location = New System.Drawing.Point(5, 213)
         Me._lblBeforelabel.Name = "_lblBeforelabel"
         Me._lblBeforelabel.Size = New System.Drawing.Size(183, 24)
         Me._lblBeforelabel.TabIndex = 3
         Me._lblBeforelabel.Text = "Before"
         Me._lblBeforelabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
         '
         '_gbGreenWeights
         '
         Me._gbGreenWeights.Controls.Add(Me._lblBlueinGreenWeight)
         Me._gbGreenWeights.Controls.Add(Me._lblGreeninGreenWeight)
         Me._gbGreenWeights.Controls.Add(Me._lblRedinGreenWeight)
         Me._gbGreenWeights.Controls.Add(Me._numBlueinGreenWeight)
         Me._gbGreenWeights.Controls.Add(Me._numGreeninGreenWeight)
         Me._gbGreenWeights.Controls.Add(Me._numRedinGreenWeight)
         Me._gbGreenWeights.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._gbGreenWeights.Location = New System.Drawing.Point(6, 304)
         Me._gbGreenWeights.Margin = New System.Windows.Forms.Padding(2)
         Me._gbGreenWeights.Name = "_gbGreenWeights"
         Me._gbGreenWeights.Padding = New System.Windows.Forms.Padding(2)
         Me._gbGreenWeights.Size = New System.Drawing.Size(292, 49)
         Me._gbGreenWeights.TabIndex = 7
         Me._gbGreenWeights.TabStop = False
         Me._gbGreenWeights.Text = "Green Weights"
         '
         '_lblBlueinGreenWeight
         '
         Me._lblBlueinGreenWeight.AutoSize = True
         Me._lblBlueinGreenWeight.Location = New System.Drawing.Point(206, 23)
         Me._lblBlueinGreenWeight.Name = "_lblBlueinGreenWeight"
         Me._lblBlueinGreenWeight.Size = New System.Drawing.Size(28, 13)
         Me._lblBlueinGreenWeight.TabIndex = 4
         Me._lblBlueinGreenWeight.Text = "Blue"
         '
         '_lblGreeninGreenWeight
         '
         Me._lblGreeninGreenWeight.AutoSize = True
         Me._lblGreeninGreenWeight.Location = New System.Drawing.Point(107, 23)
         Me._lblGreeninGreenWeight.Name = "_lblGreeninGreenWeight"
         Me._lblGreeninGreenWeight.Size = New System.Drawing.Size(36, 13)
         Me._lblGreeninGreenWeight.TabIndex = 2
         Me._lblGreeninGreenWeight.Text = "Green"
         '
         '_lblRedinGreenWeight
         '
         Me._lblRedinGreenWeight.AutoSize = True
         Me._lblRedinGreenWeight.Location = New System.Drawing.Point(11, 23)
         Me._lblRedinGreenWeight.Name = "_lblRedinGreenWeight"
         Me._lblRedinGreenWeight.Size = New System.Drawing.Size(27, 13)
         Me._lblRedinGreenWeight.TabIndex = 0
         Me._lblRedinGreenWeight.Text = "Red"
         '
         '_numBlueinGreenWeight
         '
         Me._numBlueinGreenWeight.BackColor = System.Drawing.SystemColors.Window
         Me._numBlueinGreenWeight.Location = New System.Drawing.Point(240, 20)
         Me._numBlueinGreenWeight.Margin = New System.Windows.Forms.Padding(2)
         Me._numBlueinGreenWeight.Name = "_numBlueinGreenWeight"
         Me._numBlueinGreenWeight.Size = New System.Drawing.Size(41, 20)
         Me._numBlueinGreenWeight.TabIndex = 5
         '
         '_numGreeninGreenWeight
         '
         Me._numGreeninGreenWeight.BackColor = System.Drawing.SystemColors.Window
         Me._numGreeninGreenWeight.Location = New System.Drawing.Point(148, 20)
         Me._numGreeninGreenWeight.Margin = New System.Windows.Forms.Padding(2)
         Me._numGreeninGreenWeight.Name = "_numGreeninGreenWeight"
         Me._numGreeninGreenWeight.Size = New System.Drawing.Size(41, 20)
         Me._numGreeninGreenWeight.TabIndex = 3
         '
         '_numRedinGreenWeight
         '
         Me._numRedinGreenWeight.BackColor = System.Drawing.SystemColors.Window
         Me._numRedinGreenWeight.Location = New System.Drawing.Point(47, 20)
         Me._numRedinGreenWeight.Margin = New System.Windows.Forms.Padding(2)
         Me._numRedinGreenWeight.Name = "_numRedinGreenWeight"
         Me._numRedinGreenWeight.Size = New System.Drawing.Size(41, 20)
         Me._numRedinGreenWeight.TabIndex = 1
         '
         '_gbBlueWeights
         '
         Me._gbBlueWeights.Controls.Add(Me._lblBlueinBlueWeight)
         Me._gbBlueWeights.Controls.Add(Me._lblGreeninBlueWeight)
         Me._gbBlueWeights.Controls.Add(Me._lblRedinBlueWeight)
         Me._gbBlueWeights.Controls.Add(Me._numBlueinBlueWeight)
         Me._gbBlueWeights.Controls.Add(Me._numGreeninBlueWeight)
         Me._gbBlueWeights.Controls.Add(Me._numRedinBlueWeight)
         Me._gbBlueWeights.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._gbBlueWeights.Location = New System.Drawing.Point(6, 363)
         Me._gbBlueWeights.Margin = New System.Windows.Forms.Padding(2)
         Me._gbBlueWeights.Name = "_gbBlueWeights"
         Me._gbBlueWeights.Padding = New System.Windows.Forms.Padding(2)
         Me._gbBlueWeights.Size = New System.Drawing.Size(292, 49)
         Me._gbBlueWeights.TabIndex = 8
         Me._gbBlueWeights.TabStop = False
         Me._gbBlueWeights.Text = "Blue Weights"
         '
         '_lblBlueinBlueWeight
         '
         Me._lblBlueinBlueWeight.AutoSize = True
         Me._lblBlueinBlueWeight.Location = New System.Drawing.Point(206, 23)
         Me._lblBlueinBlueWeight.Name = "_lblBlueinBlueWeight"
         Me._lblBlueinBlueWeight.Size = New System.Drawing.Size(28, 13)
         Me._lblBlueinBlueWeight.TabIndex = 4
         Me._lblBlueinBlueWeight.Text = "Blue"
         '
         '_lblGreeninBlueWeight
         '
         Me._lblGreeninBlueWeight.AutoSize = True
         Me._lblGreeninBlueWeight.Location = New System.Drawing.Point(107, 23)
         Me._lblGreeninBlueWeight.Name = "_lblGreeninBlueWeight"
         Me._lblGreeninBlueWeight.Size = New System.Drawing.Size(36, 13)
         Me._lblGreeninBlueWeight.TabIndex = 2
         Me._lblGreeninBlueWeight.Text = "Green"
         '
         '_lblRedinBlueWeight
         '
         Me._lblRedinBlueWeight.AutoSize = True
         Me._lblRedinBlueWeight.Location = New System.Drawing.Point(11, 23)
         Me._lblRedinBlueWeight.Name = "_lblRedinBlueWeight"
         Me._lblRedinBlueWeight.Size = New System.Drawing.Size(27, 13)
         Me._lblRedinBlueWeight.TabIndex = 0
         Me._lblRedinBlueWeight.Text = "Red"
         '
         '_numBlueinBlueWeight
         '
         Me._numBlueinBlueWeight.BackColor = System.Drawing.SystemColors.Window
         Me._numBlueinBlueWeight.Location = New System.Drawing.Point(240, 20)
         Me._numBlueinBlueWeight.Margin = New System.Windows.Forms.Padding(2)
         Me._numBlueinBlueWeight.Name = "_numBlueinBlueWeight"
         Me._numBlueinBlueWeight.Size = New System.Drawing.Size(41, 20)
         Me._numBlueinBlueWeight.TabIndex = 5
         '
         '_numGreeninBlueWeight
         '
         Me._numGreeninBlueWeight.BackColor = System.Drawing.SystemColors.Window
         Me._numGreeninBlueWeight.Location = New System.Drawing.Point(148, 20)
         Me._numGreeninBlueWeight.Margin = New System.Windows.Forms.Padding(2)
         Me._numGreeninBlueWeight.Name = "_numGreeninBlueWeight"
         Me._numGreeninBlueWeight.Size = New System.Drawing.Size(41, 20)
         Me._numGreeninBlueWeight.TabIndex = 3
         '
         '_numRedinBlueWeight
         '
         Me._numRedinBlueWeight.BackColor = System.Drawing.SystemColors.Window
         Me._numRedinBlueWeight.Location = New System.Drawing.Point(47, 20)
         Me._numRedinBlueWeight.Margin = New System.Windows.Forms.Padding(2)
         Me._numRedinBlueWeight.Name = "_numRedinBlueWeight"
         Me._numRedinBlueWeight.Size = New System.Drawing.Size(41, 20)
         Me._numRedinBlueWeight.TabIndex = 1
         '
         'BalanceColorsDialog
         '
         Me.ClientSize = New System.Drawing.Size(384, 446)
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
         Me.Controls.Add(Me._gbBlueWeights)
         Me.Controls.Add(Me._gbGreenWeights)
         Me.Controls.Add(Me._gbRedWeights)
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "BalanceColorsDialog"
         Me.ShowIcon = False
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Balance Colors"
         Me._gbRedWeights.ResumeLayout(False)
         Me._gbRedWeights.PerformLayout()
         CType(Me._numBlueinRedWeight, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me._numGreeninRedWeight, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me._numRedinRedWeight, System.ComponentModel.ISupportInitialize).EndInit()
         Me._tsZoomLevel.ResumeLayout(False)
         Me._tsZoomLevel.PerformLayout()
         Me._gbGreenWeights.ResumeLayout(False)
         Me._gbGreenWeights.PerformLayout()
         CType(Me._numBlueinGreenWeight, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me._numGreeninGreenWeight, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me._numRedinGreenWeight, System.ComponentModel.ISupportInitialize).EndInit()
         Me._gbBlueWeights.ResumeLayout(False)
         Me._gbBlueWeights.PerformLayout()
         CType(Me._numBlueinBlueWeight, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me._numGreeninBlueWeight, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me._numRedinBlueWeight, System.ComponentModel.ISupportInitialize).EndInit()
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub
#End Region

      Private _gbRedWeights As System.Windows.Forms.GroupBox
      Private WithEvents _numRedinRedWeight As System.Windows.Forms.NumericUpDown
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
      Private _lblRedinRedWeight As System.Windows.Forms.Label
      Private _lblGreeninRedWeight As System.Windows.Forms.Label
      Private WithEvents _numGreeninRedWeight As System.Windows.Forms.NumericUpDown
      Private _lblBlueinRedWeight As System.Windows.Forms.Label
      Private WithEvents _numBlueinRedWeight As System.Windows.Forms.NumericUpDown
      Private _gbGreenWeights As System.Windows.Forms.GroupBox
      Private _lblBlueinGreenWeight As System.Windows.Forms.Label
      Private _lblGreeninGreenWeight As System.Windows.Forms.Label
      Private _lblRedinGreenWeight As System.Windows.Forms.Label
      Private WithEvents _numBlueinGreenWeight As System.Windows.Forms.NumericUpDown
      Private WithEvents _numGreeninGreenWeight As System.Windows.Forms.NumericUpDown
      Private WithEvents _numRedinGreenWeight As System.Windows.Forms.NumericUpDown
      Private _gbBlueWeights As System.Windows.Forms.GroupBox
      Private _lblBlueinBlueWeight As System.Windows.Forms.Label
      Private _lblGreeninBlueWeight As System.Windows.Forms.Label
      Private _lblRedinBlueWeight As System.Windows.Forms.Label
      Private WithEvents _numBlueinBlueWeight As System.Windows.Forms.NumericUpDown
      Private WithEvents _numGreeninBlueWeight As System.Windows.Forms.NumericUpDown
      Private WithEvents _numRedinBlueWeight As System.Windows.Forms.NumericUpDown
   End Class
End Namespace
