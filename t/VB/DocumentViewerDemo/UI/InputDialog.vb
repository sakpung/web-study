' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System


Partial Public Class InputDialog
   Inherits Form
   Public Sub New()
      InitializeComponent()
   End Sub

   Public Property ValueTitle() As String
      Get
         Return m_ValueTitle
      End Get
      Set(value As String)
         m_ValueTitle = value
      End Set
   End Property
   Private m_ValueTitle As String
   Public Property ValueDescription1() As String
      Get
         Return m_ValueDescription1
      End Get
      Set(value As String)
         m_ValueDescription1 = value
      End Set
   End Property
   Private m_ValueDescription1 As String
   Public Property ValueDescription2() As String
      Get
         Return m_ValueDescription2
      End Get
      Set(value As String)
         m_ValueDescription2 = value
      End Set
   End Property
   Private m_ValueDescription2 As String
   Public Property Value() As String
      Get
         Return m_Value
      End Get
      Set(value As String)
         m_Value = value
      End Set
   End Property
   Private m_Value As String
   Public Property IsPassword() As Boolean
      Get
         Return m_IsPassword
      End Get
      Set(value As Boolean)
         m_IsPassword = value
      End Set
   End Property
   Private m_IsPassword As Boolean

   Private m_IsReadOnly As Boolean
   Public Property IsReadOnly As Boolean
      Get
         Return m_IsReadOnly
      End Get
      Set(value As Boolean)
         m_IsReadOnly = value
      End Set
   End Property
   Private m_IsAllowEmptyValue As Boolean
   Public Property AllowEmptyValue As Boolean
      Get
         Return m_IsAllowEmptyValue
      End Get
      Set(value As Boolean)
         m_IsAllowEmptyValue = value
      End Set
   End Property

   Public Property UseIntValues() As Boolean
      Get
         Return m_UseIntValues
      End Get
      Set(value As Boolean)
         m_UseIntValues = value
      End Set
   End Property
   Private m_UseIntValues As Boolean
   Public Property MinIntValue() As Integer
      Get
         Return m_MinIntValue
      End Get
      Set(value As Integer)
         m_MinIntValue = value
      End Set
   End Property
   Private m_MinIntValue As Integer
   Public Property MaxIntValue() As Integer
      Get
         Return m_MaxIntValue
      End Get
      Set(value As Integer)
         m_MaxIntValue = value
      End Set
   End Property
   Private m_MaxIntValue As Integer
   Public Property IntValue() As Integer
      Get
         Return m_IntValue
      End Get
      Set(value As Integer)
         m_IntValue = value
      End Set
   End Property
   Private m_IntValue As Integer

   Protected Overrides Sub OnLoad(e As EventArgs)
      AllowEmptyValue = True
      If Not DesignMode Then
         _valueGroupBox.Text = Me.ValueTitle

         If Not String.IsNullOrEmpty(Me.ValueDescription1) Then
            _valueLabel1.Text = Me.ValueDescription1
         Else
            _valueLabel1.Visible = False
         End If

         If Not String.IsNullOrEmpty(Me.ValueDescription2) Then
            _valueLabel2.Text = Me.ValueDescription2
         Else
            _valueLabel2.Visible = False
         End If

         _valueTextBox.UseSystemPasswordChar = Me.IsPassword

         If Me.UseIntValues Then
            _valueTextBox.Text = Me.IntValue.ToString()
            _valueTextBox.Width = CInt(_valueTextBox.Width / 4)
         Else
            _valueTextBox.Text = Me.Value
         End If
      End If

      If IsReadOnly Then
         _cancelButton.Visible = False
         _valueTextBox.ReadOnly = True
      End If

      MyBase.OnLoad(e)
   End Sub

   Private Sub _okButton_Click(sender As Object, e As EventArgs) Handles _okButton.Click
      If IsReadOnly Then
         Return
      End If

      If Me.UseIntValues Then
         ' Intgere value, make sure its valid and in range
         Dim value As Integer
         If Not Integer.TryParse(_valueTextBox.Text, value) OrElse value < Me.MinIntValue OrElse value > Me.MaxIntValue Then
            Helper.ShowError(Me, String.Format("Value must be between {0} and {1}", Me.MinIntValue, Me.MaxIntValue))
            DialogResult = DialogResult.None
            _valueTextBox.SelectAll()
            _valueTextBox.Focus()
            Return
         End If

         Me.IntValue = value
      End If

      Me.Value = _valueTextBox.Text
   End Sub
End Class
