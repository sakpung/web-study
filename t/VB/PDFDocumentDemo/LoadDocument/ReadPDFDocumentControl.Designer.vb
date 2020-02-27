Namespace PDFDocumentDemo.LoadDocument
   Partial Class ReadPDFDocumentControl
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

#Region "Component Designer generated code"

      ''' <summary> 
      ''' Required method for Designer support - do not modify 
      ''' the contents of this method with the code editor.
      ''' </summary>
      Private Sub InitializeComponent()
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReadPDFDocumentControl))
         Me._readObjectsValueLabel = New System.Windows.Forms.Label()
         Me._readDocumentStructureValueLabel = New System.Windows.Forms.Label()
         Me._readObjectsLabel = New System.Windows.Forms.Label()
         Me._readDocumentStructureLabel = New System.Windows.Forms.Label()
         Me._readObjectsProgressBar = New System.Windows.Forms.ProgressBar()
         Me._errorsGroupBox = New System.Windows.Forms.GroupBox()
         Me._errorsLabel = New System.Windows.Forms.Label()
         Me._copyToClipboardButton = New System.Windows.Forms.Button()
         Me._errorsListBox = New System.Windows.Forms.ListBox()
         Me._stopButton = New System.Windows.Forms.Button()
         Me._errorsGroupBox.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _readObjectsValueLabel
         ' 
         resources.ApplyResources(Me._readObjectsValueLabel, "_readObjectsValueLabel")
         Me._readObjectsValueLabel.Name = "_readObjectsValueLabel"
         ' 
         ' _readDocumentStructureValueLabel
         ' 
         resources.ApplyResources(Me._readDocumentStructureValueLabel, "_readDocumentStructureValueLabel")
         Me._readDocumentStructureValueLabel.Name = "_readDocumentStructureValueLabel"
         ' 
         ' _readObjectsLabel
         ' 
         resources.ApplyResources(Me._readObjectsLabel, "_readObjectsLabel")
         Me._readObjectsLabel.Name = "_readObjectsLabel"
         ' 
         ' _readDocumentStructureLabel
         ' 
         resources.ApplyResources(Me._readDocumentStructureLabel, "_readDocumentStructureLabel")
         Me._readDocumentStructureLabel.Name = "_readDocumentStructureLabel"
         ' 
         ' _readObjectsProgressBar
         ' 
         resources.ApplyResources(Me._readObjectsProgressBar, "_readObjectsProgressBar")
         Me._readObjectsProgressBar.Name = "_readObjectsProgressBar"
         ' 
         ' _errorsGroupBox
         ' 
         Me._errorsGroupBox.Controls.Add(Me._errorsLabel)
         Me._errorsGroupBox.Controls.Add(Me._copyToClipboardButton)
         Me._errorsGroupBox.Controls.Add(Me._errorsListBox)
         resources.ApplyResources(Me._errorsGroupBox, "_errorsGroupBox")
         Me._errorsGroupBox.Name = "_errorsGroupBox"
         Me._errorsGroupBox.TabStop = False
         ' 
         ' _errorsLabel
         ' 
         resources.ApplyResources(Me._errorsLabel, "_errorsLabel")
         Me._errorsLabel.Name = "_errorsLabel"
         ' 
         ' _copyToClipboardButton
         ' 
         resources.ApplyResources(Me._copyToClipboardButton, "_copyToClipboardButton")
         Me._copyToClipboardButton.Name = "_copyToClipboardButton"
         Me._copyToClipboardButton.UseVisualStyleBackColor = True
         ' 
         ' _errorsListBox
         ' 
         Me._errorsListBox.FormattingEnabled = True
         resources.ApplyResources(Me._errorsListBox, "_errorsListBox")
         Me._errorsListBox.Name = "_errorsListBox"
         ' 
         ' _stopButton
         ' 
         resources.ApplyResources(Me._stopButton, "_stopButton")
         Me._stopButton.Name = "_stopButton"
         Me._stopButton.UseVisualStyleBackColor = True
         ' 
         ' ReadPDFDocumentControl
         ' 
         resources.ApplyResources(Me, "$this")
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.Controls.Add(Me._stopButton)
         Me.Controls.Add(Me._errorsGroupBox)
         Me.Controls.Add(Me._readObjectsProgressBar)
         Me.Controls.Add(Me._readObjectsValueLabel)
         Me.Controls.Add(Me._readDocumentStructureValueLabel)
         Me.Controls.Add(Me._readObjectsLabel)
         Me.Controls.Add(Me._readDocumentStructureLabel)
         Me.Name = "ReadPDFDocumentControl"
         Me._errorsGroupBox.ResumeLayout(False)
         Me._errorsGroupBox.PerformLayout()
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private _readObjectsValueLabel As System.Windows.Forms.Label
      Private _readDocumentStructureValueLabel As System.Windows.Forms.Label
      Private _readObjectsLabel As System.Windows.Forms.Label
      Private _readDocumentStructureLabel As System.Windows.Forms.Label
      Private _readObjectsProgressBar As System.Windows.Forms.ProgressBar
      Private _errorsGroupBox As System.Windows.Forms.GroupBox
      Private WithEvents _copyToClipboardButton As System.Windows.Forms.Button
      Private _errorsListBox As System.Windows.Forms.ListBox
      Private _errorsLabel As System.Windows.Forms.Label
      Private WithEvents _stopButton As System.Windows.Forms.Button
   End Class
End Namespace
