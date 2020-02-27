// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leadtools.Medical.Winforms.Forwarder
{
   public class SendMessageEventArgs : EventArgs
   {
      private string _MessageId;

      public string MessageId
      {
         get { return _MessageId; }
      }

      public SendMessageEventArgs(string id)
      {
         _MessageId = id;
      }
   }

   public class ForwardMessageEventArgs : SendMessageEventArgs
   {
      private string _ForwardTo;

      public string ForwardTo
      {
         get { return _ForwardTo; }
      }

      public ForwardMessageEventArgs(string id,string destination) : base(id)
      {
         _ForwardTo = destination;
      }
   }

   public class ResetEventArgs : SendMessageEventArgs
   {
      private DateTime _Start;

      public DateTime Start
      {
         get { return _Start; }
      }

      private DateTime? _End;

      public DateTime? End
      {
         get { return _End; }
      }

      public ResetEventArgs(string messageId, DateTime startDate, DateTime? endDate) : base(messageId)
      {
         _Start = startDate;
         _End = endDate;
      }
   }
}
