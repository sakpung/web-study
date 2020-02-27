using Leadtools;
using Leadtools.Codecs;
using Leadtools.Forms.Processing.Omr;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OmrProcessingDemo.Operations;
using OmrProcessingDemo.UI.ViewerControl;
using Leadtools.Forms.Processing.Omr.Fields;
using OmrProcessingDemo.UI;
using System.Runtime.Serialization;
using System.Xml;
using System.Runtime.Serialization.Formatters.Binary;

namespace OmrProcessingDemo
{
   [Serializable]
   public class Workspace
   {
      [NonSerialized]
      private IImageManager imageManager;

      [NonSerialized]
      public const string IMGMGR_ANSWERS = "Answers";

      [NonSerialized]
      private ITemplateForm template;
      [NonSerialized]
      private IRecognitionForm answers;
      [NonSerialized]
      private List<IRecognitionForm> results;

      [NonSerialized]
      private RasterImage templateImage;

      [NonSerialized]
      private ExtractReviewCollectionOperation extractor;
      [NonSerialized]
      private ProcessOmrDocumentsOperation omrProcessor;
      [NonSerialized]
      private Dictionary<string, string> myImages;
      [NonSerialized]
      private ReviewCounter answerReviewCounts;
      [NonSerialized]
      private ReviewCounter resultReviewCounts;

      public ITemplateForm Template { get { return template; } }
      public IRecognitionForm Answers { get { return answers; } }
      public List<IRecognitionForm> Results { get { return results; } }
      public List<string> ErrorList { get { return omrProcessor != null ? omrProcessor.ErrorList : new List<string>(); } }

      // serialized
      //private string workspaceName;
      private string myAnswerkeyPath;
      private byte[] templateBytes;
      private byte[] answerBytes;
      private byte[][] resultsBytes;
      private byte[] filepathDictionaryBytes;
      private List<string> filenames;
      private VerificationParameters verificationParameters;
      bool[][][][] reviewRequiredStatus;
      private string locationOnDisk;

      public string LocationOnDisk { get { return locationOnDisk; } }
      public int PassingGrade { get; private set; }
      public RasterImage TemplateImage { get { return templateImage; } }

      public IImageManager ImageManager { get { return imageManager; } }

      public string AnswerKeyPath { get { return myAnswerkeyPath; } }
      public VerificationParameters VerificationParameters { get { return verificationParameters; } set { verificationParameters = value; } }
      public ReviewCounter AnswerReviewCounts { get { return answerReviewCounts; } }
      public ReviewCounter ResultsReviewCounts { get { return resultReviewCounts; } }
      public bool AnswersPresent { get { return answers != null && answers.Pages != null && answers.Pages.Count > 0; } }
      public Workspace()
      {
         InitializeDefaults();
      }

      public void InitializeDefaults()
      {
         imageManager = new MemoryImageManager();
         myImages = new Dictionary<string, string>();

         template = MainForm.GetOmrEngine().CreateTemplateForm();
         answers = MainForm.GetOmrEngine().CreateRecognitionForm();

         results = new List<IRecognitionForm>();
      }

      public Workspace(InputPanel ip, KeyPanel kp, ITemplateForm currentTemplate) : this()
      {
         for (int i = 0; i < ip.SelectedInputs.Count; i++)
         {
            string guid = Guid.NewGuid().ToString();

            imageManager.Add(guid, ip.SelectedInputs[i]);

            myImages.Add(guid, ip.SelectedInputs[i]);
         }

         if (kp.AnswerImage != null)
         {
            imageManager.Add(Workspace.IMGMGR_ANSWERS, kp.AnswerImagePath);

            myAnswerkeyPath = kp.AnswerImagePath;
         }

         omrProcessor = new ProcessOmrDocumentsOperation(kp.AnswerImage, currentTemplate , imageManager, myImages);

         this.PassingGrade = kp.PassingGrade;
         this.verificationParameters = VerificationParameters.GetTemplate(VerificationParameters.FilterTemplate.CommonIssues);
      }

      public void Process()
      {
         omrProcessor.Start();

         this.template = omrProcessor.TemplateForm;
         this.answers = omrProcessor.Answers;
         this.results = omrProcessor.Results;

         ReprocessVerification(VerificationParameters.AllParameters, answers, results);
      }

      public void UpdateAnswerKey(KeyPanel pid)
      {
         if (pid.AnswerImage != null)
         {
            imageManager.Add(Workspace.IMGMGR_ANSWERS, pid.AnswerImagePath);
            myAnswerkeyPath = pid.AnswerImagePath;
         }

         ProcessOmrDocumentsOperation podo = new ProcessOmrDocumentsOperation(pid.AnswerImage, template, this.imageManager, null);
         podo.Start();

         this.answers = podo.Answers;

         ReprocessVerification(VerificationParameters.AllParameters, answers, results);
      }

      public void ReprocessVerification(VerificationParameters parameters, IRecognitionForm ans, List<IRecognitionForm> res)
      {
         extractor = new ExtractReviewCollectionOperation(answers, results, verificationParameters);
         extractor.Start();

         this.answerReviewCounts = extractor.AnswerReviewCount;
         this.resultReviewCounts = extractor.ResultsReviewCount;
      }

      // this prepares the workspace for serialization to disk
      public void Pack(string filename)
      {
         this.locationOnDisk = filename;

         filenames = new List<string>();

         using (MemoryStream ms = new MemoryStream())
         {
            template.Save(ms);
            templateBytes = ms.GetBuffer();
            ms.Close();
         }

         if (answers  != null)
         {
            using (MemoryStream ms = new MemoryStream())
            {
               answers.Save(ms);
               answerBytes = ms.GetBuffer();
               ms.Close();
            }
         }

         using (MemoryStream ms = new MemoryStream())
         {
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, myImages);
            filepathDictionaryBytes = ms.GetBuffer();

            ms.Close();
         }

         reviewRequiredStatus = new bool[results.Count][][][];

         resultsBytes = new byte[results.Count][];
         for (int i = 0; i < results.Count; i++)
         {
            IRecognitionForm frm = results[i];

            reviewRequiredStatus[i] = new bool[frm.Pages.Count][][];

            for (int j = 0; j < frm.Pages.Count; j++)
            {
               reviewRequiredStatus[i][j] = new bool[frm.Pages[j].Fields.Count][];

               for (int k = 0; k < frm.Pages[j].Fields.Count; k++)
               {
                  if (frm.Pages[j].Fields[k] is OmrField)
                  {
                     reviewRequiredStatus[i][j][k] = ((OmrField)frm.Pages[j].Fields[k]).Fields.ConvertAll<bool>(delegate (OmrCollection oc) { ReviewParameters rp = oc.Tag as ReviewParameters; return rp != null ? rp.ReviewRequired : false; }).ToArray();
                  }
               }
            }

            using (MemoryStream ms = new MemoryStream())
            {
               frm.Save(ms);
               resultsBytes[i] = ms.GetBuffer();
               ms.Close();
            }
         }
      }

      // this prepares a recently deserialized workspace for use
      internal void Unpack()
      {
         InitializeDefaults();

         using (MemoryStream ms = new MemoryStream(filepathDictionaryBytes))
         {
            BinaryFormatter bf = new BinaryFormatter();
            myImages = (Dictionary<string, string>)bf.Deserialize(ms);

            ms.Close();
         }

         foreach (string key in myImages.Keys)
         {
            imageManager.Add(key, myImages[key]);
         }

         if (string.IsNullOrWhiteSpace(myAnswerkeyPath) == false)
         {
            imageManager.Add(IMGMGR_ANSWERS, myAnswerkeyPath);
         }

         template = MainForm.GetOmrEngine().CreateTemplateForm();

         results = new List<IRecognitionForm>();

         using (MemoryStream ms = new MemoryStream(templateBytes))
         {
            template.Load(ms);
         }

         templateImage = template.Pages[0].Image;
         for (int i = 1; i < template.Pages.Count; i++)
         {
            templateImage.AddPage(template.Pages[i].Image);
         }

         if (answerBytes != null)
         {
            answers = MainForm.GetOmrEngine().CreateRecognitionForm();
            using (MemoryStream ms = new MemoryStream(answerBytes))
            {
               answers.Load(ms);
            }
            answerReviewCounts = GetManualReviewCollection(answers, VerificationParameters.AllParameters);
         }

         resultReviewCounts = new ReviewCounter();

         for (int i = 0; i < resultsBytes.Length; i++)
         {
            using (MemoryStream ms = new MemoryStream(resultsBytes[i]))
            {
               IRecognitionForm frm = MainForm.GetOmrEngine().CreateRecognitionForm();

               frm.Load(ms);

               resultReviewCounts += GetManualReviewCollection(frm, VerificationParameters.AllParameters, answers, reviewRequiredStatus[i]);

               results.Add(frm);
            }
         }
      }

      public struct ReviewCounter
      {
         public int AgreeWithKey { get; set; }
         public int DisagreeWithKey { get; set; }
         public int NotExactlyOneBubble { get; set; }
         public int BelowThreshold { get; set; }
         public int Total { get { return AgreeWithKey + DisagreeWithKey + NotExactlyOneBubble + BelowThreshold; } }
         public int TotalCounts { get; set; }
         public bool IsEmpty { get { return AgreeWithKey == 0 && DisagreeWithKey == 0 && BelowThreshold == 0 && NotExactlyOneBubble == 0; } }

         public static ReviewCounter operator +(ReviewCounter a, ReviewCounter b)
         {
            ReviewCounter sum = new ReviewCounter
            {
               AgreeWithKey = a.AgreeWithKey + b.AgreeWithKey,
               DisagreeWithKey = a.DisagreeWithKey + b.DisagreeWithKey,
               BelowThreshold = a.BelowThreshold + b.BelowThreshold,
               NotExactlyOneBubble = a.NotExactlyOneBubble + b.NotExactlyOneBubble,
               TotalCounts = a.TotalCounts + b.TotalCounts
            };

            return sum;
         }

      }

      public static ReviewCounter GetManualReviewCollection(IRecognitionForm recognizeForm, VerificationParameters parameters, IRecognitionForm answers = null, bool[][][] reviewed = null)
      {
         ReviewCounter reviewCounter = new ReviewCounter();

         for (int i = 0; i < recognizeForm.Pages.Count; i++)
         {
            Page page = recognizeForm.Pages[i];
            for (int j = 0; j < page.Fields.Count; j++)
            {

               Field field = page.Fields[j];

               if (field == null)
               {
                  continue;
               }

               field.PageNumber = page.PageNumber;

               OmrField omrField = field as OmrField;

               if (omrField != null)
               {
                  for (int k = 0; k < omrField.Fields.Count; k++)
                  {
                     OmrCollection omr = omrField.Fields[k];
                     reviewCounter.TotalCounts++;

                     //string errors = "The field confidence value is below the required confidence value, the field does not have exactly one bubble filled in, the field has the same value as the answer key, the field has a different value from the answer key, ";

                     List<string> errors = new List<string>();
                     VerificationParameters erroredParams = new VerificationParameters(false, false, false, false, parameters.Threshold, false, false);

                     ReviewParameters rp = null;
                     if (omr.Tag != null)
                     {
                        rp = (ReviewParameters)omr.Tag;
                        erroredParams = rp.ErroredParameters;
                     }


                     string answerVals = null;
                     erroredParams.Threshold = omr.Confidence;

                     if (/* parameters.UseThreshold && */ omr.Confidence < parameters.Threshold)
                     {
                        errors.Add("OMR confidence value too low");
                        erroredParams.UseThreshold = true;
                        reviewCounter.BelowThreshold++;
                     }

                     //                        if (parameters.UseExactlyOneBubble)
                     {
                        int selectedCells = omr.Fields.Count<OmrBubble>(delegate (OmrBubble bub) { return bub.IsChecked; });
                        if (selectedCells != 1)
                        {
                           errors.Add("Does not have exactly one bubble filled in");
                           erroredParams.UseExactlyOneBubble = true;
                           reviewCounter.NotExactlyOneBubble++;
                        }
                     }
                     erroredParams.UseValueChanged = omr.Value != omr.OriginalValue;

                     if (answers != null && answers.Pages.Count > 0)
                     {
                        OmrField ansField = answers.Pages[i].Fields[j] as OmrField;

                        OmrFieldResult ofr = (OmrFieldResult)ansField.Result;

                        string value = ansField.Fields[k].Value;
                        answerVals = value;

                        if (/* parameters.UseAgreeWithKey && */ omr.Value == value)
                        {
                           errors.Add("Same value as answer key");
                           erroredParams.UseAgreeWithKey = true;
                           reviewCounter.AgreeWithKey++;
                        }
                        if (/* parameters.UseDisagreeWithKey && */ omr.Value != value)
                        {
                           errors.Add("Different value from answer key");
                           erroredParams.UseDisagreeWithKey = true;
                           reviewCounter.DisagreeWithKey++;
                        }
                     }

                     //page.Image.Page = omrField.PageNumber + 1;
                     if (rp != null)
                     {
                        rp.ErroredParameters = erroredParams;
                        omr.Tag = rp;
                     }
                     else
                     {
                        omr.Tag = new ReviewParameters(omrField.GetValues(), errors, answerVals, recognizeForm.Id, erroredParams, page.PageNumber);
                     }

                     if (errors.Count > 0)
                     {
                        if (reviewed != null)
                        {
                           bool flag = reviewed[i][j][k];
                           ReviewParameters rps = (ReviewParameters)omr.Tag;
                           rps.ReviewRequired = flag;

                           VerificationParameters vp = rps.ErroredParameters;
                           vp.IsReviewed = !flag;
                           rps.ErroredParameters = vp;
                        }
                     }
                  }
               }
            }
         }

         return reviewCounter;
      }

      internal string GetImageFilePath(string guid)
      {
         return myImages.ContainsKey(guid) ? myImages[guid] : string.Empty;
      }

      internal GradeOperation DoGrading()
      {
         GradeOperation grader = new GradeOperation(answers, results, PassingGrade);
         return grader;
      }
   }
}
