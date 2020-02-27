// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace Leadtools.Medical.WebViewer.ExternalControl
{

   [DataContract]
   internal class Command_Json
   {
      public Command_Json(string commandName, string[] commandArgs)
      {
         this.Name = commandName;
         this.Args = commandArgs;
      }

      [DataMember]
      public string Name { get; set; }

      [DataMember]
      public string[] Args { get; set; }
   }

   [DataContract]
   internal class ExternalControlAssociationStatus
   {
      [DataMember]
      public bool Accepted { get; set; }

      [DataMember]
      public string Token { get; set; }
   }

   [DataContract]
   public class PatientInfo
   {
      public PatientInfo()
      {
      }

      public PatientInfo(string patientId, string name, string birthDate, string sex, string ethnicGroup, string comments)
      {
         PatientId = patientId;
         Name = name;
         BirthDate = birthDate;
         Sex = sex;
         EthnicGroup = ethnicGroup;
         Comments = comments;
      }

      [DataMember]
      public string PatientId {get; set;}

      [DataMember]
      public string Name {get;set;}

      [DataMember]
      public string BirthDate {get;set;}

      [DataMember]
      public string Sex {get;set;}
      
      [DataMember]
      public string EthnicGroup {get;set;}
      
      [DataMember]
      public string Comments {get;set;}
   }

   [DataContract]
   public class StudyInfo
   {
      public StudyInfo()
      {
      }

      public StudyInfo(string studyInstanceUid, string studyDate, string accessionNumber, string studyId, string referringPhysiciansName, string studyDescription)
      {
         StudyInstanceUid = studyInstanceUid;
         StudyDate = studyDate;
         AccessionNumber = accessionNumber;
         StudyId = studyId;
         ReferringPhysiciansName = referringPhysiciansName;
         StudyDescription = studyDescription;
      }

      [DataMember]
      public string StudyInstanceUid {get; set;}

      [DataMember]
      public string StudyDate {get;set;}

      [DataMember]
      public string AccessionNumber {get;set;}

      [DataMember]
      public string StudyId {get;set;}
      
      [DataMember]
      public string ReferringPhysiciansName {get;set;}
      
      [DataMember]
      public string StudyDescription {get;set;}
   }

    [DataContract]
   public class SeriesInfo
   {
      public SeriesInfo()
      {
      }

      public SeriesInfo(string seriesInstanceUid, string modality, string seriesNumber, string seriesDate, string seriesDescription)
      {
         SeriesInstanceUid = seriesInstanceUid;
         Modality = modality;
         SeriesNumber = seriesNumber;
         SeriesDate = seriesDate;
         SeriesDescription = seriesDescription;
      }

      [DataMember]
      public string SeriesInstanceUid {get; set;}

      [DataMember]
      public string Modality {get;set;}

      [DataMember]
      public string SeriesNumber {get;set;}

      [DataMember]
      public string SeriesDate {get;set;}
      
      [DataMember]
      public string SeriesDescription {get;set;}
   }

       [DataContract]
   public class InstanceInfo
   {
      public InstanceInfo()
      {
      }

      public InstanceInfo(string sopInstanceUid, string instanceNumber, string sopClassUid)
      {
         SopInstanceUid = sopInstanceUid;
         InstanceNumber = instanceNumber;
         SopClassUid = sopClassUid;
      }

      [DataMember]
      public string SopInstanceUid {get; set;}

      [DataMember]
      public string InstanceNumber {get;set;}

      [DataMember]
      public string SopClassUid {get;set;}

      [DataMember]
      public string SeriesDate {get;set;}
   }

   // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IExternalCommandQueueService" in both code and config file together.
   [ServiceContract]
   internal interface IExternalCommandQueueService
   {
      [OperationContract]
      [WebGet(UriTemplate = "HasCommands/{externalControlAssociationToken}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
      bool HasCommands(String externalControlAssociationToken);

      [OperationContract]
      [WebGet(UriTemplate = "GetCommands/{externalControlAssociationToken}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
      List<Command_Json> GetCommands(String externalControlAssociationToken);

      [OperationContract]
      [WebGet(UriTemplate = "RequestExternalControl", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
      ExternalControlAssociationStatus RequestExternalControl();

      [OperationContract]
      [WebGet(UriTemplate = "GetViewerAuthenticationToken/{externalControlAssociationToken}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
      String GetViewerAuthenticationToken(String externalControlAssociationToken);
      
      [OperationContract]
      [WebInvokeAttribute(Method="POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      void ReceivePatientInfo(string externalControlAssociationToken , PatientInfo patientInfo);

      [OperationContract]
      [WebGet(UriTemplate = "ReceiveImageInfo/{found}/{seriesInstanceUID}/{captureDate}/{imageType}/{comment}/{toothGroups}/{externalControlAssociationToken}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
      void ReceiveImageInfo(string found, string seriesInstanceUID, string captureDate, string imageType, string comment, string toothGroups, string externalControlAssociationToken);

      [OperationContract]
      [WebGet(UriTemplate = "ReceiveGenericActionStatus/{status}/{externalControlAssociationToken}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
      void ReceiveGenericActionStatus(string status, string externalControlAssociationToken);

      [OperationContract]
      [WebInvoke(Method="*", UriTemplate = "ReceiveImageURL?url={imageURL}&token={externalControlAssociationToken}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
      void ReceiveImageURL(string imageURL, string externalControlAssociationToken);

      [OperationContract]
      [WebGet(UriTemplate = "LogoutNotify/{reason}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
      void LogoutNotify(string reason);
   }
}
