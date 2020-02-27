// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using Microsoft.Win32;
using Leadtools;
using Leadtools.Demos;
using Leadtools.Jpip;
using Leadtools.Jpip.Client.InteractiveDecoder;
using Leadtools.Jpip.Client.WinForms;
using System.Net;

#if ! LEADTOOLS_V17_OR_LATER
using LeadPoint = System.Drawing.Point;
using LeadSize = System.Drawing.Size;
using LeadRect = System.Drawing.Rectangle;
#endif // #if !LEADTOOLS_V17_OR_LATER

#if LEADTOOLS_V17_OR_LATER
using Leadtools.Drawing;
#endif // #if LEADTOOLS_V17_OR_LATER

#if LEADTOOLS_V19_OR_LATER
using Leadtools.Demos.Dialogs;
#endif

namespace JpipClientDemo
{
   public partial class MainForm : Form
   {
      const string MainFormTitle = "JPIP Client Demo";
      private JpipRasterImageViewer _jpipRasterImageViewer = null;
      private FileOpenDialog _jpipOpenFileDlg = null;
      
      public MainForm()
      {
         InitializeComponent();

         this.Text = MainFormTitle;

         Messager.Caption = this.Text;

         _jpipOpenFileDlg = new FileOpenDialog();

         _jpipRasterImageViewer = new JpipRasterImageViewer();

         _jpipRasterImageViewer.TotalBytesLoaded += this.TotalBytesLoaded;
         _jpipRasterImageViewer.StreamingError += this.OnError;
         _jpipRasterImageViewer.FileOpened += new EventHandler(_jpipRasterImageViewer_FileOpened);
         _jpipRasterImageViewer.ProgressStatusUpdated += new EventHandler<ProgressStatusUpdatedEventArgs>(_jpipRasterImageViewer_ProgressStatusUpdated);
         _jpipRasterImageViewer.ResolutionChanged += new EventHandler<ResolutionChangedEventArgs>(_jpipRasterImageViewer_ResolutionChanged);
         _jpipRasterImageViewer.CodeStreamRequest += new EventHandler<CodeStreamRequestEventArgs>(_jpipRasterImageViewer_CodeStreamRequest);

         AppSettingsReader configReader = new AppSettingsReader();
         string cacheDirectory = null ;
         try
         {
            cacheDirectory = (string)configReader.GetValue("CacheDirectoryName", typeof(string));
         }
         catch ( Exception )
         {
            cacheDirectory = null ;
         }
         
         if ( string.IsNullOrEmpty ( cacheDirectory ) || 
              !Directory.Exists(cacheDirectory) )
         {
              cacheDirectory = LEADToolsImagesFolder ;
         }

         try { _jpipRasterImageViewer.CacheDirectoryName = cacheDirectory; } catch (Exception ex) { ShowErrorMessage(this, ex); }
         try { _jpipRasterImageViewer.PortNumber = (int)configReader.GetValue("PortNumber", typeof(int)); } catch (Exception ) { _jpipRasterImageViewer.PortNumber = 49201; }
         try { _jpipRasterImageViewer.IPAddress = (string)configReader.GetValue("IPAddress", typeof(string)); } catch (Exception ) { _jpipRasterImageViewer.IPAddress = "127.0.0.1"; }
         try { _jpipRasterImageViewer.PacketSize = (int)configReader.GetValue("PacketSize", typeof(int)); } catch (Exception ) { _jpipRasterImageViewer.PacketSize = 16384 ; }
         try { _jpipRasterImageViewer.RequestTimeout = TimeSpan.FromSeconds(((double)configReader.GetValue("RequestTimeout", typeof(double)))); } catch (Exception ) { _jpipRasterImageViewer.RequestTimeout = TimeSpan.FromSeconds(60) ; }
         try { _jpipRasterImageViewer.ChannelType = (string)configReader.GetValue("ChannelType", typeof(string)); } catch (Exception ) { _jpipRasterImageViewer.ChannelType = "http"; }
         try { _jpipOpenFileDlg.ServiceIpAddress = (string)configReader.GetValue("IPAddress", typeof(string)); } catch (Exception ) { _jpipOpenFileDlg.ServiceIpAddress = "127.0.0.1" ; }
         try { _jpipOpenFileDlg.ServicePort = (int)configReader.GetValue("FileEnumerationPortNumber", typeof(int)); } catch (Exception ) { _jpipOpenFileDlg.ServicePort = 49202; }

         switch (_jpipRasterImageViewer.InteractiveMode)
         {
            case Leadtools.WinForms.RasterViewerInteractiveMode.Pan:
               this.panToolStripMenuItem.Checked = true;
               this.zoomToolStripMenuItem.Checked = false;
               break;

            default:
               this.panToolStripMenuItem.Checked = false;
               this.zoomToolStripMenuItem.Checked = true;
               break;
         }

         EnableControls(false);
         _jpipRasterImageViewer.Dock = DockStyle.Fill ;
         this.Controls.Add(_jpipRasterImageViewer);
         _jpipRasterImageViewer.BringToFront();
      }

      void _jpipRasterImageViewer_CodeStreamRequest(object sender, CodeStreamRequestEventArgs e)
      {
         if ( InvokeRequired ) 
         {
            this.Invoke ( new EventHandler < CodeStreamRequestEventArgs > ( _jpipRasterImageViewer_CodeStreamRequest ),
                          new object [ ] { sender, e } ) ;
                          
            return ;
         }
         else
         {
            UpdateCodeStreamCount ( ) ;
            
            EnableControls ( true ) ;
         }
      }

      void _jpipRasterImageViewer_ResolutionChanged ( object sender, ResolutionChangedEventArgs e )
      {
         UpdateCurrentSizeText ( e.ImageSize ) ;
         UpdateImageSizeText ( ) ;
      }

      void _jpipRasterImageViewer_ProgressStatusUpdated(object sender, ProgressStatusUpdatedEventArgs e)
      {
         if ( InvokeRequired )
         {
            Invoke ( new MethodInvoker(delegate()
                                       {
                                          UpdateProgressStatus(e.Status);
                                       } ) )  ;
         }
         else
         {
            UpdateProgressStatus(e.Status) ;
         }
      }
      
      private void UpdateProgressStatus ( ProgressStatus status )
      {
         switch ( status )
         {
            case ProgressStatus.Completed:
            {
               progressStatusLabel.Text = "Image Completely Streamed" ;
            }
            
            break ;
            
            case ProgressStatus.Disconnected:
            {
               progressStatusLabel.Text = "Disconnected" ;
            }
            
            break ;
            
            case ProgressStatus.Idle:
            {
               progressStatusLabel.Text = "Region Loaded" ;
            }
            
            break ;
            
            case ProgressStatus.Streaming:
            {
               progressStatusLabel.Text = "Streaming..." ;
            }
            
            break ;
         }
      }

      void _jpipRasterImageViewer_FileOpened(object sender, EventArgs e)
      {
         if ( InvokeRequired )
         {
            this.Invoke(new MethodInvoker(delegate()
            {
               EnableControls(true);
               UpdateComponentIndexText();
               UpdateImageSizeText();
               UpdateCodeStreamCount ( ) ;
               
               AddResolutionsMenu();
            } ) ) ;
         }
         else
         {
            EnableControls(true);
            UpdateComponentIndexText();
            UpdateImageSizeText();
            
            AddResolutionsMenu();
         }
      }

      private void ConnectionToolStripMenuItem_Click(object sender, EventArgs e)
      {
         try
         {
            ConnectionDialog connectionDialog = new ConnectionDialog();

            connectionDialog.CacheDirectoryName = _jpipRasterImageViewer.CacheDirectoryName;
            connectionDialog.PortNumber         = _jpipRasterImageViewer.PortNumber;
            connectionDialog.IpAddress          = _jpipRasterImageViewer.IPAddress;
            connectionDialog.PacketSize         = _jpipRasterImageViewer.PacketSize;
            connectionDialog.RequestTimeout     = _jpipRasterImageViewer.RequestTimeout;
            connectionDialog.ChannelType        = _jpipRasterImageViewer.ChannelType;
            connectionDialog.EnumerationServicePort = _jpipOpenFileDlg.ServicePort ;

            if (connectionDialog.ShowDialog() == DialogResult.OK)
            {
               _jpipRasterImageViewer.CacheDirectoryName = connectionDialog.CacheDirectoryName;
               _jpipRasterImageViewer.PortNumber = connectionDialog.PortNumber;
               _jpipRasterImageViewer.IPAddress = connectionDialog.IpAddress;
               _jpipRasterImageViewer.PacketSize = connectionDialog.PacketSize;
               _jpipRasterImageViewer.RequestTimeout = connectionDialog.RequestTimeout;
               _jpipRasterImageViewer.ChannelType = connectionDialog.ChannelType;
               
               _jpipOpenFileDlg.ServiceIpAddress = connectionDialog.IpAddress ;
               _jpipOpenFileDlg.ServicePort      = connectionDialog.EnumerationServicePort ;
            }
         }
         catch (Exception ex)
         {
            ShowErrorMessage(this, ex);
         }
      }

      private void SaveAppSettings()
      {
         try
         {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            if ( null == config ) 
            {
               return ;
            }

            AddConfigurationValue ( config,"CacheDirectoryName", _jpipRasterImageViewer.CacheDirectoryName );
            AddConfigurationValue ( config,"PortNumber", _jpipRasterImageViewer.PortNumber.ToString() );
            AddConfigurationValue ( config,"IPAddress", _jpipRasterImageViewer.IPAddress );
            AddConfigurationValue ( config,"PacketSize", _jpipRasterImageViewer.PacketSize.ToString() );
            AddConfigurationValue ( config,"RequestTimeout", _jpipRasterImageViewer.RequestTimeout.TotalSeconds.ToString() );
            AddConfigurationValue ( config,"ChannelType", _jpipRasterImageViewer.ChannelType );
            AddConfigurationValue ( config,"FileEnumerationPortNumber", _jpipOpenFileDlg.ServicePort.ToString ( ) );
            
            config.Save(ConfigurationSaveMode.Modified);
            
            ConfigurationManager.RefreshSection("appSettings");
         }
         catch ( Exception exception )
         {
            Messager.ShowError ( this, string.Format ( "Can't write configuration settings, error is:\n{0}", exception.Message ) ) ;
         }
      }

      private void AddConfigurationValue
      ( 
         System.Configuration.Configuration config, 
         string key, 
         string value  
      )
      {
         if (null == config.AppSettings.Settings[key])
         {
            config.AppSettings.Settings.Add(key, value);
         }
         else
         {
            config.AppSettings.Settings[key].Value = value;
         }
      }
      
      private void NextComponentBottom_Click(object sender, EventArgs e)
      {
         _jpipRasterImageViewer.ComponentIndex++;
         UpdateComponentIndexText ( ) ;
      }

      private void ShowAllBottom_Click(object sender, EventArgs e)
      {
         _jpipRasterImageViewer.ComponentIndex = -1;
         UpdateComponentIndexText();
      }

      private void CleanCacheButton_Click(object sender, EventArgs e)
      {
         if (_jpipRasterImageViewer != null)
         {
            DialogResult result = Messager.ShowQuestion(this, "Are you sure you want to clear all cache contents?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
               try
               {
                  _jpipRasterImageViewer.DeleteCacheFiles();
               }
               catch (Exception exception)
               {
                  ShowErrorMessage(this, exception);  
               }
            }
         }
      }

      private void PanZoom_Click(object sender, EventArgs e)
      {
         this.panToolStripMenuItem.Checked = !this.panToolStripMenuItem.Checked;
         this.zoomToolStripMenuItem.Checked = !this.zoomToolStripMenuItem.Checked;

         if (this.panToolStripMenuItem.Checked == true)
            _jpipRasterImageViewer.InteractiveMode = Leadtools.WinForms.RasterViewerInteractiveMode.Pan;
         else
            _jpipRasterImageViewer.InteractiveMode = Leadtools.WinForms.RasterViewerInteractiveMode.None;
      }

      private void ZoomIn_Click(object sender, EventArgs e)
      {
         try
         {
            _jpipRasterImageViewer.ZoomIn();
         }
         catch (Exception ex)
         {
            ShowErrorMessage(this, ex);
         }
      }

      private void ZoomOut_Click(object sender, EventArgs e)
      {
         try
         {
            _jpipRasterImageViewer.ZoomOut();
         }
         catch (Exception ex)
         {
            ShowErrorMessage(this, ex);
         }
      }

      private void ResolutionsToolStripDropDownButton_DropDownOpened(object sender, EventArgs e)
      {
         int currentResolutionIndex ;
         
         
         currentResolutionIndex = _jpipRasterImageViewer.CurrentResolutionIndex ;
         
         if ( currentResolutionIndex >= 0 && currentResolutionIndex < resolutionsToolStripDropDownButton.DropDownItems.Count )
         {
            this.resolutionsToolStripDropDownButton.DropDownItems [ currentResolutionIndex ].Select();
         }
      }

      void OnResolutionsMenuButtonClick(object sender, EventArgs e)
      {
         try
         {
            int index = this.resolutionsToolStripDropDownButton.DropDownItems.IndexOf((ToolStripItem)sender);
            System.Diagnostics.Debug.WriteLine(" Resolution = " + _jpipRasterImageViewer.GetResolutionSize(index));
            _jpipRasterImageViewer.Zoom(_jpipRasterImageViewer.GetResolutionSize(index));
         }
         catch (Exception ex)
         {
            ShowErrorMessage(this, ex);
         }
      }

      private void OpenFileToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (_jpipOpenFileDlg.ShowDialog() == DialogResult.OK)
         {
            try
            {
               CloseToolStripMenuItem_Click ( this, new EventArgs ( ) ) ;
               
               _jpipRasterImageViewer.Close();
               if (_jpipOpenFileDlg.FileName == null)
                  throw new Exception("A file must be selected");

               //Use Dns.GetHostAddresses to get an actual IP just in case the provided address is a DNS. If
               //it is already an IP, the IP address will not be changed.
               _jpipRasterImageViewer.IPAddress = Dns.GetHostAddresses(_jpipRasterImageViewer.IPAddress)[0].ToString();
               _jpipRasterImageViewer.Open(_jpipOpenFileDlg.FileName ) ;
            }
            catch (Exception ex)
            {
               ShowErrorMessage(this, ex);
            }
         }
      }

      private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
      {
         try
         {
            
            this.Text = MainFormTitle;
            _jpipRasterImageViewer.Close();
            UpdateComponentIndexText();
            UpdateImageSizeText();
            UpdateCurrentSizeText( LeadSize.Empty );
            UpdateCodeStreamCount ( ) ;
            
            this.resolutionsToolStripDropDownButton.DropDownItems.Clear();
            ByteCount.Text = "" ;
            progressStatusLabel.Text = "" ;
            EnableControls(false);
         }
         catch (Exception exception)
         {
            ShowErrorMessage(this, exception);
         }
      }

      private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      private void TotalBytesLoaded(object sender, TotalBytesLoadedEventArgs e)
      {

         if (InvokeRequired)
         {
            this.Invoke(new MethodInvoker(delegate()
            {
               double bytesLoaded =  ( (double)e.ByteCount / 1024 ) ;
               
               this.ByteCount.Text = String.Format ( " Loaded bytes: {0} KB", bytesLoaded.ToString ( "0.0" ) ) ;
            }));
         }
         else
         {
            double bytesLoaded = ((double)e.ByteCount / 1024);

            this.ByteCount.Text = String.Format(" Loaded bytes: {0} KB", bytesLoaded.ToString ( "0.0" ) ) ;
         }
      }

      private void OnError(object sender, System.IO.ErrorEventArgs e)
      {
         if (InvokeRequired)
         {
            this.BeginInvoke(new MethodInvoker(delegate()
            {
               ShowErrorMessage(this, e.GetException());
            }));
         }
         else
         {
            ShowErrorMessage(this, e.GetException());
         }
      }

      private void AddResolutionsMenu ( )
      {
         try
         {
            this.resolutionsToolStripDropDownButton.DropDownItems.Clear();
            if (_jpipRasterImageViewer != null && _jpipRasterImageViewer.IsActive == true)
            {
               int numOfRes = _jpipRasterImageViewer.NumberOfResolutions;
               for (int r = 0; r < numOfRes; r++)
               {
                  LeadSize resSize = _jpipRasterImageViewer.GetResolutionSize(r);
                  string sizeString = resSize.Width.ToString() + "x" + resSize.Height.ToString();
                  this.resolutionsToolStripDropDownButton.DropDownItems.Add(sizeString, null, new EventHandler(OnResolutionsMenuButtonClick));
               }
            }
         }
         catch (Exception ex)
         {
            ShowErrorMessage(this, ex);
         }
      }

      private void UpdateCodeStreamCount ( ) 
      {
         int codeStreamCount = 0 ;
         int codestreamIndex = 0 ;
         
         
         if (_jpipRasterImageViewer != null && _jpipRasterImageViewer.IsActive == true)
         {
               codeStreamCount  = _jpipRasterImageViewer.CodeStreamCount ;
               codestreamIndex  = _jpipRasterImageViewer.CodeStream + 1 ;
         }
         
         this.CodeStreamCount.Text = string.Format ( " [Number Of Frames: ({0}), Current: {1}]", 
                                                     codeStreamCount,
                                                     codestreamIndex );
      }
      
      private void UpdateImageSizeText()
      {
         int width = 0;
         int height = 0;
         if (_jpipRasterImageViewer != null && _jpipRasterImageViewer.IsActive == true)
         {
            width = _jpipRasterImageViewer.FullImageSize.Width;
            height = _jpipRasterImageViewer.FullImageSize.Height;
         }
         
         this.ImageSize.Text = string.Format("Full Size: ({0},{1})", width, height);
      }

      private void UpdateCurrentSizeText ( LeadSize imageSize ) 
      {
         this.CurrentSize.Text = string.Format("Current Size: ({0},{1})", imageSize.Width, imageSize.Height);
      }

      private void UpdateComponentIndexText()
      {
         if (_jpipRasterImageViewer != null && _jpipRasterImageViewer.IsActive == true)
         {
            if (_jpipRasterImageViewer.ComponentIndex < 0)
               this.CompIndex.Text = string.Format("Comp Index: All");
            else
               this.CompIndex.Text = string.Format("Comp Index: {0}", _jpipRasterImageViewer.ComponentIndex);
         }
         else
            this.CompIndex.Text = "";
      }

      private void EnableControls(bool isEnabled)
      {
         this.modeToolStripMenuItem.Enabled = isEnabled;
         this.panToolStripMenuItem.Enabled = isEnabled;
         this.zoomToolStripMenuItem.Enabled = isEnabled;

         this.zoomIntoolStripButton.Enabled = isEnabled;
         this.zoomOuttoolStripButton.Enabled = isEnabled;
         this.nextComptoolStripButton.Enabled = isEnabled;
         this.showAllComptoolStripButton.Enabled = isEnabled;
         this.resolutionsToolStripDropDownButton.Enabled = isEnabled;

         this.viewToolStripMenuItem.Enabled = isEnabled;
         this.zoomIntoolStripMenuItem.Enabled = isEnabled;
         this.zoomOuttoolStripMenuItem.Enabled = isEnabled;
         this.nextComponentToolStripMenuItem.Enabled = isEnabled;
         this.showAllComponenetsToolStripMenuItem1.Enabled = isEnabled;
         this.modeToolStripMenuItem.Enabled = isEnabled;
         this.panToolStripMenuItem.Enabled = isEnabled;
         this.zoomToolStripMenuItem.Enabled = isEnabled;
         
         if ( isEnabled ) 
         {
            if ( _jpipRasterImageViewer.CodeStreamCount > 0 )
            {
               if ( _jpipRasterImageViewer.CodeStream <  _jpipRasterImageViewer.CodeStreamCount - 1 ) 
               {
                  nextCodeStreamToolStripButton.Enabled = isEnabled ;
               }
               
               if ( _jpipRasterImageViewer.CodeStream >  0 ) 
               {
                  previousCodeStreamToolStripButton.Enabled = isEnabled ;
               }
            }
            else
            {
               nextCodeStreamToolStripButton.Enabled     = false  ;
               previousCodeStreamToolStripButton.Enabled = false ;
            }
         }
         else
         {
            nextCodeStreamToolStripButton.Enabled     = false  ;
            previousCodeStreamToolStripButton.Enabled = false ;
         }
      }

      private void ShowErrorMessage(IWin32Window owner, Exception ex)
      {
         if ( IsDisposed )
         {
            return ;
         }
         
         string message;
         message = ex.Message;
         if (ex is System.Net.WebException)
         {
            System.Net.WebException webExc = (System.Net.WebException)ex;
            if ((null != webExc.Response) && (webExc.Response is System.Net.HttpWebResponse))
            {
               System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)webExc.Response;
               message += "\nServer Error:\n" + response.StatusDescription;
            }
         }
         Messager.ShowError(owner, message);
      }

      private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
      {
#if LEADTOOLS_V19_OR_LATER
         using (AboutDialog aboutDialog = new AboutDialog("JPIP Client", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
#else
         using (AboutDialog aboutDialog = new AboutDialog("JPIP Client"))
            aboutDialog.ShowDialog(this);
#endif
      }

      private static string LEADToolsImagesFolder
      {
         get
         {
            return DemosGlobal.ImagesFolder ;
         }
      }

      private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (!RasterSupport.KernelExpired)
         {
            _jpipRasterImageViewer.Close();
            SaveAppSettings();
            _jpipRasterImageViewer = null;
         }
      }

      private void nextCodeStreamIndexToolStripButton_Click(object sender, EventArgs e)
      {
         try
         {
            int streamCount ;
            
            
            streamCount = _jpipRasterImageViewer.CodeStreamCount ;
            
            if ( _jpipRasterImageViewer.CodeStream >= streamCount - 1 )
            {
               return ;
            }
            
            _jpipRasterImageViewer.SetCodeStreamIndex ( _jpipRasterImageViewer.CodeStream + 1 ) ;
            
            EnableControls ( false ) ;
         }
         catch ( Exception exception )
         {
            MessageBox.Show ( exception.Message, "JPIP Client" ) ;
         }
      }

      private void previousCodeStreamToolStripButton_Click(object sender, EventArgs e)
      {
         if (_jpipRasterImageViewer.CodeStream <= 0)
         {
            return;
         }

         _jpipRasterImageViewer.SetCodeStreamIndex(_jpipRasterImageViewer.CodeStream - 1);

         EnableControls ( false ) ;
      }

      private void resolutionsToolStripDropDownButton_DropDownOpening(object sender, EventArgs e)
      {
         AddResolutionsMenu ( ) ;
      }
      
      private void howToToolStripMenuItem_Click(object sender, EventArgs e)
      {
         try
         {
            DemosGlobal.LaunchHowTo("Jpip.html");
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex.Message);
         } 
      }

      private void MainForm_Load(object sender, EventArgs e)
      {
         AppSettingsReader configReader = new AppSettingsReader();
         bool showOverview ;
         
         
         try
         {
            showOverview = (bool)configReader.GetValue("ShowOverView", typeof(bool));
         }
         catch ( Exception )
         {
            showOverview = true ;
         }
         
         
         if ( showOverview ) 
         {
            DemoOverViewDialog overviewDlg ;
            
            
            
            overviewDlg = new DemoOverViewDialog ( ) ;
            
            overviewDlg.TopLevel = true ;
            
            overviewDlg.Show ( this ) ;
         }

      }
   }
}
