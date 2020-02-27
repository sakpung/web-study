// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.Winforms;
using System.Threading;
using Leadtools.Logging;
using Leadtools.Medical.Logging.Addins.Commands;
using Leadtools.Dicom;
using Leadtools.Logging.Medical;

namespace Leadtools.Medical.Logging.Addins
{
   class CommandAsyncProcessor
   {
      #region Public
         
         #region Methods
         
            public CommandAsyncProcessor ( ) 
            {
               Commands = new List<ICommand> ( ) ;
               
               Interval = new TimeSpan ( 1, 0,0,0 )  ;
               Stopped           = true ;
            }
            
            public void Start ( ) 
            {
               if ( Stopped )
               {
                  Stopped = false ;
                  
                  __Timer = new Timer ( StartProcessing, null, DueTime, Interval ) ;
               }
            }
            
            public void RefreshDueIntervalTimes ( ) 
            {
               if ( !Stopped && __Timer != null ) 
               {
                  __Timer.Change ( DueTime, Interval ) ;
               }
            }
            
            public void Stop ( ) 
            {
               try
               {
                  if ( Disposed ) 
                  {
                     throw new ObjectDisposedException ( this.GetType ( ).Name ) ;
                  }
                  
                  if ( !Stopped )
                  {
                     Stopped = true ;
                     
                     __Timer.Dispose ( ) ;
                     
                     __Timer = null ;
                  }
               }
               catch ( ThreadAbortException )
               {}
            }
            
            public void Dispose ( )
            {
               try
               {
                  if ( !Disposed && !Stopped ) 
                  {
                     OnDisposing ( ) ;
                     
                     Stop ( ) ;
                     
                     Disposed = true ;
                  }
               }
               catch {}
            }
         
         #endregion
         
         #region Properties
         
            public bool Disposed
            {
               get ;
               private set ;
            }
            
            public bool Stopped
            {
               get ;
               private set ;
            }
            
            public List <ICommand> Commands
            {
               get ;
               set ;
            }
            
            public TimeSpan Interval
            {
               get ;
               set ;
            }
            
            public TimeSpan DueTime
            {
               get ;
               set ;
            }
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
         #region Callbacks
         
            public event EventHandler Disposing ;
            
            public event EventHandler CommandsExecuted ;
            
         #endregion
         
      #endregion
      
      #region Protected
         
         #region Methods
         
            protected virtual void OnDisposing ( )
            {
               if ( null != Disposing ) 
               {
                  Disposing ( this, EventArgs.Empty ) ;
               }
            }
            
         #endregion
         
         #region Properties
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
      #endregion
      
      #region Private
         
         #region Methods
         
            private void StartProcessing ( object nullState )
            {
               try
               {
                  if ( Commands.Count != 0 ) 
                  {
                     foreach ( ICommand command in Commands )
                     {
                        command.Execute ( ) ;
                     }
                     
                     OnCommandsExecuted ( ) ;
                  }
               }
               catch ( ThreadInterruptedException ){}
               catch ( ThreadAbortException ){}
               catch ( Exception exception ) 
               {
                  try
                  {
                     Logger.Global.Log ( string.Empty, 
                                         string.Empty, 
                                         0, 
                                         string.Empty, 
                                         string.Empty,
                                         -1,
                                         DicomCommandType.Undefined,
                                         DateTime.Now, 
                                         LogType.Error, 
                                         MessageDirection.None,
                                         exception.Message,
                                         null,
                                         null ) ;
                  }
                  catch {}
               }
            }

            private void OnCommandsExecuted()
            {
               if ( null != CommandsExecuted ) 
               {
                  CommandsExecuted ( this, EventArgs.Empty ) ;
               }
            }
            
         #endregion
         
         #region Properties
         
            private System.Threading.Timer __Timer
            {
               get ;
               set ;
            }
            
         #endregion
         
         #region Events
         
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
