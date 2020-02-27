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

namespace Leadtools.Demos.StorageServer
{
   public partial class ServerNetworkingView : UserControl
   {
      #region Public
         
         #region Methods
         
            public ServerNetworkingView ( )
            {
               InitializeComponent ( ) ;

               PDUMaxLengthCheckBox.CheckedChanged += new EventHandler(PDUMaxLengthCheckBox_CheckedChanged);
               
               PDUMaxLengthCheckBox.CheckedChanged     += new EventHandler ( OnSettingsChanged ) ;
               NoDelayCheckBox.CheckedChanged          += new EventHandler ( OnSettingsChanged ) ;
               PDUMaxLengthNumericUpDown.ValueChanged  += new EventHandler ( OnSettingsChanged ) ;
               ReceiveBufferNumericUpDown.ValueChanged += new EventHandler ( OnSettingsChanged ) ;
               SendBufferNumericUpDown.ValueChanged    += new EventHandler ( OnSettingsChanged ) ;
            }

            public bool IsMaxPduLengthChecked
            {
               get
               {
                  return PDUMaxLengthCheckBox.Checked ;
               }

               set
               {
                  PDUMaxLengthCheckBox.Checked = value ;

                  PDUMaxLengthNumericUpDown.Enabled = value ;
               }
            }
         
         #endregion
         
         #region Properties
         
            public int MaxPduLength
            {
               get
               {
                  return (int) PDUMaxLengthNumericUpDown.Value ;
               }

               set
               {
                  PDUMaxLengthNumericUpDown.Value = value ;
               }
            }

            public int ReceiveBufferSize
            {
               get
               {
                  return (int) ReceiveBufferNumericUpDown.Value ;
               }

               set
               {
                  ReceiveBufferNumericUpDown.Value = value ;
               }
            }

            public int SendBufferSize
            {
               get
               {
                  return (int) SendBufferNumericUpDown.Value ;
               }

               set
               {
                  SendBufferNumericUpDown.Value = value ;
               }
            }

            public bool NoDelay
            {
               get
               {
                  return NoDelayCheckBox.Checked ;
               }

               set
               {
                  NoDelayCheckBox.Checked = value ;
               }
            }
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
         #region Callbacks
         
            public event EventHandler SettingsChanged ;
            
         #endregion
         
      #endregion
      
      #region Protected
         
         #region Methods
            
         #endregion
         
         #region Properties
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
      #endregion
      
      #region Private
         
         #region Methods
            
         #endregion
         
         #region Properties
            
         #endregion
         
         #region Events
         
            public void OnSettingsChanged ( object sender, EventArgs e ) 
            {
               try
               {
                  if ( null != SettingsChanged ) 
                  {
                     SettingsChanged ( this, e ) ;
                  }
               }
               catch ( Exception ex ) 
               {
                  Messager.ShowError ( this, ex ) ;
               }
            }

            void PDUMaxLengthCheckBox_CheckedChanged ( object sender, EventArgs e )
            {
               try
               {
                  PDUMaxLengthNumericUpDown.Enabled = PDUMaxLengthCheckBox.Checked ;
               }
               catch ( Exception ex ) 
               {
                  Messager.ShowError ( this, ex ) ;
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
         
         #region Data Types Definition
            
         #endregion
         
         #region Callbacks
            
         #endregion
         
      #endregion
   }
}
