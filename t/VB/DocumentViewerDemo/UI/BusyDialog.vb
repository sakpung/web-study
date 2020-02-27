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

' General busy dialog
Partial Public Class BusyDialog
   Inherits Form
   Public Sub New()
      InitializeComponent()
   End Sub

   Public Property EnableCancellation() As Boolean
      Get
         Return m_EnableCancellation
      End Get
      Set(value As Boolean)
         m_EnableCancellation = value
      End Set
   End Property
   Private m_EnableCancellation As Boolean
   Public Property IsCancelled() As Boolean
      Get
         Return m_IsCancelled
      End Get
      Set(value As Boolean)
         m_IsCancelled = value
      End Set
   End Property
   Private m_IsCancelled As Boolean

   Protected Overrides Sub OnLoad(e As EventArgs)
      If Not DesignMode Then
         _isWorking = True

         Me.IsCancelled = False
         _cancellingLabel.Visible = False
         Me._cancelButton.Enabled = Me.EnableCancellation
         Me._cancelButton.Visible = Me.EnableCancellation
      End If

      MyBase.OnLoad(e)
   End Sub

   Public Sub UpdateDescription(description As String)
      If Me.InvokeRequired Then
         BeginInvoke(CType(Sub()
                                   _descriptionLabel.Text = description
                                   Application.DoEvents()

                                End Sub, Action))

         Return
      End If

      _descriptionLabel.Text = description
      Application.DoEvents()
   End Sub

   Private _isWorking As Boolean

   Public Property IsWorking() As Boolean
      Get
         Return _isWorking
      End Get
      Set(value As Boolean)
         _isWorking = value
         If Not _isWorking Then
            ' Close us
            DialogResult = DialogResult.OK
            Close()
         End If
      End Set
   End Property

   Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
      e.Cancel = _isWorking
      MyBase.OnFormClosing(e)
   End Sub

   Private Sub _cancelButton_Click(sender As Object, e As EventArgs) Handles _cancelButton.Click
      If Me.EnableCancellation AndAlso Not Me.IsCancelled Then
         Me.IsCancelled = True
         _cancelButton.Enabled = False
         _cancellingLabel.Visible = True
         Application.DoEvents()
      End If

      DialogResult = DialogResult.None
   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.[Return] OrElse keyData = Keys.Enter Then
         Return True
      End If

      Return MyBase.ProcessCmdKey(msg, keyData)
   End Function
End Class
