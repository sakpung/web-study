// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Leadtools.Demos;
using Leadtools.Dicom;

namespace Leadtools.Medical.Media.AddIns.UI
{
   public partial class AutoCreationConfigView : UserControl, IAutoCreationConfigView
   {
      #region Public
         
         #region Methods
         
            public AutoCreationConfigView ( )
            {
               InitializeComponent ( ) ;
               
               SaveConfigButton.Enabled = false ;
            }
            
            public void LoadConfiguration ( MediaAutoCreationConfiguration configuration )
            {
               Init ( configuration ) ;
               
               RegisterEvents ( ) ;
            }
            
            public void OnChangesSaved ( ) 
            {
               try
               {
                  SaveConfigButton.Enabled = false ;
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }
            
            public void NotifyViewConfigurationChanged ( ) 
            {
               try
               {
                  SaveConfigButton.Enabled = true ;
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }

         #endregion
         
         #region Properties
            
         #endregion
         
         #region Events
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
         #region Callbacks
            
            public event EventHandler SaveConfiguration ;
            public event EventHandler ViewConfigurationChanged ;
            
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
         
            private void Init ( MediaAutoCreationConfiguration configuration )
            {
               __Configuration = configuration ;
               
               AutoMediaCreationCheckBox.Checked = configuration.EnableAutoMediaCreation ;
               RejectNonBlankCheckBox.Checked    = configuration.RejectIfNotBlank ;
               CloseDiscCheckBox.Checked         = configuration.CloseDisc ;
               VerifyDiscCheckBox.Checked        = configuration.VerifyDisc ;
               ManualLoadCheckBox.Checked        = configuration.ManualLoadUnload ;
               TestDiscCreationCheckBox.Checked  = configuration.TestRecording ;
               DiscLabelingCheckBox.Checked      = configuration.EnableLabeling ;
               
               ImageFileTextBox.Text = configuration.LabelImage ;
               
               foreach ( LabelPrinting label in configuration.Labels )
               {
                  LabelsListBox.Items.Add ( label ) ;
               }
               
               UpdateLabelButtonsState ( ) ;
            }

            private void RegisterEvents ( )
            {
               AutoMediaCreationCheckBox.CheckedChanged += new EventHandler ( AutoMediaCreationCheckBox_CheckedChanged ) ;
               RejectNonBlankCheckBox.CheckedChanged    += new EventHandler ( RejectNonBlankCheckBox_CheckedChanged ) ;
               CloseDiscCheckBox.CheckedChanged         += new EventHandler ( CloseDiscCheckBox_CheckedChanged ) ;
               VerifyDiscCheckBox.CheckedChanged        += new EventHandler ( VerifyDiscCheckBox_CheckedChanged ) ;
               ManualLoadCheckBox.CheckedChanged        += new EventHandler ( ManualLoadCheckBox_CheckedChanged ) ;
               TestDiscCreationCheckBox.CheckedChanged  += new EventHandler ( TestDiscCreationCheckBox_CheckedChanged ) ;
               DiscLabelingCheckBox.CheckedChanged      += new EventHandler ( DiscLabelingCheckBox_CheckedChanged ) ;
               ImageFileBrowseButton.Click              += new EventHandler ( ImageFileBrowseButton_Click ) ;
               AddLabelButton.Click                     += new EventHandler ( AddLabelButton_Click ) ;
               EditLabelButton.Click                    += new EventHandler ( EditLabelButton_Click ) ;
               RemoveLabelButton.Click                  += new EventHandler ( RemoveLabelButton_Click ) ;
               SaveConfigButton.Click                   += new EventHandler ( SaveConfigButton_Click ) ;
               MoveLabelDownButton.Click                += new EventHandler ( MoveLabelDownButton_Click ) ;
               MoveLabelUpButton.Click                  += new EventHandler ( MoveLabelUpButton_Click ) ;

               LabelsListBox.SelectedIndexChanged += new EventHandler ( LabelsListBox_SelectedIndexChanged ) ;
               LabelsListBox.DoubleClick          += new EventHandler ( EditLabelButton_Click ) ;
            }

            private void AddLabel ( LabelPrinting newLabel )
            {
               LabelsListBox.Items.Add ( newLabel ) ;
               
               __Configuration.Labels.Add ( newLabel ) ;
            }
            
            private void RefreshLabel ( int index )
            {
               LabelsListBox.Items [ index ] = __Configuration.Labels [ index ] ;
            }
            
            private void RemoveLabel ( int labelIndex )
            {
               LabelsListBox.Items.RemoveAt ( labelIndex ) ;
               
               __Configuration.Labels.RemoveAt ( labelIndex ) ;
            }

            private void ChangeSelectedLabelIndex ( int newIndex )
            {
               object        selectedItem ;
               LabelPrinting selectedLabel ;
               
               selectedItem = LabelsListBox.Items [ LabelsListBox.SelectedIndex ] ;
               
               LabelsListBox.Items [ LabelsListBox.SelectedIndex ] = LabelsListBox.Items [ newIndex ] ;
               LabelsListBox.Items [ newIndex ]                    = selectedItem ;
               
               selectedLabel = __Configuration.Labels [ LabelsListBox.SelectedIndex ] ;
               
               __Configuration.Labels [ LabelsListBox.SelectedIndex ] = __Configuration.Labels [ newIndex ] ;
               __Configuration.Labels [ newIndex ]                    = selectedLabel ;
               
               LabelsListBox.SelectedIndex = newIndex ;
               
               UpdateUpDownButtonState ( ) ;
            }
            
            private void UpdateLabelButtonsState ( )
            {
               EditLabelButton.Enabled     = LabelsListBox.SelectedIndex != -1 ;
               RemoveLabelButton.Enabled   = LabelsListBox.SelectedIndex != -1 ;
               
               UpdateUpDownButtonState ( ) ;
            }

            private void UpdateUpDownButtonState ( )
            {
               MoveLabelUpButton.Enabled   = LabelsListBox.SelectedIndex > 0 ;
               MoveLabelDownButton.Enabled = LabelsListBox.SelectedIndex < LabelsListBox.Items.Count - 1 && LabelsListBox.SelectedIndex != -1 ;
            }
            
            private void OnChanged( )
            {
               if ( null != ViewConfigurationChanged ) 
               {
                  ViewConfigurationChanged ( this, EventArgs.Empty ) ;
               }
            }
            
         #endregion
         
         #region Properties
         
            private MediaAutoCreationConfiguration __Configuration
            {
               get ;
               set ;
            }
            
         #endregion
         
         #region Events
         
            void AutoMediaCreationCheckBox_CheckedChanged ( object sender, EventArgs e )
            {
               try
               {
                  __Configuration.EnableAutoMediaCreation = AutoMediaCreationCheckBox.Checked ;
                  
                  OnChanged ( ) ;
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }
            
            void DiscLabelingCheckBox_CheckedChanged ( object sender, EventArgs e )
            {
               try
               {
                  __Configuration.EnableLabeling = DiscLabelingCheckBox.Checked ;
                  
                  OnChanged ( ) ;
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }

            void TestDiscCreationCheckBox_CheckedChanged ( object sender, EventArgs e )
            {
               try
               {
                  __Configuration.TestRecording = TestDiscCreationCheckBox.Checked ;
                  
                  OnChanged ( ) ;
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }

            void ManualLoadCheckBox_CheckedChanged ( object sender, EventArgs e )
            {
               try
               {
                  __Configuration.ManualLoadUnload = ManualLoadCheckBox.Checked ;
                  
                  OnChanged ( ) ;
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }

            void VerifyDiscCheckBox_CheckedChanged ( object sender, EventArgs e )
            {
               try
               {
                  __Configuration.VerifyDisc = VerifyDiscCheckBox.Checked ;
                  
                  OnChanged ( ) ;
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }

            void CloseDiscCheckBox_CheckedChanged ( object sender, EventArgs e )
            {
               try
               {
                  __Configuration.CloseDisc = CloseDiscCheckBox.Checked ;
                  
                  OnChanged ( ) ;
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }

            void RejectNonBlankCheckBox_CheckedChanged ( object sender, EventArgs e )
            {
               try
               {
                  __Configuration.RejectIfNotBlank = RejectNonBlankCheckBox.Checked ;
                  
                  OnChanged ( ) ;
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }

            void ImageFileBrowseButton_Click ( object sender, EventArgs e )
            {
               try
               {
                  OpenFileDialog openFileDlg = new OpenFileDialog ( ) ;
                  
                  
                  openFileDlg.FileName = ImageFileTextBox.Text ;
                  
                  openFileDlg.Filter = "All Supported Formats (*.BMP;*.JPG;*.STD;*.PRN)|*.BMP;*.JPG;*.STD;*.PRN|" + 
                                       "Image Files(*.BMP;*.JPG)|*.BMP;*.JPG|" + 
                                       "SureThing (*.STD)|*.STD|Printer Text File (*.PRN)|*.PRN|All Files(*.*)|*.*" ;
                  
                  if ( openFileDlg.ShowDialog ( ) == DialogResult.OK )
                  {
                     ImageFileTextBox.Text = openFileDlg.FileName ;
                     
                     __Configuration.LabelImage = ImageFileTextBox.Text ;
                     
                     OnChanged ( ) ;
                  }
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }
            
            void AddLabelButton_Click ( object sender, EventArgs e )
            {
               try
               {
                  LabelPrinting newLabel ;
                  LabelingView  labeling ;
                  
                  
                  newLabel = new LabelPrinting ( ) ;
                  labeling = new LabelingView ( ) ;
                  
                  labeling.SetLabel ( newLabel, 
                                      new long[] { DicomTag.PatientName, DicomTag.PatientSex, DicomTag.PatientAge, DicomTag.PatientBirthDate, DicomTag.ReferringPhysicianName } ) ;
               
                  if ( labeling.ShowDialog ( ) == DialogResult.OK ) 
                  {
                     AddLabel ( newLabel ) ;
                     
                     UpdateUpDownButtonState ( ) ;
                     
                     OnChanged ( ) ;
                  }
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }
            
            void EditLabelButton_Click ( object sender, EventArgs e )
            {
               try
               {
                  if ( LabelsListBox.SelectedIndex != -1 )
                  {
                     LabelPrinting currentLabel ;
                     LabelingView  labeling ;
                     
                     
                     currentLabel = __Configuration.Labels [ LabelsListBox.SelectedIndex ] ;
                     labeling     = new LabelingView ( ) ;
                     
                     labeling.SetLabel ( currentLabel, 
                                         new long[] { DicomTag.PatientName, DicomTag.PatientSex, DicomTag.PatientAge, DicomTag.PatientBirthDate, DicomTag.ReferringPhysicianName } ) ;
                  
                     if ( labeling.ShowDialog ( ) == DialogResult.OK ) 
                     {
                        RefreshLabel ( LabelsListBox.SelectedIndex ) ;
                        
                        UpdateUpDownButtonState ( ) ;
                        
                        OnChanged ( ) ;
                     }
                  }
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }
            
            void RemoveLabelButton_Click(object sender, EventArgs e)
            {
               try
               {
                  if ( LabelsListBox.SelectedIndex != -1 )
                  {
                     RemoveLabel ( LabelsListBox.SelectedIndex ) ;
                     
                     UpdateLabelButtonsState ( ) ;
                     
                     UpdateUpDownButtonState ( ) ;
                     
                     OnChanged ( ) ;
                  }
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }
            
            void LabelsListBox_SelectedIndexChanged ( object sender, EventArgs e )
            {
               try
               {
                  UpdateLabelButtonsState ( ) ;
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }
            
            void MoveLabelUpButton_Click ( object sender, EventArgs e )
            {
               try
               {
                  if ( LabelsListBox.SelectedIndex > 0 )
                  {
                     ChangeSelectedLabelIndex ( LabelsListBox.SelectedIndex - 1 ) ;
                  }
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }
            
            void MoveLabelDownButton_Click(object sender, EventArgs e)
            {
               try
               {
                  if ( LabelsListBox.SelectedIndex < __Configuration.Labels.Count -1 )
                  {
                     ChangeSelectedLabelIndex ( LabelsListBox.SelectedIndex + 1 ) ;
                  }
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }

            void SaveConfigButton_Click ( object sender, EventArgs e )
            {
               try
               {
                  if ( null != SaveConfiguration ) 
                  {
                     SaveConfiguration ( this, EventArgs.Empty ) ;
                     
                     SaveConfigButton.Enabled = false ;
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
