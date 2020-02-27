// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.Scp.Media;
using Leadtools.Dicom.Common.DataTypes.MediaCreation;
using Leadtools.Dicom;

namespace Leadtools.Medical.Media.AddIns
{
   interface IMediaJobStatusView
   {
      void LoadMedia                  ( MediaObjectsStateService mediaJobsQueue ) ;
      void NotifyMediaCreationSuccess ( MediaCreationManagement mediaObject ) ;
      void NotifyMediaCreationError   ( MediaCreationManagement mediaObject, Exception  error ) ;
      
      void TearDown ( ) ;
      
      bool CanCreateSelected
      {
         set ;
      }
      
      bool CanRecreateSelected
      {
         set ;
      }
      
      bool CanDeleteSelected
      {
         set ;
      }
      
      bool CanBurn
      {
         set ;
      }
      
      DicomDataSet DetailesDataSet
      {
         get ;
         set ;
      }
      
      MediaCreationManagement SelectedMediaObject
      {
         get ;
         set ;
      }
      
      event EventHandler Load ;
      event EventHandler DeleteMedia ;
      event EventHandler RefreshMediaQueue ;
      event EventHandler CreateMedia ;
      event EventHandler RecreateMedia ;
      event EventHandler BurnActiveMedia ;
      
      void OnMediaObjectRemoved       ( MediaCreationManagement mediaObject ) ;
      void OnMediaObjectAdded         ( MediaCreationManagement mediaObject ) ;
      void OnMediaObjectStatusUpdated ( MediaCreationManagement mediaObject ) ;
      void OnMediaObjectsCleared      ( ) ;

      void HideUserAlert ( ) ;
      void ShowUserAlert ( string alertMessage ) ;
   }
}
