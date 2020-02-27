using Leadtools.Forms.Processing.Omr.Fields;
using Leadtools.Forms.Processing.Omr;
using OmrProcessingDemo.UI;
using System;
using System.Collections.Generic;

namespace OmrProcessingDemo.Operations
{
   class ExtractReviewCollectionOperation : BusyOperation
   {
      private IRecognitionForm answers;
      private List<IRecognitionForm> forms;
      private VerificationParameters verificationParameters;

      public Workspace.ReviewCounter AnswerReviewCount { get; private set; }
      public Workspace.ReviewCounter ResultsReviewCount { get; private set; }

      public ExtractReviewCollectionOperation(IRecognitionForm answers, List<IRecognitionForm> forms, VerificationParameters verificationParameters) : base()
      {
         this.answers = answers;
         this.forms = forms;

         this.verificationParameters = verificationParameters;

         useWaitWindow = false;
      }

      protected override void Run()
      {
         int ticker = 0;
         int step = Math.Max(100 / ((forms == null || forms.Count == 0 ? 1 : forms.Count) + (answers == null ? 0 : 1)), 1);

         AnswerReviewCount = new Workspace.ReviewCounter();
         ResultsReviewCount = new Workspace.ReviewCounter();

         if (answers != null)
         {
            Progress(ticker += step, "Analyzing key...");
            AnswerReviewCount= Workspace.GetManualReviewCollection(answers, verificationParameters);
         }

         if (forms == null || forms.Count == 0)
         {
            return;
         }

         for (int i = 0; i < forms.Count; i++)
         {
            IRecognitionForm form = forms[i];
            Progress(ticker += step, string.Format("Analyzing {0}...", form.Name));
            ResultsReviewCount += Workspace.GetManualReviewCollection(form, verificationParameters, answers);
         }

         base.Run();
      }

   }
}
