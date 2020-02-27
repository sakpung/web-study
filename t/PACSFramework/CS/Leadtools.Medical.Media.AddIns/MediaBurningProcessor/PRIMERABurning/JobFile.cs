// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;

namespace Leadtools.Medical.Media.AddIns.MediaBurningProcessor.Primera
{
    public enum DataFileType
    {
      DATA, 
      AUDIO, 
      IMAGE, 
      NONE=99
   }
   
   public enum DataImageType 
   { 
      ISOLEVEL1, 
      ISOLEVEL2, 
      ISOLEVEL3, 
      JOLIET, 
      ISOLEVEL1_JOLIET, 
      ISOLEVEL2_JOLIET, 
      ISOLEVEL3_JOLIET, 
      UDF, 
      UDF201 
   }
    
   public enum ImageType 
   { 
      MODE_1_2048, 
      MODE_2_2336, 
      MODE_2_2352 
   }
    
   public enum PrintQualityValues 
   {
      Low=0, 
      Medium, 
      Better, 
      High, 
      Best
   }

   public class DataEntry
   {
      public string File
      {
         get ;
         set ;
      }
      
      public DataFileType DataType
      {
         get ;
         set ;
      }
      
      public UInt32 Session
      {
         get ;
         set ;
      }
      
      public UInt32 PreGap
      {
         get ;
         set ;
      }
      
      public bool SetPreGap
      {
         get ;
         set ;
      }

      public DataEntry ( string file ) 
      {
         File     = file ;
         DataType = DataFileType.DATA;
         Session  = 0 ;
      }
    }
    
   public class JobFile
   {
      public List<DataEntry> Data
      {
         get ;
         set ;
      }
      
      public DataImageType DataType
      {
         get ;
         set ;
      }
   
      public ImageType ImgType
      {
         get ;
         set ;
      }
      
      
      public UInt32 Importance
      {
         get ;
         set ;
      }
      
      public UInt32 Copies
      {
         get ;
         set ;
      }
      public UInt32 BurnSpeed
      {
         get ;
         set ;
      }
      public PrintQualityValues PrintQuality
      {
         get ;
         set ;
      }
      public UInt32 PrintID
      {
         get ;
         set ;
      }
      public UInt32 PrintOM
      {
         get ;
         set ;
      }
      public UInt32 DriveID
      {
         get ;
         set ;
      }
      public UInt32 BinID
      {
         get ;
         set ;
      }

      public string JobID
      {
         get ;
         set ;
      }
      public string ClientID
      {
         get ;
         set ;
      }
      public UInt32 DiscType
      {
         get ;
         set ;
      }
      public string Robot
      {
         get ;
         set ;
      }
      public string PrintLabel
      {
         get ;
         set ;
      }
      public string VolumeName
      {
         get ;
         set ;
      }
      
      public List <string> MergeFields
      {
         get ;
         set ;
      }
      
      public string CheckFileOnDisc
      {
         get ;
         set ;
      }
      public string CheckSystemIDOnDisc
      {
         get ;
         set ;
      }
      public string CheckVolumeIDOnDisc
      {
         get ;
         set ;
      }
      public string CheckPubIDOnDisc
      {
         get ;
         set ;
      }
      public string CheckPreparerIDOnDisc
      {
         get ;
         set ;
      }
      public string CheckAppIDOnDisc
      {
         get ;
         set ;
      }
      public string PVDSystemID
      {
         get ;
         set ;
      }
      public string PVDPublisherID
      {
         get ;
         set ;
      }
      public string PVDPreparerID
      {
         get ;
         set ;
      }
      public string PVDApplicationID
      {
         get ;
         set ;
      }
      public string ReadDataTo
      {
         get ;
         set ;
      }
      public string ReadDataFormat
      {
         get ;
         set ;
      }
      public bool CreateSubFolders
      {
         get ;
         set ;
      }

      public bool DeleteFiles
      {
         get ;
         set ;
      }
      public bool CloseDisc
      {
         get ;
         set ;
      }
      public bool Verify
      {
         get ;
         set ;
      }
      public bool SetPrinterSettings
      {
         get ;
         set ;
      }
      public bool ManLoadUnload
      {
         get ;
         set ;
      }
      public bool UseAnyDrive
      {
         get ;
         set ;
      }
      public bool TestRecord
      {
         get ;
         set ;
      }
      public bool RejectIfNotBlank
      {
         get ;
         set ;
      }
      public bool PreMasterData
      {
         get ;
         set ;
      }
      public bool CheckDisc
      {
         get ;
         set ;
      }
      public bool SetPVD
      {
         get ;
         set ;
      }
      public bool DataSetNow
      {
         get ;
         set ;
      }
      public bool DataMode2
      {
         get ;
         set ;
      }
      public bool DataSAO
      {
         get ;
         set ;
      }
    

      public JobFile()
      {
         Data     = new List<DataEntry> ( ) ;
         Robot    = string.Empty ;
         DataType = DataImageType.JOLIET;

         Importance   = 4;
         Copies       = 1;
         BurnSpeed    = 0;
         PrintQuality = PrintQualityValues.Medium ;
         PrintID      = 200 ;
         PrintOM      = 15 ;
         DriveID      = 0 ;
         BinID        = 0 ;
         DiscType     = 0 ;

         JobID      = string.Empty ;
         ClientID   = string.Empty ;
         Robot      = string.Empty ;
         PrintLabel = string.Empty ;
         VolumeName = string.Empty ;
         ImgType    = ImageType.MODE_1_2048;

         MergeFields             = new List<string> ( ) ;
         CheckFileOnDisc         = string.Empty ;
         CheckSystemIDOnDisc     = string.Empty ;
         CheckVolumeIDOnDisc     = string.Empty ;
         CheckPubIDOnDisc        = string.Empty ;
         CheckPreparerIDOnDisc   = string.Empty ;
         CheckAppIDOnDisc        = string.Empty ;
         PVDSystemID             = string.Empty ;
         PVDPublisherID          = string.Empty ;
         PVDPreparerID           = string.Empty ;
         PVDApplicationID        = string.Empty ;

         DeleteFiles        = false ;
         CloseDisc          = false ;
         Verify             = false ;
         SetPrinterSettings = false ;
         ManLoadUnload      = false ;
         UseAnyDrive        = true ;
         TestRecord         = false ;
         RejectIfNotBlank   = false ;
         PreMasterData      = false ;
         CheckDisc          = false ;
         SetPVD             = false ;
         DataSetNow         = false ;
         DataMode2          = false ;
         DataSAO            = false ;
      }

      public void SendJobFile ( string jobFilePath )
      {
         if ( !File.Exists ( jobFilePath ) )
         {
            TextWriter tw ;
            
            
            tw = new StreamWriter ( jobFilePath ) ;
                
            if ( tw != null )
            {
               if (!String.IsNullOrEmpty(this.JobID))
               {
                  tw.WriteLine("JobID=" + JobID);
               }
               
               if ( !String.IsNullOrEmpty ( this.ClientID ) )
               {
                  tw.WriteLine ( "ClientID=" + ClientID ) ;
               }
                    
               if (!String.IsNullOrEmpty(this.Robot))
               {
                  tw.WriteLine ( "RobotName=" + Robot ) ;
               }
               
               if ( !UseAnyDrive )
               {
                  tw.WriteLine ( "DriveID=" + this.DriveID.ToString ( ) ) ;
               }

               tw.WriteLine("Importance=" + Importance.ToString ( ) ) ;
               
               if ( this.BinID != 3 )
               {
                  tw.WriteLine ( "BinID=" + BinID.ToString ( ) ) ;
               }

               if (this.DiscType != 0)
               {
                  if (this.DiscType == 1)
                  {
                     tw.WriteLine("DiscType=CDR");
                  }
                  else
                  {
                     tw.WriteLine("DiscType=DVDR");
                  }
               }


               bool setImageType = false ;
               bool setDataType  = false ;
               
               foreach ( DataEntry data in this.Data )
               {
                  string dataField = "" ;
                  
                  if ( data.DataType == DataFileType.DATA )
                  {
                     dataField = "Data=" + data.File ;
                      
                     if ( !setDataType )
                     {
                        string DataTypeStr ;
                          
                        
                        DataTypeStr = "DataImageType=" + this.DataType.ToString ( ).Replace ( '_', '+' ) ;
                          
                        if ( this.DataSetNow )
                        {
                           DataTypeStr += ", SETNOW" ;
                        }
                        
                        if ( this.DataSAO )
                        {
                           DataTypeStr += ", SAO" ;
                        }
                        
                        if ( this.DataMode2 )
                        {
                           DataTypeStr += ", MODE2" ;
                        }
                        
                        tw.WriteLine ( DataTypeStr ) ;
                        
                        setDataType = true ;
                     }
                  }
                  else if ( data.DataType == DataFileType.AUDIO )
                  {
                     dataField = "AudioFile=" + data.File ;
                      
                     if ( data.SetPreGap )
                     {
                        dataField += " Pregap" + data.PreGap.ToString ( ) ;
                     }
                  }
                  else if ( data.DataType == DataFileType.IMAGE )
                  {
                     dataField = "ImageFile=" + data.File ;
                      
                     if  ( !setImageType && ( Path.GetExtension ( data.File ).ToLower ( ) == "iso" ) )
                     {
                        tw.WriteLine ( "ImageType="+this.ImgType.ToString ( ) ) ;
                          
                        setImageType = true ;
                     }
                  }
                  
                  if ( data.Session != 0 )
                  {
                     dataField += " Session" + data.Session.ToString ( ) ;
                  }
                  
                  tw.WriteLine ( dataField ) ;
               }
              
               if ( !String.IsNullOrEmpty ( this.PrintLabel ) )
               {
                  tw.WriteLine ( "PrintLabel=" + this.PrintLabel ) ;
                  
                  if ( Path.GetExtension ( this.PrintLabel ).Equals ( ".std", StringComparison.InvariantCultureIgnoreCase ) )
                  {
                     foreach ( string label in MergeFields )
                     {
                        tw.WriteLine ( "MergeField=" + label ) ;
                     }
                  }
               }

               tw.WriteLine ( "Copies=" + this.Copies.ToString ( ) ) ;

               if  ( this.SetPrinterSettings )
               {
                  tw.WriteLine ( "PrintQuality=" + Convert.ToUInt32 ( this.PrintQuality ) ) ;
                  tw.WriteLine ( "PrintInnerDiam=" + this.PrintID ) ;
                  tw.WriteLine ( "PrintOuterMargin=" + this.PrintOM ) ;
               }
              
               if ( this.ManLoadUnload )
               {
                  tw.WriteLine ( "LoadUnloadOverride=YES" ) ;
               }
               else
               {
                  tw.WriteLine ( "LoadUnloadOverride=NO" ) ;
               }

               if  ( this.TestRecord )
               {
                  tw.WriteLine ( "TestRecord=YES" ) ;
               }
               else
               {
                  tw.WriteLine ( "TestRecord=NO" ) ;
               }

               if ( this.PreMasterData )
               {
                  tw.WriteLine ( "PreMasterData=YES" ) ;
               }
               else
               {
                  tw.WriteLine ( "PreMasterData=NO" ) ;
               }

               if ( this.RejectIfNotBlank )
               {
                  tw.WriteLine ( "RejectIfNotBlank=YES" ) ;
               }
               else
               {
                  tw.WriteLine ( "RejectIfNotBlank=NO" ) ;
               }

               if ( this.Verify )
               {
                  tw.WriteLine ( "VerifyDisc=YES" ) ;
               }
               else
               {
                  tw.WriteLine ( "VerifyDisc=NO" ) ;
               }

               if ( this.CloseDisc )
               {
                  tw.WriteLine ( "CloseDisc=YES" ) ;
               }
               else
               {
                  tw.WriteLine ( "CloseDisc=NO" ) ;
               }

               if ( this.DeleteFiles )
               {
                  tw.WriteLine ( "DeleteFiles=YES" ) ;
               }
               else
               {
                  tw.WriteLine ( "DeleteFiles=NO" ) ;
               }

               tw.WriteLine ( "BurnSpeed=" + this.BurnSpeed.ToString ( ) ) ;
               tw.WriteLine ( "VolumeName=" + this.VolumeName ) ;

               if ( this.CheckDisc )
               {
                  if  ( !String.IsNullOrEmpty ( this.CheckFileOnDisc ) )
                  {
                     tw.WriteLine ( "CheckFileOnDisc=" + this.CheckFileOnDisc ) ;
                  }
                  
                  if ( !String.IsNullOrEmpty ( this.CheckSystemIDOnDisc ) ) 
                  {
                     tw.WriteLine ( "CheckSystemIDOnDisc=" + this.CheckSystemIDOnDisc ) ;
                  }
                  
                  if ( !String.IsNullOrEmpty ( this.CheckPreparerIDOnDisc ) ) 
                  {
                     tw.WriteLine ( "CheckPreparerIDOnDisc=" + this.CheckPreparerIDOnDisc ) ;
                  }
                  
                  if ( !String.IsNullOrEmpty ( this.CheckPubIDOnDisc ) ) 
                  {
                     tw.WriteLine ( "CheckPubIDOnDisc=" + this.CheckPubIDOnDisc ) ;
                  }
                  
                  if ( !String.IsNullOrEmpty ( this.CheckAppIDOnDisc ) ) 
                  {
                     tw.WriteLine ( "CheckAppIDOnDisc=" + this.CheckAppIDOnDisc ) ;
                  }
                  
                  if ( !String.IsNullOrEmpty ( this.CheckVolumeIDOnDisc ) )
                  {
                     tw.WriteLine ( "CheckVolumeIDOnDisc=" + this.CheckVolumeIDOnDisc ) ;
                  }
               }
               
               if ( this.SetPVD )
               {
                  if ( !String.IsNullOrEmpty ( this.PVDSystemID ) )
                  {
                     tw.WriteLine ( "PVDSystemID=" + this.PVDSystemID ) ;
                  }
                  
                  if ( !String.IsNullOrEmpty ( this.PVDApplicationID ) )
                  {
                     tw.WriteLine ( "PVDApplicationID=" + this.PVDApplicationID ) ;
                  }
                  
                  if ( !String.IsNullOrEmpty ( this.PVDPreparerID ) )
                  {
                     tw.WriteLine ( "PVDPreparerID=" + this.PVDPreparerID ) ;
                  }
                  
                  if ( !String.IsNullOrEmpty ( this.PVDPublisherID ) )
                  {
                     tw.WriteLine ( "PVDPublisherID=" + this.PVDPublisherID ) ;
                  }
               }

               tw.Close ( ) ;
            }
         }
      }
   }

}
