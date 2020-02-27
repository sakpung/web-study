using Leadtools;
using Leadtools.Codecs;
using Leadtools.Forms.Common;
using Leadtools.Ocr;
using Leadtools.Forms.Processing.Omr;
using OmrProcessingDemo.Operations;
using System.Collections.Generic;
using System.IO;

namespace OmrProcessingDemo.ViewerControl
{
   internal class CreateNewTemplateOperation : BusyOperation
   {
      private RasterImage loadedImage;
      private ITemplateForm templateForm;

      public ITemplateForm TemplateForm { get { return templateForm; } }
      public bool IsLoadingError { get; private set; }
      public CreateNewTemplateOperation(RasterImage loadedImage, ITemplateForm template) : base()
      {
         this.loadedImage = loadedImage;

         this.templateForm = template;
      }

      protected override void Run()
      {
         IsLoadingError = false;
         Progress(101, "Generating...");

         Progress(101, "Creating components...");

         int step = 100 / loadedImage.PageCount;
         step = step > 0 ? step : 1;
         int ticker = 0;

         for (int i = 0; i < loadedImage.PageCount; i++)
         {
            loadedImage.Page = i + 1;
            ticker += step;
            Progress(ticker, string.Format("Adding page {0}...", loadedImage.Page));
            try
            {
               Page pg = templateForm.Pages.AddPage(loadedImage.Clone());

               IsLoadingError = IsLoadingError || pg == null;
            }
            catch (System.Exception)
            {
               IsLoadingError = true;
               continue;
            }
         }


         base.Run();
      }
   }
}