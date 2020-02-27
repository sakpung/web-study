using System;
using Leadtools.Dicom;
using Leadtools.Dicom.Scp;
using Leadtools.Dicom.Scp.Command;
using Leadtools.Dicom.Common.Extensions;
using Leadtools.Dicom.Common.DataTypes.PatientUpdater;
using Leadtools.Dicom.AddIn;
using Leadtools.Dicom.Scu;
using System.Net;

namespace Leadtools.Medical.HL7PatientUpdate.AddIn
{
   static internal class NActionClient
   {
      static private string ResolveUID()
      {
         return PatientUpdaterConstants.UID.PatientUpdateInstance;
      }
      static public void ChangePatient(Dicom.Common.DataTypes.PatientUpdater.ChangePatient data, string aeTitle)
      {
         var aeSrv = HL7ServerPatientUpdate.DicomServer.AETitle;
         var ipSrv = HL7ServerPatientUpdate.DicomServer.HostAddress;
         var portSrv = HL7ServerPatientUpdate.DicomServer.Port;
         var scp = new DicomScp(IPAddress.Parse(ipSrv), aeSrv, portSrv);
         var scu = new PatientUpdaterScu(null);
         scu.AETitle = aeTitle;
         var status = scu.ChangePatient(scp, data);
         if (status != DicomCommandStatusType.Success)
         {
            throw new Exception(status.ToString());
         }
      }
      static public void MergePatient(Dicom.Common.DataTypes.PatientUpdater.MergePatient data, string aeTitle)
      {
         var aeSrv = HL7ServerPatientUpdate.DicomServer.AETitle;
         var ipSrv = HL7ServerPatientUpdate.DicomServer.HostAddress;
         var portSrv = HL7ServerPatientUpdate.DicomServer.Port;
         var scp = new DicomScp(IPAddress.Parse(ipSrv), aeSrv, portSrv);
         var scu = new PatientUpdaterScu(null);
         scu.AETitle = aeTitle;
         var status = scu.MergePatient(scp, data);
         if (status != DicomCommandStatusType.Success)
         {
            throw new Exception(status.ToString());
         }
      }
   }
}
