using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WXService.DataAccess;

namespace WXService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“TemplateService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 TemplateService.svc 或 TemplateService.svc.cs，然后开始调试。
    public class TemplateService : ITemplateService
    {
        private readonly static ILog Logger = LogManager.GetLogger(typeof(TemplateService));
        public Status  AddTemplateCommon(string appid,List<Subcode> subcode, List<Send_param> send_param, string msg_id, string template_id, string url, string app_token_name, int ischeck, string time_stamp, string src)
        {
            Logger.Debug("start add Template common..........................");
            Logger.Debug(string.Format("AddTemplateCommon(subcode={0},send_param={1},msg_id={2},template_id={3},url={4},app_token_name={5},ischeck={6},time_stamp={7},src={8})", subcode, send_param,msg_id,template_id,url,app_token_name,ischeck,time_stamp,src));
            try
            {
                Status template = templatesql.AddTemplateDetail(appid,subcode, send_param, msg_id,template_id,url,app_token_name,ischeck,time_stamp,src);
                return template;
            }
            catch (Exception ex)
            {
                Status status = new Status();
                Logger.Error("AddWccMemberCommon Exception:" + ex.StackTrace);
                var error = new ServiceError(BaseConfig.ServiceCode.OTHER_ERROR.ToString(),
                                "AddWccMemberCommon", ex.Message);
                status.msg = error.ErrorMessage;
                status.status = StatusEnum.fail.ToString();
                return status;
                throw new FaultException<ServiceError>(error, error.ErrorMessage);
            }
        }
    }
}
