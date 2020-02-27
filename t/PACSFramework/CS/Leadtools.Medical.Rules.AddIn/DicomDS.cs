// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Leadtools.Dicom;
using Leadtools.Dicom.Common.DataTypes;
using Leadtools.Dicom.AddIn;
using Leadtools.Dicom.Common.Extensions;
using Leadtools.Medical.Rules.AddIn.Common;
using Leadtools.Logging;

namespace Leadtools.Medical.Rules.AddIn
{
   /// <summary>
   /// This is a wrapper class around the DicomDataSet.  The wrapper allows for easier getting and setting of
   /// dataset values.  For instance you can set patient id from script like this: request(DicomTag.PatientID) = "LAST^FIRST".
   /// </summary>
   public class DicomDS
   {      
      private DicomDataSet _Dataset;

      public DicomDataSet Dataset
      {
         get { return _Dataset; }
         set { _Dataset = value; }
      }           

      public object this[long tag]
      {
         get
         {
            if (_Dataset != null)
            {
               if (Utils.IsSequence(tag))
                  return new Sequence(tag, this);

               return _Dataset.GetElementValue(tag, false);
            }
            return null;
         }
         set
         {
            if (_Dataset != null)
            {
               _Dataset.InsertElementAndSetValue(tag, value);
            }
         }
      }                 

      public DicomDS(DicomDataSet ds)
      {         
         _Dataset = ds;
      }      

      public static DicomDS Load(string file)
      {
         DicomServer server = ServiceLocator.Retrieve<DicomServer>();
         DicomDS ds = new DicomDS(null);
         
         ds.Dataset = new DicomDataSet(server.TemporaryDirectory);
         ds.Dataset.Load(file, DicomDataSetLoadFlags.None);         
         return new DicomDS(ds);
      }

      public void Save(string filename)
      {
         try
         {            
            if (_Dataset != null)
            {
               _Dataset.Save(filename, DicomDataSetSaveFlags.None);
            }
         }
         catch (Exception e)
         {
            Logger.Global.SystemException(string.Empty, e);
         }
      }

      public DicomDS Copy()
      {
         return new DicomDS(_Dataset.Copy());
      }
       
       public void Delete(long tag)
       {
           DicomElement element = _Dataset.FindFirstElement(null, tag, false);
           
           if(element!=null)
           {
               _Dataset.DeleteElement(element);
           }
       }

       /// <summary>
      /// Performs an implicit conversion from <see cref="Leadtools.Medical.Rules.AddIn.DicomDS"/> to <see cref="Leadtools.Dicom.DicomDataSet"/>.
      /// </summary>
      /// <param name="wrapper">The wrapper.</param>
      /// <returns>
      /// The result of the conversion.
      /// </returns>
      public static implicit operator DicomDataSet(DicomDS wrapper)
      {
         return wrapper.Dataset;
      }

      /// <summary>
      /// Performs an implicit conversion from <see cref="Leadtools.Dicom.DicomDataSet"/> to <see cref="Leadtools.Medical.Rules.AddIn.DicomDS"/>.
      /// </summary>
      /// <param name="dataset">The dataset.</param>
      /// <returns>
      /// The result of the conversion.
      /// </returns>
      public static implicit operator DicomDS(DicomDataSet dataset)
      {
         return new DicomDS(dataset);
      }
   }
}
