// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.WebViewer.DataContracts;
using Leadtools.DataAccessLayers.Core;

namespace Leadtools.Medical.WebViewer.ServiceContracts
{
    public interface ITemplateAddin
    {
        List<AnatomicDescription> GetAnatomicDescriptions(string userData);
        List<WCFTemplate> GetAllTemplates(string userData);
        void AddTemplate(string userName, Template template, string userData);
        void UpdateTemplate(string userName, Template template, string userData);
        void DeleteTemplate(string userName, string templateId, string userData);
    }
}
