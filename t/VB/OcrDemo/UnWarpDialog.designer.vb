
Partial Class UnWarpDialog
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UnWarpDialog))
      Me._btnApply = New System.Windows.Forms.Button()
      Me._btnOK = New System.Windows.Forms.Button()
      Me._btnReset = New System.Windows.Forms.Button()
      Me._btnCancel = New System.Windows.Forms.Button()
      Me._lblCursorPosition = New System.Windows.Forms.Label()
      Me.label2 = New System.Windows.Forms.Label()
      Me.label3 = New System.Windows.Forms.Label()
      Me.label4 = New System.Windows.Forms.Label()
      Me.label5 = New System.Windows.Forms.Label()
      Me._pnlCursorPosition = New System.Windows.Forms.Panel()
      Me._lblCursorY = New System.Windows.Forms.Label()
      Me._lblCursorX = New System.Windows.Forms.Label()
      Me._txtCursorY = New System.Windows.Forms.TextBox()
      Me._txtCursorX = New System.Windows.Forms.TextBox()
      Me._gbPolygonPoints = New System.Windows.Forms.GroupBox()
      Me.label12 = New System.Windows.Forms.Label()
      Me.label11 = New System.Windows.Forms.Label()
      Me.label10 = New System.Windows.Forms.Label()
      Me.label9 = New System.Windows.Forms.Label()
      Me.label8 = New System.Windows.Forms.Label()
      Me.label7 = New System.Windows.Forms.Label()
      Me.label6 = New System.Windows.Forms.Label()
      Me.label1 = New System.Windows.Forms.Label()
      Me._numFourthPtY = New System.Windows.Forms.TextBox()
      Me._numFourthPtX = New System.Windows.Forms.TextBox()
      Me._numThirdPtY = New System.Windows.Forms.TextBox()
      Me._numThirdPtX = New System.Windows.Forms.TextBox()
      Me._numSecondPtY = New System.Windows.Forms.TextBox()
      Me._numSecondPtX = New System.Windows.Forms.TextBox()
      Me._numFirstPtY = New System.Windows.Forms.TextBox()
      Me._numFirstPtX = New System.Windows.Forms.TextBox()
      Me._UnWarpPanel = New System.Windows.Forms.Panel()
      Me._UnWarpPictureBox = New System.Windows.Forms.PictureBox()
      Me._pnlCursorPosition.SuspendLayout()
      Me._gbPolygonPoints.SuspendLayout()
      Me._UnWarpPanel.SuspendLayout()
      CType(Me._UnWarpPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      '_btnApply
      '
      resources.ApplyResources(Me._btnApply, "_btnApply")
      Me._btnApply.Name = "_btnApply"
      Me._btnApply.UseVisualStyleBackColor = True
      '
      '_btnOK
      '
      Me._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
      resources.ApplyResources(Me._btnOK, "_btnOK")
      Me._btnOK.Name = "_btnOK"
      Me._btnOK.UseVisualStyleBackColor = True
      '
      '_btnReset
      '
      resources.ApplyResources(Me._btnReset, "_btnReset")
      Me._btnReset.Name = "_btnReset"
      Me._btnReset.UseVisualStyleBackColor = True
      '
      '_btnCancel
      '
      resources.ApplyResources(Me._btnCancel, "_btnCancel")
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      '
      '_lblCursorPosition
      '
      resources.ApplyResources(Me._lblCursorPosition, "_lblCursorPosition")
      Me._lblCursorPosition.Name = "_lblCursorPosition"
      '
      'label2
      '
      resources.ApplyResources(Me.label2, "label2")
      Me.label2.Name = "label2"
      '
      'label3
      '
      resources.ApplyResources(Me.label3, "label3")
      Me.label3.Name = "label3"
      '
      'label4
      '
      resources.ApplyResources(Me.label4, "label4")
      Me.label4.Name = "label4"
      '
      'label5
      '
      resources.ApplyResources(Me.label5, "label5")
      Me.label5.Name = "label5"
      '
      '_pnlCursorPosition
      '
      Me._pnlCursorPosition.Controls.Add(Me._lblCursorY)
      Me._pnlCursorPosition.Controls.Add(Me._lblCursorX)
      Me._pnlCursorPosition.Controls.Add(Me._txtCursorY)
      Me._pnlCursorPosition.Controls.Add(Me._txtCursorX)
      Me._pnlCursorPosition.Controls.Add(Me._lblCursorPosition)
      resources.ApplyResources(Me._pnlCursorPosition, "_pnlCursorPosition")
      Me._pnlCursorPosition.Name = "_pnlCursorPosition"
      '
      '_lblCursorY
      '
      resources.ApplyResources(Me._lblCursorY, "_lblCursorY")
      Me._lblCursorY.Name = "_lblCursorY"
      '
      '_lblCursorX
      '
      resources.ApplyResources(Me._lblCursorX, "_lblCursorX")
      Me._lblCursorX.Name = "_lblCursorX"
      '
      '_txtCursorY
      '
      resources.ApplyResources(Me._txtCursorY, "_txtCursorY")
      Me._txtCursorY.Name = "_txtCursorY"
      Me._txtCursorY.ReadOnly = True
      '
      '_txtCursorX
      '
      resources.ApplyResources(Me._txtCursorX, "_txtCursorX")
      Me._txtCursorX.Name = "_txtCursorX"
      Me._txtCursorX.ReadOnly = True
      '
      '_gbPolygonPoints
      '
      Me._gbPolygonPoints.Controls.Add(Me.label12)
      Me._gbPolygonPoints.Controls.Add(Me.label11)
      Me._gbPolygonPoints.Controls.Add(Me.label10)
      Me._gbPolygonPoints.Controls.Add(Me.label9)
      Me._gbPolygonPoints.Controls.Add(Me.label8)
      Me._gbPolygonPoints.Controls.Add(Me.label7)
      Me._gbPolygonPoints.Controls.Add(Me.label6)
      Me._gbPolygonPoints.Controls.Add(Me.label1)
      Me._gbPolygonPoints.Controls.Add(Me._numFourthPtY)
      Me._gbPolygonPoints.Controls.Add(Me._numFourthPtX)
      Me._gbPolygonPoints.Controls.Add(Me._numThirdPtY)
      Me._gbPolygonPoints.Controls.Add(Me._numThirdPtX)
      Me._gbPolygonPoints.Controls.Add(Me._numSecondPtY)
      Me._gbPolygonPoints.Controls.Add(Me._numSecondPtX)
      Me._gbPolygonPoints.Controls.Add(Me._numFirstPtY)
      Me._gbPolygonPoints.Controls.Add(Me._numFirstPtX)
      Me._gbPolygonPoints.Controls.Add(Me.label2)
      Me._gbPolygonPoints.Controls.Add(Me.label3)
      Me._gbPolygonPoints.Controls.Add(Me.label5)
      Me._gbPolygonPoints.Controls.Add(Me.label4)
      resources.ApplyResources(Me._gbPolygonPoints, "_gbPolygonPoints")
      Me._gbPolygonPoints.Name = "_gbPolygonPoints"
      Me._gbPolygonPoints.TabStop = False
      '
      'label12
      '
      resources.ApplyResources(Me.label12, "label12")
      Me.label12.Name = "label12"
      '
      'label11
      '
      resources.ApplyResources(Me.label11, "label11")
      Me.label11.Name = "label11"
      '
      'label10
      '
      resources.ApplyResources(Me.label10, "label10")
      Me.label10.Name = "label10"
      '
      'label9
      '
      resources.ApplyResources(Me.label9, "label9")
      Me.label9.Name = "label9"
      '
      'label8
      '
      resources.ApplyResources(Me.label8, "label8")
      Me.label8.Name = "label8"
      '
      'label7
      '
      resources.ApplyResources(Me.label7, "label7")
      Me.label7.Name = "label7"
      '
      'label6
      '
      resources.ApplyResources(Me.label6, "label6")
      Me.label6.Name = "label6"
      '
      'label1
      '
      resources.ApplyResources(Me.label1, "label1")
      Me.label1.Name = "label1"
      '
      '_numFourthPtY
      '
      resources.ApplyResources(Me._numFourthPtY, "_numFourthPtY")
      Me._numFourthPtY.Name = "_numFourthPtY"
      Me._numFourthPtY.ReadOnly = True
      '
      '_numFourthPtX
      '
      resources.ApplyResources(Me._numFourthPtX, "_numFourthPtX")
      Me._numFourthPtX.Name = "_numFourthPtX"
      Me._numFourthPtX.ReadOnly = True
      '
      '_numThirdPtY
      '
      resources.ApplyResources(Me._numThirdPtY, "_numThirdPtY")
      Me._numThirdPtY.Name = "_numThirdPtY"
      Me._numThirdPtY.ReadOnly = True
      '
      '_numThirdPtX
      '
      resources.ApplyResources(Me._numThirdPtX, "_numThirdPtX")
      Me._numThirdPtX.Name = "_numThirdPtX"
      Me._numThirdPtX.ReadOnly = True
      '
      '_numSecondPtY
      '
      resources.ApplyResources(Me._numSecondPtY, "_numSecondPtY")
      Me._numSecondPtY.Name = "_numSecondPtY"
      Me._numSecondPtY.ReadOnly = True
      '
      '_numSecondPtX
      '
      resources.ApplyResources(Me._numSecondPtX, "_numSecondPtX")
      Me._numSecondPtX.Name = "_numSecondPtX"
      Me._numSecondPtX.ReadOnly = True
      '
      '_numFirstPtY
      '
      resources.ApplyResources(Me._numFirstPtY, "_numFirstPtY")
      Me._numFirstPtY.Name = "_numFirstPtY"
      Me._numFirstPtY.ReadOnly = True
      '
      '_numFirstPtX
      '
      resources.ApplyResources(Me._numFirstPtX, "_numFirstPtX")
      Me._numFirstPtX.Name = "_numFirstPtX"
      Me._numFirstPtX.ReadOnly = True
      '
      '_UnWarpPanel
      '
      Me._UnWarpPanel.Controls.Add(Me._UnWarpPictureBox)
      resources.ApplyResources(Me._UnWarpPanel, "_UnWarpPanel")
      Me._UnWarpPanel.Name = "_UnWarpPanel"
      '
      '_UnWarpPictureBox
      '
      resources.ApplyResources(Me._UnWarpPictureBox, "_UnWarpPictureBox")
      Me._UnWarpPictureBox.Name = "_UnWarpPictureBox"
      Me._UnWarpPictureBox.TabStop = False
      '
      'UnWarpDialog
      '
      resources.ApplyResources(Me, "$this")
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me._UnWarpPanel)
      Me.Controls.Add(Me._gbPolygonPoints)
      Me.Controls.Add(Me._pnlCursorPosition)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnReset)
      Me.Controls.Add(Me._btnOK)
      Me.Controls.Add(Me._btnApply)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "UnWarpDialog"
      Me.TopMost = True
      Me._pnlCursorPosition.ResumeLayout(False)
      Me._pnlCursorPosition.PerformLayout()
      Me._gbPolygonPoints.ResumeLayout(False)
      Me._gbPolygonPoints.PerformLayout()
      Me._UnWarpPanel.ResumeLayout(False)
      CType(Me._UnWarpPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private WithEvents _btnApply As System.Windows.Forms.Button
   Private WithEvents _btnOK As System.Windows.Forms.Button
   Private WithEvents _btnReset As System.Windows.Forms.Button
   Private WithEvents _btnCancel As System.Windows.Forms.Button
   Private _lblCursorPosition As System.Windows.Forms.Label
   Private label2 As System.Windows.Forms.Label
   Private label3 As System.Windows.Forms.Label
   Private label4 As System.Windows.Forms.Label
   Private label5 As System.Windows.Forms.Label
   Private _pnlCursorPosition As System.Windows.Forms.Panel
   Private _lblCursorY As System.Windows.Forms.Label
   Private _lblCursorX As System.Windows.Forms.Label
   Private _txtCursorY As System.Windows.Forms.TextBox
   Private _txtCursorX As System.Windows.Forms.TextBox
   Private _gbPolygonPoints As System.Windows.Forms.GroupBox
   Private label12 As System.Windows.Forms.Label
   Private label11 As System.Windows.Forms.Label
   Private label10 As System.Windows.Forms.Label
   Private label9 As System.Windows.Forms.Label
   Private label8 As System.Windows.Forms.Label
   Private label7 As System.Windows.Forms.Label
   Private label6 As System.Windows.Forms.Label
   Private label1 As System.Windows.Forms.Label
   Private _numFourthPtY As System.Windows.Forms.TextBox
   Private _numFourthPtX As System.Windows.Forms.TextBox
   Private _numThirdPtY As System.Windows.Forms.TextBox
   Private _numThirdPtX As System.Windows.Forms.TextBox
   Private _numSecondPtY As System.Windows.Forms.TextBox
   Private _numSecondPtX As System.Windows.Forms.TextBox
   Private _numFirstPtY As System.Windows.Forms.TextBox
   Private _numFirstPtX As System.Windows.Forms.TextBox
   Friend WithEvents _UnWarpPanel As System.Windows.Forms.Panel
   Friend WithEvents _UnWarpPictureBox As System.Windows.Forms.PictureBox
End Class