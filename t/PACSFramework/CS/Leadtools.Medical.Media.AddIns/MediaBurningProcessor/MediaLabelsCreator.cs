// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.Common.DataTypes.MediaCreation;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Dicom;
using Leadtools.Medical.Storage.DataAccessLayer.MatchingParameters;
using Leadtools.Medical.Storage.DataAccessLayer.Configuration;
using Leadtools.Medical.DataAccessLayer.Catalog;

namespace Leadtools.Medical.Media.AddIns.MediaBurningProcessor
{
   public interface IMediaLabelsCreator
   {
      List<string> GetLabels ( List<LabelPrinting> labels, MediaCreationManagement mediaObject ) ;
   }
   
   public class MediaLabelsCreator : IMediaLabelsCreator
   {
      public List<string> GetLabels ( List<LabelPrinting> labels, MediaCreationManagement mediaObject ) 
      {
         List <string> extractedLabels ;
         
         
         extractedLabels = new List<string> ( ) ;
         
         foreach ( LabelPrinting label in labels ) 
         {
            switch ( label.PrintLabelType )
            {
               case LabelType.ClientText:
               {
                  if ( !string.IsNullOrEmpty ( mediaObject.LabelText ) )
                  {
                     extractedLabels.Add ( mediaObject.LabelText ) ;
                  }
                  else
                  {
                     extractedLabels.Add ( string.Empty ) ;
                  }
               }
               break ;
               
               case LabelType.Image:
               {
                  if ( !string.IsNullOrEmpty ( label.PrintLabelData ) )
                  {
                     extractedLabels.Add ( label.PrintLabelData ) ;
                  }
                  else
                  {
                     extractedLabels.Add ( string.Empty ) ;
                  }
               }
               break ;
               
               case LabelType.CustomData:
               {
                  if ( !string.IsNullOrEmpty ( label.PrintLabelData ) )
                  {
                     extractedLabels.Add ( ExtractCustomData ( label.PrintLabelData, mediaObject ) ) ;
                  }
                  else
                  {
                     extractedLabels.Add ( string.Empty ) ;
                  }
               }
               break ;
            }
         }
         
         return extractedLabels ;
      }

      private string ExtractCustomData 
      ( 
         string lableData, 
         MediaCreationManagement mediaObject 
      )
      {
         if ( lableData.IndexOf ( _dicomLableChar ) != -1 )
         {
            return ProcessLabelDicomValues ( lableData, mediaObject ) ;
            
         }
         else
         {
            return lableData ;
         }
      }

      private static string ProcessLabelDicomValues
      (
         string lableData, 
         MediaCreationManagement mediaObject 
      )
      {
         IStorageDataAccessAgent  dataAccess;
         DicomDataSet             instanceDataSet ;


         dataAccess = DataAccessServices.GetDataAccessService<IStorageDataAccessAgent>();

         if ( null == dataAccess ) 
         {
            dataAccess = DataAccessFactory.GetInstance ( new StorageDataAccessConfigurationView ( ) ).CreateDataAccessAgent <IStorageDataAccessAgent> ( ) ;
         }
         
         if ( null != dataAccess )
         {
            int currentIndex ;
            
            
            instanceDataSet = GetFirstReferencedInstanceDataSet ( dataAccess, mediaObject ) ;
            
            if ( null == instanceDataSet ) 
            {
               return lableData ;
            }
            
            currentIndex = 0 ;
            
            while ( ( currentIndex = lableData.IndexOf ( _dicomLableChar, currentIndex ) ) != -1 )
            {
               int    lastTagIndex ;
               string dicomLabelTag ;
               string dicomLabelValue ;
               long   dicomTag ;
               
               
               if ( currentIndex == lableData.Length -1 )
               {
                  break ;
               }
               
               lastTagIndex = lableData.IndexOf ( _dicomLableChar, currentIndex + 1 ) ;
               
               if ( lastTagIndex == -1 ) 
               {
                  break ;
               }
               
               dicomLabelTag = lableData.Substring ( currentIndex, ( lastTagIndex - currentIndex + 1 ) ) ;
               
               dicomTag = GetDicomTag ( dicomLabelTag ) ;
               
               dicomLabelValue = instanceDataSet.GetValue <string> ( dicomTag, string.Empty ) ;
               
               dicomLabelValue = FormatPNValue ( dicomLabelValue, dicomTag ) ;
               
               lableData = lableData.Replace ( dicomLabelTag, dicomLabelValue ) ;
            }
         }
         else
         {
            throw new InvalidOperationException("IStorageDataAccessAgent is not registered.");
         }
         
         return lableData ;
      }

      private static string FormatPNValue ( string dicomLabelValue, long dicomTag )
      {
         DicomTag tag ;
         
         
         tag = DicomTagTable.Instance.Find ( dicomTag ) ;
         
         if ( null != tag ) 
         {
            if ( tag.VR == DicomVRType.PN )
            {
               string[] personNameFields ;
               string   formattedName ;
               
               
               personNameFields = dicomLabelValue.Split ( '^' ) ;
               formattedName    = string.Empty ;
               
               if ( personNameFields.Length == 0 )
               {
                  return dicomLabelValue ;
               }
               
               for ( int partsIndex = 0; partsIndex < personNameFields.Length; partsIndex++ )
               {
                  if ( ( partsIndex == 1 || partsIndex == 2 ) && 
                       ( !string.IsNullOrEmpty ( formattedName ) && !string.IsNullOrEmpty ( personNameFields [ partsIndex ] ) ) )
                  {
                     formattedName += "," ;
                  }
                  else if ( ( partsIndex == 3 || partsIndex == 4 ) && 
                            ( !string.IsNullOrEmpty ( formattedName ) && !string.IsNullOrEmpty ( personNameFields [ partsIndex ] ) ))
                  {
                     formattedName += " " ;
                  }
                  
                  formattedName += personNameFields [ partsIndex ] ;
               }
               
               return formattedName ;
            }
         }
         
         return dicomLabelValue ;
      }

      private static DicomDataSet GetFirstReferencedInstanceDataSet
      (
         IStorageDataAccessAgent dataAccess, 
         MediaCreationManagement mediaObject)
      {
         MatchingParameterCollection matchingCollection ;
         MatchingParameterList       matchingList ;
         CompositeInstanceDataSet    compositeInstance ;
         
         
         matchingCollection = new MatchingParameterCollection ( ) ;
         matchingList       = new MatchingParameterList ( ) ;
         // Instance instance           = new Instance ( mediaObject.ReferencedSopSequence [ 0 ].SopInstance.ReferencedSopInstanceUid ) ;
         ICatalogEntity instance = RegisteredEntities.GetInstanceEntity(mediaObject.ReferencedSopSequence [ 0 ].SopInstance.ReferencedSopInstanceUid);

         
         matchingCollection.Add ( matchingList ) ;
         matchingList.Add ( instance ) ;
         
         compositeInstance = dataAccess.QueryCompositeInstances ( matchingCollection ).ToCompositeInstanceDataSet() ;
         
         if ( compositeInstance.Instance.Count > 0 ) 
         {
            DicomDataSet ds ;
            
            
            ds = new DicomDataSet ( ) ;
            
            ds.Load ( compositeInstance.Instance [ 0 ].ReferencedFile, DicomDataSetLoadFlags.None ) ;
            
            return ds ;
         }
         else
         {
            return null ;
         }
      }

      private static long GetDicomTag ( string dicomLabelTag )
      {
         string [] labelParts ;
         string    hexTag ;
         
         labelParts = dicomLabelTag.Split ( ';' ) ;
         
         if ( labelParts.Length != 2 )
         {
            return -1 ;
         }
         
         hexTag = labelParts [ 1 ].TrimEnd ( _dicomLableChar ) ;
         
         return ConvertFromFormattedDICOMTag ( hexTag ) ;
      }
      
      private static long ConvertFromFormattedDICOMTag 
      ( 
         string strDICOMTag 
      )
      {
         try
         {
            string [ ] newValues ;
            long   tag ;
            ushort group;
            int    element ;
            
            
            newValues = strDICOMTag.TrimStart ( '(' ).TrimEnd ( ')' ).Split ( ':' ) ;
            
            if ( newValues.Length != 2 ) 
            {
               throw new InvalidOperationException ( "Invalid dicom Tag format value." ) ;
            }
            
            group   = ushort.Parse ( newValues [ 0 ], System.Globalization.NumberStyles.HexNumber ) ;
            element = int.Parse    ( newValues [ 1 ], System.Globalization.NumberStyles.HexNumber ) ;
            
            tag = GetTagValue ( group, element ) ;
            
            return tag ;
         }
         catch ( System.Exception exception )
         {
            System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
             
            throw ;
         }
      }
      
      private static long GetTagValue ( ushort group, int element ) 
      {
         long value ;
         
         
         value = group << 16 ;
         
         value = (long ) ( (ulong) value ) | ( (ushort) element ) ;
         
         return value ;
      }
      
      private const char _dicomLableChar = '$' ;
   }
}
