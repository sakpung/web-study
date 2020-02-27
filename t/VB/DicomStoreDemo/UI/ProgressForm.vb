' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Threading

Namespace DicomDemo
   ''' <summary>
   ''' Summary description for ProgressForm.
   ''' </summary>
   Public Class ProgressForm : Inherits System.Windows.Forms.Form
      Private CancelBtn As System.Windows.Forms.Button
      ''' <summary>
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.Container = Nothing

      Public Sub New()
         Thread.CurrentThread.SetApartmentState(ApartmentState.STA)
         '
         ' Required for Windows Form Designer support
         '
         InitializeComponent()

         '
         ' TODO: Add any constructor code after InitializeComponent call
         '
      End Sub

      ''' <summary>
      ''' Clean up any resources being used.
      ''' </summary>
      Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
         If disposing Then
            If Not components Is Nothing Then
               components.Dispose()
            End If
         End If
         MyBase.Dispose(disposing)
      End Sub

#Region "Windows Form Designer generated code"
      ''' <summary>
      ''' Required method for Designer support - do not modify
      ''' the contents of this method with the code editor.
      ''' </summary>
      Private Sub InitializeComponent()
         Me.CancelBtn = New System.Windows.Forms.Button()
         Me.SuspendLayout()
         ' 
         ' CancelBtn
         ' 
         Me.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me.CancelBtn.Location = New System.Drawing.Point(143, 72)
         Me.CancelBtn.Name = "CancelBtn"
         Me.CancelBtn.TabIndex = 1
         Me.CancelBtn.Text = "Cancel"
         ' 
         ' ProgressForm
         ' 
         Me.AcceptButton = Me.CancelBtn
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
         Me.CancelButton = Me.CancelBtn
         Me.ClientSize = New System.Drawing.Size(360, 109)
         Me.Controls.Add(Me.CancelBtn)
         Me.Name = "ProgressForm"
         Me.ShowInTaskbar = False
         Me.Text = "Storing Images"
         '         Me.Load += New System.EventHandler(Me.ProgressForm_Load);
         '         Me.Activated += New System.EventHandler(Me.ProgressForm_Activated);
         Me.ResumeLayout(False)

      End Sub
#End Region

      Private Sub ProgressForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
      End Sub

      Private Sub ProgressForm_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
      End Sub
   End Class
End Namespace
