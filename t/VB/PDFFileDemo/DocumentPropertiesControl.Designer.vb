Imports Microsoft.VisualBasic
Imports System
Namespace PDFFileDemo
   Public Partial Class DocumentPropertiesControl
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
		 Me._propertiesGroupBox = New System.Windows.Forms.GroupBox()
		 Me._modifiedTextBox = New System.Windows.Forms.TextBox()
		 Me._createdTextBox = New System.Windows.Forms.TextBox()
		 Me._modifiedDateTimePicker = New System.Windows.Forms.DateTimePicker()
		 Me._createdDateTimePicker = New System.Windows.Forms.DateTimePicker()
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
		 Me._propertiesGroupBox.Dock = System.Windows.Forms.DockStyle.Fill
		 Me._propertiesGroupBox.Location = New System.Drawing.Point(0, 0)
		 Me._propertiesGroupBox.Name = "_propertiesGroupBox"
		 Me._propertiesGroupBox.Size = New System.Drawing.Size(300, 246)
		 Me._propertiesGroupBox.TabIndex = 0
		 Me._propertiesGroupBox.TabStop = False
		 Me._propertiesGroupBox.Text = "Document properties:"
		 ' 
		 ' _modifiedTextBox
		 ' 
		 Me._modifiedTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
		 Me._modifiedTextBox.Location = New System.Drawing.Point(79, 209)
		 Me._modifiedTextBox.Name = "_modifiedTextBox"
		 Me._modifiedTextBox.Size = New System.Drawing.Size(206, 20)
		 Me._modifiedTextBox.TabIndex = 19
		 ' 
		 ' _createdTextBox
		 ' 
		 Me._createdTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
		 Me._createdTextBox.Location = New System.Drawing.Point(79, 183)
		 Me._createdTextBox.Name = "_createdTextBox"
		 Me._createdTextBox.Size = New System.Drawing.Size(206, 20)
		 Me._createdTextBox.TabIndex = 18
		 ' 
		 ' _modifiedDateTimePicker
		 ' 
		 Me._modifiedDateTimePicker.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
		 Me._modifiedDateTimePicker.CustomFormat = "MM/dd/yyyy - hh:mm:ss tt"
		 Me._modifiedDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
		 Me._modifiedDateTimePicker.Location = New System.Drawing.Point(79, 209)
		 Me._modifiedDateTimePicker.Name = "_modifiedDateTimePicker"
		 Me._modifiedDateTimePicker.Size = New System.Drawing.Size(206, 20)
		 Me._modifiedDateTimePicker.TabIndex = 17
		 ' 
		 ' _createdDateTimePicker
		 ' 
		 Me._createdDateTimePicker.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
		 Me._createdDateTimePicker.CustomFormat = "MM/dd/yyyy - hh:mm:ss tt"
		 Me._createdDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
		 Me._createdDateTimePicker.Location = New System.Drawing.Point(79, 183)
		 Me._createdDateTimePicker.Name = "_createdDateTimePicker"
		 Me._createdDateTimePicker.Size = New System.Drawing.Size(206, 20)
		 Me._createdDateTimePicker.TabIndex = 16
		 ' 
		 ' _modifiedLabel
		 ' 
		 Me._modifiedLabel.AutoSize = True
		 Me._modifiedLabel.Location = New System.Drawing.Point(21, 212)
		 Me._modifiedLabel.Name = "_modifiedLabel"
		 Me._modifiedLabel.Size = New System.Drawing.Size(50, 13)
		 Me._modifiedLabel.TabIndex = 14
		 Me._modifiedLabel.Text = "Modified:"
		 ' 
		 ' _createdLabel
		 ' 
		 Me._createdLabel.AutoSize = True
		 Me._createdLabel.Location = New System.Drawing.Point(24, 186)
		 Me._createdLabel.Name = "_createdLabel"
		 Me._createdLabel.Size = New System.Drawing.Size(47, 13)
		 Me._createdLabel.TabIndex = 12
		 Me._createdLabel.Text = "Created:"
		 ' 
		 ' _producerTextBox
		 ' 
		 Me._producerTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
		 Me._producerTextBox.Location = New System.Drawing.Point(79, 157)
		 Me._producerTextBox.Name = "_producerTextBox"
		 Me._producerTextBox.Size = New System.Drawing.Size(206, 20)
		 Me._producerTextBox.TabIndex = 11
		 ' 
		 ' _producerLabel
		 ' 
		 Me._producerLabel.AutoSize = True
		 Me._producerLabel.Location = New System.Drawing.Point(18, 160)
		 Me._producerLabel.Name = "_producerLabel"
		 Me._producerLabel.Size = New System.Drawing.Size(53, 13)
		 Me._producerLabel.TabIndex = 10
		 Me._producerLabel.Text = "Producer:"
		 ' 
		 ' _creatorTextBox
		 ' 
		 Me._creatorTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
		 Me._creatorTextBox.Location = New System.Drawing.Point(79, 131)
		 Me._creatorTextBox.Name = "_creatorTextBox"
		 Me._creatorTextBox.Size = New System.Drawing.Size(206, 20)
		 Me._creatorTextBox.TabIndex = 9
		 ' 
		 ' _creatorLabel
		 ' 
		 Me._creatorLabel.AutoSize = True
		 Me._creatorLabel.Location = New System.Drawing.Point(27, 134)
		 Me._creatorLabel.Name = "_creatorLabel"
		 Me._creatorLabel.Size = New System.Drawing.Size(44, 13)
		 Me._creatorLabel.TabIndex = 8
		 Me._creatorLabel.Text = "Creator:"
		 ' 
		 ' _keywordsTextBox
		 ' 
		 Me._keywordsTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
		 Me._keywordsTextBox.Location = New System.Drawing.Point(79, 105)
		 Me._keywordsTextBox.Name = "_keywordsTextBox"
		 Me._keywordsTextBox.Size = New System.Drawing.Size(206, 20)
		 Me._keywordsTextBox.TabIndex = 7
		 ' 
		 ' _keywordsLabel
		 ' 
		 Me._keywordsLabel.AutoSize = True
		 Me._keywordsLabel.Location = New System.Drawing.Point(15, 108)
		 Me._keywordsLabel.Name = "_keywordsLabel"
		 Me._keywordsLabel.Size = New System.Drawing.Size(56, 13)
		 Me._keywordsLabel.TabIndex = 6
		 Me._keywordsLabel.Text = "Keywords:"
		 ' 
		 ' _subjectTextBox
		 ' 
		 Me._subjectTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
		 Me._subjectTextBox.Location = New System.Drawing.Point(79, 79)
		 Me._subjectTextBox.Name = "_subjectTextBox"
		 Me._subjectTextBox.Size = New System.Drawing.Size(206, 20)
		 Me._subjectTextBox.TabIndex = 5
		 ' 
		 ' _subjectLabel
		 ' 
		 Me._subjectLabel.AutoSize = True
		 Me._subjectLabel.Location = New System.Drawing.Point(25, 82)
		 Me._subjectLabel.Name = "_subjectLabel"
		 Me._subjectLabel.Size = New System.Drawing.Size(46, 13)
		 Me._subjectLabel.TabIndex = 4
		 Me._subjectLabel.Text = "Subject:"
		 ' 
		 ' _authorTextBox
		 ' 
		 Me._authorTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
		 Me._authorTextBox.Location = New System.Drawing.Point(79, 53)
		 Me._authorTextBox.Name = "_authorTextBox"
		 Me._authorTextBox.Size = New System.Drawing.Size(206, 20)
		 Me._authorTextBox.TabIndex = 3
		 ' 
		 ' _authorLabel
		 ' 
		 Me._authorLabel.AutoSize = True
		 Me._authorLabel.Location = New System.Drawing.Point(30, 56)
		 Me._authorLabel.Name = "_authorLabel"
		 Me._authorLabel.Size = New System.Drawing.Size(41, 13)
		 Me._authorLabel.TabIndex = 2
		 Me._authorLabel.Text = "Author:"
		 ' 
		 ' _titleTextBox
		 ' 
		 Me._titleTextBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
		 Me._titleTextBox.Location = New System.Drawing.Point(79, 27)
		 Me._titleTextBox.Name = "_titleTextBox"
		 Me._titleTextBox.Size = New System.Drawing.Size(206, 20)
		 Me._titleTextBox.TabIndex = 1
		 ' 
		 ' _titleLabel
		 ' 
		 Me._titleLabel.AutoSize = True
		 Me._titleLabel.Location = New System.Drawing.Point(41, 30)
		 Me._titleLabel.Name = "_titleLabel"
		 Me._titleLabel.Size = New System.Drawing.Size(30, 13)
		 Me._titleLabel.TabIndex = 0
		 Me._titleLabel.Text = "Title:"
		 ' 
		 ' DocumentPropertiesControl
		 ' 
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.Controls.Add(Me._propertiesGroupBox)
		 Me.Name = "DocumentPropertiesControl"
		 Me.Size = New System.Drawing.Size(300, 246)
		 Me._propertiesGroupBox.ResumeLayout(False)
		 Me._propertiesGroupBox.PerformLayout()
		 Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private _propertiesGroupBox As System.Windows.Forms.GroupBox
	  Private _titleLabel As System.Windows.Forms.Label
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
	  Private _modifiedLabel As System.Windows.Forms.Label
	  Private _createdDateTimePicker As System.Windows.Forms.DateTimePicker
	  Private _modifiedDateTimePicker As System.Windows.Forms.DateTimePicker
	  Private _modifiedTextBox As System.Windows.Forms.TextBox
	  Private _createdTextBox As System.Windows.Forms.TextBox
   End Class
End Namespace
