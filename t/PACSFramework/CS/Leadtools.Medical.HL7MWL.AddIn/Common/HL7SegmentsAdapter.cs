// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using Leadtools.Medical.HL7;
using Leadtools.Medical.HL7.V2x.Models;

namespace Leadtools.Medical.HL7MWL.AddIn
{
   internal class HL7SegmentsAdapter
   {
      private List<Segment> _segments = null;
      public HL7SegmentsAdapter(List<Segment> segments)
      {
         _segments = segments;
      }

      public List<Segment> FindAll(string name)
      {
         return _segments.FindAll((s) => s.Schema.ItemName == name);
      }

      public Segment Find(string name)
      {
         return _segments.Find((s) => s.Schema.ItemName == name);
      }

      public Leadtools.Medical.HL7.V26.Segments.Zxx FindZSeg()
      {
         return _segments.Find((s) => s.Schema.ItemName[0] == 'Z' || s.Schema.ItemName[0] == 'z') as HL7.V26.Segments.Zxx;
      }

      public T Find<T>(string name) where T : class
      {
         return Find(name) as T;
      }
      public Leadtools.Medical.HL7.V26.Segments.MSH MSH { get { return Find<Leadtools.Medical.HL7.V26.Segments.MSH>("MSH"); } }
      public Leadtools.Medical.HL7.V26.Segments.PID PID { get { return Find<Leadtools.Medical.HL7.V26.Segments.PID>("PID"); } }
      public Leadtools.Medical.HL7.V26.Segments.PV1 PV1 { get { return Find<Leadtools.Medical.HL7.V26.Segments.PV1>("PV1"); } }
      public Leadtools.Medical.HL7.V26.Segments.ORC ORC { get { return Find<Leadtools.Medical.HL7.V26.Segments.ORC>("ORC"); } }
      public Leadtools.Medical.HL7.V26.Segments.OBR OBR { get { return Find<Leadtools.Medical.HL7.V26.Segments.OBR>("OBR"); } }
      public Leadtools.Medical.HL7.V26.Segments.EVN EVN { get { return Find<Leadtools.Medical.HL7.V26.Segments.EVN>("EVN"); } }
      public Leadtools.Medical.HL7.V26.Segments.ROL ROL { get { return Find<Leadtools.Medical.HL7.V26.Segments.ROL>("ROL"); } }
      public Leadtools.Medical.HL7.V26.Segments.TQ1 TQ1 { get { return Find<Leadtools.Medical.HL7.V26.Segments.TQ1>("TQ1"); } }
      public Leadtools.Medical.HL7.V26.Segments.IPC IPC { get { return Find<Leadtools.Medical.HL7.V26.Segments.IPC>("IPC"); } }
      public Leadtools.Medical.HL7.V26.Segments.AL1 AL1 { get { return Find<Leadtools.Medical.HL7.V26.Segments.AL1>("AL1"); } }
      public Leadtools.Medical.HL7.V26.Segments.OBX OBX { get { return Find< Leadtools.Medical.HL7.V26.Segments.OBX>("OBX"); } }
      public Leadtools.Medical.HL7.V26.Segments.Zxx Zxx { get { return FindZSeg(); } }

      //IPC

   }
}
