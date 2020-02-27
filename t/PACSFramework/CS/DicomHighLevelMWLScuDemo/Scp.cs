// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using Leadtools.Dicom.Scu;
using System.Net;
using System.Xml.Serialization;

namespace DicomDemo
{
    public class Scp : DicomScp
    {
        private string _IPString;

        public string IPString
        {
            get { return _IPString; }
            set 
            {
                IPAddress ip;

                if (IPAddress.TryParse(value, out ip))
                {
                    _IPString = value;
                    PeerAddress = ip;
                }
            }
        }

        [XmlIgnore]
        public override IPAddress PeerAddress
        {
            get
            {
                return base.PeerAddress;
            }
            set
            {
                base.PeerAddress = value;
                if(value!=null)
                    _IPString = value.ToString();
            }
        }
    }
}
