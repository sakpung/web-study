// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using Leadtools.Dicom.Scp.Command;
using System.Xml.Schema;


/*
 modalityWorklist IOD Description
 * All elements of the Modality Work-list IOD are listed in the document.
 * Elements should be sorted according to the DICOM specs based on the Tag Number.
 * The Worklist command will validate the dataset request against the IOD, so if sorting is not right a validation error will occur at runtime.
 * Extra DICOM element or Private elements might be added, but the new items should be placed in the right order.
 * Simple DICOM Elements are added to the document with the XML tag <element>
 * Sequence DICOM Elements are added to the document with the XML tag <sequence>
 * Sequence Item DICOM Element are added to the document witht the XML tag <item> and they must appear only after a <sequence> tag.
 * The IOD is defined by a schema, you updating an IOD you should make sure that it is valid according to the defined schema.
 * The following is an explanation of each xml tag <element> and <sequence>
<element  tag="" tagName="" vr="" minVM="" maxVM="" vmDivider="" returnType="" matchingType="" returning="" tableName="" matchingEntity="" columnsName="" />
<sequence tag="" tagName="" vr="SQ" minVM="" maxVM="" vmDivider="" returnType="" returning="" tableName="">
 * tag: The DICOM tag for the element: This is the most important tag which define which DICOM element this tag correspnds to.
 * tagName: this can be ANY human readable name
 * vr: The DICOM Value Representation which will be used to validate the request value.
 * MinVM: The minimum value multiplicity which is used for validation
 * MaxVM: The maximum value multiplicity which is used for validation
 * vmDivider: The step size of the value multiplicity
 * returnType: The DICOM return type (check the schema for allowed values), used to validate that elements of type1 has value on returning and remove type3 elements with no value from response
 * matchingType: The DICOM matching type (check the schema for allowed values), used to tell the MWL Command how to perform matching on each element.
 * returning: tell the MWL Command whether the element should be returned in the response.
 * tableName: tell the MWL Command the ADO.NET table where this element exists
 * ColumnsName: tell the MWL Command the ADO.NET DataColumn(s) where it should get the value for this DICOM element.
 * matchingEntity: If the value of matchingType is anything other than "NotApplicable", this value should be filled with the object used as matching parameters when communication with the MWL Data Access Layer
*/
namespace CSCustomizingWorklistDAL.DataTypes
{
   class WorklistIODUpdater
   {
      public static void UpdateIOD ( List<DatabaseDicomTags> iodTags, string iodPath ) 
      {
         XmlDocument document = new XmlDocument ( ) ;
         
         document.Load ( iodPath ) ;
         
         
         foreach ( DatabaseDicomTags dbIODTag in iodTags )
         {
            string tagName ;
            
            
            tagName = GetFormattedDICOMTag ( dbIODTag.DicomTag ) ;
            
            
            XmlNode iodElement = document.DocumentElement ;
            
            iodElement = FindFirstElement ( iodElement, tagName ) ;
            
            if ( null != iodElement ) 
            {
               iodElement.Attributes [ "returning" ].Value = "true" ;
               iodElement.Attributes [ "tableName" ].Value = dbIODTag.TableName ;
               iodElement.Attributes [ "columnsName" ].Value = dbIODTag.ColumnName ;
            }
         }
         
         document.Save ( iodPath ) ;
         
         ValidateDocument ( iodPath ) ;
      }

      private static XmlNode FindFirstElement ( XmlNode iodElement, string tagName )
      {
         if ( iodElement.Attributes != null &&
              iodElement.Attributes[ "tag" ] != null &&
              !string.IsNullOrEmpty ( iodElement.Attributes[ "tag" ].Value ) &&
               iodElement.Attributes [ "tag" ].Value == tagName )
         {
            return iodElement ;
         }
         else if ( iodElement.HasChildNodes )
         {
            foreach ( XmlNode childNode in iodElement.ChildNodes )
            {
               XmlNode element ;
               
               
               element = FindFirstElement ( childNode, tagName ) ;
               
               if ( null != element ) 
               {
                  return element ;
               }
            }
         }
         
         return null ;
      }
      
      private static string GetFormattedDICOMTag
      ( 
         long tag 
      )
      {
         try
         {
            string dicomTag ;

            dicomTag = String.Format ( "({0:x4},{1:x4})", 
                                          GetGroup(tag),
                                          GetElement( tag) ) ;
            
            return dicomTag ;
         }
         catch ( System.Exception exception )
         {
            System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
             
            throw exception ;
         }
      }
      
      private static void ValidateDocument ( string xmlDoc )
      {
         XmlSchema         mwlSchema ;
         XmlReaderSettings settings ;
         
         mwlSchema = MWLCFindCommand.IODSchema ;
         
         settings = new XmlReaderSettings ( ) ;
         
         settings.Schemas.Add ( mwlSchema ) ;
         settings.ValidationType = ValidationType.Schema ;
         
         settings.ValidationEventHandler += new ValidationEventHandler ( schemaValidationHandler ) ;
         
         using ( XmlReader reader = XmlTextReader.Create ( xmlDoc, settings ) )
         {
            while ( reader.Read ( ) ) ;
         }
      }

      private static void schemaValidationHandler
      ( 
         object sender, 
         ValidationEventArgs args 
      ) 
      {
         throw args.Exception ;
      }
      
      private static UInt16 GetGroup ( long tag )
      {
         return ((UInt16)(tag >> 16));
      }

      private static int GetElement ( long tag )
      {
         return ((UInt16)(tag & 0xFFFF));
      }
   }
}
