// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Leadtools.Medical.WebViewer.DataContracts
{
   /// <summary>
   /// Extra options to use when using the service
   /// </summary>
   [DataContract]
   [Serializable]
   public class ExtraOptions
   {
      /// <summary>
      /// User-defined, not used by LEADTOOLS implementation
      /// </summary>
      [DataMember]
      public string UserData { get; set; }
      [DataMember]
      public string UserData2 { get; set; }
      [DataMember]
      public string UserData3 { get; set; }
      [DataMember]
      public string AuthCookie { get; set; }
      [DataMember]
      public DateTime? TimeStamp { get; set; }
      [DataMember]
      public string ServiceUri { get; set; }
   }


   [DataContract]
   [Serializable]
   public class Settings3D
   {
      [DataMember]
      public float LowResQuality { get; set; }
      [DataMember]
      public float HighResQuality { get; set; }
      [DataMember]
      public float IsoThreshold { get; set; }
      [DataMember]
      public bool ShowMPRCrossLines { get; set; }
      [DataMember]
      public bool ShowClippingFrame { get; set; }
      [DataMember]
      public bool ShowVolumeBorder { get; set; }
      [DataMember]
      public bool ShowRotationCube { get; set; }
      [DataMember]
      public int ProjectionMethod { get; set; }
      [DataMember]
      public int CoronalPosition { get; set; }
      [DataMember]
      public int SagittalPosition { get; set; }
      [DataMember]
      public int AxialPosition { get; set; }
      public int WindowWidth { get; set; }
      public int WindowCenter { get; set; }
   }




   public enum MRTIStatus
   {
       Creating,
       Error,
       Finish,
   }

   [DataContract]
   [Serializable]
   public class MRTIStatusInfo
   {
       [DataMember]
       public MRTIStatus Status { get; set; }

       public int NumberOfFiles { get; set; }
   }

   [DataContract]
   [Serializable]
   public class WcfPingResponse
   {
      [DataMember]
      public string message { get; set; }

      [DataMember]
      public string time { get; set; }

      [DataMember]
      public bool isLicenseChecked { get; set; }

      [DataMember]
      public bool isLicenseExpired { get; set; }

      [DataMember]
      public string kernelType { get; set; }
   }
}
