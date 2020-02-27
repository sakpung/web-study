' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Windows.Forms

Imports Leadtools

Imports Leadtools.Document.Viewer
Imports System

' Contains the edit menu and toolbar part of the viewer
Partial Public Class MainForm
   Private Sub BindEditItems()
      ' Menu
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .ToolStripItem = _editToolStripMenuItem _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.AnnotationsUndo, _
         .ToolStripItem = _undoToolStripMenuItem _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.AnnotationsRedo, _
         .ToolStripItem = _redoToolStripMenuItem _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.AnnotationsCut, _
         .ToolStripItem = _cutToolStripMenuItem _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandNames = New String() {DocumentViewerCommands.TextCopy, DocumentViewerCommands.AnnotationsCopy}, _
         .ToolStripItem = _copyToolStripMenuItem _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.AnnotationsPaste, _
         .ToolStripItem = _pasteToolStripMenuItem _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.AnnotationsDelete, _
         .ToolStripItem = _deleteToolStripMenuItem _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.TextSelectAll, _
         .ToolStripItem = _selectAllToolStripMenuItem, _
         .AutoRun = False _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.AnnotationsSelectAll, _
         .ToolStripItem = _selectAllAnnotationsToolStripMenuItemtoolStripMenuItem _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandNames = New String() {DocumentViewerCommands.TextClearSelection, DocumentViewerCommands.AnnotationsClearSelection}, _
         .ToolStripItem = _clearSelectionToolStripMenuItem _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .ToolStripItem = _findToolStripMenuItem, _
         .HasDocumentEmptyEnabled = False _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.TextFindNext, _
         .ToolStripItem = _findNextToolStripMenuItem, _
         .AutoRun = False _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.TextFindPrevious, _
         .ToolStripItem = _findPreviousToolStripMenuItem, _
         .AutoRun = False _
      })
   End Sub

   Private Sub _selectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _selectAllToolStripMenuItem.Click
      DoSelectAllText()
   End Sub

   Private Sub DoSelectAllText()
      ' Check if we have any text or can get it automatically
      If Not CanPerformTextOperation("No text to select", True) Then
         Return
      End If

      'if (!_documentViewer.Text.HasDocumentPageText(0) && !
      'message = Helper.AddTextNote(message);

      Dim isSlow As Boolean = _documentViewer.Commands.IsSlow(DocumentViewerCommands.TextSelectAll, 0)

      If isSlow Then
         Me.BeginBusyOperation()
      End If

      Dim thisOperation As DocumentViewerAsyncOperation = New DocumentViewerAsyncOperation() With { _
         .[Error] = Sub(operation As DocumentViewerAsyncOperation, [error] As Exception)
                       Helper.ShowError(Me, [error])

                    End Sub, _
         .Always = Sub(operation As DocumentViewerAsyncOperation)
                      If isSlow Then
                         Me.EndBusyOperation()
                      End If

                   End Sub _
      }

      _documentViewer.Commands.RunAsync(thisOperation, DocumentViewerCommands.TextSelectAll, 0)
   End Sub

   Private Sub _findToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _findToolStripMenuItem.Click
      ' Check if we have any text or can get it automatically
      If Not CanPerformTextOperation("No text to find", True) Then
         Return
      End If

      Using dlg As FindTextDialog = New FindTextDialog(_documentViewer)
         dlg.ShowDialog(Me)
      End Using
   End Sub

   Private Sub _findNextToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _findNextToolStripMenuItem.Click
      FindNextPrevious(True)
   End Sub

   Private Sub _findPreviousToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _findPreviousToolStripMenuItem.Click
      FindNextPrevious(False)
   End Sub

   Private Sub FindNextPrevious(findNext As Boolean)
      Dim commandName As String = If(findNext, DocumentViewerCommands.TextFindNext, DocumentViewerCommands.TextFindPrevious)
      Dim isSlow As Boolean = _documentViewer.Commands.IsSlow(commandName, 0)

      If isSlow Then
         Me.BeginBusyOperation()
      End If

      Dim thisOperation As DocumentViewerAsyncOperation = New DocumentViewerAsyncOperation() With { _
        .[Error] = Sub(operation As DocumentViewerAsyncOperation, [error] As Exception)
                      Helper.ShowError(Me, [error])

                   End Sub, _
        .Always = Sub(operation As DocumentViewerAsyncOperation)
                     If isSlow Then
                        Me.EndBusyOperation()
                     End If

                  End Sub _
      }

      _documentViewer.Commands.RunAsync(thisOperation, commandName, Nothing)
   End Sub
End Class
