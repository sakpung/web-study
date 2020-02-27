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
using My.Medical.Storage.DataAccessLayer.DataAccessLogic.DataAccessAgent.Database.SqlServer;

namespace My.Medical.Storage.DataAccessLayer
{
   /// <summary>
   /// Provides methods to create SQL queries to access (insert, update, delete) the table entries in the database.  
   /// The methods override the default behavior of the StorageSqlDbDataAccessAgent.
   /// </summary>
   public partial class MyStorageSqlDbDataAccessAgent
   {
      private string MyGetPatientCommandText(Collection<CatalogElement[]> matchingParamsCollection)
      {
         try
         {
            StringBuilder sb = new StringBuilder(500);
            
            string s = MyConstants.SelectCommandText.FirstPart;
            sb.Append(s);

            s = (MyConstants.SelectCommandText.FromClause.Patient);
            sb.Append(s);

            s = InjectJoinForPatientQuery();
            sb.Append(s);
            
            s = SqlProviderUtilities.GenerateWhereStatement(matchingParamsCollection);
            sb.Append(s);
            
            s = MyConstants.SelectCommandText.MIDDLE_PART;
            sb.Append(s);

            s = MyConstants.SelectCommandText.SelectStatements.PatientEntity;
            sb.Append(s);

            s = MyConstants.SelectCommandText.LAST_PART;
            sb.Append(s);

            return sb.ToString();
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.WriteLine(exception.Message);
            System.Diagnostics.Debug.Assert(false);

            throw;
         }
      }
            
      private string MyGetStudiesCommandText(Collection<CatalogElement[]> matchingParamsCollection)
      {
         try
         {
            StringBuilder sb = new StringBuilder(500);

            string s = MyConstants.SelectCommandText.FirstPart;
            sb.Append(s);

            s = MyConstants.SelectCommandText.FromClause.Study;
            sb.Append(s);

            s = InjectJoinForStudyQuery();
            sb.Append(s);

            s = SqlProviderUtilities.GenerateWhereStatement(matchingParamsCollection);
            sb.Append(s);

            s = MyConstants.SelectCommandText.MIDDLE_PART;
            sb.Append(s);

            s = MyConstants.SelectCommandText.SelectStatements.PatientEntity;
            sb.Append(s);

            s = MyConstants.SelectCommandText.SelectStatements.StudyEntity;
            sb.Append(s);

            s = MyConstants.SelectCommandText.LAST_PART;
            sb.Append(s);

            return sb.ToString();
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.WriteLine(exception.Message);
            System.Diagnostics.Debug.Assert(false);

            throw;
         }
      }

      private string MyGetSeriesCommandText(Collection<CatalogElement[]> matchingParamsCollection)
      {
         try
         {
            StringBuilder sb = new StringBuilder(500);


            sb.Append(MyConstants.SelectCommandText.FirstPart);
            sb.Append(MyConstants.SelectCommandText.FromClause.Series);
            sb.Append(InjectJoinForSeriesQuery());
            sb.Append(SqlProviderUtilities.GenerateWhereStatement(matchingParamsCollection));
            sb.Append(MyConstants.SelectCommandText.MIDDLE_PART);
            sb.Append(MyConstants.SelectCommandText.SelectStatements.PatientEntity);
            sb.Append(MyConstants.SelectCommandText.SelectStatements.StudyEntity);
            sb.Append(MyConstants.SelectCommandText.SelectStatements.SeriesEntity);
            sb.Append(MyConstants.SelectCommandText.LAST_PART);

            return sb.ToString();
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.WriteLine(exception.Message);
            System.Diagnostics.Debug.Assert(false);

            throw;
         }
      }

      private string GetInstanceCommandText(Collection<CatalogElement[]> matchingParamsCollection, QueryPageInfo queryPageInfo)
      {
         try
         {
            string sOrderByField = "SOPInstanceUID";
            StringBuilder sb = new StringBuilder(500);
            string s;

            // Skip the pagination for now!
            queryPageInfo = null;

            if (queryPageInfo != null)
            {
               string sTemp = MyConstants.SelectCommandText.GetFirstPartPagination(queryPageInfo);
               sb.Append(sTemp);

               string originalTableQuery = MyConstants.SelectCommandText.FromClause.Image;
               originalTableQuery += InjectJoinForInstanceQuery();
               sb.Append(originalTableQuery);

               string sWhere = SqlProviderUtilities.GenerateWherePaginationStatement(matchingParamsCollection, "Instance", "SOPInstanceUID", sOrderByField, queryPageInfo, originalTableQuery);
               sb.Append(sWhere);
            }
            else
            {
               s = MyConstants.SelectCommandText.FirstPart;
               sb.Append(s);

               s = MyConstants.SelectCommandText.FromClause.Image;
               sb.Append(s);

               s = SqlProviderUtilities.GenerateWhereStatement(matchingParamsCollection);
               sb.Append(s);
            }

            s = MyConstants.SelectCommandText.MIDDLE_PART;
            sb.Append(s);

            s = MyConstants.SelectCommandText.SelectStatements.PatientEntity;
            sb.Append(s);

            s = MyConstants.SelectCommandText.SelectStatements.StudyEntity;
            sb.Append(s);

            s = MyConstants.SelectCommandText.SelectStatements.SeriesEntity;
            sb.Append(s);

            s = MyConstants.SelectCommandText.SelectStatements.InstanceEntity;
            sb.Append(s);

            s = MyConstants.SelectCommandText.LAST_PART;
            sb.Append(s);

            return sb.ToString();
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
