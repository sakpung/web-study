using Leadtools;
using Leadtools.Ocr;
using Leadtools.Forms.Processing.Omr;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leadtools.Forms.Processing.Omr.Fields;
using OmrProcessingDemo.UI.ViewerControl;
using Leadtools.ImageProcessing.Core;

namespace OmrProcessingDemo.Operations
{
   class ProcessOmrDocumentsOperation : BusyOperation
   {
      private Dictionary<string,string> toLoad;
      private IImageManager imageManager;
      private RasterImage key;

      private List<string> errorList = new List<string>();

      private ITemplateForm _templateForm;

      private List<IRecognitionForm> results;
      private IRecognitionForm answers;
      public IRecognitionForm Answers { get { return answers; } }
      public List<IRecognitionForm> Results { get { return results; } }

      public ITemplateForm TemplateForm { get { return _templateForm; } set { _templateForm = value; } }
      public List<string> ErrorList { get { return errorList; } }

      public ProcessOmrDocumentsOperation(RasterImage answerKey, ITemplateForm template, IImageManager imageManager, Dictionary<string, string> images)
      {
         this.imageManager = imageManager;

         this.key = answerKey;
         this.toLoad = images;

         this._templateForm = template;
      }

      private IRecognitionForm RecognizeForm(RasterImage formImage, string id, string name)
      {
         IRecognitionForm recognizeForm = MainForm.GetOmrEngine().CreateRecognitionForm();

         for (int i = 0; i < formImage.PageCount; i++)
         {
            formImage.Page = i + 1;
            DeskewCommand dskcmd = new DeskewCommand() ;
            dskcmd.FillColor = Leadtools.RasterColor.White ;
            dskcmd.Flags = DeskewCommandFlags.DoNotUseCheckDeskew ;
            dskcmd.Run(formImage);

            recognizeForm.Pages.AddPage(formImage);
         }

         recognizeForm.Recognize(_templateForm);

         recognizeForm.Id = id;
         recognizeForm.SaveEmbeddedImage = false;
         recognizeForm.Name = name;

         return recognizeForm;
      }

      protected override void Run()
      {
         bool checkAnswers = key != null;

         int ticker = 0;
         int step = toLoad == null ? 101 : Math.Max(100 / (toLoad.Count + 2), 1);

         Progress(ticker += step, "Initializing objects");

         if (checkAnswers)
         {
            Progress(ticker += step, "Recognizing key");

            try
            {
               answers = RecognizeForm(key, Workspace.IMGMGR_ANSWERS, Workspace.IMGMGR_ANSWERS);
            }
            catch (Exception)
            {
               errorList.Add(Workspace.IMGMGR_ANSWERS);
               answers = null;
            }
         }

         results = new List<IRecognitionForm>();

         if (toLoad != null)
         {
            foreach (KeyValuePair<string, string> kvp in toLoad)
            {
               string imageKey = kvp.Key;
               string fname = System.IO.Path.GetFileNameWithoutExtension(kvp.Value);

               Progress(ticker += step, string.Format("Recognizing {0}", fname));

               using (RasterImage image = imageManager.Get(imageKey))
               {
                  try
                  {
                     IRecognitionForm frm = RecognizeForm(image, imageKey, fname);
                     results.Add(frm);
                  }
                  catch (Exception)
                  {
                     errorList.Add(fname);
                  }
               }
            }
         }

         base.Run();
      }
   }
}