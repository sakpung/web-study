// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leadtools.Medical.Winforms.ExternalStore
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

   public class ExternalStoreMessageEventArgs : SendMessageEventArgs
   {
      private string _ExternalStoreTo;

      public string ExternalStoreTo
      {
         get { return _ExternalStoreTo; }
      }

      public ExternalStoreMessageEventArgs(string id,string destination) : base(id)
      {
         _ExternalStoreTo = destination;
      }
   }

   public class CleanMessageEventArgs : SendMessageEventArgs
   {
      private string _ExternalStoreTo;
      public string ExternalStoreTo
      {
         get { return _ExternalStoreTo; }
      }

      private int _expirationDays;
      public int ExpirationDays
      {
         get { return _expirationDays; }
      }

      public CleanMessageEventArgs(string id,string destination, int expirationDays) : base(id)
      {
         _ExternalStoreTo = destination;
         _expirationDays = expirationDays;
      }
   }

   public class RestoreMessageEventArgs : SendMessageEventArgs
   {
      private string _RestoreFrom;

      public string RestoreFrom
      {
         get { return _RestoreFrom; }
      }

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

      public RestoreMessageEventArgs(string id, string externalStoreSource, DateTime startDate, DateTime? endDate) : base(id)
      {
         _RestoreFrom = externalStoreSource;
         _Start = startDate;
         _End = endDate;
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
