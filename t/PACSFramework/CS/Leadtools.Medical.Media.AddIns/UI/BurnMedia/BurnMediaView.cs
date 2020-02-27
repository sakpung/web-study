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
using Leadtools.Dicom.Common.DataTypes.MediaCreation;
using Leadtools.Demos;
using Leadtools.MediaWriter;

namespace Leadtools.Medical.Media.AddIns.UI
{
   public partial class BurnMediaView : UserControl, IBurnMediaView
   {
      #region Public
         
         #region Methods

            public BurnMediaView ( )
            {
               InitializeComponent ( ) ;
            }
            
            public void LoadMedia
            (
               MediaCreationManagement mediaObject
            )
            {
               Init ( mediaObject ) ;
               
               RegisterEvents ( ) ;
            }

            public void SetDrives ( MediaWriterDrive[] drives ) 
            {
               try
               {
                  DriveComboBox.DataSource    = new BindingList <MediaWriterDrive> ( drives ) ;
                  DriveComboBox.DisplayMember = "Name" ;
                  
                  if ( drives.Length > 0 ) 
                  {
                     UpdateSelectedDriveInformation ( ) ;
                  }
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }
            
            public void SetSpeeds ( MediaWriterSpeed[] speeds ) 
            {
               try
               {
                  SpeedComboBox.DataSource    = new BindingList <MediaWriterSpeed> ( speeds ) ;
                  SpeedComboBox.DisplayMember = "Name" ;
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }
            
            public void UpdateSelectedDriveInformation ( ) 
            {
               try
               {
                  if ( null != SelectedDrive && null != SelectedDrive.CurrentDiscType ) 
                  {
                     DiscTypeLabel.Text = SelectedDrive.CurrentDiscType.Name ;
                  }
                  else
                  {
                     DiscTypeLabel.Text = string.Empty ;
                  }

                  string sText = GetDiskCapacity ( );
                  
                  DiskCapacityLabel.Text = sText ;
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }
            
            public bool UserWantsToCancelCurrentOperation ( ) 
            {
               try
               {
                  return Messager.ShowQuestion ( this, 
                                                 "A disc operation is currently in progress. Are you sure you like to cancel?",
                                                 MessageBoxButtons.YesNo ) == DialogResult.Yes ;
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
                  
                  return false ;
               }
            }
            
            public void ReportProgress ( int completed, string description ) 
            {
               try
               {
                  ProgressValueLabel.Text = description ;
                  MediaProgressBar.Value  = completed ;
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }
            
            public void OnTestCompleted ( ) 
            {
               Messager.ShowInformation ( this, "Test completed successfully." ) ;

               ResetProgress ( ) ;
            }

            public void OnTestFailed ( Exception exception ) 
            {
               Messager.ShowError ( this, "Test failed.\n" + exception.Message ) ;
               
               ResetProgress ( ) ;
            }
            
            public void OnBurnCompleted ( ) 
            {
               Messager.ShowInformation ( this, "Disk burned successfully." ) ;
               
               ResetProgress ( ) ;
            }
            
            public void OnBurnFailed ( Exception exception ) 
            {
               Messager.ShowError ( this, "Disk burrning failed.\n" + exception.Message ) ;
               
               ResetProgress ( ) ;
            }
            
            public void OnBurnAborted ( ) 
            {
               Messager.ShowWarning ( this, "Burn operation aborted." ) ;
            
               ResetProgress ( ) ;
            }
            
            public void OnTestAborted ( ) 
            {
               Messager.ShowWarning ( this, "Test operation aborted." ) ;
            
               ResetProgress ( ) ;
            }
            
            public bool RequestNewDisc ( )
            {
               return Messager.ShowQuestion ( this, "Insert new disc.", MessageBoxButtons.OKCancel ) == DialogResult.OK ;
            }
            
            public void CleanUp ( )
            {
               try
               {
                  EjectButton.Click          -= new EventHandler ( EjectButton_Click ) ;
                  CancelActivityButton.Click -= new EventHandler ( CancelActivityButton_Click ) ;
                  TestButton.Click           -= new EventHandler ( TestButton_Click ) ;
                  BurnButton.Click           -= new EventHandler ( BurnButton_Click ) ;

                  CopiesNumericUpDown.ValueChanged -= new EventHandler ( CopiesNumericUpDown_ValueChanged ) ;
                  
                  VolumeNameTextBox.TextChanged          -= new EventHandler(VolumeNameTextBox_TextChanged);
                  DriveComboBox.SelectionChangeCommitted -= new EventHandler ( DriveComboBox_SelectionChangeCommitted ) ;
                  SpeedComboBox.SelectionChangeCommitted -= new EventHandler ( SpeedComboBox_SelectionChangeCommitted ) ;
               }
               catch ( Exception exception ) 
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
               }
            }
            

         #endregion
         
         #region Properties
         
            public MediaWriterDrive SelectedDrive
            {
               get 
               {
                  return DriveComboBox.SelectedItem as MediaWriterDrive ;
               }
               
               set
               {
                  if ( value != DriveComboBox.SelectedItem ) 
                  {
                     DriveComboBox.SelectedItem = value ;
                     
                     UpdateSelectedDriveInformation ( ) ;
                  }
               }
            }
            
            public MediaWriterSpeed SelectedSpeed
            {
               get 
               {
                  return SpeedComboBox.SelectedItem as MediaWriterSpeed ;
               }
               
               set
               {
                  if ( value != SpeedComboBox.SelectedItem ) 
                  {
                     SpeedComboBox.SelectedItem = value ;
                  }
               }
            }
            
            public int MaxProgressValue
            {
               set
               {
                  MediaProgressBar.Maximum = value ;
               }
            }
            
            public bool AutoEject
            {
               get
               {
                  return AutoEjectCheckBox.Checked ;
               }
            }
            
            public bool AutoTest
            {
               get
               {
                  return AutoTestCheckBox.Checked ;
               }
            }
            
            public bool CanEject
            {
               set 
               {
                  AutoEjectCheckBox.Enabled = value ;
                  EjectButton.Enabled       = value ;
               }
            }
            
            public bool CanCancel
            {
               set 
               {
                  CancelActivityButton.Enabled = value ;
               }
            }
            
            public bool CanTest
            {
               set 
               {
                  AutoTestCheckBox.Enabled = value ;
                  TestButton.Enabled       = value ;
                  
                  if ( value == false ) 
                  {
                     AutoTestCheckBox.Checked = false ;
                  }
               }
            }
            
            public bool CanBurn
            {
               set 
               {
                  BurnButton.Enabled = value ;
               }
            }
            
         #endregion
         
         #region Events
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
         #region Callbacks
         
            public event EventHandler Eject ;
            public event EventHandler Cancel ;
            public event EventHandler Test ;
            public event EventHandler Burn ;

            public event EventHandler VolumeNameChanged ;
            public event EventHandler SelectedDriveChanged ;
            public event EventHandler SelectedSpeedChanged ;
            
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
            
            private void Init 
            ( 
               MediaCreationManagement mediaObject
               
            )
            {
               __MediaObject = mediaObject ;
               
               VolumeNameTextBox.Text    = mediaObject.MediaSet.FileSetID ;
               MediaFolderTextBox.Text   = mediaObject.GetCreationPath ( ) ;
               CopiesNumericUpDown.Value = mediaObject.RequestInformation.NumberOfCopies.Value ;
            }
            
            private void RegisterEvents()
            {
               EjectButton.Click          += new EventHandler ( EjectButton_Click ) ;
               CancelActivityButton.Click += new EventHandler ( CancelActivityButton_Click ) ;
               TestButton.Click           += new EventHandler ( TestButton_Click ) ;
               BurnButton.Click           += new EventHandler ( BurnButton_Click ) ;
               
               CopiesNumericUpDown.ValueChanged += new EventHandler ( CopiesNumericUpDown_ValueChanged ) ;
               
               VolumeNameTextBox.TextChanged          += new EventHandler(VolumeNameTextBox_TextChanged);
               DriveComboBox.SelectionChangeCommitted += new EventHandler ( DriveComboBox_SelectionChangeCommitted ) ;
               SpeedComboBox.SelectionChangeCommitted += new EventHandler ( SpeedComboBox_SelectionChangeCommitted ) ;
            }

            private void OnVolumeNameChanged ( ) 
            {
               if ( null != VolumeNameChanged ) 
               {
                  VolumeNameChanged ( this, EventArgs.Empty ) ;
               }
            }
            
            private void OnSelectedDriveChanged ( ) 
            {
               if ( null != SelectedDriveChanged ) 
               {
                  SelectedDriveChanged ( this, EventArgs.Empty ) ;
               }
            }
            
            private void OnSelectedSpeedChanged ( ) 
            {
               if ( null != SelectedSpeedChanged ) 
               {
                  SelectedSpeedChanged ( this, EventArgs.Empty ) ;
               }
            }
            
            private void OnBurn ( ) 
            {
               if ( null != Burn ) 
               {
                  Burn ( this, EventArgs.Empty ) ;
               }
            }
            
            private void OnTest ( ) 
            {
               if ( null != Test ) 
               {
                  Test ( this, EventArgs.Empty ) ;
               }
            }
            
            private void OnCancel ( ) 
            {
               if ( null != Cancel ) 
               {
                  Cancel ( this, EventArgs.Empty ) ;
               }
            }
            
            private void OnEject ( ) 
            {
               if ( null != Eject ) 
               {
                  Eject ( this, EventArgs.Empty ) ;
               }
            }
            
            private string GetDiskCapacity ( )
            {
               double capacity ;
               double numberOfBytes;
               string formattedCapacity ;
               
               
               capacity      = SelectedDrive.DiscCapacity ;
               numberOfBytes = capacity * 2048;
               
               if ( numberOfBytes >= 0x40000000 )
               {
                  formattedCapacity = Convert.ToString ( numberOfBytes / 0x40000000 ) ;
                  
                  if ( formattedCapacity.Length > 5 )
                  {
                     formattedCapacity = formattedCapacity.Substring ( 0, 5 ) + " GB" ;
                  }
                  
               }
               else if ( numberOfBytes >= 0x100000 )
               {
                  formattedCapacity = Convert.ToString ( numberOfBytes / 0x100000 ) ;
                  
                  if ( formattedCapacity.Length > 4 ) 
                  {
                     formattedCapacity = formattedCapacity.Substring(0, 4) + " MB" ;
                  }
               }
               else
               {
                  formattedCapacity = Convert.ToString(numberOfBytes / 0x400) ;
                  
                  if ( formattedCapacity.Length > 3 ) 
                  {
                     formattedCapacity = formattedCapacity.Substring(0, 3) + " KB" ;
                  }
               }
               
               return formattedCapacity ;
            }
            
            private void ResetProgress ( )
            {
               ProgressValueLabel.Text = string.Empty;
               MediaProgressBar.Value  = 0 ;
            }
            
         #endregion
         
         #region Properties
         
            private MediaCreationManagement __MediaObject 
            {
               get ;
               set ;
            }
            
         #endregion
         
         #region Events
         
            void SpeedComboBox_SelectionChangeCommitted(object sender, EventArgs e)
            {
               try
               {
                  OnSelectedSpeedChanged ( ) ;
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }

            void VolumeNameTextBox_TextChanged ( object sender, EventArgs e )
            {
               try
               {
                  __MediaObject.MediaSet.FileSetID = VolumeNameTextBox.Text ;
                  
                  OnVolumeNameChanged ( ) ;
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }
            
            void DriveComboBox_SelectionChangeCommitted(object sender, EventArgs e)
            {
               try
               {
                  OnSelectedDriveChanged ( ) ;
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }
         
            void BurnButton_Click(object sender, EventArgs e)
            {
               try
               {
                  OnBurn ( ) ;
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }

            void TestButton_Click(object sender, EventArgs e)
            {
               try
               {
                  OnTest ( ) ;
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }

            void CancelActivityButton_Click(object sender, EventArgs e)
            {
               try
               {
                  OnCancel ( ) ;
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }

            void EjectButton_Click(object sender, EventArgs e)
            {
               try
               {
                  OnEject ( ) ;
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }
            
            void CopiesNumericUpDown_ValueChanged ( object sender, EventArgs e )
            {
               try
               {
                  __MediaObject.RequestInformation.NumberOfCopies = (int) CopiesNumericUpDown.Value ;
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
