Imports Microsoft.VisualBasic
Imports System
Namespace Ocr2SharePointDemo
   Public Partial Class MainForm
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
		 Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
		 Me._aboutButton = New System.Windows.Forms.Button()
		 Me._previousButton = New System.Windows.Forms.Button()
		 Me._nextButton = New System.Windows.Forms.Button()
		 Me._exitButton = New System.Windows.Forms.Button()
		 Me._operationPanel = New System.Windows.Forms.Panel()
		 Me._operationLabel = New System.Windows.Forms.Label()
		 Me._operationProgressBar = New System.Windows.Forms.ProgressBar()
		 Me._mainWizardControl = New Ocr2SharePointDemo.WizardControl()
		 Me._serverPropertiesTabPage = New System.Windows.Forms.TabPage()
		 Me._sharePointServerSettingsControl = New Ocr2SharePointDemo.SharePointServerSettingsControl()
		 Me._sharePointBrowserTabPage = New System.Windows.Forms.TabPage()
		 Me._sharePointBrowserControl = New Ocr2SharePointDemo.SharePointBrowserControl()
		 Me._selectImageDocumentFileTabPage = New System.Windows.Forms.TabPage()
		 Me._selectImageDocumentFileControl = New Ocr2SharePointDemo.SelectImageDocumentControl()
		 Me._recognizeAndUploadTabPage = New System.Windows.Forms.TabPage()
		 Me._recognizeAndUploadControl = New Ocr2SharePointDemo.RecognizeAndUploadControl()
		 Me._operationPanel.SuspendLayout()
		 Me._mainWizardControl.SuspendLayout()
		 Me._serverPropertiesTabPage.SuspendLayout()
		 Me._sharePointBrowserTabPage.SuspendLayout()
		 Me._selectImageDocumentFileTabPage.SuspendLayout()
		 Me._recognizeAndUploadTabPage.SuspendLayout()
		 Me.SuspendLayout()
		 ' 
		 ' _aboutButton
		 ' 
		 Me._aboutButton.Location = New System.Drawing.Point(13, 441)
		 Me._aboutButton.Name = "_aboutButton"
		 Me._aboutButton.Size = New System.Drawing.Size(75, 23)
		 Me._aboutButton.TabIndex = 1
		 Me._aboutButton.Text = "&About..."
		 Me._aboutButton.UseVisualStyleBackColor = True
'		 Me._aboutButton.Click += New System.EventHandler(Me._aboutButton_Click);
		 ' 
		 ' _previousButton
		 ' 
		 Me._previousButton.Location = New System.Drawing.Point(518, 441)
		 Me._previousButton.Name = "_previousButton"
		 Me._previousButton.Size = New System.Drawing.Size(75, 23)
		 Me._previousButton.TabIndex = 2
		 Me._previousButton.Text = "&Previous"
		 Me._previousButton.UseVisualStyleBackColor = True
'		 Me._previousButton.Click += New System.EventHandler(Me._previousButton_Click);
		 ' 
		 ' _nextButton
		 ' 
		 Me._nextButton.Location = New System.Drawing.Point(599, 441)
		 Me._nextButton.Name = "_nextButton"
		 Me._nextButton.Size = New System.Drawing.Size(75, 23)
		 Me._nextButton.TabIndex = 3
		 Me._nextButton.Text = "&Next"
		 Me._nextButton.UseVisualStyleBackColor = True
'		 Me._nextButton.Click += New System.EventHandler(Me._nextButton_Click);
		 ' 
		 ' _exitButton
		 ' 
		 Me._exitButton.Location = New System.Drawing.Point(692, 441)
		 Me._exitButton.Name = "_exitButton"
		 Me._exitButton.Size = New System.Drawing.Size(75, 23)
		 Me._exitButton.TabIndex = 4
		 Me._exitButton.Text = "E&xit"
		 Me._exitButton.UseVisualStyleBackColor = True
'		 Me._exitButton.Click += New System.EventHandler(Me._exitButton_Click);
		 ' 
		 ' _operationPanel
		 ' 
		 Me._operationPanel.Controls.Add(Me._operationLabel)
		 Me._operationPanel.Controls.Add(Me._operationProgressBar)
		 Me._operationPanel.Location = New System.Drawing.Point(13, 364)
		 Me._operationPanel.Name = "_operationPanel"
		 Me._operationPanel.Size = New System.Drawing.Size(758, 71)
		 Me._operationPanel.TabIndex = 5
		 ' 
		 ' _operationLabel
		 ' 
		 Me._operationLabel.Location = New System.Drawing.Point(4, 7)
		 Me._operationLabel.Name = "_operationLabel"
		 Me._operationLabel.Size = New System.Drawing.Size(748, 23)
		 Me._operationLabel.TabIndex = 1
		 Me._operationLabel.Text = "_operationLabel"
		 Me._operationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		 ' 
		 ' _operationProgressBar
		 ' 
		 Me._operationProgressBar.Location = New System.Drawing.Point(212, 33)
		 Me._operationProgressBar.Name = "_operationProgressBar"
		 Me._operationProgressBar.Size = New System.Drawing.Size(335, 23)
		 Me._operationProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee
		 Me._operationProgressBar.TabIndex = 0
		 ' 
		 ' _mainWizardControl
		 ' 
		 Me._mainWizardControl.Controls.Add(Me._serverPropertiesTabPage)
		 Me._mainWizardControl.Controls.Add(Me._sharePointBrowserTabPage)
		 Me._mainWizardControl.Controls.Add(Me._selectImageDocumentFileTabPage)
		 Me._mainWizardControl.Controls.Add(Me._recognizeAndUploadTabPage)
		 Me._mainWizardControl.Location = New System.Drawing.Point(13, 13)
		 Me._mainWizardControl.Name = "_mainWizardControl"
		 Me._mainWizardControl.SelectedIndex = 0
		 Me._mainWizardControl.Size = New System.Drawing.Size(758, 345)
		 Me._mainWizardControl.TabIndex = 0
		 ' 
		 ' _serverPropertiesTabPage
		 ' 
		 Me._serverPropertiesTabPage.Controls.Add(Me._sharePointServerSettingsControl)
		 Me._serverPropertiesTabPage.Location = New System.Drawing.Point(4, 22)
		 Me._serverPropertiesTabPage.Name = "_serverPropertiesTabPage"
		 Me._serverPropertiesTabPage.Size = New System.Drawing.Size(750, 319)
		 Me._serverPropertiesTabPage.TabIndex = 0
		 Me._serverPropertiesTabPage.Text = "ServerProperties"
		 Me._serverPropertiesTabPage.UseVisualStyleBackColor = True
		 ' 
		 ' _sharePointServerSettingsControl
		 ' 
		 Me._sharePointServerSettingsControl.Location = New System.Drawing.Point(0, 0)
		 Me._sharePointServerSettingsControl.Name = "_sharePointServerSettingsControl"
		 Me._sharePointServerSettingsControl.Size = New System.Drawing.Size(740, 330)
		 Me._sharePointServerSettingsControl.TabIndex = 0
		 ' 
		 ' _sharePointBrowserTabPage
		 ' 
		 Me._sharePointBrowserTabPage.Controls.Add(Me._sharePointBrowserControl)
		 Me._sharePointBrowserTabPage.Location = New System.Drawing.Point(4, 22)
		 Me._sharePointBrowserTabPage.Name = "_sharePointBrowserTabPage"
		 Me._sharePointBrowserTabPage.Size = New System.Drawing.Size(750, 319)
		 Me._sharePointBrowserTabPage.TabIndex = 2
		 Me._sharePointBrowserTabPage.Text = "SharePointBrowser"
		 Me._sharePointBrowserTabPage.UseVisualStyleBackColor = True
		 ' 
		 ' _sharePointBrowserControl
		 ' 
		 Me._sharePointBrowserControl.Location = New System.Drawing.Point(0, 0)
		 Me._sharePointBrowserControl.Name = "_sharePointBrowserControl"
		 Me._sharePointBrowserControl.Size = New System.Drawing.Size(740, 330)
		 Me._sharePointBrowserControl.TabIndex = 0
		 ' 
		 ' _selectImageDocumentFileTabPage
		 ' 
		 Me._selectImageDocumentFileTabPage.Controls.Add(Me._selectImageDocumentFileControl)
		 Me._selectImageDocumentFileTabPage.Location = New System.Drawing.Point(4, 22)
		 Me._selectImageDocumentFileTabPage.Name = "_selectImageDocumentFileTabPage"
		 Me._selectImageDocumentFileTabPage.Size = New System.Drawing.Size(750, 319)
		 Me._selectImageDocumentFileTabPage.TabIndex = 1
		 Me._selectImageDocumentFileTabPage.Text = "ImageDocumentFile"
		 Me._selectImageDocumentFileTabPage.UseVisualStyleBackColor = True
		 ' 
		 ' _selectImageDocumentFileControl
		 ' 
		 Me._selectImageDocumentFileControl.Location = New System.Drawing.Point(0, 0)
		 Me._selectImageDocumentFileControl.Name = "_selectImageDocumentFileControl"
		 Me._selectImageDocumentFileControl.Size = New System.Drawing.Size(740, 330)
		 Me._selectImageDocumentFileControl.TabIndex = 0
		 ' 
		 ' _recognizeAndUploadTabPage
		 ' 
		 Me._recognizeAndUploadTabPage.Controls.Add(Me._recognizeAndUploadControl)
		 Me._recognizeAndUploadTabPage.Location = New System.Drawing.Point(4, 22)
		 Me._recognizeAndUploadTabPage.Name = "_recognizeAndUploadTabPage"
		 Me._recognizeAndUploadTabPage.Size = New System.Drawing.Size(750, 319)
		 Me._recognizeAndUploadTabPage.TabIndex = 4
		 Me._recognizeAndUploadTabPage.Text = "RecognizeAndUpload"
		 Me._recognizeAndUploadTabPage.UseVisualStyleBackColor = True
		 ' 
		 ' _recognizeAndUploadControl
		 ' 
		 Me._recognizeAndUploadControl.Location = New System.Drawing.Point(0, 0)
		 Me._recognizeAndUploadControl.Name = "_recognizeAndUploadControl"
		 Me._recognizeAndUploadControl.Size = New System.Drawing.Size(740, 330)
		 Me._recognizeAndUploadControl.TabIndex = 0
		 ' 
		 ' MainForm
		 ' 
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.ClientSize = New System.Drawing.Size(777, 474)
		 Me.Controls.Add(Me._operationPanel)
		 Me.Controls.Add(Me._previousButton)
		 Me.Controls.Add(Me._nextButton)
		 Me.Controls.Add(Me._exitButton)
		 Me.Controls.Add(Me._aboutButton)
		 Me.Controls.Add(Me._mainWizardControl)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		 Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
		 Me.MaximizeBox = False
		 Me.Name = "MainForm"
		 Me.Text = "MainForm"
		 Me._operationPanel.ResumeLayout(False)
		 Me._mainWizardControl.ResumeLayout(False)
		 Me._serverPropertiesTabPage.ResumeLayout(False)
		 Me._sharePointBrowserTabPage.ResumeLayout(False)
		 Me._selectImageDocumentFileTabPage.ResumeLayout(False)
		 Me._recognizeAndUploadTabPage.ResumeLayout(False)
		 Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private _mainWizardControl As WizardControl
	  Private WithEvents _aboutButton As System.Windows.Forms.Button
	  Private WithEvents _previousButton As System.Windows.Forms.Button
	  Private WithEvents _nextButton As System.Windows.Forms.Button
	  Private WithEvents _exitButton As System.Windows.Forms.Button
	  Private _serverPropertiesTabPage As System.Windows.Forms.TabPage
	  Private _sharePointServerSettingsControl As SharePointServerSettingsControl
	  Private _operationPanel As System.Windows.Forms.Panel
	  Private _operationLabel As System.Windows.Forms.Label
	  Private _operationProgressBar As System.Windows.Forms.ProgressBar
	  Private _selectImageDocumentFileTabPage As System.Windows.Forms.TabPage
	  Private _selectImageDocumentFileControl As SelectImageDocumentControl
	  Private _sharePointBrowserTabPage As System.Windows.Forms.TabPage
	  Private _sharePointBrowserControl As SharePointBrowserControl
	  Private _recognizeAndUploadTabPage As System.Windows.Forms.TabPage
	  Private _recognizeAndUploadControl As RecognizeAndUploadControl
   End Class
End Namespace