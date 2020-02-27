Namespace PDFDocumentDemo.LoadDocument
   Partial Class GetDocumentPropertiesControl
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GetDocumentPropertiesControl))
         Me._fileTypeLabel = New System.Windows.Forms.Label()
         Me._encryptionLabel = New System.Windows.Forms.Label()
         Me._createDocumentLabel = New System.Windows.Forms.Label()
         Me._fileTypeValueLabel = New System.Windows.Forms.Label()
         Me._encryptionValueLabel = New System.Windows.Forms.Label()
         Me._createDocumentValueLabel = New System.Windows.Forms.Label()
         Me.SuspendLayout()
         ' 
         ' _fileTypeLabel
         ' 
         resources.ApplyResources(Me._fileTypeLabel, "_fileTypeLabel")
         Me._fileTypeLabel.Name = "_fileTypeLabel"
         ' 
         ' _encryptionLabel
         ' 
         resources.ApplyResources(Me._encryptionLabel, "_encryptionLabel")
         Me._encryptionLabel.Name = "_encryptionLabel"
         ' 
         ' _createDocumentLabel
         ' 
         resources.ApplyResources(Me._createDocumentLabel, "_createDocumentLabel")
         Me._createDocumentLabel.Name = "_createDocumentLabel"
         ' 
         ' _fileTypeValueLabel
         ' 
         resources.ApplyResources(Me._fileTypeValueLabel, "_fileTypeValueLabel")
         Me._fileTypeValueLabel.Name = "_fileTypeValueLabel"
         ' 
         ' _encryptionValueLabel
         ' 
         resources.ApplyResources(Me._encryptionValueLabel, "_encryptionValueLabel")
         Me._encryptionValueLabel.Name = "_encryptionValueLabel"
         ' 
         ' _createDocumentValueLabel
         ' 
         resources.ApplyResources(Me._createDocumentValueLabel, "_createDocumentValueLabel")
         Me._createDocumentValueLabel.Name = "_createDocumentValueLabel"
         ' 
         ' GetDocumentPropertiesControl
         ' 
         resources.ApplyResources(Me, "$this")
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.Controls.Add(Me._createDocumentValueLabel)
         Me.Controls.Add(Me._encryptionValueLabel)
         Me.Controls.Add(Me._fileTypeValueLabel)
         Me.Controls.Add(Me._createDocumentLabel)
         Me.Controls.Add(Me._encryptionLabel)
         Me.Controls.Add(Me._fileTypeLabel)
         Me.Name = "GetDocumentPropertiesControl"
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private _fileTypeLabel As System.Windows.Forms.Label
      Private _encryptionLabel As System.Windows.Forms.Label
      Private _createDocumentLabel As System.Windows.Forms.Label
      Private _fileTypeValueLabel As System.Windows.Forms.Label
      Private _encryptionValueLabel As System.Windows.Forms.Label
      Private _createDocumentValueLabel As System.Windows.Forms.Label
   End Class
End Namespace
