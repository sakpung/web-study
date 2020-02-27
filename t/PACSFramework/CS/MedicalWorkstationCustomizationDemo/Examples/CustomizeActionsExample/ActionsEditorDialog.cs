// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Leadtools.MedicalViewer;
using Leadtools.Medical.Workstation.UI;

namespace Leadtools.Demos.Workstation.Customized
{
   public partial class ActionsEditorDialog : WorkstationModalViewBase, IActionsEditorView
   {
      #region Public
         
         #region Methods
         
            public ActionsEditorDialog ( )
            {
               InitializeComponent ( ) ;
               
               RegisterEvents ( ) ;
            }

            public void SetActions ( MedicalViewerActionType[] actions ) 
            {
               ActionComboBox.DataSource = actions ;
            }
            
            public void SetActionMouseButtons ( MedicalViewerMouseButtons[] mouseButtons ) 
            {
               MouseButtonsComboBox.DataSource = mouseButtons ;
            }
            
            public void SetValidationErrorText ( string message ) 
            {
               errorProvider1.SetError ( FeautreIdTextBox, message ) ;
            }
         
         #endregion
         
         #region Properties
         
            public MedicalViewerActionType SelectedAction
            {
               get 
               {
                  return (MedicalViewerActionType) ActionComboBox.SelectedItem ;
               }
               
               set
               {
                  ActionComboBox.SelectedItem = value ;
               }
            }
            
            public string ActionDisplayName
            {
               get
               {
                  return ActionDisplayNameTextBox.Text ;
               }
               
               set
               {
                  ActionDisplayNameTextBox.Text = value ;
               }
            }
            
            public MedicalViewerMouseButtons SelectedMouseButton
            {
               get
               {
                  return (MedicalViewerMouseButtons) MouseButtonsComboBox.SelectedItem ;
               }
               
               set
               {
                  MouseButtonsComboBox.SelectedItem  = value ;
               }
            }
            
            public bool CanEditToolstripButtons
            {
               get
               {
                  return ToolStripButtonsGroupBox.Enabled ;
               }
               
               set
               {
                  ToolStripButtonsGroupBox.Enabled = value ;
               }
            }
            
            public string FeatureId
            {
               get
               {
                  return FeautreIdTextBox.Text ;
               }
               
               set
               {
                  FeautreIdTextBox.Text = value ;
               }
            }
            
            public Image ToolStipItemImage
            {
               get
               {
                  return ImagePictureBox.Image ;
               }
               
               set
               {
                  ImagePictureBox.Image = value ;
               }
            }
            
            public Image ToolStipItemAlternativeImage 
            { 
               get
               {
                  return AltImagePictureBox.Image ;
               }
               
               set
               {
                  AltImagePictureBox.Image = value ;
               }
            }
            
            public bool CanAddAction
            {
               get
               {
                  return AddActionButton.Enabled ;
               }
               
               set
               {
                  AddActionButton.Enabled = value ;
               }
            }
            
            public bool CanRemoveAction
            {
               get
               {
                  return RemoveActionButton.Enabled ;
               }
               
               set
               {
                  RemoveActionButton.Enabled = value ;
               }
            }
            
            public bool CanChangeDisplayName 
            { 
               get { return ActionDisplayNameTextBox.Enabled ; }
               set { ActionDisplayNameTextBox.Enabled = value ; }
            }
            
            public bool CanChangeMouseButton 
            { 
               get { return MouseButtonsComboBox.Enabled; } 
               set { MouseButtonsComboBox.Enabled = value ; }
            }
            
            public bool CanChangeFeatureId 
            { 
               get { return FeautreIdTextBox.Enabled ; }
               set { FeautreIdTextBox.Enabled = value ; }
            }
            
         #endregion
         
         #region Events
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
         #region Callbacks
         
            public event EventHandler SelectedActionChanged ;
            public event EventHandler SelectedActionMouseButtonChanged ;
            public event EventHandler AddSelectedAction ;
            public event EventHandler RemoveSelectedAction ;
            public event CancelEventHandler ValidateFeatureId ;
            
         #endregion
         
      #endregion
      
      #region Protected
         
         #region Methods
            
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
         
            private void RegisterEvents ( )
            {
               ActionComboBox.SelectionChangeCommitted       += new EventHandler ( ActionComboBox_SelectionChangeCommitted ) ;
               MouseButtonsComboBox.SelectionChangeCommitted += new EventHandler ( MouseButtonsComboBox_SelectionChangeCommitted ) ;
               FeautreIdTextBox.Validating                   += new CancelEventHandler ( FeautreIdTextBox_Validating ) ;
               AddActionButton.Click                         += new EventHandler ( AddActionButton_Click ) ;
               RemoveActionButton.Click                      += new EventHandler ( RemoveActionButton_Click ) ;
               BrowseButton.Click                            += new EventHandler ( BrowseButton_Click ) ;
               AlternativeImageButton.Click                  += new EventHandler ( AlternativeImageButton_Click ) ;
            }

         #endregion
         
         #region Properties
            
         #endregion
         
         #region Events
         
            void ActionComboBox_SelectionChangeCommitted ( object sender, EventArgs e )
            {
               try
               {
                  if ( null != SelectedActionChanged ) 
                  {
                     SelectedActionChanged ( this, e ) ;
                  }
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }
            
            void MouseButtonsComboBox_SelectionChangeCommitted ( object sender, EventArgs e )
            {
               try
               {
                  if ( null != SelectedActionMouseButtonChanged ) 
                  {
                     SelectedActionMouseButtonChanged ( this, e ) ;
                  }
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }
            
            void FeautreIdTextBox_Validating(object sender, CancelEventArgs e)
            {
               try
               {
                  if ( null != ValidateFeatureId ) 
                  {
                     ValidateFeatureId ( this, e ) ;
                  }
               }
               catch ( Exception exception ) 
               {
                  e.Cancel = true ;
                  
                  Messager.ShowError ( this, exception ) ;
               }
            }
            
            void AddActionButton_Click(object sender, EventArgs e)
            {
               try
               {
                  if ( null != AddSelectedAction ) 
                  {
                     AddSelectedAction ( this, e ) ;
                  }
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }
            
            void RemoveActionButton_Click(object sender, EventArgs e)
            {
               try
               {
                  if ( null != RemoveSelectedAction ) 
                  {
                     RemoveSelectedAction ( this, e ) ;
                  }
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }
            
            void BrowseButton_Click ( object sender, EventArgs e )
            {
               try
               {
                  using ( OpenFileDialog openFileDlg = new OpenFileDialog ( ) )
                  {
                     openFileDlg.Filter = "Image Formats (*.jpg, *.bmp, *.ico)|*.jpg;*.bmp;*.ico" ;
                     
                     if ( openFileDlg.ShowDialog ( ) == DialogResult.OK ) 
                     {
                        ImagePictureBox.Image = Image.FromFile ( openFileDlg.FileName ) ;
                     }
                  }
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }
            
            void AlternativeImageButton_Click(object sender, EventArgs e)
            {
               try
               {
                  using ( OpenFileDialog openFileDlg = new OpenFileDialog ( ) )
                  {
                     openFileDlg.Filter = "Image Formats (*.jpg, *.bmp, *.ico)|*.jpg;*.bmp;*.ico" ;
                     
                     if ( openFileDlg.ShowDialog ( ) == DialogResult.OK ) 
                     {
                        AltImagePictureBox.Image = Image.FromFile ( openFileDlg.FileName ) ;
                     }
                  }
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }
            
         #endregion
         
         #region Data Members
            
         #endregion
         
         #region Data Types Definition
            
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
