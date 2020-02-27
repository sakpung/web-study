' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Leadtools.Medical.Workstation.Presenters
Imports Leadtools.Medical.Workstation
Imports Leadtools.MedicalViewer
Imports System.Windows.Forms
Imports System.ComponentModel
Imports Leadtools.Medical.Workstation.UI

Namespace Leadtools.Demos.Workstation.Customized
   Class ActionsEditorViewPresenter
      Inherits WorkstationPresenterBase(Of IActionsEditorView)
#Region "Public"

#Region "Methods"

#End Region

#Region "Properties"

#End Region

#Region "Events"

#End Region

#Region "Data Types Definition"

#End Region

#Region "Callbacks"

#End Region

#End Region

#Region "Protected"

#Region "Methods"

      Protected Overrides Sub DoInitialize(ByVal container As WorkstationContainer, ByVal view As IActionsEditorView)
         Dim actions As MedicalViewerActionType()


         If container.State.DataServices.IsRegistered(Of ActionsEditorState)() Then
            __ActionsEditorState = container.State.DataServices.[Get](Of ActionsEditorState)()
         Else
            __ActionsEditorState = New ActionsEditorState()

            container.State.DataServices.Register(Of ActionsEditorState)(__ActionsEditorState)
         End If

         actions = GetAllowedActions(container)

         view.SetActions(actions)
         view.SetActionMouseButtons(System.Enum.GetValues(GetType(MedicalViewerMouseButtons)).OfType(Of MedicalViewerMouseButtons)().ToArray())


         If actions.Length > 0 Then
            view.SelectedAction = actions(0)

            SetActionInformation(view, container, actions(0))

            RegisterViewEvents(view)
         Else
            view.CanAddAction = False
            view.CanRemoveAction = False
         End If

         view.ActivateView(container.State.ActiveWorkstation)
      End Sub

#End Region

#Region "Properties"

#End Region

#Region "Events"

#End Region

#Region "Data Members"

#End Region

#Region "Data Types Definition"

#End Region

#End Region

#Region "Private"

#Region "Methods"

      Private Function GetAllowedActions(ByVal container As WorkstationContainer) As MedicalViewerActionType()
         Dim actions As List(Of MedicalViewerActionType)


         actions = New List(Of MedicalViewerActionType)()

         For Each action As MedicalViewerActionType In System.Enum.GetValues(GetType(MedicalViewerActionType)).OfType(Of MedicalViewerActionType)().ToArray()
            If action = MedicalViewerActionType.None OrElse action = MedicalViewerActionType.Rotate3DCamera OrElse action = MedicalViewerActionType.Rotate3DObject OrElse action = MedicalViewerActionType.RotatePlane OrElse action = MedicalViewerActionType.Scale3DObject OrElse action = MedicalViewerActionType.Translate3DCamera OrElse action = MedicalViewerActionType.TranslatePlane Then
               Continue For
            End If

            If container.State.MedicalViewerCellActions.Contains(action) Then
               If __ActionsEditorState.CustomActions.Contains(action) Then
                  actions.Add(action)
               End If
            Else
               actions.Add(action)
            End If
         Next

         Return actions.ToArray()
      End Function


      Private Sub SetActionInformation(ByVal view__1 As IActionsEditorView, ByVal container As WorkstationContainer, ByVal action As MedicalViewerActionType)
         Dim isNewAction As Boolean


         isNewAction = Not __ActionsEditorState.CustomActions.Contains(action)

         If isNewAction Then
            view__1.CanAddAction = True
            view__1.CanRemoveAction = False

            view__1.ActionDisplayName = action.ToString()
            view__1.SelectedMouseButton = MedicalViewerMouseButtons.Left

            view__1.CanEditToolstripButtons = True

            view__1.FeatureId = action.ToString() & "FeatureId"

            view__1.ToolStipItemImage = Nothing
            View.ToolStipItemAlternativeImage = Nothing
         Else
            view__1.CanAddAction = False
            view__1.CanRemoveAction = True

            Dim keyValuePair As KeyValuePair(Of MedicalViewerMouseButtons, MedicalViewerActionType) = container.State.MedicalViewerCellMouseButtonActions.Where(Function(n) n.Value = action).FirstOrDefault()

            view__1.ActionDisplayName = container.State.WorkstationActionDisplayName(action)
            view__1.SelectedMouseButton = keyValuePair.Key

            view__1.CanEditToolstripButtons = keyValuePair.Key = MedicalViewerMouseButtons.Left

            If __ActionsEditorState.ActionAssociatedFeature.ContainsKey(action) Then
               view__1.FeatureId = __ActionsEditorState.ActionAssociatedFeature(action)

               If Not String.IsNullOrEmpty(view__1.FeatureId) Then
                  Dim items As ToolStripItem() = container.StripItemFeatureExecuter.GetItems(view__1.FeatureId)

                  If items.Length > 0 AndAlso TypeOf items(0) Is IToolStripItemItemProperties Then
                     view__1.ToolStipItemImage = CType(items(0), IToolStripItemItemProperties).ItemProperties.DefaultImage
                     view__1.ToolStipItemAlternativeImage = CType(items(0), IToolStripItemItemProperties).ItemProperties.AlternativeImage
                  End If
               End If
            End If
         End If

         view__1.CanChangeDisplayName = view__1.CanAddAction
         view__1.CanChangeFeatureId = view__1.CanAddAction
         view__1.CanChangeMouseButton = view__1.CanAddAction
      End Sub

      Private Sub RegisterViewEvents(ByVal view As IActionsEditorView)
         AddHandler view.SelectedActionChanged, AddressOf view_SelectedActionChanged
         AddHandler view.SelectedActionMouseButtonChanged, AddressOf view_SelectedActionMouseButtonChanged
         AddHandler view.AddSelectedAction, AddressOf view_AddSelectedAction
         AddHandler view.RemoveSelectedAction, AddressOf view_RemoveSelectedAction
         AddHandler view.ValidateFeatureId, AddressOf view_ValidateFeatureId
      End Sub

      Private Sub view_ValidateFeatureId(ByVal sender As Object, ByVal e As CancelEventArgs)
         e.Cancel = False
         View.SetValidationErrorText(String.Empty)

         If String.IsNullOrEmpty(View.FeatureId) Then
            e.Cancel = True

            View.SetValidationErrorText("Feature ID can't be empty")
         Else
            If ViewerContainer.FeaturesFactory.IsCommandRegistered(View.FeatureId) Then
               e.Cancel = True

               View.SetValidationErrorText("Feature ID already registered")
            End If
         End If
      End Sub

      Private Sub AddCustomMenuItem(ByVal action As MedicalViewerActionType, ByVal newMenuProperties As WorkstationMenuProperties, ByVal item As ToolStripDropDownItem)
         Dim newActionItem As CustomToolStripMenuItem



         newActionItem = New CustomToolStripMenuItem(newMenuProperties)


         item.DropDownItems.Insert(0, newActionItem)

         ViewerContainer.State.ActiveWorkstation.AddToolbarSplitButtonChildItemLeftAction(CType(item, CustomToolStripSplitButton), newActionItem, action)

         ViewerContainer.StripItemFeatureExecuter.SetItemFeature(newActionItem)
      End Sub

      Private Sub AddCustomButton(ByVal action As MedicalViewerActionType, ByVal newMenuProperties As WorkstationMenuProperties, ByVal item As ToolStripDropDownItem)
         Dim newActionItem As CustomToolStripButton


         newActionItem = New CustomToolStripButton(newMenuProperties)

         item.DropDownItems.Add(newActionItem)

         ViewerContainer.State.ActiveWorkstation.AddToolbarActivatedButtonLeftAction(item, action)

         ViewerContainer.StripItemFeatureExecuter.SetItemFeature(newActionItem)
      End Sub

      Private Sub AddDesignerItem(ByVal action As MedicalViewerActionType, ByVal newMenuProperties As WorkstationMenuProperties, ByVal item As ToolStripDropDownItem)
         Dim newActionItem As DesignToolStripMenuItem


         newActionItem = New DesignToolStripMenuItem(newMenuProperties)

         item.DropDownItems.Add(newActionItem)

         ViewerContainer.StripItemFeatureExecuter.SetItemFeature(newActionItem)
      End Sub

      Private Sub AddActionToCurrentCells(ByVal action As MedicalViewerActionType)
         For Each studyViewer As StudiesViewer In ViewerContainer.State.WorkstationHostViewers.OfType(Of StudiesViewer)()
            For Each medicalViewer As MedicalViewer.MedicalViewer In studyViewer.Viewers
               For Each cell As MedicalViewerCell In medicalViewer.Cells
                  cell.AddAction(action)
               Next
            Next
         Next
      End Sub

      Private Function GetAnnotationOrRegionsParnetItems(ByVal action As MedicalViewerActionType) As ToolStripItem()
         If action.ToString().Contains("Annotation") Then
            Return ToolStripMenuProperties.Instance.AnnotationstoolStripSplitButton.AssociatedItems.OfType(Of ToolStripDropDownItem)().ToArray()
         ElseIf action.ToString().Contains("Region") Then
            Return ToolStripMenuProperties.Instance.RegionstoolStripSplitButton.AssociatedItems.OfType(Of ToolStripDropDownItem)().ToArray()
         Else
            Return Nothing
         End If
      End Function

#End Region

#Region "Properties"

      Private __ActionsEditorState As ActionsEditorState
#End Region

#Region "Events"

      Private Sub view_AddSelectedAction(ByVal sender As Object, ByVal e As EventArgs)
         Dim action As MedicalViewerActionType = View.SelectedAction
         Dim actionCommand As ApplyActionCommand

         If Not ViewerContainer.State.MedicalViewerCellActions.Contains(action) Then
            AddActionToCurrentCells(action)

            ViewerContainer.State.MedicalViewerCellActions.Add(action)
         End If

         ViewerContainer.State.WorkstationActionDisplayName(action) = View.ActionDisplayName

         __ActionsEditorState.CustomActions.Add(action)

         actionCommand = New ApplyActionCommand(View.FeatureId, ViewerContainer, action, View.SelectedMouseButton, ApplyActionFlags.Viewer2D)

         If View.SelectedMouseButton = MedicalViewerMouseButtons.Left Then
            Dim newMenuProperties As WorkstationMenuProperties


            newMenuProperties = New WorkstationMenuProperties(ViewerContainer.State.WorkstationActionDisplayName(action), View.ToolStipItemImage, View.ToolStipItemAlternativeImage)
            newMenuProperties.FeatureId = View.FeatureId

            __ActionsEditorState.ActionAssociatedFeature(action) = View.FeatureId

            ViewerContainer.FeaturesFactory.RegisterCommand(actionCommand)

            Dim parentItems As ToolStripItem() = GetAnnotationOrRegionsParnetItems(action)

            If parentItems IsNot Nothing Then
               For Each item As ToolStripDropDownItem In parentItems
                  If ViewerContainer.State.ActiveWorkstation.IsToolbarActivatedButtonLeftAction(item) Then
                     If TypeOf item Is CustomToolStripSplitButton Then
                        AddCustomMenuItem(action, newMenuProperties, item)
                     Else
                        AddCustomButton(action, newMenuProperties, item)
                     End If
                  Else
                     AddDesignerItem(action, newMenuProperties, item)
                  End If
               Next
            Else
               Dim annotationToolbarItem As CustomToolStripSplitButton = Nothing
               Dim newActionItem As CustomToolStripButton


               newActionItem = New CustomToolStripButton(newMenuProperties)

               For Each annotationItem As CustomToolStripSplitButton In ToolStripMenuProperties.Instance.AnnotationstoolStripSplitButton.AssociatedItems.OfType(Of CustomToolStripSplitButton)()
                  If annotationItem.Owner Is ViewerContainer.State.ActiveWorkstation.ViewerToolbar Then
                     annotationToolbarItem = annotationItem
                     Exit For
                  End If
               Next

               If annotationToolbarItem IsNot Nothing Then
                  ViewerContainer.State.ActiveWorkstation.ViewerToolbar.Items.Insert(ViewerContainer.State.ActiveWorkstation.ViewerToolbar.Items.IndexOf(annotationToolbarItem) - 1, newActionItem)
               Else
                  ViewerContainer.State.ActiveWorkstation.ViewerToolbar.Items.Add(newActionItem)
               End If

               ViewerContainer.State.ActiveWorkstation.AddToolbarActivatedButtonLeftAction(newActionItem, action)

               ViewerContainer.StripItemFeatureExecuter.SetItemFeature(newActionItem)
            End If
         End If

         If actionCommand.CanExecute() Then
            actionCommand.Execute()
         End If

         SetActionInformation(View, ViewerContainer, View.SelectedAction)

      End Sub

      Private Sub view_RemoveSelectedAction(ByVal sender As Object, ByVal e As EventArgs)
         Dim action As MedicalViewerActionType = View.SelectedAction


         If __ActionsEditorState.CustomActions.Contains(action) Then
            If ViewerContainer.State.MedicalViewerCellActions.Contains(action) Then
               ViewerContainer.State.MedicalViewerCellActions.Remove(action)
            End If

            ViewerContainer.State.WorkstationActionDisplayName.Remove(action)

            __ActionsEditorState.CustomActions.Remove(action)
         End If

         If __ActionsEditorState.ActionAssociatedFeature.ContainsKey(action) Then
            Dim items As ToolStripItem()


            items = ViewerContainer.StripItemFeatureExecuter.GetItems(__ActionsEditorState.ActionAssociatedFeature(action))

            For Each item As ToolStripItem In items
               If TypeOf item Is ActivatedButton AndAlso ViewerContainer.State.ActiveWorkstation.IsToolbarActivatedButtonLeftAction(item) Then
                  ViewerContainer.State.ActiveWorkstation.RemoveToolbarActivatedButtonLeftAction(item, action)
               ElseIf TypeOf item.OwnerItem Is ActivatedButton Then
                  ViewerContainer.State.ActiveWorkstation.RemoveToolbarActivatedButtonLeftAction(item.OwnerItem, action)
               End If

               ViewerContainer.StripItemFeatureExecuter.RemoveItemFeature(item)

               If item.OwnerItem IsNot Nothing Then
                  CType(item.OwnerItem, ToolStripDropDownItem).DropDownItems.Remove(item)
               Else
                  item.Owner.Items.Remove(item)
               End If
            Next
         End If

         SetActionInformation(View, ViewerContainer, action)
      End Sub

      Private Sub view_SelectedActionMouseButtonChanged(ByVal sender As Object, ByVal e As EventArgs)
         View.CanEditToolstripButtons = View.SelectedMouseButton = MedicalViewerMouseButtons.Left
      End Sub

      Private Sub view_SelectedActionChanged(ByVal sender As Object, ByVal e As EventArgs)
         SetActionInformation(View, ViewerContainer, View.SelectedAction)
      End Sub

#End Region

#Region "Data Members"

#End Region

#Region "Data Types Definition"

      Private Class ActionsEditorState
         Public Sub New()
            CustomActions = New List(Of MedicalViewerActionType)()
            ActionAssociatedFeature = New Dictionary(Of MedicalViewerActionType, String)()
         End Sub

         Public CustomActions As List(Of MedicalViewerActionType)
         Public ActionAssociatedFeature As Dictionary(Of MedicalViewerActionType, String)
      End Class

#End Region

#End Region

#Region "internal"

#Region "Methods"

#End Region

#Region "Properties"

#End Region

#Region "Events"

#End Region

#Region "Data Types Definition"

#End Region

#Region "Callbacks"

#End Region

#End Region
   End Class
End Namespace
