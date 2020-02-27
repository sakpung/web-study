// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Dicom;
using Leadtools.Dicom.Common.DataTypes;

namespace Leadtools.Medical.Media.AddIns.Composing
{
   public interface IDicomMediaProfileProcessor
   {
      bool CanProcess                 ( string profile ) ;
      long GetProfileMediaSize        ( ) ;
      long CalculateRemainingDataSize ( long dicomObjectsSize ) ;
      void SetProfile                 ( string profile ) ;
      void BeforeAddingToDicomDir     ( string referencedInstancePath, CompositeInstanceDataSet.InstanceRow instance, bool allowLossyCompression ) ;
      void AfterAddingToDicomDir      ( string referencedInstancePath, CompositeInstanceDataSet.InstanceRow instance, DicomDataSet dicomDir ) ;
      void OnDicomDirCompleted        ( DicomDataSet dicomDir ) ;
      void IncludeNonDicomObjects     ( IncludeNonDicomObjects nonDicomObjectType ) ;
      void IncludeDisplayApplication  ( ) ;
      
      event EventHandler <CopyEventArgs> CopyDirectory ;
      event EventHandler <CopyEventArgs> CopyFile ;
   }
   
   public class CopyEventArgs : EventArgs
   {
      public CopyEventArgs ( string path ) 
      {
         Path = path ;
      }
      
      public string Path 
      {
         get ;
         private set ;
      }
   }
}
