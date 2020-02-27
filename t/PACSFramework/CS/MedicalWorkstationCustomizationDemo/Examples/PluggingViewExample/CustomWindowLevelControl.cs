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
using Leadtools.Medical.Workstation.Interfaces.Views;
using Leadtools.Medical.Workstation;
using Leadtools.Medical.Workstation.Interfaces;

namespace Leadtools.Demos.Workstation.Customized
{
   public partial class CustomWindowLevelControl : UserControl, IWindowLevelView, IWorkstationInitializer
   {
      public CustomWindowLevelControl()
      {
         InitializeComponent ( ) ;
         
         __SourceWindowLevelPreset = new List<WindowLevelInformation> ( ) ;
         __CustomWindowLevelInfo   = new WindowLevelInformation ( WindowWidth, WindowCenter, "Custom", Keys.None ) ;
         
         MinimumCenter = 0 ;
         MinimumWidth  = 0 ;
         MaximumCenter = 255 ;
         MaximumWidth  = 255 ;
         WindowCenter = 100 ;
         WindowWidth  = 100 ;
         
         AutoWindowLevelButton.Click             += new EventHandler ( OnAutoWindowLevel ) ;
         CloseButton.Click                       += new EventHandler ( CloseButton_Click ) ;
         PresetComboBox.SelectionChangeCommitted += new EventHandler ( PresetComboBox_SelectionChangeCommitted ) ; 
         RegisterEvents ( ) ;
      }

      void PresetComboBox_SelectionChangeCommitted(object sender, EventArgs e)
      {
         try
         {
            if ( PresetComboBox.SelectedItem != __CustomWindowLevelInfo && 
                 PresetComboBox.SelectedItem is WindowLevelInformation )
            {
               WindowLevelInformation preset ;
               
               
               preset = ( WindowLevelInformation ) PresetComboBox.SelectedItem ;
               
               BeginInit ( ) ;
               WindowCenter = preset.Center ;
               WindowWidth  = preset.Width ;
               EndInit ( ) ;
               
               OnWindowLevelChanged ( ) ;
            }
         }
         catch ( Exception exception ) 
         {
            System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
         }
      }

      void CloseButton_Click ( object sender, EventArgs e )
      {
         this.Parent.Controls.Remove ( this ) ;
         
         this.Dispose ( ) ;
      }

      private void RegisterEvents ( )
      {
         WindowCenterNumericUpDown.Validating  += new System.ComponentModel.CancelEventHandler(this.WindowCenterNumericUpDown_Validating);
         WindowCenterNumericUpDown.TextChanged += new System.EventHandler(this.WindowNumericUpDown_TextChanged);
         WindowWidthNumericUpDown.Validating  += new System.ComponentModel.CancelEventHandler(this.WindowCenterNumericUpDown_Validating);
         WindowWidthNumericUpDown.TextChanged += new EventHandler ( this.WindowNumericUpDown_TextChanged ) ;
      }
      
      private void UnregisterEvents ( )
      {
         WindowCenterNumericUpDown.Validating  -= new System.ComponentModel.CancelEventHandler(this.WindowCenterNumericUpDown_Validating);
         WindowCenterNumericUpDown.TextChanged -= new System.EventHandler(this.WindowNumericUpDown_TextChanged);
         WindowWidthNumericUpDown.Validating   -= new System.ComponentModel.CancelEventHandler(WindowWidthNumericUpDown_Validating);
         WindowWidthNumericUpDown.TextChanged  -= new EventHandler ( this.WindowNumericUpDown_TextChanged ) ;
      }
      
      private void WindowCenterNumericUpDown_Validating(object sender, CancelEventArgs e)
      {
         try
         {
            int centerValue ;
            
            
            centerValue = ( int ) WindowCenterNumericUpDown.Value ;
            
            if ( centerValue < MinimumCenter || centerValue > MaximumCenter )
            {
               e.Cancel = true ;
               
               return ;
            }
         }
         catch ( Exception exception ) 
         {
            System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
         }
      }
      
      private void WindowWidthNumericUpDown_Validating ( object sender, CancelEventArgs e )
      {
         try
         {
            int widthValue ;
            
            widthValue = ( int ) WindowWidthNumericUpDown.Value ;
            
            if ( widthValue < MinimumWidth || widthValue > MaximumWidth )
            {
               e.Cancel = true ;
               
               return ;
            }
         }
         catch ( Exception exception ) 
         {
            System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
         }
      }
      
      private void WindowNumericUpDown_TextChanged(object sender, EventArgs e)
      {
         try
         {
            OnWindowLevelChanged ( ) ;
         }
         catch ( Exception exception ) 
         {
            System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
         }
      }
      
      private void OnWindowLevelChanged ( ) 
      {
         if ( !_initializing )
         {
            WindowCenter = ( int ) WindowCenterNumericUpDown.Value ;
            WindowWidth  = ( int ) WindowWidthNumericUpDown.Value ;
            
            bool presetFound = false ;
            
            foreach ( WindowLevelInformation winLevel in __SourceWindowLevelPreset )
            {
               if ( winLevel.Width == WindowWidth &&
                    winLevel.Center == WindowCenter )
               {
                  PresetComboBox.SelectedItem = winLevel ;
                  
                  presetFound = true ;
                  
                  break ;
               }
            }
            
            if ( !presetFound ) 
            {
               PresetComboBox.SelectedItem = __CustomWindowLevelInfo ;
            }
            
            if ( null != WindowLevelChanged )
            {
               WindowLevelChanged ( this, EventArgs.Empty ) ;
            }
         }
      }

      private void OnAutoWindowLevel ( object sender, EventArgs e ) 
      {
         if ( null != AutoWindowLevel ) 
         {
            AutoWindowLevel ( sender, e ) ;
         }
      }
      
      private void OnDeactivated ( ) 
      {
         if ( !_isDeactivated )
         {
            if ( null != DeActivated )
            {
               DeActivated ( this, EventArgs.Empty ) ;
            }
            
            _isDeactivated = true ;
         }
      }
      
      #region IWindowLevelView Members

      public event EventHandler AutoWindowLevel;

      public void BeginInit()
      {
         if ( !_initializing ) 
         {
            _initializing = true ;
            
            UnregisterEvents ( ) ;
         }
      }

      public void EndInit()
      {
         if ( _initializing ) 
         {
            _initializing = false ;
            
            RegisterEvents ( ) ;
         }
      }

      public int MaximumCenter
      {
         get
         {
            return (int)WindowCenterNumericUpDown.Maximum ;
         }
         set
         {
            WindowCenterNumericUpDown.Maximum = value ;
         }
      }

      public int MaximumWidth
      {
         get
         {
            return (int) WindowWidthNumericUpDown.Maximum ;
         }
         set
         {
            WindowWidthNumericUpDown.Maximum = value ;
         }
      }

      public int MinimumCenter
      {
         get
         {
            return (int) WindowCenterNumericUpDown.Minimum ;
         }
         set
         {
            WindowCenterNumericUpDown.Minimum = value ;
         }
      }

      public int MinimumWidth
      {
         get
         {
            return (int) WindowWidthNumericUpDown.Minimum ;
         }
         set
         {
            __CustomWindowLevelInfo.Width = value ;
            
            WindowWidthNumericUpDown.Minimum = value ;
         }
      }

      public int WindowCenter
      {
         get
         {
            return (int) WindowCenterNumericUpDown.Value ;
         }
         set
         {
            __CustomWindowLevelInfo.Center = value ;
            
            WindowCenterNumericUpDown.Value = value ;
         }
      }

      public event EventHandler WindowLevelChanged;

      public WindowLevelInformation[] WindowLevelPreset
      {
         get 
         {
            if ( null != __SourceWindowLevelPreset )
            {
               return __SourceWindowLevelPreset.ToArray ( ) ;
            }
            else
            {
               return null ;
            }
         }
         
         set 
         {
            if ( null != value )
            {
               List <WindowLevelInformation> presetList ;
               
               
               __SourceWindowLevelPreset.Clear ( ) ;
               __SourceWindowLevelPreset.AddRange ( value ) ;
               
               presetList = new List<WindowLevelInformation> ( ) ;
               
               presetList.Add ( __CustomWindowLevelInfo ) ;
               presetList.AddRange ( value ) ;
               
               PresetComboBox.DataSource    = presetList ;
               PresetComboBox.DisplayMember = "Name" ; 
               PresetComboBox.Enabled       = true ;
            }
            else
            {
               PresetComboBox.DataSource = value ;
               PresetComboBox.Enabled = false ;
            }
         }
      }

      public int WindowWidth
      {
         get
         {
            return (int) WindowWidthNumericUpDown.Value ;
         }
         set
         {
            WindowWidthNumericUpDown.Value = value ;
         }
      }

      #endregion

      #region IWorkstationView Members

      public void ActivateView ( IWin32Window owner )
      {
         this.Dock = DockStyle.Right ;
         
         ViewerContainer.State.ActiveWorkstation.Controls.Add ( this ) ;
      }

      public event EventHandler DeActivated ;

      public void EnsureVisible(IWin32Window owner)
      {
         this.Visible = true ;
      }

      #endregion
      
      private WindowLevelInformation __CustomWindowLevelInfo
      {
         get ; 
         set ;
      }
      
      private List <WindowLevelInformation> __SourceWindowLevelPreset
      {
         get ;
         set ;
      }
      
      private bool _initializing ;
      
      private WorkstationContainer __viewerContainer ;
      private bool _isDeactivated ;

      #region IWorkstationInitializer Members

      public void Initialize(WorkstationContainer container)
      {
         __viewerContainer = container ;
      }

      public bool IsInitialized
      {
         get { return __viewerContainer != null ; }
      }

      public WorkstationContainer ViewerContainer
      {
         get { return __viewerContainer ; }
      }

      #endregion
   }
}
