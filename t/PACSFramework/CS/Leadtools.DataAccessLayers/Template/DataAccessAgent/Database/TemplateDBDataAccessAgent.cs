// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Security;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Leadtools.Dicom.AddIn.Common;
using Leadtools.DataAccessLayers.Core;
using Common = Leadtools.Dicom.Common.DataTypes;

namespace Leadtools.DataAccessLayers
{
    public abstract class TemplateDBDataAccessAgent : ITemplateDataAccessAgent
    {
        private string _ConnectionString;

        public string ConnectionString
        {
            get
            {
                return _ConnectionString;
            }

            private set
            {
                _ConnectionString = value;
            }
        }

        private Database _DatabaseProvider;

        protected Database DatabaseProvider
        {
            get
            {
                if (null == _DatabaseProvider)
                {
                    _DatabaseProvider = CreateDatabaseProvider();
                }

                return _DatabaseProvider;
            }

            private set
            {
                _DatabaseProvider = value;
            }
        }

        public TemplateDBDataAccessAgent(string connectionString)
        {
            ConnectionString = connectionString;
        }

        protected abstract Database CreateDatabaseProvider();
        protected abstract object RunQueryScalar(string query);
        protected abstract void InitializeGetAnatomicDescriptions(DbCommand command);
        protected abstract void InitializeGetAllTemplates(DbCommand command);
        protected abstract void InitializeGetTemplateFrames(DbCommand command, string templateId);
        protected abstract void InitializeAddTemplate(DbCommand command, Template template);
        protected abstract void InitializeUpdateTemplate(DbCommand command, Template template);
        protected abstract void InitializeTemplateExists(DbCommand command, string templateId);
        protected abstract void InitializeAddFrame(DbCommand command, string templateId, TemplateFrame frame);
        protected abstract void InitializeDeleteAllFrames(DbCommand command, string templateId);
        protected abstract void InitializeDeleteTemplate(DbCommand command, string templateId);

        public List<AnatomicDescription> GetAnatomicDescriptions()
        {
            List<AnatomicDescription> anatomicDescriptions = new List<AnatomicDescription>();

            using (var command = DatabaseProvider.DbProviderFactory.CreateCommand())
            {
               InitializeGetAnatomicDescriptions(command);
               using (var reader = DatabaseProvider.ExecuteReader(command))
               {

                  while (reader.Read())
                  {
                     AnatomicDescription description = new AnatomicDescription();
                     string modiferCode = reader.GetColumnValue<string>("AnatomicRegionModiferCodeValue");

                     description.Id = reader.GetColumnValue<string>("Id");
                     description.Name = reader.GetColumnValue<string>("Name");
                     description.Laterality = reader.GetColumnValue<Laterality>("Laterality");
                     if (!string.IsNullOrEmpty(modiferCode) && AnatomicRegionTable.Modifers.ContainsKey(modiferCode))
                     {
                        description.AnatomicRegionModifierSequence = AnatomicRegionTable.Modifers[modiferCode];
                     }
                     description.AnatomicRegionSequence = new Common.CodeSequence()
                     {
                        CodeValue = reader.GetColumnValue<string>("CodeValue"),
                        CodeMeaning = reader.GetColumnValue<string>("CodeMeaning"),
                        CodeSchemeDesignator = reader.GetColumnValue<string>("CodingSchemeDesignator")
                     };

                     anatomicDescriptions.Add(description);
                  }
               }
            }

            return anatomicDescriptions;
        }


        public List<Template> GetAllTemplates()
        {
            List<Template> templates = new List<Template>();

            using (var command = DatabaseProvider.DbProviderFactory.CreateCommand())
            {
               InitializeGetAllTemplates(command);
               using (var reader = DatabaseProvider.ExecuteReader(command))
               {
                  while (reader.Read())
                  {
                     Template template = new Template();

                     using (var frameCommand = DatabaseProvider.DbProviderFactory.CreateCommand())
                     {
                        template.Id = reader.GetColumnValue<string>("Id");
                        template.Name = reader.GetColumnValue<string>("Name");
                        template.Modality = reader.GetColumnValue<string>("Modality");
                        template.Created = reader.GetColumnValue<DateTime?>("Created");
                        template.Hidden = reader.GetColumnValue<bool>("Hidden");
                        template.AutoMatching = reader.GetColumnValue<string>("AutoMatching");
                        template.BuiltIn = reader.GetColumnValue<bool>("BuiltIn");
                        template.Comments = reader.GetColumnValue<string>("Comments");
                        template.Availability = reader.GetColumnValue<AvailabilityLevel>("Availability");

                        InitializeGetTemplateFrames(frameCommand, template.Id);
                        using (var frameReader = DatabaseProvider.ExecuteReader(frameCommand))
                        {
                           while (frameReader.Read())
                           {
                              TemplateFrame frame;
                              FramePosition position = new FramePosition();

                              position.leftTop = new LeadPointD(frameReader.GetColumnValue<double>("Left"), frameReader.GetColumnValue<double>("Top"));
                              position.rightBottom = new LeadPointD(frameReader.GetColumnValue<double>("Right"), frameReader.GetColumnValue<double>("Bottom"));
                              frame = new TemplateFrame(position);
                              frame.Id = frameReader.GetColumnValue<string>("Id");
                              frame.FrameNumber = frameReader.GetColumnValue<int>("FrameNumber");
                              frame.SequenceNumber = frameReader.GetColumnValue<int>("SequenceNumber");
                              frame.ImageComments = frameReader.GetColumnValue<string>("Comments");
                              frame.Rotation = frameReader.GetColumnValue<FrameRotation>("FrameRotation");
                              frame.HorizontalJustification = frameReader.GetColumnValue<FrameHorizontalJustication>("HorizontalJustification");
                              frame.VerticalJustification = frameReader.GetColumnValue<FrameVerticalJustification>("VerticalJustification");
                              frame.PresentationSizeMode = frameReader.GetColumnValue<PresentationSizeMode>("PresentationSizeMode");
                              frame.Magnification = frameReader.GetColumnValue<double>("Magnification");
                              //frame.AnatomicDescription = anatomicDescriptions.Where(a => a.Id == frameReader.GetColumnValue<string>("AnatomicDescriptionId")).FirstOrDefault();
                              frame.Script = frameReader.GetColumnValue<string>("Script");
                              frame.Flip = frameReader.GetColumnValue<bool>("Flip");
                              frame.Reverse = frameReader.GetColumnValue<bool>("Reverse");
                              frame.Invert = frameReader.GetColumnValue<bool>("Invert");
                              template.Frames.Add(frame);
                           }
                        }
                     }

                     templates.Add(template);
                  }
               }
            }

            return templates;
        }

        public void AddTemplate(Template template)
        {
           using (var command = DatabaseProvider.DbProviderFactory.CreateCommand())
           {

              InitializeAddTemplate(command, template);
              DatabaseProvider.ExecuteNonQuery(command);

              AddTemplateFrames(template.Id, template.Frames);
           }
        }

        public void UpdateTemplate(Template template)
        {
           using (var command = DatabaseProvider.DbProviderFactory.CreateCommand())
           {

              if (TemplateExists(template.Id))
              {
                 InitializeUpdateTemplate(command, template);
                 DatabaseProvider.ExecuteNonQuery(command);

                 command.Parameters.Clear();
                 InitializeDeleteAllFrames(command, template.Id);
                 DatabaseProvider.ExecuteNonQuery(command);

                 AddTemplateFrames(template.Id, template.Frames);
              }
              else
              {
                 AddTemplate(template);
              }
           }
        }

        public bool TemplateExists(string templateId)
        {
           using (var command = DatabaseProvider.DbProviderFactory.CreateCommand())
           {

              InitializeTemplateExists(command, templateId);
              return RunQueryScalar(command.CommandText) != null;
           }
        }

        public void DeleteTemplate(string templateId)
        {
           using (var command = DatabaseProvider.DbProviderFactory.CreateCommand())
           {

              InitializeDeleteTemplate(command, templateId);
              DatabaseProvider.ExecuteNonQuery(command);
           }
        }

        private void AddTemplateFrames(string templateId, List<TemplateFrame> frames)
        {
            foreach (TemplateFrame frame in frames)
            {
               using (DbCommand command = DatabaseProvider.DbProviderFactory.CreateCommand())
               {
                  InitializeAddFrame(command, templateId, frame);
                  DatabaseProvider.ExecuteNonQuery(command);
               }
            }
        }
    }
}
