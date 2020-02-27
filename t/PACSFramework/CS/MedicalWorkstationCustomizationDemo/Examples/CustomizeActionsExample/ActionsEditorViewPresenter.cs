// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.Workstation.Presenters;
using Leadtools.Medical.Workstation;
using Leadtools.MedicalViewer;
using System.Windows.Forms;
using Leadtools.Medical.Workstation.UI;
using System.ComponentModel;

namespace Leadtools.Demos.Workstation.Customized
{
   class ActionsEditorViewPresenter : WorkstationPresenterBase <IActionsEditorView>
   {
      #region Public
         
         #region Methods
         
         #endregion
         
         #region Properties
            
         #endregion
         
         #region Events
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
         #region Callbacks
            
         #endregion
         
      #endregion
      
      #region Protected
         
         #region Methods
         
            protected override void DoInitialize 
            (
               WorkstationContainer container, 
               IActionsEditorView view
            )
            {
               MedicalViewerActionType [] actions ;
               
               
               if ( container.State.DataServices.IsRegistered <ActionsEditorState> ( ) )
               {
                  __ActionsEditorState = container.State.DataServices.Get <ActionsEditorState> ( ) ;
               }
               else
               {
                  __ActionsEditorState = new ActionsEditorState ( ) ;
                  
                  container.State.DataServices.Register <ActionsEditorState> ( __ActionsEditorState ) ;
               }
               
               actions = GetAllowedActions ( container ) ;
               
               view.SetActions ( actions ) ;
               view.SetActionMouseButtons ( Enum.GetValues ( typeof ( MedicalViewerMouseButtons ) ).OfType <MedicalViewerMouseButtons> ( ).ToArray ( ) ) ;
               
               if ( actions.Length > 0 )
               {
                  view.SelectedAction = actions [ 0 ] ;
                  
                  SetActionInformation ( view, container, actions [ 0 ] ) ;
                  
                  RegisterViewEvents ( view ) ;
               }
               else
               {
                  view.CanAddAction    = false ;
                  view.CanRemoveAction = false ;
               }
               
               view.ActivateView ( container.State.ActiveWorkstation ) ;
            }

         #endregion
         
         #region Properties
            
         #endregion
         
         #region Events
            
         #endregion
         
         #region Data Members
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
      #endregion
      
      #region Private
         
         #region Methods
         
            private MedicalViewerActionType[] GetAllowedActions ( WorkstationContainer container )
            {
               List <MedicalViewerActionType> actions ;
               
               
               actions = new List<MedicalViewerActionType> ( ) ;
               
               foreach ( MedicalViewerActionType action in Enum.GetValues ( typeof ( MedicalViewerActionType ) ).OfType <MedicalViewerActionType> ( ).ToArray ( )  ) 
               {
                  if ( action == MedicalViewerActionType.None || 
                       action == MedicalViewerActionType.Rotate3DCamera ||
                       action == MedicalViewerActionType.Rotate3DObject ||
                       action == MedicalViewerActionType.RotatePlane ||
                       action == MedicalViewerActionType.Scale3DObject ||
                       action == MedicalViewerActionType.Translate3DCamera ||
                       action == MedicalViewerActionType.TranslatePlane  )
                  {
                     continue ;
                  }
                  
                  if ( container.State.MedicalViewerCellActions.Contains ( action ) )
                  {
                     if ( __ActionsEditorState.CustomActions.Contains ( action ) )
                     {
                        actions.Add ( action ) ;
                     }
                  }
                  else
                  {
                     actions.Add ( action ) ;
                  }
               }
               
               return actions.ToArray ( ) ;
            }
            
            
            private void SetActionInformation
            (
               IActionsEditorView view, 
               WorkstationContainer container,
               MedicalViewerActionType action
            )
            {
               bool isNewAction ;
               
               
               isNewAction = !__ActionsEditorState.CustomActions.Contains ( action ) ;
               
               if ( isNewAction )
               {
                  view.CanAddAction    = true ;
                  view.CanRemoveAction = false ;
                  
                  view.ActionDisplayName   = action.ToString ( ) ;
                  view.SelectedMouseButton = MedicalViewerMouseButtons.Left ;
                  
                  view.CanEditToolstripButtons = true ;
                  
                  view.FeatureId = action.ToString ( ) + "FeatureId" ;
                  
                  view.ToolStipItemImage            = null ;
                  View.ToolStipItemAlternativeImage = null ;
               }
               else
               {
                  view.CanAddAction    = false ;
                  view.CanRemoveAction = true ;
                  
                  var keyValuePair = container.State.MedicalViewerCellMouseButtonActions.Where ( n=>n.Value == action ).FirstOrDefault ( ) ;
                  
                  view.ActionDisplayName   = container.State.WorkstationActionDisplayName [ action ] ;
                  view.SelectedMouseButton = keyValuePair.Key ;
                  
                  view.CanEditToolstripButtons = keyValuePair.Key == MedicalViewerMouseButtons.Left ;
                  
                  if ( __ActionsEditorState.ActionAssociatedFeature.ContainsKey ( action ) )
                  {
                     view.FeatureId = __ActionsEditorState.ActionAssociatedFeature [ action ] ;
                     
                     if ( !string.IsNullOrEmpty ( view.FeatureId ) )
                     {
                        ToolStripItem[] items = container.StripItemFeatureExecuter.GetItems ( view.FeatureId ) ;
                        
                        if ( items.Length > 0 && items [ 0 ] is IToolStripItemItemProperties )
                        {
                           view.ToolStipItemImage            = ( ( IToolStripItemItemProperties ) items [ 0 ] ).ItemProperties.DefaultImage ;
                           view.ToolStipItemAlternativeImage = ( ( IToolStripItemItemProperties ) items [ 0 ] ).ItemProperties.AlternativeImage ;
                        }
                     }
                  }
               }
               
               view.CanChangeDisplayName = view.CanAddAction ;
               view.CanChangeFeatureId   = view.CanAddAction ;
               view.CanChangeMouseButton = view.CanAddAction ;
            }
            
            private void RegisterViewEvents ( IActionsEditorView view )
            {
               view.SelectedActionChanged            += new EventHandler ( view_SelectedActionChanged ) ;
               view.SelectedActionMouseButtonChanged += new EventHandler ( view_SelectedActionMouseButtonChanged ) ;
               view.AddSelectedAction                += new EventHandler ( view_AddSelectedAction ) ;
               view.RemoveSelectedAction             += new EventHandler ( view_RemoveSelectedAction ) ;
               view.ValidateFeatureId += new System.ComponentModel.CancelEventHandler(view_ValidateFeatureId);
            }

            void view_ValidateFeatureId ( object sender, CancelEventArgs e )
            {
               e.Cancel = false ;
               View.SetValidationErrorText ( string.Empty ) ;
               
               if ( string.IsNullOrEmpty ( View.FeatureId ) )
               {
                  e.Cancel = true ;
                  
                  View.SetValidationErrorText ( "Feature ID can't be empty" ) ;
               }
               else
               {
                  if ( ViewerContainer.FeaturesFactory.IsCommandRegistered ( View.FeatureId ) )
                  {
                     e.Cancel = true ;
                     
                     View.SetValidationErrorText ( "Feature ID already registered" ) ;
                  }
               }
            }

            private void AddCustomMenuItem
            (
               MedicalViewerActionType action, 
               WorkstationMenuProperties newMenuProperties, 
               ToolStripDropDownItem item
            )
            {
               CustomToolStripMenuItem newActionItem ;
               
               
               
               newActionItem = new CustomToolStripMenuItem ( newMenuProperties ) ;
               
               
               item.DropDownItems.Insert ( 0, newActionItem ) ;
               
               ViewerContainer.State.ActiveWorkstation.AddToolbarSplitButtonChildItemLeftAction ( (CustomToolStripSplitButton) item,
                                                                                                   newActionItem,
                                                                                                   action ) ;
                                                                                                   
               ViewerContainer.StripItemFeatureExecuter.SetItemFeature ( newActionItem ) ;
            }

            private void AddCustomButton
            ( 
               MedicalViewerActionType action, 
               WorkstationMenuProperties newMenuProperties, 
               ToolStripDropDownItem item 
            )
            {
               CustomToolStripButton newActionItem ;
               
               
               newActionItem = new CustomToolStripButton ( newMenuProperties ) ;
               
               item.DropDownItems.Add ( newActionItem ) ;
               
               ViewerContainer.State.ActiveWorkstation.AddToolbarActivatedButtonLeftAction ( item, action ) ;
               
               ViewerContainer.StripItemFeatureExecuter.SetItemFeature ( newActionItem ) ;
            }
            
            private void AddDesignerItem
            ( 
               MedicalViewerActionType action, 
               WorkstationMenuProperties newMenuProperties, 
               ToolStripDropDownItem item 
            )
            {
               DesignToolStripMenuItem newActionItem ;
               
               
               newActionItem = new DesignToolStripMenuItem ( newMenuProperties ) ;
               
               item.DropDownItems.Add ( newActionItem ) ;
               
               ViewerContainer.StripItemFeatureExecuter.SetItemFeature ( newActionItem ) ;
            }

            private void AddActionToCurrentCells ( MedicalViewerActionType action )
            {
               foreach ( StudiesViewer studyViewer in ViewerContainer.State.WorkstationHostViewers.OfType <StudiesViewer> ( ) )
               {
                  foreach ( MedicalViewer.MedicalViewer medicalViewer in studyViewer.Viewers ) 
                  {
                     foreach ( MedicalViewerCell cell in medicalViewer.Cells )
                     {
                        cell.AddAction ( action ) ;
                     }
                  }
               }
            }

            private ToolStripItem[] GetAnnotationOrRegionsParnetItems ( MedicalViewerActionType action )
            {
               if ( action.ToString ( ).Contains ( "Annotation" ) )
               {
                  return ToolStripMenuProperties.Instance.AnnotationstoolStripSplitButton.AssociatedItems.OfType <ToolStripDropDownItem> ( ).ToArray ( ) ;
               }
               else if ( action.ToString ( ).Contains ( "Region" ) )
               {
                  return ToolStripMenuProperties.Instance.RegionstoolStripSplitButton.AssociatedItems.OfType <ToolStripDropDownItem> ( ).ToArray ( ) ;
               }
               else
               {
                  return null ;
               }
            }
            
         #endregion
         
         #region Properties
         
            private ActionsEditorState __ActionsEditorState
            {
               get ;
               set ;
            }
            
         #endregion
         
         #region Events
         
            void view_AddSelectedAction ( object sender, EventArgs e )
            {
               MedicalViewerActionType action = View.SelectedAction ;
               ApplyActionCommand actionCommand ;
               
               if ( !ViewerContainer.State.MedicalViewerCellActions.Contains ( action ) )
               {
                  AddActionToCurrentCells ( action ) ;
                  
                  ViewerContainer.State.MedicalViewerCellActions.Add ( action ) ;
               }
               
               ViewerContainer.State.WorkstationActionDisplayName [action] = View.ActionDisplayName ;
               
               __ActionsEditorState.CustomActions.Add ( action ) ;
               
               actionCommand = new ApplyActionCommand ( View.FeatureId, ViewerContainer, action, View.SelectedMouseButton, ApplyActionFlags.Viewer2D ) ;
               
               if ( View.SelectedMouseButton == MedicalViewerMouseButtons.Left )
               {
                  WorkstationMenuProperties newMenuProperties ;
                  
                  
                  newMenuProperties           = new WorkstationMenuProperties ( ViewerContainer.State.WorkstationActionDisplayName [action], View.ToolStipItemImage, View.ToolStipItemAlternativeImage ) ;
                  newMenuProperties.FeatureId = View.FeatureId ;
                  
                  __ActionsEditorState.ActionAssociatedFeature [ action ] = View.FeatureId ;
                  
                  ViewerContainer.FeaturesFactory.RegisterCommand ( actionCommand ) ;
                  
                  ToolStripItem[] parentItems = GetAnnotationOrRegionsParnetItems ( action ) ;
                  
                  if(  null != parentItems )
                  {
                     foreach ( ToolStripDropDownItem item in parentItems ) 
                     {
                        if ( ViewerContainer.State.ActiveWorkstation.IsToolbarActivatedButtonLeftAction ( item ) )
                        {
                           if ( item is CustomToolStripSplitButton ) 
                           {
                              AddCustomMenuItem ( action, newMenuProperties, item ) ;
                           }
                           else
                           {
                              AddCustomButton(action, newMenuProperties, item);
                           }
                        }
                        else
                        {
                           AddDesignerItem ( action, newMenuProperties, item ) ;
                        }
                     }
                  }
                  else
                  {
                     CustomToolStripSplitButton annotationToolbarItem = null ;
                     CustomToolStripButton newActionItem ;
                              
                              
                              
                     newActionItem = new CustomToolStripButton ( newMenuProperties ) ;
                     
                     foreach ( CustomToolStripSplitButton annotationItem in ToolStripMenuProperties.Instance.AnnotationstoolStripSplitButton.AssociatedItems.OfType <CustomToolStripSplitButton> ( ) )
                     {
                        if ( annotationItem.Owner == ViewerContainer.State.ActiveWorkstation.ViewerToolbar )
                        {
                           annotationToolbarItem = annotationItem ;
                           
                           break ;
                        }
                     }
                     
                     if ( null != annotationToolbarItem )
                     {
                        ViewerContainer.State.ActiveWorkstation.ViewerToolbar.Items.Insert ( ViewerContainer.State.ActiveWorkstation.ViewerToolbar.Items.IndexOf ( annotationToolbarItem ) - 1, 
                                                                                             newActionItem ) ;
                     }
                     else
                     {
                        ViewerContainer.State.ActiveWorkstation.ViewerToolbar.Items.Add ( newActionItem ) ;
                     }
                     
                     ViewerContainer.State.ActiveWorkstation.AddToolbarActivatedButtonLeftAction ( newActionItem, action ) ;
                     
                     ViewerContainer.StripItemFeatureExecuter.SetItemFeature ( newActionItem ) ;
                  }
               }
             
               if ( actionCommand.CanExecute ( ) )
               {
                  actionCommand.Execute ( ) ;
               }
               
               SetActionInformation ( View, ViewerContainer, View.SelectedAction ) ;
            
            }
            
            void view_RemoveSelectedAction ( object sender, EventArgs e )
            {
               MedicalViewerActionType action = View.SelectedAction ;
               
               
               if ( __ActionsEditorState.CustomActions.Contains ( action ) )
               {
                  if ( ViewerContainer.State.MedicalViewerCellActions.Contains ( action ) )
                  {
                     ViewerContainer.State.MedicalViewerCellActions.Remove ( action ) ;
                  }
                  
                  ViewerContainer.State.WorkstationActionDisplayName.Remove ( action ) ;
                  
                  __ActionsEditorState.CustomActions.Remove ( action ) ;
               }
               
               if ( __ActionsEditorState.ActionAssociatedFeature.ContainsKey ( action ) )
               {
                  ToolStripItem [] items ;
                  
                  
                  items = ViewerContainer.StripItemFeatureExecuter.GetItems ( __ActionsEditorState.ActionAssociatedFeature [ action ]) ;
                  
                  foreach ( ToolStripItem item in items ) 
                  {
                     if ( item is ActivatedButton && ViewerContainer.State.ActiveWorkstation.IsToolbarActivatedButtonLeftAction ( item ) )
                     {
                        ViewerContainer.State.ActiveWorkstation.RemoveToolbarActivatedButtonLeftAction ( item, action ) ;
                     }
                     else if ( item.OwnerItem is ActivatedButton )
                     {
                        ViewerContainer.State.ActiveWorkstation.RemoveToolbarActivatedButtonLeftAction ( item.OwnerItem, action ) ;
                     }
                     
                     ViewerContainer.StripItemFeatureExecuter.RemoveItemFeature ( item ) ;
                  
                     if ( null != item.OwnerItem )
                     {
                        ( ( ToolStripDropDownItem ) item.OwnerItem ).DropDownItems.Remove ( item ) ;
                     }
                     else
                     {
                        item.Owner.Items.Remove ( item ) ;
                     }
                  }
               }
            
               SetActionInformation ( View, ViewerContainer, action ) ;
            }
            
            void view_SelectedActionMouseButtonChanged ( object sender, EventArgs e )
            {
               View.CanEditToolstripButtons = View.SelectedMouseButton == MedicalViewerMouseButtons.Left ;
            }

            void view_SelectedActionChanged ( object sender, EventArgs e )
            {
               SetActionInformation ( View, ViewerContainer, View.SelectedAction ) ;
            }
            
         #endregion
         
         #region Data Members
            
         #endregion
         
         #region Data Types Definition
         
            class ActionsEditorState
            {
               public ActionsEditorState ( ) 
               {
                  CustomActions           = new List<MedicalViewerActionType> ( ) ;
                  ActionAssociatedFeature = new Dictionary<MedicalViewerActionType,string> ( ) ;
               }
               
               public List <MedicalViewerActionType> CustomActions
               {
                  get ;
                  private set ;
               }
               
               public Dictionary <MedicalViewerActionType, string> ActionAssociatedFeature 
               {
                  get;
                  private set ;
               }
            }
            
         #endregion
         
      #endregion
      
      #region internal
         
         #region Methods
            
         #endregion
         
         #region Properties
            
         #endregion
         
         #region Events
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
         #region Callbacks
            
         #endregion
         
      #endregion
   }
}
