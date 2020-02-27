// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Leadtools.Medical.WebViewer.Services.Interfaces
{  
   public interface IMessagesBus : IDisposable
   {
      Task SendSingle(string to, object obj);
      Task<List<T>> GetMany<T>(string to);
      Task Drain(string to);
      Task SetStatus(string id, object status);
      Task<T> GetStatus<T>(string id);
   }
}
