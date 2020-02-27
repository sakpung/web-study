// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;

using Leadtools.Ocr;
using Leadtools.Document.Writer;

namespace OcrAutoRecognizeDemo
{
   public class JobData
   {
      public IOcrEngine OcrEngine;
      public string ImageFileName;
      public int FirstPageNumber;
      public int LastPageNumber;
      public DocumentFormat Format;
      public string DocumentFileName;
      public string ZonesFileName;
      public bool EnableTrace;
      public OcrAutoRecognizeManagerJobErrorMode JobErrorMode;
      public int MaximumPagesBeforeLtd;
      public int MaximumThreadsPerJob;
      public IList<OcrAutoPreprocessPageCommand> PreprocessPageCommands;
      public bool ViewFinalDocument;
   }
}
