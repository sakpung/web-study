// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Medical.DataAccessLayer.Configuration;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.DataAccessLayer.Catalog;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using Leadtools.Dicom;
using My.Medical.Storage.DataAccessLayer.Entities;
using My.Medical.Storage.DataAccessLayer.DataAccessLogic.BusinessEntity;
using My.Medical.Storage.DataAccessLayer.DataAccessLogic.DicomDataSetConvertor;
using System.Data.Common;
using My.Medical.Storage.DataAccessLayer.DataAccessLogic.DataAccessAgent.Database.SqlServer;

namespace My.Medical.Storage.DataAccessLayer
{
   public partial class MyStorageSqlDbDataAccessAgent : StorageSqlDbDataAccessAgent
   {

      public MyStorageSqlDbDataAccessAgent(string connectionString)
         : base(connectionString)
      {
         // __DataProvider = CreateDataProvider(connectionString);
         MaxQueryResults = 0;
      }

      public MyStorageSqlDbDataAccessAgent(DataAccessConfigurationView configView)
         : base(configView)
      {
         // __DataProvider = CreateDataProvider(ConnectionString);
         MaxQueryResults = 0;
      }


      // ***************
      // Query Commands
      // ***************
      
      /// <summary>
      /// Creates a command to peform a patient-level query
      /// </summary>
      /// <param name="command">IDbCommand that is created</param>
      /// <param name="matchingParamsCollection">Contains the query parameters that are used to generate the WHERE statement</param>
      protected override void PreparePatientsQueryCommand(IDbCommand command, Collection<CatalogElement[]> matchingParamsCollection, ExtraQueryOptions extraQueryOptions)
      {
         //if (MaxQueryResults > 0)
         //{
         //   base.PreparePatientsQueryCommand(command, matchingParamsCollection, extraQueryOptions);
         //}
         //else
         {
            command.CommandText = MyGetPatientCommandText(matchingParamsCollection);
            command.CommandType = CommandType.Text;
         }
      }

      /// <summary>
      /// Creates a command to peform a study-level query
      /// </summary>
      /// <param name="command">IDbCommand that is created</param>
      /// <param name="matchingParamsCollection">Contains the query parameters that are used to generate the WHERE statement</param>
      protected override void PrepareStudiesQueryCommand
      (
         IDbCommand command,
         Collection<CatalogElement[]> matchingParamsCollection,
         ExtraQueryOptions extraQueryOptions
      )
      {
         //if (MaxQueryResults > 0)
         //{
         //   base.PrepareStudiesQueryCommand(command, matchingParamsCollection, extraQueryOptions);
         //}
         //else
         {
            command.CommandText = MyGetStudiesCommandText(matchingParamsCollection);
            command.CommandType = CommandType.Text;
         }
      }

      /// <summary>
      /// Creates a command to peform a series-level query
      /// </summary>
      /// <param name="command">IDbCommand that is created</param>
      /// <param name="matchingParamsCollection">Contains the query parameters that are used to generate the WHERE statement</param>
      protected override void PrepareSeriesQueryCommand(IDbCommand command, Collection<CatalogElement[]> matchingParamsCollection, ExtraQueryOptions extraQueryOptions)
      {
         //if (MaxQueryResults > 0)
         //{
         //   base.PrepareSeriesQueryCommand(command, matchingParamsCollection, extraQueryOptions);
         //}
         //else
         {
            command.CommandText = MyGetSeriesCommandText(matchingParamsCollection);
            command.CommandType = CommandType.Text;
         }
      }

      /// <summary>
      /// Creates a command to peform an instance-level query
      /// </summary>
      /// <param name="command">IDbCommand that is created</param>
      /// <param name="matchingParamsCollection">Contains the query parameters that are used to generate the WHERE statement</param>
      protected override void PrepareInstanceQueryCommand(IDbCommand command, Collection<CatalogElement[]> matchingParamsCollection, ExtraQueryOptions extraQueryOptions)
      {
         command.CommandText = "exec sp_executeSQL @CMD";

         //if (MaxQueryResults > 0)
         //{
         //   base.PrepareInstanceQueryCommand(command, matchingParamsCollection, extraQueryOptions);
         //}
         //else
         {
            string cmdText = GetInstanceCommandText(matchingParamsCollection, null);
            command.Parameters.Add(new SqlParameter("@CMD", cmdText));
            command.CommandType = CommandType.Text;
         }
      }


      // This example builds a IDbCommand 
      // for querying the MyPatient table
      // The generated WHERE clause contains PatientName and PatientSex
      public void MyExample()
      {
         MatchingParameterCollection matchingParamCollection = new MatchingParameterCollection();
         MatchingParameterList matchingParamList = new MatchingParameterList();

         MyPatient myPatient = new MyPatient();
         myPatient.PatientName = "Smith";
         myPatient.PatientSex = "M";

         matchingParamList.Add(myPatient);
         matchingParamCollection.Add(matchingParamList);

         IDbCommand command = new SqlCommand();
         
         // This reads the storage catalog
         // Before you run this, make sure and add the following to your application configuration file
         
         //<configSections>
         //    <section name="xmlStorageCatalogSettings" type="Leadtools.Medical.Storage.DataAccessLayer.XmlStorageCatalogSettings, Leadtools.Medical.Storage.DataAccessLayer" />
         //</configSections>
         StorageCatalog myCatalog = new StorageCatalog();

         Collection<CatalogElement[]> catalogElements = CatalogDescriptor.GetElementsCollection(matchingParamCollection, myCatalog , true);

         PreparePatientsQueryCommand(command, catalogElements, ExtraQueryOptions.Typical);
         
         // The 'WHERE' clause of command.CommandText is the following:
         //    WHERE ( (  MyPatientTable.PatientName LIKE  'Smith' ) AND (  MyPatientTable.PatientSex LIKE  'M' ) )
         Console.WriteLine(command.CommandText);
      }
      
      // This example is a test to build all queries
      public void MySampleQueries()
      {
         MatchingParameterCollection matchingParamCollection = new MatchingParameterCollection();
         MatchingParameterList matchingParamList = new MatchingParameterList();
         matchingParamCollection.Add(matchingParamList);

         StorageCatalog myCatalog = new StorageCatalog();
         Collection<CatalogElement[]> catalogElements = CatalogDescriptor.GetElementsCollection(matchingParamCollection, myCatalog, true);

         IDbCommand command = new SqlCommand();
         
         PreparePatientsQueryCommand(command, catalogElements, ExtraQueryOptions.Typical);
         PrepareStudiesQueryCommand(command, catalogElements, ExtraQueryOptions.Typical);
         PrepareSeriesQueryCommand(command, catalogElements, ExtraQueryOptions.Typical);
         PrepareInstanceQueryCommand(command, catalogElements,ExtraQueryOptions.Typical);
         
         PrepareDeletePatientsCommand(command, catalogElements, ExtraQueryOptions.Typical);
         PrepareDeleteStudiesCommand(command, catalogElements, ExtraQueryOptions.Typical);
         PrepareDeleteSeriesCommand(command, catalogElements, ExtraQueryOptions.Typical);
         PrepareDeleteInstanceCommand(command, catalogElements, ExtraQueryOptions.Typical);
         
         PrepareDeletePatientsNoChildStudiesCommand(command);
         PrepareDeleteStudiesNoChildSeriesCommand(command);
         PrepareDeleteSeriesNoChildInstancesCommand(command);
         
         DeletePatient(matchingParamCollection);
         DeleteStudy(matchingParamCollection);
         DeleteSeries(matchingParamCollection);
         DeleteInstance(matchingParamCollection);
         
         PrepareIsPatientExistsCommand(command, "1111");
         PrepareIsStudyExistsCommand(command, "2222");
         PrepareIsSeriesExistsCommand(command, "3333");
         PrepareIsInstanceExistsCommand(command, "4444");
      }

      /// <summary>
      /// Prepares an Instance level command when using pagination.  
      /// Pagination returns results in one or more pages of data, where the user specifies the page size.  
      /// The pagination feature is not implemented in this sample data access agent
      /// </summary>
      /// <param name="command">IDbCommand that is created</param>
      /// <param name="matchingParamsCollection">Contains the query parameters that are used to generate the WHERE statement</param>
      /// <param name="queryPageInfo"></param>
      protected override void PrepareInstancePageQueryCommand
      (
         IDbCommand command,
         Collection<CatalogElement[]> matchingParamsCollection,
         QueryPageInfo queryPageInfo
      )
      {
         command.CommandText = "exec sp_executeSQL @CMD";

         string cmdText = GetInstanceCommandText(matchingParamsCollection, queryPageInfo);

         command.Parameters.Add(new SqlParameter("@CMD", cmdText));

         command.CommandType = CommandType.Text;
      }


      // ***************
      // Count Commands
      // ***************
      private bool IsNoTableSpecifiedInParams( Collection<CatalogElement[]> matchingParamsCollection )
      {
         return (matchingParamsCollection == null || matchingParamsCollection.Count == 0 ||
                  (matchingParamsCollection != null &&
                    matchingParamsCollection.Count == 1 &&
                    matchingParamsCollection[0].Length == 0
                  )
                );
      }

      /// <summary>
      /// Creates a command that returns a count of patient rows matching the search criteria specified in the matchingParamsCollection
      /// </summary>
      /// <param name="command">IDbCommand that is created</param>
      /// <param name="matchingParamsCollection">Contains the query parameters that are used to generate the WHERE statement</param>
      protected override void PreparePatientsQueryCountCommand(IDbCommand command, Collection<CatalogElement[]> matchingParamsCollection, ExtraQueryOptions extraQueryOptions)
      {
         command.CommandText = string.Format ( MySqlStatments.SqlSpecificSelectCount, "MyPatientTable" ) ;
      }

      /// <summary>
      /// Creates a command that returns a count of study rows matching the search criteria specified in the matchingParamsCollection
      /// </summary>
      /// <param name="command">IDbCommand that is created</param>
      /// <param name="matchingParamsCollection">Contains the query parameters that are used to generate the WHERE statement</param>
      protected override void PrepareStudiesQueryCountCommand(IDbCommand command, Collection<CatalogElement[]> matchingParamsCollection, ExtraQueryOptions extraQueryOptions)
      {
         command.CommandText = string.Format ( MySqlStatments.SqlSpecificSelectCount, "MyStudyTable" ) ;
      }

      /// <summary>
      /// Creates a command that returns a count of series rows matching the search criteria specified in the matchingParamsCollection
      /// </summary>
      /// <param name="command">IDbCommand that is created</param>
      /// <param name="matchingParamsCollection">Contains the query parameters that are used to generate the WHERE statement</param>
      protected override void PrepareSeriesQueryCountCommand(IDbCommand command, Collection<CatalogElement[]> matchingParamsCollection, ExtraQueryOptions extraQueryOptions)
      {
         command.CommandText = string.Format ( MySqlStatments.SqlSpecificSelectCount, "MySeriesTable" ) ;
      }

      /// <summary>
      /// Creates a command that returns a count of instance rows matching the search criteria specified in the matchingParamsCollection
      /// </summary>
      /// <param name="command">IDbCommand that is created</param>
      /// <param name="matchingParamsCollection">Contains the query parameters that are used to generate the WHERE statement</param>
      protected override void PrepareInstanceQueryCountCommand(IDbCommand command, Collection<CatalogElement[]> matchingParamsCollection, ExtraQueryOptions extraQueryOptions)
      {
         if (IsNoTableSpecifiedInParams(matchingParamsCollection))
         {
            command.CommandText = string.Format(MySqlStatments.SqlSpecificSelectCount, "MyInstanceTable");
         }
         else
               {
                  StringBuilder sb = new StringBuilder ( 500 ) ;
                  
                  
                  sb.Append ( MyConstants.SelectCommandText.FirstPart ) ;
                  sb.Append ( MyConstants.SelectCommandText.FromClause.Image ) ;
                  sb.Append ( SqlProviderUtilities.GenerateWhereStatement ( matchingParamsCollection ) ) ;
                  sb.Append ( MyConstants.SelectCommandText.MIDDLE_PART ) ;
                  sb.Append ( string.Format ( MySqlStatments.InstanceEntitySelect.InstanceCount, MyConstants.PrimaryKeyTableName ) ) ;
                  sb.Append ( MyConstants.SelectCommandText.LAST_PART ) ;
                  
                  command.CommandText = sb.ToString ( ) ;
               }
      }

      // ***************
      // Delete Commands
      // ***************
      private string MyGetDeleteCommandText(Collection<CatalogElement[]> matchingParamsCollection, string fromPart)
      {
         try
         {
            StringBuilder sb = new StringBuilder(fromPart);

            sb.Append(MyConstants.SelectCommandText.FromClause.Image);
            sb.Append(SqlProviderUtilities.GenerateWhereStatement(matchingParamsCollection));
            sb.Append(MyConstants.DeleteCommandText.DeleteLastPart);

            return sb.ToString();
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.WriteLine(exception.Message);
            System.Diagnostics.Debug.Assert(false);

            throw;
         }
      }

      /// <summary>
      /// Creates a command to delete rows of the 'patient' table based on the search criteria specified in the matchingParamsCollection
      /// </summary>
      /// <param name="command">IDbCommand that is created</param>
      /// <param name="matchingParamsCollection">Contains the query parameters that are used to generate the WHERE statement</param>
      protected override void PrepareDeletePatientsCommand(IDbCommand command, Collection<CatalogElement[]> matchingParametersCollection, ExtraQueryOptions extraQueryOptions)
      {
         command.CommandText = MyGetDeleteCommandText(matchingParametersCollection, MyConstants.DeleteCommandText.FromPatient);
         command.CommandType = CommandType.Text;
      }

      /// <summary>
      /// Creates a command to delete rows of the 'study' table based on the search criteria specified in the matchingParamsCollection
      /// </summary>
      /// <param name="command">IDbCommand that is created</param>
      /// <param name="matchingParamsCollection">Contains the query parameters that are used to generate the WHERE statement</param>
      protected override void PrepareDeleteStudiesCommand(IDbCommand command, Collection<CatalogElement[]> matchingParametersCollection, ExtraQueryOptions extraQueryOptions)
      {
         command.CommandText = MyGetDeleteCommandText(matchingParametersCollection, MyConstants.DeleteCommandText.FromStudy);
         command.CommandType = CommandType.Text;
      }

      /// <summary>
      /// Creates a command to delete rows of the 'series' table based on the search criteria specified in the matchingParamsCollection
      /// </summary>
      /// <param name="command">IDbCommand that is created</param>
      /// <param name="matchingParamsCollection">Contains the query parameters that are used to generate the WHERE statement</param>
      protected override void PrepareDeleteSeriesCommand(IDbCommand command, Collection<CatalogElement[]> matchingParametersCollection, ExtraQueryOptions extraQueryOptions)
      {
         command.CommandText = MyGetDeleteCommandText(matchingParametersCollection, MyConstants.DeleteCommandText.FromSeries);
         command.CommandType = CommandType.Text;
      }

      /// <summary>
      /// Creates a command to delete rows of the 'instance' table based on the search criteria specified in the matchingParamsCollection
      /// </summary>
      /// <param name="command">IDbCommand that is created</param>
      /// <param name="matchingParamsCollection">Contains the query parameters that are used to generate the WHERE statement</param>
      protected override void PrepareDeleteInstanceCommand(IDbCommand command, Collection<CatalogElement[]> matchingParametersCollection, ExtraQueryOptions extraQueryOptions)
      {
         command.CommandText = MyGetDeleteCommandText(matchingParametersCollection, MyConstants.DeleteCommandText.FromInstance);
         command.CommandType = CommandType.Text;
      }

      // ******************************
      // Delete NoChild Commands
      // ******************************
      
      /// <summary>
      /// Creates a command to delete rows from the 'patient' table that has no corresponding rows in the 'study' child table.  
      /// </summary>
      /// <param name="command">IDbCommand that is created</param>
      protected override void PrepareDeletePatientsNoChildStudiesCommand(IDbCommand command)
      {
         command.CommandType = CommandType.Text;
         command.CommandText = MyConstants.DeleteCommandText.OrphanPatient;
      }

     /// <summary>
      /// Creates a command to delete rows from the 'study' table that has no corresponding rows in the 'series' child table.  
      /// </summary>
      /// <param name="command">IDbCommand that is created</param>
      protected override void PrepareDeleteStudiesNoChildSeriesCommand(IDbCommand command)
      {
         command.CommandType = CommandType.Text;
         command.CommandText = MyConstants.DeleteCommandText.OrphanStudies;
      }

     /// <summary>
      /// Creates a command to delete rows from the 'series' table that has no corresponding rows in the 'instance' child table.  
      /// </summary>
      /// <param name="command">IDbCommand that is created</param>
      protected override void PrepareDeleteSeriesNoChildInstancesCommand(IDbCommand command)
      {
         command.CommandType = CommandType.Text;
         command.CommandText = MyConstants.DeleteCommandText.OrphanSeries;
      }


      // ******************************
      // Exists Commands
      // ******************************
      
      /// <summary>
      /// Creates a command to test for existence of a patient based on PatientID
      /// </summary>
      /// <param name="command">IDbCommand that is created</param>
      /// <param name="patientID">PatientID of the patient</param>
      protected override void PrepareIsPatientExistsCommand(IDbCommand command, string patientID)
      {
         command.CommandType = CommandType.Text;
         command.CommandText = string.Format("SELECT PatientIdentification FROM MyPatientTable WHERE PatientIdentification='{0}'", patientID);
      }

      /// <summary>
      /// Creates a command to test for existence of a study based on StudyInstanceUID
      /// </summary>
      /// <param name="command">IDbCommand that is created</param>
      /// <param name="studyInstanceUID">Study Instance Unique ID of the study</param>
      protected override void PrepareIsStudyExistsCommand(IDbCommand command, string studyInstanceUID)
      {
         command.CommandType = CommandType.Text;
         command.CommandText = string.Format("SELECT StudyStudyInstanceUID FROM MyStudyTable WHERE StudyStudyInstanceUID='{0}'", studyInstanceUID);
      }

      /// <summary>
      /// Creates a command to test for existence of a series based on SeriesInstanceUID
      /// </summary>
      /// <param name="command">IDbCommand that is created</param>
      /// <param name="seriesInstanceUID">Series Instance Unique ID of the series</param>
      protected override void PrepareIsSeriesExistsCommand(IDbCommand command, string seriesInstanceUID)
      {
         command.CommandType = CommandType.Text;
         command.CommandText = string.Format("SELECT SeriesSeriesInstanceUID FROM MySeriesTable WHERE SeriesSeriesInstanceUID='{0}'", seriesInstanceUID);
      }

      /// <summary>
      /// Creates a command to test for existence of an instance based on SOPInstanceUID
      /// </summary>
      /// <param name="command">IDbCommand that is created</param>
      /// <param name="sopInstanceUID">SOP Instance Unique ID of the instance</param>
      protected override void PrepareIsInstanceExistsCommand(IDbCommand command, string sopInstanceUID)
      {
         command.CommandType = CommandType.Text;
         command.CommandText = string.Format("SELECT SOPInstanceUID FROM MyInstanceTable WHERE SOPInstanceUID='{0}'", sopInstanceUID);
      }

      // ******************************
      // Other Commands
      // ******************************

      // Instance
      private DbCommand CreateDeleteInstanceCommand(DbConnection connection) 
      {
         DbCommand DeleteCommand = connection.CreateCommand();
         
         DeleteCommand.CommandText = "DELETE FROM [MyInstanceTable] WHERE (([SOPInstanceUID] = @Original_SOPInstanceUID))";
         DeleteCommand.CommandType = System.Data.CommandType.Text;
         
         DataProvider.AddInParameter ( DeleteCommand, "@Original_SOPInstanceUID", DbType.String, "SOPInstanceUID", System.Data.DataRowVersion.Original);
      
         return DeleteCommand ;
      }
      
      private DbCommand CreateInsertInstanceCommand ( DbConnection connection ) 
      {
         DbCommand InsertCommand = connection.CreateCommand();
         
         InsertCommand.CommandText = @"INSERT INTO [MyInstanceTable] ([ImageSeriesId], [SOPInstanceUID], [ImageImageNumber], [ImageLastStoreDate], [ImageFilename], [ImageUniqueSOPClassUID], [ImageRows], [ImageColumns], [ImageBitsAllocated]) 
                                       VALUES                        (@ImageSeriesId,  @SOPInstanceUID,  @ImageImageNumber,  @ImageLastStoreDate,  @ImageFilename,  @ImageUniqueSOPClassUID,  @ImageRows,  @ImageColumns,  @ImageBitsAllocated); 
                                       SELECT ImageId FROM MyInstanceTable WHERE (ImageId = SCOPE_IDENTITY())";
         InsertCommand.CommandType = global::System.Data.CommandType.Text;
         
         DataProvider.AddInParameter ( InsertCommand, "@ImageSeriesId",          DbType.Int32,      "ImageSeriesId",          System.Data.DataRowVersion.Current);
         DataProvider.AddInParameter ( InsertCommand, "@SOPInstanceUID",         DbType.String,     "SOPInstanceUID",         System.Data.DataRowVersion.Current);
         DataProvider.AddInParameter ( InsertCommand, "@ImageImageNumber",       DbType.Int32,      "ImageImageNumber",       System.Data.DataRowVersion.Current);
         DataProvider.AddInParameter ( InsertCommand, "@ImageLastStoreDate",     DbType.Date,       "ImageLastStoreDate",     System.Data.DataRowVersion.Current);
         DataProvider.AddInParameter ( InsertCommand, "@ImageFilename",          DbType.String,     "ImageFilename",          System.Data.DataRowVersion.Current);
         DataProvider.AddInParameter ( InsertCommand, "@ImageUniqueSOPClassUID", DbType.String,     "ImageUniqueSOPClassUID", System.Data.DataRowVersion.Current);
         DataProvider.AddInParameter ( InsertCommand, "@ImageRows",              DbType.Int64,      "ImageRows",              System.Data.DataRowVersion.Current);
         DataProvider.AddInParameter ( InsertCommand, "@ImageColumns",           DbType.Int64,      "ImageColumns",           System.Data.DataRowVersion.Current);
         DataProvider.AddInParameter ( InsertCommand, "@ImageBitsAllocated",     DbType.Int64,      "ImageBitsAllocated",     System.Data.DataRowVersion.Current);
         
         return InsertCommand ;
      }
      
      private DbCommand CreateUpdateInstanceCommand ( DbConnection connection ) 
      {
         DbCommand UpdateCommand = connection.CreateCommand ( ) ;

         UpdateCommand.CommandText = @"UPDATE [MyInstanceTable] SET 
                                       [ImageSeriesId]            = @ImageSeriesId, 
                                       [SOPInstanceUID]           = @SOPInstanceUID, 
                                       [ImageImageNumber]         = @ImageImageNumber, 
                                       [ImageLastStoreDate]       = @ImageLastStoreDate, 
                                       [ImageFilename]            = @ImageFilename, 
                                       [ImageUniqueSOPClassUID]   = @ImageUniqueSOPClassUID, 
                                       [ImageRows]                = @ImageRows, 
                                       [ImageColumns]             = @ImageColumns, 
                                       [ImageBitsAllocated]       = @ImageBitsAllocated 
                                     WHERE (([SOPInstanceUID] = @Original_SOPInstanceUID))";
         UpdateCommand.CommandType = System.Data.CommandType.Text;

         DataProvider.AddInParameter ( UpdateCommand, "@ImageSeriesId",          DbType.Int32,      "ImageSeriesId",          System.Data.DataRowVersion.Current);
         DataProvider.AddInParameter ( UpdateCommand, "@SOPInstanceUID",         DbType.String,     "SOPInstanceUID",         System.Data.DataRowVersion.Current);
         DataProvider.AddInParameter ( UpdateCommand, "@ImageImageNumber",       DbType.Int32,      "ImageImageNumber",       System.Data.DataRowVersion.Current);
         DataProvider.AddInParameter ( UpdateCommand, "@ImageLastStoreDate",     DbType.Date,       "ImageLastStoreDate",     System.Data.DataRowVersion.Current);
         DataProvider.AddInParameter ( UpdateCommand, "@ImageFilename",          DbType.String,     "ImageFilename",          System.Data.DataRowVersion.Current);
         DataProvider.AddInParameter ( UpdateCommand, "@ImageUniqueSOPClassUID", DbType.String,     "ImageUniqueSOPClassUID", System.Data.DataRowVersion.Current);
         DataProvider.AddInParameter ( UpdateCommand, "@ImageRows",              DbType.Int64,      "ImageRows",              System.Data.DataRowVersion.Current);
         DataProvider.AddInParameter ( UpdateCommand, "@ImageColumns",           DbType.Int64,      "ImageColumns",           System.Data.DataRowVersion.Current);
         DataProvider.AddInParameter ( UpdateCommand, "@ImageBitsAllocated",     DbType.Int64,      "ImageBitsAllocated",     System.Data.DataRowVersion.Current);
         
         return UpdateCommand ;
      }

      // Patient
      private DbCommand CreateUpdatePatientCommnad ( DbConnection connection ) 
      {
         DbCommand UpdateCommand = connection.CreateCommand();
         
         UpdateCommand.CommandText = @"UPDATE [MyPatientTable] SET [PatientIdentification] = @PatientIdentification, [PatientName] = @PatientName, [PatientBirthday] = @PatientBirthday, [PatientSex] = @PatientSex, [PatientComments] = @PatientComments WHERE ( [PatientIdentification] = @Original_PatientID )";
         UpdateCommand.CommandType = System.Data.CommandType.Text;
         
         // DataProvider.AddInParameter ( UpdateCommand, "@PatientID",              DbType.String, "PatientID",               System.Data.DataRowVersion.Current);
         DataProvider.AddInParameter ( UpdateCommand, "@PatientIdentification",  DbType.String,    "PatientIdentification",   System.Data.DataRowVersion.Current);
         DataProvider.AddInParameter ( UpdateCommand, "@PatientName",            DbType.String,    "PatientName",             System.Data.DataRowVersion.Current);
         DataProvider.AddInParameter ( UpdateCommand, "@PatientBirthday",        DbType.Date,      "PatientBirthday",         System.Data.DataRowVersion.Current);
         DataProvider.AddInParameter ( UpdateCommand, "@PatientSex",             DbType.String,    "PatientSex",              System.Data.DataRowVersion.Current);
         DataProvider.AddInParameter ( UpdateCommand, "@PatientComments",        DbType.String,    "PatientComments",         System.Data.DataRowVersion.Current);
         
         return UpdateCommand ;
      }
      
      
      private DbCommand CreateInsertPatientCommand ( DbConnection connection ) 
      {
         DbCommand InsertCommand = connection.CreateCommand();
         
         InsertCommand.CommandText = @"INSERT INTO [MyPatientTable] ([PatientIdentification], [PatientName], [PatientBirthday], [PatientSex], [PatientComments]) 
                                       VALUES                       (@PatientIdentification,  @PatientName,  @PatientBirthday,  @PatientSex,  @PatientComments); 
                                       SELECT PatientId FROM MyPatientTable WHERE (PatientId = SCOPE_IDENTITY())";
         InsertCommand.CommandType = global::System.Data.CommandType.Text;
         DataProvider.AddInParameter ( InsertCommand, "@PatientIdentification",  DbType.String, "PatientIdentification",   System.Data.DataRowVersion.Current);
         DataProvider.AddInParameter ( InsertCommand, "@PatientName",            DbType.String, "PatientName",             System.Data.DataRowVersion.Current);
         DataProvider.AddInParameter ( InsertCommand, "@PatientBirthday",        DbType.Date,   "PatientBirthday",         System.Data.DataRowVersion.Current);
         DataProvider.AddInParameter ( InsertCommand, "@PatientSex",             DbType.String, "PatientSex",              System.Data.DataRowVersion.Current);
         DataProvider.AddInParameter ( InsertCommand, "@PatientComments",        DbType.String, "PatientComments",         System.Data.DataRowVersion.Current);
         DataProvider.AddOutParameter( InsertCommand, "@PatientId",              DbType.Int32, 4 );
      
         return InsertCommand ;
      }
      
      private DbCommand CreateDeletePatientCommand ( DbConnection connection ) 
      {
         DbCommand DeleteCommand = connection.CreateCommand ( ) ;
         
         DeleteCommand.CommandText = @"DELETE FROM [MyPatientTable] WHERE ([PatientIdentification] = @Original_PatientID) ";
         DeleteCommand.CommandType = System.Data.CommandType.Text;
         DataProvider.AddInParameter ( DeleteCommand, "@Original_PatientID", DbType.String, "PatientID", System.Data.DataRowVersion.Original);
      
         return DeleteCommand ;
      }
      
      // Study
      private DbCommand CreateInsertStudyCommand ( DbConnection connection ) 
      {
         DbCommand InsertCommand = connection.CreateCommand();
         
         InsertCommand.CommandText = @"INSERT INTO [MyStudyTable] ([StudyPatientId], [StudyStudyInstanceUID], [StudyStudyDate], [StudyAccessionNumber], [StudyStudyDescription], [StudyReferringPhysiciansName], [StudyStudyId]) 
                                                           VALUES (@StudyPatientId,  @StudyStudyInstanceUID,  @StudyStudyDate,  @StudyAccessionNumber,  @StudyStudyDescription,  @StudyReferringPhysiciansName,  @StudyStudyId );
                                       SELECT StudyId FROM MyStudyTable WHERE (StudyId = SCOPE_IDENTITY())";
                                                    
         InsertCommand.CommandType = global::System.Data.CommandType.Text;
         DataProvider.AddInParameter ( InsertCommand, "@StudyId",                DbType.Int32,  "StudyId",             System.Data.DataRowVersion.Current);
         DataProvider.AddInParameter ( InsertCommand, "@StudyPatientId",         DbType.Int32,  "StudyPatientId",             System.Data.DataRowVersion.Current);
         DataProvider.AddInParameter ( InsertCommand, "@StudyStudyInstanceUID",  DbType.String, "StudyStudyInstanceUID",      System.Data.DataRowVersion.Current);
         DataProvider.AddInParameter ( InsertCommand, "@StudyStudyDate",         DbType.Date,   "StudyStudyDate",             System.Data.DataRowVersion.Current);
         DataProvider.AddInParameter ( InsertCommand, "@StudyAccessionNumber",   DbType.Int32,  "StudyAccessionNumber",       System.Data.DataRowVersion.Current);
         DataProvider.AddInParameter ( InsertCommand, "@StudyStudyDescription",  DbType.String, "StudyStudyDescription",      System.Data.DataRowVersion.Current);
         DataProvider.AddInParameter ( InsertCommand, "@StudyReferringPhysiciansName",  DbType.String, "StudyReferringPhysiciansName",      System.Data.DataRowVersion.Current);
         DataProvider.AddInParameter ( InsertCommand, "@StudyStudyId",           DbType.String, "StudyStudyId",               System.Data.DataRowVersion.Current);

         return InsertCommand ;
      }
      
      private DbCommand CreateUpdateStudyCommnad ( DbConnection connection ) 
      {
         DbCommand UpdateCommand = connection.CreateCommand();
         
         UpdateCommand.CommandText = @"UPDATE [MyStudyTable] SET 
                                       [StudyStudyId]             = @StudyStudyId, 
                                       [StudyPatientId]           = @StudyPatientId, 
                                       [StudyStudyInstanceUID]    = @StudyStudyInstanceUID, 
                                       [StudyStudyDate]           = @StudyStudyDate, 
                                       [StudyAccessionNumber]     = @StudyAccessionNumber, 
                                       [StudyStudyDescription]    = @StudyStudyDescription, 
                                       [StudyReferringPhysiciansName]    = @StudyReferringPhysiciansName, 
                                   WHERE ( [StudyInstanceUID]     = @Original_StudyInstanceUID )";
         UpdateCommand.CommandType = System.Data.CommandType.Text;

         DataProvider.AddInParameter( UpdateCommand, " @StudyStudyId",           DbType.String, "StudyStudyId",               System.Data.DataRowVersion.Current);
         DataProvider.AddInParameter ( UpdateCommand, "@StudyPatientId",         DbType.Int32,  "StudyPatientId",             System.Data.DataRowVersion.Current);
         DataProvider.AddInParameter ( UpdateCommand, "@StudyStudyInstanceUID",  DbType.String, "StudyStudyInstanceUID",      System.Data.DataRowVersion.Current);
         DataProvider.AddInParameter ( UpdateCommand, "@StudyStudyDate",         DbType.Date,   "StudyStudyDate",             System.Data.DataRowVersion.Current);
         DataProvider.AddInParameter ( UpdateCommand, "@StudyAccessionNumber",   DbType.String,  "StudyAccessionNumber",       System.Data.DataRowVersion.Current);
         DataProvider.AddInParameter ( UpdateCommand, "@StudyStudyDescription",  DbType.String, "StudyStudyDescription",      System.Data.DataRowVersion.Current);
         DataProvider.AddInParameter ( UpdateCommand, "@StudyReferringPhysiciansName",  DbType.String, "StudyReferringPhysiciansName",      System.Data.DataRowVersion.Current);
         
         DataProvider.AddInParameter ( UpdateCommand, "@Original_StudyInstanceUID", DbType.String, "StudyInstanceUID", System.Data.DataRowVersion.Original);
         
         return UpdateCommand ;
      }
      
      private DbCommand CreateDeleteStudyCommand ( DbConnection connection ) 
      {
         DbCommand DeleteCommand = connection.CreateCommand ( ) ;


         DeleteCommand.CommandText = "DELETE FROM [MyStudyTable] WHERE (([StudyInstanceUID] = @Original_StudyInstanceUID))" ;
         DeleteCommand.CommandType = System.Data.CommandType.Text;
         
         DataProvider.AddInParameter ( DeleteCommand, "@Original_StudyInstanceUID", DbType.String, "StudyInstanceUID", System.Data.DataRowVersion.Original);
      
         return DeleteCommand ;
      }
      
      // Series
      private DbCommand CreateInsertSeriesCommand ( DbConnection connection ) 
      {
         DbCommand InsertCommand = connection.CreateCommand();
         
         InsertCommand.CommandText = @"INSERT INTO [MySeriesTable] ([SeriesStudyId], [SeriesSeriesInstanceUID], [SeriesBodyPartExamined], [SeriesSeriesNumber], [SeriesSeriesDescription], [SeriesSeriesDate], [SeriesModality]) 
                                       VALUES                       (@SeriesStudyId,  @SeriesSeriesInstanceUID, @SeriesBodyPartExamined,  @SeriesSeriesNumber,  @SeriesSeriesDescription,   @SeriesSeriesDate, @SeriesModality);
                                       SELECT       SeriesId FROM MySeriesTable WHERE (SeriesId = SCOPE_IDENTITY())";
                                                    
         InsertCommand.CommandType = global::System.Data.CommandType.Text;
         DataProvider.AddInParameter ( InsertCommand, "@SeriesId",                  DbType.Int32,  "SeriesId",                System.Data.DataRowVersion.Current);
         DataProvider.AddInParameter ( InsertCommand, "@SeriesStudyId",             DbType.Int32,  "SeriesStudyId",           System.Data.DataRowVersion.Current);
         DataProvider.AddInParameter ( InsertCommand, "@SeriesSeriesInstanceUID",   DbType.String, "SeriesSeriesInstanceUID", System.Data.DataRowVersion.Current);
         DataProvider.AddInParameter ( InsertCommand, "@SeriesBodyPartExamined",    DbType.String,  "SeriesBodyPartExamined", System.Data.DataRowVersion.Current);
         DataProvider.AddInParameter ( InsertCommand, "@SeriesSeriesNumber",        DbType.Int32,  "SeriesSeriesNumber",      System.Data.DataRowVersion.Current);
         DataProvider.AddInParameter ( InsertCommand, "@SeriesSeriesDescription",   DbType.String, "SeriesSeriesDescription", System.Data.DataRowVersion.Current);
         DataProvider.AddInParameter ( InsertCommand, "@SeriesSeriesDate",          DbType.Date,   "SeriesSeriesDate",        System.Data.DataRowVersion.Current);
         DataProvider.AddInParameter ( InsertCommand, "@SeriesModality",            DbType.String, "SeriesModality",          System.Data.DataRowVersion.Current);
      
         return InsertCommand ;
      }
      
      private DbCommand CreateUpdateSeriesCommnad ( DbConnection connection ) 
      {
         DbCommand UpdateCommand = connection.CreateCommand();
         
         UpdateCommand.CommandText = @"UPDATE [MySeriesTable] SET 
                                       [SeriesStudyId]               = @SeriesStudyId, 
                                       [SeriesSeriesInstanceUID]     = @SeriesSeriesInstanceUID, 
                                       [SeriesBodyPartExamined]      = @SeriesBodyPartExamined, 
                                       [SeriesSeriesNumber]          = @SeriesSeriesNumber, 
                                       [SeriesSeriesDescription]     = @SeriesSeriesDescription, 
                                       [SeriesSeriesDate]            = @SeriesSeriesDate,
                                       [SeriesModality]              = @SeriesModality
                                   WHERE ( [SeriesInstanceUID] = @Original_SeriesInstanceUID )";
         
         UpdateCommand.CommandType = System.Data.CommandType.Text;
         
         DataProvider.AddInParameter ( UpdateCommand, "@SeriesId",                  DbType.Int32,  "SeriesId",                System.Data.DataRowVersion.Current);
         DataProvider.AddInParameter ( UpdateCommand, "@SeriesStudyId",             DbType.Int32,  "SeriesStudyId",           System.Data.DataRowVersion.Current);
         DataProvider.AddInParameter ( UpdateCommand, "@SeriesSeriesInstanceUID",   DbType.String, "SeriesSeriesInstanceUID", System.Data.DataRowVersion.Current);
         DataProvider.AddInParameter ( UpdateCommand, "@SeriesBodyPartExamined",    DbType.String, "SeriesBodyPartExamined",  System.Data.DataRowVersion.Current);
         DataProvider.AddInParameter ( UpdateCommand, "@SeriesSeriesNumber",        DbType.Int32,  "SeriesSeriesNumber",      System.Data.DataRowVersion.Current);
         DataProvider.AddInParameter ( UpdateCommand, "@SeriesSeriesDescription",   DbType.String, "SeriesSeriesDescription", System.Data.DataRowVersion.Current);
         DataProvider.AddInParameter ( UpdateCommand, "@SeriesSeriesDate",          DbType.Date,   "SeriesSeriesDate",        System.Data.DataRowVersion.Current);
         DataProvider.AddInParameter ( UpdateCommand, "@SeriesModality",            DbType.String, "SeriesModality",          System.Data.DataRowVersion.Current);
         
         DataProvider.AddInParameter ( UpdateCommand, "@Original_SeriesInstanceUID", DbType.String, "SeriesInstanceUID", System.Data.DataRowVersion.Original);
         
         return UpdateCommand ;
      }
      
      private DbCommand CreateDeleteSeriesCommand ( DbConnection connection ) 
      {
         DbCommand DeleteCommand = connection.CreateCommand ( ) ;


         DeleteCommand.CommandText = "DELETE FROM [MySeriesTable] WHERE (([SeriesInstanceUID] = @Original_SeriesInstanceUID))" ;
         DeleteCommand.CommandType = System.Data.CommandType.Text;
         
         DataProvider.AddInParameter ( DeleteCommand, "@Original_SeriesInstanceUID", DbType.String, "SeriesInstanceUID", System.Data.DataRowVersion.Original);
      
         return DeleteCommand ;
      }
      
      
      DbDataAdapter MyCreateDataAdapter()
      {
         DbDataAdapter da = DataProvider.DbProviderFactory.CreateDataAdapter();
         if (da != null)
         {
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
         }
         return da;
      }

      // UpdateTable
      private void MyUpdateTable
            (
               MyDataSet updatingDataset,
               DbConnection updatingDbConnection,
               DbTransaction updatingTransaction,
               string tableName
            )
      {
         if (tableName == updatingDataset.MyPatientTable.TableName)
         {
            SqlProviderUtilities.UpdateTable ( updatingDataset, 
                                               updatingDbConnection, 
                                               updatingTransaction, 
                                               MyCreateDataAdapter(),
                                               CreateInsertPatientCommand ( updatingDbConnection ),
                                               CreateUpdatePatientCommnad(updatingDbConnection),
                                               CreateDeletePatientCommand ( updatingDbConnection ),
                                               tableName,
                                               false,
                                               true,
                                               true,
                                               true ) ;
         }
         else if ( tableName == updatingDataset.MyStudyTable.TableName )
         {
            SqlProviderUtilities.UpdateTable ( updatingDataset, 
                                               updatingDbConnection, 
                                               updatingTransaction, 
                                               MyCreateDataAdapter(),
                                               CreateInsertStudyCommand ( updatingDbConnection ),
                                               CreateUpdateStudyCommnad(updatingDbConnection),
                                               CreateDeleteStudyCommand ( updatingDbConnection ),
                                               tableName,
                                               false,
                                               true,
                                               true,
                                               true ) ;
         }
         else if ( tableName == updatingDataset.MySeriesTable.TableName )
         {
            SqlProviderUtilities.UpdateTable ( updatingDataset, 
                                               updatingDbConnection, 
                                               updatingTransaction, 
                                               MyCreateDataAdapter(),
                                               CreateInsertSeriesCommand ( updatingDbConnection ),
                                               CreateUpdateSeriesCommnad(updatingDbConnection),
                                               CreateDeleteSeriesCommand ( updatingDbConnection ),
                                               tableName,
                                               false,
                                               true,
                                               true,
                                               true ) ;
         }
         else if (tableName == updatingDataset.MyInstanceTable.TableName)
         {
            SqlProviderUtilities.UpdateTable ( updatingDataset,
                                               updatingDbConnection,
                                               updatingTransaction,
                                               MyCreateDataAdapter(),
                                               CreateInsertInstanceCommand(updatingDbConnection),
                                               CreateUpdateInstanceCommand(updatingDbConnection),
                                               CreateDeleteInstanceCommand(updatingDbConnection),
                                               tableName,
                                               false,
                                               true,
                                               true,
                                               true);
         }
         else
         {
            SqlProviderUtilities.UpdateTable ( updatingDataset, 
                                               updatingDbConnection, 
                                               updatingTransaction, 
                                               DataProvider.DbProviderFactory.CreateDataAdapter ( ),
                                               DataProvider.DbProviderFactory.CreateCommandBuilder ( ),
                                               tableName,
                                               true,
                                               true,
                                               true,
                                               true ) ;
         }
      }

      /// <summary>
      /// Returns a list containing the all tables names in the database
      /// </summary>
      /// <param name="dataset">The strongly typed DataSet that corresponds to the custom database (i.e. MyDicomDataSet)</param>
      /// <returns>
      /// A list containing the all tables names in the database
      /// </returns>
      protected override string[] GetCompositeInstanceQueryDataAdapterTables(DataSet dataset, ExtraQueryOptions extraQueryOptions)
      {
         MyDataSet myDataSet = new MyDataSet();
         myDataSet.Merge(dataset);

         try
         {
            List<string> instanceQueryTables = new List<string>();

            //Patient entity mapping
            instanceQueryTables.Add(myDataSet.MyPatientTable.TableName);

            //Study entity mapping
            instanceQueryTables.Add(myDataSet.MyStudyTable.TableName);

            //Series entity mapping
            instanceQueryTables.Add(myDataSet.MySeriesTable.TableName);

            //Image entity mapping
            instanceQueryTables.Add(myDataSet.MyInstanceTable.TableName);

            return instanceQueryTables.ToArray();
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.WriteLine(exception.Message);
            System.Diagnostics.Debug.Assert(false);

            throw;
         }
      }
     }
}
