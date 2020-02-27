// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;

using Leadtools.Ocr;
using Leadtools.Document.Writer;

namespace OcrMultiThreadingDemo
{
   public class StartConversionEventArgs : EventArgs
   {
      private OcrEngineType _engineType;
      private string[] _sourceFiles;
      private string _destinationDirectory;
      private DocumentFormat _format;
      private bool _loopContinuously;

      public StartConversionEventArgs(OcrEngineType engineType, string[] sourceFiles, string destinationDirectory, DocumentFormat format, bool loopContinuously)
      {
         _engineType = engineType;
         _sourceFiles = sourceFiles;
         _destinationDirectory = destinationDirectory;
         _format = format;
         _loopContinuously = loopContinuously;
      }

      public OcrEngineType EngineType
      {
         get { return _engineType; }
      }

      public string[] SourceFiles
      {
         get { return _sourceFiles; }
      }

      public string DestinationDirectory
      {
         get { return _destinationDirectory; }
      }

      public DocumentFormat Format
      {
         get { return _format; }
      }

      public bool LoopContinuously
      {
         get { return _loopContinuously; }
      }
   }
}
