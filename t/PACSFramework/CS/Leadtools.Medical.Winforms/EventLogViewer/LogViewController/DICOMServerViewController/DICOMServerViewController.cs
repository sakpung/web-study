// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System ;
using System.Data ;
using System.IO ;
using System.Reflection ;
using System.Collections.Generic;
using System.Windows.Forms; 
using Leadtools.Medical.DataAccessLayer ;
using Leadtools.Medical.DataAccessLayer.Catalog ;
using Leadtools.Medical.Winforms.Control ;
using Leadtools.Medical.Logging.DataAccessLayer ;
using Leadtools.Medical.Logging.DataAccessLayer.MatchingParameters ;
using Leadtools.Medical.Logging.DataAccessLayer.Configuration ;
using System.Xml.Serialization;
using System.Text;
using Leadtools.Dicom;
using Leadtools.Logging.Medical;
using Leadtools.Logging;
using Leadtools.DicomDemos;
using System.ComponentModel;

      

namespace Leadtools.Medical.Winforms
{
   class DICOMServerViewController: LogViewController
   {
      #region Public
         
         #region Methods
         
            public DICOMServerViewController 
            ( 
               DICOMServerMain ctlServerMainView 
            )
            {
               try
               {
                  Init ( ctlServerMainView ) ;
                  
                  RegisterEvents ( ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }	
            }

            private QueryState GetCurrentQueryState()
            {
               MatchingParameterCollection ServerMatchingParametersListCollection;
               MatchingParameterList ServerMatchingParametersList;
               DICOMServerEventLogMatchingParameters serverEventLogEntity;
               DICOMServerQuery.QueryFilterType CurrentFilterType;
               QueryState CurrentQueryState;


               ServerMatchingParametersListCollection = new MatchingParameterCollection();
               ServerMatchingParametersList = new MatchingParameterList();
               serverEventLogEntity = new DICOMServerEventLogMatchingParameters();
               CurrentFilterType = __ServerMainView.SelectedQueryFilter;
               CurrentQueryState = new QueryState();

               FillGeneralMatchingParams(serverEventLogEntity);
               FillDateRangeMatchingParams(serverEventLogEntity);
               FillClientsMatchingParams(serverEventLogEntity);
               FillServerMatchingParams(serverEventLogEntity);

               ServerMatchingParametersList.Add(serverEventLogEntity);

               ServerMatchingParametersListCollection.Add(ServerMatchingParametersList);

               CurrentQueryState.MatchingParametersListCollection = ServerMatchingParametersListCollection;

               if ((DICOMServerQuery.QueryFilterType.LastEntry & CurrentFilterType) != 0)
               {
                  CurrentQueryState.LastRowsCount = __ServerMainView.LastLogs;
               }
               else
               {
                  CurrentQueryState.LastRowsCount = Constants.General.LastEntryNotSpcified;
               }


               if (null != __LastQueryState)
               {
                  CurrentQueryState.OrderParamsList = __LastQueryState.OrderParamsList;
               }
               else
               {
                  OrderByParameter ServerOrderByParameter;
                  OrderByParametersList ServerOrderByParametersList;


                  ServerOrderByParameter = new OrderByParameter();
                  ServerOrderByParametersList = new OrderByParametersList();

                  //ServerOrderByParameter.Ascending = false ;

                  //ServerOrderByParameter.OrderBy = OrderByParameter.OrderByOptions.ServerEventDateTime ;

                  ServerOrderByParametersList.Add(ServerOrderByParameter);

                  CurrentQueryState.OrderParamsList = ServerOrderByParametersList;
               }
               return CurrentQueryState;
            }
            
            public int PerformQuery ( )
            {
               try
               {
                  
                  QueryState CurrentQueryState = GetCurrentQueryState();
                  
                  QueryServerEventLogTable ( CurrentQueryState ) ;
                  
                  __LastDICOMServerEventLogIDsSum = __DataAccessAgent.GetDicomEventLogIdsSum ( CurrentQueryState.MatchingParametersListCollection ) ;
                  
                  __ServerMainView.QueryStateChanged  ( true ) ;
                  
                  __LastQueryState = CurrentQueryState ;
                  
                  __QueryPerformed = true ;
                  
                  __ImportLogActive = false;
                  
                  return __EventLogId.Count ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  __ServerMainView.QueryStateChanged  ( false ) ;
                  
                  throw exception ;
               }
            }
            
            private DICOMServerEventLogMatchingParameters GetDICOMServerEventLogMatchingParameters(QueryState queryState)
            {
               DICOMServerEventLogMatchingParameters ret = null;

               if (queryState == null)
                  return null;

               if (queryState.MatchingParametersListCollection.Count != 1)
                  return null;

               if (queryState.MatchingParametersListCollection[0].Count != 1)
                  return null;

               MatchingParameterList matchingParameterListItem = queryState.MatchingParametersListCollection[0];
               ICatalogEntity entity = matchingParameterListItem[0];

               ret = entity as DICOMServerEventLogMatchingParameters;
               return ret;
            }
           
            public void CancelImportAsync(ImportLogArgs args)
            {
               if (_bw.WorkerSupportsCancellation == true)
               {
                  _cancelImport = true;
                  _bw.CancelAsync();
               }
            }
            
            protected virtual void OnImportStarting(ImportLogArgs e)
            {
               if (ImportStarting != null)
               {
                  ImportStarting(this, e);
               }
            }
            
            protected virtual void OnImportCompleted(ImportLogArgs e)
            {
               if (ImportCompleted != null)
               {
                  ImportCompleted(this, e);
               }
            }
            
            public void ImportAsync ( List<string> files)
            {
               _cancelImport = false;
               __ServerMainView.ServerLogsCount = 0;
               QueryState CurrentQueryState = GetCurrentQueryState();

               DICOMServerEventLogMatchingParameters matchingParameters = GetDICOMServerEventLogMatchingParameters(CurrentQueryState);

               // The code below is if you are reading index.xml, which doesn't always contain the full list of files
               //List<String> files = new List<String>();
               //XmlReader reader = XmlReader.Create(strFilePath);
               //while (reader.Read())
               //{
               //   if (reader.NodeType == XmlNodeType.Element && reader.Name == "logFile")
               //   {
               //      string fileName = reader.GetAttribute("file");
               //      files.Add(fileName);
               //   }
               //}

               __EventLogId = new List<long>();
               __DICOMServerEventLogGeneralInfoCacheDataset.Clear();

               // Sort the files from highest number to lowest
               // This is important because when you only want to see the last 'n' logs, you dont' want to open every log file
               // Sort by file number (the name of the file is a number) to achieve this
               files.Sort(delegate(string path0, string path1)
                        {
                           int nCompare = 0;
                           
                           int nFile0 = 0;
                           string file0 = Path.GetFileNameWithoutExtension(path0);
                           bool result0 = Int32.TryParse(file0, out nFile0);
                           
                           int nFile1 = 0;
                           string file1 = Path.GetFileNameWithoutExtension(path1);
                           bool result1 = Int32.TryParse(file1, out nFile1);

                           if (result0 && result1)
                           {
                              // if files are all digits
                              nCompare = nFile1.CompareTo(nFile0);
                           }
                           else
                           {
                              // if one of the files is not all digits
                              nCompare = file0.CompareTo(file1);
                           }
                           return nCompare;
                        }
                     );

               if (!_bw.IsBusy)
               {
                  ImportLogArgs args = new ImportLogArgs(files, matchingParameters, CurrentQueryState, CurrentQueryState.LastRowsCount);
                  OnImportStarting(args);
                  _bw.RunWorkerAsync(args);
               }
            }
            
            private string sColEventID = "EventID: ";
            private string sColServerAETitle = "ServerAETitle: ";
            private string sColServerIPAddress = "ServerIPAddress: ";
            private string sColServerPort = "ServerPort: ";
            private string sColClientAETitle = "ClientAETitle: ";
            private string sColClientHostAddress = "ClientHostAddress: ";
            private string sColClientPort = "ClientPort: ";
            private string sColCommand = "Command: ";
            
            private string sColEventDateTime = "EventDateTime: ";
            private string sColType = "Type: ";
            private string sColMessageDirection = "MessageDirection: ";
            private string sColDescription = "Description: ";
            private string sColCustomInformation = "CustomInformation: ";
            private string sColDatasetPath = "DatasetPath: ";
            private string sColCustomType = "CustomType: ";
            
            private int MyConvertToInt32(string s)
            {
               int ret = 0;
               Int32.TryParse(s, out ret);
               return ret;
            }

            private bool IsFailStringMatch(string mpString, string rowString)
            {
               if (!string.IsNullOrEmpty(mpString))
               {
                  if (mpString.EndsWith("*", StringComparison.OrdinalIgnoreCase))
                  {
                     string sVal = mpString.Substring(0, mpString.Length - 1);
                     if (!rowString.StartsWith(sVal, StringComparison.OrdinalIgnoreCase))
                        return false;
                  }
                  else if (string.Compare(mpString, rowString, StringComparison.OrdinalIgnoreCase) != 0)
                  {
                     return false;
                  }
               }
               return true;
            }
            
            private bool IsRowInQueryState(DicomEventLogDataSet.DICOMServerEventLogRow row, DICOMServerEventLogMatchingParameters mp)
            {
               // Type
               if (!string.IsNullOrEmpty(mp.Type))
               {
                  if (string.IsNullOrEmpty(row.Type) && mp.Type.Contains("Undefined"))
                  {
                  }
                  else if (!string.IsNullOrEmpty(row.Type) && mp.Type.Contains(row.Type))
                  {
                  }
                  else
                     return false;
               }
               
               // Command
               if (!string.IsNullOrEmpty(mp.Command))
               {
                  if (string.IsNullOrEmpty(row.Command) && mp.Command.Contains("Undefined"))
                  {
                  }
                  else if (!string.IsNullOrEmpty(row.Command) && mp.Command.Contains(row.Command))
                  {
                  }
                  else
                     return false;
               }
               
               // Date
               if (mp.EventDateTime.StartDate != null || mp.EventDateTime.EndDate != null )
               {
                  if (mp.EventDateTime.StartDate.HasValue)
                  {
                     if (DateTime.Compare(mp.EventDateTime.StartDate.Value, row.EventDateTime) > 0)
                        return false;
                  }
                  
                  if (mp.EventDateTime.EndDate.HasValue)
                  {
                     if (DateTime.Compare(row.EventDateTime, mp.EventDateTime.EndDate.Value) > 0)
                        return false;
                  }
               }

               // Client - AE Title
               if (false == IsFailStringMatch(mp.ClientAETitle, row.ClientAETitle))
               {
                  return false;
               }
               
               // Client - AE IP
               if (false == IsFailStringMatch(mp.ClientHostAddress, row.ClientHostAddress))
               {
                  return false;
               }
               
               // Client - Port
               if (false == IsFailStringMatch(mp.ClientPort, row.ClientPort.ToString()))
               {
                  return false;
               }

               // Server - AE Title
               if (false == IsFailStringMatch(mp.ServerAETitle, row.ServerAETitle))
               {
                  return false;
               }
               
               // Server - AE IP
               if (false == IsFailStringMatch(mp.ServerIPAddress, row.ServerIPAddress))
               {
                  return false;
               }
               
               // Server - Port
               if (false == IsFailStringMatch(mp.ServerPort, row.ServerPort.ToString()))
               {
                  return false;
               }
               
               
               
               return true;
            }
            
            // returns true:  skipped parsing the file, or successfully parsed the file
            //         false: failed to parse the file
            private bool ParseOneFile(string s, DICOMServerEventLogMatchingParameters matchingParameters, int lastRowsCount)
            {
               bool ret = false;
               if (lastRowsCount != -1 && __EventLogId.Count >= lastRowsCount)
                  return true;
               
               try
               {
               using (StreamReader reader = File.OpenText(s))
               {
                  string line;
                  while ((line = reader.ReadLine()) != null)
                  {
                     if (_cancelImport) 
                     {
                        break;
                     }
                     
                     string sCol = string.Empty;
                     string sVal = string.Empty;
                     int nEventID = 0;
                     if (line.Contains(sColEventID))
                     {
                        // beginning of log record
                        DicomEventLogDataSet.DICOMServerEventLogRow row = __DICOMServerEventLogGeneralInfoCacheDataset.DICOMServerEventLog.NewDICOMServerEventLogRow();

                        // EventID
                        sCol = sColEventID;
                        if (!string.IsNullOrEmpty(line) && line.Contains(sCol))
                        {
                           sVal = line.Replace(sCol, "");
                           sVal = sVal.Trim();
                           nEventID = MyConvertToInt32(sVal);
                           row.EventID = nEventID;
                           line = reader.ReadLine();
                        }

                        // ServerAETitle
                        sCol = sColServerAETitle;
                        if (!string.IsNullOrEmpty(line) && line.Contains(sCol))
                        {
                           sVal = line.Replace(sCol, "");
                           row.ServerAETitle = sVal.Trim();
                           line = reader.ReadLine();
                        }

                        // sColServerIPAddress
                        sCol = sColServerIPAddress;
                        if (!string.IsNullOrEmpty(line) && line.Contains(sCol))
                        {
                           sVal = line.Replace(sCol, "");
                           row.ServerIPAddress = sVal.Trim();
                           line = reader.ReadLine();
                        }

                        // sColServerPort
                        sCol = sColServerPort;
                        if (!string.IsNullOrEmpty(line) && line.Contains(sCol))
                        {
                           sVal = line.Replace(sCol, "");
                           sVal = sVal.Trim();
                           row.ServerPort = MyConvertToInt32(sVal);
                           line = reader.ReadLine();
                        }

                        // sColClientAETitle
                        sCol = sColClientAETitle;
                        if (!string.IsNullOrEmpty(line) && line.Contains(sCol))
                        {
                           sVal = line.Replace(sCol, "");
                           row.ClientAETitle = sVal.Trim();
                           line = reader.ReadLine();
                        }

                        // sColClientHostAddress
                        sCol = sColClientHostAddress;
                        if (!string.IsNullOrEmpty(line) && line.Contains(sCol))
                        {
                           sVal = line.Replace(sCol, "");
                           row.ClientHostAddress = sVal.Trim();
                           line = reader.ReadLine();
                        }

                        // sColClientPort
                        sCol = sColClientPort;
                        if (!string.IsNullOrEmpty(line) && line.Contains(sCol))
                        {
                           sVal = line.Replace(sCol, "");
                           sVal = sVal.Trim();
                           row.ClientPort = MyConvertToInt32(sVal);
                           line = reader.ReadLine();
                        }

                        // sColCommand
                        sCol = sColCommand;
                        if (!string.IsNullOrEmpty(line) && line.Contains(sCol))
                        {
                           sVal = line.Replace(sCol, "");
                           row.Command = sVal.Trim();
                           line = reader.ReadLine();
                        }

                        // sColEventDateTime
                        sCol = sColEventDateTime;
                        if (!string.IsNullOrEmpty(line) && line.Contains(sCol))
                        {
                           sVal = line.Replace(sCol, "");
                           sVal = sVal.Trim();
                           row.EventDateTime = DateTime.Parse(sVal);
                           line = reader.ReadLine();
                        }

                        // sColType 
                        sCol = sColType;
                        if (!string.IsNullOrEmpty(line) && line.Contains(sCol))
                        {
                           sVal = line.Replace(sCol, "");
                           row.Type = sVal.Trim();
                           line = reader.ReadLine();
                        }

                        // sColMessageDirection 
                        sCol = sColMessageDirection;
                        if (!string.IsNullOrEmpty(line) && line.Contains(sCol))
                        {
                           sVal = line.Replace(sCol, "");
                           row.MessageDirection = sVal.Trim();
                           line = reader.ReadLine();
                        }

                        // sColDescription   
                        sCol = sColDescription;
                        if (!string.IsNullOrEmpty(line) && line.Contains(sCol))
                        {
                           sVal = line.Replace(sCol, "");

                           // Description can span multiple lines
                           line = reader.ReadLine();
                           while (line != null && !line.Contains(sColCustomInformation))
                           {
                              sVal += "\n" + line;
                              line = reader.ReadLine();
                           }

                           row.Description = sVal.Trim();
                        }

                        // sColCustomInformation   
                        sCol = sColCustomInformation;
                        if (!string.IsNullOrEmpty(line) && line.Contains(sCol))
                        {
                           sVal = line.Replace(sCol, "");

                           // CustomInformation can span multiple lines
                           line = reader.ReadLine();
                           while (line != null && !line.Contains(sColDatasetPath))
                           {
                              sVal += "\n" + line;
                              line = reader.ReadLine();
                           }

                           row.CustomInformation = sVal.Trim();

                        }

                        // sColDatasetPath   
                        sCol = sColDatasetPath;
                        if (!string.IsNullOrEmpty(line) && line.Contains(sCol))
                        {
                           sVal = line.Replace(sCol, "");
                           sVal = sVal.Trim();
                           if (!string.IsNullOrEmpty(sVal))
                           {
                              row.DatasetPath = sVal.Trim();
                           }
                           line = reader.ReadLine();
                        }

                        // sColCustomType 
                        sCol = sColCustomType;
                        if (!string.IsNullOrEmpty(line) && line.Contains(sCol))
                        {
                           sVal = line.Replace(sCol, "");
                           row.CustomType = sVal.Trim();
                           line = reader.ReadLine();
                        }

                        if (IsRowInQueryState(row, matchingParameters))
                        {
                           ret = true;
                           __EventLogId.Add(nEventID);
                           __DICOMServerEventLogGeneralInfoCacheDataset.DICOMServerEventLog.AddDICOMServerEventLogRow(row);
                        }

                     } // if (line.Contains(sColEventID))
                  } // while ((line = reader.ReadLine()) != null)
               } // using (StreamReader reader = File.OpenText(s))
               
               }
               catch(Exception)
               {
                  ret = false;
               }
               return ret;
            }


            public void ExportSelected ( string strFilePath )
            {
               try
               {

                  ListView.SelectedIndexCollection  narrSelectedIndices ;
                  DICOMServerEventLogFormsFormatter ServerEventLogFormsFormatter ;
                  
                  using ( FileStream fleStream = new FileStream ( strFilePath, FileMode.Create, FileAccess.Write ) )
                  {
                                               
                     using ( StreamWriter strmWriter = new StreamWriter ( fleStream ) )
                     {
                        narrSelectedIndices = __ServerMainView.SelectedIndices ;
                        
                        ServerEventLogFormsFormatter = new DICOMServerEventLogFormsFormatter ( ) ;
                        
                        strmWriter.WriteLine ( Constants.General.EVENT_LOGGING_HEADER_TEXT ) ; 
                                       
                        strmWriter.WriteLine ( ) ;
                        
                     
                        for ( int nSelectedRowIndex = 0; nSelectedRowIndex < narrSelectedIndices.Count; nSelectedRowIndex++ )
                        {
                           WriteEventInfo ( __EventLogId [ narrSelectedIndices [ nSelectedRowIndex ] ], 
                                            strmWriter,
                                            ServerEventLogFormsFormatter ) ;
                                          
                           strmWriter.WriteLine ( ) ;
                        }
                     }
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }


            public void DeleteSelected ( )
            {
               try
               {
                  ListView.SelectedIndexCollection narrSelectedIndices ;
                  List <long> deletedEvents = null ;
                  bool           bSkipAllDeleted = false ;
                  
                  
                  narrSelectedIndices = __ServerMainView.SelectedIndices ;
                  
                  deletedEvents = new List <long> ( ) ;
                  
                  __ServerMainView.SuspendLogsLayout ( ) ;
                  
                  for ( int nSelectedRowIndex = 0; nSelectedRowIndex < narrSelectedIndices.Count; nSelectedRowIndex++ )
                  {
                     try
                     {
                        long logId ;
                        
                        
                        logId = __EventLogId [ narrSelectedIndices [ nSelectedRowIndex ] ] ;
                        
                        __DataAccessAgent.DeleteDicomEventLog ( logId ) ;  
                        
                        deletedEvents.Add ( logId ) ;
                     }
                     catch ( Exception exception )
                     {
                        if ( ! bSkipAllDeleted ) 
                        {
                           DialogResult CurrentEventLogStateDialogResult ;
                        
                        
                           CurrentEventLogStateDialogResult = ShowDeleteRowFailedMessage ( exception.Message ) ;
                        
                           switch ( CurrentEventLogStateDialogResult ) 
                           {
                              case DialogResult.Retry:
                              {
                                 --nSelectedRowIndex ;
                              }
                           
                              break;
                           
                              case DialogResult.Abort:
                              {
                                 bSkipAllDeleted = true ;
                              }
                           
                              break;
                           
                              default:
                              
                              break ;
                           }
                        }
                     }
                  }
                  
                  foreach ( long eventId in deletedEvents ) 
                  {
                     __EventLogId.Remove ( eventId ) ;
                  }
                  
                  RefreshQueryInfo ( ) ;
                  
                  if ( null != DeleteCompleted ) 
                  {
                     try
                     {
                        DeleteCompleted ( this, new RunWorkerCompletedEventArgs ( null, null, false ) ) ;
                     }
                     catch{}
                  }
               }
               catch ( Exception exception )
               {
                  if ( null != DeleteCompleted ) 
                  {
                     try
                     {
                        DeleteCompleted ( this, new RunWorkerCompletedEventArgs ( null, exception, false ) ) ;
                     }
                     catch{}
                  }
               }
               finally
               {
                  __ServerMainView.ResumeLogsLayout ( ) ;
               }
            }

            public void DeleteCurrentView ( ) 
            {
               if ( null == __LastQueryState )
               {
                  return ;
               }
               
               __ServerMainView.ServerLogsCount = 0 ;
               __ServerMainView.SuspendLogsLayout ( ) ;
               
               BackgroundWorker deleteWorker = new BackgroundWorker ( ) ;

               deleteWorker.DoWork += new DoWorkEventHandler ( deleteWorker_DoWork ) ;

               deleteWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler ( deleteWorker_RunWorkerCompleted ) ;
               
               deleteWorker.RunWorkerAsync ( new QueryState ( __LastQueryState.MatchingParametersListCollection, null, __LastQueryState.LastRowsCount )  ) ;
            }

            public void DeleteAll ( ) 
            {
               __ServerMainView.ServerLogsCount = 0 ;
               __ServerMainView.SuspendLogsLayout ( ) ;
               
               BackgroundWorker deleteWorker = new BackgroundWorker ( ) ;

               deleteWorker.DoWork += new DoWorkEventHandler ( deleteWorker_DoWork ) ;

               deleteWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler ( deleteWorker_RunWorkerCompleted ) ;
               
               deleteWorker.RunWorkerAsync ( new QueryState ( new MatchingParameterCollection ( ), null, -1 ) ) ;
            }

            public void ViewSelectedLogDetail ( )
            {
               try
               {
                  if ( __ServerMainView.SelectedCount == 1 ) 
                  {
                     DICOMServerEventLogDetails frmEventLogDetails ;
                     int                        currentEventIdIndex ;
                     long                       decEventID ;
                     
                     
                     frmEventLogDetails  = new DICOMServerEventLogDetails ( ) ;
                     currentEventIdIndex = __ServerMainView.SelectedIndices [ 0 ] ;
                     decEventID          = __EventLogId [ currentEventIdIndex ] ;
                     
                     frmEventLogDetails.Tag = currentEventIdIndex ;
                     
                     frmEventLogDetails.CanDisplayPrevious = CanDisplayPrevious ( currentEventIdIndex ) ;
                     frmEventLogDetails.CanDisplayNext     = CanDisplayNext     ( currentEventIdIndex ) ;

                     frmEventLogDetails.DisplayPrevious += new EventHandler(frmEventLogDetails_DisplayPrevious);
                     frmEventLogDetails.DisplayNext += new EventHandler ( OnDisplayNextLog ) ;
                     
                     frmEventLogDetails.BindData ( __DICOMServerEventLogGeneralInfoCacheDataset.DICOMServerEventLog.FindByEventID ( decEventID ) ) ;
                     
                     frmEventLogDetails.ShowDialog ( ) ;
                  }
                  else
                  {
                     return ;
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }

            void frmEventLogDetails_DisplayPrevious(object sender, EventArgs e)
            {
               DICOMServerEventLogDetails frmEventLogDetails ;
               int                        currentEventIdIndex ;
               
               
               frmEventLogDetails  = (DICOMServerEventLogDetails) sender ;
               currentEventIdIndex = (int) frmEventLogDetails.Tag ;
               
               currentEventIdIndex-- ;

               BindEvent ( frmEventLogDetails, currentEventIdIndex ) ;
            }
            
            public void OnDisplayNextLog ( object sender, EventArgs e ) 
            {
               DICOMServerEventLogDetails frmEventLogDetails ;
               int                        currentEventIdIndex ;
               
               
               frmEventLogDetails  = (DICOMServerEventLogDetails) sender ;
               currentEventIdIndex = (int) frmEventLogDetails.Tag ;
               
               currentEventIdIndex++ ;

               BindEvent ( frmEventLogDetails, currentEventIdIndex ) ;
            }

            private void BindEvent ( DICOMServerEventLogDetails frmEventLogDetails, int currentEventIdIndex )
            {
               if ( currentEventIdIndex >= 0 || currentEventIdIndex < __EventLogId.Count )
               {
                  frmEventLogDetails.BindData ( GetItemInfo ( __EventLogId [ currentEventIdIndex ] ) ) ;
                  
                  frmEventLogDetails.Tag = currentEventIdIndex ;
               }
               
               frmEventLogDetails.CanDisplayPrevious = CanDisplayPrevious ( currentEventIdIndex ) ;
               frmEventLogDetails.CanDisplayNext     = CanDisplayNext     ( currentEventIdIndex ) ;
            }

            private bool CanDisplayPrevious ( int currentEventIdIndex )
            {
               return currentEventIdIndex > 0 ;
            }

            private bool CanDisplayNext ( int currentEventIdIndex )
            {
               return currentEventIdIndex < __EventLogId.Count - 1 ;
            }

            public void RefreshQueryInfo ( )
            {
               try
               {
                  long decCurrentDICOMServerEventLogIDsCount ;
                  
                  
                  if ( null != __LastQueryState ) 
                  {
                     decCurrentDICOMServerEventLogIDsCount = __DataAccessAgent.GetDicomEventLogIdsSum ( __LastQueryState.MatchingParametersListCollection ) ;
                  }
                  else
                  {
                     decCurrentDICOMServerEventLogIDsCount = __DataAccessAgent.GetDicomEventLogIdsSum ( ) ;
                  }
                  
                  if ( decCurrentDICOMServerEventLogIDsCount != __LastDICOMServerEventLogIDsSum )
                  {
                     if ( ! __QueryPerformed )
                     {
                        QueryState                       CurrentQueryState ;
                        MatchingParameterCollection ServerMatchingParametersListCollection ;
                        OrderByParameter      ServerOrderByParam ;
                        OrderByParametersList ServerOrderParamList ;
                        
                        
                        CurrentQueryState = new QueryState ( ) ;
                        
                        ServerMatchingParametersListCollection = new MatchingParameterCollection ( ) ;
                        
                        ServerOrderByParam   = new OrderByParameter ( ) ;
                        
                        ServerOrderParamList = new OrderByParametersList ( ) ;
                        
                        
                        //ServerOrderByParam.OrderBy = OrderByParameter.OrderByOptions.ServerEventDateTime ;
                        
                        ServerOrderParamList.Add ( ServerOrderByParam ) ;
                        
                        
                        CurrentQueryState.MatchingParametersListCollection = ServerMatchingParametersListCollection ;
                        CurrentQueryState.OrderParamsList                  = ServerOrderParamList ;
                        CurrentQueryState.LastRowsCount                       = Constants.General.LastEntryNotSpcified ;
                        
                        __LastQueryState = CurrentQueryState ;
                     }
                     
                     QueryServerEventLogTable ( __LastQueryState ) ;
                  }
                  
                  __ServerMainView.QueryStateChanged  ( true ) ;
                  
                  __LastDICOMServerEventLogIDsSum = decCurrentDICOMServerEventLogIDsCount ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  __ServerMainView.QueryStateChanged  ( false ) ;
                  
                  throw exception ;
               }
            }


         #endregion
            
         #region Properties
         
            public int CurrentLogsCount
            {
               get
               {
                  if ( null != __EventLogId )
                  {
                     return __EventLogId.Count ;
                  }
                  else
                  {
                     return 0 ;
                  }
               }
            }
         
            public int SelctedLogsCount
            {
               get
               {
                  return __ServerMainView.SelectedCount ;
               }
            }
            
            
         #endregion
         
         #region Events
         
         public event EventHandler<ImportLogArgs> ImportStarting;
         
         public event EventHandler<ImportLogArgs> ImportCompleted;
         
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
         #region Callbacks
         
            public event EventHandler SelectedLogViewIndexChange ;
            public event EventHandler <RunWorkerCompletedEventArgs> DeleteCompleted ;
            
         #endregion
         
      #endregion
      
      #region Protected
         
         #region Methods
            
         #endregion
         
         #region Properties
            
         #endregion
         
         #region Events
            
         #endregion
         
         #region Data Members
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
      #endregion
      
      #region Private
         
         #region Methods
         
            private void Init ( DICOMServerMain ctlServerMainView )
            {
               try
               {
                  __ServerMainView = ctlServerMainView ;
                  
                  __DICOMServerEventLogGeneralInfoCacheDataset = new DicomEventLogDataSet ( ) ;
                  
                  __ListViewFormatter  = new DICOMServerEventLogListviewFormatter ( ) ;
                  
                  InitEventLogTableColumnFiledFullPathDataSet ( ) ;
                  
                  InsertViewColumns ( ) ;
                  
                  FillViewLogType ( ) ;
               
                  FillViewLogCommand ( ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }

            private void RegisterEvents ( )
            {
               try
               {
                  __ServerMainView.LogsViewColumnClicked      += new System.Windows.Forms.ColumnClickEventHandler ( ServerMainView_LogsColumnClicked ) ;
                  __ServerMainView.LogsViewColumnContextMenu  += new Leadtools.Medical.Winforms.Control.VirtualListView.ColumnContextMenuHandler ( ServerMainView_LogsColumnContextMenu ) ;
                  __ServerMainView.SelectedLogViewIndexChange += new EventHandler ( ServerMainView_SelectedLogViewIndexChange ) ;
                  __ServerMainView.RetrieveListViewItem       += new EventHandler<RetrieveVirtualItemEventArgs> ( __ServerMainView_RetrieveListViewItem ) ;

                  _bw.WorkerSupportsCancellation = true;
                  _bw.WorkerReportsProgress = false;
                  _bw.DoWork += new DoWorkEventHandler(_bw_DoWork);
                  _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }

            void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
               ImportLogArgs args = e.Result as ImportLogArgs;
                           
               bool cancelled = _cancelImport;
               if (cancelled)
               {
                  __ServerMainView.ServerLogsCount = 0;
                  __EventLogId.Clear();
                  args.Cancelled = true;
                  OnImportCompleted(args);
                  return;
               }
               
               if (string.IsNullOrEmpty(args.ErrorMessage))
               {
                  __ServerMainView.ServerLogsCount = __EventLogId.Count;
                  // __ServerMainView.ScrollToEnd();

                  // Sort the ids
                  __EventLogId.Sort();

                  if (args.LastRowsCount != -1)
                  {
                     // Keep the last LastRowsCount
                     int nCount = __EventLogId.Count;
                     int nMax = args.LastRowsCount;
                     if (nCount > nMax)
                     {
                        __EventLogId.RemoveRange(0, nCount - nMax);
                        __ServerMainView.ServerLogsCount = __EventLogId.Count;
                     }
                  }

                  foreach (ColumnHeader column in __ServerMainView.VirtualListColumns)
                  {
                     column.Width = -2;
                  }

                  __ServerMainView.QueryStateChanged(true);

                  __LastQueryState = args.CurrentQueryState as QueryState;
                  __ImportLogActive = true;
               }
               else
               {
                  __ServerMainView.ServerLogsCount = 0;
                  __EventLogId.Clear();

                  MessageBox.Show(args.ErrorMessage,
                               Constants.Messages.MessageBox.ErrorCaption,
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
               }
               
               OnImportCompleted(args);
            }


            void _bw_DoWork(object sender, DoWorkEventArgs e)
            {
               BackgroundWorker bw = sender as BackgroundWorker;
               ImportLogArgs args = e.Argument as ImportLogArgs;
               e.Result = args;

               foreach (string s in args.Files)
               {
                  if (bw.CancellationPending == true)
                  {
                     break;
                  }
                  else
                  {
                     if (!ParseOneFile(s, args.MatchingParameters, args.LastRowsCount))
                     {
                        args.ErrorMessage = string.Format(Constants.Messages.MessageBox.ImportLogError, s);
                        break;
                     }
                  }
               }

               //if (bw.CancellationPending == true)
               //{
               //   e.Cancel = true;
               //}
            }

            private void InitEventLogTableColumnFiledFullPathDataSet ( )
            {
               try
               {
                  __EventLogTableColumnFiledFullPathDataSet = new DataSet ( ) ;
                  
                  __EventLogTableColumnFiledFullPathDataSet.ReadXml ( Assembly.GetExecutingAssembly ( ).GetManifestResourceStream ( Constants.Resources.XML.EventLogTableColumnFiledFullPath ) ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private void InsertViewColumns ( )
            {
               try
               {
                  ICatalog   catalog ;
                  string [ ] tables ;

                  catalog = CatalogFactory.GetInstance(new LoggingDataAccessConfigurationView(DicomDemoSettingsManager.GetGlobalPacsConfiguration(), PacsProduct.ProductName, PacsProduct.ServiceName)).CreateCatalog();
                  tables  = catalog.GetEntities ( ) ; 
                  
                  if ( tables.Length != 1 )
                  {
                     System.Diagnostics.Debug.Assert ( false ) ;
                     
                     return ;
                  }
                  
                  foreach ( DataRow fieledFullPathDataRow in __EventLogTableColumnFiledFullPathDataSet.Tables [ Constants.ResInfo.EventLogTableColumnFiledFullPathTable.TableName ].Rows )
                  {
                     VirtualListViewColumn vlstcolServerLog ; 
                     ColumnHeader          listViewColumn ;
                     string                strColumnFieldValue ;
                     
                     
                     vlstcolServerLog = new VirtualListViewColumn ( ) ;
                     listViewColumn   = new ColumnHeader ( ) ;
                     
                     strColumnFieldValue = fieledFullPathDataRow [ Constants.ResInfo.EventLogTableColumnFiledFullPathTable.ColumnFieldFullPathName ].ToString ( ) ;
                     
                     __ServerMainView.VirtualListColumns.Add ( listViewColumn ) ;
                     
                     listViewColumn.Text  = catalog.GetEntityElementDisplayName ( tables [ 0 ], strColumnFieldValue ) ;
                     listViewColumn.Width = -2 ;
                     listViewColumn.Tag   = catalog.GetEntityElementName ( tables [ 0 ], strColumnFieldValue ) ;
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private void FillViewLogType ( ) 
            {
               try
               {
                  __ServerMainView.TypeDataSource = Enum.GetNames ( typeof ( LogType ) ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private void FillViewLogCommand ( ) 
            {
               try
               {
                  __ServerMainView.CommandDataSource = Enum.GetNames ( typeof ( DicomCommandType ) ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            private void SortColumnImportedLogs(OrderByParameter sortColumnOrderType)
            {
               int retVal = 0;
               switch (sortColumnOrderType.OrderBy)
               {
                  case OrderByParameter.OrderByOptions.ClientAETitle:
                     __EventLogId.Sort(delegate(long id0, long id1)
                        {
                           DicomEventLogDataSet.DICOMServerEventLogRow row0 = __DICOMServerEventLogGeneralInfoCacheDataset.DICOMServerEventLog.FindByEventID(id0);
                           DicomEventLogDataSet.DICOMServerEventLogRow row1 = __DICOMServerEventLogGeneralInfoCacheDataset.DICOMServerEventLog.FindByEventID(id1);

                           retVal = string.Compare(row0.ClientAETitle, row1.ClientAETitle);
                           if (sortColumnOrderType.Ascending == false)
                              retVal *= -1;
                           return retVal;
                        }
                     );
                     break;

                  case OrderByParameter.OrderByOptions.ClientHostAddress:
                     __EventLogId.Sort(delegate(long id0, long id1)
                        {
                           DicomEventLogDataSet.DICOMServerEventLogRow row0 = __DICOMServerEventLogGeneralInfoCacheDataset.DICOMServerEventLog.FindByEventID(id0);
                           DicomEventLogDataSet.DICOMServerEventLogRow row1 = __DICOMServerEventLogGeneralInfoCacheDataset.DICOMServerEventLog.FindByEventID(id1);

                           retVal =  string.Compare(row0.ClientHostAddress, row1.ClientHostAddress);
                           if (sortColumnOrderType.Ascending == false)
                              retVal *= -1;
                           return retVal;
                        }
                     );
                     break;

                  case OrderByParameter.OrderByOptions.ClientPort:
                     __EventLogId.Sort(delegate(long id0, long id1)
                        {
                           DicomEventLogDataSet.DICOMServerEventLogRow row0 = __DICOMServerEventLogGeneralInfoCacheDataset.DICOMServerEventLog.FindByEventID(id0);
                           DicomEventLogDataSet.DICOMServerEventLogRow row1 = __DICOMServerEventLogGeneralInfoCacheDataset.DICOMServerEventLog.FindByEventID(id1);

                           retVal =   row0.ClientPort.CompareTo(row1.ClientPort);
                           if (sortColumnOrderType.Ascending == false)
                              retVal *= -1;
                           return retVal;
                        }
                     );
                     break;

                  case OrderByParameter.OrderByOptions.Command:
                     __EventLogId.Sort(delegate(long id0, long id1)
                        {
                           DicomEventLogDataSet.DICOMServerEventLogRow row0 = __DICOMServerEventLogGeneralInfoCacheDataset.DICOMServerEventLog.FindByEventID(id0);
                           DicomEventLogDataSet.DICOMServerEventLogRow row1 = __DICOMServerEventLogGeneralInfoCacheDataset.DICOMServerEventLog.FindByEventID(id1);

                           retVal =  string.Compare(row0.Command, row1.Command);
                           if (sortColumnOrderType.Ascending == false)
                              retVal *= -1;
                           return retVal;
                        }
                     );
                     break;

                  case OrderByParameter.OrderByOptions.Description:
                     __EventLogId.Sort(delegate(long id0, long id1)
                        {
                           DicomEventLogDataSet.DICOMServerEventLogRow row0 = __DICOMServerEventLogGeneralInfoCacheDataset.DICOMServerEventLog.FindByEventID(id0);
                           DicomEventLogDataSet.DICOMServerEventLogRow row1 = __DICOMServerEventLogGeneralInfoCacheDataset.DICOMServerEventLog.FindByEventID(id1);

                           retVal =  string.Compare(row0.Description, row1.Description);
                           if (sortColumnOrderType.Ascending == false)
                              retVal *= -1;
                           return retVal;
                        }
                     );
                     break;

                  case OrderByParameter.OrderByOptions.EventType:
                     __EventLogId.Sort(delegate(long id0, long id1)
                        {
                           DicomEventLogDataSet.DICOMServerEventLogRow row0 = __DICOMServerEventLogGeneralInfoCacheDataset.DICOMServerEventLog.FindByEventID(id0);
                           DicomEventLogDataSet.DICOMServerEventLogRow row1 = __DICOMServerEventLogGeneralInfoCacheDataset.DICOMServerEventLog.FindByEventID(id1);

                           retVal =  string.Compare(row0.Type, row1.Type);
                           if (sortColumnOrderType.Ascending == false)
                              retVal *= -1;
                           return retVal;
                        }
                     );
                     break;

                  case OrderByParameter.OrderByOptions.Invalid:
                     break;

                  case OrderByParameter.OrderByOptions.MessageDirection:
                     __EventLogId.Sort(delegate(long id0, long id1)
                        {
                           DicomEventLogDataSet.DICOMServerEventLogRow row0 = __DICOMServerEventLogGeneralInfoCacheDataset.DICOMServerEventLog.FindByEventID(id0);
                           DicomEventLogDataSet.DICOMServerEventLogRow row1 = __DICOMServerEventLogGeneralInfoCacheDataset.DICOMServerEventLog.FindByEventID(id1);

                           retVal =  string.Compare(row0.MessageDirection, row1.MessageDirection);
                           if (sortColumnOrderType.Ascending == false)
                              retVal *= -1;
                              return retVal;
                        }
                     );
                     break;

                  case OrderByParameter.OrderByOptions.ServerAETitle:
                     __EventLogId.Sort(delegate(long id0, long id1)
                        {
                           DicomEventLogDataSet.DICOMServerEventLogRow row0 = __DICOMServerEventLogGeneralInfoCacheDataset.DICOMServerEventLog.FindByEventID(id0);
                           DicomEventLogDataSet.DICOMServerEventLogRow row1 = __DICOMServerEventLogGeneralInfoCacheDataset.DICOMServerEventLog.FindByEventID(id1);

                           retVal =  string.Compare(row0.ServerAETitle, row1.ServerAETitle);
                           if (sortColumnOrderType.Ascending == false)
                              retVal *= -1;
                           return retVal;
                        }
                     );
                     break;

                  case OrderByParameter.OrderByOptions.ServerEventDateTime:
                      __EventLogId.Sort(delegate(long id0, long id1)
                        {
                           DicomEventLogDataSet.DICOMServerEventLogRow row0 = __DICOMServerEventLogGeneralInfoCacheDataset.DICOMServerEventLog.FindByEventID(id0);
                           DicomEventLogDataSet.DICOMServerEventLogRow row1 = __DICOMServerEventLogGeneralInfoCacheDataset.DICOMServerEventLog.FindByEventID(id1);

                           retVal =  row0.EventDateTime.CompareTo(row1.EventDateTime);
                           if (sortColumnOrderType.Ascending == false)
                              retVal *= -1;
                           return retVal;
                        }
                     );
                     break;

                  case OrderByParameter.OrderByOptions.ServerIPAddress:
                     __EventLogId.Sort(delegate(long id0, long id1)
                        {
                           DicomEventLogDataSet.DICOMServerEventLogRow row0 = __DICOMServerEventLogGeneralInfoCacheDataset.DICOMServerEventLog.FindByEventID(id0);
                           DicomEventLogDataSet.DICOMServerEventLogRow row1 = __DICOMServerEventLogGeneralInfoCacheDataset.DICOMServerEventLog.FindByEventID(id1);

                           retVal =  string.Compare(row0.ServerIPAddress, row1.ServerIPAddress);
                           if (sortColumnOrderType.Ascending == false)
                              retVal *= -1;
                           return retVal;
                        }
                     );
                     break;

                  case OrderByParameter.OrderByOptions.ServerPort:
                     __EventLogId.Sort(delegate(long id0, long id1)
                        {
                           DicomEventLogDataSet.DICOMServerEventLogRow row0 = __DICOMServerEventLogGeneralInfoCacheDataset.DICOMServerEventLog.FindByEventID(id0);
                           DicomEventLogDataSet.DICOMServerEventLogRow row1 = __DICOMServerEventLogGeneralInfoCacheDataset.DICOMServerEventLog.FindByEventID(id1);

                           retVal =  row0.ServerPort.CompareTo(row1.ServerPort);
                           if (sortColumnOrderType.Ascending == false)
                              retVal *= -1;
                           return retVal;
                        }
                     );
                     break;
               }
            }
            
            
            private void SortColumn ( int nColumnIndex )
            {
               try
               {
                  string                          strColumnName ;   
                  OrderByParameter.OrderByOptions order ;
                  OrderByParameter                sortColumnOrderType ;
                  QueryState                      sortingQueryState ;
                  OrderByParametersList           serverOrderByParametersList ;
                  
                  
                  strColumnName = (string) __ServerMainView.VirtualListColumns [ nColumnIndex ].Tag ;
                  order         = GetOrderByOptions ( strColumnName ) ;
                  
                  if ( order == OrderByParameter.OrderByOptions.Invalid ) 
                  {
                     return ;
                  }
                  
                  sortColumnOrderType = new OrderByParameter ( ) ; 
                  
                  sortingQueryState = new QueryState ( ) ;
                  
                  serverOrderByParametersList = new OrderByParametersList ( ) ;
                  
                  sortColumnOrderType.OrderBy = order ;
                  
                  foreach ( OrderByParameter orderByParameter in __LastQueryState.OrderParamsList )
                  {
                     if ( orderByParameter.OrderBy == sortColumnOrderType.OrderBy )
                     {
                        sortColumnOrderType.Ascending = ! orderByParameter.Ascending ;
                        
                        break ;
                     } 
                  }
                  
                  serverOrderByParametersList.Add ( sortColumnOrderType ) ;
                  
                  sortingQueryState.OrderParamsList                  = serverOrderByParametersList ;
                  sortingQueryState.LastRowsCount                       = __LastQueryState.LastRowsCount ;
                  sortingQueryState.MatchingParametersListCollection = __LastQueryState.MatchingParametersListCollection ;

                  if (__ImportLogActive)
                  {
                     SortColumnImportedLogs(sortColumnOrderType);
                     this.__ServerMainView.RedrawItems();
                     // __DICOMServerEventLogGeneralInfoCacheDataset.Clear ( ) ;
                  }
                  else
                  {
                     QueryServerEventLogTable(sortingQueryState);
                  }
                  
                  __LastQueryState = sortingQueryState ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private OrderByParameter.OrderByOptions GetOrderByOptions 
            ( 
               string strColumnName 
            )
            {
               try
               {
                  foreach ( DataRow FiledFullPathDataRow  in __EventLogTableColumnFiledFullPathDataSet.Tables [ Constants.ResInfo.EventLogTableColumnFiledFullPathTable.TableName ].Rows )
                  {
                     string strColumnFieldValue ;
                     
                     
                     strColumnFieldValue = FiledFullPathDataRow [ Constants.ResInfo.EventLogTableColumnFiledFullPathTable.ColumnFieldFullPathName ].ToString ( ) ;   
                     
                     if ( strColumnFieldValue == strColumnName ) 
                     {
                        string strColumnFieldRelatedOrderByOption ;
                        
                        
                        strColumnFieldRelatedOrderByOption = FiledFullPathDataRow  [ Constants.ResInfo.EventLogTableColumnFiledFullPathTable.ColumnFieldRelatedOrderByOption ].ToString ( ) ;
                        
                        return ( OrderByParameter.OrderByOptions ) Enum.Parse ( typeof ( OrderByParameter.OrderByOptions ),
                                                                                        strColumnFieldRelatedOrderByOption ) ;
                     }
                  } 
                  
                  throw new Exception ( Constants.Messages.Exception.ColumnNameNotFound ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private void WriteEventInfo
            (
               long eventId, 
               StreamWriter FileStreamWriter,
               DICOMServerEventLogFormatter ServerEventLogFormsFormatter
            )
            {
               try
               {
                  DicomEventLogDataSet                        currentDICOMServerEventItemInfoDataset ;
                  DicomEventLogDataSet.DICOMServerEventLogRow currentDICOMServerEventItemInfo ;
                  
                  
                  currentDICOMServerEventItemInfoDataset = CreateEventLogDataset ( __DataAccessAgent.FindDicomEventLog ( eventId, false ), eventId, out currentDICOMServerEventItemInfo ) ;
                                                                                                               
                  EventLogWriter.WriteEventLog ( currentDICOMServerEventItemInfo, FileStreamWriter, ServerEventLogFormsFormatter, false, string.Empty ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                              
                  throw exception ;
               }
            }
            
            
            private void DisplayDICOMServerHeaderContextMenu 
            ( 
               System.Drawing.Point MousePosition 
            )
            {
               try
               {
                  ContextMenu cmnuDICOMServerMenu ;
                        
                        
                  cmnuDICOMServerMenu = new ContextMenu ( ) ;
                        
                  foreach ( ColumnHeader ServerColumn in __ServerMainView.VirtualListColumns )
                  {
                     MenuItem ServerMenuItem ;
                     bool     fChecked = false ;
                           
                           
                     ServerMenuItem = new MenuItem ( ServerColumn.Text ) ;
                           
                     if ( ServerColumn.Width != 0 )
                     {
                        fChecked = true ;
                     }
                           
                     ServerMenuItem.Checked = fChecked ;
                           
                     ServerMenuItem.Click += new EventHandler ( ServerMenuItem_Click ) ;
                           
                     cmnuDICOMServerMenu.MenuItems.Add ( ServerMenuItem ) ;
                  }
                        
                  cmnuDICOMServerMenu.Show ( __ServerMainView, MousePosition ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                        
                  throw exception ;
               }
            }
            
            
            private void OnServerMenuItemChecked ( MenuItem mnuiServerLogs )
            {
               try
               {
                  mnuiServerLogs.Checked = ! mnuiServerLogs.Checked ;
                        
                  foreach ( ColumnHeader ctlServerColumn in __ServerMainView.VirtualListColumns )
                  {
                     if ( ctlServerColumn.Text == mnuiServerLogs.Text ) 
                     {
                        if ( mnuiServerLogs.Checked )
                        {
                           ctlServerColumn.Width = -1 ;
                        }
                        else
                        {
                           ctlServerColumn.Width = 0 ;
                        }
                     }   
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                        
                  throw exception ;
               }
                     
            }
                  
                  
                  
            private void OnSelectedLogViewIndexChange ( )
            {
               try
               {
                  if ( null != SelectedLogViewIndexChange ) 
                  {
                     SelectedLogViewIndexChange ( this,
                                                  new EventArgs ( ) ) ;
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
                  
                  
            private void FillGeneralMatchingParams
            (
               DICOMServerEventLogMatchingParameters serverEventLogEntity
            )
            {
               try
               {
                  DICOMServerQuery.QueryFilterType CurrentFilterType ;
                  
                  
                  CurrentFilterType = __ServerMainView.SelectedQueryFilter ;
                  
                  if ( ( DICOMServerQuery.QueryFilterType.Type & CurrentFilterType ) != 0 )
                  {
                     serverEventLogEntity.Type = __ServerMainView.Type.Replace ( Constants.SpecialCharacters.QueryFieldSeparator, SqlProviderUtilities.MatchingValueSeparator ) ;
                  }
                  
                  if ( ( DICOMServerQuery.QueryFilterType.Command & CurrentFilterType ) != 0 )
                  {
                     serverEventLogEntity.Command = __ServerMainView.Command.Replace ( Constants.SpecialCharacters.QueryFieldSeparator, SqlProviderUtilities.MatchingValueSeparator ) ;
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            
            private void FillDateRangeMatchingParams 
            ( 
               DICOMServerEventLogMatchingParameters serverEventLogEntity
            )
            {
               try
               {
                  DICOMServerQuery.QueryFilterType CurrentFilterType ;
                  
                  
                  CurrentFilterType = __ServerMainView.SelectedQueryFilter ;
                  
                  if ( ( DICOMServerQuery.QueryFilterType.Date & CurrentFilterType ) != 0 )
                  {
                     if ( ( DICOMServerQuery.QueryFilterType.DateMonths & CurrentFilterType ) != 0 )
                     {
                        DateTime  FirstDateMatching ;
                        
                        
                        FirstDateMatching = SubtractMonths ( DateTime.Now,
                                                             Convert.ToInt32 ( __ServerMainView.DateMonths ) ) ;
                                                             
                        serverEventLogEntity.EventDateTime.StartDate = FirstDateMatching ;
                     }
                     
                     if ( ( DICOMServerQuery.QueryFilterType.DateDays & CurrentFilterType ) != 0 )
                     {
                        TimeSpan  SubtractionDays ;
                        
                        
                        SubtractionDays = new TimeSpan ( Convert.ToInt32 ( __ServerMainView.DateDays ),
                                                         DateTime.Now.Hour,
                                                         DateTime.Now.Minute,
                                                         DateTime.Now.Second,
                                                         DateTime.Now.Millisecond ) ;
                                                         
                        serverEventLogEntity.EventDateTime.StartDate = DateTime.Now.Subtract ( SubtractionDays ) ;
                     }
                     
                     
                     if ( ( DICOMServerQuery.QueryFilterType.DateRange & CurrentFilterType ) != 0 )
                     {
                        serverEventLogEntity.EventDateTime.StartDate = ( String.IsNullOrEmpty (__ServerMainView.DateRangeFrom ) ) ? DateTime.MinValue : DateTime.Parse ( __ServerMainView.DateRangeFrom ) ;
                        serverEventLogEntity.EventDateTime.EndDate   = ( String.IsNullOrEmpty (__ServerMainView.DateRangeTo ) ) ? DateTime.MaxValue : DateTime.Parse ( __ServerMainView.DateRangeTo ) ;
                     }
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            
            private void FillClientsMatchingParams   
            ( 
               DICOMServerEventLogMatchingParameters serverEventLogEntity
            )
            {
               try
               {
                  DICOMServerQuery.QueryFilterType CurrentFilterType ;
                  
                  
                  CurrentFilterType = __ServerMainView.SelectedQueryFilter ;

                  if ( ( DICOMServerQuery.QueryFilterType.ClientAETitle & CurrentFilterType ) != 0 )
                  {
                     serverEventLogEntity.ClientAETitle = __ServerMainView.ClientAETitle.Replace ( Constants.SpecialCharacters.QueryFieldSeparator, SqlProviderUtilities.MatchingValueSeparator ) ;
                  }
                  
                  if ( ( DICOMServerQuery.QueryFilterType.ClientHostAddress & CurrentFilterType ) != 0 )
                  {
                     serverEventLogEntity.ClientHostAddress = __ServerMainView.ClientHostAddress.Replace ( Constants.SpecialCharacters.QueryFieldSeparator, SqlProviderUtilities.MatchingValueSeparator ) ;
                  }
                  
                  
                  if ( ( DICOMServerQuery.QueryFilterType.ClientPort & CurrentFilterType ) != 0 )
                  {
                     serverEventLogEntity.ClientPort = __ServerMainView.ClientPort.Replace ( Constants.SpecialCharacters.QueryFieldSeparator, SqlProviderUtilities.MatchingValueSeparator ) ;
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            
            private void FillServerMatchingParams 
            (  
               DICOMServerEventLogMatchingParameters serverEventLogEntity
            )
            {
               try
               {
                  DICOMServerQuery.QueryFilterType CurrentFilterType ;
                  
                  
                  CurrentFilterType = __ServerMainView.SelectedQueryFilter ;     
                  
                  if ( ( DICOMServerQuery.QueryFilterType.ServerAETitle & CurrentFilterType ) != 0 )
                  {
                     serverEventLogEntity.ServerAETitle = __ServerMainView.ServerAETitle.Replace ( Constants.SpecialCharacters.QueryFieldSeparator, SqlProviderUtilities.MatchingValueSeparator ) ;
                  }
                  
                  if ( ( DICOMServerQuery.QueryFilterType.ServerIPAddress & CurrentFilterType ) != 0 )
                  {
                     serverEventLogEntity.ServerIPAddress = __ServerMainView.ServerIPAddress.Replace ( Constants.SpecialCharacters.QueryFieldSeparator, SqlProviderUtilities.MatchingValueSeparator ) ;
                  }
                  
                  
                  if ( ( DICOMServerQuery.QueryFilterType.ServerPort & CurrentFilterType ) != 0 )
                  {
                     serverEventLogEntity.ServerPort = __ServerMainView.ServerPort.Replace ( Constants.SpecialCharacters.QueryFieldSeparator, SqlProviderUtilities.MatchingValueSeparator ) ;
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
               
            
            bool _updateColumns = true ;
            
            private void QueryServerEventLogTable
            ( 
               QueryState RequestedQueryState
            )
            {
               try
               {
                  __EventLogId = new List <long> ( __DataAccessAgent.QueryDicomEventLogID ( RequestedQueryState.MatchingParametersListCollection,
                                                                                                     RequestedQueryState.OrderParamsList,
                                                                                                     RequestedQueryState.LastRowsCount ) ) ;

                  __ServerMainView.ServerLogsCount = 0 ;
                  __ServerMainView.ServerLogsCount = __EventLogId.Count ;
                  __ServerMainView.ScrollToEnd ( ) ;
                  
                  
                  if ( _updateColumns ) 
                  {
                     foreach ( ColumnHeader column in __ServerMainView.VirtualListColumns )
                     {
                        column.Width = -2 ;
                     }
                     
                     _updateColumns = false ;
                  }
                  
                  __DICOMServerEventLogGeneralInfoCacheDataset.Clear ( ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                  
                  throw exception ;
               }
            }
            
            
            private DateTime SubtractMonths 
            ( 
               DateTime CurrentDateTime,
               int nMonths
            )
            {
               try
               {
                  DateTime ResultDateTime ;
                  
                  
                  
                  ResultDateTime = CurrentDateTime ;
               
                  for ( int nSubMonths = nMonths; nSubMonths > 0 ; nSubMonths-- ) 
                  {
                     TimeSpan SubtactionTimeSpan ;
                     
                     
                     SubtactionTimeSpan = new TimeSpan ( ResultDateTime.Day, 
                                                         ResultDateTime.Hour, 
                                                         ResultDateTime.Minute, 
                                                         ResultDateTime.Second, 
                                                         ResultDateTime.Millisecond ) ;
                     
                     ResultDateTime = ResultDateTime.Subtract ( SubtactionTimeSpan ) ; 
                  }
                  
                  
                  return ResultDateTime.Subtract ( new TimeSpan ( ResultDateTime.Day - CurrentDateTime.Day, 
                                                                  ResultDateTime.Hour, 
                                                                  ResultDateTime.Minute, 
                                                                  ResultDateTime.Second, 
                                                                  ResultDateTime.Millisecond ) ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            
            private DicomEventLogDataSet.DICOMServerEventLogRow GetItemInfo 
            ( 
               long decEventId 
            )
            {
               try
               {
                  DicomEventLogDataSet.DICOMServerEventLogRow returnLogRow ;
                  
                  
                  returnLogRow = __DICOMServerEventLogGeneralInfoCacheDataset.DICOMServerEventLog.FindByEventID ( decEventId ) ;
                  
                  if ( null != returnLogRow )
                  {
                     return returnLogRow ;
                  }
                  else
                  {
                     if ( __DICOMServerEventLogGeneralInfoCacheDataset.DICOMServerEventLog.Rows.Count == Constants.General.CacheTableMaxSize )
                     {
                        __DICOMServerEventLogGeneralInfoCacheDataset.DICOMServerEventLog.RemoveDICOMServerEventLogRow ( ( DicomEventLogDataSet.DICOMServerEventLogRow ) __DICOMServerEventLogGeneralInfoCacheDataset.DICOMServerEventLog.Rows [ 0 ] ) ;
                     }


                     returnLogRow = CreateEventLogRow ( __DICOMServerEventLogGeneralInfoCacheDataset, __DataAccessAgent.FindDicomEventLog ( decEventId, false ), decEventId  ) ;
                     
                     return returnLogRow ;
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private DialogResult ShowDeleteRowFailedMessage ( string strMessage )
            {
               try
               {
                  DeleteRowFailedDialog DeleteRowDlg ;
                  
                  
                  DeleteRowDlg = new DeleteRowFailedDialog ( ) ;
                  
                  DeleteRowDlg.DetailsMessage = strMessage ;
                  DeleteRowDlg.Text           = Constants.Messages.MessageBox.ErrorCaption ;
                  
                  return DeleteRowDlg.ShowDialog ( ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            private DicomEventLogDataSet CreateEventLogDataset
            (
               DicomLogEntry serverLogEntry,
               long eventId,
               out DicomEventLogDataSet.DICOMServerEventLogRow eventLogDataRow
            )
            {
               try
               {
                  DicomEventLogDataSet eventLogDataset ;
                  
                  
                  eventLogDataset = new DicomEventLogDataSet ( ) ; 
                  
                  
                  eventLogDataRow = CreateEventLogRow ( eventLogDataset, serverLogEntry, eventId ) ;
                  
                  return eventLogDataset ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.ToString ( ) ) ;
                  
                  throw ;
               }
            }
            
            private DicomEventLogDataSet.DICOMServerEventLogRow CreateEventLogRow
            (
               DicomEventLogDataSet eventLogDataset,
               DicomLogEntry serverLogEntry,
               long eventId
            )
            {
               try
               {
                  DicomEventLogDataSet.DICOMServerEventLogRow eventLogDataRow ;
                  
                  
                  eventLogDataRow = null ;
                  
                  if ( null == serverLogEntry )
                  {
                     return eventLogDataRow ; 
                  }
                  
                  eventLogDataRow = eventLogDataset.DICOMServerEventLog.NewDICOMServerEventLogRow ( ) ;
                  
                  CopyGeneralServerLogEntryIntoServerLogRow ( serverLogEntry, 
                                                              eventLogDataset,
                                                              eventLogDataRow,
                                                              eventId ) ;
                  
                  eventLogDataset.DICOMServerEventLog.Rows.Add ( eventLogDataRow ) ;
                  
                  return eventLogDataRow ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.ToString ( ) ) ;
                  
                  throw ;
               }
            }
            
            private void CopyGeneralServerLogEntryIntoServerLogRow
            ( 
               DicomLogEntry serverLogEntry, 
               DicomEventLogDataSet eventLogDataset,
               DicomEventLogDataSet.DICOMServerEventLogRow eventLogDataRow,
               long eventId
            )
            {
               try
               {
                  eventLogDataRow.EventID           = eventId ;
                  eventLogDataRow.ServerAETitle     = serverLogEntry.ServerAETitle ;
                  eventLogDataRow.ServerIPAddress   = serverLogEntry.ServerIPAddress ;
                  eventLogDataRow.ServerPort        = serverLogEntry.ServerPort ;
                  eventLogDataRow.ClientAETitle     = serverLogEntry.ClientAETitle ;
                  eventLogDataRow.ClientHostAddress = serverLogEntry.ClientIPAddress ;
                  eventLogDataRow.ClientPort        = serverLogEntry.ClientPort ;
                  eventLogDataRow.Command           = serverLogEntry.Command.ToString ( ) ;
                  eventLogDataRow.EventDateTime     = serverLogEntry.TimeStamp ;
                  eventLogDataRow.Type              = serverLogEntry.LogType.ToString ( ) ;
                  eventLogDataRow.MessageDirection  = serverLogEntry.MessageDirection.ToString ( ) ;
                  eventLogDataRow.Description       = serverLogEntry.Description ;
                  
                  if ( null != serverLogEntry.DicomDataset ) 
                  {
                     eventLogDataRow.Dataset = DatasetServices.GetDICOMDataSetStream ( serverLogEntry.DicomDataset ) ;
                  }
                  
                  if ( null != serverLogEntry.CustomInformation ) 
                  {
                     object dataSetPath ;
                     
                     eventLogDataRow.CustomInformation = SerializeCustomInformation ( serverLogEntry.CustomInformation ) ;
                     
                     if ( serverLogEntry.CustomInformation.TryGetValue ( eventLogDataset.DICOMServerEventLog.DatasetPathColumn.ColumnName, 
                                                                         out dataSetPath ) )
                     {
                        eventLogDataRow.DatasetPath = dataSetPath as string ;
                     }
                  }
                  
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            private string SerializeCustomInformation (  SerializableDictionary <string, object> customInformation ) 
            {
               XmlSerializer serializer ;
               MemoryStream  stream ;
               
               
               serializer = new XmlSerializer ( typeof ( SerializableDictionary <string, object> ) ) ;
               stream     = new MemoryStream  ( ) ;
               
               try
               {
                  serializer.Serialize ( stream, customInformation ) ;
                  
                  return UTF8Encoding.UTF8.GetString (  stream.ToArray ( ) ) ;
               }
               catch ( Exception ) 
               {
                  return null ;
               }
            }
            
         #endregion
         
         #region Properties
         
            private DICOMServerMain __ServerMainView
            {
               get
               {
                  return m_ctlServerMainView ;
               }
            
               set 
               {
                  m_ctlServerMainView = value ;
               }
            }
            
            
            private DICOMServerViewController.QueryState __LastQueryState
            {
               get
               {
                  return m_LastQueryState ;
               }
               
               set
               {
                  m_LastQueryState =  value ;
               }
            }
            
            
            private List <long> __EventLogId
            {
               get
               {
                  return m_eventLogId ;
               }
            
               set 
               {
                  m_eventLogId = value ;
               }
            } 
            
            
            private DataSet __EventLogTableColumnFiledFullPathDataSet
            {
               get
               {
                  return m_EventLogTableColumnFiledFullPathDataSet ;
               }
               
               
               set
               {
                  m_EventLogTableColumnFiledFullPathDataSet = value ;
               }
            }
            
            
            private bool __QueryPerformed
            {
               get
               {
                  return m_QueryPerformed ;
               }
            
               set 
               {
                  m_QueryPerformed = value ;
               }
            }
            
            
            private ILoggingDataAccessAgent2 __DataAccessAgent
            {
               get
               {
                  if ( null == m_DataAccessAgent )
                  {
                     if ( !DataAccessServices.IsDataAccessServiceRegistered <ILoggingDataAccessAgent2> ( ) )
                     {
                        m_DataAccessAgent = DataAccessFactory.GetInstance(new LoggingDataAccessConfigurationView(DicomDemoSettingsManager.GetGlobalPacsConfiguration(), PacsProduct.ProductName, PacsProduct.ServiceName)).CreateDataAccessAgent<ILoggingDataAccessAgent2>();
                        
                        DataAccessServices.RegisterDataAccessService <ILoggingDataAccessAgent2> ( m_DataAccessAgent ) ;
                     }
                     else
                     {
                        m_DataAccessAgent = DataAccessServices.GetDataAccessService <ILoggingDataAccessAgent2> ( ) ;
                     }
                  }
                  
                  return m_DataAccessAgent ;
               }
            }
            
            
            private DicomEventLogDataSet __DICOMServerEventLogGeneralInfoCacheDataset
            {
               get
               {
                  return m_DICOMServerEventLogGeneralInfoCacheDataset ;
               }
            
               set
               {
                  m_DICOMServerEventLogGeneralInfoCacheDataset = value ;
               }
            }
            
            
            private long __LastDICOMServerEventLogIDsSum
            {
               get
               {
                  return m_decLasttDICOMServerEventLogIDsSum ;
               }
               
               set
               {
                  m_decLasttDICOMServerEventLogIDsSum = value ;
               }
            }
            
            
            
            private DICOMServerEventLogListviewFormatter  __ListViewFormatter
            {
               get
               {
                  return m_ListViewFormatter ;
               }
            
               set
               {
                  m_ListViewFormatter = value ;
               }
            }
            
            private bool __ImportLogActive
            {
               get
               {
                  return m_ImportLogActive;
               }
               set
               {
                  m_ImportLogActive = value;
               }
            }
            
            private BackgroundWorker _bw = new BackgroundWorker();
            
            private volatile bool _cancelImport = false;

            
         #endregion
         
         #region Events
         
            private void ServerMainView_LogsColumnClicked
            (
               object sender, 
               System.Windows.Forms.ColumnClickEventArgs e
            )
            {
               try
               {
                  Cursor.Current = Cursors.WaitCursor ;
                  
                  SortColumn ( e.Column ) ;
               }
               catch
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
               }
               finally
               {
                  Cursor.Current = Cursors.Default ;
               }
            }
            
            
            private void ServerMenuItem_Click
            (
               object sender, 
               EventArgs e
            )
            {
               try
               {
                  OnServerMenuItemChecked ( ( MenuItem ) sender ) ;
               }
               catch
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
               }
            }
            
            
            private void ServerMainView_LogsColumnContextMenu
            (
               object sender, 
               Leadtools.Medical.Winforms.Control.VirtualListView.HeaderContextMenuEventArgs e
            )
            {
               try
               {
                  DisplayDICOMServerHeaderContextMenu ( e.MousePosition ) ;
               }
               catch
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
               }
            }
            
            
            private void ServerMainView_SelectedLogViewIndexChange
            (
               object sender, 
               EventArgs e
            )
            {
               try
               {
                  OnSelectedLogViewIndexChange ( ) ;
               }
               catch
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
               }
            }
            
            void __ServerMainView_RetrieveListViewItem(object sender, RetrieveVirtualItemEventArgs e)
            {
               long    decEventId ;
               DicomEventLogDataSet.DICOMServerEventLogRow currentItemDR ;
               string strColumnName ;
               
               
               if ( e.ItemIndex >= __EventLogId.Count )
               {
                  currentItemDR = null;
                  // --__ServerMainView.ServerLogsCount;
                  __ServerMainView.ServerLogsCount = 0;
                  __EventLogId.Clear();
                  
                  //string[] items2 = new string[__ServerMainView.VirtualListColumns.Count];

                  //for (int index = 0; index < __ServerMainView.VirtualListColumns.Count; index++)
                  //{
                  //   ColumnHeader column = __ServerMainView.VirtualListColumns[index];

                  //   strColumnName = (string)column.Tag;

                  //   items2[index] = "Not Exist";
                  //}

                  //e.Item = null;
                  e.Item = new ListViewItem("222");
                  for (int index = 0; index < __ServerMainView.VirtualListColumns.Count; index++)
                  {
                     e.Item.SubItems.Add("2x");
                  }
                  return ;
               }
               
               decEventId = __EventLogId [ e.ItemIndex ] ;
               
               try
               {
                  currentItemDR = GetItemInfo ( decEventId ) ;
               }
               catch ( Exception )
               {
                  __ServerMainView.QueryStateChanged ( false ) ;
                  
                  __EventLogId.Clear ( ) ;

                  //__ServerMainView.ServerLogsCount = 0;
                  
                  OnSelectedLogViewIndexChange ( ) ;
                  
                  currentItemDR = null ;
               }
               
               
               if ( null == currentItemDR )
               {
                  if ( __EventLogId.Contains ( decEventId ) )
                  {
                     __EventLogId.Remove ( decEventId ) ;
                  }

                  string[] items1 = new string[__ServerMainView.VirtualListColumns.Count];

                  for (int index = 0; index < __ServerMainView.VirtualListColumns.Count; index++)
                  {
                     ColumnHeader column = __ServerMainView.VirtualListColumns[index];

                     strColumnName = (string)column.Tag;

                     items1[index] = "Not Exist";
                  }

                  e.Item = new ListViewItem(items1);

                  //__ServerMainView.ServerLogsCount = 0;
                  
                  return ;
               }
               
               string[] items = new string [ __ServerMainView.VirtualListColumns.Count ] ;
               
               for ( int index = 0; index < __ServerMainView.VirtualListColumns.Count; index++ ) 
               {
                  ColumnHeader column =  __ServerMainView.VirtualListColumns [ index ] ;
                  
                  strColumnName = (string) column.Tag ;
                  
                  items [ index ] = __ListViewFormatter.Format ( strColumnName, 
                                                                 currentItemDR [ strColumnName ], 
                                                                 null ) ;
               }

               e.Item = new ListViewItem ( items ) ;
            }
            
            void deleteWorker_RunWorkerCompleted ( object sender, RunWorkerCompletedEventArgs e )
            {
               try
               {
                  if ( e.Error == null ) 
                  {
                     if ( null != __EventLogId ) 
                     {
                        __EventLogId.Clear ( ) ;
                     }
                     
                     RefreshQueryInfo ( ) ;
                  }
                  
                  if ( null != DeleteCompleted ) 
                  {
                     try
                     {
                        DeleteCompleted ( this, e ) ;
                     }
                     catch{}
                  }
               }
               catch ( Exception ex ) 
               {
                  if ( null != DeleteCompleted ) 
                  {
                     DeleteCompleted ( this, new RunWorkerCompletedEventArgs ( null, ex, false ) ) ;
                  }
               }
               finally
               {
                  __ServerMainView.ResumeLogsLayout ( ) ;
               }
            }

            void deleteWorker_DoWork ( object sender, DoWorkEventArgs e )
            {
               if ( e.Argument is QueryState ) 
               {
                  QueryState query = (QueryState) e.Argument ;
                  
                  __DataAccessAgent.DeleteDicomEventLog ( query.MatchingParametersListCollection, 
                                                          query.LastRowsCount ) ;
               }
            }
            
            
         #endregion
         
         #region Data Members
         
            private List <long>                           m_eventLogId ;
            private DICOMServerMain                       m_ctlServerMainView ;
            private DICOMServerViewController.QueryState  m_LastQueryState ;
            private DataSet                               m_EventLogTableColumnFiledFullPathDataSet ;
            private bool                                  m_QueryPerformed      = false ;
            private ILoggingDataAccessAgent2              m_DataAccessAgent     = null ;
            private DicomEventLogDataSet                  m_DICOMServerEventLogGeneralInfoCacheDataset = null ;
            private long                                  m_decLasttDICOMServerEventLogIDsSum  = -1 ;
            DICOMServerEventLogListviewFormatter          m_ListViewFormatter ;
            private bool                                  m_ImportLogActive = false;
            
            
         #endregion
         
         #region Data Types Definition
         

            private class Constants
            {
               public class KeyBoardKeys
               {
                  public const int Delete = 46 ;
                  public const int Enter  = 13 ;
               }
               
               public class General
               {
                  public const string EVENT_LOGGING_HEADER_TEXT = "DICOM Server Event Logs:" ;
                  
                  public const int LastEntryNotSpcified = -1 ;
                  public const int CacheTableMaxSize    = 1000 ;
               }
               
               public class ResInfo
               {
                  public class EventLogTableColumnFiledFullPathTable
                  {
                     public const string TableName = "Entry" ;
                     
                     public const string ColumnFieldFullPathName         = "ColumnKeyFullPath" ;
                     public const string ColumnFieldRelatedOrderByOption = "RelatedOrderByOption" ;
                  }
               }
               
               public class SpecialCharacters
               {
                  public const char Space               = ' ' ;
                  public const char KeyValueSeparator   = ':' ;
                  public const char QueryFieldSeparator = ',' ;
               }
               
               public class Messages
               {
                  public class Exception
                  {
                     public const string ColumnNameNotFound = "Column name can't be found." ;
                  }
                  
                  public class MessageBox
                  {
                     public const string DICOMServerDetailsDialogShowFailed = "Failed to display the DICOM Server event log details dialog." ;
                     public const string ErrorCaption                       = "Event Log Viewer Error" ;
                     public const string ImportLogError                     = "Error Importing Log File: '{0}'" ;
                  }
               }
               
               
               public class Resources
               {
                  public class XML
                  {
                     public const string EventLogTableColumnFiledFullPath = "Leadtools.Medical.Winforms.EventLogViewer.LogViewController.DICOMServerViewController.Resources.XML.ColumnFieldsFullPath.ColumnFieldsFullPath.xml" ;
                  }
               }
            }
            
            private class QueryState
            {
               public QueryState ( )
               {}
               
               public QueryState ( MatchingParameterCollection matchingParams, OrderByParametersList orderBy, int lastRowsCount )
               {
                  MatchingParametersListCollection = matchingParams ;
                  OrderParamsList                  = orderBy ;
                  LastRowsCount                    = lastRowsCount ;
               }
               
               public MatchingParameterCollection MatchingParametersListCollection = null ;
               
               public OrderByParametersList OrderParamsList = null ;
               
               public int LastRowsCount = -1 ;
            }
                        
         #endregion
         
      #endregion
      
      #region internal
         
         #region Methods
            
         #endregion
         
         #region Properties
            
         #endregion
         
         #region Events
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
         #region Callbacks
            
         #endregion
         
      #endregion
   }
}

