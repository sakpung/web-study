using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OmrProcessingDemo.UI
{
   public class CloseRequestArgs : EventArgs
   {
      public ClosingReason ClosingState { get; private set; }

      public enum ClosingReason
      {
         RevertToIntro,
         ExplicitNew,
         ToLoadExisting,
         ApplicationExiting
      }

      public CloseRequestArgs(ClosingReason closeState) : base()
      {
         this.ClosingState = closeState;
      }
   }
}
