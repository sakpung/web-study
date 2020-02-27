// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.Scu;
using Leadtools.Dicom.Scu.Queries;
using System.Threading;
using System.Windows.Forms;
using Leadtools.Dicom.Common.Extensions;
using Leadtools.Dicom;

namespace DicomDemo.Utils
{
    public static class DicomUtils
    {
        public static Patient FindPatient(Control owner,QueryRetrieveScu find,DicomScp scp,string pid)
        {
            PatientRootQueryPatient query = new PatientRootQueryPatient();
            Patient patient = null;
            ProgressDialog progress = new ProgressDialog();

            query.PatientQuery.PatientId = pid;
            Thread thread = new Thread(() =>
            {
                try
                {
                    find.Find<PatientRootQueryPatient, Patient>(scp, query, (p, ds) => patient = p);
                }
                catch (Exception e)
                {
                    ApplicationUtils.ShowException(owner, e);
                }
            });

            progress.ActionThread = thread;
            progress.Title = "Searching For Patient";
            progress.ProgressInfo = "Looking for patient to merge with.";            
            progress.ShowDialog(owner);
            return patient;
        }        
    }

    public class PatientUpdaterSeries : Series
    {
        [Element(DicomTag.SeriesTime)]
        public DateTime? Time { get; set; }
        public Study Study { get; set; }
    }

    internal class NoFlashListView : ListView
    {
        public NoFlashListView()
        {
            //Activate double buffering
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            //Enable the OnNotifyMessage event so we get a chance to filter out 
            // Windows messages before they get to the form's WndProc
            SetStyle(ControlStyles.EnableNotifyMessage, true);
        }

        protected override void OnNotifyMessage(Message m)
        {
            //Filter out the WM_ERASEBKGND message
            if (m.Msg != 0x14)
            {
                base.OnNotifyMessage(m);
            }
        }
    }
}
