using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WXService
{
    [DataContract]
    public class SNCommon
    {
        [DataMember]
        public string SN { get; set; }
    }
}