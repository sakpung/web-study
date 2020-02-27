// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data.SqlClient;
using Leadtools.DataAccessLayers.Core;

namespace Leadtools.DataAccessLayers
{
    public class TemplateSqlDataAccessAgent : TemplateDBDataAccessAgent
    {
        public TemplateSqlDataAccessAgent(string connectionString)
            : base(connectionString)
        {

        }

        protected override Database CreateDatabaseProvider()
        {
            return new SqlDatabase(ConnectionString);
        }

        protected override object RunQueryScalar(string query)
        {
            try
            {
                // Create a connection, a command and an adapter then fill a dataset and return it
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        return command.ExecuteScalar();
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        protected override void InitializeGetAnatomicDescriptions(DbCommand command)
        {
            command.CommandText = @"SELECT *, AnatomicRegion.* FROM AnatomicDescription
                                  INNER JOIN AnatomicRegion ON AnatomicDescription.AnatomicRegionCodeValue = AnatomicRegion.CodeValue";
        }

        protected override void InitializeGetAllTemplates(DbCommand command)
        {
            command.CommandText = "SELECT * FROM Template";
        }

        protected override void InitializeGetTemplateFrames(DbCommand command, string templateId)
        {
            DbParameter p = command.CreateParameter();

            command.CommandText = "SELECT * FROM TemplateFrames WHERE TemplateId = @id";
            command.AddParameter("@id", templateId);
        }

        protected override void InitializeAddTemplate(DbCommand command, Core.Template template)
        {
            command.CommandText = @"INSERT INTO Template
                                   ([Id]
                                   ,[Name]
                                   ,[Comments]
                                   ,[BuiltIn]
                                   ,[Modality]
                                   ,[Created]
                                   ,[Hidden]
                                   ,[AutoMatching]
                                   ,[Availability])
                             VALUES
                                   (@Id
                                   ,@Name
                                   ,@Comments
                                   ,@BuiltIn
                                   ,@Modality
                                   ,CURRENT_TIMESTAMP
                                   ,@Hidden
                                   ,@AutoMatching
                                   ,@Availability)";

            command.AddParameter("@Id", template.Id);
            command.AddParameter("@Name", template.Name);
            command.AddParameter("@Comments", template.Comments == null ? DBNull.Value : (object)template.Comments);
            command.AddParameter("@BuiltIn", template.BuiltIn);
            command.AddParameter("@Modality", template.Modality);
            command.AddParameter("@Hidden", template.Hidden);
            command.AddParameter("@AutoMatching", template.AutoMatching == null ? string.Empty : template.AutoMatching);
            command.AddParameter("@Availability", template.Availability);
        }

        protected override void InitializeUpdateTemplate(DbCommand command, Core.Template template)
        {
            command.CommandText = @"UPDATE [dbo].[Template]
                                    SET [Name] = @Name
                                       ,[Comments] = @Comments
                                       ,[BuiltIn] = @BuiltIn
                                       ,[Modality] = @Modality                                       
                                       ,[Hidden] = @Hidden
                                       ,[AutoMatching] = @AutoMatching
                                       ,[Availability] = @Availability
                                    WHERE Id = @Id";

            command.AddParameter("@Id", template.Id);
            command.AddParameter("@Name", template.Name);
            command.AddParameter("@Comments", template.Comments == null ? DBNull.Value : (object)template.Comments);
            command.AddParameter("@BuiltIn", template.BuiltIn);
            command.AddParameter("@Modality", template.Modality);
            command.AddParameter("@Hidden", template.Hidden);
            command.AddParameter("@AutoMatching", template.AutoMatching == null ? string.Empty : template.AutoMatching);
            command.AddParameter("@Availability", template.Availability);
        }

        protected override void InitializeTemplateExists(DbCommand command, string templateId)
        {
            command.CommandText = string.Format("SELECT Id FROM Template WHERE Id = '{0}'", templateId);            
        }

        protected override void InitializeAddFrame(DbCommand command, string templateId, Core.TemplateFrame frame)
        {
            command.CommandText = @"INSERT INTO [dbo].[TemplateFrames]
                                   ([Id]
                                   ,[TemplateId]
                                   ,[FrameNumber]
                                   ,[SequenceNumber]
                                   ,[FrameRotation]
                                   ,[HorizontalJustification]
                                   ,[VerticalJustification]
                                   ,[PresentationSizeMode]
                                   ,[Magnification]
                                   ,[Comments]
                                   ,[AnatomicDescriptionId]
                                   ,[Flip]
                                   ,[Reverse]
                                   ,[Invert]
                                   ,[Left]
                                   ,[Top]
                                   ,[Right]
                                   ,[Bottom]
                                   ,[Script])
                                   VALUES
                                   (@Id
                                   ,@TemplateId
                                   ,@FrameNumber
                                   ,@SequenceNumber
                                   ,@FrameRotation
                                   ,@HorizontalJustification
                                   ,@VerticalJustification
                                   ,@PresentationSizeMode
                                   ,@Magnification
                                   ,@Comments
                                   ,@AnatomicDescriptionId
                                   ,@Flip
                                   ,@Reverse
                                   ,@Invert
                                   ,@Left
                                   ,@Top
                                   ,@Right
                                   ,@Bottom
                                   ,@Script)";

            command.AddParameter("@Id", frame.Id);
            command.AddParameter("@TemplateId", templateId);
            command.AddParameter("@FrameNumber", frame.FrameNumber);
            command.AddParameter("@SequenceNumber", frame.SequenceNumber);
            command.AddParameter("@FrameRotation", frame.Rotation.ToString());
            command.AddParameter("@HorizontalJustification", frame.HorizontalJustification.ToString());
            command.AddParameter("@VerticalJustification", frame.VerticalJustification.ToString());
            command.AddParameter("@PresentationSizeMode", frame.PresentationSizeMode.ToString());
            command.AddParameter("@Magnification", frame.Magnification);
            command.AddParameter("@Comments", frame.ImageComments==null?DBNull.Value:(object)frame.ImageComments);
            command.AddParameter("@AnatomicDescriptionId", frame.AnatomicDescription!=null && !string.IsNullOrEmpty(frame.AnatomicDescription.Id)?frame.AnatomicDescription.Id:(object)DBNull.Value);
            command.AddParameter("@Flip", frame.Flip);
            command.AddParameter("@Reverse", frame.Reverse);
            command.AddParameter("@Invert", frame.Invert);
            command.AddParameter("@Left", frame.Position.leftTop.X);
            command.AddParameter("@Top", frame.Position.leftTop.Y);
            command.AddParameter("@Right", frame.Position.rightBottom.X);
            command.AddParameter("@Bottom", frame.Position.rightBottom.Y);
            command.AddParameter("@Script", frame.Script==null?string.Empty:frame.Script);
        }

        protected override void InitializeDeleteAllFrames(DbCommand command, string templateId)
        {
            command.CommandText = "DELETE FROM TemplateFrames WHERE TemplateId = @Id";
            command.AddParameter("@Id", templateId);
        }

        protected override void InitializeDeleteTemplate(DbCommand command, string templateId)
        {
            command.CommandText = "DELETE FROM Template WHERE Id = @Id";
            command.AddParameter("@Id", templateId);
        }
    }
}
