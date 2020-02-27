// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using Leadtools.Dicom.AddIn;
using Leadtools.Dicom;
using Leadtools.Dicom.Common.Extensions;
using Leadtools.Logging;
using System.Collections.ObjectModel;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.DataAccessLayer.Catalog;
using Leadtools.Medical.Storage.DataAccessLayer.MatchingParameters;

namespace Leadtools.Medical.SearchOtherPatientId.Addin.Common
{
   public class NotifyReceiveMessage : NotifyReceiveMessageBase
   {

      private readonly Func<Collection<CatalogElement[]>, string> _oldWhereStatement;

      public NotifyReceiveMessage()
      {
         _oldWhereStatement = SqlProviderUtilities.WhereStatementGenerator;
         SqlProviderUtilities.WhereStatementGenerator = GenerateNewWhereStatement;
      }

      public void AddElements(List<CatalogElement[]> masterList, List<CatalogElement> queryElementsToAdd)
      {
         List<CatalogElement[]> tempElements = new List<CatalogElement[]>();
         tempElements.Insert(0, new CatalogElement[queryElementsToAdd.Count]);
         for (int j = 0; j < queryElementsToAdd.Count; j++)
         {
            tempElements[0][j] = queryElementsToAdd[j];
         }
         masterList.Add(tempElements[0]);
      }

      public string GenerateNewWhereStatement(Collection<CatalogElement[]> matchingParams)
      {
         List<CatalogElement[]> list = new List<CatalogElement[]>();

         if (null != matchingParams  && Module.Options.SearchOtherPatientId) 
         {
            for (int i = 0; i < matchingParams.Count; i++)
            {
               // CatalogElement found = null;
               List<CatalogElement[]> elements = new List<CatalogElement[]>();
               List<CatalogElement> normalQueryElements = new List<CatalogElement>();
               List<CatalogElement> modifiedQueryElements = new List<CatalogElement>();
               bool otherPatientIdFound = false;

               foreach (CatalogElement element in matchingParams[i])
               {
                  if (element.Entity is OtherPatientIds)
                  {
                     otherPatientIdFound = true;
                  }
                  else
                  {
                     normalQueryElements.Add(element);
                  }

                  if (element.ElementName != "PatientID")
                  {
                     modifiedQueryElements.Add(element);
                  }
               }

               if (otherPatientIdFound)
               {
                  AddElements(list, modifiedQueryElements);
               }

               AddElements(list, normalQueryElements);
            }
            return _oldWhereStatement(new Collection<CatalogElement[]>(list.ToArray()));
         }
         return _oldWhereStatement(matchingParams);
      }



      public override void OnReceiveCFindRequest(DicomClient Client, byte presentationID, int messageID, string affectedClass, DicomCommandPriorityType priority, DicomDataSet ds)
      {
         string patientId = ds.GetValue<string>(DicomTag.PatientID, string.Empty);
         if (Module.Options.SearchOtherPatientId && !patientId.IsNullOrEmpty())
         {
            MyOtherPatientIds opid = new MyOtherPatientIds();
            ds.Get(opid);

            if (opid.OtherPatientIds == null)
            {
               opid.OtherPatientIds = new List<string>();
            }

            if (!opid.OtherPatientIds.Contains(patientId))
            {
               opid.OtherPatientIds.Add(patientId);
               ds.Set(opid);

               Logger.Global.SystemMessage(LogType.Information, "CFind request dataset modified: PatientID added to OtherPatientIds", Client.AETitle, ds, null);
            }
         }
         base.OnReceiveCFindRequest(Client, presentationID, messageID, affectedClass, priority, ds);
      }
   }
}
