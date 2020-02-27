' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Collections.Generic
Imports System.Text
Imports Leadtools.Annotations.Engine
Imports System.Windows.Forms
Imports Leadtools.Annotations.Automation
Imports Leadtools.Annotations.WinForms
Imports Leadtools
Imports System

Public Class CheckBoxTreeView : Inherits TreeView
   Public Sub New()
      Me.CheckBoxes = True
   End Sub

   Protected Overrides Sub WndProc(ByRef m As Message)
      ' Ignore WM_LBUTTONDBLCLK
      Const WM_LBUTTONDBLCLK As Integer = &H203
      If m.Msg = WM_LBUTTONDBLCLK Then
         m.Result = IntPtr.Zero
      Else
         MyBase.WndProc(m)
      End If
   End Sub
End Class

Friend Class LayerMenuItem
   Inherits MenuItem
   Private _id As Integer

   Friend Sub New(id As Integer, text As String)
      MyBase.New(text)
      _id = id
      RadioCheck = True
   End Sub

   Public ReadOnly Property Id() As Integer
      Get
         Return _id
      End Get
   End Property
End Class

Public Class LayerContextMenu
   Inherits ContextMenu
   Public Const AddLayer As Integer = -1
   Public Const DeleteLayer As Integer = -2
   Public Const Separator1Id As Integer = -3
   Public Const BringToFrontId As Integer = -4
   Public Const SendToBackId As Integer = -5
   Public Const BringToFirstId As Integer = -6
   Public Const SendToLastId As Integer = -7

   Public Const SeparatorMenuItem As String = "-"


   Public Const LastId As Integer = -15
   'const int UseId = 0;

   Private _layerNode As LayerNode
   Private _automation As AnnAutomation = Nothing


   Public Sub Attach(layerNode As LayerNode, automation As AnnAutomation)
      _layerNode = layerNode
      _automation = automation
   End Sub

   Public Sub Detach()
      _layerNode = Nothing
      _automation = Nothing
   End Sub

   Public Sub New()
      MenuItems.Add(New LayerMenuItem(AddLayer, "Add Layer"))
      MenuItems.Add(New LayerMenuItem(DeleteLayer, "Delete Layer"))
      MenuItems.Add(New LayerMenuItem(Separator1Id, SeparatorMenuItem))
      MenuItems.Add(New LayerMenuItem(SendToBackId, StringManager.GetString(StringManager.Id.SendToBackContextMenu)))
      MenuItems.Add(New LayerMenuItem(BringToFirstId, StringManager.GetString(StringManager.Id.BringToFirstContextMenu)))
      MenuItems.Add(New LayerMenuItem(SendToLastId, StringManager.GetString(StringManager.Id.SendToLastContextMenu)))
      MenuItems.Add(New LayerMenuItem(BringToFrontId, StringManager.GetString(StringManager.Id.BringToFrontContextMenu)))

      For Each i As MenuItem In MenuItems
         If String.Compare(i.Text, SeparatorMenuItem) <> 0 Then
            AddHandler i.Click, AddressOf menuItem_Click
         End If
      Next
   End Sub

   Public Overridable ReadOnly Property Layer() As LayerNode
      Get
         Return _layerNode
      End Get
   End Property

   Friend Function GetMenuItem(id As Integer) As LayerMenuItem
      For Each i As MenuItem In MenuItems
         If TypeOf i Is LayerMenuItem Then
            Dim mi As LayerMenuItem = TryCast(i, LayerMenuItem)
            If mi.Id = id Then
               Return mi
            End If
         End If
      Next

      Return Nothing
   End Function

   Protected Overrides Sub OnPopup(e As EventArgs)
      Dim parentLayer As AnnLayer = _layerNode.Layer.Parent
      Dim isContainer As Boolean = _layerNode.Tag IsNot Nothing AndAlso String.Compare(CType(_layerNode.Tag, String), "Container") = 0

      Dim mi As LayerMenuItem = GetMenuItem(DeleteLayer)
      If mi IsNot Nothing Then
         mi.Enabled = Not isContainer
      End If

      mi = GetMenuItem(BringToFrontId)
      If mi IsNot Nothing Then
         mi.Enabled = _automation.CanBringLayerToFront
      End If

      mi = GetMenuItem(SendToBackId)
      If mi IsNot Nothing Then
         mi.Enabled = _automation.CanSendLayerToBack
      End If

      mi = GetMenuItem(BringToFirstId)
      If mi IsNot Nothing Then
         mi.Enabled = _automation.CanBringLayerToFirst
      End If

      mi = GetMenuItem(SendToLastId)
      If mi IsNot Nothing Then
         mi.Enabled = _automation.CanSendLayerToLast
      End If

      MyBase.OnPopup(e)
   End Sub

   Private Sub menuItem_Click(sender As Object, e As EventArgs)
      If _layerNode Is Nothing Then
         Return
      End If

      Dim mi As LayerMenuItem = TryCast(sender, LayerMenuItem)
      If mi IsNot Nothing Then
         If mi.Id = AddLayer Then
            If mi.Parent IsNot Nothing Then
               Dim newLayer As AnnLayer = AnnLayer.Create("Layer")
               _layerNode.Nodes.Add(New LayerNode(newLayer, Me))
               If _layerNode.Tag IsNot Nothing AndAlso String.Compare(CType(_layerNode.Tag, String), "Container") = 0 Then
                  _automation.AddLayer(Nothing, newLayer)
               Else
                  _automation.AddLayer(_layerNode.Layer, newLayer)
               End If
            End If
         ElseIf mi.Id = DeleteLayer Then
            _automation.DeleteLayer(_layerNode.Layer, False)
            _layerNode.Parent.Nodes.Remove(_layerNode)
         ElseIf mi.Id = BringToFirstId Then
            _automation.BringLayerToFront(True)
         ElseIf mi.Id = BringToFrontId Then
            _automation.BringLayerToFront(False)
         ElseIf mi.Id = SendToBackId Then
            _automation.SendLayerToBack(False)
         ElseIf mi.Id = SendToLastId Then
            _automation.SendLayerToBack(True)
         End If
      End If

      If _automation IsNot Nothing Then
         _automation.Invalidate(LeadRectD.Empty)
      End If
   End Sub
End Class

Public Class LayerNode
   Inherits TreeNode
   Shared _count As Integer = 0

   Private Sub Init(layer As AnnLayer, menu As ContextMenu)
      _layer = layer
      ContextMenu = Nothing
      Checked = layer.IsVisible
   End Sub

   Public Sub New(layer As AnnLayer, menu As ContextMenu, increment As Boolean)
      MyBase.New(If(increment, String.Format("{0} #{1}", layer.Name, (System.Math.Max(System.Threading.Interlocked.Increment(_count), _count - 1)).ToString()), layer.Name))
      Init(layer, menu)
   End Sub

   Public Sub New(layer As AnnLayer, menu As ContextMenu)
      MyBase.New(String.Format("{0} #{1}", layer.Name, (System.Math.Max(System.Threading.Interlocked.Increment(_count), _count - 1)).ToString()))
      Init(layer, menu)
   End Sub

   Private _layer As AnnLayer

   Public ReadOnly Property Layer() As AnnLayer
      Get
         Return _layer
      End Get
   End Property
End Class
