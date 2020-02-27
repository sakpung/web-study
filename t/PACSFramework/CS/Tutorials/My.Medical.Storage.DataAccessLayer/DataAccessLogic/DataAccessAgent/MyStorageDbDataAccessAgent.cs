// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using My.Medical.Storage.DataAccessLayer.DataAccessLogic.BusinessEntity;
using My.Medical.Storage.DataAccessLayer.DataAccessLogic.DicomDataSetConvertor;
using Leadtools.Dicom;
using Leadtools.Medical.DataAccessLayer;
using My.Medical.Storage.DataAccessLayer.Entities;
using Leadtools.Medical.Storage.DataAccessLayer;
using System.Data;
using System.Collections.ObjectModel;
using Leadtools.Medical.DataAccessLayer.Catalog;
using System.Data.SqlClient;
using Leadtools.Dicom.Common.Extensions;

namespace My.Medical.Storage.DataAccessLayer
{
   public partial class MyStorageSqlDbDataAccessAgent
   {
   
      // Returns a DataSet that reflects the existence of PatientID, StudyInstanceUID, SeriesInstanceUID, and SOPInstanceUID
      // * If the patient does not exist, returns an empty DataSet
      // * If patient exists but no study returns a DataSet where MyPatientTable has row with PatientID of DicomDataSet
      // * If patient exists, study exists but no series, returns a DataSet that has PatientID (MyPatientTable), and StudyInstanceUID (MyStudyTable)
      // * If patient, study, series exist but no Instance, returns a DataSet with PatientID, StudyInstanceUID, and SeriesInstanceUID
      // * If patinet, study series, instance exist, returns empty dataset
      private DataSet GetUpdateDataSet
           (
              DicomDataSet ds,
              bool updateExistentPatient,
              bool updateExistentStudy,
              bool updateExistentSeries,
              bool updateExistentInstances
           )
      {
         MatchingParameterCollection matchingEntitiesCollection = new MatchingParameterCollection();
         MatchingParameterList matchingEntitiesList = new MatchingParameterList();

         matchingEntitiesCollection.Add(matchingEntitiesList);

         MyInstance instance = new MyInstance();
         instance.SOPInstanceUID = ds.MyGetStringValue(DicomTag.SOPInstanceUID);

         bool instanceExists = IsCompositeInstancesExists(instance.SOPInstanceUID);

         if (instanceExists)
         {
            matchingEntitiesList.Add(instance);

            DeleteInstance(matchingEntitiesCollection);

            matchingEntitiesList.Remove(instance);

            instanceExists = false;
         }


         MyPatient patient = new MyPatient();

         patient.PatientIdentification = ds.MyGetStringValue(DicomTag.PatientID);

         if (null != patient.PatientIdentification)
         {
            matchingEntitiesList.Add(patient);
         }

         bool patientExist = IsPatientsExists(patient.PatientIdentification);

         if (updateExistentPatient && patientExist)
         {
            // case #1
            return QueryCompositeInstances(matchingEntitiesCollection);
         }
         else if (!patientExist)
         {
            // case #2
            return new MyDataSet();
         }
         else
         {
            // case #3
            // (!updateExistentPatient) && (patientExist)
            // int ? patientId = GetIntValue(patient.PatientIdentification);

            MyStudy study = new MyStudy();
            study.StudyStudyInstanceUID = ds.MyGetStringValue(DicomTag.StudyInstanceUID);

            if (null != study.StudyStudyInstanceUID)
            {
               matchingEntitiesList.Add(study);
            }

            bool studyExists = IsStudyExists(study.StudyStudyInstanceUID);

            if (updateExistentStudy && studyExists)
            {
               return QueryCompositeInstances(matchingEntitiesCollection);
            }
            else if (!studyExists)
            {
               if (matchingEntitiesList.Contains(study))
               {
                  matchingEntitiesList.Remove(study);
               }

               return QueryPatients(matchingEntitiesCollection);
            }
            else
            {
               MySeries series = new MySeries();

               series.SeriesSeriesInstanceUID = ds.MyGetStringValue(DicomTag.SeriesInstanceUID);

               if (!string.IsNullOrEmpty(series.SeriesSeriesInstanceUID))
               {
                  matchingEntitiesList.Add(series);
               }

               bool seriesExists = IsSeriesExists(series.SeriesSeriesInstanceUID);

               if (updateExistentSeries && seriesExists)
               {
                  return QueryCompositeInstances(matchingEntitiesCollection);
               }
               else if (!seriesExists)
               {
                  if (matchingEntitiesList.Contains(series))
                  {
                     matchingEntitiesList.Remove(series);
                  }

                  return QueryStudies(matchingEntitiesCollection);
               }
               else
               {
                  if (!string.IsNullOrEmpty(instance.SOPInstanceUID))
                  {
                     matchingEntitiesList.Add(instance);
                  }

                  if (updateExistentInstances && instanceExists)
                  {
                     return QueryCompositeInstances(matchingEntitiesCollection);
                  }
                  else
                  {
                     MyDataSet.MyPatientTableRow patientRow;
                     MyDataSet.MyStudyTableRow studyRow;
                     MyDataSet.MySeriesTableRow seriesRow;

                     MyDataSet myDataSet = new MyDataSet();
                     myDataSet.EnforceConstraints = false;
                     myDataSet.MyPatientTable.BeginLoadData();
                     myDataSet.MyStudyTable.BeginLoadData();
                     myDataSet.MySeriesTable.BeginLoadData();
                     myDataSet.MyInstanceTable.BeginLoadData();

                     patientRow = myDataSet.MyPatientTable.AddMyPatientTableRow(patient.PatientIdentification,
                        string.Empty,
                        DateTime.MinValue,
                        string.Empty,
                        string.Empty);
                        
                        //if (patientId != null)
                        //{
                        //   patientRow.PatientId = patientId.Value;
                        //}
                        
                        //dicomDataSet.MyPatientTable.Rows[0]["PatientId"] = patientId;

                     studyRow = myDataSet.MyStudyTable.AddMyStudyTableRow(patientRow,
                     study.StudyStudyInstanceUID,
                     DateTime.MinValue,
                     string.Empty,
                     string.Empty,
                     string.Empty,
                     string.Empty);

                     seriesRow = myDataSet.MySeriesTable.AddMySeriesTableRow(
                     studyRow,
                     series.SeriesSeriesInstanceUID,
                     string.Empty,
                     0,
                     string.Empty,
                     DateTime.MinValue,
                     string.Empty);

                     //1. if updateInstance and instance exist not valid (will be in the above IF
                     //2. if updateInstance and instance NOT exist don't fill from Db
                     //3. if NOT updateInstance and instance exist then insert SOP Instance UID
                     //4. if NOT updateInstnace and NOT instance exist then don't fill from Db

                     //case 3 above
                     if (instanceExists)
                     {
                        myDataSet.MyInstanceTable.AddMyInstanceTableRow(seriesRow,
                        instance.SOPInstanceUID,
                        0,
                        DateTime.MinValue,
                        string.Empty,
                        string.Empty,
                        0,
                        0,
                        0);
                     }

                     myDataSet.AcceptChanges();

                     myDataSet.MyPatientTable.EndLoadData();
                     myDataSet.MyStudyTable.EndLoadData();
                     myDataSet.MySeriesTable.EndLoadData();
                     myDataSet.MyInstanceTable.EndLoadData();
                     myDataSet.EnforceConstraints = true;
                     return myDataSet;
                  }
               }
            }
         }
      }

      private delegate void PrepareEntityQueryCommandDelegate(IDbCommand command, Collection<CatalogElement[]> matchingParamsCollection, ExtraQueryOptions extraQueryOptions);
      private delegate void PrepareDeleteOrphanEntityCommandDelegate(IDbCommand command);

      /// <summary>
      /// Updates the necessary table entries (MyPatient, MyStudy, MySeries, MyInstance) in the database, based on the input parameter myDataSet.
      /// </summary>
      /// <param name="myDataSet">
      /// The strongly typed DataSet that corresponds to the custom database (i.e. MyDicomDataSet)
      /// </param>
      /// <remarks>
      /// The parameter myDataSet is a DataSet that contains all the necessary additions, updates, and deletions that need to be applied.  
      /// If there is an exception during the process, all updates are backed out.
      /// </remarks>
      public virtual void UpdateCompositeInstance( MyDataSet myDataSet)
      {
         try
         {
            UpdateCompositeInstance(myDataSet, DataProvider.CreateConnection(), MyUpdateTable);
         }
         catch (Exception)
         {
            throw;
         }
      }

      /// <summary>
      /// Creates the necessary table entries (MyPatient, MyStudy, MySeries, MyInstance) for a Leadtools.Dicom.DicomDataSet
      /// </summary>
      /// <param name="ds">The Leadtools.Dicom.DicomDataSet that is being stored.</param>
      /// <param name="referencedFileName">Full path to the DICOM file</param>
      /// <param name="retrieveAe">AE Title of the client doing the retrieval</param>
      /// <param name="images">Not used</param>
      /// <param name="updateExistentPatient">If true, overwrite an existing patient data.</param>
      /// <param name="updateExistentStudy">If true, overwrite any existing study data.</param>
      /// <param name="updateExistentSeries">If true, overwrite any existing series data.</param>
      /// <param name="updateExistentInstances">If true, overwrite an existing instance data.</param>
      /// <remarks>
      /// Table rows are overwritten based on the parameters:
      /// <list>
      /// <item>updateExistentPatient</item>
      /// <item>updateExistentStudy</item>
      /// <item>updateExistentSeries</item>
      /// <item>updateExistentInstances</item>
      /// </list>
      /// </remarks>
      public override void StoreDicom( DicomDataSet ds, 
                                       string referencedFileName, 
                                       string retrieveAe, 
                                       ReferencedImages[] images, 
                                       bool updateExistentPatient, 
                                       bool updateExistentStudy, 
                                       bool updateExistentSeries, 
                                       bool updateExistentInstances
                                       )
      {
         if (ds.IsHangingProtocolDataSet())
            return;

         DataSet dataSetTemp = GetUpdateDataSet(ds,
                                             updateExistentPatient,
                                             updateExistentStudy,
                                             updateExistentSeries,
                                             updateExistentInstances);

         MyDataSet instanceDataSet = new MyDataSet();
         instanceDataSet.Merge(dataSetTemp);

         MyDicomDataSetConvertor converter = new MyDicomDataSetConvertor();

         converter.FillADONetDataSet(instanceDataSet,
                                       ds,
                                       referencedFileName,
                                       retrieveAe,
                                       updateExistentPatient,
                                       updateExistentStudy,
                                       updateExistentSeries,
                                       updateExistentInstances);


         UpdateCompositeInstance(instanceDataSet);
      } 

      // New Overload
      public override void StoreDicom(DicomDataSet dataSet,
                  string referencedFileName,
                  string token,
                  string externalStoreGuid,
                  string retrieveAe,
                  string storeAe,
                  ReferencedImages[] images,
                  bool updateExistentPatient,
                  bool updateExistentStudy,
                  bool updateExistentSeries,
                  bool updateExistentInstances)
      {
         StoreDicom(dataSet, referencedFileName, retrieveAe, images, updateExistentPatient, updateExistentStudy,
                    updateExistentSeries, updateExistentInstances);
      }

      public override bool HangingProtocolSupported
      {
         get
         {
            return false;
         }
         set
         {
            // do nothing
         }
      }



      private int MyDeleteEntity( MatchingParameterCollection matchingEntitiesCollection, PrepareEntityQueryCommandDelegate deleteHandler)
      {
         DbCommand command = DataProvider.CreateConnection().CreateCommand();
         Collection<CatalogElement[]> matchingParametersCollection = CatalogDescriptor.GetElementsCollection(matchingEntitiesCollection, StorageCatalog, true);

         deleteHandler(command, matchingParametersCollection, ExtraQueryOptions.Typical);

         command.Connection.Open();

         try
         {
            return (int)command.ExecuteNonQuery();
         }
         finally
         {
            command.Connection.Close();
         }

      }

      private int MyDeleteEntity(PrepareDeleteOrphanEntityCommandDelegate deleteHandler)
      {
         DbCommand command = DataProvider.CreateConnection().CreateCommand();

         deleteHandler(command);

         command.Connection.Open();

         try
         {
            return (int)command.ExecuteNonQuery();
         }
         finally
         {
            command.Connection.Close();
         }

      }

      /// <summary>
      /// High-level command that deletes patient rows from the 'MyPatient' database tabled based on the search criteria
      /// </summary>
      /// <param name="matchingEntitiesCollection">Contains the query parameters that are used to generate the WHERE statement</param>
      /// <returns>Number of rows deleted</returns>
      /// <remarks>
      /// Uses the PrepareDeletePatientsCommand() override.  
      /// These commands also delete the corresponding rows in the tables above it in the hierarchy
      /// </remarks>
      public override int DeletePatient(MatchingParameterCollection matchingEntitiesCollection)
      {
         return MyDeleteEntity(matchingEntitiesCollection, PrepareDeletePatientsCommand);
      }

      /// <summary>
      /// High-level command that deletes study rows from the 'MyStudy' database tabled based on the search criteria
      /// </summary>
      /// <param name="matchingEntitiesCollection">Contains the query parameters that are used to generate the WHERE statement</param>
      /// <returns>Number of rows deleted</returns>
      /// <remarks>
      /// Uses the PrepareDeleteStudiesCommand() override.  
      /// These commands also delete the corresponding rows in the tables above it in the hierarchy
      /// </remarks>
      public override int DeleteStudy(MatchingParameterCollection matchingEntitiesCollection)
      {
         int studyCount = MyDeleteEntity(matchingEntitiesCollection, PrepareDeleteStudiesCommand);

         MyDeleteEntity(PrepareDeletePatientsNoChildStudiesCommand);

         return studyCount;
      }

      /// <summary>
      /// High-level command that deletes study rows from the 'MySeries' database tabled based on the search criteria
      /// </summary>
      /// <param name="matchingEntitiesCollection">Contains the query parameters that are used to generate the WHERE statement</param>
      /// <returns>Number of rows deleted</returns>
      /// <remarks>
      /// Uses the PrepareDeleteSeriesCommand() override.  
      /// These commands also delete the corresponding rows in the tables above it in the hierarchy
      /// </remarks>
      public override int DeleteSeries(MatchingParameterCollection matchingEntitiesCollection)
      {
         int seriesCount = MyDeleteEntity(matchingEntitiesCollection, PrepareDeleteSeriesCommand);

         MyDeleteEntity(PrepareDeleteStudiesNoChildSeriesCommand);
         MyDeleteEntity(PrepareDeletePatientsNoChildStudiesCommand);

         return seriesCount;
      }

      /// <summary>
      /// High-level command that deletes study rows from the 'MyInstance' database tabled based on the search criteria
      /// </summary>
      /// <param name="matchingEntitiesCollection">Contains the query parameters that are used to generate the WHERE statement</param>
      /// <returns>Number of rows deleted</returns>
      /// <remarks>
      /// Uses the PrepareDeleteInstancesCommand() override.  
      /// These commands also delete the corresponding rows in the tables above it in the hierarchy
      /// </remarks>
      public override int DeleteInstance(MatchingParameterCollection matchingEntitiesCollection)
      {
         int instancesCount = MyDeleteEntity(matchingEntitiesCollection, PrepareDeleteInstanceCommand);

         MyDeleteEntity(PrepareDeleteSeriesNoChildInstancesCommand);
         MyDeleteEntity(PrepareDeleteStudiesNoChildSeriesCommand);
         MyDeleteEntity(PrepareDeletePatientsNoChildStudiesCommand);

         return instancesCount;
      }
      
      // Gets the 'primaryKey' value from table 'tableName', for the row where 'columnName' has the value 'uid'
      // In our database , all our primary keys are auto-generated integers
      internal static int? GetIntValue(DbConnection connection, string tableName, string primaryKey, string columnName, string columnNameValue)
      {
         int? ret = null;

         DbCommand command = connection.CreateCommand();
         command.CommandType = CommandType.Text;
         command.CommandText= string.Format("SELECT {0} FROM {1} WHERE {2}='{3}'", primaryKey, tableName, columnName, columnNameValue);

         try
         {
            object objValue;

            objValue = command.ExecuteScalar();

            if (null != objValue && DBNull.Value != objValue)
            {
               if (objValue.GetType() == typeof(int))
               {
                  ret = Convert.ToInt32(objValue);
               }
            }
         }
         finally
         {
            // command.Connection.Close();
         }
         return ret;
      }

      internal static void UpdateCompositeInstance
   (
      MyDataSet compositeInstanceDataSet,
      DbConnection connection,
      MyUpdateTableDelegate updateTable
   )
      {
         try
         {
            DbTransaction DbTransaction = null;
            
            connection.Open();

            try
            {
               try
               {
                  MyDataSet.MyPatientTableRow patientRow = compositeInstanceDataSet.Tables["MyPatientTable"].Rows[0] as MyDataSet.MyPatientTableRow;
                  MyDataSet.MyStudyTableRow studyRow = compositeInstanceDataSet.Tables["MyStudyTable"].Rows[0] as MyDataSet.MyStudyTableRow;
                  MyDataSet.MySeriesTableRow seriesRow = compositeInstanceDataSet.Tables["MySeriesTable"].Rows[0] as MyDataSet.MySeriesTableRow;
                  MyDataSet.MyInstanceTableRow dimageRow = compositeInstanceDataSet.Tables["MyInstanceTable"].Rows[0] as MyDataSet.MyInstanceTableRow;
                  
                  int ? patientId = -1;
                  int ? studyId = -1;
                  int ? seriesId = -1;

                  // *************************
                  // Patient 
                  // *************************
                  DbTransaction = connection.BeginTransaction();
                  UpdatePatientDataset(compositeInstanceDataSet,
                                         connection,
                                         DbTransaction,
                                         updateTable);
                  DbTransaction.Commit();

                  // Use the last generated PatientId -- if RowState is 'unchanged', nothing gets updated in the patientRow
                  // In this case, we need to read the patientId from the database
                  patientId = patientRow.PatientId;
                  if (patientId == -1)
                  {
                     patientId = GetIntValue(connection, "MyPatientTable", "patientId", "PatientIdentification", patientRow.PatientIdentification);
                  }

                  // *************************
                  // Study 
                  // *************************
                  DbTransaction = connection.BeginTransaction();
                  if ((studyRow.RowState != DataRowState.Unchanged &&  studyRow.StudyPatientId == -1) && (patientId != null))
                  {
                     studyRow.StudyPatientId = patientId.Value;
                  }
                  UpdateStudyDataset(compositeInstanceDataSet,
                                       connection,
                                       DbTransaction,
                                       updateTable);
                  DbTransaction.Commit();
                  
                  studyId = studyRow.StudyId;
                  if (studyId== -1)
                  {
                     studyId = GetIntValue(connection, "MyStudyTable", "studyId", "StudyStudyInstanceUID", studyRow.StudyStudyInstanceUID);
                  }

                  // *************************
                  // Series 
                  // *************************
                  // Use the last generated StudyId
                  DbTransaction = connection.BeginTransaction();
                  if ((seriesRow.RowState != DataRowState.Unchanged && seriesRow.SeriesStudyId == -1) && (studyId != null))
                  {
                     seriesRow.SeriesStudyId = studyId.Value;
                  }
                  UpdateSeriesDataset(compositeInstanceDataSet,
                                        connection,
                                        DbTransaction,
                                        updateTable);
                  DbTransaction.Commit();
                  
                  seriesId = seriesRow.SeriesId;
                  if (seriesId == -1)
                  {
                     seriesId = GetIntValue(connection, "MySeriesTable", "SeriesId", "SeriesSeriesInstanceUID",  seriesRow.SeriesSeriesInstanceUID);
                  }

                  // *************************
                  // Instance 
                  // *************************
                  // Use the last generated SeriesId
                  DbTransaction = connection.BeginTransaction();
                  if ((dimageRow.RowState != DataRowState.Unchanged && dimageRow.ImageSeriesId == -1) && (seriesId != null))
                  {
                     dimageRow.ImageSeriesId = seriesId.Value;
                  }
                  UpdateInstanceDataset(compositeInstanceDataSet,
                                          connection,
                                          DbTransaction,
                                          updateTable);

                  DbTransaction.Commit();
               }
               catch (Exception exception)
               {
                  System.Diagnostics.Debug.Assert(false, exception.ToString());

                  DbTransaction.Rollback();

                  throw;
               }
            }
            finally
            {
               connection.Close();
            }

            compositeInstanceDataSet.AcceptChanges();
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.WriteLine(exception.Message);
            System.Diagnostics.Debug.Assert(false);

            throw;
         }
      }

      private static void UpdatePatientDataset(
                                                MyDataSet updatingDataset,
                                                DbConnection updatingDbConnection,
                                                DbTransaction updatingTransaction,
                                                MyUpdateTableDelegate updateTable
                                              )
      {
         try
         {
            updateTable(updatingDataset,
                          updatingDbConnection,
                          updatingTransaction,
                          updatingDataset.MyPatientTable.TableName);
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.WriteLine(exception.Message);
            System.Diagnostics.Debug.Assert(false);

            throw;
         }
      }

      private static void UpdateStudyDataset
      (
         MyDataSet updatingDataset,
         DbConnection updatingDbConnection,
         DbTransaction updatingTransaction,
         MyUpdateTableDelegate updateTable
      )
      {
         try
         {
            updateTable(updatingDataset,
                          updatingDbConnection,
                          updatingTransaction,
                          updatingDataset.MyStudyTable.TableName);

         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.WriteLine(exception.Message);
            System.Diagnostics.Debug.Assert(false);

            throw;
         }
      }


      private static void UpdateSeriesDataset
      (
         MyDataSet updatingDataset,
         DbConnection updatingDbConnection,
         DbTransaction updatingTransaction,
         MyUpdateTableDelegate updateTable
      )
      {
         try
         {
            updateTable(updatingDataset,
                          updatingDbConnection,
                          updatingTransaction,
                          updatingDataset.MySeriesTable.TableName);

         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.WriteLine(exception.Message);
            System.Diagnostics.Debug.Assert(false);

            throw;
         }
      }

      private static void UpdateInstanceDataset
      (
         MyDataSet updatingDataset,
         DbConnection updatingDbConnection,
         DbTransaction updatingTransaction,
         MyUpdateTableDelegate updateTable
      )
      {
         try
         {
            updateTable(updatingDataset,
                          updatingDbConnection,
                          updatingTransaction,
                          updatingDataset.MyInstanceTable.TableName);
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.WriteLine(exception.Message);
            System.Diagnostics.Debug.Assert(false);

            throw;
         }
      }


      internal static MyDataSet _myStructureDataSet = new MyDataSet();

      internal delegate void MyUpdateTableDelegate(MyDataSet updatingDataset,
                                             DbConnection updatingDbConnection,
                                             DbTransaction updatingTransaction,
                                             string tableName);

/// <summary>
/// Returns a strongly typed DataSet representing the tables of the database
/// </summary>
/// <returns>
/// a strongly typed DataSet representing the tables of the database
/// </returns>
/// <remarks>
/// For the MyDicomDb database, these tables are:
/// <list>
/// <item>MyPatient</item>
/// <item>MyStudy</item>
/// <item>MySeries</item>
/// <item>MyInstance</item>
/// </list>
/// </remarks>
      protected override DataSet CreateCompositeInstanceDataSet()
      {
         return new MyDataSet();
      }
   }
}
