' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Leadtools
Imports Leadtools.Document.Viewer
Imports System

Class ViewContextMenu
   Inherits ContextMenuStrip
   Public Sub New(documentViewer As DocumentViewer, selectAllTextAction As Action)
      _commandsBinder = New CommandsBinder(documentViewer)

      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandNames = New String() {DocumentViewerCommands.TextCopy, DocumentViewerCommands.AnnotationsCopy}, _
         .ToolStripItem = Me.Items.Add("Copy") _
      })

      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.AnnotationsPaste, _
         .ToolStripItem = Me.Items.Add("Paste"), _
         .GetValue = Function()
                        ' The paste position, in viewer coordinates
                        Dim position As Point = documentViewer.View.ImageViewer.PointToClient(_openingPosition)
                        Return LeadPoint.Create(position.X, position.Y)

                     End Function _
      })


      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.AnnotationsDelete, _
         .ToolStripItem = Me.Items.Add("Delete") _
      })

      Me.Items.Add(New ToolStripSeparator())

      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.TextSelectAll, _
         .ToolStripItem = Me.Items.Add("Select all", Nothing, New EventHandler(Sub() selectAllTextAction())), _
         .AutoRun = False _
      })

      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.AnnotationsSelectAll, _
         .ToolStripItem = Me.Items.Add("Select all annotations") _
      })

      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandNames = New String() {DocumentViewerCommands.TextClearSelection, DocumentViewerCommands.AnnotationsClearSelection}, _
         .ToolStripItem = Me.Items.Add("Clear selection") _
      })

      _commandsBinder.BindActions(True)
      _commandsBinder.Run()
   End Sub

   Private _openingPosition As Point

   Protected Overrides Sub OnOpening(e As CancelEventArgs)
      ' Save the current mouse position
      _openingPosition = Cursor.Position
      If Not _commandsBinder Is Nothing Then
         _commandsBinder.Run()
      End If
      MyBase.OnOpening(e)
   End Sub

   Private _commandsBinder As CommandsBinder

   Protected Overrides Sub Dispose(disposing As Boolean)
      If disposing Then
         If _commandsBinder IsNot Nothing Then
            _commandsBinder.BindActions(False)
            _commandsBinder.Items.Clear()
            _commandsBinder = Nothing
         End If
      End If

      MyBase.Dispose(disposing)
   End Sub
End Class
