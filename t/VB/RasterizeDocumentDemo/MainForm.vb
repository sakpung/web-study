' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.Demos.Dialogs

Public Class MainForm
   ' The RasterCodecs object used to load images
   Private _rasterCodecsInstance As RasterCodecs
   ' Last document information
   Private _imageInfo As CodecsImageInfo

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      If Not DesignMode Then
         Using g As Graphics = CreateGraphics()
            Units.ScreenResolution = CType(g.DpiX, Integer)
         End Using

         ' Setup the caption for this demo
         Messager.Caption = "VB Rasterize Document Demo"
         Text = Messager.Caption

         _rasterCodecsInstance = New RasterCodecs()

         Dim pdfEngineOk As Boolean

         ' Check if LEADTOOLS PDF PlugIn is installed
         pdfEngineOk = _rasterCodecsInstance.Options.Pdf.IsEngineInstalled

         If pdfEngineOk Then
            ' Setup and initialize the option controls
            For Each tp As TabPage In _optionsTabControl.TabPages
               Dim optionsUserControl As IOptionsUserControl = CType(tp.Controls(0), IOptionsUserControl)
               optionsUserControl.SetData(_rasterCodecsInstance)
            Next
            _documentInfoControl.SetData(_imageInfo, _rasterCodecsInstance)
         Else
            Close()
         End If
      End If

      MyBase.OnLoad(e)
   End Sub

   Protected Overrides Sub OnFormClosed(ByVal e As System.Windows.Forms.FormClosedEventArgs)
      If Not DesignMode Then
         If Not IsNothing(_imageInfo) Then
            _imageInfo.Dispose()
         End If

         _rasterCodecsInstance.Dispose()
      End If

      MyBase.OnFormClosed(e)
   End Sub

   Private Sub _fileExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _fileExitToolStripMenuItem.Click
      Close()
   End Sub

   Private Sub _helpAboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _helpAboutToolStripMenuItem.Click
      Using aboutDialog As New AboutDialog("Rasterize Document", ProgrammingInterface.VB)
         aboutDialog.ShowDialog(Me)
      End Using
   End Sub

   Private Sub _getDocumentInformationButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _getDocumentInformationButton.Click
      GetDocumentInformation()
   End Sub

   Private Sub _loadDocumentInViewerButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _loadDocumentInViewerButton.Click
      LoadDocumentInViewer()
   End Sub

   Private Function CollectAllOptions() As Boolean
      ' Collects all the options from the controls, return true/false if we can continue

      Dim ret As Boolean = True
      For Each tp As TabPage In _optionsTabControl.TabPages
         Dim optionsUserControl As IOptionsUserControl = CType(tp.Controls(0), IOptionsUserControl)
         ret = optionsUserControl.GetData(_rasterCodecsInstance)
         If Not ret Then
            _optionsTabControl.SelectedTab = tp
            Exit For
         End If
      Next

      If ret Then
         ret = _documentPathControl.GetData(_rasterCodecsInstance)
      End If

      Return ret
   End Function

   Private Function GetDocumentInformation() As Boolean
      ' Get all the options
      If Not CollectAllOptions() Then
         Return False
      End If

      ' Get the new image information

      Dim documentPath As String = _documentPathControl.DocumentPath

      Try
         Dim newImageInfo As CodecsImageInfo = Nothing

         Using wait As New WaitCursor()
            newImageInfo = _rasterCodecsInstance.GetInformation(documentPath, True)
         End Using

         ' Use this information
         If Not IsNothing(_imageInfo) Then
            _imageInfo.Dispose()
         End If

         _imageInfo = newImageInfo
         _documentInfoControl.SetData(_imageInfo, _rasterCodecsInstance)

         Return True
      Catch ex As Exception
         Messager.ShowError(Me, ex)
         Return False
      End Try
   End Function

   Private Sub LoadDocumentInViewer()
      ' Get information first
      If Not GetDocumentInformation() Then
         Return
      End If

      ' Check if we have more than one page to load
      Dim totalPages As Integer = _imageInfo.TotalPages
      Dim firstPageNumber As Integer = 1
      Dim lastPageNumber As Integer = 1

      Dim loadDocument As Boolean = True

      If totalPages > 1 Then
         ' Yes, prompt the user for the pages to load
         Using dlg As New LoadPagesDialog()
            dlg.TotalPages = totalPages
            dlg.FirstPageNumber = firstPageNumber
            dlg.LastPageNumber = lastPageNumber

            If dlg.ShowDialog(Me) = DialogResult.OK Then
               firstPageNumber = dlg.FirstPageNumber
               lastPageNumber = dlg.LastPageNumber
               loadDocument = True
            Else
               loadDocument = False
            End If
         End Using
      End If

      If loadDocument Then
         ' Load the document
         Dim documentPath As String = _documentPathControl.DocumentPath

         ViewDocument(documentPath, firstPageNumber, lastPageNumber)
      End If
   End Sub

   Private Sub ViewDocument(ByVal documentPath As String, ByVal firstPageNumber As Integer, ByVal lastPageNumber As Integer)
      Dim image As RasterImage = Nothing

      Try
         Using wait As New WaitCursor()
            image = _rasterCodecsInstance.Load(documentPath, 0, CodecsLoadByteOrder.BgrOrGray, firstPageNumber, lastPageNumber)
         End Using
      Catch ex As Exception
         Messager.ShowError(Me, ex)
         Return
      End Try

      Dim viewer As New ViewerForm()

      Try
         viewer.Initialize(documentPath, _imageInfo.TotalPages, _rasterCodecsInstance)
         viewer.Show()
      Catch ex As Exception
         Messager.ShowError(Me, ex)
         viewer.Dispose()
      End Try
   End Sub
End Class
