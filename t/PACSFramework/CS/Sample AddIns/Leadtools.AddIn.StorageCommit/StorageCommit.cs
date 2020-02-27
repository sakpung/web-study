// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using Leadtools.Dicom;

namespace Leadtools.AddIn.StorageCommit
{
    public class StorageCommit
    {
        private bool _SameStudy;

        public string TransactionUID;

        public bool SameStudy
        {
           get { return _SameStudy; }
           set { _SameStudy = value; }
        }

        private List<StorageCommitItem> _Items = new List<StorageCommitItem>();

        public List<StorageCommitItem> Items
        {
            get
            {
                return _Items;
            }
        }

        public int SuccessCount
        {
            get
            {
                int count = 0;

                foreach (StorageCommitItem item in Items)
                {
                    if (item.Status == DicomCommandStatusType.Success)
                        count++;
                }
                return count;
            }
        }

        public int FailedCount
        {
            get
            {
                int count = 0;

                foreach (StorageCommitItem item in Items)
                {
                    if (item.Status != DicomCommandStatusType.Success)
                        count++;
                }
                return count;
            }
        }

        public bool IsSameStudy()
        {
            string study;

            if (_Items.Count <= 0)
                return true;

            study = _Items[0].StudyInstanceUID;
            for(int i = 1; i < _Items.Count;i++)
            {
                if (_Items[i].StudyInstanceUID != study)
                    return false;
            }
            return true;
        }
    }
}
