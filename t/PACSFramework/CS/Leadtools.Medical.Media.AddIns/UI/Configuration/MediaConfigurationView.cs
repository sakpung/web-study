// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Leadtools.Demos;
using System.IO;
using Leadtools.Medical.Media.AddIns.Composing;
using System.Reflection;

namespace Leadtools.Medical.Media.AddIns.UI
{
   public partial class MediaConfigurationView : UserControl, IMediaConfigurationView
   {
      #region Public
         
         #region Methods
         
            public MediaConfigurationView ( )
            {
               InitializeComponent ( ) ;
               
               SaveButton.Enabled = false ;
            }
            
            public void LoadConfiguration 
            ( 
               MediaAddInConfiguration configuration, 
               MediaProfiles[] profiles 
            )
            {
               Init ( configuration, profiles ) ;
               
               RegisterEvents ( ) ;
            }
            
            public void TearDown ( ) 
            {
               if ( null != _tooltip ) 
               {
                  _tooltip.Dispose ( ) ;
                  _tooltip = null ;
               }
            }
            
            public void OnChangesSaved ( ) 
            {
               try
               {
                  __IsDirty = false ;
                  
                  SaveButton.Enabled = __IsDirty ;
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }            
            
            public void NotifyViewConfigurationChanged ( ) 
            {
               try
               {
                  __IsDirty = true ;
                  
                  SaveButton.Enabled = __IsDirty ;
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }

         #endregion
         
         #region Properties
         
         #endregion
         
         #region Events
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
         #region Callbacks
         
            public event EventHandler SaveChanges ;
            public event EventHandler ViewConfigurationChanged ;
            
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
         
            private void Init ( MediaAddInConfiguration configuration, MediaProfiles[] profiles )
            {
               __Configuration = configuration ;
               
               MediaBaseFolderTextBox.Text            = configuration.MediaFolder ;
               ViewerDirTextBox.Text                  = configuration.ViewerDirectory ;
               ValidateReferencedSopsCheckBox.Checked = configuration.ValidateReferencedSopInstances ;
               IncludeViewerCheckBox.Checked          = configuration.IncludeViewer ;
               
               DefaultProfileComboBox.DataSource    = profiles ;
               DefaultProfileComboBox.DisplayMember = "Description" ;
               DefaultProfileComboBox.ValueMember   = "Name" ;
               
               FoldersListBox.DataSource = configuration.Folders ;
               FilesListBox.DataSource   = configuration.Files ;
               
               BrowseViewerButton.DataBindings.Add ( "Enabled", IncludeViewerCheckBox, "Checked" ) ;
               
               UpdateDisplayTotalSize ( ) ;
            
               _tooltip = new ToolTip ( ) ;
               
               _tooltip.ToolTipIcon  = ToolTipIcon.Info ;
               _tooltip.UseAnimation = true ;
               _tooltip.UseFading    = true ;
               _tooltip.ToolTipTitle = "Workstation Media Viewer Tips" ;
               _tooltip.IsBalloon    = true ;
               _tooltip.AutoPopDelay = 30000 ;
               
               _tooltip.SetToolTip ( GenerateViewerButton,
                                     "The Viewer requires .NET 3.5 to be installed on the machine when running from a media CD/DVD.\nTo run the viewer on machines that only has .NET Framework 2.0 you can include Microsoft .NET Framework 3.5 installer  or copy the .NET 3.0 and .NET 3.5 assemblies into the same folder where the viewer is created.\nYou might find the .NET Framework referenced assemblies on your machine under \"[Program Files]\\Reference Assemblies\" folder." ) ;
            }

            private void RegisterEvents ( )
            {
               DefaultProfileComboBox.SelectionChangeCommitted += new EventHandler ( DefaultProfileComboBox_SelectionChangeCommitted ) ;
               FoldersListBox.SelectedIndexChanged             += new EventHandler ( FoldersListBox_SelectedIndexChanged ) ;
               FilesListBox.SelectedIndexChanged               += new EventHandler ( FilesListBox_SelectedIndexChanged ) ;

               ValidateReferencedSopsCheckBox.CheckedChanged += new EventHandler ( ValidateReferencedSopsCheckBox_CheckedChanged ) ;
               IncludeViewerCheckBox.CheckedChanged          += new EventHandler ( IncludeViewerCheckBox_CheckedChanged ) ;

               GenerateViewerButton.Click        += new EventHandler ( GenerateViewerButton_Click ) ;
               BrowseMediaBaseFolderButton.Click += new EventHandler ( BrowseMediaBaseFolderButton_Click ) ;
               BrowseViewerButton.Click          += new EventHandler ( BrowseViewerButton_Click ) ;
               AddFolderButton.Click             += new EventHandler ( AddFolderButton_Click ) ;
               AddFilesButton.Click              += new EventHandler ( AddFilesButton_Click ) ;
               RemoveFilesButton.Click           += new EventHandler ( RemoveFilesButton_Click ) ;
               RemoveFoldersButton.Click         += new EventHandler ( RemoveFoldersButton_Click ) ;
               SaveButton.Click                  += new EventHandler ( SaveButton_Click ) ;
            }

            private void OnSaveChanges ( )
            {
               if ( null != SaveChanges )
               {
                  SaveChanges ( this, EventArgs.Empty ) ;
               }
            }
            
            private void RefreshFoldersList ( )
            {
               if ( FoldersListBox.BindingContext [ __Configuration.Folders ] is CurrencyManager )
               {
                  ( ( CurrencyManager ) FoldersListBox.BindingContext [ __Configuration.Folders ] ).Refresh ( ) ;
               }
            }
            
            private void RefreshFilesList ( )
            {
               if ( FilesListBox.BindingContext [ __Configuration.Files ] is CurrencyManager )
               {
                  ( ( CurrencyManager ) FilesListBox.BindingContext [ __Configuration.Files ] ).Refresh ( ) ;
               }
            }
            
            private double GetCurrentSize ( )
            {
               return ( ( __Configuration.IncludeViewer ) ? __Configuration.ViewerSize : 0 )+ __Configuration.FilesAndFoldersSize ;
            }
            
            private double GetFolderSize ( string folderPath ) 
            {
               FileInfo[] files = new DirectoryInfo ( folderPath ).GetFiles ( "*", SearchOption.AllDirectories ) ;
               double     size  = 0 ;
               
               foreach ( FileInfo file in files ) 
               {
                  size += file.Length ;
               }
               
               return size ;
            }
            
            private double GetFilesSize ( string[] files )
            {
               double size ;
               
               
               size = 0 ;
               
               foreach ( string file in files ) 
               {
                  size += new FileInfo ( file ).Length ;
               }
               
               return size ;
            }
            
            private double GetFileSize ( string filePath ) 
            {
               FileInfo file = new FileInfo ( filePath ) ;
               
               return file.Length ;
            }
            
            private void UpdateDisplayTotalSize ( ) 
            {
               double numberOfBytes = GetCurrentSize ( ) ;
               string formattedCapacity ;
               
               if ( numberOfBytes >= 0x40000000 )
               {
                  formattedCapacity = Convert.ToString ( numberOfBytes / 0x40000000 ) ;
                  
                  if ( formattedCapacity.Length > 5 )
                  {
                     formattedCapacity = formattedCapacity.Substring ( 0, 5 ) + " GB" ;
                  }
                  
               }
               else if ( numberOfBytes >= 0x100000 )
               {
                  formattedCapacity = Convert.ToString ( numberOfBytes / 0x100000 ) ;
                  
                  if ( formattedCapacity.Length > 4 ) 
                  {
                     formattedCapacity = formattedCapacity.Substring(0, 4) + " MB" ;
                  }
               }
               else
               {
                  formattedCapacity = Convert.ToString(numberOfBytes / 0x400) ;
                  
                  if ( formattedCapacity.Length > 3 ) 
                  {
                     formattedCapacity = formattedCapacity.Substring(0, 3) + " KB" ;
                  }
               }
               
               TotalSizeTextBox.Text = formattedCapacity ;
            }
            
            private string PrepareViewerDirectory ( out string autoRunFile )
            {
               string binariesFolder ;
               string viewerFolderName ;
               string viewerFolder ;
               string viewerName ;
               
               
               binariesFolder   = new DirectoryInfo ( AddInsSession.ServiceDirectory ).Parent.FullName ;
               viewerFolderName = "WSViewer" ;
               viewerFolder     = Path.Combine ( AddInsSession.ServiceDirectory, viewerFolderName ) ;
               autoRunFile      = Path.Combine ( AddInsSession.ServiceDirectory, "autorun.inf" ) ;
               
               string[] mediatWorkstations = Directory.GetFiles ( binariesFolder, "*workstationdicomdir*.exe", SearchOption.TopDirectoryOnly ) ;
               
               if ( mediatWorkstations.Length == 0 )
               {
                  throw new InvalidOperationException ( "No Workstation Media Viewer found." ) ;
               }
               
               viewerName = new FileInfo ( mediatWorkstations [ 0 ] ).Name ;
               
               if ( !Directory.Exists ( viewerFolder ) )
               {
                  Directory.CreateDirectory ( viewerFolder ) ;
                  
                  foreach ( string fileName in  _viewerBinaries ) 
                  {
                     string filePath ;
                     
                     
                     filePath = Path.Combine ( binariesFolder, fileName ) ;
                     
                     if ( File.Exists ( filePath ) )
                     {
                        File.Copy ( filePath, Path.Combine ( viewerFolder, fileName ) ) ;
                     }
                  }
                  
                  File.Copy ( Path.Combine ( binariesFolder, viewerName ), 
                              Path.Combine ( viewerFolder, viewerName ) ) ;
                              
                  if ( File.Exists ( Path.Combine ( binariesFolder, viewerName + ".config" ) ) )
                  {
                     File.Copy ( Path.Combine ( binariesFolder, viewerName + ".config" ),
                                 Path.Combine ( viewerFolder, viewerName + ".config" ) ) ;
                  }
               }
               
               if ( !File.Exists ( autoRunFile ) )
               {
                  string viewerPath ;
                  string autoRunContents ;
                  
                  
                  viewerPath      = Path.Combine ( new DirectoryInfo ( viewerFolder ).Name, viewerName ) ;
                  autoRunContents = @"[autorun]
open={0}
icon={0}" ;
               
                  autoRunContents = string.Format ( autoRunContents, viewerPath ) ;
                     
                  File.WriteAllText ( autoRunFile, autoRunContents ) ;
               }
               
               return viewerFolder ;
            }
            
            private void UpdateSelectedViewer ( string folderPath )
            {
               ViewerDirTextBox.Text           = folderPath ;
               __Configuration.ViewerDirectory = folderPath ;
               __Configuration.ViewerSize      = GetFolderSize ( folderPath ) ;
               
               UpdateDisplayTotalSize ( ) ;
               
               OnChanged ( ) ;
            }
            
            private void OnChanged ( )
            {
               if ( null != ViewConfigurationChanged ) 
               {
                  ViewConfigurationChanged ( this, EventArgs.Empty ) ;
               }
            }

         #endregion
         
         #region Properties
         
            private MediaAddInConfiguration __Configuration
            {
               get ;
               set ;
            }
            
            private bool __IsDirty 
            {
               get ;
               set ;
            }
            
         #endregion
         
         #region Events
         

            void DefaultProfileComboBox_SelectionChangeCommitted ( object sender, EventArgs e )
            {
               try
               {
                  __Configuration.DefaultProfile = DefaultProfileComboBox.SelectedValue as string ;
                  
                  OnChanged ( ) ;
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }

            void FilesListBox_SelectedIndexChanged(object sender, EventArgs e)
            {
               try
               {
                  RemoveFilesButton.Enabled = FilesListBox.SelectedIndex != -1 ;
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }

            void FoldersListBox_SelectedIndexChanged(object sender, EventArgs e)
            {
               try
               {
                  RemoveFoldersButton.Enabled = FoldersListBox.SelectedIndex != -1 ;
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }
            
            void RemoveFoldersButton_Click ( object sender, EventArgs e )
            {
               try
               {
                  if ( FoldersListBox.SelectedIndex != -1 ) 
                  {
                     double folderSize ;
                     
                     
                     folderSize = GetFolderSize ( __Configuration.Folders [ FoldersListBox.SelectedIndex ] ) ;
                     
                     __Configuration.Folders.RemoveAt ( FoldersListBox.SelectedIndex ) ;
                     
                     __Configuration.FilesAndFoldersSize -= folderSize ;
                     
                     RefreshFoldersList ( ) ;
                     
                     UpdateDisplayTotalSize ( ) ;
                     
                     OnChanged ( ) ;
                  }
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }

            void RemoveFilesButton_Click(object sender, EventArgs e)
            {
               try
               {
                  if ( FilesListBox.SelectedIndex != -1 ) 
                  {
                     double filesSize ;
                     
                     
                     filesSize = GetFileSize ( __Configuration.Files [ FilesListBox.SelectedIndex ] ) ;
                     
                     if ( __Configuration.Files [ FilesListBox.SelectedIndex ] == __Configuration.AutoRunViewerFile )
                     {
                        __Configuration.RemoveViewerAutorunFile ( ) ;
                     }
                     else
                     {
                        __Configuration.Files.RemoveAt ( FilesListBox.SelectedIndex ) ;
                     }

                     __Configuration.FilesAndFoldersSize -= filesSize ;
                     
                     RefreshFilesList ( ) ;
                     
                     UpdateDisplayTotalSize ( ) ;
                     
                     OnChanged ( ) ;
                  }
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }
            
            void AddFolderButton_Click ( object sender, EventArgs e )
            {
               try
               {
                  FolderBrowserDialog folderBrowse ;
                  
                  
                  using ( folderBrowse = new FolderBrowserDialog ( ) )
                  {
                     if ( folderBrowse.ShowDialog ( ) == DialogResult.OK ) 
                     {
                        if ( !__Configuration.Folders.Contains ( folderBrowse.SelectedPath ) )
                        {
                           double folderSize ;
                           
                           
                           folderSize = GetFolderSize ( folderBrowse.SelectedPath ) ;
                           
                           __Configuration.Folders.Add ( folderBrowse.SelectedPath ) ;
                           
                           __Configuration.FilesAndFoldersSize += folderSize ;
                           
                           RefreshFoldersList ( ) ;
                           
                           UpdateDisplayTotalSize ( ) ;
                           
                           OnChanged ( ) ;
                        }
                        else
                        {
                           Messager.ShowWarning ( this, "The selected folder is already added" ) ;
                        }
                     }
                  }
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }

            void AddFilesButton_Click(object sender, EventArgs e)
            {
               try
               {
                  OpenFileDialog fileAddDialog ;
                  
                  
                  using ( fileAddDialog = new OpenFileDialog ( ) )
                  {
                     fileAddDialog.Multiselect = true ;
                     
                     if ( fileAddDialog.ShowDialog ( ) == DialogResult.OK ) 
                     {
                        foreach ( string file in fileAddDialog.FileNames )
                        {
                           if ( __Configuration.Files.Contains ( file ) )
                           {
                              continue ;
                           }
                           else
                           {
                              double filesSize ;
                              
                              
                              filesSize = GetFileSize ( file ) ;
                              
                              __Configuration.Files.Add ( file ) ;
                              
                              __Configuration.FilesAndFoldersSize += filesSize ;
                           }
                        }
                        
                        RefreshFilesList ( ) ;
                        
                        UpdateDisplayTotalSize ( ) ;
                        
                        OnChanged ( ) ;
                     }
                  }
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }

            void BrowseViewerButton_Click(object sender, EventArgs e)
            {
               try
               {
                  FolderBrowserDialog folderBrwose ;
                  
                  
                  using ( folderBrwose = new FolderBrowserDialog ( ) )
                  {
                     if ( folderBrwose.ShowDialog ( ) == DialogResult.OK ) 
                     {
                        string folderPath ;
                        
                        
                        folderPath = folderBrwose.SelectedPath ;

                        UpdateSelectedViewer ( folderPath ) ;
                     }
                  }
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }

            void ValidateReferencedSopsCheckBox_CheckedChanged(object sender, EventArgs e)
            {
               try
               {
                  __Configuration.ValidateReferencedSopInstances = ValidateReferencedSopsCheckBox.Checked;

                  OnChanged();
               }
               catch (Exception exception)
               {
                  Messager.ShowError(this, exception);
               }
            }
            
            void IncludeViewerCheckBox_CheckedChanged ( object sender, EventArgs e )
            {
               try
               {
                  if ( IncludeViewerCheckBox.Checked && ViewerDirTextBox.Text.Length == 0 )
                  {
                     BrowseViewerButton_Click ( BrowseViewerButton, EventArgs.Empty ) ;
                  }
                  
                  if ( IncludeViewerCheckBox.Checked && ViewerDirTextBox.Text.Length == 0 )
                  {
                     IncludeViewerCheckBox.Checked = false ;
                  }
                  
                  __Configuration.IncludeViewer = IncludeViewerCheckBox.Checked ;
                  
                  UpdateDisplayTotalSize ( ) ;
                  
                  OnChanged ( ) ;
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }

            void GenerateViewerButton_Click ( object sender, EventArgs e )
            {
               try
               {
                  string autoGeneratedFile ;
                  string viewerFolder ;
                  
                  
                  
                  viewerFolder = PrepareViewerDirectory ( out autoGeneratedFile ) ;
                  
                  if ( !string.IsNullOrEmpty ( autoGeneratedFile ) )
                  {
                     if ( !__Configuration.Files.Contains ( autoGeneratedFile ) )
                     {
                        if ( DialogResult.Yes == Messager.ShowQuestion ( this, "Do you want to add an Autorun file on the media to run the Workstation Media Viewer?", MessageBoxButtons.YesNo ) )
                        {
                           double filesSize ;
                           
                           
                           filesSize = GetFileSize ( autoGeneratedFile ) ;
                           
                           __Configuration.FilesAndFoldersSize += filesSize ;
                           
                           __Configuration.AddViewerAutorunFile ( autoGeneratedFile ) ;
                           
                           RefreshFilesList ( ) ;
                        }
                     }
                     else
                     {
                        __Configuration.AddViewerAutorunFile ( autoGeneratedFile ) ;
                        
                        RefreshFilesList ( ) ;
                     }
                  }
                  
                  UpdateSelectedViewer ( viewerFolder ) ;
                  
                  IncludeViewerCheckBox.Checked = true ;
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }

            void BrowseMediaBaseFolderButton_Click(object sender, EventArgs e)
            {
               try
               {
                  using ( FolderBrowserDialog folderDialog = new FolderBrowserDialog ( ) )
                  {
                     if ( folderDialog.ShowDialog ( ) == DialogResult.OK ) 
                     {
                        MediaBaseFolderTextBox.Text = folderDialog.SelectedPath ;
                        __Configuration.MediaFolder = folderDialog.SelectedPath ;
                        
                        OnChanged ( ) ;
                     }
                  }
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }
            
            
            void SaveButton_Click ( object sender, EventArgs e )
            {
               try
               {
                  OnSaveChanges ( ) ;
               }
               catch ( Exception exception )
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }

         #endregion
         
         #region Data Members

            private ToolTip _tooltip ;
               
            private string[] _viewerBinaries = new string[] {  "AWCODC32.DLL",
                                                               "AWDCXC32.DLL",
                                                               "AWDENC32.DLL",
                                                               "AWRESX32.DLL",
                                                               "AWVIEW32.DLL",
                                                               "CDRAPCLS.dll",
                                                               "CDSDK.dll",
                                                               "czs_ui.dll",
                                                               "DC120V154_32.dll",
                                                               "DCSPro3SLR.dll",
                                                               "DCSProBack.dll",
                                                               "deimg.dll",
                                                               "deImg010.dll",
                                                               "deImg110.dll",
                                                               "deImg153.dll",
                                                               "deimg301.dll",
                                                               "deimg401.dll",
                                                               "deImg404.dll",
                                                               "deimg602.dll",
                                                               "Deimg603.dll",
                                                               "DeImgd60.dll",
                                                               "DocumentFormat.OpenXml.dll",
                                                               "ekfpixjpeg140.dll",
                                                               "Leadtools.Annotations.dll",
                                                               "Leadtools.Codecs.Bmp.dll",
                                                               "Leadtools.Codecs.Cmp.dll",
                                                               "Leadtools.Codecs.Cmw.dll",
                                                               "Leadtools.Codecs.dll",
                                                               "Leadtools.Codecs.Gif.dll",
                                                               "Leadtools.Codecs.Img.dll",
                                                               "Leadtools.Codecs.J2k.dll",
                                                               "Leadtools.Codecs.Jb2.dll",
                                                               "Leadtools.Codecs.Jbg.dll",
                                                               "Leadtools.Codecs.Tif.dll",
                                                               "Leadtools.ColorConversion.dll",
                                                               "Leadtools.Compatibility.dll",
                                                               "Leadtools.Dicom.AddIn.dll",
                                                               "Leadtools.Dicom.Annotations.dll",
                                                               "Leadtools.Dicom.Common.dll",
                                                               "Leadtools.Dicom.dll",
                                                               "Leadtools.Dicom.Scp.dll",
                                                               "Leadtools.Dicom.Scu.dll",
                                                               "Leadtools.Dicom.Server.Admin.dll",
                                                               "Leadtools.dll",
                                                               "Leadtools.Drawing.dll",
                                                               "Leadtools.ImageOptimization.dll",
                                                               "Leadtools.ImageProcessing.Color.dll",
                                                               "Leadtools.ImageProcessing.Core.dll",
                                                               "Leadtools.ImageProcessing.Effects.dll",
                                                               "Leadtools.ImageProcessing.SpecialEffects.dll",
                                                               "Leadtools.ImageProcessing.Utilities.dll",
                                                               "Leadtools.Jpeg2000.dll",
                                                               "Leadtools.Kernel.Annotations.dll",
                                                               "Leadtools.Logging.dll",
                                                               "Leadtools.Logging.Medical.dll",
                                                               "Leadtools.MediaWriter.dll",
                                                               "Leadtools.Medical.DataAccessLayer.dll",
                                                               "Leadtools.Medical.Logging.DataAccessLayer.dll",
                                                               "Leadtools.Medical.Media.AddIns.dll",
                                                               "Leadtools.Medical.Media.DataAccessLayer.dll",
                                                               "Leadtools.Medical.Storage.AddIns.dll",
                                                               "Leadtools.Medical.Storage.DataAccessLayer.dll",
                                                               "Leadtools.Medical.UserManagementDataAccessLayer.dll",
                                                               "Leadtools.Medical.Winforms.dll",
                                                               "Leadtools.Medical.Worklist.AddIns.dll",
                                                               "Leadtools.Medical.Worklist.DataAccessLayer.dll",
                                                               "Leadtools.Medical.Workstation.Client.dll",
                                                               "Leadtools.Medical.Workstation.DataAccessLayer.dll",
                                                               "Leadtools.Medical.Workstation.dll",
                                                               "Leadtools.Medical.Workstation.Loader.dll",
                                                               "Leadtools.Medical3d.dll",
                                                               "Leadtools.Medical3D.Engine9.dll",
                                                               "Leadtools.MedicalViewer.dll",
                                                               "Leadtools.Mrc.dll",
                                                               "Leadtools.SpecialEffects.dll",
                                                               "Leadtools.WinForms.CommonDialogs.Color.dll",
                                                               "Leadtools.WinForms.CommonDialogs.File.dll",
                                                               "Leadtools.WinForms.Design.dll",
                                                               "Leadtools.WinForms.dll",
                                                               "Ltcryu.dll",
                                                               "Ltfpxu.dll",
                                                               "Ltkdku.dll",
                                                               "Lttlsu.dll",
                                                               "mfc90.dll",
                                                               "mfc90u.dll",
                                                               "mfcm90.dll",
                                                               "mfcm90u.dll",
                                                               "Microsoft.Practices.EnterpriseLibrary.Common.dll",
                                                               "Microsoft.Practices.EnterpriseLibrary.Data.dll",
                                                               "Microsoft.Practices.EnterpriseLibrary.Data.SqlCe.dll",
                                                               "Microsoft.Practices.EnterpriseLibrary.Logging.dll",
                                                               "Microsoft.Practices.ObjectBuilder2.dll",
                                                               "Microsoft.Practices.Unity.dll",
                                                               "msvcm90.dll",
                                                               "msvcp90.dll",
                                                               "msvcr90.dll",
                                                               "NCScnet.dll",
                                                               "NCSEcw.dll",
                                                               "NCSEcwC.dll",
                                                               "NCSUtil.dll",
                                                               "PCDLIB32.DLL",
                                                               "PDC_SDK.dll",
                                                               "ProFire.dll",
                                                               "pscAdimg.dll",
                                                               "pscCllct.dll",
                                                               "pscCStUI.dll",
                                                               "pscDcd.dll",
                                                               "pscDevUI.dll",
                                                               "pscDvlp.dll",
                                                               "Pscl2STI.dll",
                                                               "pscll.dll",
                                                               "pscParse.dll",
                                                               "pscSetup.dll",
                                                               "psdkdll.dll",
                                                               "psdkReg.dll",
                                                               "psParse.dll",
                                                               "sqlceca35.dll",
                                                               "sqlcecompact35.dll",
                                                               "sqlceer35EN.dll",
                                                               "sqlceme35.dll",
                                                               "sqlceoledb35.dll",
                                                               "sqlceqp35.dll",
                                                               "sqlcese35.dll",
                                                               "System.Data.SQLite.DLL",
                                                               "System.Data.SqlServerCe.dll",
                                                               "System.Data.SqlServerCe.Entity.dll",
                                                               "unicows.dll",
                                                               "Microsoft.VC90.CRT.manifest",
                                                               "Microsoft.VC90.MFC.manifest ",
                                                               "splash.png",
                                                               "app.ico",
                                                               "ViewerCommon.config",
                                                               "Leadtools.Dicom.Tables.dll"
                                                               } ;
            
         #endregion
         
         #region Data Types Definition
            
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
