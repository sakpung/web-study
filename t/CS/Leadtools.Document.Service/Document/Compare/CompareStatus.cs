using System;
namespace Leadtools.Document.Service.Document.Compare
{
   [Serializable]
   public enum CompareStatus
   {
      Aborted,
      Comparing,
      GeneratingReport,
      Completed,
      Failed
   }
}
