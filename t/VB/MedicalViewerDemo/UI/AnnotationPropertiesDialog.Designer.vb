Namespace MedicalViewerDemo
   Partial Class AnnotationPropertiesDialog
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
         Me._tabAnnProperties = New System.Windows.Forms.TabControl()
         Me._penTab = New System.Windows.Forms.TabPage()
         Me._penGroup = New System.Windows.Forms.GroupBox()
         Me._lblPenColor = New System.Windows.Forms.Label()
         Me._btnColor = New System.Windows.Forms.Button()
         Me._penWidth = New System.Windows.Forms.NumericUpDown()
         Me.label1 = New System.Windows.Forms.Label()
         Me._chkUsePen = New System.Windows.Forms.CheckBox()
         Me._brushTab = New System.Windows.Forms.TabPage()
         Me._brushGroup = New System.Windows.Forms.GroupBox()
         Me._lblBrushColor = New System.Windows.Forms.Label()
         Me.button1 = New System.Windows.Forms.Button()
         Me._chkUseBrush = New System.Windows.Forms.CheckBox()
         Me._fontTab = New System.Windows.Forms.TabPage()
         Me.groupBox3 = New System.Windows.Forms.GroupBox()
         Me._lblSample = New System.Windows.Forms.Label()
         Me._lblFont = New System.Windows.Forms.Label()
         Me.label3 = New System.Windows.Forms.Label()
         Me._btnChange = New System.Windows.Forms.Button()
         Me._btnCancel = New System.Windows.Forms.Button()
         Me._btnOK = New System.Windows.Forms.Button()
         Me._btnApply = New System.Windows.Forms.Button()
         Me._tabAnnProperties.SuspendLayout()
         Me._penTab.SuspendLayout()
         Me._penGroup.SuspendLayout()
         CType(Me._penWidth, System.ComponentModel.ISupportInitialize).BeginInit()
         Me._brushTab.SuspendLayout()
         Me._brushGroup.SuspendLayout()
         Me._fontTab.SuspendLayout()
         Me.groupBox3.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _tabAnnProperties
         ' 
         Me._tabAnnProperties.Controls.Add(Me._penTab)
         Me._tabAnnProperties.Controls.Add(Me._brushTab)
         Me._tabAnnProperties.Controls.Add(Me._fontTab)
         Me._tabAnnProperties.Location = New System.Drawing.Point(0, 0)
         Me._tabAnnProperties.Name = "_tabAnnProperties"
         Me._tabAnnProperties.SelectedIndex = 0
         Me._tabAnnProperties.Size = New System.Drawing.Size(203, 198)
         Me._tabAnnProperties.TabIndex = 0
         ' 
         ' _penTab
         ' 
         Me._penTab.Controls.Add(Me._penGroup)
         Me._penTab.Controls.Add(Me._chkUsePen)
         Me._penTab.Location = New System.Drawing.Point(4, 22)
         Me._penTab.Name = "_penTab"
         Me._penTab.Padding = New System.Windows.Forms.Padding(3)
         Me._penTab.Size = New System.Drawing.Size(195, 172)
         Me._penTab.TabIndex = 0
         Me._penTab.Text = "Pen"
         Me._penTab.UseVisualStyleBackColor = True
         ' 
         ' _penGroup
         ' 
         Me._penGroup.Controls.Add(Me._lblPenColor)
         Me._penGroup.Controls.Add(Me._btnColor)
         Me._penGroup.Controls.Add(Me._penWidth)
         Me._penGroup.Controls.Add(Me.label1)
         Me._penGroup.Location = New System.Drawing.Point(8, 30)
         Me._penGroup.Name = "_penGroup"
         Me._penGroup.Size = New System.Drawing.Size(178, 134)
         Me._penGroup.TabIndex = 1
         Me._penGroup.TabStop = False
         ' 
         ' _lblPenColor
         ' 
         Me._lblPenColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
         Me._lblPenColor.Location = New System.Drawing.Point(82, 52)
         Me._lblPenColor.Name = "_lblPenColor"
         Me._lblPenColor.Size = New System.Drawing.Size(90, 31)
         Me._lblPenColor.TabIndex = 5
         ' 
         ' _btnColor
         ' 
         Me._btnColor.Location = New System.Drawing.Point(6, 52)
         Me._btnColor.Name = "_btnColor"
         Me._btnColor.Size = New System.Drawing.Size(58, 31)
         Me._btnColor.TabIndex = 4
         Me._btnColor.Text = "C&olor"
         Me._btnColor.UseVisualStyleBackColor = True
         ' 
         ' _penWidth
         ' 
         Me._penWidth.Location = New System.Drawing.Point(82, 18)
         Me._penWidth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
         Me._penWidth.Name = "_penWidth"
         Me._penWidth.Size = New System.Drawing.Size(90, 20)
         Me._penWidth.TabIndex = 1
         Me._penWidth.Value = New Decimal(New Integer() {1, 0, 0, 0})
         ' 
         ' label1
         ' 
         Me.label1.AutoSize = True
         Me.label1.Location = New System.Drawing.Point(7, 20)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(59, 13)
         Me.label1.TabIndex = 0
         Me.label1.Text = "Thickness:"
         ' 
         ' _chkUsePen
         ' 
         Me._chkUsePen.AutoSize = True
         Me._chkUsePen.Checked = True
         Me._chkUsePen.CheckState = System.Windows.Forms.CheckState.Checked
         Me._chkUsePen.Location = New System.Drawing.Point(8, 6)
         Me._chkUsePen.Name = "_chkUsePen"
         Me._chkUsePen.Size = New System.Drawing.Size(67, 17)
         Me._chkUsePen.TabIndex = 0
         Me._chkUsePen.Text = "Use Pen"
         Me._chkUsePen.UseVisualStyleBackColor = True
         ' 
         ' _brushTab
         ' 
         Me._brushTab.Controls.Add(Me._brushGroup)
         Me._brushTab.Controls.Add(Me._chkUseBrush)
         Me._brushTab.Location = New System.Drawing.Point(4, 22)
         Me._brushTab.Name = "_brushTab"
         Me._brushTab.Padding = New System.Windows.Forms.Padding(3)
         Me._brushTab.Size = New System.Drawing.Size(195, 172)
         Me._brushTab.TabIndex = 1
         Me._brushTab.Text = "Brush"
         Me._brushTab.UseVisualStyleBackColor = True
         ' 
         ' _brushGroup
         ' 
         Me._brushGroup.Controls.Add(Me._lblBrushColor)
         Me._brushGroup.Controls.Add(Me.button1)
         Me._brushGroup.Location = New System.Drawing.Point(8, 30)
         Me._brushGroup.Name = "_brushGroup"
         Me._brushGroup.Size = New System.Drawing.Size(178, 134)
         Me._brushGroup.TabIndex = 2
         Me._brushGroup.TabStop = False
         ' 
         ' _lblBrushColor
         ' 
         Me._lblBrushColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
         Me._lblBrushColor.Location = New System.Drawing.Point(82, 52)
         Me._lblBrushColor.Name = "_lblBrushColor"
         Me._lblBrushColor.Size = New System.Drawing.Size(90, 31)
         Me._lblBrushColor.TabIndex = 5
         ' 
         ' button1
         ' 
         Me.button1.Location = New System.Drawing.Point(6, 52)
         Me.button1.Name = "button1"
         Me.button1.Size = New System.Drawing.Size(58, 31)
         Me.button1.TabIndex = 4
         Me.button1.Text = "C&olor"
         Me.button1.UseVisualStyleBackColor = True
         ' 
         ' _chkUseBrush
         ' 
         Me._chkUseBrush.AutoSize = True
         Me._chkUseBrush.Checked = True
         Me._chkUseBrush.CheckState = System.Windows.Forms.CheckState.Checked
         Me._chkUseBrush.Location = New System.Drawing.Point(8, 6)
         Me._chkUseBrush.Name = "_chkUseBrush"
         Me._chkUseBrush.Size = New System.Drawing.Size(75, 17)
         Me._chkUseBrush.TabIndex = 0
         Me._chkUseBrush.Text = "Use Brush"
         Me._chkUseBrush.UseVisualStyleBackColor = True
         ' 
         ' _fontTab
         ' 
         Me._fontTab.Controls.Add(Me.groupBox3)
         Me._fontTab.Controls.Add(Me._lblFont)
         Me._fontTab.Controls.Add(Me.label3)
         Me._fontTab.Controls.Add(Me._btnChange)
         Me._fontTab.Location = New System.Drawing.Point(4, 22)
         Me._fontTab.Name = "_fontTab"
         Me._fontTab.Size = New System.Drawing.Size(195, 172)
         Me._fontTab.TabIndex = 2
         Me._fontTab.Text = "Font"
         Me._fontTab.UseVisualStyleBackColor = True
         ' 
         ' groupBox3
         ' 
         Me.groupBox3.Controls.Add(Me._lblSample)
         Me.groupBox3.Location = New System.Drawing.Point(9, 50)
         Me.groupBox3.Name = "groupBox3"
         Me.groupBox3.Size = New System.Drawing.Size(176, 67)
         Me.groupBox3.TabIndex = 3
         Me.groupBox3.TabStop = False
         Me.groupBox3.Text = "Sample"
         ' 
         ' _lblSample
         ' 
         Me._lblSample.Location = New System.Drawing.Point(6, 16)
         Me._lblSample.Name = "_lblSample"
         Me._lblSample.Size = New System.Drawing.Size(164, 48)
         Me._lblSample.TabIndex = 0
         Me._lblSample.Text = "AaBbZz"
         Me._lblSample.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
         ' 
         ' _lblFont
         ' 
         Me._lblFont.AutoSize = True
         Me._lblFont.Location = New System.Drawing.Point(57, 17)
         Me._lblFont.Name = "_lblFont"
         Me._lblFont.Size = New System.Drawing.Size(0, 13)
         Me._lblFont.TabIndex = 2
         ' 
         ' label3
         ' 
         Me.label3.AutoSize = True
         Me.label3.Location = New System.Drawing.Point(9, 17)
         Me.label3.Name = "label3"
         Me.label3.Size = New System.Drawing.Size(31, 13)
         Me.label3.TabIndex = 1
         Me.label3.Text = "Font:"
         ' 
         ' _btnChange
         ' 
         Me._btnChange.Location = New System.Drawing.Point(60, 141)
         Me._btnChange.Name = "_btnChange"
         Me._btnChange.Size = New System.Drawing.Size(75, 23)
         Me._btnChange.TabIndex = 0
         Me._btnChange.Text = "Change..."
         Me._btnChange.UseVisualStyleBackColor = True
         ' 
         ' _btnCancel
         ' 
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnCancel.Location = New System.Drawing.Point(73, 204)
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.Size = New System.Drawing.Size(58, 29)
         Me._btnCancel.TabIndex = 17
         Me._btnCancel.Text = "Canc&el"
         Me._btnCancel.UseVisualStyleBackColor = True
         ' 
         ' _btnOK
         ' 
         Me._btnOK.Location = New System.Drawing.Point(7, 204)
         Me._btnOK.Name = "_btnOK"
         Me._btnOK.Size = New System.Drawing.Size(58, 29)
         Me._btnOK.TabIndex = 16
         Me._btnOK.Text = "&OK"
         Me._btnOK.UseVisualStyleBackColor = True
         ' 
         ' _btnApply
         ' 
         Me._btnApply.Location = New System.Drawing.Point(138, 204)
         Me._btnApply.Name = "_btnApply"
         Me._btnApply.Size = New System.Drawing.Size(58, 29)
         Me._btnApply.TabIndex = 18
         Me._btnApply.Text = "App&ly"
         Me._btnApply.UseVisualStyleBackColor = True
         ' 
         ' AnnotationPropertiesDialog
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(203, 237)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._btnOK)
         Me.Controls.Add(Me._btnApply)
         Me.Controls.Add(Me._tabAnnProperties)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "AnnotationPropertiesDialog"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Annotation Properties"
         Me._tabAnnProperties.ResumeLayout(False)
         Me._penTab.ResumeLayout(False)
         Me._penTab.PerformLayout()
         Me._penGroup.ResumeLayout(False)
         Me._penGroup.PerformLayout()
         CType(Me._penWidth, System.ComponentModel.ISupportInitialize).EndInit()
         Me._brushTab.ResumeLayout(False)
         Me._brushTab.PerformLayout()
         Me._brushGroup.ResumeLayout(False)
         Me._fontTab.ResumeLayout(False)
         Me._fontTab.PerformLayout()
         Me.groupBox3.ResumeLayout(False)
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private _tabAnnProperties As System.Windows.Forms.TabControl
      Private _penTab As System.Windows.Forms.TabPage
      Private _brushTab As System.Windows.Forms.TabPage
      Private _fontTab As System.Windows.Forms.TabPage
      Private _penGroup As System.Windows.Forms.GroupBox
      Private _penWidth As System.Windows.Forms.NumericUpDown
      Private label1 As System.Windows.Forms.Label
      Private WithEvents _chkUsePen As System.Windows.Forms.CheckBox
      Private WithEvents _lblPenColor As System.Windows.Forms.Label
      Private WithEvents _btnColor As System.Windows.Forms.Button
      Private WithEvents _chkUseBrush As System.Windows.Forms.CheckBox
      Private _brushGroup As System.Windows.Forms.GroupBox
      Private _lblBrushColor As System.Windows.Forms.Label
      Private WithEvents button1 As System.Windows.Forms.Button
      Private WithEvents _btnChange As System.Windows.Forms.Button
      Private groupBox3 As System.Windows.Forms.GroupBox
      Private _lblSample As System.Windows.Forms.Label
      Private _lblFont As System.Windows.Forms.Label
      Private label3 As System.Windows.Forms.Label
      Private _btnCancel As System.Windows.Forms.Button
      Private WithEvents _btnOK As System.Windows.Forms.Button
      Private WithEvents _btnApply As System.Windows.Forms.Button

   End Class
End Namespace
