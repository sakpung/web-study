// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.IO;
using Leadtools.Medical.WebViewer.DataContracts;
using System.Threading.Tasks;
using System;

namespace Leadtools.Medical.WebViewer.Services.Interfaces
{
   //public interface IThreeDHandler2
   //{
   //   string Open(string authenticationCookie, int renderingType);
   //   void Close(string authenticationCookie, string id);

   //   Task BeginBuilding(string authenticationCookie, string id, QueryOptions options);
   //   Tuple<string, string, int> GetStatus(string authenticationCookie, string id);
   //   void KeepAlive(string authenticationCookie, string id);

   //   Task<Stream> Get3DImage(string authenticationCookie, string id, int x, int y, int width, int height, int resizeFactor, string effect, int action, float sensitivity, float resizeRatio);
   //   Task<Stream> GetMPRImage(string authenticationCookie, string id, int mprType, int index);

   //   void Update3DSettings(string authenticationCookie, string id, string options);
   //   string Get3DSettings(string authenticationCookie, string id, string options);
   //}

   public interface IThreeDHandler
   {
      Stream Get3DImage(string authenticationCookie, string id, int x, int y, int width, int height, int resizeFactor, string effect, int action, float sensitivity, float resizeRatio);
      bool End3DObject(string authenticationCookie, string id);
      string Create3DObject(string authenticationCookie, QueryOptions options, string id, int renderingType, ExtraOptions extraOptions);
      bool Update3DSettings(string authenticationCookie, string id, string options);
      string Get3DSettings(string authenticationCookie, string id, string options);
      string CheckProgress(string authenticationCookie, string id);
      bool KeepAlive(string authenticationCookie, string id);
      Stream GetMPRImage(string authenticationCookie, string id, int mprType, int index);
      Stream GetPanoramicImage(string authenticationCookie, string id, int resizeFactor, string polygonInfo, string polygonData);
   }
}
