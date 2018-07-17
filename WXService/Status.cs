using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WXService
{
    [DataContract]
    public class Status
    {
        [DataMember]
        public string status { get; set; }
        [DataMember]
        public string msg { get; set; }
    }
}