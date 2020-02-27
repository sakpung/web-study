using System;
using System.Collections.Generic;
using Leadtools.Medical.HL7;
using Leadtools.Medical.HL7.V2x.Models;

namespace Leadtools.Medical.HL7PatientUpdate.AddIn
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
      public Leadtools.Medical.HL7.V26.Segments.PD1 PD1 { get { return Find<Leadtools.Medical.HL7.V26.Segments.PD1>("PD1"); } }
      public Leadtools.Medical.HL7.V26.Segments.PV1 PV1 { get { return Find<Leadtools.Medical.HL7.V26.Segments.PV1>("PV1"); } }
      public Leadtools.Medical.HL7.V26.Segments.EVN EVN { get { return Find<Leadtools.Medical.HL7.V26.Segments.EVN>("EVN"); } }
      public Leadtools.Medical.HL7.V26.Segments.ROL ROL { get { return Find<Leadtools.Medical.HL7.V26.Segments.ROL>("ROL"); } }
      public Leadtools.Medical.HL7.V26.Segments.IN1 IN1 { get { return Find<Leadtools.Medical.HL7.V26.Segments.IN1>("IN1"); } }
      public Leadtools.Medical.HL7.V26.Segments.IN2 IN2 { get { return Find<Leadtools.Medical.HL7.V26.Segments.IN2>("IN2"); } }
      public Leadtools.Medical.HL7.V26.Segments.DG1 DG1 { get { return Find<Leadtools.Medical.HL7.V26.Segments.DG1>("DG1"); } }
      public Leadtools.Medical.HL7.V26.Segments.NK1 NK1 { get { return Find<Leadtools.Medical.HL7.V26.Segments.NK1>("NK1"); } }
      public Leadtools.Medical.HL7.V26.Segments.GT1 GT1 { get { return Find<Leadtools.Medical.HL7.V26.Segments.GT1>("GT1"); } }
      public Leadtools.Medical.HL7.V26.Segments.MRG MRG { get { return Find<Leadtools.Medical.HL7.V26.Segments.MRG>("MRG"); } }
      public Leadtools.Medical.HL7.V26.Segments.Zxx Zxx { get { return FindZSeg(); } }
   }
}
