' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Windows.Forms

Imports Leadtools.Controls
Imports Leadtools.Document.Viewer
Imports System

' Contains the view menu and toolbar part of the viewer
Partial Public Class MainForm
   Private Sub BindViewItems()
      ' Menu
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .ToolStripItem = _viewToolStripMenuItem _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.ViewRotateClockwise, _
         .ToolStripItem = _clockwiseToolStripMenuItem _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.ViewRotateCounterClockwise, _
         .ToolStripItem = _counterClockwiseToolStripMenuItem _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.ViewZoomOut, _
         .ToolStripItem = _zoomOutToolStripMenuItem _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.ViewZoomIn, _
         .ToolStripItem = _zoomInToolStripMenuItem _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.ViewActualSize, _
         .ToolStripItem = _actualSizeToolStripMenuItem, _
         .UpdateChecked = True _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.ViewFitPage, _
         .ToolStripItem = _fitPageToolStripMenuItem, _
         .UpdateChecked = True _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.ViewFitWidth, _
         .ToolStripItem = _fitWidthToolStripMenuItem, _
         .UpdateChecked = True _
      })

      ' Toolbar
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .ToolStripItem = _mainToolStripSeparator2 _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.ViewZoomIn, _
         .ToolStripItem = _zoomInToolStripButton _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.ViewZoomOut, _
         .ToolStripItem = _zoomOutToolStripButton _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .ToolStripItem = _zoomToolStripComboBox _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.ViewFitPage, _
         .ToolStripItem = _fitPageToolStripButton, _
         .UpdateChecked = True _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.ViewFitWidth, _
         .ToolStripItem = _fitWidthToolStripButton, _
         .UpdateChecked = True _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.ViewActualSize, _
         .ToolStripItem = _actualSizeToolStripButton, _
         .UpdateChecked = True _
      })

      BindZoom()
   End Sub

   Private Sub _viewToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles _viewToolStripMenuItem.DropDownOpening
      If _documentViewer.Document.Images.IsSvgViewingPreferred Then
         If Not _asSvgToolStripMenuItem.Enabled Then
            _asSvgToolStripMenuItem.Enabled = True
         End If

         _asSvgToolStripMenuItem.Checked = Not _documentViewer.Commands.CanRun(DocumentViewerCommands.ViewItemType, DocumentViewerItemType.Svg)
         _asImageToolStripMenuItem.Checked = Not _documentViewer.Commands.CanRun(DocumentViewerCommands.ViewItemType, DocumentViewerItemType.Image)
      Else
         _asSvgToolStripMenuItem.Enabled = False
         _asSvgToolStripMenuItem.Checked = False
         _asImageToolStripMenuItem.Checked = True
      End If

      If _documentViewer.Document.IsStructureSupported Then
         If Not _bookmarksToolStripMenuItem.Enabled Then
            _bookmarksToolStripMenuItem.Enabled = True
         End If

         _bookmarksToolStripMenuItem.Checked = (_leftTabControl.SelectedTab Is _bookmarksTabPage)
      Else
         _bookmarksToolStripMenuItem.Enabled = False
         _bookmarksToolStripMenuItem.Checked = False
      End If

      _thumbnailsToolStripMenuItem.Checked = Not _bookmarksToolStripMenuItem.Checked
   End Sub

   Private Sub _asSvgToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _asSvgToolStripMenuItem.Click
      _documentViewer.Commands.Run(DocumentViewerCommands.ViewItemType, DocumentViewerItemType.Svg)
   End Sub

   Private Sub _asImageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _asImageToolStripMenuItem.Click
      _documentViewer.Commands.Run(DocumentViewerCommands.ViewItemType, DocumentViewerItemType.Image)
   End Sub

   Private Sub BindZoom()
      Dim zoomValues As String() = {"10%", "25%", "50%", "75%", "100%", "125%", _
       "200%", "400%", "800%", "1600%", "2400%", "3200%", _
       "6400%", "Actual Size", "Fit Page", "Fit Width", "Fit Height"}

      For Each zoomValue As String In zoomValues
         _zoomToolStripComboBox.Items.Add(zoomValue)
      Next

      AddHandler _documentViewer.View.ImageViewer.TransformChanged, AddressOf UpdateZoomValueFromView
      AddHandler _zoomToolStripComboBox.LostFocus, AddressOf UpdateZoomValueFromView

      AddHandler _zoomToolStripComboBox.SelectedIndexChanged, Sub(sender, e)
                                                                 If Not _documentViewer.HasDocument Then
                                                                    Return
                                                                 End If

                                                                 ' Parse the new zoom value
                                                                 Dim text As String = _zoomToolStripComboBox.Text.Trim()
                                                                 Dim imageViewer As ImageViewer = _documentViewer.View.ImageViewer

                                                                 Select Case text
                                                                    Case "Actual Size"
                                                                       imageViewer.Zoom(ControlSizeMode.ActualSize, 1, imageViewer.DefaultZoomOrigin)
                                                                       Exit Select

                                                                    Case "Fit Page"
                                                                       imageViewer.Zoom(ControlSizeMode.FitAlways, 1, imageViewer.DefaultZoomOrigin)
                                                                       Exit Select

                                                                    Case "Fit Width"
                                                                       imageViewer.Zoom(ControlSizeMode.FitWidth, 1, imageViewer.DefaultZoomOrigin)
                                                                       Exit Select

                                                                    Case "Fit Height"
                                                                       imageViewer.Zoom(ControlSizeMode.FitHeight, 1, imageViewer.DefaultZoomOrigin)
                                                                       Exit Select
                                                                    Case Else

                                                                       If Not String.IsNullOrEmpty(text) Then
                                                                          Dim percentage As Double = Double.Parse(text.Substring(0, text.Length - 1))
                                                                          imageViewer.Zoom(ControlSizeMode.None, percentage / 100.0, imageViewer.DefaultZoomOrigin)
                                                                          UpdateUIState()
                                                                       End If
                                                                       Exit Select
                                                                 End Select

                                                              End Sub

      AddHandler _zoomToolStripComboBox.KeyPress, Sub(sender, e)
                                                     If e.KeyChar = CChar(Microsoft.VisualBasic.ChrW(Keys.[Return])) Then
                                                        ' User has pressed enter, parse the new zoom value
                                                        Dim text As String = _zoomToolStripComboBox.Text.Trim()
                                                        If String.IsNullOrEmpty(text) Then
                                                           Return
                                                        End If

                                                        ' Remove the % sign if present
                                                        If text.EndsWith("%") Then
                                                           text = text.Remove(text.Length - 1, 1).Trim()
                                                        End If

                                                        ' Try to parse the new zoom value
                                                        Dim percentage As Double
                                                        If Double.TryParse(text, percentage) Then
                                                           Dim imageViewer As ImageViewer = _documentViewer.View.ImageViewer
                                                           imageViewer.Zoom(ControlSizeMode.None, percentage / 100.0, imageViewer.DefaultZoomOrigin)
                                                        End If

                                                        UpdateZoomValueFromView()
                                                     End If

                                                  End Sub
   End Sub

   Private Sub UpdateZoomValueFromView()
      ' We are invoking this instead of changing the properties
      ' directly because the Text value of a combo box is not
      ' updated till after the lost focus or enter event is exited
      BeginInvoke(New MethodInvoker(Sub()
                                       If _documentViewer.HasDocument Then
                                          Dim percentage As Double = _documentViewer.View.ImageViewer.ScaleFactor * 100.0
                                          _zoomToolStripComboBox.Text = percentage.ToString("F1") & "%"
                                       Else
                                          _zoomToolStripComboBox.Text = String.Empty
                                       End If
                                    End Sub
   ))
   End Sub


   Private Sub _thumbnailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _thumbnailsToolStripMenuItem.Click
      _leftTabControl.SelectedTab = _thumbnailsTabPage
   End Sub

   Private Sub _bookmarksToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _bookmarksToolStripMenuItem.Click
      _leftTabControl.SelectedTab = _bookmarksTabPage
   End Sub
End Class
