// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security;
using Leadtools.Dicom.AddIn.Common;
using Leadtools.DataAccessLayers.Core;

namespace Leadtools.DataAccessLayers
{   
   public interface ITemplateDataAccessAgent
   {
       List<AnatomicDescription> GetAnatomicDescriptions();
       List<Template> GetAllTemplates();
       void AddTemplate(Template template);
       void UpdateTemplate(Template template);
       bool TemplateExists(string templateId);
       void DeleteTemplate(string templateId);
   }
}
