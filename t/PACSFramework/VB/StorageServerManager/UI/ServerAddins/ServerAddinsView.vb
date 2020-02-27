' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Dicom.AddIn.Interfaces
Imports Leadtools.Demos.StorageServer.DataTypes

Namespace Leadtools.Demos.StorageServer.UI
   Partial Friend Class ServerAddinsView : Inherits UserControl
#Region "Public"

#Region "Methods"

      Public Sub New()
         InitializeComponent()
      End Sub

      Public Sub SetAddin(ByVal addIn As IAddInOptions)
         Dim label As Button = New Button()

         If Not Nothing Is addIn.Image Then
            label.Image = addIn.Image.ToImage()
         End If

         label.Text = addIn.Text
         label.Tag = addIn
         label.TextImageRelation = TextImageRelation.ImageBeforeText
         label.ImageAlign = ContentAlignment.MiddleLeft
         label.TextAlign = ContentAlignment.MiddleCenter
         label.Cursor = Cursors.Hand
         label.AutoSize = True
         label.Size = New Size(170, 60)
         label.Margin = New Padding(10)

         AddHandler label.Click, AddressOf label_Click

         AddinsTableLayoutPanel.Controls.Add(label)
      End Sub

      Public Sub ClearAddins()
         AddinsTableLayoutPanel.Controls.Clear()
      End Sub

      Public Sub DisplayStaticNote(ByVal text As String)
         NoteLabel.Text = text
         NoteLabel.Visible = True
      End Sub

      Public Sub HideStaticNote()
         NoteLabel.Visible = False
      End Sub

#End Region

#Region "Properties"

#End Region

#Region "Data Types Definition"

#End Region

#Region "Callbacks"

      Public Event AddInClicked As EventHandler(Of DataEventArgs(Of IAddInOptions))

#End Region

#End Region

#Region "Protected"

#Region "Methods"

#End Region

#Region "Properties"

#End Region

#Region "Data Types Definition"

#End Region

#End Region

#Region "Private"

#Region "Methods"

#End Region

#Region "Properties"

#End Region

#Region "Events"

      Private Sub label_Click(ByVal sender As Object, ByVal e As EventArgs)
         Try
            If Not Nothing Is AddInClickedEvent Then
               RaiseEvent AddInClicked(Me, New DataEventArgs(Of IAddInOptions)(CType((CType(sender, Control)).Tag, IAddInOptions)))
            End If
         Catch exception As Exception
            MessageBox.Show(exception.Message)
         End Try
      End Sub

#End Region

#Region "Data Members"

#End Region

#Region "Data Types Definition"

#End Region

#End Region

#Region "internal"

#Region "Methods"

#End Region

#Region "Properties"

#End Region

#Region "Data Types Definition"

#End Region

#Region "Callbacks"

#End Region

#End Region
   End Class
End Namespace
