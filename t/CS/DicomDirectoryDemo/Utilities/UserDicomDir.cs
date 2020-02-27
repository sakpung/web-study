// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System.Windows.Forms;
using Leadtools.Dicom;

namespace DicomDemo
{
    public class UserDicomDir : DicomDir
    {
        // Private members
        private TextBox m_txtStatus;
        private int m_nAddedDicomFilesCount;

        // Constructors
        public UserDicomDir() : base() 
        {
            m_nAddedDicomFilesCount = 0;
        }
        
        public new void Reset(string destinationFolder)
        {
            m_nAddedDicomFilesCount = 0;

            base.Reset(destinationFolder);
        }

        public new void Load(string name, DicomDataSetLoadFlags flags)
        {
            base.Load(name, flags);
        }

        public void SetStatus(string status)
        {
           if (m_txtStatus != null)
           {
              m_txtStatus.Text = status;
           }
        }

        public override DicomDirInsertFileCommand OnInsertFile(string fileName, DicomDataSet ds, DicomDirInsertFileStatus status, DicomExceptionCode code)
        {
           if (MainForm.cancel)
           {
              SetStatus("Cancelled");
              return DicomDirInsertFileCommand.Stop;
           }
           if (status == DicomDirInsertFileStatus.PreAdd)
           {
              // About to add the DICOM file
              if (ds.InformationClass == DicomClassType.BasicDirectory)
              {
                 return DicomDirInsertFileCommand.Skip;
              }
              SetStatus(string.Format("Status: Adding the file \"{0}\"", fileName));
           }
           else if (status == DicomDirInsertFileStatus.Success)
           {
              // The DICOM file has been added successfully
              m_nAddedDicomFilesCount++;
           }
           else // Failure
           {
              DialogResult dlgRes = MessageBox.Show("Invalid File Id: " + fileName + "\n Do you want to skip this file and continue?", "Error", MessageBoxButtons.YesNo);
              if (dlgRes == DialogResult.Yes)
              {
                 return DicomDirInsertFileCommand.Skip;
              }
              else
              {
                 return DicomDirInsertFileCommand.Stop;
              }
           }

           Application.DoEvents();
           return DicomDirInsertFileCommand.Continue;
        }

        /*
         * Returns the number of Dicom files added to the DicomDir
         */
        public int GetAddedDicomFilesCount()
        {
            return m_nAddedDicomFilesCount;
        }

        /*
         * Sets the TextBox on which it can write its status
         */
        public void SetStatusTextBox(ref TextBox t)
        {
            m_txtStatus = t;
        }
    }
}
