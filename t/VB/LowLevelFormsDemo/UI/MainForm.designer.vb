Namespace FormsDemo
   Partial Class MainForm
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
         Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
         Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
         Me._menuItemFile = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemLaunchMasterFormsEditor = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemExit = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemRecognition = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemRecognizeScannedForms = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemRecognizeSingleForm = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemRecognizeMultipleForms = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemOptions = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemObjectManagers = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemOCRManager = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemBarcodeManager = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemDefaultManager = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemRecognizeFirstPageOnly = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemHelp = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemHowto = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuItemAbout = New System.Windows.Forms.ToolStripMenuItem()
         Me._chImage = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
         Me._pbProgress = New System.Windows.Forms.ProgressBar()
         Me._lblStatus = New System.Windows.Forms.Label()
         Me._lblFormName = New System.Windows.Forms.Label()
         Me._lblTimingInformation = New System.Windows.Forms.Label()
         Me._btnCancel = New System.Windows.Forms.Button()
         Me._lblMasterFormRespository = New System.Windows.Forms.Label()
         Me._txtMasterFormRespository = New System.Windows.Forms.TextBox()
         Me._lvLastOperation = New System.Windows.Forms.ListView()
         Me._chOperation = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
         Me._chTime = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
         Me._btnBrowseMasterFormRespository = New System.Windows.Forms.Button()
         Me._rb_OCR_ICR = New System.Windows.Forms.RadioButton()
         Me._rb_OCR = New System.Windows.Forms.RadioButton()
         Me._rb_DL = New System.Windows.Forms.RadioButton()
         Me._rb_Invoice = New System.Windows.Forms.RadioButton()
         Me._rb_Omr = New System.Windows.Forms.RadioButton()
         Me.menuStrip1.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' menuStrip1
         ' 
         Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemFile, Me._menuItemRecognition, Me._menuItemOptions, Me._menuItemHelp})
         Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
         Me.menuStrip1.Name = "menuStrip1"
         Me.menuStrip1.Size = New System.Drawing.Size(486, 24)
         Me.menuStrip1.TabIndex = 14
         Me.menuStrip1.Text = "menuStrip1"
         ' 
         ' _menuItemFile
         ' 
         Me._menuItemFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemLaunchMasterFormsEditor, Me._menuItemExit})
         Me._menuItemFile.Name = "_menuItemFile"
         Me._menuItemFile.Size = New System.Drawing.Size(37, 20)
         Me._menuItemFile.Text = "File"
         ' 
         ' _menuItemLaunchMasterFormsEditor
         ' 
         Me._menuItemLaunchMasterFormsEditor.Name = "_menuItemLaunchMasterFormsEditor"
         Me._menuItemLaunchMasterFormsEditor.Size = New System.Drawing.Size(222, 22)
         Me._menuItemLaunchMasterFormsEditor.Text = "Launch Master Forms Editor"
         ' 
         ' _menuItemExit
         ' 
         Me._menuItemExit.Name = "_menuItemExit"
         Me._menuItemExit.Size = New System.Drawing.Size(222, 22)
         Me._menuItemExit.Text = "Exit"
         ' 
         ' _menuItemRecognition
         ' 
         Me._menuItemRecognition.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemRecognizeScannedForms, Me._menuItemRecognizeSingleForm, Me._menuItemRecognizeMultipleForms})
         Me._menuItemRecognition.Name = "_menuItemRecognition"
         Me._menuItemRecognition.Size = New System.Drawing.Size(83, 20)
         Me._menuItemRecognition.Text = "Recognition"
         ' 
         ' _menuItemRecognizeScannedForms
         ' 
         Me._menuItemRecognizeScannedForms.Name = "_menuItemRecognizeScannedForms"
         Me._menuItemRecognizeScannedForms.Size = New System.Drawing.Size(212, 22)
         Me._menuItemRecognizeScannedForms.Text = "Recognize Scanned Forms"
         ' 
         ' _menuItemRecognizeSingleForm
         ' 
         Me._menuItemRecognizeSingleForm.Name = "_menuItemRecognizeSingleForm"
         Me._menuItemRecognizeSingleForm.Size = New System.Drawing.Size(212, 22)
         Me._menuItemRecognizeSingleForm.Text = "Recognize Single Form"
         ' 
         ' _menuItemRecognizeMultipleForms
         ' 
         Me._menuItemRecognizeMultipleForms.Name = "_menuItemRecognizeMultipleForms"
         Me._menuItemRecognizeMultipleForms.Size = New System.Drawing.Size(212, 22)
         Me._menuItemRecognizeMultipleForms.Text = "Recognize Multiple Forms"
         ' 
         ' _menuItemOptions
         ' 
         Me._menuItemOptions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemObjectManagers, Me._menuItemRecognizeFirstPageOnly})
         Me._menuItemOptions.Name = "_menuItemOptions"
         Me._menuItemOptions.Size = New System.Drawing.Size(61, 20)
         Me._menuItemOptions.Text = "Options"
         ' 
         ' _menuItemObjectManagers
         ' 
         Me._menuItemObjectManagers.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemOCRManager, Me._menuItemBarcodeManager, Me._menuItemDefaultManager})
         Me._menuItemObjectManagers.Name = "_menuItemObjectManagers"
         Me._menuItemObjectManagers.Size = New System.Drawing.Size(210, 22)
         Me._menuItemObjectManagers.Text = "Object Managers"
         ' 
         ' _menuItemOCRManager
         ' 
         Me._menuItemOCRManager.Checked = True
         Me._menuItemOCRManager.CheckOnClick = True
         Me._menuItemOCRManager.CheckState = System.Windows.Forms.CheckState.Checked
         Me._menuItemOCRManager.Name = "_menuItemOCRManager"
         Me._menuItemOCRManager.Size = New System.Drawing.Size(205, 22)
         Me._menuItemOCRManager.Text = "OCR Object Manager"
         ' 
         ' _menuItemBarcodeManager
         ' 
         Me._menuItemBarcodeManager.CheckOnClick = True
         Me._menuItemBarcodeManager.Name = "_menuItemBarcodeManager"
         Me._menuItemBarcodeManager.Size = New System.Drawing.Size(205, 22)
         Me._menuItemBarcodeManager.Text = "Barcode Object Manager"
         ' 
         ' _menuItemDefaultManager
         ' 
         Me._menuItemDefaultManager.CheckOnClick = True
         Me._menuItemDefaultManager.Name = "_menuItemDefaultManager"
         Me._menuItemDefaultManager.Size = New System.Drawing.Size(205, 22)
         Me._menuItemDefaultManager.Text = "Default Objects Manager"
         ' 
         ' _menuItemRecognizeFirstPageOnly
         ' 
         Me._menuItemRecognizeFirstPageOnly.Checked = True
         Me._menuItemRecognizeFirstPageOnly.CheckOnClick = True
         Me._menuItemRecognizeFirstPageOnly.CheckState = System.Windows.Forms.CheckState.Checked
         Me._menuItemRecognizeFirstPageOnly.Name = "_menuItemRecognizeFirstPageOnly"
         Me._menuItemRecognizeFirstPageOnly.Size = New System.Drawing.Size(210, 22)
         Me._menuItemRecognizeFirstPageOnly.Text = "Recognize First Page Only"
         ' 
         ' _menuItemHelp
         ' 
         Me._menuItemHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._menuItemHowto, Me._menuItemAbout})
         Me._menuItemHelp.Name = "_menuItemHelp"
         Me._menuItemHelp.Size = New System.Drawing.Size(44, 20)
         Me._menuItemHelp.Text = "Help"
         ' 
         ' _menuItemHowto
         ' 
         Me._menuItemHowto.Name = "_menuItemHowto"
         Me._menuItemHowto.Size = New System.Drawing.Size(116, 22)
         Me._menuItemHowto.Text = "How To"
         ' 
         ' _menuItemAbout
         ' 
         Me._menuItemAbout.Name = "_menuItemAbout"
         Me._menuItemAbout.Size = New System.Drawing.Size(116, 22)
         Me._menuItemAbout.Text = "About"
         ' 
         ' _chImage
         ' 
         Me._chImage.Text = "Image File"
         Me._chImage.Width = 117
         ' 
         ' _pbProgress
         ' 
         Me._pbProgress.Location = New System.Drawing.Point(9, 413)
         Me._pbProgress.Name = "_pbProgress"
         Me._pbProgress.Size = New System.Drawing.Size(416, 23)
         Me._pbProgress.TabIndex = 27
         ' 
         ' _lblStatus
         ' 
         Me._lblStatus.AutoSize = True
         Me._lblStatus.Location = New System.Drawing.Point(6, 381)
         Me._lblStatus.Name = "_lblStatus"
         Me._lblStatus.Size = New System.Drawing.Size(37, 13)
         Me._lblStatus.TabIndex = 26
         Me._lblStatus.Text = "Status"
         ' 
         ' _lblFormName
         ' 
         Me._lblFormName.AutoSize = True
         Me._lblFormName.Location = New System.Drawing.Point(6, 351)
         Me._lblFormName.Name = "_lblFormName"
         Me._lblFormName.Size = New System.Drawing.Size(61, 13)
         Me._lblFormName.TabIndex = 25
         Me._lblFormName.Text = "Form Name"
         ' 
         ' _lblTimingInformation
         ' 
         Me._lblTimingInformation.AutoSize = True
         Me._lblTimingInformation.Location = New System.Drawing.Point(9, 217)
         Me._lblTimingInformation.Name = "_lblTimingInformation"
         Me._lblTimingInformation.Size = New System.Drawing.Size(93, 13)
         Me._lblTimingInformation.TabIndex = 24
         Me._lblTimingInformation.Text = "Timing Information"
         ' 
         ' _btnCancel
         ' 
         Me._btnCancel.Location = New System.Drawing.Point(9, 455)
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.Size = New System.Drawing.Size(82, 26)
         Me._btnCancel.TabIndex = 28
         Me._btnCancel.Text = "Cancel"
         Me._btnCancel.UseVisualStyleBackColor = True
         ' 
         ' _lblMasterFormRespository
         ' 
         Me._lblMasterFormRespository.AutoSize = True
         Me._lblMasterFormRespository.Location = New System.Drawing.Point(12, 42)
         Me._lblMasterFormRespository.Name = "_lblMasterFormRespository"
         Me._lblMasterFormRespository.Size = New System.Drawing.Size(123, 13)
         Me._lblMasterFormRespository.TabIndex = 21
         Me._lblMasterFormRespository.Text = "Master Form Respository"
         ' 
         ' _txtMasterFormRespository
         ' 
         Me._txtMasterFormRespository.Location = New System.Drawing.Point(12, 71)
         Me._txtMasterFormRespository.Name = "_txtMasterFormRespository"
         Me._txtMasterFormRespository.[ReadOnly] = True
         Me._txtMasterFormRespository.Size = New System.Drawing.Size(416, 20)
         Me._txtMasterFormRespository.TabIndex = 20
         ' 
         ' _lvLastOperation
         ' 
         Me._lvLastOperation.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me._chImage, Me._chOperation, Me._chTime})
         Me._lvLastOperation.Location = New System.Drawing.Point(9, 248)
         Me._lvLastOperation.Name = "_lvLastOperation"
         Me._lvLastOperation.Size = New System.Drawing.Size(416, 78)
         Me._lvLastOperation.TabIndex = 19
         Me._lvLastOperation.UseCompatibleStateImageBehavior = False
         Me._lvLastOperation.View = System.Windows.Forms.View.Details
         ' 
         ' _chOperation
         ' 
         Me._chOperation.Text = "Operation"
         Me._chOperation.Width = 199
         ' 
         ' _chTime
         ' 
         Me._chTime.Text = "Time (seconds)"
         Me._chTime.Width = 90
         ' 
         ' _btnBrowseMasterFormRespository
         ' 
         Me._btnBrowseMasterFormRespository.Location = New System.Drawing.Point(434, 70)
         Me._btnBrowseMasterFormRespository.Name = "_btnBrowseMasterFormRespository"
         Me._btnBrowseMasterFormRespository.Size = New System.Drawing.Size(37, 21)
         Me._btnBrowseMasterFormRespository.TabIndex = 22
         Me._btnBrowseMasterFormRespository.Text = "..."
         Me._btnBrowseMasterFormRespository.UseVisualStyleBackColor = True
         ' 
         ' _rb_OCR_ICR
         ' 
         Me._rb_OCR_ICR.AutoSize = True
         Me._rb_OCR_ICR.Location = New System.Drawing.Point(12, 120)
         Me._rb_OCR_ICR.Name = "_rb_OCR_ICR"
         Me._rb_OCR_ICR.Size = New System.Drawing.Size(60, 17)
         Me._rb_OCR_ICR.TabIndex = 30
         Me._rb_OCR_ICR.Text = "Ocr_Icr"
         Me._rb_OCR_ICR.UseVisualStyleBackColor = True
         ' 
         ' _rb_OCR
         ' 
         Me._rb_OCR.AutoSize = True
         Me._rb_OCR.Checked = True
         Me._rb_OCR.Location = New System.Drawing.Point(12, 97)
         Me._rb_OCR.Name = "_rb_OCR"
         Me._rb_OCR.Size = New System.Drawing.Size(42, 17)
         Me._rb_OCR.TabIndex = 29
         Me._rb_OCR.TabStop = True
         Me._rb_OCR.Text = "Ocr"
         Me._rb_OCR.UseVisualStyleBackColor = True
         ' 
         ' _rb_DL
         ' 
         Me._rb_DL.AutoSize = True
         Me._rb_DL.Location = New System.Drawing.Point(12, 143)
         Me._rb_DL.Name = "_rb_DL"
         Me._rb_DL.Size = New System.Drawing.Size(98, 17)
         Me._rb_DL.TabIndex = 31
         Me._rb_DL.Text = "Driving License"
         Me._rb_DL.UseVisualStyleBackColor = True
         ' 
         ' _rb_Invoice
         ' 
         Me._rb_Invoice.AutoSize = True
         Me._rb_Invoice.Location = New System.Drawing.Point(12, 166)
         Me._rb_Invoice.Name = "_rb_Invoice"
         Me._rb_Invoice.Size = New System.Drawing.Size(60, 17)
         Me._rb_Invoice.TabIndex = 32
         Me._rb_Invoice.TabStop = True
         Me._rb_Invoice.Text = "Invoice"
         Me._rb_Invoice.UseVisualStyleBackColor = True
         ' 
         ' _rb_Omr
         ' 
         Me._rb_Omr.AutoSize = True
         Me._rb_Omr.Location = New System.Drawing.Point(12, 189)
         Me._rb_Omr.Name = "_rb_Omr"
         Me._rb_Omr.Size = New System.Drawing.Size(44, 17)
         Me._rb_Omr.TabIndex = 33
         Me._rb_Omr.TabStop = True
         Me._rb_Omr.Text = "Omr"
         Me._rb_Omr.UseVisualStyleBackColor = True
         ' 
         ' MainForm
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(486, 487)
         Me.Controls.Add(Me._rb_Omr)
         Me.Controls.Add(Me._rb_Invoice)
         Me.Controls.Add(Me._rb_DL)
         Me.Controls.Add(Me._rb_OCR_ICR)
         Me.Controls.Add(Me._rb_OCR)
         Me.Controls.Add(Me._pbProgress)
         Me.Controls.Add(Me._lblStatus)
         Me.Controls.Add(Me._lblFormName)
         Me.Controls.Add(Me._lblTimingInformation)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._lblMasterFormRespository)
         Me.Controls.Add(Me._txtMasterFormRespository)
         Me.Controls.Add(Me._lvLastOperation)
         Me.Controls.Add(Me._btnBrowseMasterFormRespository)
         Me.Controls.Add(Me.menuStrip1)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
         Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
         Me.MaximizeBox = False
         Me.Name = "MainForm"
         Me.Text = "LEADTOOLS Low Level Forms Demo"
         Me.menuStrip1.ResumeLayout(False)
         Me.menuStrip1.PerformLayout()
         Me.ResumeLayout(False)
         Me.PerformLayout()
      End Sub

#End Region

        Private menuStrip1 As System.Windows.Forms.MenuStrip
        Private _menuItemFile As System.Windows.Forms.ToolStripMenuItem
        Private WithEvents _menuItemExit As System.Windows.Forms.ToolStripMenuItem
        Private _menuItemRecognition As System.Windows.Forms.ToolStripMenuItem
        Private WithEvents _menuItemRecognizeScannedForms As System.Windows.Forms.ToolStripMenuItem
        Private WithEvents _menuItemRecognizeSingleForm As System.Windows.Forms.ToolStripMenuItem
        Private WithEvents _menuItemRecognizeMultipleForms As System.Windows.Forms.ToolStripMenuItem
        Private _menuItemOptions As System.Windows.Forms.ToolStripMenuItem
        Private _menuItemObjectManagers As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemOCRManager As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemBarcodeManager As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _menuItemDefaultManager As System.Windows.Forms.ToolStripMenuItem
        Private _menuItemRecognizeFirstPageOnly As System.Windows.Forms.ToolStripMenuItem
        Private _menuItemHelp As System.Windows.Forms.ToolStripMenuItem
        Private WithEvents _menuItemHowto As System.Windows.Forms.ToolStripMenuItem
        Private WithEvents _menuItemAbout As System.Windows.Forms.ToolStripMenuItem
        Private _chImage As System.Windows.Forms.ColumnHeader
        Private _pbProgress As System.Windows.Forms.ProgressBar
        Private _lblStatus As System.Windows.Forms.Label
        Private _lblFormName As System.Windows.Forms.Label
        Private _lblTimingInformation As System.Windows.Forms.Label
        Private WithEvents _btnCancel As System.Windows.Forms.Button
        Private _lblMasterFormRespository As System.Windows.Forms.Label
        Private _txtMasterFormRespository As System.Windows.Forms.TextBox
        Private _lvLastOperation As System.Windows.Forms.ListView
        Private _chOperation As System.Windows.Forms.ColumnHeader
        Private _chTime As System.Windows.Forms.ColumnHeader
        Private WithEvents _btnBrowseMasterFormRespository As System.Windows.Forms.Button
        Private WithEvents _menuItemLaunchMasterFormsEditor As System.Windows.Forms.ToolStripMenuItem
        Private WithEvents _rb_OCR_ICR As System.Windows.Forms.RadioButton
        Private WithEvents _rb_OCR As System.Windows.Forms.RadioButton
        Private WithEvents _rb_DL As System.Windows.Forms.RadioButton
        Private WithEvents _rb_Invoice As System.Windows.Forms.RadioButton
        Private WithEvents _rb_Omr As System.Windows.Forms.RadioButton

   End Class
End Namespace

