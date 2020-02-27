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

Namespace HL7Messaging
   Partial Public Class AddMWLView
      Inherits Form
      Public Property ID() As String
         Get
            Return m_ID
         End Get
         Set(value As String)
            m_ID = value
         End Set
      End Property
      Private m_ID As String
      Public Property FirstName() As String
         Get
            Return m_FirstName
         End Get
         Set(value As String)
            m_FirstName = value
         End Set
      End Property
      Private m_FirstName As String
      Public Property MiddleName() As String
         Get
            Return m_MiddleName
         End Get
         Set(value As String)
            m_MiddleName = value
         End Set
      End Property
      Private m_MiddleName As String
      Public Property LastName() As String
         Get
            Return m_LastName
         End Get
         Set(value As String)
            m_LastName = value
         End Set
      End Property
      Private m_LastName As String

      Public Sub New()
         InitializeComponent()
      End Sub

      Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load

      End Sub

      Private Sub ShowRequiredFields()
         MessageBox.Show(Me, "Please supply the patient's id and one or more of the other fields", "Missing Required Fields", MessageBoxButtons.OK, MessageBoxIcon.[Error])
      End Sub

      Private Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click
         ID = textBox1.Text
         FirstName = textBox5.Text
         MiddleName = textBox2.Text
         LastName = textBox3.Text

         If String.IsNullOrEmpty(ID) OrElse (String.IsNullOrEmpty(FirstName) AndAlso String.IsNullOrEmpty(MiddleName) AndAlso String.IsNullOrEmpty(LastName)) Then
            ShowRequiredFields()
            Return
         End If

         Me.DialogResult = DialogResult.OK
         Me.Close()
      End Sub

      Private Sub button2_Click(sender As Object, e As EventArgs) Handles button2.Click
         Me.DialogResult = DialogResult.Cancel
         Me.Close()
      End Sub
   End Class
End Namespace
