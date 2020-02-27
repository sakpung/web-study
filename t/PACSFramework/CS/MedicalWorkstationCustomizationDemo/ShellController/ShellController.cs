// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System ;
using System.Collections.Generic ;
using System.Linq ;
using System.Text ;
using Leadtools.Medical.Workstation.UI;
using Leadtools.Medical.Workstation.UI.Factory;
using Leadtools.Demos.Workstation.UI;
using System.Windows.Forms;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Leadtools.Medical.Workstation.Loader;
using Leadtools.Medical.Workstation;
using Leadtools.Medical.Workstation.Client.Local;
using System.Drawing;
using System.IO;
using Leadtools.MedicalViewer;

namespace Leadtools.Demos.Workstation.Customized
{
   class WorkstationShellController
   {
      #region Public
         
         #region Methods
         
            public void Run ( ) 
            {
               MainForm          mainForm ;
               WorkstationViewer viewer ;
               ExamplesMenuStrip examplesMenu ;
               TextBox           examplesDescription ;
               


               Messager.Caption            = "Workstation Customization Demo" ;
               WorkstationMessager.Caption = "Workstation Customization Demo" ;

               WorkstationUISettings.Instance.Controls.Add ( new NameTypeConfigurationElement ( UIElementKeys.WorkstastionControl, 
                                                                                                typeof ( WorkstationViewer ) ) ) ;
               
               WorkstationUISettings.Instance.Controls.Add ( new NameTypeConfigurationElement ( UIElementKeys.ExamplesMenuStrip, 
                                                                                                typeof ( ExamplesMenuStrip ) ) ) ;
               
               WorkstationUISettings.Instance.Controls.Add ( new NameTypeConfigurationElement ( UIElementKeys.ExamplesDescription, 
                                                                                                typeof ( TextBox ) ) ) ;
               
               viewer       = WorkstationUIFactory.Instance.GetWorkstsationControl <WorkstationViewer> ( UIElementKeys.WorkstastionControl ) ;
               viewer.Options3D.SupportPanoramic = true;
               examplesMenu = WorkstationUIFactory.Instance.GetWorkstsationControl <ExamplesMenuStrip> ( UIElementKeys.ExamplesMenuStrip ) ;
               examplesDescription = WorkstationUIFactory.Instance.GetWorkstsationControl <TextBox> ( UIElementKeys.ExamplesDescription ) ;
            
               try
               {
                  mainForm = new MainForm ( ) ;
                  
                  viewer.Dock = DockStyle.Fill ;
                  
                  mainForm.MainMenuStrip = examplesMenu ;
                  
                  mainForm.Controls.Add ( viewer ) ;
                  mainForm.Controls.Add ( examplesMenu ) ;
                  
                  viewer.BringToFront ( ) ;
                  
                  examplesDescription.Dock      = DockStyle.Fill ;
                  examplesDescription.Multiline = true ;
                  examplesDescription.ReadOnly  = true ;
                  examplesDescription.BackColor = Color.Black ;
                  examplesDescription.ForeColor = Color.White ;
                  
                  mainForm.DescriptionPanel.Controls.Add ( examplesDescription ) ;
                  
                  examplesDescription.BringToFront ( ) ;
                  
                  __ViewerContainer = viewer.ViewerContainer ;
                  
                  __ViewerContainer.State.ModalityManager.FillDefaultOptions ( ) ;
                  
                  viewer.SeriesDropLoaderRequested += new EventHandler<SeriesDropLoaderRequestedEventArgs> ( viewer_SeriesDropLoaderRequested ) ;

                  viewer.SeriesLoadingCompleted += new EventHandler<LoadSeriesEventArgs>(viewer_SeriesLoadingCompleted);
                  
                  new WorkstationCustomizationController ( ) ;
                  
                  Application.Run ( mainForm ) ;
               }
               catch ( Exception ex ) 
               {
                  ViewErrorDetailsDialog detailedError ;
                  
                  
                  detailedError = new ViewErrorDetailsDialog ( ex ) ;
                  
                  detailedError.ShowDialog ( ) ;
               }
               finally
               {
                  if ( null != viewer && 
                       !viewer.IsDisposed )
                  {
                     viewer.Dispose ( ) ;
                  }
               }
            }

            void viewer_SeriesLoadingCompleted(object sender, LoadSeriesEventArgs e)
            {
               foreach ( MedicalViewerMultiCell cell in e.LoadedSeries.Streamer.SeriesCells )
               {
                  cell.ProbeToolTextChanged += new EventHandler<MedicalViewerProbeToolTextChangedEventArgs>(cell_ProbeToolTextChanged);
               }
            }

            void viewer_SeriesDropLoaderRequested ( object sender, SeriesDropLoaderRequestedEventArgs e )
            {
               if ( __ViewerContainer.ArgumentsService.Exists <LoadSeriesFromDicomDirCommandArgument> ( ) )
               {
                  string                 dicomDir ;
                  DicomDirRetrieveClient client ;
                  
                  dicomDir = __ViewerContainer.ArgumentsService.PopArgument <LoadSeriesFromDicomDirCommandArgument> ( ).DicomDirFile ;
                  
                  client = new DicomDirRetrieveClient ( null, 
                                                        dicomDir ) ;
                                                        
                  e.SeriesLoader = new MedicalViewerLoader ( client ) ;
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
         
           private string GetRealPixelValue(RasterImage image, int x, int y)
           {
               LeadPoint bitmapPoint = image.PointToImage(RasterViewPerspective.TopLeft, new LeadPoint(x, y));

               x = bitmapPoint.X;
               y = bitmapPoint.Y;

               if (x >= 0 && y >= 0)
                   if ((image.Width >= x) && (image.Height >= y))
                   {
                       byte[] Data;
                       Int16 Value;
                       UInt16 uValue;

                       // just work with extended gray scale here
                       if (image.GrayscaleMode != RasterGrayscaleMode.None && image.BitsPerPixel > 8)
                       {
                           Data = image.GetPixelData(y, x);
                           if (image.Signed)
                           {
                               Int16 highBit;
                               if (image.HighBit == 0)
                               {
                                   highBit = (Int16)(image.BitsPerPixel - 1);
                               }
                               else
                                   highBit = (Int16)image.HighBit;

                               Value = BitConverter.ToInt16(Data, 0);
                               // account for when all allocated bits are not used for image data encoding
                               if ((image.HighBit < (image.BitsPerPixel - 1)) | (image.LowBit > 0))
                               {
                                   // actual image low bit is not 0
                                   if (image.LowBit != 0)
                                   {
                                       Value = (Int16)(Value >> image.LowBit);
                                       highBit = (Int16)(image.HighBit - image.LowBit);
                                   }

                                   // see if the value is negative 
                                   Int16 signLimit;
                                   signLimit = (Int16)(Math.Pow(2, highBit + 1) / 2);
                                   if (Value >= signLimit)
                                   {
                                       Value = (Int16)(Value - (Math.Pow(2, highBit + 1)));
                                   }
                               }

                               return Value.ToString();
                           }
                           else
                           {
                               uValue = BitConverter.ToUInt16(Data, 0);
                               // when low bit is not zero
                               if (image.LowBit > 0)
                               {
                                   uValue = (UInt16)(uValue >> image.LowBit);
                               }
                               return uValue.ToString();
                           }
                       }
                       else
                       {
                           int R;
                           int G;
                           int B;

                           if (image.BitsPerPixel > 32)
                           {
                               byte[] bit16ComponentData;
                               bit16ComponentData = image.GetPixelData(y, x);
                               R = BitConverter.ToUInt16(bit16ComponentData, 0);
                               G = BitConverter.ToUInt16(bit16ComponentData, 2);
                               B = BitConverter.ToUInt16(bit16ComponentData, 4);
                               return String.Format("{0}, {1}, {2}", R, G, B);
                           }


                           RasterColor PixelColor = image.GetPixelColor(y, x);
                           return String.Format("{0}, {1}, {2}", PixelColor.R, PixelColor.G, PixelColor.B);
                       }

                   }
               return "";
           }
           
            private RasterImage GetCellImage ( MedicalViewerCell cell, int subCellIndex ) 
            {
               if (cell.VirtualImage == null)
               {
                   return cell.Image;
               }
               else
               {
                   if (cell.VirtualImage[subCellIndex].ImageExist)
                   {
                       return cell.VirtualImage[subCellIndex].Image;
                   }
               }
               
               return null ;
            }
            
         #endregion
         
         #region Properties
         
            private WorkstationContainer __ViewerContainer
            {
               get ;
               set ;
            }
            
         #endregion
         
         #region Events
         
            void cell_ProbeToolTextChanged(object sender, MedicalViewerProbeToolTextChangedEventArgs e)
            {
               int bitmapX = (int)(e.X);
               int bitmapY = (int)(e.Y);
               string output;

               MedicalViewerCell cell = sender as MedicalViewerCell ;
               RasterImage image = GetCellImage ( cell, e.SubCellIndex ) ;
            
               if ( null != image ) 
               {
                  string value =  GetRealPixelValue(image, bitmapX, bitmapY);

                  if (value != "")
                      output = String.Format("X = {0}, Y = {1} \nValue = {2} \nFrame {3}", (int)e.X, (int)e.Y, value, e.SubCellIndex + 1);
                  else
                      output = String.Format("X = N/A, Y = N/A \nValue = N/A \nFrame N/A");

                  e.Text = output;
               }
            }
            
         #endregion
         
         #region Data Members
            
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
