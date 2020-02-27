
Partial Class MasterFormsWizard
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MasterFormsWizard))
      Me._tbMain = New System.Windows.Forms.TabControl()
      Me._tbAboutDemo = New System.Windows.Forms.TabPage()
      Me._lblLink = New System.Windows.Forms.LinkLabel()
      Me._btnNextAbout = New System.Windows.Forms.Button()
      Me._tbOptions = New System.Windows.Forms.TabPage()
      Me.groupBox1 = New System.Windows.Forms.GroupBox()
      Me._btnPrevOptions = New System.Windows.Forms.Button()
      Me._btnNext = New System.Windows.Forms.Button()
      Me._rdLoad = New System.Windows.Forms.RadioButton()
      Me._rdCreate = New System.Windows.Forms.RadioButton()
      Me._tbCreate = New System.Windows.Forms.TabPage()
      Me._txtMasterFormsName = New System.Windows.Forms.TextBox()
      Me.groupBox2 = New System.Windows.Forms.GroupBox()
      Me._btnMasterDirectory = New System.Windows.Forms.Button()
      Me._btnPrevCreate = New System.Windows.Forms.Button()
      Me._txtMasterFormsDirectory = New System.Windows.Forms.TextBox()
      Me.label1 = New System.Windows.Forms.Label()
      Me.label2 = New System.Windows.Forms.Label()
      Me._btnNextCreate = New System.Windows.Forms.Button()
      Me._tbAddPage = New System.Windows.Forms.TabPage()
      Me._btnAcquirePage = New System.Windows.Forms.Button()
      Me._txtPagePath = New System.Windows.Forms.TextBox()
      Me.groupBox3 = New System.Windows.Forms.GroupBox()
      Me.groupBox5 = New System.Windows.Forms.GroupBox()
      Me._rbOmr = New System.Windows.Forms.RadioButton()
      Me._rbIDCard = New System.Windows.Forms.RadioButton()
      Me._rbNormal = New System.Windows.Forms.RadioButton()
      Me._lblImagePath = New System.Windows.Forms.Label()
      Me._btnPrevAddPage = New System.Windows.Forms.Button()
      Me._rdFromScanner = New System.Windows.Forms.RadioButton()
      Me._btnFinishCreate = New System.Windows.Forms.Button()
      Me._rdFromDisk = New System.Windows.Forms.RadioButton()
      Me._btnBrowsePage = New System.Windows.Forms.Button()
      Me._tbLoad = New System.Windows.Forms.TabPage()
      Me._btnBrowseMaster = New System.Windows.Forms.Button()
      Me._txtMasterFormsPath = New System.Windows.Forms.TextBox()
      Me.groupBox4 = New System.Windows.Forms.GroupBox()
      Me.label3 = New System.Windows.Forms.Label()
      Me._btnPrevLoad = New System.Windows.Forms.Button()
      Me._btnFinishLoad = New System.Windows.Forms.Button()
      Me._lblAboutDemo = New System.Windows.Forms.Label()
      Me._tbMain.SuspendLayout()
      Me._tbAboutDemo.SuspendLayout()
      Me._tbOptions.SuspendLayout()
      Me.groupBox1.SuspendLayout()
      Me._tbCreate.SuspendLayout()
      Me.groupBox2.SuspendLayout()
      Me._tbAddPage.SuspendLayout()
      Me.groupBox3.SuspendLayout()
      Me.groupBox5.SuspendLayout()
      Me._tbLoad.SuspendLayout()
      Me.groupBox4.SuspendLayout()
      Me.SuspendLayout()
      '
      '_tbMain
      '
      Me._tbMain.Controls.Add(Me._tbAboutDemo)
      Me._tbMain.Controls.Add(Me._tbOptions)
      Me._tbMain.Controls.Add(Me._tbCreate)
      Me._tbMain.Controls.Add(Me._tbAddPage)
      Me._tbMain.Controls.Add(Me._tbLoad)
      Me._tbMain.Location = New System.Drawing.Point(-4, -3)
      Me._tbMain.Name = "_tbMain"
      Me._tbMain.SelectedIndex = 0
      Me._tbMain.Size = New System.Drawing.Size(475, 215)
      Me._tbMain.TabIndex = 0
      '
      '_tbAboutDemo
      '
      Me._tbAboutDemo.Controls.Add(Me._lblAboutDemo)
      Me._tbAboutDemo.Controls.Add(Me._lblLink)
      Me._tbAboutDemo.Controls.Add(Me._btnNextAbout)
      Me._tbAboutDemo.Location = New System.Drawing.Point(4, 22)
      Me._tbAboutDemo.Name = "_tbAboutDemo"
      Me._tbAboutDemo.Padding = New System.Windows.Forms.Padding(3)
      Me._tbAboutDemo.Size = New System.Drawing.Size(467, 189)
      Me._tbAboutDemo.TabIndex = 4
      Me._tbAboutDemo.Text = "About Demo"
      Me._tbAboutDemo.UseVisualStyleBackColor = True
      '
      '_lblLink
      '
      Me._lblLink.AutoSize = True
      Me._lblLink.Location = New System.Drawing.Point(93, 137)
      Me._lblLink.Name = "_lblLink"
      Me._lblLink.Size = New System.Drawing.Size(257, 13)
      Me._lblLink.TabIndex = 1
      Me._lblLink.TabStop = True
      Me._lblLink.Text = "How to Use LEADTOOLS Master Forms Editor Demo"
      '
      '_btnNextAbout
      '
      Me._btnNextAbout.Location = New System.Drawing.Point(376, 160)
      Me._btnNextAbout.Name = "_btnNextAbout"
      Me._btnNextAbout.Size = New System.Drawing.Size(88, 23)
      Me._btnNextAbout.TabIndex = 2
      Me._btnNextAbout.Text = "&Next"
      Me._btnNextAbout.UseVisualStyleBackColor = True
      '
      '_tbOptions
      '
      Me._tbOptions.Controls.Add(Me.groupBox1)
      Me._tbOptions.Location = New System.Drawing.Point(4, 22)
      Me._tbOptions.Name = "_tbOptions"
      Me._tbOptions.Padding = New System.Windows.Forms.Padding(3)
      Me._tbOptions.Size = New System.Drawing.Size(467, 189)
      Me._tbOptions.TabIndex = 0
      Me._tbOptions.Text = "Master forms options"
      Me._tbOptions.UseVisualStyleBackColor = True
      '
      'groupBox1
      '
      Me.groupBox1.Controls.Add(Me._btnPrevOptions)
      Me.groupBox1.Controls.Add(Me._btnNext)
      Me.groupBox1.Controls.Add(Me._rdLoad)
      Me.groupBox1.Controls.Add(Me._rdCreate)
      Me.groupBox1.Location = New System.Drawing.Point(13, 27)
      Me.groupBox1.Name = "groupBox1"
      Me.groupBox1.Size = New System.Drawing.Size(454, 166)
      Me.groupBox1.TabIndex = 5
      Me.groupBox1.TabStop = False
      Me.groupBox1.Text = "Master Forms"
      '
      '_btnPrevOptions
      '
      Me._btnPrevOptions.Location = New System.Drawing.Point(269, 133)
      Me._btnPrevOptions.Name = "_btnPrevOptions"
      Me._btnPrevOptions.Size = New System.Drawing.Size(88, 23)
      Me._btnPrevOptions.TabIndex = 5
      Me._btnPrevOptions.Text = "&Previous"
      Me._btnPrevOptions.UseVisualStyleBackColor = True
      '
      '_btnNext
      '
      Me._btnNext.Location = New System.Drawing.Point(363, 133)
      Me._btnNext.Name = "_btnNext"
      Me._btnNext.Size = New System.Drawing.Size(88, 23)
      Me._btnNext.TabIndex = 0
      Me._btnNext.Text = "&Next"
      Me._btnNext.UseVisualStyleBackColor = True
      '
      '_rdLoad
      '
      Me._rdLoad.AutoSize = True
      Me._rdLoad.Location = New System.Drawing.Point(15, 85)
      Me._rdLoad.Name = "_rdLoad"
      Me._rdLoad.Size = New System.Drawing.Size(184, 17)
      Me._rdLoad.TabIndex = 4
      Me._rdLoad.Text = "Load/Edit existing master form set"
      Me._rdLoad.UseVisualStyleBackColor = True
      '
      '_rdCreate
      '
      Me._rdCreate.AutoSize = True
      Me._rdCreate.Checked = True
      Me._rdCreate.Location = New System.Drawing.Point(15, 54)
      Me._rdCreate.Name = "_rdCreate"
      Me._rdCreate.Size = New System.Drawing.Size(162, 17)
      Me._rdCreate.TabIndex = 3
      Me._rdCreate.TabStop = True
      Me._rdCreate.Text = "Create a new master form set"
      Me._rdCreate.UseVisualStyleBackColor = True
      '
      '_tbCreate
      '
      Me._tbCreate.Controls.Add(Me._txtMasterFormsName)
      Me._tbCreate.Controls.Add(Me.groupBox2)
      Me._tbCreate.Location = New System.Drawing.Point(4, 22)
      Me._tbCreate.Name = "_tbCreate"
      Me._tbCreate.Padding = New System.Windows.Forms.Padding(3)
      Me._tbCreate.Size = New System.Drawing.Size(467, 189)
      Me._tbCreate.TabIndex = 1
      Me._tbCreate.Text = "Create Master Form"
      Me._tbCreate.UseVisualStyleBackColor = True
      '
      '_txtMasterFormsName
      '
      Me._txtMasterFormsName.Location = New System.Drawing.Point(129, 75)
      Me._txtMasterFormsName.Name = "_txtMasterFormsName"
      Me._txtMasterFormsName.Size = New System.Drawing.Size(331, 20)
      Me._txtMasterFormsName.TabIndex = 0
      '
      'groupBox2
      '
      Me.groupBox2.Controls.Add(Me._btnMasterDirectory)
      Me.groupBox2.Controls.Add(Me._btnPrevCreate)
      Me.groupBox2.Controls.Add(Me._txtMasterFormsDirectory)
      Me.groupBox2.Controls.Add(Me.label1)
      Me.groupBox2.Controls.Add(Me.label2)
      Me.groupBox2.Controls.Add(Me._btnNextCreate)
      Me.groupBox2.Location = New System.Drawing.Point(13, 27)
      Me.groupBox2.Name = "groupBox2"
      Me.groupBox2.Size = New System.Drawing.Size(454, 166)
      Me.groupBox2.TabIndex = 8
      Me.groupBox2.TabStop = False
      Me.groupBox2.Text = "Create Master Form"
      '
      '_btnMasterDirectory
      '
      Me._btnMasterDirectory.Location = New System.Drawing.Point(421, 94)
      Me._btnMasterDirectory.Name = "_btnMasterDirectory"
      Me._btnMasterDirectory.Size = New System.Drawing.Size(27, 20)
      Me._btnMasterDirectory.TabIndex = 5
      Me._btnMasterDirectory.Text = "..."
      Me._btnMasterDirectory.UseVisualStyleBackColor = True
      '
      '_btnPrevCreate
      '
      Me._btnPrevCreate.Location = New System.Drawing.Point(269, 133)
      Me._btnPrevCreate.Name = "_btnPrevCreate"
      Me._btnPrevCreate.Size = New System.Drawing.Size(88, 23)
      Me._btnPrevCreate.TabIndex = 6
      Me._btnPrevCreate.Text = "&Previous"
      Me._btnPrevCreate.UseVisualStyleBackColor = True
      '
      '_txtMasterFormsDirectory
      '
      Me._txtMasterFormsDirectory.Location = New System.Drawing.Point(116, 94)
      Me._txtMasterFormsDirectory.Name = "_txtMasterFormsDirectory"
      Me._txtMasterFormsDirectory.Size = New System.Drawing.Size(298, 20)
      Me._txtMasterFormsDirectory.TabIndex = 4
      '
      'label1
      '
      Me.label1.AutoSize = True
      Me.label1.Location = New System.Drawing.Point(6, 51)
      Me.label1.Name = "label1"
      Me.label1.Size = New System.Drawing.Size(101, 13)
      Me.label1.TabIndex = 1
      Me.label1.Text = "Master Forms Name"
      '
      'label2
      '
      Me.label2.AutoSize = True
      Me.label2.Location = New System.Drawing.Point(62, 97)
      Me.label2.Name = "label2"
      Me.label2.Size = New System.Drawing.Size(48, 13)
      Me.label2.TabIndex = 3
      Me.label2.Text = "Save To"
      '
      '_btnNextCreate
      '
      Me._btnNextCreate.Location = New System.Drawing.Point(363, 133)
      Me._btnNextCreate.Name = "_btnNextCreate"
      Me._btnNextCreate.Size = New System.Drawing.Size(88, 23)
      Me._btnNextCreate.TabIndex = 2
      Me._btnNextCreate.Text = "&Next"
      Me._btnNextCreate.UseVisualStyleBackColor = True
      '
      '_tbAddPage
      '
      Me._tbAddPage.Controls.Add(Me._btnAcquirePage)
      Me._tbAddPage.Controls.Add(Me._txtPagePath)
      Me._tbAddPage.Controls.Add(Me.groupBox3)
      Me._tbAddPage.Location = New System.Drawing.Point(4, 22)
      Me._tbAddPage.Name = "_tbAddPage"
      Me._tbAddPage.Size = New System.Drawing.Size(467, 189)
      Me._tbAddPage.TabIndex = 3
      Me._tbAddPage.Text = "Add Page"
      Me._tbAddPage.UseVisualStyleBackColor = True
      '
      '_btnAcquirePage
      '
      Me._btnAcquirePage.Location = New System.Drawing.Point(150, 124)
      Me._btnAcquirePage.Name = "_btnAcquirePage"
      Me._btnAcquirePage.Size = New System.Drawing.Size(179, 21)
      Me._btnAcquirePage.TabIndex = 12
      Me._btnAcquirePage.Text = "Acquire Page"
      Me._btnAcquirePage.UseVisualStyleBackColor = True
      Me._btnAcquirePage.Visible = False
      '
      '_txtPagePath
      '
      Me._txtPagePath.Location = New System.Drawing.Point(87, 125)
      Me._txtPagePath.Name = "_txtPagePath"
      Me._txtPagePath.Size = New System.Drawing.Size(340, 20)
      Me._txtPagePath.TabIndex = 6
      '
      'groupBox3
      '
      Me.groupBox3.Controls.Add(Me.groupBox5)
      Me.groupBox3.Controls.Add(Me._lblImagePath)
      Me.groupBox3.Controls.Add(Me._btnPrevAddPage)
      Me.groupBox3.Controls.Add(Me._rdFromScanner)
      Me.groupBox3.Controls.Add(Me._btnFinishCreate)
      Me.groupBox3.Controls.Add(Me._rdFromDisk)
      Me.groupBox3.Controls.Add(Me._btnBrowsePage)
      Me.groupBox3.Location = New System.Drawing.Point(13, 27)
      Me.groupBox3.Name = "groupBox3"
      Me.groupBox3.Size = New System.Drawing.Size(454, 166)
      Me.groupBox3.TabIndex = 15
      Me.groupBox3.TabStop = False
      Me.groupBox3.Text = "Add Page"
      '
      'groupBox5
      '
      Me.groupBox5.Controls.Add(Me._rbOmr)
      Me.groupBox5.Controls.Add(Me._rbIDCard)
      Me.groupBox5.Controls.Add(Me._rbNormal)
      Me.groupBox5.Location = New System.Drawing.Point(195, 19)
      Me.groupBox5.Name = "groupBox5"
      Me.groupBox5.Size = New System.Drawing.Size(253, 44)
      Me.groupBox5.TabIndex = 15
      Me.groupBox5.TabStop = False
      Me.groupBox5.Text = "Page Type"
      '
      '_rbOmr
      '
      Me._rbOmr.AutoSize = True
      Me._rbOmr.Location = New System.Drawing.Point(170, 19)
      Me._rbOmr.Name = "_rbOmr"
      Me._rbOmr.Size = New System.Drawing.Size(44, 17)
      Me._rbOmr.TabIndex = 26
      Me._rbOmr.Text = "Omr"
      Me._rbOmr.UseVisualStyleBackColor = True
      '
      '_rbIDCard
      '
      Me._rbIDCard.AutoSize = True
      Me._rbIDCard.Location = New System.Drawing.Point(87, 19)
      Me._rbIDCard.Name = "_rbIDCard"
      Me._rbIDCard.Size = New System.Drawing.Size(61, 17)
      Me._rbIDCard.TabIndex = 25
      Me._rbIDCard.Text = "ID Card"
      Me._rbIDCard.UseVisualStyleBackColor = True
      '
      '_rbNormal
      '
      Me._rbNormal.AutoSize = True
      Me._rbNormal.Checked = True
      Me._rbNormal.Location = New System.Drawing.Point(7, 19)
      Me._rbNormal.Name = "_rbNormal"
      Me._rbNormal.Size = New System.Drawing.Size(58, 17)
      Me._rbNormal.TabIndex = 24
      Me._rbNormal.TabStop = True
      Me._rbNormal.Text = "Normal"
      Me._rbNormal.UseVisualStyleBackColor = True
      '
      '_lblImagePath
      '
      Me._lblImagePath.AutoSize = True
      Me._lblImagePath.Location = New System.Drawing.Point(6, 101)
      Me._lblImagePath.Name = "_lblImagePath"
      Me._lblImagePath.Size = New System.Drawing.Size(61, 13)
      Me._lblImagePath.TabIndex = 13
      Me._lblImagePath.Text = "Image Path"
      '
      '_btnPrevAddPage
      '
      Me._btnPrevAddPage.Location = New System.Drawing.Point(269, 133)
      Me._btnPrevAddPage.Name = "_btnPrevAddPage"
      Me._btnPrevAddPage.Size = New System.Drawing.Size(88, 23)
      Me._btnPrevAddPage.TabIndex = 14
      Me._btnPrevAddPage.Text = "&Previous"
      Me._btnPrevAddPage.UseVisualStyleBackColor = True
      '
      '_rdFromScanner
      '
      Me._rdFromScanner.AutoSize = True
      Me._rdFromScanner.Location = New System.Drawing.Point(54, 58)
      Me._rdFromScanner.Name = "_rdFromScanner"
      Me._rdFromScanner.Size = New System.Drawing.Size(91, 17)
      Me._rdFromScanner.TabIndex = 8
      Me._rdFromScanner.Text = "From Scanner"
      Me._rdFromScanner.UseVisualStyleBackColor = True
      '
      '_btnFinishCreate
      '
      Me._btnFinishCreate.Location = New System.Drawing.Point(363, 133)
      Me._btnFinishCreate.Name = "_btnFinishCreate"
      Me._btnFinishCreate.Size = New System.Drawing.Size(88, 23)
      Me._btnFinishCreate.TabIndex = 11
      Me._btnFinishCreate.Text = "&Finish"
      Me._btnFinishCreate.UseVisualStyleBackColor = True
      '
      '_rdFromDisk
      '
      Me._rdFromDisk.AutoSize = True
      Me._rdFromDisk.Checked = True
      Me._rdFromDisk.Location = New System.Drawing.Point(54, 19)
      Me._rdFromDisk.Name = "_rdFromDisk"
      Me._rdFromDisk.Size = New System.Drawing.Size(72, 17)
      Me._rdFromDisk.TabIndex = 7
      Me._rdFromDisk.TabStop = True
      Me._rdFromDisk.Text = "From Disk"
      Me._rdFromDisk.UseVisualStyleBackColor = True
      '
      '_btnBrowsePage
      '
      Me._btnBrowsePage.Location = New System.Drawing.Point(421, 97)
      Me._btnBrowsePage.Name = "_btnBrowsePage"
      Me._btnBrowsePage.Size = New System.Drawing.Size(27, 20)
      Me._btnBrowsePage.TabIndex = 10
      Me._btnBrowsePage.Text = "..."
      Me._btnBrowsePage.UseVisualStyleBackColor = True
      '
      '_tbLoad
      '
      Me._tbLoad.Controls.Add(Me._btnBrowseMaster)
      Me._tbLoad.Controls.Add(Me._txtMasterFormsPath)
      Me._tbLoad.Controls.Add(Me.groupBox4)
      Me._tbLoad.Location = New System.Drawing.Point(4, 22)
      Me._tbLoad.Name = "_tbLoad"
      Me._tbLoad.Size = New System.Drawing.Size(467, 189)
      Me._tbLoad.TabIndex = 2
      Me._tbLoad.Text = "Load Master Form"
      Me._tbLoad.UseVisualStyleBackColor = True
      '
      '_btnBrowseMaster
      '
      Me._btnBrowseMaster.Location = New System.Drawing.Point(434, 83)
      Me._btnBrowseMaster.Name = "_btnBrowseMaster"
      Me._btnBrowseMaster.Size = New System.Drawing.Size(27, 20)
      Me._btnBrowseMaster.TabIndex = 1
      Me._btnBrowseMaster.Text = "..."
      Me._btnBrowseMaster.UseVisualStyleBackColor = True
      '
      '_txtMasterFormsPath
      '
      Me._txtMasterFormsPath.Location = New System.Drawing.Point(122, 83)
      Me._txtMasterFormsPath.Name = "_txtMasterFormsPath"
      Me._txtMasterFormsPath.Size = New System.Drawing.Size(306, 20)
      Me._txtMasterFormsPath.TabIndex = 0
      '
      'groupBox4
      '
      Me.groupBox4.Controls.Add(Me.label3)
      Me.groupBox4.Controls.Add(Me._btnPrevLoad)
      Me.groupBox4.Controls.Add(Me._btnFinishLoad)
      Me.groupBox4.Location = New System.Drawing.Point(13, 27)
      Me.groupBox4.Name = "groupBox4"
      Me.groupBox4.Size = New System.Drawing.Size(454, 166)
      Me.groupBox4.TabIndex = 5
      Me.groupBox4.TabStop = False
      Me.groupBox4.Text = "Load Master Form"
      '
      'label3
      '
      Me.label3.AutoSize = True
      Me.label3.Location = New System.Drawing.Point(6, 59)
      Me.label3.Name = "label3"
      Me.label3.Size = New System.Drawing.Size(95, 13)
      Me.label3.TabIndex = 3
      Me.label3.Text = "Master Forms Path"
      '
      '_btnPrevLoad
      '
      Me._btnPrevLoad.Location = New System.Drawing.Point(269, 133)
      Me._btnPrevLoad.Name = "_btnPrevLoad"
      Me._btnPrevLoad.Size = New System.Drawing.Size(88, 23)
      Me._btnPrevLoad.TabIndex = 4
      Me._btnPrevLoad.Text = "&Previous"
      Me._btnPrevLoad.UseVisualStyleBackColor = True
      '
      '_btnFinishLoad
      '
      Me._btnFinishLoad.Location = New System.Drawing.Point(363, 133)
      Me._btnFinishLoad.Name = "_btnFinishLoad"
      Me._btnFinishLoad.Size = New System.Drawing.Size(88, 23)
      Me._btnFinishLoad.TabIndex = 2
      Me._btnFinishLoad.Text = "&Finish"
      Me._btnFinishLoad.UseVisualStyleBackColor = True
      '
      '_lblAboutDemo
      '
      Me._lblAboutDemo.Location = New System.Drawing.Point(22, 31)
      Me._lblAboutDemo.Name = "_lblAboutDemo"
      Me._lblAboutDemo.Size = New System.Drawing.Size(427, 97)
      Me._lblAboutDemo.TabIndex = 3
      Me._lblAboutDemo.Text = resources.GetString("_lblAboutDemo.Text")
      '
      'MasterFormsWizard
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(498, 224)
      Me.Controls.Add(Me._tbMain)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.Name = "MasterFormsWizard"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "LEADTOOLS Master Form Editor"
      Me._tbMain.ResumeLayout(False)
      Me._tbAboutDemo.ResumeLayout(False)
      Me._tbAboutDemo.PerformLayout()
      Me._tbOptions.ResumeLayout(False)
      Me.groupBox1.ResumeLayout(False)
      Me.groupBox1.PerformLayout()
      Me._tbCreate.ResumeLayout(False)
      Me._tbCreate.PerformLayout()
      Me.groupBox2.ResumeLayout(False)
      Me.groupBox2.PerformLayout()
      Me._tbAddPage.ResumeLayout(False)
      Me._tbAddPage.PerformLayout()
      Me.groupBox3.ResumeLayout(False)
      Me.groupBox3.PerformLayout()
      Me.groupBox5.ResumeLayout(False)
      Me.groupBox5.PerformLayout()
      Me._tbLoad.ResumeLayout(False)
      Me._tbLoad.PerformLayout()
      Me.groupBox4.ResumeLayout(False)
      Me.groupBox4.PerformLayout()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private _tbMain As System.Windows.Forms.TabControl
   Private _tbOptions As System.Windows.Forms.TabPage
   Private _tbCreate As System.Windows.Forms.TabPage
   Private WithEvents _btnNext As System.Windows.Forms.Button
   Private _rdLoad As System.Windows.Forms.RadioButton
   Private _rdCreate As System.Windows.Forms.RadioButton
   Private _tbLoad As System.Windows.Forms.TabPage
   Private WithEvents _btnFinishLoad As System.Windows.Forms.Button
   Private WithEvents _btnBrowseMaster As System.Windows.Forms.Button
   Private _txtMasterFormsPath As System.Windows.Forms.TextBox
   Private label1 As System.Windows.Forms.Label
   Private _txtMasterFormsName As System.Windows.Forms.TextBox
   Private WithEvents _btnNextCreate As System.Windows.Forms.Button
   Private _tbAddPage As System.Windows.Forms.TabPage
   Private WithEvents _btnFinishCreate As System.Windows.Forms.Button
   Private WithEvents _btnBrowsePage As System.Windows.Forms.Button
   Private _txtPagePath As System.Windows.Forms.TextBox
   Private WithEvents _rdFromScanner As System.Windows.Forms.RadioButton
   Private WithEvents _rdFromDisk As System.Windows.Forms.RadioButton
   Private WithEvents _btnAcquirePage As System.Windows.Forms.Button
   Private WithEvents _btnMasterDirectory As System.Windows.Forms.Button
   Private _txtMasterFormsDirectory As System.Windows.Forms.TextBox
   Private label2 As System.Windows.Forms.Label
   Private label3 As System.Windows.Forms.Label
   Private _lblImagePath As System.Windows.Forms.Label
   Private WithEvents _btnPrevCreate As System.Windows.Forms.Button
   Private WithEvents _btnPrevAddPage As System.Windows.Forms.Button
   Private WithEvents _btnPrevLoad As System.Windows.Forms.Button
   Private groupBox1 As System.Windows.Forms.GroupBox
   Private groupBox2 As System.Windows.Forms.GroupBox
   Private groupBox3 As System.Windows.Forms.GroupBox
   Private groupBox4 As System.Windows.Forms.GroupBox
   Private _tbAboutDemo As System.Windows.Forms.TabPage
   Private WithEvents _lblLink As System.Windows.Forms.LinkLabel
   Private WithEvents _btnNextAbout As System.Windows.Forms.Button
   Private WithEvents _btnPrevOptions As System.Windows.Forms.Button
   Private groupBox5 As System.Windows.Forms.GroupBox
   Private _rbOmr As System.Windows.Forms.RadioButton
   Private _rbIDCard As System.Windows.Forms.RadioButton
   Private _rbNormal As System.Windows.Forms.RadioButton
   Private WithEvents _lblAboutDemo As System.Windows.Forms.Label
End Class
