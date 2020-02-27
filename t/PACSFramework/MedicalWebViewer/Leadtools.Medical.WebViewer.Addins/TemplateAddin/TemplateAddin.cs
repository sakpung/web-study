// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.WebViewer.Core.Addins;
using Leadtools.Medical.WebViewer.DataContracts;
using Leadtools.Medical.WebViewer.ServiceContracts;
using Leadtools.DataAccessLayers;
using Leadtools.DataAccessLayers.Core;
using Leadtools.Dicom;

namespace Leadtools.Medical.WebViewer.Addins
{
    public class TemplateAddin: ITemplateAddin
    {
        private ITemplateDataAccessAgent _templateDataAccessAgent;

        public TemplateAddin(ITemplateDataAccessAgent templateDataAccessAgent)
        {
            _templateDataAccessAgent = templateDataAccessAgent;
        }

        public List<AnatomicDescription> GetAnatomicDescriptions(string userData)
        {            
            return _templateDataAccessAgent.GetAnatomicDescriptions(); 
        }

        public List<WCFTemplate> GetAllTemplates(string userData)
        {
           List<WCFTemplate> templates = (from template in _templateDataAccessAgent.GetAllTemplates()
                                          select new WCFTemplate()
                                                    {
                                                       Id = template.Id,
                                                       BuiltIn = template.BuiltIn,
                                                       Comments = template.Comments,
                                                       Created = template.Created,
                                                       Frames = template.Frames,
                                                       Hidden = template.Hidden,
                                                       AutoMatching = template.AutoMatching,
                                                       Modality = template.Modality,
                                                       Name = template.Name,
                                                       Availability = template.Availability,
                                          }).ToList();

            return templates;
        }        
        
       
        public void AddTemplate(string userName, Template template, string userData)
        {
            _templateDataAccessAgent.AddTemplate(template);
        }

        public void UpdateTemplate(string userName, Template template, string userData)
        {
            _templateDataAccessAgent.UpdateTemplate(template);
        }

        public void DeleteTemplate(string userName, string templateId, string userData)
        {
            _templateDataAccessAgent.DeleteTemplate(templateId);
        }
    }
}
