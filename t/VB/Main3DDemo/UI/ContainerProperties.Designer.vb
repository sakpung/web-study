Namespace Main3DDemo
   Partial Class ContainerProperties
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ContainerProperties))
         Me._btnReset = New System.Windows.Forms.Button()
         Me._btnCancel = New System.Windows.Forms.Button()
         Me._btnOK = New System.Windows.Forms.Button()
         Me._btnApply = New System.Windows.Forms.Button()
         Me._tabCamera = New System.Windows.Forms.TabPage()
         Me._txtCameraFar = New Main3DDemo.NumericTextBox()
         Me._txtCameraNear = New Main3DDemo.NumericTextBox()
         Me.label2 = New System.Windows.Forms.Label()
         Me.label5 = New System.Windows.Forms.Label()
         Me._comboBoxProjectionMethod = New System.Windows.Forms.ComboBox()
         Me.label1 = New System.Windows.Forms.Label()
         Me._tabMPR = New System.Windows.Forms.TabPage()
         Me._chkRemoveBackground = New System.Windows.Forms.CheckBox()
         Me._chkIntersectionLine = New System.Windows.Forms.CheckBox()
         Me._btnIntersectionLineColor = New System.Windows.Forms.Button()
         Me._chkFrameBoundary = New System.Windows.Forms.CheckBox()
         Me._btnFrameBoundaryColor = New System.Windows.Forms.Button()
         Me._lblIntersectionLineColor = New Main3DDemo.ColorBox()
         Me._lblFrameBoundaryColor = New Main3DDemo.ColorBox()
         Me._tabGeneral = New System.Windows.Forms.TabPage()
         Me._lblBackgroundColor = New Main3DDemo.ColorBox()
         Me._btnBackgroundColor = New System.Windows.Forms.Button()
         Me._chkBoundaryBox = New System.Windows.Forms.CheckBox()
         Me._lblBoundaryBoxColor = New Main3DDemo.ColorBox()
         Me._btnBoundaryBoxColor = New System.Windows.Forms.Button()
         Me._tabControl = New System.Windows.Forms.TabControl()
         Me._tabCamera.SuspendLayout()
         Me._tabMPR.SuspendLayout()
         Me._tabGeneral.SuspendLayout()
         Me._tabControl.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _btnReset
         ' 
         resources.ApplyResources(Me._btnReset, "_btnReset")
         Me._btnReset.Name = "_btnReset"
         Me._btnReset.UseVisualStyleBackColor = True
         ' 
         ' _btnCancel
         ' 
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         resources.ApplyResources(Me._btnCancel, "_btnCancel")
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.UseVisualStyleBackColor = True
         ' 
         ' _btnOK
         ' 
         Me._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
         resources.ApplyResources(Me._btnOK, "_btnOK")
         Me._btnOK.Name = "_btnOK"
         Me._btnOK.UseVisualStyleBackColor = True
         ' 
         ' _btnApply
         ' 
         resources.ApplyResources(Me._btnApply, "_btnApply")
         Me._btnApply.Name = "_btnApply"
         Me._btnApply.UseVisualStyleBackColor = True
         ' 
         ' _tabCamera
         ' 
         Me._tabCamera.Controls.Add(Me._txtCameraFar)
         Me._tabCamera.Controls.Add(Me._txtCameraNear)
         Me._tabCamera.Controls.Add(Me.label2)
         Me._tabCamera.Controls.Add(Me.label5)
         Me._tabCamera.Controls.Add(Me._comboBoxProjectionMethod)
         Me._tabCamera.Controls.Add(Me.label1)
         resources.ApplyResources(Me._tabCamera, "_tabCamera")
         Me._tabCamera.Name = "_tabCamera"
         Me._tabCamera.UseVisualStyleBackColor = True
         ' 
         ' _txtCameraFar
         ' 
         resources.ApplyResources(Me._txtCameraFar, "_txtCameraFar")
         Me._txtCameraFar.MaximumAllowed = 1000
         Me._txtCameraFar.MinimumAllowed = -1000
         Me._txtCameraFar.Name = "_txtCameraFar"
         Me._txtCameraFar.Value = 0
         ' 
         ' _txtCameraNear
         ' 
         resources.ApplyResources(Me._txtCameraNear, "_txtCameraNear")
         Me._txtCameraNear.MaximumAllowed = 1000
         Me._txtCameraNear.MinimumAllowed = -1000
         Me._txtCameraNear.Name = "_txtCameraNear"
         Me._txtCameraNear.Value = 0
         ' 
         ' label2
         ' 
         resources.ApplyResources(Me.label2, "label2")
         Me.label2.Name = "label2"
         ' 
         ' label5
         ' 
         resources.ApplyResources(Me.label5, "label5")
         Me.label5.Name = "label5"
         ' 
         ' _comboBoxProjectionMethod
         ' 
         Me._comboBoxProjectionMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._comboBoxProjectionMethod.FormattingEnabled = True
         Me._comboBoxProjectionMethod.Items.AddRange(New Object() {resources.GetString("_comboBoxProjectionMethod.Items"), resources.GetString("_comboBoxProjectionMethod.Items1")})
         resources.ApplyResources(Me._comboBoxProjectionMethod, "_comboBoxProjectionMethod")
         Me._comboBoxProjectionMethod.Name = "_comboBoxProjectionMethod"
         ' 
         ' label1
         ' 
         resources.ApplyResources(Me.label1, "label1")
         Me.label1.Name = "label1"
         ' 
         ' _tabMPR
         ' 
         Me._tabMPR.Controls.Add(Me._chkRemoveBackground)
         Me._tabMPR.Controls.Add(Me._chkIntersectionLine)
         Me._tabMPR.Controls.Add(Me._btnIntersectionLineColor)
         Me._tabMPR.Controls.Add(Me._chkFrameBoundary)
         Me._tabMPR.Controls.Add(Me._btnFrameBoundaryColor)
         Me._tabMPR.Controls.Add(Me._lblIntersectionLineColor)
         Me._tabMPR.Controls.Add(Me._lblFrameBoundaryColor)
         resources.ApplyResources(Me._tabMPR, "_tabMPR")
         Me._tabMPR.Name = "_tabMPR"
         Me._tabMPR.UseVisualStyleBackColor = True
         ' 
         ' _chkRemoveBackground
         ' 
         resources.ApplyResources(Me._chkRemoveBackground, "_chkRemoveBackground")
         Me._chkRemoveBackground.Name = "_chkRemoveBackground"
         Me._chkRemoveBackground.UseVisualStyleBackColor = True
         ' 
         ' _chkIntersectionLine
         ' 
         resources.ApplyResources(Me._chkIntersectionLine, "_chkIntersectionLine")
         Me._chkIntersectionLine.Name = "_chkIntersectionLine"
         Me._chkIntersectionLine.UseVisualStyleBackColor = True
         ' 
         ' _btnIntersectionLineColor
         ' 
         resources.ApplyResources(Me._btnIntersectionLineColor, "_btnIntersectionLineColor")
         Me._btnIntersectionLineColor.Name = "_btnIntersectionLineColor"
         Me._btnIntersectionLineColor.UseVisualStyleBackColor = True
         ' 
         ' _chkFrameBoundary
         ' 
         resources.ApplyResources(Me._chkFrameBoundary, "_chkFrameBoundary")
         Me._chkFrameBoundary.Name = "_chkFrameBoundary"
         Me._chkFrameBoundary.UseVisualStyleBackColor = True
         ' 
         ' _btnFrameBoundaryColor
         ' 
         resources.ApplyResources(Me._btnFrameBoundaryColor, "_btnFrameBoundaryColor")
         Me._btnFrameBoundaryColor.Name = "_btnFrameBoundaryColor"
         Me._btnFrameBoundaryColor.UseVisualStyleBackColor = True
         ' 
         ' _lblIntersectionLineColor
         ' 
         Me._lblIntersectionLineColor.BackColor = System.Drawing.Color.FromArgb((CInt((CByte(255)))), (CInt((CByte(255)))), (CInt((CByte(255)))))
         Me._lblIntersectionLineColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._lblIntersectionLineColor.BoxColor = System.Drawing.Color.FromArgb((CInt((CByte(0)))), (CInt((CByte(255)))), (CInt((CByte(255)))), (CInt((CByte(255)))))
         resources.ApplyResources(Me._lblIntersectionLineColor, "_lblIntersectionLineColor")
         Me._lblIntersectionLineColor.Name = "_lblIntersectionLineColor"
         ' 
         ' _lblFrameBoundaryColor
         ' 
         Me._lblFrameBoundaryColor.BackColor = System.Drawing.Color.FromArgb((CInt((CByte(255)))), (CInt((CByte(255)))), (CInt((CByte(255)))))
         Me._lblFrameBoundaryColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._lblFrameBoundaryColor.BoxColor = System.Drawing.Color.FromArgb((CInt((CByte(0)))), (CInt((CByte(255)))), (CInt((CByte(255)))), (CInt((CByte(255)))))
         resources.ApplyResources(Me._lblFrameBoundaryColor, "_lblFrameBoundaryColor")
         Me._lblFrameBoundaryColor.Name = "_lblFrameBoundaryColor"
         ' 
         ' _tabGeneral
         ' 
         Me._tabGeneral.Controls.Add(Me._lblBackgroundColor)
         Me._tabGeneral.Controls.Add(Me._btnBackgroundColor)
         Me._tabGeneral.Controls.Add(Me._chkBoundaryBox)
         Me._tabGeneral.Controls.Add(Me._lblBoundaryBoxColor)
         Me._tabGeneral.Controls.Add(Me._btnBoundaryBoxColor)
         resources.ApplyResources(Me._tabGeneral, "_tabGeneral")
         Me._tabGeneral.Name = "_tabGeneral"
         Me._tabGeneral.UseVisualStyleBackColor = True
         ' 
         ' _lblBackgroundColor
         ' 
         Me._lblBackgroundColor.BackColor = System.Drawing.Color.FromArgb((CInt((CByte(255)))), (CInt((CByte(255)))), (CInt((CByte(255)))))
         Me._lblBackgroundColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._lblBackgroundColor.BoxColor = System.Drawing.Color.FromArgb((CInt((CByte(0)))), (CInt((CByte(255)))), (CInt((CByte(255)))), (CInt((CByte(255)))))
         resources.ApplyResources(Me._lblBackgroundColor, "_lblBackgroundColor")
         Me._lblBackgroundColor.Name = "_lblBackgroundColor"
         ' 
         ' _btnBackgroundColor
         ' 
         resources.ApplyResources(Me._btnBackgroundColor, "_btnBackgroundColor")
         Me._btnBackgroundColor.Name = "_btnBackgroundColor"
         Me._btnBackgroundColor.UseVisualStyleBackColor = True
         ' 
         ' _chkBoundaryBox
         ' 
         resources.ApplyResources(Me._chkBoundaryBox, "_chkBoundaryBox")
         Me._chkBoundaryBox.Name = "_chkBoundaryBox"
         Me._chkBoundaryBox.UseVisualStyleBackColor = True
         ' 
         ' _lblBoundaryBoxColor
         ' 
         Me._lblBoundaryBoxColor.BackColor = System.Drawing.Color.FromArgb((CInt((CByte(255)))), (CInt((CByte(255)))), (CInt((CByte(255)))))
         Me._lblBoundaryBoxColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._lblBoundaryBoxColor.BoxColor = System.Drawing.Color.FromArgb((CInt((CByte(0)))), (CInt((CByte(255)))), (CInt((CByte(255)))), (CInt((CByte(255)))))
         resources.ApplyResources(Me._lblBoundaryBoxColor, "_lblBoundaryBoxColor")
         Me._lblBoundaryBoxColor.Name = "_lblBoundaryBoxColor"
         ' 
         ' _btnBoundaryBoxColor
         ' 
         resources.ApplyResources(Me._btnBoundaryBoxColor, "_btnBoundaryBoxColor")
         Me._btnBoundaryBoxColor.Name = "_btnBoundaryBoxColor"
         Me._btnBoundaryBoxColor.UseVisualStyleBackColor = True
         ' 
         ' _tabControl
         ' 
         Me._tabControl.Controls.Add(Me._tabGeneral)
         Me._tabControl.Controls.Add(Me._tabMPR)
         Me._tabControl.Controls.Add(Me._tabCamera)
         resources.ApplyResources(Me._tabControl, "_tabControl")
         Me._tabControl.Name = "_tabControl"
         Me._tabControl.SelectedIndex = 0
         ' 
         ' ContainerProperties
         ' 
         Me.AcceptButton = Me._btnOK
         resources.ApplyResources(Me, "$this")
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me._btnCancel
         Me.Controls.Add(Me._btnApply)
         Me.Controls.Add(Me._btnReset)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._btnOK)
         Me.Controls.Add(Me._tabControl)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "ContainerProperties"
         Me._tabCamera.ResumeLayout(False)
         Me._tabCamera.PerformLayout()
         Me._tabMPR.ResumeLayout(False)
         Me._tabMPR.PerformLayout()
         Me._tabGeneral.ResumeLayout(False)
         Me._tabGeneral.PerformLayout()
         Me._tabControl.ResumeLayout(False)
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private WithEvents _btnReset As System.Windows.Forms.Button
      Private _btnCancel As System.Windows.Forms.Button
      Private WithEvents _btnOK As System.Windows.Forms.Button
      Private WithEvents _btnApply As System.Windows.Forms.Button
      Private _tabCamera As System.Windows.Forms.TabPage
      Private _txtCameraFar As NumericTextBox
      Private _txtCameraNear As NumericTextBox
      Private label2 As System.Windows.Forms.Label
      Private label5 As System.Windows.Forms.Label
      Private _comboBoxProjectionMethod As System.Windows.Forms.ComboBox
      Private label1 As System.Windows.Forms.Label
      Private _tabMPR As System.Windows.Forms.TabPage
      Private _chkRemoveBackground As System.Windows.Forms.CheckBox
      Private WithEvents _chkIntersectionLine As System.Windows.Forms.CheckBox
      Private WithEvents _btnIntersectionLineColor As System.Windows.Forms.Button
      Private WithEvents _chkFrameBoundary As System.Windows.Forms.CheckBox
      Private WithEvents _btnFrameBoundaryColor As System.Windows.Forms.Button
      Private _lblIntersectionLineColor As ColorBox
      Private _lblFrameBoundaryColor As ColorBox
      Private _tabGeneral As System.Windows.Forms.TabPage
      Private _lblBackgroundColor As ColorBox
      Private WithEvents _btnBackgroundColor As System.Windows.Forms.Button
      Private WithEvents _chkBoundaryBox As System.Windows.Forms.CheckBox
      Private _lblBoundaryBoxColor As ColorBox
      Private WithEvents _btnBoundaryBoxColor As System.Windows.Forms.Button
      Private _tabControl As System.Windows.Forms.TabControl
   End Class
End Namespace
