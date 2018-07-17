﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;



namespace WXService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IQRcodeService”。
    [ServiceContract]
    public interface IQRcodeService
    {

        [OperationContract]
        [WebInvoke(Method="POST", UriTemplate = "SelectQRcode",BodyStyle =WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json,ResponseFormat =WebMessageFormat.Json)]
        QRcodeCommon SelectQRcode(string appid,string subcode);
    }
}
