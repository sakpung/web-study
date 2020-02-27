// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.Workstation.Commands;
using Leadtools.Medical.Workstation;
using Leadtools.Medical.Workstation.Client.Local;
using Leadtools.Dicom;
using Leadtools.Dicom.Scu.Common;
using System.Windows.Forms;

namespace Leadtools.Demos.Workstation.Customized
{
   class LoadSeriesFromDicomDirCommand : WorkstationCommand
   {
      public LoadSeriesFromDicomDirCommand ( string featureId, WorkstationContainer container ) 
      : base ( featureId, container ) 
      {
         
      }

      protected override void DoExecute ( )
      {
         string dicomDirFile ;
         
         
         dicomDirFile = GetDicomDir ( ) ;
         
         if ( !string.IsNullOrEmpty ( dicomDirFile ) )
         {
            List <SeriesInformation> serieses ;
            LoadSeriesFromDicomDirCommandArgument argument ;
            
            serieses = GetSeriesForLoading ( dicomDirFile ) ;
            
            
            foreach ( SeriesInformation series in serieses ) 
            {
               if ( Container.ArgumentsService.Exists <LoadSeriesFromDicomDirCommandArgument> ( ) )
               {
                  argument = Container.ArgumentsService.PopArgument <LoadSeriesFromDicomDirCommandArgument> ( ) ;
               
                  argument.DicomDirFile = dicomDirFile ;
               }
               else
               {
                  argument = new LoadSeriesFromDicomDirCommandArgument ( dicomDirFile ) ;
               }
               
               Container.ArgumentsService.PushArgument <LoadSeriesFromDicomDirCommandArgument> ( argument ) ;

               Container.State.ActiveWorkstation.LoadSeries ( series ) ;
            }
         }
      }

      protected override bool DoCanExecute()
      {
         return true ;
      }

      private List<SeriesInformation> GetSeriesForLoading ( string dicomDirFile )
      {
         List<SeriesInformation> seriesInfo ;
         DicomDirQueryClient     client ;
         DicomDataSet[]          seriesDataSets ;
         
         
         seriesInfo     = new List<SeriesInformation> ( ) ;
         client         = new DicomDirQueryClient ( dicomDirFile ) ;
         seriesDataSets = client.FindSeries ( new FindQuery ( ) ) ;
         
         
         foreach ( DicomDataSet sereisDs in seriesDataSets ) 
         {
            SeriesInformation series ;
            
            
            series = new SeriesInformation ( sereisDs.GetValue <string> ( DicomTag.PatientID, string.Empty ),
                                             sereisDs.GetValue <string> ( DicomTag.StudyInstanceUID, string.Empty ),
                                             sereisDs.GetValue <string> ( DicomTag.SeriesInstanceUID, string.Empty ),
                                             sereisDs.GetValue <string> ( DicomTag.SeriesDescription, string.Empty ) ) ;
                                             
            seriesInfo.Add ( series ) ;
            
            sereisDs.Dispose ( ) ;
         }
         
         return seriesInfo ; 
      }
      
      private string GetDicomDir ( ) 
      {
         OpenFileDialog openFileDialog = new OpenFileDialog ( ) ;
         
         openFileDialog.FileName = "DICOMDIR" ;
         
         if ( openFileDialog.ShowDialog ( ) == DialogResult.OK ) 
         {
            if ( openFileDialog.SafeFileName != "DICOMDIR" ) 
            {
               MessageBox.Show ( "Invalid DICOMDIR file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error ) ;
               
               return null ;
            }
            else
            {
               return openFileDialog.FileName ;
            }
         }
         
         return null ;
      }
   }
   
   public class LoadSeriesFromDicomDirCommandArgument
   {
      public LoadSeriesFromDicomDirCommandArgument ( string dicomDirFile )
      {
         DicomDirFile = dicomDirFile ;
      }
      
      public string DicomDirFile
      {
         get ;
         set ;
      }
   }
}
