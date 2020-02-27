// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System ;
using System.Data ;
using System.Drawing ;
using System.Reflection ;
using System.Collections ;
using System.ComponentModel ;
using System.Windows.Forms ;
using System.Threading ;
using Leadtools.Medical.Winforms.Control ;
using Leadtools.Medical.Winforms.Monitor;
using System.IO;
using System.Collections.Generic;


namespace Leadtools.Medical.Winforms
{
   public partial class EventLogViewer : UserControl
   {
      #region Public
         
         #region Methods
         
            public EventLogViewer ( )
            {
               try
               {
                  InitializeComponent ( ) ;
                     
                  if ( !_DesignMode ) 
                  {
                     Init ( ) ;
                        
                     RegisterEvents ( ) ;                     
                  }                  

               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                        
                  throw exception ;
               }
            }           

         
         #endregion
         
         #region Properties
         public string PathLogDump {get;set;}
            
         #endregion
         
         #region Events
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
         #region Callbacks
            
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
         
            private void Init ( ) 
            {
               try
               {
                  if ( _DesignMode )
                  {
                     return ;
                  }
                  
                  __TabPagesToViewComponents = new Hashtable ( ) ;
                  
                  __DICOMServerViewController = new DICOMServerViewController ( ctlServerMain ) ;
                  
                  __TabPagesToViewComponents.Add ( tabpgDICOMServer, 
                                                   ctlServerMain ) ;
                                                   
                  SetDICOMServerButtonIcons ( ) ;
                                                   
                  HandleDICOMServerQueryUITab ( true ) ;
                  
                  _ImportingLogs = false;
                  _ImportedLogsInViewer = false;
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
                  RegisterDICOMServerEvents ( ) ;
                  
                  tabEventLogViewer.SelectedIndexChanged += new EventHandler ( tabEventLogViewer_SelectedIndexChanged ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private void RegisterDICOMServerEvents ( )
            {
               try
               {
                  btnDICOMServerQuery.Click   += new EventHandler ( btnDICOMServerQuery_Click ) ;   
                  btnDICOMServerDetails.Click += new EventHandler ( DICOMServer_DetailsRequest ) ;
                  btnDICOMServerDelete.Click  += new EventHandler ( DICOMServer_DeleteRequest ) ;
                  btnDICOMServerExport.Click  += new EventHandler ( DICOMServer_ExportRequest ) ;
                  btnDICOMServerImport.Click += new EventHandler ( DICOMServer_ImportRequest );
                  btnDICOMServerCancelImport.Click += new EventHandler(DICOMServer_CancelImportRequest);

                  DeleteSelectedToolStripMenuItem.Click    += new EventHandler ( DeleteSelectedToolStripMenuItem_Click ) ;
                  DeleteCurrentViewToolStripMenuItem.Click += new EventHandler ( DeleteCurrentViewToolStripMenuItem_Click ) ;
                  ClearAllLogsToolStripMenuItem.Click      += new EventHandler ( ClearAllLogsToolStripMenuItem_Click ) ;
                  
                  btnDICOMServerStartConQuery.Click += new EventHandler ( btnDICOMServerStartConQuery_Click ) ;
                  btnDICOMServerStopConQuery.Click  += new EventHandler ( btnDICOMServerStopConQuery_Click ) ;

                  DeleteLogsContextMenuStrip.Opening += new CancelEventHandler ( DeleteLogsContextMenuStrip_Opening ) ;

                  
                  __DICOMServerViewController.SelectedLogViewIndexChange += new EventHandler ( DICOMServerViewController_SelectedLogViewIndexChange ) ;
                  __DICOMServerViewController.DeleteCompleted += new EventHandler<RunWorkerCompletedEventArgs> ( __DICOMServerViewController_DeleteCompleted ) ;

                  __DICOMServerViewController.ImportStarting += new EventHandler<ImportLogArgs>(__DICOMServerViewController_ImportStarting);
                  __DICOMServerViewController.ImportCompleted += new EventHandler<ImportLogArgs>(__DICOMServerViewController_ImportCompleted);
                  
                  tmrServerQueryUpdate.Tick += new EventHandler ( tmrServerQueryUpdate_Tick ) ;
                  
                  ctlServerMain.DeleteRequest       += new EventHandler ( DICOMServer_DeleteRequest ) ; 
                  ctlServerMain.DetailsRequest      += new EventHandler ( DeleteSelectedToolStripMenuItem_Click ) ;
                  ctlServerMain.LogsViewDoubleClick += new EventHandler ( DICOMServer_DetailsRequest ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }

            void __DICOMServerViewController_ImportStarting(object sender, ImportLogArgs e)
            {
               _ImportingLogs = true;
               HandleDICOMServerQueryUITab(true);
            }
            
            
            void __DICOMServerViewController_ImportCompleted(object sender, ImportLogArgs e)
            {
               _ImportingLogs = false;
               if (e.Cancelled)
               {
                  MessageBox.Show(Constants.Messages.MessageBox.ImportLogCancelled,
                  Constants.Messages.MessageBox.EventLogViewerCaption,
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Exclamation);
               }
               _ImportedLogsInViewer = !e.Cancelled;
               HandleDICOMServerQueryUITab(true);
            }

            private void SetDICOMServerButtonIcons ( )
            {
               try
               {
                  //btnDICOMServerDelete.Image = Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream(Constants.Resources.Delete));
                  //btnDICOMServerQuery.Image = Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream(Constants.Resources.Query_Single));
                  //btnDICOMServerExport.Image = Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream(Constants.Resources.Export));
                  //btnDICOMServerDetails.Image = Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream(Constants.Resources.ViewDetails));
                  //btnDICOMServerStartConQuery.Image = Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream(Constants.Resources.Query_StartCont));
                  //btnDICOMServerStopConQuery.Image = Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream(Constants.Resources.Query_StopCont));

                  btnDICOMServerDetails.Image       = Image.FromStream ( Assembly.GetExecutingAssembly ( ).GetManifestResourceStream ( Constants.Resources.ViewDetailsPNG ) ) ;
                  btnDICOMServerDelete.Image = Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream(Constants.Resources.DeletePNG));
                  btnDICOMServerExport.Image = Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream(Constants.Resources.ExportPNG));
                  btnDICOMServerQuery.Image = Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream(Constants.Resources.Query_SinglePNG));
                  btnDICOMServerStartConQuery.Image = Image.FromStream ( Assembly.GetExecutingAssembly ( ).GetManifestResourceStream ( Constants.Resources.Query_StartContPNG ) ) ;
                  btnDICOMServerStopConQuery.Image  = Image.FromStream ( Assembly.GetExecutingAssembly ( ).GetManifestResourceStream ( Constants.Resources.Query_StopContPNG ) ) ;
                  
                  this.btnDICOMServerImport.Image  = Image.FromStream ( Assembly.GetExecutingAssembly ( ).GetManifestResourceStream ( Constants.Resources.ImportPNG ) ) ;
                  this.btnDICOMServerCancelImport.Image  = Image.FromStream ( Assembly.GetExecutingAssembly ( ).GetManifestResourceStream ( Constants.Resources.Cancel_ImportPNG ) ) ;

               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            private bool IsDeleteRequestVerefiedFromClient ( string question )
            {
               try
               {
                  DialogResult DeleteRequestDialogResult ;
                        
                        
                  DeleteRequestDialogResult = MessageBox.Show ( question,
                                                                Constants.Messages.MessageBox.EventLogViewerCaption,
                                                                MessageBoxButtons.YesNo,
                                                                MessageBoxIcon.Question,
                                                                MessageBoxDefaultButton.Button2 ) ;
                                                                      
                  switch ( DeleteRequestDialogResult )
                  {
                     case DialogResult.Yes:
                     {
                        return true ;
                     }
                           
                     default:
                     {
                        return false ;
                     }
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                        
                  throw exception ;
               }
            }
            
            
            private void ExportDICOMServerSelectedLogs ( )
            {
               try
               {
                  if ( DialogResult.OK == LogsSaveFileDialog.ShowDialog ( ) )
                  {
                     Cursor.Current = Cursors.WaitCursor ;
                     
                     __DICOMServerViewController.ExportSelected ( LogsSaveFileDialog.FileName ) ;            
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                        
                  throw exception ;
               }
               finally
               {
                  Cursor.Current = Cursors.Default ;
               }
            }

            bool IsDigitsOnly(string str)
            {
               foreach (char c in str)
               {
                  if (!char.IsDigit(c))
                     return false;
               }
               return true;
            }
            
            private void ImportDICOMServerLogs()
            {
               try
               {
                  // LoggingModuleConfigurationManager loggingConfigManager = ServiceLocator.Retrieve <LoggingModuleConfigurationManager> ( ) ;
                  
                  LogViewController x = this.m_DICOMServerViewController;
                  
                  LogsOpenFileDialog.InitialDirectory = PathLogDump;
                  if (!string.IsNullOrEmpty(LogsOpenFileDialog.FileName))
                  {
                     LogsOpenFileDialog.InitialDirectory = Path.GetDirectoryName(LogsOpenFileDialog.FileName);
                  }
                  
                  LogsOpenFileDialog.FileName = string.Empty; // PathLogDump;
                  if ( DialogResult.OK == LogsOpenFileDialog.ShowDialog ( ) )
                  {
                     Cursor.Current = Cursors.WaitCursor ;
                     
                     string root = Path.GetDirectoryName(LogsOpenFileDialog.FileName);
                     
                     // We only want file names of all digits with an extension '.txt'
                     List<string> files = new List<string>();
                     
                     foreach (string fname in LogsOpenFileDialog.FileNames)
                     {
                        if (fname.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                        {
                           // if (IsDigitsOnly(Path.GetFileNameWithoutExtension(fname)))
                                 files.Add(Path.Combine(root, fname));
                        }
                     }
                     
                     __DICOMServerViewController.ImportAsync( files);
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                        
                  throw exception ;
               }
               finally
               {
                  Cursor.Current = Cursors.Default ;
               }
            }
            
            private void HandleEnableDisabledDICOMServerDetailsButton 
            ( 
               int nSelectedCount 
            )
            {
               try
               {
                  if (_ImportingLogs)
                  {
                     btnDICOMServerDetails.Enabled = false ;
                  }
                  if ( tmrServerQueryUpdate.Enabled )
                  {
                     btnDICOMServerDetails.Enabled = false ;
                  }
                  else
                  {
                     if ( nSelectedCount != 1 ) 
                     {
                        btnDICOMServerDetails.Enabled = false ;
                     }
                     else
                     {
                        btnDICOMServerDetails.Enabled = true ;
                     }
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                        
                  throw exception ;
               }
            }
            
            
            
            private void HandleEnableDisableDICOMServerDeleteExportButtons 
            ( 
               int nSelectedCount
            )
            {
               try
               {
                  if (_ImportingLogs || _ImportedLogsInViewer)
                  {
                     btnDICOMServerDelete.Enabled = false ;
                     btnDICOMServerExport.Enabled = false ;
                  }
                  
                  else if ( tmrServerQueryUpdate.Enabled ) 
                  {
                     btnDICOMServerDelete.Enabled = false ;
                     btnDICOMServerExport.Enabled = false ;                  
                  }
                  else
                  {
                     btnDICOMServerDelete.Enabled = true ;
                     
                     if ( nSelectedCount > 0 )
                     {
                        btnDICOMServerExport.Enabled = true ;
                     }
                     else
                     {
                        btnDICOMServerExport.Enabled = false ;
                     }
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
         
                  throw exception ;
               }
            }
            
            private void HandleEnableDisableDICOMServerLogButtons()
            {
               btnDICOMServerImport.Enabled = !_ImportingLogs;
               btnDICOMServerCancelImport.Enabled = _ImportingLogs;
               
               if (_ImportedLogsInViewer)
               {
                  ctlServerMain.VirutalListBackColor = Color.LemonChiffon; //SystemColors.Info;
                  tabpgDICOMServer.ImageIndex = 0;
                  tabpgDICOMServer.Text = "Event Log: Import Mode";
               }
               else
               {
                  ctlServerMain.VirutalListBackColor = SystemColors.Window;
                  tabpgDICOMServer.ImageIndex = -1;
                  tabpgDICOMServer.Text = "Event Log";
               }
            }
            
            
            private void HandleEnableDisableDICOMServerQueryControls ( )
            {
               try
               {
                  btnDICOMServerQuery.Enabled         = ! tmrServerQueryUpdate.Enabled  && !_ImportingLogs;
                  btnDICOMServerStartConQuery.Enabled = ! tmrServerQueryUpdate.Enabled  && !_ImportingLogs;
                  btnDICOMServerStopConQuery.Enabled  = tmrServerQueryUpdate.Enabled  && !_ImportingLogs;
                  
                  ctlServerMain.EnableQueryControl ( ! tmrServerQueryUpdate.Enabled  && !_ImportingLogs) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            
            private void HandleDICOMServerQueryUITab ( bool bSuccessState )
            {
               try
               {
                  if ( ! bSuccessState )
                  {
                     HandleEnableDisabledDICOMServerDetailsButton ( 0 ) ;
                     HandleEnableDisableDICOMServerDeleteExportButtons ( 0 ) ;
                  }
                  else
                  {
                     HandleEnableDisabledDICOMServerDetailsButton      ( __DICOMServerViewController.SelctedLogsCount ) ;
                     HandleEnableDisableDICOMServerDeleteExportButtons ( __DICOMServerViewController.SelctedLogsCount ) ;
                  }
                  
                  HandleEnableDisableDICOMServerLogButtons();
                  HandleEnableDisableDICOMServerQueryControls ( ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            void __DICOMServerViewController_DeleteCompleted ( object sender, RunWorkerCompletedEventArgs e )
            {
               try
               {
                  this.Enabled = true ;
                  
                  if ( e.Error != null )
                  {
                     HandleDICOMServerQueryUITab ( false ) ;
                     
                     MessageBox.Show ( Constants.Messages.MessageBox.EventLogDeleteFailed,
                                       Constants.Messages.MessageBox.ErrorCaption,
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Error ) ;
                  }
                  else
                  {
                     HandleDICOMServerQueryUITab ( true ) ;
                     
                     MessageBox.Show ( Constants.Messages.MessageBox.DeleteSuccess,
                                       Constants.Messages.MessageBox.EventLogViewerCaption,
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Information ) ;                  
                  }
               }
               catch ( Exception ex ) 
               {
                  MessageBox.Show ( ex.Message,
                                    Constants.Messages.MessageBox.ErrorCaption,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error ) ;                  
               }
            }
            
            
            private void HandleLogDetailsRequest 
            ( 
               LogViewController ViewController 
            ) 
            {
               try
               {
                  ShowLogDetails ( ViewController ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private void ShowLogDetails 
            (  
               LogViewController ViewController 
            ) 
            {
               try
               {
                  ViewController.ViewSelectedLogDetail ( ) ;
               }
               catch
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                                          
                  MessageBox.Show ( Constants.Messages.MessageBox.DetailsDialogShowFailed,
                                    Constants.Messages.MessageBox.ErrorCaption,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error ) ;
               }
            }
            
            
         #endregion
         
         #region Properties
         
            private LogViewController __DICOMServerViewController
            {
               get
               {
                  return m_DICOMServerViewController ;
               }
            
               set 
               {
                  m_DICOMServerViewController = value ;
               }
            }
            
            private Hashtable __TabPagesToViewComponents
            {
               get
               {
                  return m_TabPagesToViewComponents ;
               }
            
               set 
               {
                  m_TabPagesToViewComponents = value ;
               }
            }
            
            private bool _DesignMode
            {
               get
               {
                  return (this.GetService(typeof(System.ComponentModel.Design.IDesignerHost)) != null) || 
                         (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime || 
                         DesignMode  );
               }
            }
            
            private bool _ImportingLogs
            {
               get; set;
            }
            
            private bool _ImportedLogsInViewer
            {
               get; set;
            }
                        
         #endregion
         
         #region Events
         
            private void btnDICOMServerQuery_Click
            (
               object sender, 
               EventArgs e
            )
            {
               try
               {
                  Cursor.Current = Cursors.WaitCursor ;
                  _ImportedLogsInViewer = false;
                  
                  if ( __DICOMServerViewController.PerformQuery ( ) == 0 )
                  {
                  
                     MessageBox.Show ( Constants.Messages.MessageBox.QueryNoResults,
                                       Constants.Messages.MessageBox.EventLogViewerCaption,
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Information ) ;                  
                  }
                  
                  HandleDICOMServerQueryUITab ( true ) ;
               }
               catch
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  HandleDICOMServerQueryUITab ( false ) ;
               }
               finally
               {
                  Cursor.Current = Cursors.Default ;
               }
            }
            
            
            
            private void DICOMServerViewController_SelectedLogViewIndexChange
            (
               object sender, 
               EventArgs e
            )
            {
               try
               {
                  HandleDICOMServerQueryUITab ( true ) ;
               }
               catch
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
               }
            }
            
            
            private void tabEventLogViewer_SelectedIndexChanged
            (
               object sender, 
               EventArgs e
            )
            {
               try
               {
                  switch (  tabEventLogViewer.SelectedTab.Name )
                  {
                     case Constants.TabPagesName.DICOMServer:
                     {
                        HandleDICOMServerQueryUITab ( true ) ;
                     }
                     
                     break ;
                     
                     default:
                     {
                        throw new Exception ( Constants.Messages.Exception.InvalidTabPageName ) ;
                     }
                  } 
               }
               catch ( Exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
               }
            }
            
            private void tmrServerQueryUpdate_Tick
            (
               object sender, 
               EventArgs e
            )
            {
               try
               {
                  if ( tabEventLogViewer.SelectedTab == tabpgDICOMServer ) 
                  {
                     tmrServerQueryUpdate.Enabled = false ;
               
                  
                     __DICOMServerViewController.RefreshQueryInfo ( ) ;
                  
                     tmrServerQueryUpdate.Enabled = true ;
                  }
               }
               catch 
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  HandleDICOMServerQueryUITab ( false ) ;
               }
            }
            
            
            private void DICOMServer_DeleteRequest
            (
               object sender, 
               EventArgs e
            )
            {
               try
               {
                  if ( ! tmrServerQueryUpdate.Enabled )
                  {
                     DeleteLogsContextMenuStrip.Show ( btnDICOMServerDelete, 10 , 10 ) ;
                  }
               }
               catch  
               {}
            }
            
            void DeleteSelectedToolStripMenuItem_Click ( object sender, EventArgs e )
            {
               try
               {
                  if ( ! tmrServerQueryUpdate.Enabled )
                  {
                     if ( IsDeleteRequestVerefiedFromClient ( Constants.Messages.MessageBox.DeleteSelectedRequestVerification ) )
                     {
                        this.Enabled = false ;
                        
                        __DICOMServerViewController.DeleteSelected ( ) ;
                     }
                  }
               }
               catch 
               {
                  HandleDICOMServerQueryUITab ( false ) ;
                  
                  MessageBox.Show ( Constants.Messages.MessageBox.EventLogDeleteFailed,
                                    Constants.Messages.MessageBox.ErrorCaption,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error ) ;
               }
            }
            
            void DeleteCurrentViewToolStripMenuItem_Click ( object sender, EventArgs e )
            {
               try
               {
                  if ( ! tmrServerQueryUpdate.Enabled )
                  {
                     if ( IsDeleteRequestVerefiedFromClient ( Constants.Messages.MessageBox.DeleteCurrentRequestVerification ) )
                     {
                        this.Enabled = false ;
                        
                        __DICOMServerViewController.DeleteCurrentView ( ) ;
                     }
                  }
               }
               catch 
               {
                  HandleDICOMServerQueryUITab ( false ) ;
                  
                  MessageBox.Show ( Constants.Messages.MessageBox.EventLogDeleteFailed,
                                    Constants.Messages.MessageBox.ErrorCaption,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error ) ;
               }
            }
            
            void ClearAllLogsToolStripMenuItem_Click ( object sender, EventArgs e )
            {
               try
               {
                  if ( ! tmrServerQueryUpdate.Enabled )
                  {
                     if ( IsDeleteRequestVerefiedFromClient ( Constants.Messages.MessageBox.DeleteAllRequestVerification ) )
                     {
                        this.Enabled = false ;
                        
                        __DICOMServerViewController.DeleteAll ( ) ;
                     }
                  }
               }
               catch 
               {
                  HandleDICOMServerQueryUITab ( false ) ;
                  
                  MessageBox.Show ( Constants.Messages.MessageBox.EventLogDeleteFailed,
                                    Constants.Messages.MessageBox.ErrorCaption,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error ) ;
               }
            }

            void deleteWorker_DoWork ( object sender, DoWorkEventArgs e )
            {
               if( e.Argument is Action ) 
               {
                  ( ( Action ) e.Argument ).Invoke ( ) ;
               }
            }
            
            
            private void DICOMServer_DetailsRequest
            (
               object sender, 
               EventArgs e
            )
            {
               try
               {
                  if ( ! tmrServerQueryUpdate.Enabled )
                  {
                     Cursor.Current = Cursors.WaitCursor ;
                  
                     HandleLogDetailsRequest ( __DICOMServerViewController ) ;
                  }
               }
               catch
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  MessageBox.Show ( Constants.Messages.MessageBox.DetailsDialogShowFailed,
                                    Constants.Messages.MessageBox.ErrorCaption,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error ) ;
               }
               finally
               {
                  Cursor.Current = Cursors.Default ;
               }
            }
            
            
            private void DICOMServer_ExportRequest
            (
               object sender, 
               EventArgs e
            )
            {
               try
               {
                  Cursor.Current = Cursors.WaitCursor ;
                  
                  ExportDICOMServerSelectedLogs ( ) ;  
                     
               }
               catch
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  MessageBox.Show ( Constants.Messages.MessageBox.DICOMServerExportEventLogFailed,
                                    Constants.Messages.MessageBox.ErrorCaption,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error ) ;

               }
               finally
               {
                  Cursor.Current = Cursors.Default ;
               }
            }
            

            private void DICOMServer_ImportRequest
            (
               object sender, 
               EventArgs e
            )
            {
               try
               {
                  Cursor.Current = Cursors.WaitCursor ;
                  
                  ImportDICOMServerLogs ( ) ;
                                       
               }
               catch
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  MessageBox.Show ( Constants.Messages.MessageBox.DICOMServerExportEventLogFailed,
                                    Constants.Messages.MessageBox.ErrorCaption,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error ) ;

               }
               finally
               {
                  Cursor.Current = Cursors.Default ;
               }
            }



            private void DICOMServer_CancelImportRequest
                      (
                         object sender,
                         EventArgs e
                      )
            {
               try
               {
                  Cursor.Current = Cursors.WaitCursor;

                  _ImportedLogsInViewer = false;

                  __DICOMServerViewController.CancelImportAsync(null);

               }
               catch
               {
                  System.Diagnostics.Debug.Assert(false);

                  MessageBox.Show(Constants.Messages.MessageBox.DICOMServerExportEventLogFailed,
                                    Constants.Messages.MessageBox.ErrorCaption,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

               }
               finally
               {
                  Cursor.Current = Cursors.Default;
               }
            }
            
            
            
            
            private void btnDICOMServerStartConQuery_Click
            (
               object sender, 
               EventArgs e
            )
            {
               try
               {
                  EventBroker.Instance.PublishEvent<BackgroundProcessEventAgs>(this, new BackgroundProcessEventAgs(true));

                  _ImportedLogsInViewer = false;

                  Cursor.Current = Cursors.WaitCursor ;
                  
                  __DICOMServerViewController.PerformQuery ( ) ;
                  
                  tmrServerQueryUpdate.Start ( ) ;
                  
                  HandleDICOMServerQueryUITab ( true ) ;
               }
               catch ( Exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  HandleDICOMServerQueryUITab ( false ) ;
                  
                  Cursor.Current = Cursors.Default ;

                  EventBroker.Instance.PublishEvent<BackgroundProcessEventAgs>(this, new BackgroundProcessEventAgs(false));
               }               
            }
            
            
            private void btnDICOMServerStopConQuery_Click
            (
               object sender, 
               EventArgs e
            )
            {
               try
               {
                  Cursor.Current = Cursors.WaitCursor;

                  tmrServerQueryUpdate.Stop();

                  HandleDICOMServerQueryUITab(true);
               }
               catch (Exception)
               {
                  System.Diagnostics.Debug.Assert(false);

                  HandleDICOMServerQueryUITab(false);

                  Cursor.Current = Cursors.Default;
               }
               finally
               {
                  EventBroker.Instance.PublishEvent<BackgroundProcessEventAgs>(this, new BackgroundProcessEventAgs(false));
               }
            }
            
            
            void DeleteLogsContextMenuStrip_Opening ( object sender, CancelEventArgs e )
            {
               try
               {
                  if ( tmrServerQueryUpdate.Enabled ) 
                  {
                     DeleteCurrentViewToolStripMenuItem.Enabled = false ;
                     DeleteSelectedToolStripMenuItem.Enabled    = false ;
                     ClearAllLogsToolStripMenuItem.Enabled      = false ;
                  }
                  else
                  {
                     DeleteCurrentViewToolStripMenuItem.Enabled = __DICOMServerViewController.CurrentLogsCount > 0 ;
                     DeleteSelectedToolStripMenuItem.Enabled    = __DICOMServerViewController.SelctedLogsCount > 0 ;
                     ClearAllLogsToolStripMenuItem.Enabled      = true ;
                  }
               }
               catch {}
            }
            
            
            
            
         #endregion

         #region Data Members

            private LogViewController m_DICOMServerViewController ;
            private Hashtable         m_TabPagesToViewComponents ;
            private Leadtools.Medical.Winforms.Control.DICOMServerMain ctlServerMain;
            
         #endregion
         
         #region Data Types Definition
         
            private class Constants
            {
               public class General
               {
                  public const int MutexWaitTimeSpan = 1 ;
               }

               public class TabPagesName
               {
                  public const string DICOMServer      = "tabpgDICOMServer" ;
                  
               }
               
               
               public class Resources
               {
                  private const string ResourceIconPath = "Leadtools.Medical.Winforms.EventLogViewer.Res.Icon." ;
                  
                  public const string AppIcon            = ResourceIconPath + "EventLogViewer.ico" ;
                  public const string ViewDetails        = ResourceIconPath + "ViewDetails.ico" ;
                  public const string Query_StopCont     = ResourceIconPath + "Query_StopCont.ico" ;
                  public const string Query_StartCont    = ResourceIconPath + "Query_StartCont.ico" ;
                  public const string Query_Single       = ResourceIconPath + "Query_Single.ico" ;
                  public const string Export             = ResourceIconPath + "Export.ico" ;
                  public const string Delete             = ResourceIconPath + "Delete.ico" ;
                  public const string Unlocked           = ResourceIconPath + "Unlocked3.ico" ;

                  public const string DeletePNG          = ResourceIconPath + "Delete.png";
                  public const string Query_SinglePNG    = ResourceIconPath + "Query_Single.png";
                  public const string ExportPNG          = ResourceIconPath + "Export.png";
                  public const string ViewDetailsPNG     = ResourceIconPath + "ViewDetails.png";
                  public const string Query_StopContPNG  = ResourceIconPath + "Query_StopCont.png";
                  public const string Query_StartContPNG = ResourceIconPath + "Query_StartCont.png";
                  public const string ImportPNG          = ResourceIconPath + "Import.png";
                  public const string Cancel_ImportPNG   = ResourceIconPath + "Cancel_Import.png";

               }
               
               public class Messages
               {
                  public class MessageBox
                  {
                     public const string ErrorCaption                          = "Event Log Viewer Error" ;
                     public const string EventLogViewerCaption                 = "Event Log Viewer" ;  
                     public const string DetailsDialogShowFailed               = "Failed to display event log details dialog." ;
                     public const string EventLogDeleteFailed                  = "Problem occurred while trying to delete event logs." ;
                     public const string DICOMServerExportEventLogFailed       = "Problem occurred while trying to save DICOM Server event logs on file." ;
                     public const string DeleteSelectedRequestVerification     = "Are you sure you want to delete selected records?" ;  
                     public const string DeleteCurrentRequestVerification      = "Are you sure you want to delete current view records?" ;  
                     public const string DeleteAllRequestVerification          = "Are you sure you want to clear all event logs?" ;  
                     public const string DeleteSuccess                         = "Event logs deleted successfully." ;  
                     public const string EventLogViewer_ABOUT_ERROR_MESSAGE    = "Problem occurred while trying to open About dialog." ;
                     public const string QueryNoResults                        = "No results found!" ;
                     public const string ImportLogCancelled                    = "Import Log Cancelled";
                     
                  }
                        
                  public class Exception
                  {
                     public const string One_EventLog_Selected    = "At least one Event Log should be selected." ;
                     public const string One_Transaction_Selected = "At least one Transaction status should be selected." ;
                     public const string InvalidTabPageName  = "The tab-page name is not Identified." ;
                  }
               }
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
