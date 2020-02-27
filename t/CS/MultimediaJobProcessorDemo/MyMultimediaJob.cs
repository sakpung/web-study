// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Text;
using System.IO;
using System.Threading;

using Leadtools;
using Leadtools.Multimedia;
using Leadtools.JobProcessor.Job;

using Leadtools.Demos;
using System.Xml.Serialization;
using System.Runtime.InteropServices;

namespace MultimediaJobProcessorDemo
{
   public class MyMultimediaJob : JobBase
   {
      private int _reportStatusInterval = 60;
      private const int SECONDS_TO_MILLISECONDS_FACTOR = 1000;
      private bool conversionAborted = false;
      ConvertCtrl convertCtrl = null;
      string _jobId = string.Empty;

      public MyMultimediaJob(IJob job)
         : base(job)
      {
         if (!Support.SetLicense())
            return;
      }

      /***************************************************************************/
      /* This function will convert multimedia files based on the settings specified in MultimediaData.ConversionSettings*/
      /***************************************************************************/
      public override void OnJobReceived(string id, string clientMetadata, string jobMetadata, string jobType, int progressRate)
      {
         _jobId = id;
         conversionAborted = false;
         AutoResetEvent finishedEvent = new AutoResetEvent(false);

         try
         {
            // Check if we have valid job information and job metadata
            if (String.IsNullOrEmpty(jobMetadata))
            {
               SetFailureStatus(_jobId, (int)RasterExceptionCode.InvalidParameter, Leadtools.RasterException.GetCodeMessage(RasterExceptionCode.InvalidParameter), null);
               return;
            }

            //Deserialize the jobMetadata so we can get the MultimediaData
            MultimediaData multimediaData = MultimediaData.DeserializeFromString(jobMetadata);
            _reportStatusInterval = progressRate * SECONDS_TO_MILLISECONDS_FACTOR;

            using (Timer updateStatusTimer = new Timer(new TimerCallback(UpdateStatusProc), multimediaData, 0, _reportStatusInterval))
            {
               ConvertFile(multimediaData);
            }
         }
         catch (COMException ex)
         {
            SetFailureStatus(id, ex.ErrorCode, ex.Message, null);
         }
         catch (Exception ex)
         {
            SetFailureStatus(id, 0, ex.Message, null);
         }
         finally
         {
            finishedEvent.Close();
         }
      }

      private void ConvertFile(MultimediaData multimediaData)
      {
         try
         {
            //Set up the conversion control and start the conversion
            convertCtrl = new ConvertCtrl(true);

            if (!File.Exists(multimediaData.SourceFile))
            {
               SetFailureStatus(_jobId, (int)RasterExceptionCode.FileNotFound, Leadtools.RasterException.GetCodeMessage(RasterExceptionCode.FileNotFound), null);
               return;
            }

            convertCtrl.TargetFile = String.Empty;
            convertCtrl.SourceFile = multimediaData.SourceFile;
            // MultimediaData.ConversionSettings contains all of the predefined conversion settings (format, compression, etc).
            using (MemoryStream memoryStream = new MemoryStream(multimediaData.ConversionSettings))
               convertCtrl.LoadSettingsFromStream(memoryStream, ConvertSettings.All);

            convertCtrl.TargetFile = BuildOutputFile(multimediaData, convertCtrl.TargetFormat);
            convertCtrl.StartConvert();
            while (convertCtrl.State != ConvertState.Stopped)
            {
               //Pump messages so progress is updated
               System.Windows.Forms.Application.DoEvents();
               Thread.Sleep(1);
            }

            if (conversionAborted)
            {
               //if job was already aborted, no need to continue.
               return;
            }

            //Job complete. Check if an error occured during conversion
            if (convertCtrl.ConvertError != 0)
               throw new Exception(convertCtrl.ConvertError.ToString());

            //conversion success. Set completed status unless job was aborted
            //Update metadata since it contains the updated targetfile
            multimediaData.TargetFile = convertCtrl.TargetFile;
            if (UpdatePercentage(_jobId, 100, String.Empty))
               SetCompletedStatus(_jobId, MultimediaData.SerializeToString(multimediaData));
            else
               AbortJob();
         }
         catch (COMException ex)
         {
            SetFailureStatus(_jobId, ex.ErrorCode, ex.Message, null);
         }
         catch (Exception ex)
         {
            SetFailureStatus(_jobId, 0, ex.Message, null);
         }
         finally
         {
            if (convertCtrl != null)
               convertCtrl.Dispose();
         }
      }

      string BuildOutputFile(MultimediaData multimediaData, TargetFormatType targetFormat)
      {
         //Format the target file like <output directory>\<source filename>_<source file extension>_<Guid>.<new extension>
         string ext = Path.GetExtension(multimediaData.SourceFile);
         if (!string.IsNullOrEmpty(ext))
         {
            ext = ext.Replace(".", "");
         }

         if (!string.IsNullOrEmpty(ext))
         {
            ext = "_" + ext;
         }
         else
         {
            ext = string.Empty;
         }

         string name = Path.GetFileNameWithoutExtension(multimediaData.SourceFile);

         name = string.Format(
               "{0}{1}_{2}.{3}",
               name, ext, Guid.NewGuid(), GetExtension(targetFormat));

         string fullPath = string.Empty;

         // If the TargetFile is a file, this is a full path (from a previous conversion). In this case need, we to get the directory name and append the new file name.
         // We cannot check the file itself because it may no longer exist so we use the extension in the path to indicate if it is a file
         if (String.IsNullOrEmpty(Path.GetExtension(multimediaData.TargetFile)))
            fullPath = multimediaData.TargetFile; //path is a directory
         else
            fullPath = Path.GetDirectoryName(multimediaData.TargetFile);//This is a file

         if (!Directory.Exists(fullPath))
            Directory.CreateDirectory(fullPath);

         return Path.Combine(fullPath, name);
      }

      private string GetExtension(TargetFormatType targetFormat)
      {
         switch (targetFormat)
         {
            case TargetFormatType.MPEG2DICOM:
            case TargetFormatType.DICOM:
               return "dcm";
            case TargetFormatType.ASF:
            case TargetFormatType.ASFMux:
            case TargetFormatType.WMVMux:
               return "wmv";
            case TargetFormatType.DVSD:
               return "dvsd";
            case TargetFormatType.MKV:
               return "mkv";
            case TargetFormatType.MXF:
               return "mxf";
            case TargetFormatType.DVSDAVI:
               return "avi";
            case TargetFormatType.DVSDMXF:
               return "mxf";
            case TargetFormatType.DVSDOGG:
               return "ogg";
            case TargetFormatType.FLVH264:
            case TargetFormatType.FLVH263:
            case TargetFormatType.FLV:
               return "flv";
            case TargetFormatType.ISO:
               return "mp4";
            case TargetFormatType.MP3LEAD:
            case TargetFormatType.MP3LAME:
            case TargetFormatType.MP3Default:
            case TargetFormatType.MP3:
               return "mp3";
            case TargetFormatType.MPEG2Program:
            case TargetFormatType.MPEG1Audio:
            case TargetFormatType.MPEG1System:
               return "mpg";
            case TargetFormatType.MPEG2Transport:
               return "m2ts";
            case TargetFormatType.OGG:
               return "ogg";
            case TargetFormatType.WAVE:
               return "wav";
            default:
            case TargetFormatType.AVI:
               return "avi";
         }
      }

      private void UpdateStatusProc(Object stateInfo)
      {
         try
         {
            // We should always report status when the report status interval elapses. Otherwise the job could be 
            // considered hung and terminated.
            if (convertCtrl != null)
            {
               convertCtrl.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate
               {
                  if (convertCtrl.State == ConvertState.Running)
                  {
                     if (!UpdatePercentage(_jobId, convertCtrl.PercentComplete, String.Empty))
                        AbortJob();
                  }
               });
            }
         }
         catch (Exception ex)
         {
            SetFailureStatus(_jobId, 0, ex.Message, null);
         }
      }

      private void AbortJob()
      {
         try
         {
            conversionAborted = true;
            //Set aborted status and stop conversion
            SetAbortedStatus(_jobId, null);
            if (convertCtrl.State != ConvertState.Stopped)
               convertCtrl.StopConvert();

            //Cleanup
            if (File.Exists(convertCtrl.TargetFile))
            {
               try
               {
                  File.Delete(convertCtrl.TargetFile);
               }
               catch { }
            }
         }
         catch (COMException ex)
         {
            SetFailureStatus(_jobId, ex.ErrorCode, ex.Message, null);
         }
         catch (Exception ex)
         {
            SetFailureStatus(_jobId, 0, ex.Message, null);
         }
      }

      public override bool OnJobTerminated(string id, string jobMetadata, TerminationType type)
      {
         string failedMessage = string.Empty;
         if (type == TerminationType.DidNotRespond)
            failedMessage = string.Format("Job {0} was terminated because it did not respond.", id);
         else
            failedMessage = string.Format("Job {0} experienced an unhandled exception and exited. See log info.", id);

         SetFailureStatus(id, 0, failedMessage, string.Empty);

         return true;
      }
   }
}
