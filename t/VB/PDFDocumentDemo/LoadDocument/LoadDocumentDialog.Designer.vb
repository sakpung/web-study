Namespace PDFDocumentDemo.LoadDocument
   Partial Class LoadDocumentDialog
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoadDocumentDialog))
         Me._cancelButton = New System.Windows.Forms.Button()
         Me._fileNameTextBox = New System.Windows.Forms.TextBox()
         Me._okButton = New System.Windows.Forms.Button()
         Me._mainWizardControl = New PDFDocumentDemo.WizardControl()
         Me._propertiesTabPage = New System.Windows.Forms.TabPage()
         Me._getDocumentPropertiesControl = New PDFDocumentDemo.LoadDocument.GetDocumentPropertiesControl()
         Me._optionsTabPage = New System.Windows.Forms.TabPage()
         Me._loadDocumentOptionsControl = New PDFDocumentDemo.LoadDocument.LoadDocumentOptionsControl()
         Me._readTabPage = New System.Windows.Forms.TabPage()
         Me._readPDFDocumentControl = New PDFDocumentDemo.LoadDocument.ReadPDFDocumentControl()
         Me._mainWizardControl.SuspendLayout()
         Me._propertiesTabPage.SuspendLayout()
         Me._optionsTabPage.SuspendLayout()
         Me._readTabPage.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _cancelButton
         ' 
         Me._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
         resources.ApplyResources(Me._cancelButton, "_cancelButton")
         Me._cancelButton.Name = "_cancelButton"
         Me._cancelButton.UseVisualStyleBackColor = True
         ' 
         ' _fileNameTextBox
         ' 
         resources.ApplyResources(Me._fileNameTextBox, "_fileNameTextBox")
         Me._fileNameTextBox.Name = "_fileNameTextBox"
         Me._fileNameTextBox.ReadOnly = True
         Me._fileNameTextBox.TabStop = False
         ' 
         ' _okButton
         ' 
         Me._okButton.DialogResult = System.Windows.Forms.DialogResult.OK
         resources.ApplyResources(Me._okButton, "_okButton")
         Me._okButton.Name = "_okButton"
         Me._okButton.UseVisualStyleBackColor = True
         ' 
         ' _mainWizardControl
         ' 
         Me._mainWizardControl.Controls.Add(Me._propertiesTabPage)
         Me._mainWizardControl.Controls.Add(Me._optionsTabPage)
         Me._mainWizardControl.Controls.Add(Me._readTabPage)
         resources.ApplyResources(Me._mainWizardControl, "_mainWizardControl")
         Me._mainWizardControl.Name = "_mainWizardControl"
         Me._mainWizardControl.SelectedIndex = 0
         ' 
         ' _propertiesTabPage
         ' 
         Me._propertiesTabPage.Controls.Add(Me._getDocumentPropertiesControl)
         resources.ApplyResources(Me._propertiesTabPage, "_propertiesTabPage")
         Me._propertiesTabPage.Name = "_propertiesTabPage"
         Me._propertiesTabPage.UseVisualStyleBackColor = True
         ' 
         ' _getDocumentPropertiesControl
         ' 
         resources.ApplyResources(Me._getDocumentPropertiesControl, "_getDocumentPropertiesControl")
         Me._getDocumentPropertiesControl.Name = "_getDocumentPropertiesControl"
         ' 
         ' _optionsTabPage
         ' 
         Me._optionsTabPage.Controls.Add(Me._loadDocumentOptionsControl)
         resources.ApplyResources(Me._optionsTabPage, "_optionsTabPage")
         Me._optionsTabPage.Name = "_optionsTabPage"
         Me._optionsTabPage.UseVisualStyleBackColor = True
         ' 
         ' _loadDocumentOptionsControl
         ' 
         resources.ApplyResources(Me._loadDocumentOptionsControl, "_loadDocumentOptionsControl")
         Me._loadDocumentOptionsControl.Name = "_loadDocumentOptionsControl"
         ' 
         ' _readTabPage
         ' 
         Me._readTabPage.Controls.Add(Me._readPDFDocumentControl)
         resources.ApplyResources(Me._readTabPage, "_readTabPage")
         Me._readTabPage.Name = "_readTabPage"
         Me._readTabPage.UseVisualStyleBackColor = True
         ' 
         ' _readPDFDocumentControl
         ' 
         resources.ApplyResources(Me._readPDFDocumentControl, "_readPDFDocumentControl")
         Me._readPDFDocumentControl.Name = "_readPDFDocumentControl"
         ' 
         ' LoadDocumentDialog
         ' 
         Me.AcceptButton = Me._okButton
         resources.ApplyResources(Me, "$this")
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me._cancelButton
         Me.Controls.Add(Me._okButton)
         Me.Controls.Add(Me._fileNameTextBox)
         Me.Controls.Add(Me._mainWizardControl)
         Me.Controls.Add(Me._cancelButton)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "LoadDocumentDialog"
         Me.ShowInTaskbar = False
         Me._mainWizardControl.ResumeLayout(False)
         Me._propertiesTabPage.ResumeLayout(False)
         Me._optionsTabPage.ResumeLayout(False)
         Me._readTabPage.ResumeLayout(False)
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private _cancelButton As System.Windows.Forms.Button
      Private _mainWizardControl As WizardControl
      Private _propertiesTabPage As System.Windows.Forms.TabPage
      Private _getDocumentPropertiesControl As GetDocumentPropertiesControl
      Private _fileNameTextBox As System.Windows.Forms.TextBox
      Private _optionsTabPage As System.Windows.Forms.TabPage
      Private _loadDocumentOptionsControl As LoadDocumentOptionsControl
      Private WithEvents _okButton As System.Windows.Forms.Button
      Private _readTabPage As System.Windows.Forms.TabPage
      Private _readPDFDocumentControl As ReadPDFDocumentControl
   End Class
End Namespace
