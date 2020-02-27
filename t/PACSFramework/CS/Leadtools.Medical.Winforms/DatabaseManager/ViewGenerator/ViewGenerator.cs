// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System ;
using System.Data ;
using System.Collections.Generic ;
using System.Text ;
using Leadtools.Medical.Storage.DataAccessLayer ;

namespace Leadtools.Medical.Winforms
{
   public class ViewGenerator
   {
      public static ViewDataTable GenerateView 
      ( 
         DicomInformationView viewType, 
         DataSet source 
      )
      {
         switch ( viewType )
         {
            case DicomInformationView.PatientLevel:
            {
               return GenerateView ( viewType, source, GetPatientLevelColumns ( ) ) ;
            }
            
            case DicomInformationView.StudiesLevel:
            {
               return GenerateView ( viewType, source, GetStudyLevelColumns ( ) ) ;
            }
            
            case DicomInformationView.SeriesLevel:
            {
               return GenerateView ( viewType, source, GetSeriesLevelColumns ( ) ) ;
            }
            
            case DicomInformationView.ImagesLevel:
            {
               return GenerateView ( viewType, source, GetImageLevelColumns ( ) ) ;
            }

#if (LEADTOOLS_V19_OR_LATER)
            case DicomInformationView.HangingProtocol:
            {
               return GenerateView ( viewType, source, GetHangingProtocolColumns ( ) ) ;
            }

            case DicomInformationView.HangingProtocolDefinition:
            {
               return GenerateView ( viewType, source, GetHangingProtocolDefinitionColumns ( ) ) ;
            }
#endif // #if (LEADTOOLS_V19_OR_LATER)
            
            default:
            {
               throw new InvalidOperationException ( "Requested view not supported." ) ;
            }
         }
      }
      
      public static ViewDataTable GenerateView 
      ( 
         DicomInformationView viewType, 
         DataSet source,
         List <string> viewColumns 
      )
      {
         switch ( viewType )
         {
            case DicomInformationView.PatientLevel:
            {
               return GeneratePatientView ( source, GetPatientLevelColumns ( ) ) ;
            }
            
            case DicomInformationView.StudiesLevel:
            {
               return GenerateStudyView ( source, GetStudyLevelColumns ( ) ) ;
            }
            
            case DicomInformationView.SeriesLevel:
            {
               return GenerateSeriesView ( source, GetSeriesLevelColumns ( ) ) ;
            }
            
            case DicomInformationView.ImagesLevel:
            {
               return GenerateImageView ( source, GetImageLevelColumns ( ) ) ;
            }
#if (LEADTOOLS_V19_OR_LATER)
            case DicomInformationView.HangingProtocol:
            {
               return GenerateHangingProtocolView ( source, GetHangingProtocolColumns ( ) ) ;
            }

           case DicomInformationView.HangingProtocolDefinition:
            {
               return GenerateHangingProtocolDefinitionView ( source, GetHangingProtocolDefinitionColumns ( ) ) ;
            }
#endif // #if (LEADTOOLS_V19_OR_LATER)
            
            default:
            {
               throw new InvalidOperationException ( "Requested view not supported." ) ;
            }
         }
      }
      
      private static ViewDataTable GeneratePatientView 
      ( 
         DataSet source, 
         List <string> columns 
      ) 
      {
         return GenerateView ( "PatientView",
                               source, 
                               source.Tables[DataTableHelper.PatientTableName], 
                               columns, 
                               PatientLevelColumns ) ;      
      }
      
      private static ViewDataTable GenerateStudyView 
      ( 
         DataSet source, 
         List <string> columns 
      ) 
      {
         return GenerateView ( "StudyView",
                               source, 
                               source.Tables[DataTableHelper.StudyTableName], 
                               columns, 
                               StudyLevelColumns ) ;
      }
      
      private static ViewDataTable GenerateSeriesView 
      ( 
         DataSet source, 
         List <string> columns 
      ) 
      {
         return GenerateView ( "SeriesView",
                               source, 
                               source.Tables[DataTableHelper.SeriesTableName], 
                               columns, 
                               SeriesLevelColumns ) ;      
      }
      
      private static ViewDataTable GenerateImageView 
      ( 
         DataSet source, 
         List <string> columns 
      ) 
      {
         return GenerateView ( "ImageView",
                               source, 
                               source.Tables[DataTableHelper.InstanceTableName], 
                               columns, 
                               ImageLevelColumns ) ;
      }

#if (LEADTOOLS_V19_OR_LATER)

      private static void AddDefinitionColumns(DataSet dataSet, string parentColumnName, string parentKey, string childKey)
      {
         if (dataSet != null)
         {
            DataTable hp = dataSet.Tables["hangingProtocol"];
            if (hp != null)
            {
               if (hp.Columns[parentColumnName] == null)
               {
                  DataColumn newColumn = hp.Columns.Add(parentColumnName, typeof(string));
                  newColumn.AllowDBNull = true;
                  newColumn.Unique = false;
               }

               foreach (DataRow row in hp.Rows)
               {
                  string sopInstanceUid = row[parentKey] as string;
                  string modalities = string.Empty;

                  DataTable definitionDataTable = dataSet.Tables["HangingProtocolDefinitonSequence"];
                  if (definitionDataTable != null)
                  {
                     string query = string.Format(@"{0} = '{1}'", parentKey, sopInstanceUid);
                     DataRow[] definitionRows = definitionDataTable.Select(query);
                     foreach(DataRow definitionRow in definitionRows)
                     {
                        string modality = definitionRow[childKey] as string;
                        modalities += modality + Environment.NewLine;
                     }
                     modalities = modalities.TrimEnd(new char[] {'\r', '\n'});
                  }
                  row.SetField(parentColumnName, modalities);
               }
            }

         }
      }

      private static ViewDataTable GenerateHangingProtocolView 
      ( 
         DataSet source, 
         List <string> columns 
      ) 
      {
         AddDefinitionColumns(source, "Modalities", "SOPInstanceUID", "Modality");
         AddDefinitionColumns(source, "Lateralities", "SOPInstanceUID", "Laterality");
         AddDefinitionColumns(source, "StudyDescriptions", "SOPInstanceUID", "StudyDescription");

         AddDefinitionColumns(source, "BodyPartsExamined", "SOPInstanceUID", "BodyPartExamined");
         AddDefinitionColumns(source, "ProtocolNames", "SOPInstanceUID", "ProtocolName");

         return GenerateView ( "HangingProtocolView",
                               source, 
                               source.Tables[DataTableHelper.HangingProtocolTableName], 
                               columns, 
                               HangingProtocolColumns ) ;
      }

      private static ViewDataTable GenerateHangingProtocolDefinitionView 
      ( 
         DataSet source, 
         List <string> columns 
      ) 
      {
         return GenerateView ( "HangingProtocolDefinitionView",
                               source, 
                               source.Tables[DataTableHelper.HangingProtocolDefinitionTableName], 
                               columns, 
                               HangingProtocolDefinitionColumns ) ;
      }
#endif // #if (LEADTOOLS_V19_OR_LATER)
      
      private static ViewDataTable GenerateView 
      ( 
         string viewName, 
         DataSet source, 
         DataTable sourceTable, 
         List <string> columns, 
         Dictionary <string, string> viewLevelColumnTables 
      ) 
      {  
         ViewDataTable viewTable = new ViewDataTable ( viewName ) ;
         if (sourceTable == null)
         {
            return viewTable;
         }
         
         foreach ( string column in columns )
         {
            DataColumn origColumn ;
            
            if ( !viewLevelColumnTables.ContainsKey ( column ) ) 
            {
               throw new InvalidOperationException ( string.Format ( "Column: {0} doesn't belong to {1}", column, viewName ) ) ;
            }

            origColumn = source.Tables [ viewLevelColumnTables [ column ] ].Columns [ column ] ;
            
               viewTable.Columns.Add(origColumn.ColumnName, origColumn.DataType);
            }
         
         foreach ( DataRow sourceRow in sourceTable.Rows )
         {
            ViewDataRow viewRow ;
            Dictionary <string, DataRow> parentTablesRows ;
            
            
            viewRow          = viewTable.NewViewRow ( ) ;
            parentTablesRows = GetParentRows ( sourceRow ) ;
            
            foreach ( string column in columns )
            {
               if ( sourceTable.Columns.Contains ( column ) )
               {
                  viewRow [ column ] = sourceRow [ column ] ;
                  
                  viewRow.OriginalRow = sourceRow ;
                  viewRow.OriginalTable = sourceTable ;
               }
               else
               {
                  DataTable parentTable ;
                  DataRow   parentRow ;
                  
                  
                  parentTable = source.Tables [ viewLevelColumnTables [ column ] ] ;
                  parentRow = parentTablesRows [  parentTable.TableName ] ;
                  
                  viewRow [ column ] = parentRow [ column ] ;
                  
                  viewRow.OriginalRow   = parentRow ;
                  viewRow.OriginalTable = parentTable ;
               }
            }
            
            viewTable.Rows.Add ( viewRow ) ;
         }
         
         return viewTable ;
      }
      
      
      public static List <string> GetPatientLevelColumns ( )
      {
         string [ ] columns ;
         
         
         columns = new string [ PatientLevelColumns.Count ] ;
         
         PatientLevelColumns.Keys.CopyTo ( columns, 0 ) ;
         
         return new List<string> (  columns ) ;
      }
      
      public static List <string> GetStudyLevelColumns ( )
      {
         string [ ] columns ;
         
         
         columns = new string [ StudyLevelColumns.Count ] ;
         
         StudyLevelColumns.Keys.CopyTo ( columns, 0 ) ;
         
         return new List<string> (  columns ) ;
      }
      
      public static List <string> GetSeriesLevelColumns ( )
      {
         string [ ] columns ;
         
         
         columns = new string [ SeriesLevelColumns.Count ] ;
         
         SeriesLevelColumns.Keys.CopyTo ( columns, 0 ) ;
         
         return new List<string> (  columns ) ;
      }
      
      public static List <string> GetImageLevelColumns ( )
      {
         string [ ] columns ;
         
         
         columns = new string [ ImageLevelColumns.Count ] ;
         
         ImageLevelColumns.Keys.CopyTo ( columns, 0 ) ;
         
         return new List<string> (  columns ) ;
      }

#if (LEADTOOLS_V19_OR_LATER)
      public static List <string> GetHangingProtocolColumns ( )
      {
         string [ ] columns = new string [ HangingProtocolColumns.Count ] ;
         
         HangingProtocolColumns.Keys.CopyTo ( columns, 0 ) ;
         
         return new List<string> (  columns ) ;
      }

      public static List <string> GetHangingProtocolDefinitionColumns ( )
      {
         string [ ] columns = new string [ HangingProtocolDefinitionColumns.Count ] ;
         
         HangingProtocolDefinitionColumns.Keys.CopyTo ( columns, 0 ) ;
         
         return new List<string> (  columns ) ;
      }
#endif // #if (LEADTOOLS_V19_OR_LATER)
      
      private static Dictionary <string, DataRow>  GetParentRows ( DataRow sourceRow ) 
      {
         Dictionary <string, DataRow> parentRowsTable ;
         DataTable currentTable ;
         
         
         parentRowsTable = new Dictionary<string,DataRow> ( ) ;
         currentTable    = sourceRow.Table ;
         
         while ( currentTable.ParentRelations.Count > 0 )
         {
            DataRow parentRow ;
            
            
            //parentRow = sourceRow.GetParentRow ( currentTable.ParentRelations [ 0 ] ) ;
            
            DataRelation dr = currentTable.ParentRelations [ 0 ];
            parentRow = sourceRow.GetParentRow ( dr, DataRowVersion.Default) ;

            
            parentRowsTable.Add ( parentRow.Table.TableName, parentRow ) ;
            
            currentTable = parentRow.Table ;
            sourceRow    = parentRow ;
         }
         
         return parentRowsTable ;
      }
      
      private static Dictionary <string,string> GeneratePatientLevelColumns ( ) 
      {
         Dictionary <string,string> patientColumnsTable ;
         DataSet dicomInfoDS ;
         
         
         patientColumnsTable = new Dictionary<string,string> ( ) ;
         dicomInfoDS = DataTableHelper.CreateTypedDataSet();
         
         foreach (DataColumn column in dicomInfoDS.Tables[DataTableHelper.PatientTableName].Columns)
         {
            patientColumnsTable.AddIfNotPresent(column.ColumnName, dicomInfoDS.Tables[DataTableHelper.PatientTableName].TableName);
         }

         //
         //patientColumnsTable.Add ( dicomInfoDS.Patient.PatientIDColumn.ColumnName, 
         //                          dicomInfoDS.Patient.TableName ) ;
         //patientColumnsTable.Add ( dicomInfoDS.Patient.FamilyNameColumn.ColumnName, 
         //                          dicomInfoDS.Patient.TableName ) ;
                                   
         //patientColumnsTable.Add ( dicomInfoDS.Patient.GivenNameColumn.ColumnName, 
         //                          dicomInfoDS.Patient.TableName ) ;
                                   
         //patientColumnsTable.Add ( dicomInfoDS.Patient.MiddleNameColumn.ColumnName, 
         //                          dicomInfoDS.Patient.TableName ) ;
                                   
         //patientColumnsTable.Add ( dicomInfoDS.Patient.NamePrefixColumn.ColumnName, 
         //                          dicomInfoDS.Patient.TableName ) ;
                                   
         //patientColumnsTable.Add ( dicomInfoDS.Patient.NameSuffixColumn.ColumnName, 
         //                          dicomInfoDS.Patient.TableName ) ;
                                   
         //patientColumnsTable.Add ( dicomInfoDS.Patient.BirthDateColumn.ColumnName, 
         //                          dicomInfoDS.Patient.TableName ) ;
                                   
         //patientColumnsTable.Add ( dicomInfoDS.Patient.SexColumn.ColumnName, 
         //                          dicomInfoDS.Patient.TableName ) ;

         //patientColumnsTable.Add ( dicomInfoDS.Patient.EthnicGroupColumn.ColumnName, 
         //                          dicomInfoDS.Patient.TableName ) ;
                                   
         //patientColumnsTable.Add ( dicomInfoDS.Patient.CommentsColumn.ColumnName, 
         //                          dicomInfoDS.Patient.TableName ) ;
         //
         
         return patientColumnsTable ;
      }
      private static Dictionary <string,string> GenerateStudyLevelColumns ( ) 
      {
         Dictionary <string,string> studyColumnsTable ;
         DataSet dicomInfoDS ;
         
         
         studyColumnsTable = new Dictionary<string,string> ( ) ;
         
         dicomInfoDS = DataTableHelper.CreateTypedDataSet();
        
         foreach (DataColumn column in dicomInfoDS.Tables[DataTableHelper.PatientTableName].Columns)
         {
            studyColumnsTable.AddIfNotPresent(column.ColumnName, dicomInfoDS.Tables[DataTableHelper.PatientTableName].TableName);
         }
         
         foreach (DataColumn column in dicomInfoDS.Tables[DataTableHelper.StudyTableName].Columns)
         {
            studyColumnsTable.AddIfNotPresent(column.ColumnName, dicomInfoDS.Tables[DataTableHelper.StudyTableName].TableName);
         }

         //studyColumnsTable.Add ( dicomInfoDS.Patient.PatientIDColumn.ColumnName, 
         //                        dicomInfoDS.Patient.TableName ) ;
         
         //studyColumnsTable.Add ( dicomInfoDS.Patient.FamilyNameColumn.ColumnName, 
         //                        dicomInfoDS.Patient.TableName ) ;
                                   
         //studyColumnsTable.Add ( dicomInfoDS.Patient.GivenNameColumn.ColumnName, 
         //                        dicomInfoDS.Patient.TableName ) ;
                                   
         //studyColumnsTable.Add ( dicomInfoDS.Patient.BirthDateColumn.ColumnName, 
         //                        dicomInfoDS.Patient.TableName ) ;
                                   
         //studyColumnsTable.Add ( dicomInfoDS.Patient.SexColumn.ColumnName, 
         //                        dicomInfoDS.Patient.TableName ) ;
                                 
         //studyColumnsTable.Add ( dicomInfoDS.Study.StudyInstanceUIDColumn.ColumnName, 
         //                        dicomInfoDS.Study.TableName ) ;
                                 
         //studyColumnsTable.Add ( dicomInfoDS.Study.StudyDateColumn.ColumnName, 
         //                        dicomInfoDS.Study.TableName ) ;
                                 
         //studyColumnsTable.Add ( dicomInfoDS.Study.AccessionNumberColumn.ColumnName, 
         //                        dicomInfoDS.Study.TableName ) ;
                                 
         //studyColumnsTable.Add ( dicomInfoDS.Study.StudyIDColumn.ColumnName, 
         //                        dicomInfoDS.Study.TableName ) ;
                                 
         //studyColumnsTable.Add ( dicomInfoDS.Study.ReferDrFamilyNameColumn.ColumnName, 
         //                        dicomInfoDS.Study.TableName ) ;
                                 
         //studyColumnsTable.Add ( dicomInfoDS.Study.ReferDrGivenNameColumn.ColumnName, 
         //                        dicomInfoDS.Study.TableName ) ;
                                 
         //studyColumnsTable.Add ( dicomInfoDS.Study.ReferDrMiddleNameColumn.ColumnName, 
         //                        dicomInfoDS.Study.TableName ) ;
                                 
         //studyColumnsTable.Add ( dicomInfoDS.Study.ReferDrNamePrefixColumn.ColumnName, 
         //                        dicomInfoDS.Study.TableName ) ;
                                 
         //studyColumnsTable.Add ( dicomInfoDS.Study.ReferDrNameSuffixColumn.ColumnName, 
         //                        dicomInfoDS.Study.TableName ) ;
                                 
         //studyColumnsTable.Add ( dicomInfoDS.Study.StudyDescriptionColumn.ColumnName, 
         //                        dicomInfoDS.Study.TableName ) ;
                                 
         //studyColumnsTable.Add ( dicomInfoDS.Study.AdmittingDiagnosesDescColumn.ColumnName, 
         //                        dicomInfoDS.Study.TableName ) ;
                                 
         //studyColumnsTable.Add ( dicomInfoDS.Study.PatientAgeColumn.ColumnName, 
         //                        dicomInfoDS.Study.TableName ) ;
                                 
         //studyColumnsTable.Add ( dicomInfoDS.Study.PatientSizeColumn.ColumnName, 
         //                        dicomInfoDS.Study.TableName ) ;
                                 
         //studyColumnsTable.Add ( dicomInfoDS.Study.PatientWeightColumn.ColumnName, 
         //                        dicomInfoDS.Study.TableName ) ;
                                 
         //studyColumnsTable.Add ( dicomInfoDS.Study.OccupationColumn.ColumnName, 
         //                        dicomInfoDS.Study.TableName ) ;
                                 
         //studyColumnsTable.Add ( dicomInfoDS.Study.AdditionalPatientHistoryColumn.ColumnName, 
         //                        dicomInfoDS.Study.TableName ) ;
                                 
         //studyColumnsTable.Add ( dicomInfoDS.Study.InterpretationAuthorColumn.ColumnName, 
         //                        dicomInfoDS.Study.TableName ) ;
                                
         return studyColumnsTable ;
      }
      private static Dictionary <string,string> GenerateSeriesLevelColumns ( )
      {
         Dictionary <string,string> seriesColumnsTable ;
         DataSet dicomInfoDS ;
         
         
         seriesColumnsTable = new Dictionary<string,string> ( ) ;
         
         dicomInfoDS = DataTableHelper.CreateTypedDataSet();
         
         foreach (DataColumn column in dicomInfoDS.Tables[DataTableHelper.PatientTableName].Columns)
         {
            seriesColumnsTable.AddIfNotPresent(column.ColumnName, dicomInfoDS.Tables[DataTableHelper.PatientTableName].TableName);
         }
         
         foreach (DataColumn column in dicomInfoDS.Tables[DataTableHelper.StudyTableName].Columns)
         {
            seriesColumnsTable.AddIfNotPresent(column.ColumnName, dicomInfoDS.Tables[DataTableHelper.StudyTableName].TableName);
         }

         foreach (DataColumn column in dicomInfoDS.Tables[DataTableHelper.SeriesTableName].Columns)
         {
            seriesColumnsTable.AddIfNotPresent(column.ColumnName, dicomInfoDS.Tables[DataTableHelper.SeriesTableName].TableName);
         }
         
         //seriesColumnsTable.Add ( dicomInfoDS.Patient.PatientIDColumn.ColumnName, 
         //                        dicomInfoDS.Patient.TableName ) ;
         
         //seriesColumnsTable.Add ( dicomInfoDS.Patient.FamilyNameColumn.ColumnName, 
         //                        dicomInfoDS.Patient.TableName ) ;
                                   
         //seriesColumnsTable.Add ( dicomInfoDS.Patient.GivenNameColumn.ColumnName, 
         //                        dicomInfoDS.Patient.TableName ) ;
                                   
         //seriesColumnsTable.Add ( dicomInfoDS.Patient.BirthDateColumn.ColumnName, 
         //                        dicomInfoDS.Patient.TableName ) ;
                                   
         //seriesColumnsTable.Add ( dicomInfoDS.Patient.SexColumn.ColumnName, 
         //                        dicomInfoDS.Patient.TableName ) ;
                                 
         //seriesColumnsTable.Add ( dicomInfoDS.Study.StudyInstanceUIDColumn.ColumnName, 
         //                        dicomInfoDS.Study.TableName ) ;
                                 
         //seriesColumnsTable.Add ( dicomInfoDS.Study.StudyDateColumn.ColumnName, 
         //                        dicomInfoDS.Study.TableName ) ;
                                 
         //seriesColumnsTable.Add ( dicomInfoDS.Study.AccessionNumberColumn.ColumnName, 
         //                        dicomInfoDS.Study.TableName ) ;
                                 
         //seriesColumnsTable.Add ( dicomInfoDS.Study.StudyIDColumn.ColumnName, 
         //                        dicomInfoDS.Study.TableName ) ;
                                 
         //seriesColumnsTable.Add ( dicomInfoDS.Study.ReferDrFamilyNameColumn.ColumnName, 
         //                        dicomInfoDS.Study.TableName ) ;
                                 
         //seriesColumnsTable.Add ( dicomInfoDS.Study.ReferDrGivenNameColumn.ColumnName, 
         //                        dicomInfoDS.Study.TableName ) ;
                                 
         //seriesColumnsTable.Add ( dicomInfoDS.Series.SeriesInstanceUIDColumn.ColumnName, 
         //                         dicomInfoDS.Series.TableName ) ;
                                  
         //seriesColumnsTable.Add ( dicomInfoDS.Series.ModalityColumn.ColumnName, 
         //                         dicomInfoDS.Series.TableName ) ;
                                  
         //seriesColumnsTable.Add ( dicomInfoDS.Series.SeriesNumberColumn.ColumnName, 
         //                         dicomInfoDS.Series.TableName ) ;
                                  
         //seriesColumnsTable.Add ( dicomInfoDS.Series.SeriesDateColumn.ColumnName, 
         //                         dicomInfoDS.Series.TableName ) ;
                                  
         //seriesColumnsTable.Add ( dicomInfoDS.Series.SeriesDescriptionColumn.ColumnName, 
         //                         dicomInfoDS.Series.TableName ) ;
                                  
         //seriesColumnsTable.Add ( dicomInfoDS.Series.InstitutionNameColumn.ColumnName, 
         //                         dicomInfoDS.Series.TableName ) ;                       
         return seriesColumnsTable ;
      }
      private static Dictionary <string, string> GenerateImageLevelColumns ( ) 
      {
         Dictionary <string,string> ImagesColumnsTable ;
         DataSet dicomInfoDS ;
         
         
         ImagesColumnsTable = new Dictionary<string,string> ( ) ;

         dicomInfoDS = DataTableHelper.CreateTypedDataSet();
         
         foreach (DataColumn column in dicomInfoDS.Tables[DataTableHelper.PatientTableName].Columns)
         {
            ImagesColumnsTable.AddIfNotPresent(column.ColumnName, dicomInfoDS.Tables[DataTableHelper.PatientTableName].TableName);
         }
         
         foreach (DataColumn column in dicomInfoDS.Tables[DataTableHelper.StudyTableName].Columns)
         {
            ImagesColumnsTable.AddIfNotPresent(column.ColumnName, dicomInfoDS.Tables[DataTableHelper.StudyTableName].TableName);
         }

         foreach (DataColumn column in dicomInfoDS.Tables[DataTableHelper.SeriesTableName].Columns)
         {
            ImagesColumnsTable.AddIfNotPresent(column.ColumnName, dicomInfoDS.Tables[DataTableHelper.SeriesTableName].TableName);
         }
         
         foreach (DataColumn column in dicomInfoDS.Tables[DataTableHelper.InstanceTableName].Columns)
         {
            ImagesColumnsTable.AddIfNotPresent(column.ColumnName, dicomInfoDS.Tables[DataTableHelper.InstanceTableName].TableName);
         }

         //ImagesColumnsTable.Add ( dicomInfoDS.Patient.PatientIDColumn.ColumnName, 
         //                        dicomInfoDS.Patient.TableName ) ;
         
         //ImagesColumnsTable.Add ( dicomInfoDS.Patient.FamilyNameColumn.ColumnName, 
         //                        dicomInfoDS.Patient.TableName ) ;
                                   
         //ImagesColumnsTable.Add ( dicomInfoDS.Patient.GivenNameColumn.ColumnName, 
         //                        dicomInfoDS.Patient.TableName ) ;
                                   
         //ImagesColumnsTable.Add ( dicomInfoDS.Patient.BirthDateColumn.ColumnName, 
         //                        dicomInfoDS.Patient.TableName ) ;
                                   
         //ImagesColumnsTable.Add ( dicomInfoDS.Patient.SexColumn.ColumnName, 
         //                        dicomInfoDS.Patient.TableName ) ;
                                 
         //ImagesColumnsTable.Add ( dicomInfoDS.Study.StudyInstanceUIDColumn.ColumnName, 
         //                        dicomInfoDS.Study.TableName ) ;
                                 
         //ImagesColumnsTable.Add ( dicomInfoDS.Study.StudyDateColumn.ColumnName, 
         //                        dicomInfoDS.Study.TableName ) ;
                                 
         //ImagesColumnsTable.Add ( dicomInfoDS.Study.AccessionNumberColumn.ColumnName, 
         //                        dicomInfoDS.Study.TableName ) ;
                                 
         //ImagesColumnsTable.Add ( dicomInfoDS.Study.StudyIDColumn.ColumnName, 
         //                        dicomInfoDS.Study.TableName ) ;
                                 
         //ImagesColumnsTable.Add ( dicomInfoDS.Study.ReferDrFamilyNameColumn.ColumnName, 
         //                        dicomInfoDS.Study.TableName ) ;
                                 
         //ImagesColumnsTable.Add ( dicomInfoDS.Study.ReferDrGivenNameColumn.ColumnName, 
         //                        dicomInfoDS.Study.TableName ) ;
                                 
         //ImagesColumnsTable.Add ( dicomInfoDS.Series.SeriesInstanceUIDColumn.ColumnName, 
         //                         dicomInfoDS.Series.TableName ) ;
                                  
         //ImagesColumnsTable.Add ( dicomInfoDS.Series.ModalityColumn.ColumnName, 
         //                         dicomInfoDS.Series.TableName ) ;
                                  
         //ImagesColumnsTable.Add ( dicomInfoDS.Series.SeriesNumberColumn.ColumnName, 
         //                         dicomInfoDS.Series.TableName ) ;
                                  
         //ImagesColumnsTable.Add ( dicomInfoDS.Series.SeriesDateColumn.ColumnName, 
         //                         dicomInfoDS.Series.TableName ) ;
                                  
         //ImagesColumnsTable.Add ( dicomInfoDS.Series.SeriesDescriptionColumn.ColumnName, 
         //                         dicomInfoDS.Series.TableName ) ;
                                  
         //ImagesColumnsTable.Add ( dicomInfoDS.Series.InstitutionNameColumn.ColumnName, 
         //                         dicomInfoDS.Series.TableName ) ;
                                  
         //ImagesColumnsTable.Add ( dicomInfoDS.Instance.SOPInstanceUIDColumn.ColumnName, 
         //                         dicomInfoDS.Instance.TableName ) ;
                                  
         //ImagesColumnsTable.Add ( dicomInfoDS.Instance.InstanceNumberColumn.ColumnName, 
         //                         dicomInfoDS.Instance.TableName ) ;
                                  
         //ImagesColumnsTable.Add ( dicomInfoDS.Instance.ReferencedFileColumn.ColumnName, 
         //                         dicomInfoDS.Instance.TableName ) ;
                                  
         //ImagesColumnsTable.Add ( dicomInfoDS.Instance.TransferSyntaxColumn.ColumnName, 
         //                         dicomInfoDS.Instance.TableName ) ;
                                  
         //ImagesColumnsTable.Add ( dicomInfoDS.Instance.StationNameColumn.ColumnName, 
         //                         dicomInfoDS.Instance.TableName ) ;
                                  
         //ImagesColumnsTable.Add ( dicomInfoDS.Instance.ReceiveDateColumn.ColumnName, 
         //                         dicomInfoDS.Instance.TableName ) ;
                                  
         //ImagesColumnsTable.Add ( dicomInfoDS.Instance.RetrieveAETitleColumn.ColumnName, 
         //                         dicomInfoDS.Instance.TableName ) ;
                      
         return ImagesColumnsTable ;
      }
      
      private static Dictionary <string,string> PatientLevelColumns = GeneratePatientLevelColumns ( ) ;
      private static Dictionary <string,string> StudyLevelColumns   = GenerateStudyLevelColumns ( ) ;
      private static Dictionary <string,string> SeriesLevelColumns  = GenerateSeriesLevelColumns ( ) ;
      private static Dictionary <string,string> ImageLevelColumns   = GenerateImageLevelColumns ( ) ;

#if (LEADTOOLS_V19_OR_LATER)
      private static Dictionary <string,string> HangingProtocolColumns   = GenerateHangingProtocolColumns ( ) ;
      private static Dictionary <string,string> HangingProtocolDefinitionColumns   = GenerateHangingProtocolDefinitionColumns ( ) ;
#endif

#if (LEADTOOLS_V19_OR_LATER)
      private static Dictionary <string, string> GenerateHangingProtocolColumns ( ) 
      {
         Dictionary <string,string> HangingProtocolColumnsTable = new Dictionary<string,string> ( ) ;
         DataSet dicomInfoDS = DataTableHelper.CreateHangingProtocolDataSet();
         
         foreach (DataColumn column in dicomInfoDS.Tables[DataTableHelper.HangingProtocolTableName].Columns)
         {
            HangingProtocolColumnsTable.AddIfNotPresent(column.ColumnName, dicomInfoDS.Tables[DataTableHelper.HangingProtocolTableName].TableName);
         }

         HangingProtocolColumnsTable.AddIfNotPresent("Modalities", dicomInfoDS.Tables[DataTableHelper.HangingProtocolTableName].TableName);
         HangingProtocolColumnsTable.AddIfNotPresent("Lateralities", dicomInfoDS.Tables[DataTableHelper.HangingProtocolTableName].TableName);
         HangingProtocolColumnsTable.AddIfNotPresent("StudyDescriptions", dicomInfoDS.Tables[DataTableHelper.HangingProtocolTableName].TableName);

         HangingProtocolColumnsTable.AddIfNotPresent("BodyPartsExamined", dicomInfoDS.Tables[DataTableHelper.HangingProtocolTableName].TableName);
         HangingProtocolColumnsTable.AddIfNotPresent("ProtocolNames", dicomInfoDS.Tables[DataTableHelper.HangingProtocolTableName].TableName);
         
         return HangingProtocolColumnsTable ;
      }

      private static Dictionary <string, string> GenerateHangingProtocolDefinitionColumns ( ) 
      {
         Dictionary <string,string> HangingProtocolDefinitionColumnsTable = new Dictionary<string,string> ( ) ;
         DataSet dicomInfoDS = DataTableHelper.CreateHangingProtocolDataSet();

         foreach (DataColumn column in dicomInfoDS.Tables[DataTableHelper.HangingProtocolTableName].Columns)
         {
            HangingProtocolDefinitionColumnsTable.AddIfNotPresent(column.ColumnName, dicomInfoDS.Tables[DataTableHelper.HangingProtocolTableName].TableName);
         }
         
         foreach (DataColumn column in dicomInfoDS.Tables[DataTableHelper.HangingProtocolDefinitionTableName].Columns)
         {
            HangingProtocolDefinitionColumnsTable.AddIfNotPresent(column.ColumnName, dicomInfoDS.Tables[DataTableHelper.HangingProtocolDefinitionTableName].TableName);
         }
         
         return HangingProtocolDefinitionColumnsTable ;
      }
#endif //#if (LEADTOOLS_V19_OR_LATER)
      
      public class ViewDataRow : DataRow 
      {
         internal ViewDataRow ( DataRowBuilder rb ) : base ( rb ) 
         {
             
         }

         
         public DataRow OriginalRow 
         {
            get
            {
               return _originalRow ;
            }
            
            set
            {
               _originalRow = value ;
            }
         }
         
         public DataTable OriginalTable 
         {
            get
            {
               return _originalTable ;
            }
            
            set
            {
               _originalTable = value ;
            }
         }
         
         private DataRow   _originalRow ;
         private DataTable _originalTable ;
      }
      
      public class ViewDataTable : DataTable 
      {
         public ViewDataTable ( string tableName ) : base ( tableName ) {}
         protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
         {
            return new ViewDataRow ( builder ) ;
         }
         
         public ViewDataRow NewViewRow ( ) 
         {
            return ( ( ViewDataRow )( this.NewRow ( ) ) );
         }

      }
   }
   
   public enum DicomInformationView
   {
      // None,
      PatientLevel,
      StudiesLevel,
      SeriesLevel,
      ImagesLevel,
      HangingProtocol,
      HangingProtocolDefinition,
   }
}
