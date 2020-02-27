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
using Leadtools.Demos;

namespace Leadtools.Medical.Winforms
{
   partial class StatusReport : Form
   {
      #region Public
         
         #region Methods
         
            private StatusReport ( )
            {
               InitializeComponent ( ) ;
               
               Init ( ) ;
               
               RegisterEvents ( ) ;
               
            }
            
            public void BeginOperation ( string operation )
            {
               btnClear.Enabled = false ;
               
               rtxtReport.AppendText ( operation ) ;
               rtxtReport.AppendText ( "\r\n" ) ;
               rtxtReport.AppendText ( "\r\n" ) ;
               
               rtxtReport.AppendText ( " " ) ; //to get replaced by the status 
               
               lastMessagePoistion = rtxtReport.Text.Length - 1 ;
               
               rtxtReport.AppendText ( "\r\n" ) ;
               
               rtxtReport.ScrollToCaret ( ) ;
            }
            
            public void OperationMainStatus ( string message ) 
            {
               int selectionLength ;
               
               if ( lastMessagePoistion == -1 )
               {
                  throw new InvalidOperationException ( "Must call BeginOperation before adding status message." ) ;
               }

               rtxtReport.SelectionStart = lastMessagePoistion ;
               
               if ( !string.IsNullOrEmpty ( lastMessage ) )
               {
                  selectionLength = lastMessage.Length ;
               }
               else
               {
                  selectionLength = 1 ;
                  
                  lastMessage = message ;
               }
               
               rtxtReport.SelectionLength = selectionLength ;
               rtxtReport.SelectedText    = message ;
               
               rtxtReport.SelectionStart = lastMessagePoistion ;
               rtxtReport.SelectionLength = message.Length ;
               rtxtReport.SelectionColor  = Color.DarkBlue ;
               
               lastMessage = message ;
               
               if ( selectionLength == 1 )
               {
                  rtxtReport.AppendText ( "\r\n" ) ;
               }
               
               rtxtReport.ScrollToCaret ( ) ;
            }
            
            
            public void AddOperationMainStatus ( string message ) 
            {
               if ( string.IsNullOrEmpty ( lastMessage ) )
               {
                  OperationMainStatus ( message ) ;
               }
               else
               {
                  lastMessagePoistion += lastMessage.Length ;
                  
                  rtxtReport.SelectionStart = lastMessagePoistion ;
                  
                  rtxtReport.AppendText ( "\r\n" ) ;
                  
                  rtxtReport.AppendText ( " " ) ; //to get replaced by the status 
                  
                  lastMessagePoistion += 3 ;
                  
                  lastMessage = "" ;
                  
                  //rtxtReport.AppendText ( "\r\n" ) ;
                  
                  OperationMainStatus ( message ) ;
               }
            }
            
            public void OperationAppendStatus ( string errorMessage, Color textColor ) 
            {
               int position ;
               
               if ( !string.IsNullOrEmpty ( lastMessage ) )
               {
                  if ( lastMessagePoistion >= rtxtReport.Text.Length - 1 )
                  {
                     rtxtReport.AppendText ( "\r\n" ) ;
                  }
               }
               
               position = rtxtReport.Text.Length ;
               
               rtxtReport.AppendText ( "   " + errorMessage ) ;
               
               rtxtReport.SelectionStart = position ;
               rtxtReport.SelectionLength = ( "   " + errorMessage ).Length ;
               rtxtReport.SelectionColor  = textColor ;
               
               rtxtReport.SelectionStart = rtxtReport.Text.Length - 1 ;
               
               rtxtReport.AppendText ( "\r\n" ) ;
               
               rtxtReport.ScrollToCaret ( ) ;
            }

            public void OperationErrorStatus(string errorMessage)
            {
               OperationAppendStatus(errorMessage, Color.Red);
            }

            public void OperationAppendStatus ( string errorMessage )
            {
               OperationAppendStatus(errorMessage, Color.DarkBlue);
            }

            
            public void EndOperation ( string message ) 
            {
               rtxtReport.AppendText ( "\r\n" ) ;
               rtxtReport.AppendText ( message ) ;
               rtxtReport.AppendText ( "\r\n" ) ;
               rtxtReport.AppendText ( "\r\n" ) ;
               
               rtxtReport.ScrollToCaret ( ) ;
               
               lastMessage = string.Empty ;
               
               btnClear.Enabled = true ;
            }
            
         #endregion
         
         #region Properties
         
            public static StatusReport Instance
            {
               get
               {
                  if ( null == _instance || _instance.IsDisposed )
                  {
                     _instance = new StatusReport ( ) ;
                  }
                  
                  return _instance ;
               }
            }
            
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
         
            static StatusReport ( ) 
            {
               _instance = new StatusReport ( ) ;
            }
            
            
            private void Init ( ) 
            {
            }
            
            private void RegisterEvents ( ) 
            {
               btnClear.Click      += new EventHandler ( btnClear_Click ) ;
               btnClose.Click      += new EventHandler ( btnClose_Click ) ;
               this.FormClosing    += new FormClosingEventHandler(StatusReport_FormClosing);
               this.VisibleChanged += new EventHandler ( StatusReport_VisibleChanged ) ;
               this.Load += new EventHandler(StatusReport_Load);
            }

            void StatusReport_Load(object sender, EventArgs e)
            {
               try
               {
                  TopLevel = true ;
               }
               catch {}
            }

         #endregion
         
         #region Properties
            
         #endregion
         
         #region Events
         
            private void btnClear_Click ( object sender, EventArgs e )
            {
               try
               {
                  if ( Messager.ShowQuestion ( this, "Are you sure you want to clear all status?", MessageBoxButtons.YesNo ) == DialogResult.Yes )
                  {
                     rtxtReport.Clear ( ) ;
                     
                     lastMessage = string.Empty ;
                     lastMessagePoistion = -1 ;
                  }
               }
               catch ( Exception )
               {}
            }
            
            void btnClose_Click ( object sender, EventArgs e )
            {
               if ( this.Owner != null ) 
               {
                  this.Owner.Focus ( ) ;
               }
               
               this.Hide ( ) ;
            }
            
            void StatusReport_FormClosing ( object sender, FormClosingEventArgs e )
            {
               try
               {
                  if ( e.CloseReason == CloseReason.UserClosing )
                  {
                     e.Cancel = true ;
                     
                     if ( this.Owner != null ) 
                     {
                        this.Owner.Focus ( ) ;
                     }
                     
                     this.Hide ( ) ;
                  }
                  
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
               }
            }
            
            void StatusReport_VisibleChanged(object sender, EventArgs e)
            {
               if ( Visible ) 
               {
                  rtxtReport.ScrollToCaret ( ) ;
               }
            }
            
         #endregion
         
         #region Data Members
         
            private static StatusReport _instance ;
            private string lastMessage = string.Empty ;
            private int lastMessagePoistion = -1 ;
            
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
