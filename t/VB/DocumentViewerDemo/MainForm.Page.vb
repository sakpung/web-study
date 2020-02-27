' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Windows.Forms
Imports System.ComponentModel

Imports Leadtools
Imports Leadtools.Document.Viewer
Imports Leadtools.Controls
Imports Leadtools.Document
Imports System.Collections.Generic

' Contains the page menu and toolbar part of the viewer
Partial Public Class MainForm
   Private Sub BindPageItems()
      ' Menu
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
        .ToolStripItem = _pageToolStripMenuItem _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
        .CommandName = DocumentViewerCommands.PageFirst, _
        .ToolStripItem = _firstPageToolStripMenuItem _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
        .CommandName = DocumentViewerCommands.PagePrevious, _
        .ToolStripItem = _previousPageToolStripMenuItem _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
        .CommandName = DocumentViewerCommands.PageNext, _
        .ToolStripItem = _nextPageToolStripMenuItem _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
        .CommandName = DocumentViewerCommands.PageLast, _
        .ToolStripItem = _lastPageToolStripMenuItem _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.PageGoto, _
         .ToolStripItem = _gotoPageToolStripMenuItem, _
         .AutoRun = False _
      })

      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.TextGet, _
         .ToolStripItem = _getCurrentPageTextToolStripMenuItem, _
         .AutoRun = False, _
         .GetValue = Function()
                        Return _documentViewer.CurrentPageNumber
                     End Function _
      })

      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.TextGet, _
         .ToolStripItem = _getAllPagesTextToolStripMenuItem, _
         .AutoRun = False, _
         .GetValue = Function()
                        Return 0
                     End Function _
      })

      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.PageRotateClockwise, _
         .ToolStripItem = _rotatePageClockwiseToolStripMenuItem, _
         .AutoRun = True, _
         .GetValue = Function()
                        Return New Integer() {_documentViewer.CurrentPageNumber}
                     End Function _
      })

      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.PageRotateCounterClockwise, _
         .ToolStripItem = _rotatePageCounterClockwiseToolStripMenuItem, _
         .AutoRun = True, _
         .GetValue = Function()
                        Return New Integer() {_documentViewer.CurrentPageNumber}
                     End Function _
      })

      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.PageDisable, _
         .ToolStripItem = _enableDisablePageToolStripMenuItem, _
         .AutoRun = False, _
         .GetValue = Function()
                        Return _documentViewer.CurrentPageNumber
                     End Function
      })

      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.LayoutSingle, _
         .ToolStripItem = _singlePageToolStripMenuItem, _
         .UpdateChecked = True _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.LayoutVertical, _
         .ToolStripItem = _verticalPageToolStripMenuItem, _
         .UpdateChecked = True _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.LayoutDouble, _
         .ToolStripItem = _doublePageToolStripMenuItem, _
         .UpdateChecked = True _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.LayoutHorizontal, _
         .ToolStripItem = _horizontalPageToolStripMenuItem, _
         .UpdateChecked = True _
      })

      ' Toolbar
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .ToolStripItem = _mainToolStripSeparator1 _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.PagePrevious, _
         .ToolStripItem = _previousPageToolStripButton _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.PageNext, _
         .ToolStripItem = _nextPageToolStripButton _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .ToolStripItem = _pageNumberToolStripTextBox _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .ToolStripItem = _pageNumberToolStripLabel _
      })

      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .ToolStripItem = _mainToolStripSeparator3 _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.LayoutSingle, _
         .ToolStripItem = _singlePageToolStripButton, _
         .UpdateChecked = True _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.LayoutVertical, _
         .ToolStripItem = _verticalPageToolStripButton, _
         .UpdateChecked = True _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.LayoutDouble, _
         .ToolStripItem = _doublePageToolStripButton, _
         .UpdateChecked = True _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.LayoutHorizontal, _
         .ToolStripItem = _horizontalPageToolStripButton, _
         .UpdateChecked = True _
      })

      BindPageNumber()
   End Sub

   Private Sub BindPageNumber()
      _commandsBinder.PostRuns.Add(Sub()
                                      If Not _documentViewer.HasDocument Then
                                         Return
                                      End If

                                      Dim pageNumber As Integer = _documentViewer.CurrentPageNumber
                                      Dim pageCount As Integer = _documentViewer.PageCount

                                      _pageNumberToolStripTextBox.Text = pageNumber.ToString()
                                      _pageNumberToolStripLabel.Text = "/ " & pageCount.ToString()

                                   End Sub)

      AddHandler _pageNumberToolStripTextBox.LostFocus, Sub(sender, e)
                                                           If Not _documentViewer.HasDocument Then
                                                              Return
                                                           End If

                                                           Dim pageNumber As Integer = _documentViewer.CurrentPageNumber
                                                           _pageNumberToolStripTextBox.Text = pageNumber.ToString()

                                                        End Sub

      AddHandler _pageNumberToolStripTextBox.KeyPress, Sub(sender, e)
                                                          If e.KeyChar <> CChar(Microsoft.VisualBasic.ChrW(Keys.Return)) Then
                                                             Return
                                                          End If

                                                          ' User has pressed enter, go to the new page number
                                                          Dim text As String = _pageNumberToolStripTextBox.Text.Trim()

                                                          ' Try to parse the integer value
                                                          Dim newPageNumber As Integer
                                                          If Not Integer.TryParse(text, newPageNumber) Then
                                                             Return
                                                          End If

                                                          Dim pageNumber As Integer = _documentViewer.CurrentPageNumber
                                                          Dim pageCount As Integer = _documentViewer.PageCount

                                                          If newPageNumber <> pageNumber AndAlso newPageNumber >= 1 AndAlso newPageNumber <= pageCount Then
                                                             Try
                                                                _documentViewer.Commands.Run(DocumentViewerCommands.PageGoto, newPageNumber)
                                                             Catch ex As Exception
                                                                Helper.ShowError(Me, ex)
                                                             End Try
                                                          End If
                                                       End Sub
   End Sub

   Private Sub _gotoPageToolStripMenuItem_Click(sender As Object, e As EventArgs)
      Using dlg As InputDialog = New InputDialog()
         dlg.Text = "Go To Page"
         dlg.ValueTitle = Nothing
         Dim pageCount As Integer = _documentViewer.PageCount
         dlg.ValueDescription1 = String.Format("This document has {0} pages. Select the page number to go to", pageCount)
         dlg.UseIntValues = True
         dlg.MinIntValue = 1
         dlg.MaxIntValue = pageCount
         dlg.IntValue = _documentViewer.View.ImageViewer.GetLargestVisibleItemIndex(ImageViewerItemPart.Item) + 1
         If dlg.ShowDialog(Me) = DialogResult.OK Then
            Try
               _documentViewer.Commands.Run(DocumentViewerCommands.PageGoto, dlg.IntValue)
            Catch ex As Exception
               Helper.ShowError(Me, ex)
            End Try
         End If
      End Using
   End Sub

   Private Sub _getCurrentPageTextToolStripMenuItem_Click(sender As Object, e As EventArgs)
      GetPagesText(_documentViewer.CurrentPageNumber)
   End Sub

   Private Sub _getAllPagesTextToolStripMenuItem_Click(sender As Object, e As EventArgs)
      GetPagesText(0)
   End Sub

   Private Sub _thumbnailsContextMenuStrip_Opening(sender As Object, e As CancelEventArgs)
      ' Get current page from the position
      If Not _documentViewer.HasDocument Then
         e.Cancel = True
         Return
      End If

      Dim thumbnails As DocumentViewerThumbnails = _documentViewer.Thumbnails
      If thumbnails Is Nothing Then
         e.Cancel = True
         Return
      End If

      Dim pageNumber As Integer = -1
      Dim imageViewer As ImageViewer = thumbnails.ImageViewer
      Dim position As LeadPoint = LeadPoint.Create(imageViewer.PointToClient(Windows.Forms.Cursor.Position).X, imageViewer.PointToClient(Windows.Forms.Cursor.Position).Y)
      Dim item As ImageViewerItem = imageViewer.HitTestItem(LeadPoint.Create(position.X, position.Y))
      Dim canRunText As Boolean = False
      If item IsNot Nothing Then
         pageNumber = imageViewer.Items.IndexOf(item) + 1
         canRunText = _documentViewer.Commands.CanRun(DocumentViewerCommands.TextGet, pageNumber)
      End If

      If pageNumber <> -1 Then
         If canRunText Then
            _thumbnailsGetThisPageTextToolStripMenuItem.Tag = CType(pageNumber, Object)
         Else
            _thumbnailsGetThisPageTextToolStripMenuItem.Tag = Nothing
         End If

         _thumbnailsGetThisPageTextToolStripMenuItem.Enabled = canRunText
         _thumbnailsRotateClockwiseToolStripMenuItem.Tag = pageNumber
         _thumbnailsRotateClockwiseToolStripMenuItem.Enabled = True
         _thumbnailsRotateCounterClockwiseToolStripMenuItem.Tag = pageNumber
         _thumbnailsRotateCounterClockwiseToolStripMenuItem.Enabled = True
         _thumbnailsEnableDisablePageToolStripMenuItem.Tag = pageNumber
         _thumbnailsEnableDisablePageToolStripMenuItem.Enabled = True
         _thumbnailsEnableDisablePageToolStripMenuItem.Checked = _documentViewer.Document.Pages(pageNumber - 1).IsDeleted
      Else
         _thumbnailsGetThisPageTextToolStripMenuItem.Tag = Nothing
         _thumbnailsGetThisPageTextToolStripMenuItem.Enabled = False
         _thumbnailsRotateClockwiseToolStripMenuItem.Tag = Nothing
         _thumbnailsRotateClockwiseToolStripMenuItem.Enabled = True
         _thumbnailsRotateCounterClockwiseToolStripMenuItem.Tag = Nothing
         _thumbnailsRotateCounterClockwiseToolStripMenuItem.Enabled = True
         _thumbnailsEnableDisablePageToolStripMenuItem.Tag = Nothing
         _thumbnailsEnableDisablePageToolStripMenuItem.Enabled = False
      End If

      _thumbnailsGetAllPagesTextToolStripMenuItem.Enabled = _documentViewer.Commands.CanRun(DocumentViewerCommands.TextGet, 0)
   End Sub

   Private Sub _thumbnailsGetThisPageTextToolStripMenuItem_Click(sender As Object, e As EventArgs)
      If _thumbnailsGetThisPageTextToolStripMenuItem.Tag Is Nothing Then
         Return
      End If

      Dim pageNumber As Integer = CInt(_thumbnailsGetThisPageTextToolStripMenuItem.Tag)
      GetPagesText(pageNumber)
   End Sub

   Private Sub _thumbnailsGetAllPagesTextToolStripMenuItem_Click(sender As Object, e As EventArgs)
      GetPagesText(0)
   End Sub

   Private Sub GetPagesText(pageNumber As Integer)
      ' This could take some time, so run it as a busy operation
      Me.BeginBusyOperation()

      Dim thisOperation As DocumentViewerAsyncOperation = New DocumentViewerAsyncOperation() With { _
        .Error = Sub(operation As DocumentViewerAsyncOperation, [error] As Exception)
                    Helper.ShowError(Me, [error])

                 End Sub, _
        .Always = Sub(operation As DocumentViewerAsyncOperation)
                     Me.EndBusyOperation()

                  End Sub _
      }

      _documentViewer.Commands.RunAsync(thisOperation, DocumentViewerCommands.TextGet, pageNumber)
   End Sub

   Private Sub _thumbnailsRotateClockwiseToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      If _thumbnailsRotateClockwiseToolStripMenuItem.Tag Is Nothing Then
         Return
      End If

      Dim pageNumber As Integer = CInt(_thumbnailsRotateClockwiseToolStripMenuItem.Tag)
      RotatePage(pageNumber, DocumentViewerCommands.PageRotateClockwise)
   End Sub

   Private Sub _thumbnailsRotateCounterClockwiseToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      If _thumbnailsRotateCounterClockwiseToolStripMenuItem.Tag Is Nothing Then
         Return
      End If

      Dim pageNumber As Integer = CInt(_thumbnailsRotateCounterClockwiseToolStripMenuItem.Tag)
      RotatePage(pageNumber, DocumentViewerCommands.PageRotateCounterClockwise)
   End Sub

   Private Sub _rotatePagesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      Using dlg As RotatePagesDialog = New RotatePagesDialog()
         dlg.PageCount = _documentViewer.PageCount
         dlg.FirstPageNumber = 1
         dlg.LastPageNumber = dlg.PageCount
         dlg.SelectedPageNumber = _documentViewer.CurrentPageNumber
         If dlg.ShowDialog(Me) = DialogResult.OK Then
            Dim rotationAngle As Integer
            Select Case dlg.Direction
               Case RotatePagesDialog.DirectionMode.Direction90CounterClockwise
                  rotationAngle = -90

               Case RotatePagesDialog.DirectionMode.Direction180
                  rotationAngle = 180

               Case Else
                  rotationAngle = 90
            End Select

            ' Get the page numbers to rotate
            Dim pageNumbers As List(Of Integer) = New List(Of Integer)()
            Dim firstPageNumber As Integer = dlg.FirstPageNumber
            Dim lastPageNumber As Integer = dlg.LastPageNumber
            Dim evenOdd As RotatePagesDialog.EvenOddMode = dlg.EventOdd
            Dim orientation As RotatePagesDialog.OrientationMode = dlg.Orientation

            Dim pageNumber As Integer = firstPageNumber
            Do While pageNumber <= lastPageNumber
               Dim add As Boolean = False

               Select Case evenOdd
                  Case RotatePagesDialog.EvenOddMode.OnlyEven
                     add = (pageNumber Mod 2) = 0

                  Case RotatePagesDialog.EvenOddMode.OnlyOdd
                     add = (pageNumber Mod 2) <> 0

                  Case RotatePagesDialog.EvenOddMode.All
                     add = True
               End Select

               If add Then
                  Dim page As DocumentPage = _documentViewer.Document.Pages(pageNumber - 1)
                  Select Case orientation
                     Case RotatePagesDialog.OrientationMode.LandscapeOnly
                        add = page.ViewPerspectiveSize.Width > page.ViewPerspectiveSize.Height

                     Case RotatePagesDialog.OrientationMode.PortraitOnly
                        add = page.ViewPerspectiveSize.Height > page.ViewPerspectiveSize.Width

                     Case Else
                        add = True
                  End Select
               End If

               If add Then
                  pageNumbers.Add(pageNumber)
               End If
               pageNumber += 1
            Loop

            If pageNumbers.Count > 0 Then
               _documentViewer.RotatePages(pageNumbers, rotationAngle)
            End If
         End If
      End Using
   End Sub

   Private Sub RotatePage(ByVal pageNumber As Integer, ByVal commandName As String)
      _documentViewer.Commands.Run(commandName, New Integer() {pageNumber})
   End Sub

   Private Sub _thumbnailsEnableDisablePageToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      If (_thumbnailsEnableDisablePageToolStripMenuItem.Tag Is Nothing) Then
         Return
      End If

      Dim pageNumber As Integer = CType(_thumbnailsEnableDisablePageToolStripMenuItem.Tag, Integer)
      EnableDisablePage(pageNumber)
   End Sub

   Private Sub _pageToolStripMenuItem_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs)
      If Not _documentViewer.HasDocument Then
         Return
      End If

      Dim pageNumber As Integer = _documentViewer.CurrentPageNumber
      If (pageNumber = 0) Then
         Return
      End If

      _enableDisablePageToolStripMenuItem.Checked = _documentViewer.Document.Pages((pageNumber - 1)).IsDeleted
   End Sub

   Private Sub _enableDisablePageToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      Dim pageNumber As Integer = _documentViewer.CurrentPageNumber
      EnableDisablePage(pageNumber)
   End Sub

   Private Sub EnableDisablePage(ByVal pageNumber As Integer)
      Dim page As DocumentPage = _documentViewer.Document.Pages((pageNumber - 1))
      Dim command As String
      If page.IsDeleted Then
         command = DocumentViewerCommands.PageEnable
      Else
         command = DocumentViewerCommands.PageDisable
      End If

      _documentViewer.Commands.Run(command, New Integer() {pageNumber})
   End Sub
End Class
