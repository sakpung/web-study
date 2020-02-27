// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.Common.DataTypes.MediaCreation;
using Leadtools.MediaWriter;

namespace Leadtools.Medical.Media.AddIns
{
   public interface IBurnMediaView
   {
      event EventHandler Load ;
      event EventHandler Eject ;
      event EventHandler Cancel ;
      event EventHandler Test ;
      event EventHandler Burn ;
      
      event EventHandler VolumeNameChanged ;
      event EventHandler SelectedDriveChanged ;
      event EventHandler SelectedSpeedChanged ;
      
      void CleanUp   ( ) ;
      void LoadMedia ( MediaCreationManagement mediaObject ) ;
      void SetDrives ( MediaWriterDrive[] drives ) ;
      void SetSpeeds ( MediaWriterSpeed[] speeds ) ;
      
      void UpdateSelectedDriveInformation ( ) ;
      void ReportProgress ( int completed, string description ) ;
      void OnTestCompleted ( ) ;
      void OnTestFailed ( Exception exception ) ;
      void OnBurnCompleted ( ) ;
      void OnBurnFailed ( Exception exception ) ;
      void OnBurnAborted ( ) ;
      void OnTestAborted ( ) ;
      bool UserWantsToCancelCurrentOperation ( ) ;
      bool RequestNewDisc ( );
      
      
      MediaWriterDrive SelectedDrive
      {
         get ;
         set ;
      }
      
      MediaWriterSpeed SelectedSpeed
      {
         get ;
         set ;
      }
      
      bool AutoEject
      {
         get ;
      }
      
      bool AutoTest
      {
         get ;
      }
      
      int MaxProgressValue
      {
         set ;
      }
      
      bool CanEject
      {
         set ;
      }
      
      bool CanCancel
      {
         set ;
      }
      
      bool CanTest
      {
         set ;
      }
      
      bool CanBurn
      {
         set ;
      }
   }
}
