using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WXService
{
    [DataContract]
    public class ServiceError
    {
        [DataMember]
        public string ServiceCode { get; set; }
        [DataMember]
        public string Operation { get; set; }
        [DataMember]
        public string ErrorMessage { get; set; }

        public string Invaliduser { get; set; }
        public string Invalidparty { get; set; }
        public string Invalidtag { get; set; }

        public ServiceError(string serviceCode, string operation, string message)
        {
            ServiceCode = serviceCode;
            Operation = operation;
            ErrorMessage = message;
        }
       
        public ServiceError(string serviceCode, string operation, string message, string invaliduser, string invalidparty, string invalidtag)
        {
            ServiceCode = serviceCode;
            Operation = operation;
            ErrorMessage = message;
            //WechatErrorCode = wechatErrorCode;
            Invaliduser = invaliduser;
            Invalidparty = invalidparty;
            Invalidtag = invalidtag;
        }
    }
}