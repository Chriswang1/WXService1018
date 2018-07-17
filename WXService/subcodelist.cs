using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WXService
{
    [DataContract]
    public class Subcode
    {
        [DataMember]
        public string subcode { get;set;}
    }
    [DataContract]
    public class SubcodeList
    {
        [DataMember]
        public List<Subcode> subcodes { get; set; }
    }
}