// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Leadtools.Medical.Media.AddIns.Commands ;
using Leadtools.Logging;
using Leadtools.Dicom;
using Leadtools.Logging.Medical;

namespace Leadtools.Medical.Media.AddIns
{
   public class CommandAsyncProcessor : IDisposable
   {
      #region Public
         
         #region Methods
         
            public CommandAsyncProcessor ( ) 
            {
               Commands = new List<ICommand> ( ) ;
               
               IntervalInSeconds = 60 ;
               Stopped           = true ;
            }
            
            public void Start ( ) 
            {
               if ( Stopped )
               {
                  Stopped = false ;
                  
                  __WorkingThread = new Thread ( StartProcessing ) ;
                  
                  __WorkingThread.Start ( ) ;
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
                     
                     _processingEvent.Set ( ) ;
                     
                     __WorkingThread.Abort ( ) ;
                     
                     __WorkingThread = null ;
                  }
               }
               catch ( ThreadAbortException )
               {}
            }
            
            public void WaitAndStop ( ) 
            {
               try
               {
                  if ( !Stopped )
                  {
                     Stopped = true ;
                     
                     foreach ( ICancelExecute cancelCommand in Commands.OfType <ICancelExecute> ( ) )
                     {
                        cancelCommand.Cancel ( ) ;
                     }
                     
                     _processingEvent.Set ( ) ;
                     
                     __WorkingThread.Join ( ) ;
                     
                     __WorkingThread = null ;
                  }
               }
               catch ( ThreadAbortException )
               {}
            }
            
            public void SignalProcessor ( )
            {
               if ( null != _processingEvent ) 
               {
                  _processingEvent.Set ( ) ;
               }
               
            }
            
            public void Dispose ( )
            {
               try
               {
                  if ( !Stopped ) 
                  {
                     OnDisposing ( ) ;
                     
                     Stop ( ) ;
                     
                     _processingEvent.Close ( ) ;
                     
                     Disposed = true ;
                  }
               }
               catch {}
            }

            protected virtual void OnDisposing ( )
            {
               if ( null != Disposing ) 
               {
                  Disposing ( this, EventArgs.Empty ) ;
               }
            }
            
            public bool Disposed
            {
               get ;
               private set ;
            }
          
         #endregion
         
         #region Properties
         
            public bool Stopped
            {
               get ;
               private set ;
            }
            
            public int IntervalInSeconds
            {
               get ;
               set ;
            }
            
            public List <ICommand> Commands
            {
               get ;
               set ;
            }
            
         #endregion
         
         #region Events
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
         #region Callbacks
            
            public event EventHandler Disposing ;
         #endregion
         
      #endregion
      
      #region Protected
         
         #region Methods
         
            protected virtual void OnExecutingCommand ( )
            {
               
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
            
            private void StartProcessing ( )
            {
               try
               {
                  while ( !Stopped )
                  {
                     if ( Commands.Count != 0 ) 
                     {
                        OnExecutingCommand ( ) ;
                        
                        foreach ( ICommand command in Commands )
                        {
                           command.Execute ( ) ;
                        }
                     }
                     
                     
                     _processingEvent.WaitOne ( IntervalInSeconds * 1000, false ) ;
                     
                     //Thread.Sleep ( IntervalInSeconds * 1000 ) ;
                  }
               }
               catch ( ThreadInterruptedException ){}
               catch ( ThreadAbortException ){}
               catch ( Exception exception ) 
               {
                  try
                  {
                     Logger.Global.Log ( AddInsSession.ServerAE, 
                                         AddInsSession.ServerAddress, 
                                         AddInsSession.ServerPort, 
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
            
         #endregion
         
         #region Properties
         
            private Thread __WorkingThread
            {
               get ;
               set ;
            }
            
         #endregion
         
         #region Events
            
         #endregion
         
         #region Data Members
         
            AutoResetEvent _processingEvent = new AutoResetEvent ( false ) ;
            
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
