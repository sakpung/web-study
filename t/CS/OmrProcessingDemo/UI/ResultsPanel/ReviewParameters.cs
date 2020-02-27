using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leadtools;
using OmrProcessingDemo.UI;

namespace OmrProcessingDemo
{
   [Serializable]
   class ReviewParameters
   {
      private string answerVals;
      private List<string> errors;
      private List<string> omrValues;
      private string owningId;
      private bool reviewRequired;

      private int pageNumber;

      private VerificationParameters erroredParams;

      public List<string> Errors { get { return errors; } }
      public string AnswerVals { get { return answerVals; } }
      public List<string> OmrFieldValues { get { return omrValues; } }
      public string OwningId { get { return owningId; } }

      public bool ReviewRequired { get { return reviewRequired; } set { reviewRequired = value; } }
      public int PageNumber { get { return pageNumber; } }

      public VerificationParameters ErroredParameters { get { return erroredParams; } set { erroredParams = value; } }

      public ReviewParameters(List<string> list, List<string> errors, string answerVals, string id, VerificationParameters erroredParams, int pageNumber)
      {
         this.omrValues = list;
         this.errors = errors;
         this.answerVals = answerVals;
         this.owningId = id;
         this.erroredParams = erroredParams;
         this.pageNumber = pageNumber;

         reviewRequired = errors.Count > 0;
      }
   }
}
