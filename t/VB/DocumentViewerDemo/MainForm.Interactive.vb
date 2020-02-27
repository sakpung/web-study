' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.Document.Viewer
Imports Leadtools.Controls
Imports System

' Contains the interactive menu and toolbar part of the viewer
Partial Public Class MainForm
   Private Sub BindInteractiveItems()
      ' Menu
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .ToolStripItem = _interactiveToolStripMenuItem _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.InteractiveSelectText, _
         .ToolStripItem = _selectTextToolStripMenuItem, _
         .UpdateChecked = True _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.InteractivePanZoom, _
         .ToolStripItem = _panZoomToolStripMenuItem, _
         .UpdateChecked = True _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.InteractivePan, _
         .ToolStripItem = _panToolStripMenuItem, _
         .UpdateChecked = True _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.InteractiveZoom, _
         .ToolStripItem = _zoomToolStripMenuItem, _
         .UpdateChecked = True _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.InteractiveZoomTo, _
         .ToolStripItem = _zoomToToolStripMenuItem, _
         .UpdateChecked = True _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.InteractiveMagnifyGlass, _
         .ToolStripItem = _magnifyGlassToolStripMenuItem, _
         .UpdateChecked = True _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.InteractiveAutoPan, _
         .ToolStripItem = _autoPanToolStripMenuItem _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .ToolStripItem = _inertiaScrollToolStripMenuItem _
      })

      ' Toolbar
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.InteractiveSelectText, _
         .ToolStripItem = _selectTextToolStripButton, _
         .UpdateChecked = True _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.InteractivePanZoom, _
         .ToolStripItem = _panZoomToolStripButton, _
         .UpdateChecked = True _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.InteractivePan, _
         .ToolStripItem = _panToolStripButton, _
         .UpdateChecked = True _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.InteractiveZoom, _
         .ToolStripItem = _zoomToolStripButton, _
         .UpdateChecked = True _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.InteractiveZoomTo, _
         .ToolStripItem = _zoomToToolStripButton, _
         .UpdateChecked = True _
      })
      _commandsBinder.Items.Add(New CommandBinderItem() With { _
         .CommandName = DocumentViewerCommands.InteractiveMagnifyGlass, _
         .ToolStripItem = _magnifyGlassToolStripButton, _
         .UpdateChecked = True _
      })
   End Sub


   Private Sub _interactiveToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs)
      _inertiaScrollToolStripMenuItem.Checked = _preferences.EnableInertiaScroll
   End Sub

   Private Sub _inertiaScrollToolStripMenuItem_Click(sender As Object, e As EventArgs)
      ToggleInertiaScroll(False)
   End Sub
End Class
