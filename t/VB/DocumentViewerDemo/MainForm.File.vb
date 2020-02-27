' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.Demos
Imports Leadtools.Document
Imports Leadtools.Document.Viewer
Imports Leadtools.Controls
Imports Leadtools.Demos.Dialogs
Imports System

' Contains the file menu and toolbar part of the viewer
Partial Public Class MainForm
   Private Sub BindFileItems()
      ' Menu
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .ToolStripItem = _saveToolStripMenuItem, _
         .HasDocumentEmptyEnabled = False _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .ToolStripItem = _closeToolStripMenuItem _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .ToolStripItem = _saveToCacheToolStripMenuItem, .HasDocumentEmptyEnabled = False
      })
      _commandsBinder.Items.Add(New CommandBinderItem With {.ToolStripItem = _fileSep3ToolStripMenuItem})

      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .ToolStripItem = _exportTextToolStripMenuItem _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .ToolStripItem = _propertiesToolStripMenuItem _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .ToolStripItem = _fileSep4ToolStripMenuItem _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .ToolStripItem = _printToolStripMenuItem, _
         .HasDocumentEmptyEnabled = False _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .ToolStripItem = _printSetupToolStripMenuItem _
      })
   End Sub

   Private Sub _openDocumentFromFileToolStripMenuItem_Click(sender As Object, e As EventArgs)
      Using dlg As OpenDocumentFileDialog = New OpenDocumentFileDialog()
         dlg.DocumentFileName = _preferences.LastDocumentFileName
         dlg.FirstPageNumber = _preferences.LastDocumentFirstPageNumber
         dlg.LastPageNumber = _preferences.LastDocumentLastPageNumber
         dlg.AnnotationsFileName = _preferences.LastAnnotationsFileName
         dlg.LoadEmbeddedAnnotations = _preferences.LastFileLoadEmbeddedAnnotations
         If dlg.ShowDialog(Me) = DialogResult.OK Then
            LoadDocumentFromFile(dlg.DocumentFileName, dlg.FirstPageNumber, dlg.LastPageNumber, dlg.AnnotationsFileName, dlg.LoadEmbeddedAnnotations)
         End If
      End Using
   End Sub

   Private Sub _openDocumentFromUrltoolStripMenuItem_Click(sender As Object, e As EventArgs)
      Using dlg As OpenDocumentUrlDialog = New OpenDocumentUrlDialog()
         If String.IsNullOrEmpty(_preferences.LastDocumentUri) Then
            dlg.DocumentUrl = "http://demo.leadtools.com/images/pdf/leadtools.pdf"
            dlg.AnnotationsUrl = Nothing
         Else
            dlg.DocumentUrl = _preferences.LastDocumentUri
            dlg.AnnotationsUrl = _preferences.LastAnnotationsUri
         End If

         dlg.FirstPageNumber = _preferences.LastDocumentUriFirstPageNumber
         dlg.LastPageNumber = _preferences.LastDocumentUriLastPageNumber

         dlg.LoadEmbeddedAnnotations = _preferences.LastUriLoadEmbeddedAnnotations
         dlg.ShowDialog(Me)
      End Using
   End Sub

   Private Sub _saveToolStripMenuItem_Click(sender As Object, e As EventArgs)
      SaveDocument()
   End Sub

   Private Sub _closeToolStripMenuItem_Click(sender As Object, e As EventArgs)
      CloseDocument()
   End Sub

   Private Sub _exitToolStripMenuItem_Click(sender As Object, e As EventArgs)
      Close()
   End Sub

   Private Sub _openFromCacheToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      If _cache Is Nothing Then
         Helper.ShowInformation(Me, "This feature is only available when a Document Cache is used")
         Return
      End If

      Using dlg As InputDialog = New InputDialog()
         dlg.Text = "Document ID"
         dlg.ValueTitle = "Enter the ID of a document previously saved into the cache"

         ' If the document Is already in the cache, show its ID for easy re-loading
         Dim document As LEADDocument = _documentViewer.Document
         If document IsNot Nothing AndAlso DocumentFactory.GetDocumentCacheInfo(_cache, document.DocumentId) IsNot Nothing Then
            dlg.ValueDescription1 = "The current document ID is:"
            dlg.Value = document.DocumentId
         Else
            dlg.Value = String.Empty
         End If

         dlg.AllowEmptyValue = False
         If dlg.ShowDialog(Me) = DialogResult.OK Then
               LoadDocumentFromCache(dlg.Value)
            End If
      End Using
   End Sub

   Private Sub _saveToCacheToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      If _cache Is Nothing Then
         Helper.ShowInformation(Me, "This feature is only available when a Document Cache is used")
         Return
      End If

      SaveDocumentToCache()
   End Sub

   Private Sub _aboutToolStripMenuItem_Click(sender As Object, e As EventArgs)
      Using aboutDialog As New AboutDialog("Document Viewer", ProgrammingInterface.VB)
         aboutDialog.ShowDialog(Me)
      End Using
   End Sub

   Private Sub _openDocumentFromFileToolStripButton_Click(sender As Object, e As EventArgs)
      _openDocumentFromFileToolStripMenuItem.PerformClick()
   End Sub

   Private Sub _openDocumentFromUrlToolStripButton_Click(sender As Object, e As EventArgs)
      _openDocumentFromUrltoolStripMenuItem.PerformClick()
   End Sub

   Private Sub _propertiesToolStripMenuItem_Click(sender As Object, e As EventArgs)
      ShowDocumentProperties()
   End Sub

   Private Sub _exportTextToolStripMenuItem_Click(sender As Object, e As EventArgs)
      ' Check if we have any text or can get it automatically
      If Not CanPerformTextOperation("No text to export", True) Then
         Return
      End If

      Dim pageNumber As Integer = 1
      Dim pageCount As Integer = _documentViewer.PageCount

      If pageNumber > pageCount Then
         pageNumber = pageCount
      End If

      If pageCount > 1 Then
         Using dlg As PagesDialog = New PagesDialog()
            dlg.Operation = "Export Text"
            dlg.PageCount = _documentViewer.PageCount
            dlg.FirstPageNumber = _documentViewer.CurrentPageNumber
            dlg.SinglePageMode = True
            If dlg.ShowDialog(Me) <> DialogResult.OK Then
               Return
            End If

            ' Single page mode, either .FirstPageNumber == .LastPageNumber meaning all pages or get it from .FirstPageNumber
            If dlg.FirstPageNumber = 1 AndAlso dlg.LastPageNumber = _documentViewer.PageCount Then
               pageNumber = 0
            Else
               ' 0 means all pages
               pageNumber = dlg.FirstPageNumber
            End If
         End Using
      End If

      Dim isSlow As Boolean = _documentViewer.Commands.IsSlow(DocumentViewerCommands.TextExport, pageNumber)

      If isSlow Then
         Me.BeginBusyOperation()
      End If

      Dim thisOperation As DocumentViewerAsyncOperation(Of Object) = New DocumentViewerAsyncOperation(Of Object)() With {
               .Done = Sub(operation As DocumentViewerAsyncOperation(Of Object))
                          Me.BeginInvoke(CType(Sub()
                                                  Dim text As String = TryCast(operation.Result, String)
                                                  If text IsNot Nothing Then
                                                     Using dlg As ExportTextDialog = New ExportTextDialog(text)
                                                        dlg.ShowDialog(Me)
                                                     End Using
                                                  Else
                                                     Helper.ShowInformation(Me, "This document does not contain any text")
                                                  End If
                                               End Sub, MethodInvoker))
                       End Sub,
               .[Error] = Sub(operation As DocumentViewerAsyncOperation(Of Object), [error] As Exception)
                             Helper.ShowError(Me, [error])
                          End Sub,
               .Always = Sub(operation As DocumentViewerAsyncOperation(Of Object))
                            If isSlow Then
                               Me.EndBusyOperation()
                            End If
                         End Sub
            }

      _documentViewer.Commands.RunAsync(thisOperation, DocumentViewerCommands.TextExport, pageNumber)
   End Sub

   Private Sub _printSetupToolStripMenuItem_Click(sender As Object, e As EventArgs)
      PrintSetup()
   End Sub

   Private Sub _printToolStripMenuItem_Click(sender As Object, e As EventArgs)
      PrintDocument()
   End Sub
End Class
