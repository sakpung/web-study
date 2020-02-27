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

namespace Leadtools.Medical.Media.AddIns.UI
{
   public partial class MediaJobMaintenanceView : UserControl, IMediaJobMaintenanceView
   {
      #region Public
         
         #region Methods
         
            public MediaJobMaintenanceView ( )
            {
               InitializeComponent();
            }
            
            public void LoadMaintenanceConfiguration ( MediaMaintenanceState config )
            {
               Init ( config ) ;
               
               RegisterEvents ( ) ;
            }
            
            public void OnChangesSaved ( ) 
            {
               try
               {
                  __IsDirty = false ;
                  
                  SaveButton.Enabled = __IsDirty ;
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
                  __IsDirty = true ;
                  
                  SaveButton.Enabled = __IsDirty ;
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
            
            public event EventHandler SaveChanges ;
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
         #region Callbacks
            
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
         
            private void Init ( MediaMaintenanceState config )
            {
               string durationOption ;
               
               
               __Config          = config ;
               __DurationOptions = new List<string> ( ) ;
               
               __DurationOptions.Add ( "Minute(s)" ) ;
               __DurationOptions.Add ( "Day(s)" ) ;
               __DurationOptions.Add ( "Week(s)" ) ;
               
               SaveButton.Enabled = __IsDirty ;
               
               EnableMaintainanceCheckBox.Checked = config.Enabled ;
               
               IdleComboBox.DataSource       = __DurationOptions.ToArray ( ) ;
               PendingComboBox.DataSource    = __DurationOptions.ToArray ( ) ;
               ProcessingComboBox.DataSource = __DurationOptions.ToArray ( ) ;
               FailedComboBox.DataSource     = __DurationOptions.ToArray ( ) ;
               CompletedComboBox.DataSource  = __DurationOptions.ToArray ( ) ;
               
               IdleNumericUpDown.Value   = GetDurationValue ( config.KeepIdleDurationInMinutes, out durationOption ) ;
               IdleComboBox.SelectedItem = durationOption ;
               
               PendingNumericUpDown.Value   = GetDurationValue ( config.KeepPendingDurationInMinutes, out durationOption ) ;
               PendingComboBox.SelectedItem = durationOption ;
               
               ProcessingNumericUpDown.Value   = GetDurationValue ( config.KeepProcessingDurationInMinutes, out durationOption ) ;
               ProcessingComboBox.SelectedItem = durationOption ;
               
               FailedNumericUpDown.Value   = GetDurationValue ( config.KeepFailedDurationInMinutes, out durationOption ) ;
               FailedComboBox.SelectedItem = durationOption ;
               
               CompletedNumericUpDown.Value   = GetDurationValue ( config.KeepCompletedDurationInMinutes, out durationOption ) ;
               CompletedComboBox.SelectedItem = durationOption ;
            }
            
            private void RegisterEvents ( )
            {
               EnableMaintainanceCheckBox.CheckedChanged += new EventHandler ( EnableMaintainanceCheckBox_CheckedChanged ) ;
               
               IdleComboBox.SelectionChangeCommitted       += new EventHandler ( OnIdleChanged ) ;
               PendingComboBox.SelectionChangeCommitted    += new EventHandler ( OnPendingChanged ) ;
               ProcessingComboBox.SelectionChangeCommitted += new EventHandler ( OnProcessingChanged ) ;
               FailedComboBox.SelectionChangeCommitted     += new EventHandler ( OnFailedChanged ) ;
               CompletedComboBox.SelectionChangeCommitted  += new EventHandler ( OnCompletedChanged ) ;
               
               IdleNumericUpDown.ValueChanged       += new EventHandler ( OnIdleChanged ) ;
               PendingNumericUpDown.ValueChanged    += new EventHandler ( OnPendingChanged ) ;
               ProcessingNumericUpDown.ValueChanged += new EventHandler ( OnProcessingChanged ) ;
               FailedNumericUpDown.ValueChanged     += new EventHandler ( OnFailedChanged ) ;
               CompletedNumericUpDown.ValueChanged  += new EventHandler ( OnCompletedChanged ) ;

               SaveButton.Click += new EventHandler ( SaveButton_Click ) ;
            }

            private void OnChanged ( )
            {
               if ( null != ViewConfigurationChanged ) 
               {
                  ViewConfigurationChanged ( this, EventArgs.Empty ) ;
               }
            }
            
            private int GetMinutesValue ( int durationValue, string durationOption )
            {
               int durationOptionIndex ;
               
               
               durationOptionIndex = __DurationOptions.IndexOf ( durationOption ) ;
               
               if ( durationOptionIndex < 0 )
               {
                  throw new InvalidOperationException ( "Invalid duration option" ) ;
               }
               
               switch ( durationOptionIndex ) 
               {
                  case 0:
                  {
                     return durationValue ;
                  }
                  
                  case 1:
                  {
                     return durationValue * ( 24 * 60 ) ;
                  }
                  
                  case 2:
                  {
                     return durationValue * ( 7 * 24 * 60 ) ;
                  }
                  
                  default:
                  {
                     throw new InvalidOperationException ( "Invalid duration option" ) ;
                  }
               }
            }
         
            private int GetDurationValue ( int durationInMinutes, out string durationOption )
            {
               if ( durationInMinutes % ( 24 * 60 * 7 )  == 0 )
               {
                  durationOption = __DurationOptions [ 2 ] ;
                  
                  return ( int ) ( durationInMinutes / ( 24 * 60 * 7 ) ) ;
               }
               else if ( durationInMinutes % ( 24 * 60 )  == 0 )
               {
                  durationOption = __DurationOptions [ 1 ] ;
                  
                  return ( int ) ( durationInMinutes / ( 24 * 60 ) ) ;
               }
               else
               {
                  durationOption = __DurationOptions [ 0 ] ;
                  
                  return durationInMinutes ;
               }
            }
            
         #endregion
         
         #region Properties
         
            private bool __IsDirty
            {
               get ;
               set ;
            }
            
            private MediaMaintenanceState __Config
            {
               get ;
               set ;
            }
            
            private List <string> __DurationOptions
            {
               get ;
               set ;
            }
            
         #endregion
         
         #region Events
         
            void EnableMaintainanceCheckBox_CheckedChanged ( object sender, EventArgs e )
            {
               try
               {
                  __Config.Enabled = EnableMaintainanceCheckBox.Checked ;
                  
                  OnChanged ( ) ;
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }
         
            void OnIdleChanged ( object sender, EventArgs e )
            {
               try
               {
                  __Config.KeepIdleDurationInMinutes = GetMinutesValue ( (int) IdleNumericUpDown.Value, (string) IdleComboBox.SelectedItem ) ;
                  
                  OnChanged ( ) ;
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }
            
            void OnCompletedChanged ( object sender, EventArgs e )
            {
               try
               {
                  __Config.KeepCompletedDurationInMinutes = GetMinutesValue ( (int) CompletedNumericUpDown.Value, (string) CompletedComboBox.SelectedItem ) ;
                  
                  OnChanged ( ) ;
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }

            void OnFailedChanged ( object sender, EventArgs e )
            {
               try
               {
                  __Config.KeepFailedDurationInMinutes = GetMinutesValue ( (int) FailedNumericUpDown.Value, (string) FailedComboBox.SelectedItem ) ;
                  
                  OnChanged ( ) ;
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }

            void OnProcessingChanged ( object sender, EventArgs e )
            {
               try
               {
                  __Config.KeepProcessingDurationInMinutes = GetMinutesValue ( (int) ProcessingNumericUpDown.Value, (string) ProcessingComboBox.SelectedItem ) ;
                  
                  OnChanged ( ) ;
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }

            void OnPendingChanged ( object sender, EventArgs e )
            {
               try
               {
                  __Config.KeepPendingDurationInMinutes = GetMinutesValue ( (int) PendingNumericUpDown.Value, (string) PendingComboBox.SelectedItem ) ;
                  
                  OnChanged ( ) ;
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }
            
            void SaveButton_Click ( object sender, EventArgs e )
            {
               try
               {
                  if ( SaveChanges != null ) 
                  {
                     SaveChanges ( this, EventArgs.Empty ) ;
                     
                     SaveButton.Enabled = false ;
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
