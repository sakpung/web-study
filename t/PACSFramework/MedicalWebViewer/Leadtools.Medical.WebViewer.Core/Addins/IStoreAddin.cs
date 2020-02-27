// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Leadtools.Medical.WebViewer.DataContracts;
using Leadtools.Dicom;
using Leadtools.Dicom.Common.DataTypes.HangingProtocol;
using Leadtools.Medical.WebViewer.Core.DataTypes;

namespace Leadtools.Medical.WebViewer.ServiceContracts
{
   /// <summary>
   /// Stores images to DICOM
   /// </summary>
   /// <remarks>
   /// As previous services, can store to remote PACS or local database
   /// Each operation in the services must specify what role it falls into. You must first call IsUserInRole to check if the user
   /// can perform the operation
   /// </remarks>
   public interface IStoreAddin
   {
      /// <summary>
      /// Stores an item from user machine to local archive, item should be a DICOM file
      /// </summary>
      /// <param name="stream">The item to store</param>
      /// <param name="itemInfo">Item info</param>
      /// <param name="extraOptions">Extra options</param>
      /// <remarks>
      /// <para>RoleName:CanStore</para>
      /// </remarks>
      void StoreItem(Stream stream, StoreItemInfo itemInfo);
      SeriesData StoreSecondaryCapture(string UserName, string EncodedCapture, string OriginalSOPInstance, string SeriesNumber, string SeriesDescription, string ProtocolName);
      
      /// <summary>
      /// Stores the annotations data (serialized AnnContainer object) as a DICOM presentation state.
      /// </summary>
      /// <param name="userName">name of user storing the annotations</param>
      /// <param name="seriesInstanceUID">The referenced Series Instance UID</param>
      /// <param name="annotationData">The serialized AnnContainer</param>
      /// <param name="description">presentation state description</param>
      /// <param name="userData">custom data</param>
      /// <returns></returns>
      PresentationStateData StoreAnnotations(string userName, string seriesInstanceUID, string annotationData, string description, string userData);

#if LEADTOOLS_V19_OR_LATER
        void StoreStudyLayout(string userName, string studyInstanceUID, StudyLayout studyLayout, string userData);

        void DeleteStudyLayout(string studyInstanceUID, string userData);

        void StoreHangingProtocol(string userName, WCFHangingProtocol hangingProtocol, string userData);        
#endif
        /// <summary>
        /// Deletes a presentation state DICOM DataSet
        /// </summary>
        /// <param name="sopInstanceUID">The SOP Instance UID for the presentation state DICOM DataSet</param>
        /// <param name="userData">custom user data</param>
        void DeletePresentationState ( string sopInstanceUID, string userData ) ;
      void DoStore(DicomDataSet ds);

      //void AddPatient(DicomDataSet ds);
      void UpdatePatient(DicomDataSet ds);

      bool DeletePatient(string patientId);

   }
}
