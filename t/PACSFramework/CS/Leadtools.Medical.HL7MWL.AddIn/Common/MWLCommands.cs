// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using Leadtools.Medical.Worklist.DataAccessLayer.BusinessEntity;
using Leadtools.Medical.Worklist.DataAccessLayer.MatchingParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leadtools.Medical.HL7MWL.AddIn
{
   public static class MWLCommandsFactory
   {
      private static IMWLCommand AddCommand(IHL7MessageAdapter hl7, bool pps)
      {
         var patient = new AddPatient(hl7.getPatient());
         var image = new AddImageServiceRequest(hl7.getPatient(), hl7.getImageServiceRequest());
         var visit = new AddVisit(hl7.getVisit());
         var procedure = new AddRequestedProcedure(hl7.getImageServiceRequest(), hl7.getProcedure());
         var scheduled = new AddScheduledProcedureStep(hl7.getImageServiceRequest(), hl7.getProcedure(), hl7.getProcedureStep());

         var cmd = (new TransactionCommand()).Add(patient).Add(image).Add(visit).Add(procedure).Add(scheduled);

         if (pps)
         {
            var addpps = new AddPPSInformation(hl7.getPPS());
            cmd.Add(addpps);
         }

         return cmd.Add(new ResolveLinks());
      }

      private static IMWLCommand UpdateCommand(IHL7MessageAdapter hl7, bool pps)
      {
         var patient = new UpdatePatient(hl7.getPatient());
         var image = new UpdateImageServiceRequest(hl7.getPatient(), hl7.getImageServiceRequest());
         var visit = new UpdateVisit(hl7.getVisit());
         var procedure = new UpdateRequestedProcedure(hl7.getImageServiceRequest(), hl7.getProcedure());
         var scheduled = new UpdateScheduledProcedureStep(hl7.getImageServiceRequest(), hl7.getProcedure(), hl7.getProcedureStep());

         var cmd = (new CompositeCommand()).Add(patient).Add(image).Add(visit).Add(procedure).Add(scheduled);

         if (pps)
         {
            var addpps = new UpdatePPSInformation(hl7.getPPS());
            cmd.Add(addpps);
         }

         ResolveLinks.Execute(hl7);

         return cmd;
      }

      private static IMWLCommand DeleteCommand(IHL7MessageAdapter hl7, bool pps)
      {
         var patient = new DeletePatient(hl7.getPatient());
         var image = new DeleteImageServiceRequest(hl7.getPatient(), hl7.getImageServiceRequest());
         var visit = new DeleteVisit(hl7.getVisit());
         var procedure = new DeleteRequestedProcedure(hl7.getImageServiceRequest(), hl7.getProcedure());
         var scheduled = new DeleteScheduledProcedureStep(hl7.getProcedure(), hl7.getProcedureStep());

         var cmd = (new CompositeCommand()).Add(patient).Add(image).Add(scheduled).Add(procedure).Add(visit);

         if (pps)
         {
            var addpps = new DeletePPSInformation(hl7.getPPS());
            cmd.Add(addpps);
         }

         ResolveLinks.Execute(hl7);

         return cmd;
      }
      public static IMWLCommand MapHL7ToMWLCommand(IHL7MessageAdapter hl7, bool pps)
      {
         if (hl7.getOrderControl()== "NW")
         {
            var add = AddCommand(hl7, pps);

            if (HL7ServerMWL.HL7Options.HandleDuplicates)
            {
               add.WhenFailed = UpdateCommand(hl7, pps);
            }

            return add;
         }
         else if (hl7.getOrderControl() == "XO")
         {
            return UpdateCommand(hl7, pps);
         }
         else if (hl7.getOrderControl() == "CA" || hl7.getOrderControl() == "DC")
         {
            return DeleteCommand(hl7, pps);
         }
         else
         {
            throw new Exception("The order control is not recognized.");
         }
      }
   }

   public interface IMWLCommand
   {
      void Execute();
      string Desc();
      object State { get; set; }

      IMWLCommand WhenFailed { get; set; }
   }

   internal abstract class IMWLCommandBase : IMWLCommand
   {
      public virtual string Desc()
      {
         return GetType().Name;
      }

      public virtual void Execute()
      {
         throw new NotImplementedException();
      }

      public object State { get; set; }

      public IMWLCommand WhenFailed { get; set; } = null;
   }

   internal class CompositeCommand : IMWLCommandBase
   {
      List<IMWLCommand> _lst = new List<IMWLCommand>();
            
      public CompositeCommand Add(IMWLCommand cmd)
      {
         _lst.Add(cmd);
         return this;
      }
      
      public override void Execute()
      {         
         foreach (var cmd in _lst)
         {
            cmd.Execute();
         }
      }

      public override string Desc()
      {
         var sb = new StringBuilder();
         foreach (var cmd in _lst)
         {
            sb.Append(cmd.Desc());
            sb.Append(",");
         }
         sb.Remove(sb.Length - 1, 1);
         return sb.ToString();
      }
   }

   internal class TransactionCommand : IMWLCommandBase
   {
      List<IMWLCommand> _lst = new List<IMWLCommand>();

      public TransactionCommand Add(IMWLCommand cmd)
      {
         _lst.Add(cmd);
         return this;
      }

      public override void Execute()
      {
         var broker = new BrokerService();
         var transaction = broker.BeginTransaction();
         Exception _ex_ = null;

         try
         {
            foreach (var cmd in _lst)
            {
               cmd.State = transaction;
               cmd.Execute();
            }
            broker.CommitTransaction(transaction);
         }
         catch(Exception ex)
         {
            _ex_ = ex;
            broker.RollbackTransaction(transaction);
         }

         if (null != _ex_)
         {
            if (WhenFailed != null)
            {
               WhenFailed.Execute();
            }
            else
            {
               throw _ex_;
            }
         }
      }

      public override string Desc()
      {
         var sb = new StringBuilder();
         foreach (var cmd in _lst)
         {
            sb.Append(cmd.Desc());
            sb.Append(",");
         }
         sb.Remove(sb.Length - 1, 1);
         return sb.ToString();
      }
   }

   internal class ResolveLinks : IMWLCommandBase
   {
      public static void Execute(IHL7MessageAdapter hl7)
      {
         var AccessionNumber = hl7.getImageServiceRequest()?.AccessionNumber;
         if (string.IsNullOrEmpty(AccessionNumber))
         {
            AccessionNumber = UniqueIdProvider.NewUnique16BytesId();
         }

         var AdmissionID = hl7.getVisit()?.AdmissionID;
         if (string.IsNullOrEmpty(AdmissionID))
         {
            AdmissionID = UniqueIdProvider.NewUnique16BytesId();
         }

         if (null != hl7.getVisit()) hl7.getVisit().AdmissionID = AdmissionID;
         if (null != hl7.getImageServiceRequest()) hl7.getImageServiceRequest().AccessionNumber = AccessionNumber;
         if (null != hl7.getProcedure()) hl7.getProcedure().RequestedProcedureID = AccessionNumber;
         if (null != hl7.getProcedureStep()) hl7.getProcedureStep().ScheduledProcedureStepID = AccessionNumber;
      }
      public override void Execute()
      {
         var ds = State as MWLDataset;
         
         {
            var pr = ds.Patient.Count > 0 ? ds.Patient[0]:null;
            var vr = ds.Visit.Count > 0 ? ds.Visit[0] : null;
            var isrr = ds.ImagingServiceRequest.Count > 0? ds.ImagingServiceRequest[0] : null;
            var rpr = ds.RequestedProcedure.Count > 0? ds.RequestedProcedure[0] : null;
            var rfps = ds.ReferencedPatientSequence.Count > 0 ? ds.ReferencedPatientSequence[0]:null;
            var spsr = ds.ScheduledProcedureStep.Count > 0? ds.ScheduledProcedureStep[0] : null;
            var ssaetr = ds.ScheduledStationAETitles.Count > 0? ds.ScheduledStationAETitles[0] : null;

            var AccessionNumber = isrr.AccessionNumber;
            if (string.IsNullOrEmpty(AccessionNumber))
            {
               AccessionNumber = UniqueIdProvider.NewUnique16BytesId();
            }

            var AdmissionID = vr?.AdmissionID;
            if (string.IsNullOrEmpty(AdmissionID))
            {
               AdmissionID = UniqueIdProvider.NewUnique16BytesId();
            }

            if (null != vr) vr.AdmissionID = AdmissionID;
            if (null != rpr) rpr.AdmissionID = AdmissionID;
            if (null != rfps) rfps.AdmissionID = AdmissionID;
            if (null != isrr) isrr.AccessionNumber = AccessionNumber;
            if (null != rpr) rpr.AccessionNumber = AccessionNumber;
            if (null != rpr) rpr.RequestedProcedureID = AccessionNumber;
            if (null != spsr) spsr.ScheduledProcedureStepID = AccessionNumber;
            if (null != spsr) spsr.AccessionNumber = AccessionNumber;
            if (null != spsr) spsr.RequestedProcedureID = AccessionNumber;
            if (null != ssaetr) ssaetr.ScheduledProcedureStepID = AccessionNumber;
         }
      }
   }
   internal class AddPatient : IMWLCommandBase
   {
      private WCFPatient _patient = null;
      
      public AddPatient(WCFPatient patient)
      {
         _patient = patient;
      }
      public override void Execute()
      {
         Guard.ArgumentNotNull(_patient, "_patient");
         Guard.ArgumentNotNullOrEmpty(_patient.IssuerOfPatientID, "IssuerOfPatientID");
         
         var broker = new BrokerService();

         var p = broker.FindPatient(_patient.PatientID, _patient.IssuerOfPatientID);
         if (p != null)
         {
            throw new ArgumentException("Patient already exist");
         }

         broker.AddPatient(_patient, State as MWLDataset);
      }
   }
   internal class AddImageServiceRequest : IMWLCommandBase
   {
      private ImagingServiceRequest _imageServiceRequest = null;
      private WCFPatient _patient = null;
      

      public AddImageServiceRequest(WCFPatient patient, ImagingServiceRequest imageServiceRequest)
      {
         _imageServiceRequest = imageServiceRequest;
         _patient = patient;
      }
      public override void Execute()
      {
         Guard.ArgumentNotNull(_imageServiceRequest.AccessionNumber, "_imageServiceRequest.AccessionNumber");

         var broker = new BrokerService();

         var r = broker.FindImagingServiceRequest(_imageServiceRequest.AccessionNumber, _patient.PatientID, _patient.IssuerOfPatientID);
         if (r != null)
         {
            throw new ArgumentException("ImageServiceRequest already exist.");
         }
         broker.AddImagingServiceRequest(_patient.PatientID, _patient.IssuerOfPatientID, _imageServiceRequest, State as MWLDataset);
      }
   }

   internal class AddVisit : IMWLCommandBase
   {
      WCFVisit _visit = null;
      

      public AddVisit(WCFVisit visit)
      {
         _visit = visit;
      }
      public override void Execute()
      {
         Guard.ArgumentNotNull(_visit.AdmissionID, "_visit.AdmissionID");

         var broker = new BrokerService();

         var v = broker.FindVisit(_visit.AdmissionID);
         if (v != null)
            throw new ArgumentException("Visit already exist.");

         broker.AddVisit(_visit, State as MWLDataset);
      }
   }

   internal class AddRequestedProcedure : IMWLCommandBase
   {
      private ImagingServiceRequest _imageServiceRequest = null;
      private WCFRequestedProcedure _procedure = null;
      
      public AddRequestedProcedure(ImagingServiceRequest imageServiceRequest, WCFRequestedProcedure procedure)
      {
         _imageServiceRequest = imageServiceRequest;
         _procedure = procedure;
      }
      public override void Execute()
      {
         Guard.ArgumentNotNull(_imageServiceRequest.AccessionNumber, "_imageServiceRequest.AccessionNumber");

         var broker = new BrokerService();
         broker.AddRequestedProcedure(_imageServiceRequest.AccessionNumber, _procedure, State as MWLDataset);
      }
   }

   internal class AddScheduledProcedureStep : IMWLCommandBase
   {
      private ImagingServiceRequest _imageServiceRequest = null;
      private WCFRequestedProcedure _procedure = null;
      private WCFScheduledProcedureStep _procedureStep = null;
      
      public AddScheduledProcedureStep(ImagingServiceRequest imageServiceRequest, WCFRequestedProcedure procedure, WCFScheduledProcedureStep procedureStep)
      {
         _imageServiceRequest = imageServiceRequest;
         _procedure = procedure;
         _procedureStep = procedureStep;
      }
      public override void Execute()
      {
         Guard.ArgumentNotNull(_procedureStep.ScheduledProcedureStepID, "_procedureStep.ScheduledProcedureStepID");
         
         var broker = new BrokerService();
         broker.AddScheduledProcedureStep(_imageServiceRequest.AccessionNumber, _procedure.RequestedProcedureID, _procedureStep, State as MWLDataset);
      }
   }

   internal class AddPPSInformation : IMWLCommandBase
   {
      private WCFPPSInformation _pps=null;

      
      public AddPPSInformation(WCFPPSInformation pps)
      {
         _pps = pps;
      }
      public override void Execute()
      {
         var broker = new BrokerService();

         var p = broker.FindMPPS(_pps.MPPSSOPInstanceUID);
         if (p != null)
         {
            throw new ArgumentException("PPS Information already exist.");
         }

         broker.AddMPPS(_pps);
      }
   }

   internal class UpdatePatient : IMWLCommandBase
   {
      private WCFPatient _patient = null;

      
      public UpdatePatient(WCFPatient patient)
      {
         _patient = patient;
      }
      public override void Execute()
      {
         Guard.ArgumentNotNull(_patient, "_patient");
         Guard.ArgumentNotNullOrEmpty(_patient.IssuerOfPatientID, "IssuerOfPatientID");

         var broker = new BrokerService();

         var p = broker.FindPatient(_patient.PatientID, _patient.IssuerOfPatientID);
         if (p != null)
         {
            broker.UpdatePatient(_patient.PatientID, _patient.IssuerOfPatientID, _patient);
         }
         else
         {
            broker.AddPatient(_patient);
         }
      }
   }
   internal class UpdateImageServiceRequest : IMWLCommandBase
   {
      private ImagingServiceRequest _imageServiceRequest = null;
      private WCFPatient _patient = null;
      

      public UpdateImageServiceRequest(WCFPatient patient, ImagingServiceRequest imageServiceRequest)
      {
         _imageServiceRequest = imageServiceRequest;
         _patient = patient;
      }
      public override void Execute()
      {
         Guard.ArgumentNotNull(_imageServiceRequest.AccessionNumber, "_imageServiceRequest.AccessionNumber");

         var broker = new BrokerService();

         var r = broker.FindImagingServiceRequest(_imageServiceRequest.AccessionNumber, _patient.PatientID, _patient.IssuerOfPatientID);
         if (r != null)
         {
            broker.UpdateImagingServiceRequest(_imageServiceRequest.AccessionNumber, _patient.PatientID, _patient.IssuerOfPatientID, _imageServiceRequest);
         }
         else
         {
            broker.AddImagingServiceRequest(_patient.PatientID, _patient.IssuerOfPatientID, _imageServiceRequest);
         }
      }
   }
   internal class UpdateVisit : IMWLCommandBase
   {
      WCFVisit _visit = null;
      

      public UpdateVisit(WCFVisit visit)
      {
         _visit = visit;
      }
      public override void Execute()
      {
         Guard.ArgumentNotNull(_visit.AdmissionID, "_visit.AdmissionID");

         var broker = new BrokerService();
         
         var v = broker.FindVisit(_visit.AdmissionID);
         if (v != null)
         {
            broker.UpdateVisit(_visit.AdmissionID, _visit);
         }
         else
         {
            //because of legacy behavior some visit records might have been left orphaned, we need to delete first
            broker.DeleteThenAddVisit(_visit);
         }
      }
   }
   internal class UpdateRequestedProcedure : IMWLCommandBase
   {
      private ImagingServiceRequest _imageServiceRequest = null;
      private WCFRequestedProcedure _procedure = null;
      

      public UpdateRequestedProcedure(ImagingServiceRequest imageServiceRequest, WCFRequestedProcedure procedure)
      {
         _imageServiceRequest = imageServiceRequest;
         _procedure = procedure;
      }
      public override void Execute()
      {
         Guard.ArgumentNotNull(_imageServiceRequest.AccessionNumber, "_imageServiceRequest.AccessionNumber");

         var broker = new BrokerService();

         var p = broker.FindRequestedProcedure(_imageServiceRequest.AccessionNumber, _procedure.RequestedProcedureID);
         if (p != null)
         {
            broker.UpdateRequestedProcedure(_imageServiceRequest.AccessionNumber, _procedure.RequestedProcedureID, _procedure);
         }
         else
         {
            broker.AddRequestedProcedure(_imageServiceRequest.AccessionNumber, _procedure);
         }
      }
   }
   internal class UpdateScheduledProcedureStep : IMWLCommandBase
   {
      private ImagingServiceRequest _imageServiceRequest = null;
      private WCFRequestedProcedure _procedure = null;
      private WCFScheduledProcedureStep _procedureStep = null;
      

      public UpdateScheduledProcedureStep(ImagingServiceRequest imageServiceRequest, WCFRequestedProcedure procedure, WCFScheduledProcedureStep procedureStep)
      {
         _imageServiceRequest = imageServiceRequest;
         _procedure = procedure;
         _procedureStep = procedureStep;
      }
      public override void Execute()
      {
         Guard.ArgumentNotNull(_procedureStep.ScheduledProcedureStepID, "_procedureStep.ScheduledProcedureStepID");

         var broker = new BrokerService();

         var p = broker.FindScheduledProcedureStep(_procedureStep.ScheduledProcedureStepID);
         if (p != null)
         {
            broker.UpdateScheduledProcedureStep(_procedure.RequestedProcedureID, _procedureStep);
         }
         else
         {
            broker.AddScheduledProcedureStep(_imageServiceRequest.AccessionNumber, _procedure.RequestedProcedureID, _procedureStep);
         }
      }
   }

   internal class UpdatePPSInformation : IMWLCommandBase
   {
      private WCFPPSInformation _pps = null;
      

      public UpdatePPSInformation(WCFPPSInformation pps)
      {
         _pps = pps;
      }
      public override void Execute()
      {
         var broker = new BrokerService();

         var p = broker.FindMPPS(_pps.MPPSSOPInstanceUID);
         if (p != null)
         {
            broker.UpdateMPPS(_pps.MPPSSOPInstanceUID, _pps);
         }
         else
         {
            broker.AddMPPS(_pps);
         }
      }
   }
   
   internal class DeletePatient : IMWLCommandBase
   {
      private WCFPatient _patient = null;
      

      public DeletePatient(WCFPatient patient)
      {
         _patient = patient;
      }
      public override void Execute()
      {
         Guard.ArgumentNotNull(_patient, "_patient");
         Guard.ArgumentNotNullOrEmpty(_patient.IssuerOfPatientID, "IssuerOfPatientID");

         var broker = new BrokerService();

         var p = broker.FindPatient(_patient.PatientID, _patient.IssuerOfPatientID);
         if (p != null)
         {
            //deletes patient only and leave the cascade operation to db engine:
            //broker.DeletePatient(_patient.PatientID, _patient.IssuerOfPatientID);

            //enforce deleting all logically related records:
            broker.DeletePatientAndRelatedRecords(_patient.PatientID, _patient.IssuerOfPatientID);
         }
      }
   }
   internal class DeleteImageServiceRequest : IMWLCommandBase
   {
      private ImagingServiceRequest _imageServiceRequest = null;
      private WCFPatient _patient = null;
      

      public DeleteImageServiceRequest(WCFPatient patient, ImagingServiceRequest imageServiceRequest)
      {
         _imageServiceRequest = imageServiceRequest;
         _patient = patient;
      }
      public override void Execute()
      {
         Guard.ArgumentNotNull(_imageServiceRequest.AccessionNumber, "_imageServiceRequest.AccessionNumber");

         var broker = new BrokerService();

         var r = broker.FindImagingServiceRequest(_imageServiceRequest.AccessionNumber, _patient.PatientID, _patient.IssuerOfPatientID);
         if (r != null)
         {
            broker.DeleteImagingServiceRequest(_imageServiceRequest.AccessionNumber, _patient.PatientID, _patient.IssuerOfPatientID);
         }
      }
   }
   internal class DeleteVisit : IMWLCommandBase
   {
      WCFVisit _visit = null;
      

      public DeleteVisit(WCFVisit visit)
      {
         _visit = visit;
      }
      public override void Execute()
      {
         Guard.ArgumentNotNull(_visit.AdmissionID, "_visit.AdmissionID");

         var broker = new BrokerService();

         var v = broker.FindVisit(_visit.AdmissionID);
         if (v != null)
         {
            broker.DeleteVisit(_visit.AdmissionID);
         }
      }
   }
   internal class DeleteRequestedProcedure : IMWLCommandBase
   {
      private ImagingServiceRequest _imageServiceRequest = null;
      private WCFRequestedProcedure _procedure = null;
      
      public DeleteRequestedProcedure(ImagingServiceRequest imageServiceRequest, WCFRequestedProcedure procedure)
      {
         _imageServiceRequest = imageServiceRequest;
         _procedure = procedure;
      }
      public override void Execute()
      {
         Guard.ArgumentNotNull(_imageServiceRequest.AccessionNumber, "_imageServiceRequest.AccessionNumber");

         var broker = new BrokerService();

         var p = broker.FindRequestedProcedure(_imageServiceRequest.AccessionNumber, _procedure.RequestedProcedureID);
         if (p != null)
         {
            broker.DeleteRequestedProcedure(_imageServiceRequest.AccessionNumber, _procedure.RequestedProcedureID);
         }
      }
   }
   internal class DeleteScheduledProcedureStep : IMWLCommandBase
   {
      private WCFRequestedProcedure _procedure = null;
      private WCFScheduledProcedureStep _procedureStep = null;
      
      public DeleteScheduledProcedureStep(WCFRequestedProcedure procedure, WCFScheduledProcedureStep procedureStep)
      {
         _procedure = procedure;
         _procedureStep = procedureStep;
      }
      public override void Execute()
      {
         Guard.ArgumentNotNull(_procedureStep.ScheduledProcedureStepID, "_procedureStep.ScheduledProcedureStepID");

         var broker = new BrokerService();

         var p = broker.FindScheduledProcedureStep(_procedureStep.ScheduledProcedureStepID);
         if (p != null)
         {
            broker.DeleteScheduledProcedureStep(_procedure.RequestedProcedureID);
         }
      }
   }

   internal class DeletePPSInformation : IMWLCommandBase
   {
      private WCFPPSInformation _pps = null;
      
      public DeletePPSInformation(WCFPPSInformation pps)
      {
         _pps = pps;
      }
      public override void Execute()
      {
         var broker = new BrokerService();

         var p = broker.FindMPPS(_pps.MPPSSOPInstanceUID);
         if (p != null)
         {
            broker.DeleteMPPS(_pps.MPPSSOPInstanceUID);
         }
      }

   }
}
