using Leadtools.Forms.Processing.Omr.Fields;
using Leadtools.Forms.Processing.Omr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmrProcessingDemo.Operations
{
   class GradeOperation : BusyOperation
   {
      private List<IRecognitionForm> results;
      private IRecognitionForm answers;
      private OmrAnalysisEngine omrAnalysisEngine;
      private string[,] statsArray;
      private string[,] invertedStats;
      public List<IRecognitionForm> Results { get { return results; } }

      private int passingScore;
      private OmrGradesStatistics statistics;

      public int PassingScore { get { return passingScore; } }
      public OmrGradesStatistics Statistics { get { return statistics; } }
      public Dictionary<string, QuestionAnswers> QuestionAnswers { get { return omrAnalysisEngine != null ?  omrAnalysisEngine.QuestionsAnswers : null; } }
      public string[,] StatsArray { get { return statsArray; } }
      public string[,] InvertedStats { get { return invertedStats; } }

      public GradeOperation(IRecognitionForm answerKey, List<IRecognitionForm> toGrade, int passingGrade)
      {
         this.answers = answerKey;
         this.results = toGrade;
         this.passingScore = passingGrade;

         useWaitWindow = false;
      }

      protected override void StartThread()
      {
         try
         {
            Run();
         }
         catch (Exception)
         {
            // don't interfere with exceptions to still generate as much info as possible
         }
         finally
         {
            Complete();
         }
      }

      protected override void Run()
      {
         int step = Math.Max(100 / (results.Count + 1), 1);

         Progress(101, "Grading...");

         omrAnalysisEngine = new OmrAnalysisEngine(results, answers);
         omrAnalysisEngine.PassingScore = passingScore;
         Generate();
         Invert();

         statistics = omrAnalysisEngine.GradeForms();

         base.Run();
      }

      private void Generate()
      {
         Dictionary<string, QuestionAnswers> localQa = omrAnalysisEngine.QuestionsAnswers;

         List<string> detectedKeys = new List<string>();
         foreach (KeyValuePair<string, QuestionAnswers> kvp in localQa)
         {
            detectedKeys.AddRange(kvp.Value.AnswersCount.Keys);
         }

         detectedKeys = detectedKeys.Distinct().ToList();

         int length = detectedKeys.Count + 1;
         int width = localQa.Count + 1;

         statsArray = new string[length, width];

         // build header
         int ticker = 1;
         foreach (KeyValuePair<string, QuestionAnswers> kvp in localQa)
         {
            statsArray[0, ticker] = kvp.Key;
            ticker++;
         }

         for (int i = 0; i < detectedKeys.Count; i++)
         {
            string masterKey = detectedKeys[i];
            statsArray[i + 1, 0] = masterKey;

            for (int j = 0; j < width; j++)
            {
               string currentKey = statsArray[0, j];
               if (currentKey == null || localQa.ContainsKey(currentKey) == false)
               {
                  continue;
               }
               QuestionAnswers qa = localQa[currentKey];

               if (qa.AnswersCount == null || qa.AnswersCount.ContainsKey(masterKey) == false)
               {
                  continue;
               }
               statsArray[i + 1, j] = qa.AnswersCount[detectedKeys[i]].ToString();
            }
         }
      }
      private void Invert()
      {
         int length = statsArray.GetLength(1);
         int width = statsArray.GetLength(0);

         invertedStats = new string[length, width];

         for (int i = 0; i < length; i++)
         {
            for (int j = 0; j < width; j++)
            {
               invertedStats[i, j] = statsArray[j, i];
            }
         }
      }
   }
}
