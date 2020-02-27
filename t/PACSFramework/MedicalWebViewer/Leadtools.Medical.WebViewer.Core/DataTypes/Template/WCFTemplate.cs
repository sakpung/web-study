// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.DataAccessLayers.Core;
using System.Runtime.Serialization;

namespace Leadtools.Medical.WebViewer.DataContracts
{
    [DataContract]
    public class WCFTemplate : Template
    {
        [DataMember]
        public string CreateDate 
        { 
            get
            {
                if (Created.HasValue)
                    return Created.Value.ToString();
                return string.Empty;
            }
            set
            {                
                DateTime dt;

                if (DateTime.TryParse(value, out dt))
                {
                    Created = dt;
                }
            }
        }        
    }
}
