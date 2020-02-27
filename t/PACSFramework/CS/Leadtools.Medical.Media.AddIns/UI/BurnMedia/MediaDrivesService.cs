// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.MediaWriter;

namespace Leadtools.Medical.Media.AddIns
{
   public class MediaDrivesService : IDisposable
   {
      public MediaDrivesService ( ) 
      {
         __MediaWriter = new MediaWriter.MediaWriter ( ) ;
         
         
         Drives = new List<MediaWriterDrive> ( __MediaWriter.Drives.ToArray ( ) ) ;
         
         if ( Drives.Count > 0 )
         {
            if ( Drives [ 0 ].DriveNumber == -1 ) 
            {
               Drives.RemoveAt ( 0 ) ;
            }
         }
         
         if ( Drives.Count > 0 && __MediaWriter.CurrentDriveNumber == -1 )
         {
            __MediaWriter.CurrentDriveNumber = 0 ;
         }
         
         foreach ( MediaWriterDrive drive in Drives ) 
         {
            drive.OnDeviceEvent += new EventHandler<MediaWriterDevNotifyEventArgs> ( drive_OnDeviceEvent ) ;
         }
      }
      
      public List <MediaWriterDrive> Drives
      {
         get 
         {
            return _drives ;
         }
         
         private set 
         {
            _drives = value ;
         }
      }
      
      public MediaWriterDrive SelectedDrive
      {
         get 
         {
            if ( __MediaWriter.CurrentDriveNumber == -1 )
            {
               return null ;
            }
            else
            {
               return __MediaWriter.CurrentDrive ;
            }
         }
         
         set 
         {
            if ( null == value ) 
            {
               if ( __MediaWriter.CurrentDriveNumber != -1 )
               {
                  __MediaWriter.CurrentDriveNumber = -1 ;
                  
                  FireSelectedDriveEvents ( ) ;
               }
            }
            else
            {
               int driveIndex ;
               
               
               driveIndex = Drives.IndexOf ( value ) ;
               
               if ( driveIndex != __MediaWriter.CurrentDriveNumber ) 
               {
                  __MediaWriter.CurrentDriveNumber = driveIndex ;

                  FireSelectedDriveEvents ( ) ;
               }
            }
         }
      }

      public List <MediaWriterSpeed> SelectedDriveSpeeds
      {
         get
         {
            if ( null == SelectedDrive ) 
            {
               return new List<MediaWriterSpeed> ( ) ;
            }
            else
            {
               return SelectedDrive.Speeds ;
            }
         }
      }
      
      public MediaWriterSpeed SelectedSpeed
      {
         get 
         {
            if (null == SelectedDrive || SelectedDrive.CurrentSpeedIndex == -1 || SelectedDrive.Speeds.Count >= SelectedDrive.CurrentSpeedIndex ) 
            {
               return null ;
            }
            
            return SelectedDrive.Speeds [ SelectedDrive.CurrentSpeedIndex ] ;
         }
         
         set 
         {
            if ( value == null ) 
            {
               if ( SelectedDrive.CurrentSpeedIndex != -1 ) 
               {
                  SelectedDrive.CurrentSpeedIndex = -1 ;
                  
                  FireSelectedDriveSpeedChanged ( ) ;
               }
            }
            else
            {
               int currentSpeedIndex ;
               
               currentSpeedIndex = SelectedDriveSpeeds.IndexOf ( value ) ;
               
               if ( currentSpeedIndex !=- SelectedDrive.CurrentSpeedIndex ) 
               {
                  SelectedDrive.CurrentSpeedIndex = currentSpeedIndex ;
               
                  FireSelectedDriveSpeedChanged ( ) ;
               }
            }
         }
      }
      
      public void Dispose ( )
      {
         foreach ( MediaWriterDrive drive in Drives ) 
         {
            drive.OnDeviceEvent -= new EventHandler<MediaWriterDevNotifyEventArgs> ( drive_OnDeviceEvent ) ;
            drive.Dispose ( ) ;
         }
         
         Drives.Clear ( ) ;
         
         if ( null != __MediaWriter ) 
         {
            __MediaWriter.Dispose ( ) ;
         }
      }

      public event EventHandler SelectedDriveChanged ;
      public event EventHandler SelectedDriveSpeedChanged ;
      public event EventHandler SpeedsChanged ;
      public event EventHandler SelectedDriveStateChanged ;
      
      private void FireSelectedDriveEvents ( )
      {
         if ( null != SelectedDriveChanged ) 
         {
            SelectedDriveChanged ( this, EventArgs.Empty ) ;
         }
         
         if ( null != SpeedsChanged ) 
         {
            SpeedsChanged ( this, EventArgs.Empty ) ;
         }
      }
      
      private void FireSelectedDriveSpeedChanged()
      {
         if ( null != SelectedDriveSpeedChanged ) 
         {
            SelectedDriveSpeedChanged ( this, EventArgs.Empty ) ;
         }
      }
      
      void drive_OnDeviceEvent ( object sender, MediaWriterDevNotifyEventArgs e )
      {
         if ( sender == SelectedDrive ) 
         {
            OnSelectedDriveStateChanged ( ) ;
         }
      }
      
      
      private void OnSelectedDriveStateChanged ( ) 
      {
         if ( SelectedDriveStateChanged != null ) 
         {
            SelectedDriveStateChanged ( this, EventArgs.Empty ) ;
         }
      }
      
      private MediaWriter.MediaWriter __MediaWriter
      {
         get ;
         set ;
      }
      
      private List <MediaWriterDrive> _drives ;
   }
}
