// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System.Collections.Generic;
using System.IO;
using Leadtools.Medical.WebViewer.DataContracts;
using Leadtools.DataAccessLayers.Core;

namespace Leadtools.Medical.WebViewer.Services.Interfaces
{
   /// <summary>
   /// The service contract for the annotations service (not used anymore)
   /// </summary>
   public interface ITemplateHandler
   {
      List<AnatomicDescription> GetAnatomicDescriptions(string authenticationCookie, string userData);

      List<WCFTemplate> GetAllTemplates(string authenticationCookie, string userData);

      void AddTemplate(string authenticationCookie, WCFTemplate template, string userData);

      void UpdateTemplate(string authenticationCookie, WCFTemplate template, string userData);

      void DeleteTemplate(string authenticationCookie, string templateId, string userData);
      Stream ExportAllTemplates(string authenticationCookie, string userData);
      List<WCFTemplate> ImportTemplates(Stream file);
   }
}
