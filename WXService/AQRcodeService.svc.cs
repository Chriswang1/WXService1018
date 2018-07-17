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
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“AQRcodeService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 AQRcodeService.svc 或 AQRcodeService.svc.cs，然后开始调试。
    public class AQRcodeService : IAQRcodeService
    {
        private readonly static ILog Logger = LogManager.GetLogger(typeof(AQRcodeService));
        public Status AddQRcode(string appid,string subcode)
        {
            Logger.Debug("start add qrcode common..........................");
            Logger.Debug(string.Format("AddQRcode(appid={0},subcode={1})", appid,subcode));
            try
            {
                Status qrcrcode = addqrcommon.Addqrcommondetail(appid,subcode);
                return qrcrcode;
            }
            catch (Exception ex)
            {
                Status status = new Status();
                Logger.Error("Addqrcommondetail Exception:" + ex.StackTrace);
                var error = new ServiceError(BaseConfig.ServiceCode.OTHER_ERROR.ToString(),
                                "Addqrcommondetail", ex.Message);
                status.msg = error.ErrorMessage;
                status.status = StatusEnum.fail.ToString();
                return status;
                throw new FaultException<ServiceError>(error, error.ErrorMessage);
            }
        }
    }
}