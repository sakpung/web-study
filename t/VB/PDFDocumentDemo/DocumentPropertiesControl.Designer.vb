Namespace PDFDocumentDemo
   Partial Class DocumentPropertiesControl
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DocumentPropertiesControl))
         Me._modifiedTextBox = New System.Windows.Forms.TextBox()
         Me._createdTextBox = New System.Windows.Forms.TextBox()
         Me._modifiedDateTimePicker = New System.Windows.Forms.DateTimePicker()
         Me._createdDateTimePicker = New System.Windows.Forms.DateTimePicker()
         Me._propertiesGroupBox = New System.Windows.Forms.GroupBox()
         Me._modifiedLabel = New System.Windows.Forms.Label()
         Me._createdLabel = New System.Windows.Forms.Label()
         Me._producerTextBox = New System.Windows.Forms.TextBox()
         Me._producerLabel = New System.Windows.Forms.Label()
         Me._creatorTextBox = New System.Windows.Forms.TextBox()
         Me._creatorLabel = New System.Windows.Forms.Label()
         Me._keywordsTextBox = New System.Windows.Forms.TextBox()
         Me._keywordsLabel = New System.Windows.Forms.Label()
         Me._subjectTextBox = New System.Windows.Forms.TextBox()
         Me._subjectLabel = New System.Windows.Forms.Label()
         Me._authorTextBox = New System.Windows.Forms.TextBox()
         Me._authorLabel = New System.Windows.Forms.Label()
         Me._titleTextBox = New System.Windows.Forms.TextBox()
         Me._titleLabel = New System.Windows.Forms.Label()
         Me._propertiesGroupBox.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _modifiedTextBox
         ' 
         resources.ApplyResources(Me._modifiedTextBox, "_modifiedTextBox")
         Me._modifiedTextBox.Name = "_modifiedTextBox"
         ' 
         ' _createdTextBox
         ' 
         resources.ApplyResources(Me._createdTextBox, "_createdTextBox")
         Me._createdTextBox.Name = "_createdTextBox"
         ' 
         ' _modifiedDateTimePicker
         ' 
         resources.ApplyResources(Me._modifiedDateTimePicker, "_modifiedDateTimePicker")
         Me._modifiedDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
         Me._modifiedDateTimePicker.Name = "_modifiedDateTimePicker"
         ' 
         ' _createdDateTimePicker
         ' 
         resources.ApplyResources(Me._createdDateTimePicker, "_createdDateTimePicker")
         Me._createdDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
         Me._createdDateTimePicker.Name = "_createdDateTimePicker"
         ' 
         ' _propertiesGroupBox
         ' 
         Me._propertiesGroupBox.Controls.Add(Me._modifiedTextBox)
         Me._propertiesGroupBox.Controls.Add(Me._createdTextBox)
         Me._propertiesGroupBox.Controls.Add(Me._modifiedDateTimePicker)
         Me._propertiesGroupBox.Controls.Add(Me._createdDateTimePicker)
         Me._propertiesGroupBox.Controls.Add(Me._modifiedLabel)
         Me._propertiesGroupBox.Controls.Add(Me._createdLabel)
         Me._propertiesGroupBox.Controls.Add(Me._producerTextBox)
         Me._propertiesGroupBox.Controls.Add(Me._producerLabel)
         Me._propertiesGroupBox.Controls.Add(Me._creatorTextBox)
         Me._propertiesGroupBox.Controls.Add(Me._creatorLabel)
         Me._propertiesGroupBox.Controls.Add(Me._keywordsTextBox)
         Me._propertiesGroupBox.Controls.Add(Me._keywordsLabel)
         Me._propertiesGroupBox.Controls.Add(Me._subjectTextBox)
         Me._propertiesGroupBox.Controls.Add(Me._subjectLabel)
         Me._propertiesGroupBox.Controls.Add(Me._authorTextBox)
         Me._propertiesGroupBox.Controls.Add(Me._authorLabel)
         Me._propertiesGroupBox.Controls.Add(Me._titleTextBox)
         Me._propertiesGroupBox.Controls.Add(Me._titleLabel)
         resources.ApplyResources(Me._propertiesGroupBox, "_propertiesGroupBox")
         Me._propertiesGroupBox.Name = "_propertiesGroupBox"
         Me._propertiesGroupBox.TabStop = False
         ' 
         ' _modifiedLabel
         ' 
         resources.ApplyResources(Me._modifiedLabel, "_modifiedLabel")
         Me._modifiedLabel.Name = "_modifiedLabel"
         ' 
         ' _createdLabel
         ' 
         resources.ApplyResources(Me._createdLabel, "_createdLabel")
         Me._createdLabel.Name = "_createdLabel"
         ' 
         ' _producerTextBox
         ' 
         resources.ApplyResources(Me._producerTextBox, "_producerTextBox")
         Me._producerTextBox.Name = "_producerTextBox"
         ' 
         ' _producerLabel
         ' 
         resources.ApplyResources(Me._producerLabel, "_producerLabel")
         Me._producerLabel.Name = "_producerLabel"
         ' 
         ' _creatorTextBox
         ' 
         resources.ApplyResources(Me._creatorTextBox, "_creatorTextBox")
         Me._creatorTextBox.Name = "_creatorTextBox"
         ' 
         ' _creatorLabel
         ' 
         resources.ApplyResources(Me._creatorLabel, "_creatorLabel")
         Me._creatorLabel.Name = "_creatorLabel"
         ' 
         ' _keywordsTextBox
         ' 
         resources.ApplyResources(Me._keywordsTextBox, "_keywordsTextBox")
         Me._keywordsTextBox.Name = "_keywordsTextBox"
         ' 
         ' _keywordsLabel
         ' 
         resources.ApplyResources(Me._keywordsLabel, "_keywordsLabel")
         Me._keywordsLabel.Name = "_keywordsLabel"
         ' 
         ' _subjectTextBox
         ' 
         resources.ApplyResources(Me._subjectTextBox, "_subjectTextBox")
         Me._subjectTextBox.Name = "_subjectTextBox"
         ' 
         ' _subjectLabel
         ' 
         resources.ApplyResources(Me._subjectLabel, "_subjectLabel")
         Me._subjectLabel.Name = "_subjectLabel"
         ' 
         ' _authorTextBox
         ' 
         resources.ApplyResources(Me._authorTextBox, "_authorTextBox")
         Me._authorTextBox.Name = "_authorTextBox"
         ' 
         ' _authorLabel
         ' 
         resources.ApplyResources(Me._authorLabel, "_authorLabel")
         Me._authorLabel.Name = "_authorLabel"
         ' 
         ' _titleTextBox
         ' 
         resources.ApplyResources(Me._titleTextBox, "_titleTextBox")
         Me._titleTextBox.Name = "_titleTextBox"
         ' 
         ' _titleLabel
         ' 
         resources.ApplyResources(Me._titleLabel, "_titleLabel")
         Me._titleLabel.Name = "_titleLabel"
         ' 
         ' DocumentPropertiesControl
         ' 
         resources.ApplyResources(Me, "$this")
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.Controls.Add(Me._propertiesGroupBox)
         Me.Name = "DocumentPropertiesControl"
         Me._propertiesGroupBox.ResumeLayout(False)
         Me._propertiesGroupBox.PerformLayout()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private _modifiedTextBox As System.Windows.Forms.TextBox
      Private _createdTextBox As System.Windows.Forms.TextBox
      Private _modifiedDateTimePicker As System.Windows.Forms.DateTimePicker
      Private _createdDateTimePicker As System.Windows.Forms.DateTimePicker
      Private _propertiesGroupBox As System.Windows.Forms.GroupBox
      Private _modifiedLabel As System.Windows.Forms.Label
      Private _createdLabel As System.Windows.Forms.Label
      Private _producerTextBox As System.Windows.Forms.TextBox
      Private _producerLabel As System.Windows.Forms.Label
      Private _creatorTextBox As System.Windows.Forms.TextBox
      Private _creatorLabel As System.Windows.Forms.Label
      Private _keywordsTextBox As System.Windows.Forms.TextBox
      Private _keywordsLabel As System.Windows.Forms.Label
      Private _subjectTextBox As System.Windows.Forms.TextBox
      Private _subjectLabel As System.Windows.Forms.Label
      Private _authorTextBox As System.Windows.Forms.TextBox
      Private _authorLabel As System.Windows.Forms.Label
      Private _titleTextBox As System.Windows.Forms.TextBox
      Private _titleLabel As System.Windows.Forms.Label
   End Class
End Namespace
