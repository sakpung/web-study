// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Text;
using System.IO;
using System.Threading;

using Leadtools;
using Leadtools.Ocr;
using Leadtools.JobProcessor.Job;

using Leadtools.Demos;
using System.Xml.Serialization;
using Leadtools.Document.Writer;
using System.Reflection;
using System.Configuration;
using Leadtools.Document.Converter;

namespace OcrJobProcessorDemo
{
   public class MyOcrJob : JobBase
   {
      private const int SECONDS_TO_MILLISECONDS_FACTOR = 1000;

      bool _aborted = false;
      bool _completed = false;

      string _jobId = string.Empty;
      XmlSerializer _serializer = null;
      int _currentPageIndex = 0;
      int _totalPages = 1;

      public MyOcrJob(IJob job)
         : base(job)
      {
#if LEADTOOLS_V175_OR_LATER
         if (!Support.SetLicense())
            return;
#else
         Support.Unlock(false);
#endif // #if LEADTOOLS_V175_OR_LATER

         _serializer = new XmlSerializer(typeof(OcrData));
      }

      private static void SetDocumentWriterOptions(DocumentWriter docWriter, DocumentFormat format)
      {
         switch (format)
         {
#if LEADTOOLS_V19_OR_LATER
            case DocumentFormat.Ltd:
#else
            case DocumentFormat.Ltd:
#endif // #if LEADTOOLS_V19_OR_LATER
            case DocumentFormat.Pdf:
            case DocumentFormat.Html:
            case DocumentFormat.Text:
            case DocumentFormat.Emf:
            case DocumentFormat.Xps:
            case DocumentFormat.Xls:
               break;

            case DocumentFormat.Doc:
               {
                  DocDocumentOptions docOptions = docWriter.GetOptions(format) as DocDocumentOptions;

                  docOptions.TextMode = DocumentTextMode.Framed;

                  docWriter.SetOptions(format, docOptions);
               }
               break;

            case DocumentFormat.Rtf:
               {
                  RtfDocumentOptions rtfOptions = docWriter.GetOptions(format) as RtfDocumentOptions;

                  rtfOptions.TextMode = DocumentTextMode.Framed;

                  docWriter.SetOptions(format, rtfOptions);
               }
               break;

            case DocumentFormat.Docx:
               {
                  DocxDocumentOptions docxOptions = docWriter.GetOptions(format) as DocxDocumentOptions;

                  docxOptions.TextMode = DocumentTextMode.Framed;

                  docWriter.SetOptions(format, docxOptions);
               }
               break;

            default:
               throw new ArgumentException("Invalid format");
         }
      }

      /***************************************************************************/
      /* This function will OCR and convert the source image from the input      */
      /* path specified through the Job class and will save the converted file   */
      /* into the output path the client also specified.                         */
      /***************************************************************************/
      public override void OnJobReceived(string id, string userToken, string jobMetadata, string jobType, int progressRate)
      {
         _jobId = id;

         try
         {
            // Check if we have valid job information and job metadata
            if (string.IsNullOrEmpty(jobMetadata))
            {
               SetFailureStatus(_jobId, (int)RasterExceptionCode.InvalidParameter, Leadtools.RasterException.GetCodeMessage(RasterExceptionCode.InvalidParameter), null);
               return;
            }

            using (Timer updateStatusTimer = new Timer(new TimerCallback(UpdateStatusProc), _jobId, 0, progressRate * SECONDS_TO_MILLISECONDS_FACTOR))
            {
               OcrData data = OcrData.DeserializeFromString(jobMetadata);
               data.DocumentFileName = BuildOutputFile(data);

               DoRecognizeAndSave(data);
            }
         }
         catch (RasterException ex)
         {
            SetFailureStatus(id, (int)ex.Code, ex.Message, null);
         }
         catch (OcrException ex)
         {
            SetFailureStatus(id, (int)ex.Code, ex.Message, null);
         }
         catch (Exception ex)
         {
            SetFailureStatus(id, 0, ex.Message, null);
         }
      }

      private void DoRecognizeAndSave(OcrData ocrData)
      {
         // Read and retrieve the Ocr job parameters from the JobMetadata XML string sent through Job.JobMetadata
         using (IOcrEngine ocrEngine = OcrEngineManager.CreateEngine(OcrEngineType.LEAD, false))
         {
            try
            {
               string executingAssemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
               string ocrEnginePath = null;

               if (!String.IsNullOrEmpty(executingAssemblyPath))
               {
                  ocrEnginePath = Path.Combine(executingAssemblyPath, @"..\..\common\OcrLEADRuntime");
                  if (!Directory.Exists(ocrEnginePath))
                     ocrEnginePath = null;
               }

               ocrEngine.Startup(null, null, null, ocrEnginePath);

               DocumentFormat documentFormat = (DocumentFormat)Enum.Parse(typeof(DocumentFormat), ocrData.DocumentFormat, true);
               
               if (ocrEngine.DocumentWriterInstance != null)
                  SetDocumentWriterOptions(ocrEngine.DocumentWriterInstance, documentFormat);

               using (DocumentConverter documentConverter = new DocumentConverter())
               {
                  documentConverter.SetOcrEngineInstance(ocrEngine, true);
                  documentConverter.Diagnostics.EnableTrace = true;
                  var jobData = DocumentConverterJobs.CreateJobData(ocrData.ImageFileName, ocrData.DocumentFileName, documentFormat);
                  var job = documentConverter.Jobs.CreateJob(jobData);
                  if (null != documentConverter.OcrEngineInstance)
                  {
                     documentConverter.OcrEngineInstance.AutoRecognizeManager.JobOperation += new EventHandler<OcrAutoRecognizeJobOperationEventArgs>(AutoRecognizeManager_JobOperation);
                     documentConverter.OcrEngineInstance.AutoRecognizeManager.JobCompleted += new EventHandler<OcrAutoRecognizeRunJobEventArgs>(AutoRecognizeManager_JobCompleted);
                  }
                  documentConverter.Jobs.RunJob(job);
                  if (null != documentConverter.OcrEngineInstance)
                  {
                     documentConverter.OcrEngineInstance.AutoRecognizeManager.JobOperation -= new EventHandler<OcrAutoRecognizeJobOperationEventArgs>(AutoRecognizeManager_JobOperation);
                     documentConverter.OcrEngineInstance.AutoRecognizeManager.JobCompleted -= new EventHandler<OcrAutoRecognizeRunJobEventArgs>(AutoRecognizeManager_JobCompleted);
                  }
                  //Update job metadata with new filename                  
                  SetCompletedStatus(_jobId, OcrData.SerializeToString(ocrData));
               }
            }
            catch (RasterException ex)
            {
               SetFailureStatus(_jobId, (int)ex.Code, ex.Message, null);
            }
            catch (OcrException ex)
            {
               SetFailureStatus(_jobId, (int)ex.Code, ex.Message, null);
            }
            catch (Exception ex)
            {
               SetFailureStatus(_jobId, 0, ex.Message, null);
            }
            finally
            {
               ocrEngine.Shutdown();
            }
         }
      }

      string BuildOutputFile(OcrData ocrData)
      {
         //Format the target file like <output directory>\<source filename>_<source file extension>_<Guid>.<new extension>
         string ext = Path.GetExtension(ocrData.ImageFileName);
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

         string name = Path.GetFileNameWithoutExtension(ocrData.ImageFileName);

         DocumentFormat documentFormat = (DocumentFormat)Enum.Parse(typeof(DocumentFormat), ocrData.DocumentFormat, true);
         name = string.Format(
               "{0}{1}_{2}.{3}",
               name, ext, Guid.NewGuid(), DocumentWriter.GetFormatFileExtension(documentFormat));

         string fullPath = string.Empty;

         // If DocumentFileName is a file, this is a full path (from a previous conversion). In this case need, we to get the directory name and append the new file name.
         // We cannot check the file itself because it may no longer exist so we use the extension in the path to indicate if it is a file
         if (String.IsNullOrEmpty(Path.GetExtension(ocrData.DocumentFileName)))
            fullPath = ocrData.DocumentFileName; //path is a directory
         else
            fullPath = Path.GetDirectoryName(ocrData.DocumentFileName);//This is a file

         if (!Directory.Exists(fullPath))
            Directory.CreateDirectory(fullPath);

         return Path.Combine(fullPath, name);
      }

      void AutoRecognizeManager_JobOperation(object sender, OcrAutoRecognizeJobOperationEventArgs e)
      {
         if (_aborted)
         {
            e.Status = OcrAutoRecognizeManagerJobStatus.Abort;
            SetAbortedStatus(_jobId, null);

            return;
         }

         try
         {
            if (e.PostOperation && (
                        e.Operation == OcrAutoRecognizeManagerJobOperation.SavePage ||
                        e.Operation == OcrAutoRecognizeManagerJobOperation.SaveDocument))
            {
               _totalPages = (e.Job.JobData.LastPageNumber - e.Job.JobData.FirstPageNumber + 1) + 1;
               _currentPageIndex++;
            }

            if (e.PostOperation && e.Operation == OcrAutoRecognizeManagerJobOperation.ConvertDocument)
            {
               _currentPageIndex = _totalPages;
            }
         }
         catch (RasterException ex)
         {
            SetFailureStatus(_jobId, (int)ex.Code, ex.Message, null);
         }
         catch (OcrException ex)
         {
            if (!_aborted)
               SetFailureStatus(_jobId, (int)ex.Code, ex.Message, null);
         }
         catch (Exception ex)
         {
            if (!_aborted)
               SetFailureStatus(_jobId, 0, ex.Message, null);
         }
      }

      void AutoRecognizeManager_JobCompleted(object sender, OcrAutoRecognizeRunJobEventArgs e)
      {
         // JobCompleted event will be fired even if the process was aborted, so in this case 
         // we don't want to update the percentage again.
         if (e.Status == OcrAutoRecognizeManagerJobStatus.Abort)
         {
            if (e.Job.Errors.Count > 0)
            {
               SetFailureStatus(_jobId, 0, e.Job.Errors[0].Exception.Message, string.Empty);
            }
            return;
         }

         try
         {
            _completed = true;
            bool abort = !UpdatePercentage(_jobId, 100, string.Format("{0} completed job {1}", Environment.MachineName, _jobId));
            if (abort)
            {
               e.Status = OcrAutoRecognizeManagerJobStatus.Abort;
               SetAbortedStatus(_jobId, null);
               return;
            }            
         }

         catch (OcrException ex)
         {
            SetFailureStatus(_jobId, (int)ex.Code, ex.Message, null);
         }
         catch (Exception ex)
         {
            SetFailureStatus(_jobId, 0, ex.Message, null);
         }
      }

      private void UpdateStatusProc(Object stateInfo)
      {
         try
         {
            bool abort = false;

            if (!_completed)
            {
               if (Percentage < 100)
               {
                  string workerMetadata = string.Format("{0} Coverting page {1} / {2}", Environment.MachineName, _currentPageIndex, _totalPages);
                  abort = !UpdatePercentage(_jobId, Percentage, workerMetadata);
               }
               else if (Percentage == 100)
                  abort = !UpdatePercentage(_jobId, 99, string.Empty);
            }
            else
            {
               abort = !UpdatePercentage(_jobId, 100, string.Empty);
            }

            if (abort)
               _aborted = true;
         }
         catch (Exception ex)
         {
            if (!_aborted)
            {
               SetFailureStatus(_jobId, 0, ex.Message, null);
            }
         }
      }

      public int Percentage
      {
         get { return Math.Min(_currentPageIndex * 100 / _totalPages, 100); }
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
