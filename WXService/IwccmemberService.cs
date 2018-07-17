using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.IO;
using System.Web;

namespace WXService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IwccmemberService”。
    [ServiceContract]
    public interface IwccmemberService
    {
        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(Method ="POST", UriTemplate = "AddWccMemberCommon",BodyStyle =WebMessageBodyStyle.WrappedRequest ,RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]

        Status AddWccMemberCommon(string appid, string subcode,string customercode,string customertype,string name,string telephone,string email,string region,string province,string city,string systemaccount,string systempassword,string isAD);

    }
}
