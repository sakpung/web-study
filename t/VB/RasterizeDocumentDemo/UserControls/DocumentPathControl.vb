' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.ComponentModel
Imports System.IO
Imports System.Text

Imports Leadtools
Imports Leadtools.Codecs

Public Class DocumentPathControl

   ' The LEADTOOLS RastreCodecs object instance used to load raster documents
   Private _documentPath As String

   <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
   Public Property DocumentPath() As String
      Get
         Return _documentPath
      End Get
      Set(ByVal value As String)
         _documentPath = value
      End Set
   End Property

   ''' <summary>
   ''' Called by the owner to initialize
   ''' </summary>
   Public Sub SetData()
      ' Set the state of the controls

      _documentPathTextBox.Text = _documentPath
   End Sub

   ''' <summary>
   ''' Called by the owner to get the data
   ''' </summary>
   Public Function GetData(ByVal rasterCodecsInstance As RasterCodecs) As Boolean
      Dim ret As Boolean = True

      Dim documentPath As String = _documentPathTextBox.Text.Trim()

      If ret Then
         If String.IsNullOrEmpty(documentPath) Then
            Messager.ShowWarning(Me, "Enter the path of the document to load or click the browse button")
            _documentPathTextBox.Focus()
            ret = False
         End If
      End If

      If ret Then
         If Not File.Exists(documentPath) Then
            Dim message As String = String.Format("File:{0}{0}'{1}'{0}{0}Does not exist.", Environment.NewLine, documentPath)
            Messager.ShowWarning(Me, message)
            _documentPathTextBox.Focus()
            ret = False
         End If
      End If

      _documentPath = documentPath

      Return ret
   End Function

   Private Sub _browseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _browseButton.Click
      Using dlg As New OpenFileDialog()
         Dim sb As New StringBuilder()

         Dim count As Integer = DocumentFormats.Formats.Length

         For i As Integer = 0 To count - 1
            Dim extensions() As String = DocumentFormats.FormatExtensions(i)

            Dim extension As New StringBuilder()
            extension.AppendFormat("*.{0}", extensions(0))
            For j As Integer = 1 To extensions.Length - 1
               extension.AppendFormat(";*.{0}", extensions(j))
            Next

            Dim friendlyName As String = DocumentFormats.FormatFriendlyNames(i)

            sb.AppendFormat("{0} ({1})|{1}|", friendlyName, extension.ToString())
         Next

         sb.Append("All Files|*.*")

         dlg.Filter = sb.ToString()

         If dlg.ShowDialog(Me) = DialogResult.OK Then
            _documentPathTextBox.Text = dlg.FileName
         End If
      End Using
   End Sub
End Class
