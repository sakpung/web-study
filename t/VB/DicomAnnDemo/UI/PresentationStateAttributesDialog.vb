' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Namespace DicomAnnDemo
   Partial Public Class PresentationStateAttributesDialog : Inherits Form
      Private components As System.ComponentModel.IContainer = Nothing
      Private WithEvents _btnOK As System.Windows.Forms.Button
      Private _btnCancel As System.Windows.Forms.Button
      Private _lblCreationDate As System.Windows.Forms.Label
      Private _tbCreationDate As System.Windows.Forms.TextBox
      Private _lblCreationTime As System.Windows.Forms.Label
      Private _tbCreationTime As System.Windows.Forms.TextBox
      Private _lblInstanceNumber As System.Windows.Forms.Label
      Private WithEvents _tbInstanceNumber As System.Windows.Forms.TextBox
      Private _lblPresentationCreator As System.Windows.Forms.Label
      Private _tbPresentationCreator As System.Windows.Forms.TextBox
      Private _lblPresentationDescription As System.Windows.Forms.Label
      Private _tbPresentationDescription As System.Windows.Forms.TextBox
      Private _lblPresentationLabel As System.Windows.Forms.Label
      Private _tbPresentationLabel As System.Windows.Forms.TextBox

      Private _presentation As PresentationStateAttributes
      Private _presentationOriginal As PresentationStateAttributes

      Public Property Presentation() As PresentationStateAttributes
         Get
            Return _presentation
         End Get
         Set(ByVal value As PresentationStateAttributes)
            _presentation = Value
         End Set
      End Property

      Public Sub New()
         InitializeComponent()
         _presentation = New PresentationStateAttributes()
      End Sub

      ''' <summary>
      ''' Clean up any resources being used.
      ''' </summary>
      ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
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
         Me._btnOK = New System.Windows.Forms.Button()
         Me._btnCancel = New System.Windows.Forms.Button()
         Me._lblCreationDate = New System.Windows.Forms.Label()
         Me._tbCreationDate = New System.Windows.Forms.TextBox()
         Me._lblCreationTime = New System.Windows.Forms.Label()
         Me._tbCreationTime = New System.Windows.Forms.TextBox()
         Me._lblInstanceNumber = New System.Windows.Forms.Label()
         Me._tbInstanceNumber = New System.Windows.Forms.TextBox()
         Me._lblPresentationCreator = New System.Windows.Forms.Label()
         Me._tbPresentationCreator = New System.Windows.Forms.TextBox()
         Me._lblPresentationDescription = New System.Windows.Forms.Label()
         Me._tbPresentationDescription = New System.Windows.Forms.TextBox()
         Me._lblPresentationLabel = New System.Windows.Forms.Label()
         Me._tbPresentationLabel = New System.Windows.Forms.TextBox()
         Me.SuspendLayout()
         ' 
         ' _btnOK
         ' 
         Me._btnOK.Location = New System.Drawing.Point(125, 228)
         Me._btnOK.Name = "_btnOK"
         Me._btnOK.Size = New System.Drawing.Size(75, 23)
         Me._btnOK.TabIndex = 0
         Me._btnOK.Text = "OK"
         Me._btnOK.UseVisualStyleBackColor = True
         '		 Me._btnOK.Click += New System.EventHandler(Me._btnOK_Click);
         ' 
         ' _btnCancel
         ' 
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnCancel.Location = New System.Drawing.Point(253, 228)
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.Size = New System.Drawing.Size(75, 23)
         Me._btnCancel.TabIndex = 1
         Me._btnCancel.Text = "Cancel"
         Me._btnCancel.UseVisualStyleBackColor = True
         ' 
         ' _lblCreationDate
         ' 
         Me._lblCreationDate.AutoSize = True
         Me._lblCreationDate.Location = New System.Drawing.Point(24, 19)
         Me._lblCreationDate.Name = "_lblCreationDate"
         Me._lblCreationDate.Size = New System.Drawing.Size(75, 13)
         Me._lblCreationDate.TabIndex = 2
         Me._lblCreationDate.Text = "Creation Date:"
         ' 
         ' _tbCreationDate
         ' 
         Me._tbCreationDate.Location = New System.Drawing.Point(155, 16)
         Me._tbCreationDate.Name = "_tbCreationDate"
         Me._tbCreationDate.ReadOnly = True
         Me._tbCreationDate.Size = New System.Drawing.Size(214, 20)
         Me._tbCreationDate.TabIndex = 3
         ' 
         ' _lblCreationTime
         ' 
         Me._lblCreationTime.AutoSize = True
         Me._lblCreationTime.Location = New System.Drawing.Point(24, 52)
         Me._lblCreationTime.Name = "_lblCreationTime"
         Me._lblCreationTime.Size = New System.Drawing.Size(72, 13)
         Me._lblCreationTime.TabIndex = 4
         Me._lblCreationTime.Text = "CreationTime:"
         ' 
         ' _tbCreationTime
         ' 
         Me._tbCreationTime.Location = New System.Drawing.Point(155, 49)
         Me._tbCreationTime.Name = "_tbCreationTime"
         Me._tbCreationTime.ReadOnly = True
         Me._tbCreationTime.Size = New System.Drawing.Size(214, 20)
         Me._tbCreationTime.TabIndex = 5
         ' 
         ' _lblInstanceNumber
         ' 
         Me._lblInstanceNumber.AutoSize = True
         Me._lblInstanceNumber.Location = New System.Drawing.Point(24, 86)
         Me._lblInstanceNumber.Name = "_lblInstanceNumber"
         Me._lblInstanceNumber.Size = New System.Drawing.Size(91, 13)
         Me._lblInstanceNumber.TabIndex = 6
         Me._lblInstanceNumber.Text = "Instance Number:"
         ' 
         ' _tbInstanceNumber
         ' 
         Me._tbInstanceNumber.Location = New System.Drawing.Point(155, 83)
         Me._tbInstanceNumber.MaxLength = 10
         Me._tbInstanceNumber.Name = "_tbInstanceNumber"
         Me._tbInstanceNumber.Size = New System.Drawing.Size(214, 20)
         Me._tbInstanceNumber.TabIndex = 7
         '		 Me._tbInstanceNumber.KeyPress += New System.Windows.Forms.KeyPressEventHandler(Me._tbInstanceNumber_KeyPress);
         ' 
         ' _lblPresentationCreator
         ' 
         Me._lblPresentationCreator.AutoSize = True
         Me._lblPresentationCreator.Location = New System.Drawing.Point(24, 120)
         Me._lblPresentationCreator.Name = "_lblPresentationCreator"
         Me._lblPresentationCreator.Size = New System.Drawing.Size(106, 13)
         Me._lblPresentationCreator.TabIndex = 8
         Me._lblPresentationCreator.Text = "Presentation Creator:"
         ' 
         ' _tbPresentationCreator
         ' 
         Me._tbPresentationCreator.Location = New System.Drawing.Point(155, 117)
         Me._tbPresentationCreator.Name = "_tbPresentationCreator"
         Me._tbPresentationCreator.Size = New System.Drawing.Size(214, 20)
         Me._tbPresentationCreator.TabIndex = 9
         ' 
         ' _lblPresentationDescription
         ' 
         Me._lblPresentationDescription.AutoSize = True
         Me._lblPresentationDescription.Location = New System.Drawing.Point(24, 150)
         Me._lblPresentationDescription.Name = "_lblPresentationDescription"
         Me._lblPresentationDescription.Size = New System.Drawing.Size(125, 13)
         Me._lblPresentationDescription.TabIndex = 10
         Me._lblPresentationDescription.Text = "Presentation Description:"
         ' 
         ' _tbPresentationDescription
         ' 
         Me._tbPresentationDescription.Location = New System.Drawing.Point(155, 147)
         Me._tbPresentationDescription.Name = "_tbPresentationDescription"
         Me._tbPresentationDescription.Size = New System.Drawing.Size(214, 20)
         Me._tbPresentationDescription.TabIndex = 11
         ' 
         ' _lblPresentationLabel
         ' 
         Me._lblPresentationLabel.AutoSize = True
         Me._lblPresentationLabel.Location = New System.Drawing.Point(24, 180)
         Me._lblPresentationLabel.Name = "_lblPresentationLabel"
         Me._lblPresentationLabel.Size = New System.Drawing.Size(98, 13)
         Me._lblPresentationLabel.TabIndex = 12
         Me._lblPresentationLabel.Text = "Presentation Label:"
         ' 
         ' _tbPresentationLabel
         ' 
         Me._tbPresentationLabel.Location = New System.Drawing.Point(155, 177)
         Me._tbPresentationLabel.Name = "_tbPresentationLabel"
         Me._tbPresentationLabel.Size = New System.Drawing.Size(214, 20)
         Me._tbPresentationLabel.TabIndex = 13
         ' 
         ' PresentationStateAttributesDialog
         ' 
         Me.AcceptButton = Me._btnOK
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me._btnCancel
         Me.ClientSize = New System.Drawing.Size(397, 275)
         Me.Controls.Add(Me._tbPresentationLabel)
         Me.Controls.Add(Me._lblPresentationLabel)
         Me.Controls.Add(Me._tbPresentationDescription)
         Me.Controls.Add(Me._lblPresentationDescription)
         Me.Controls.Add(Me._tbPresentationCreator)
         Me.Controls.Add(Me._lblPresentationCreator)
         Me.Controls.Add(Me._tbInstanceNumber)
         Me.Controls.Add(Me._lblInstanceNumber)
         Me.Controls.Add(Me._tbCreationTime)
         Me.Controls.Add(Me._lblCreationTime)
         Me.Controls.Add(Me._tbCreationDate)
         Me.Controls.Add(Me._lblCreationDate)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._btnOK)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
         Me.Name = "PresentationStateAttributesDialog"
         Me.ShowInTaskbar = False
         Me.Text = "Presentation State Module Attributes"
         '		 Me.Load += New System.EventHandler(Me.PresentationStateAttributesDialog_Load);
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private Sub _btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOK.Click
         If CheckIfInstanceValueValid() Then
            Me.DialogResult = DialogResult.OK
            FillPresentationStateAttributes()
         End If
      End Sub

      Private Function VerifyCodeString(ByVal value As String) As Boolean
         Dim len As Integer = value.Length
         For i As Integer = 0 To len - 1
            Dim valid As Boolean = ((value.Chars(i) >= "A"c AndAlso value.Chars(i) <= "Z"c) OrElse (value.Chars(i) >= "0"c AndAlso value.Chars(i) <= "9"c) OrElse (value.Chars(i) = " "c) OrElse (value.Chars(i) = "_"c))
            If (Not valid) Then
               Return False
            End If
         Next i
         Return True
      End Function

      Private Function CheckIfInstanceValueValid() As Boolean
         If (Me._tbInstanceNumber.Text.Length < 0) Then
            Return False
         End If

         Dim instanceNumber As Long = Convert.ToInt64(Me._tbInstanceNumber.Text)
         'Check if Valid
         If instanceNumber < 0 OrElse instanceNumber > 2147483647 Then
            Messager.ShowError(Me, "Enter an integer between 1 and 2147483647")
            Return False
         End If

         Dim label As String = _tbPresentationLabel.Text
         If (Not VerifyCodeString(label)) Then
            Messager.ShowError(Me, "Presentation Label can only contain:" & Environment.NewLine & "Uppercase characters: 'A'-'Z'" & Environment.NewLine & "Digits: '0'-'9'" & Environment.NewLine & "Blanks (space character)" & Environment.NewLine & "Underscores '_'")
            _tbPresentationLabel.SelectAll()
            _tbPresentationLabel.Focus()
            Return False
         End If

         'Valid
         Return True
      End Function

      Private Sub PresentationStateAttributesDialog_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
         _presentationOriginal = New PresentationStateAttributes()
         _presentationOriginal.CopyFrom(_presentation)
         FillPresentationStateAttributesControls()
      End Sub

      Private Sub FillPresentationStateAttributes()
         _presentation.CreationDate = Convert.ToDateTime(Me._tbCreationDate.Text)
         _presentation.CreationTime = Convert.ToDateTime(Me._tbCreationTime.Text)
         _presentation.InstanceNumber = Convert.ToInt32(Me._tbInstanceNumber.Text)
         _presentation.PresentationCreator = Me._tbPresentationCreator.Text
         _presentation.PresentationDescription = Me._tbPresentationDescription.Text
         _presentation.PresentationLabel = Me._tbPresentationLabel.Text
      End Sub

      Private Sub FillPresentationStateAttributesControls()
         Me._tbCreationDate.Text = _presentation.CreationDate.ToShortDateString()
         Me._tbCreationTime.Text = _presentation.CreationTime.ToShortTimeString()
         Me._tbInstanceNumber.Text = _presentation.InstanceNumber.ToString()
         Me._tbPresentationCreator.Text = _presentation.PresentationCreator.ToString()
         Me._tbPresentationDescription.Text = _presentation.PresentationDescription.ToString()
         Me._tbPresentationLabel.Text = _presentation.PresentationLabel.ToString()
      End Sub

      Private Sub _tbInstanceNumber_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles _tbInstanceNumber.KeyPress
         'Accept only Numbers & Backspace
         e.Handled = Not (Char.IsNumber(e.KeyChar) Or Char.ConvertToUtf32(e.KeyChar, 0) = Keys.Back)
      End Sub
   End Class

   Public Class PresentationStateAttributes
      Private _instanceNumber As Integer
      Private _presentationLabel As String
      Private _presentationDescription As String
      Private _presentationCreator As String
      Private _creationDate As DateTime
      Private _creationTime As DateTime

      Public Property InstanceNumber() As Integer
         Get
            Return _instanceNumber
         End Get
         Set(ByVal value As Integer)
            _instanceNumber = Value
         End Set
      End Property

      Public Property PresentationLabel() As String
         Get
            Return _presentationLabel
         End Get
         Set(ByVal value As String)
            _presentationLabel = Value
         End Set
      End Property

      Public Property PresentationDescription() As String
         Get
            Return _presentationDescription
         End Get
         Set(ByVal value As String)
            _presentationDescription = Value
         End Set
      End Property

      Public Property PresentationCreator() As String
         Get
            Return _presentationCreator
         End Get
         Set(ByVal value As String)
            _presentationCreator = Value
         End Set
      End Property

      Public ReadOnly Property CreationDateString() As String
         Get
            Return _creationDate.ToShortDateString()
         End Get
      End Property


      Public ReadOnly Property CreationTimeString() As String
         Get
            Return _creationTime.ToShortTimeString()
         End Get
      End Property


      Friend Property CreationDate() As DateTime
         Get
            Return _creationDate
         End Get
         Set(ByVal value As DateTime)
            _creationDate = Value
         End Set
      End Property

      Friend Property CreationTime() As DateTime
         Get
            Return _creationTime
         End Get
         Set(ByVal value As DateTime)
            _creationTime = Value
         End Set
      End Property

      Public Sub New()
         _instanceNumber = 0
         _presentationLabel = String.Empty
         _presentationDescription = String.Empty
         _presentationCreator = String.Empty
         _creationDate = DateTime.Now
         _creationTime = DateTime.Now
      End Sub

      Public Sub CopyFrom(ByVal src As PresentationStateAttributes)
         If Not src Is Nothing Then
            _instanceNumber = src.InstanceNumber
            _presentationLabel = src.PresentationLabel
            _presentationDescription = src.PresentationDescription
            _presentationCreator = src.PresentationCreator
            _creationDate = src.CreationDate
            _creationTime = src.CreationTime
         End If
      End Sub
   End Class
End Namespace
