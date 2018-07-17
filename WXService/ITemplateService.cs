using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WXService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“ITemplateService”。
    [ServiceContract]
    public interface ITemplateService
    {
  
        [OperationContract]
        [WebInvoke(Method ="POST",BodyStyle =WebMessageBodyStyle.Wrapped, UriTemplate = "AddTemplateCommon", RequestFormat = WebMessageFormat.Json,ResponseFormat =WebMessageFormat.Json)]
        Status AddTemplateCommon(string appid,List<Subcode> subcode, List<Send_param> send_param,string msg_id,string template_id,string url,string app_token_name,int ischeck,string time_stamp,string src);
    }
}