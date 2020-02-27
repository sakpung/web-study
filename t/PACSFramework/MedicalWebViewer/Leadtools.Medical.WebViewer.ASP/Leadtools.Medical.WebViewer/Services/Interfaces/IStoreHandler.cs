// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using Leadtools.Medical.WebViewer.DataContracts;
using System.Runtime.Serialization;
using Leadtools.Medical.WebViewer.Core.DataTypes;

namespace Leadtools.Medical.WebViewer.Services.Interfaces
{

   public enum StoreReturnCode
   {
      Failure = 0,
      Success = 1,
      PendingMoreData = 2
   }

   public enum StoreImageFormatCode
   {
      DCM = 0,
      JPEG = 1,
      PNG = 2,
   }

   [DataContract]
   public class PatientInfo_Json
   {
      public PatientInfo_Json(
                         string patientId,
                         string name,
                         string sex,
                         string birthDate,
                         string ethnicGroup,
                         string comments)
      {
         this.PatientId = patientId;
         this.Name = name;
         this.Sex = sex;
         this.BirthDate = birthDate;
         this.EthnicGroup = ethnicGroup;
         this.Comments = comments;
      }

      [DataMember]
      public string PatientId { get; set; }

      [DataMember]
      public string Name { get; set; }

      [DataMember]
      public string Sex { get; set; }

      [DataMember]
      public string BirthDate { get; set; }

      [DataMember]
      public string EthnicGroup { get; set; }

      [DataMember]
      public string Comments { get; set; }
   }

   [DataContract]
   public class StoreStatus_Json
   {
      public StoreStatus_Json(StoreReturnCode storeReturnCode, string message)
      {
         this.ReturnCode = (int)storeReturnCode;
         this.Message = message;
      }

      [DataMember]
      public int ReturnCode { get; set; }

      [DataMember]
      public string Message { get; set; }
   }

   /// <summary>
   /// Stores images to DICOM
   /// </summary>
   /// <remarks>
   /// As previous services, can store to remote PACS or local database
   /// Each operation in the services must specify what role it falls into. You must first call IsUserInRole to check if the user
   /// can perform the operation
   /// </remarks>    
   public interface IStoreHandler
   {
      /// <summary>
      /// Stores a secondary capture item from user's machine
      /// </summary>
      /// <param name="authenticationCookie">cookie</param>
      /// <param name="EncodedCapture">base64 encoded png image</param>
      /// <param name="OriginalSOPInstance">uid of related SOP</param>
      /// <param name="SeriesNumber">Series Number</param>
      /// <param name="SeriesDescription">Series Description</param>
      /// <param name="ProtocolName">Protocol Name</param>
      SeriesData StoreSecondaryCapture(string authenticationCookie, string EncodedCapture, string OriginalSOPInstance, string SeriesNumber, string SeriesDescription, string ProtocolName);

      PresentationStateData StoreAnnotations(string authenticationCookie, string seriesInstanceUID, string annotationData, string description, string userData);

      string UploadDicomImage(string authenticationCookie, string dicomData, string status, string fileName);

      void DeletePresentationState(string authenticationCookie, string sopInstanceUID, string userData);

      StoreStatus_Json StoreImage(string authenticationCookie, int formatCode, string imageData, string userData);

      void StoreStudyLayout(string authenticationCookie, string studyInstanceUID, StudyLayout studyLayout, string userData);
      void DeleteStudyLayout(string authenticationCookie, string studyInstanceUID, string userData);
      void StoreHangingProtocol(string authenticationCookie, WCFHangingProtocol hangingProtocol, string userData);
   }
}
