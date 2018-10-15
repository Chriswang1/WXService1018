using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WXService
{
    [DataContract]
    public class Send_param
    {
        [DataMember]
        public string keyword1 { get; set; }
        [DataMember]
        public string keyword2 { get; set; }
        [DataMember]
        public string keyword3 { get; set; }
        [DataMember]
        public string remark { get; set; }
        [DataMember]
        public string first { get; set; }
        public class Send_paramList
        {
           [DataMember]
           public List<Send_param> send_paramlist { get; set; }
        }
        //public Send_param getsp()
        //{
        //    string sp = string.Format("{"keywords1":{0},"keyword2":{1},"remark":{2},"first":{3}"},keywords1,keywords2,remark,first);
        //    return Send_param;
        //}
    }
}