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
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“QRcodeService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 QRcodeService.svc 或 QRcodeService.svc.cs，然后开始调试。
    public class QRcodeService : IQRcodeService
    {
        private readonly static ILog Logger = LogManager.GetLogger(typeof(QRcodeService));
        public QRcodeCommon SelectQRcode(string appid,string subcode)
        {
            Logger.Debug("start Select QRcodeurl..........................");
            Logger.Debug(string.Format("SelectQRcode(subcode={0},appid={1})", subcode,appid));
            try
            {
                QRcodeCommon qrcodecommon = qrcodesql.SelectQRcode(appid,subcode);
                Logger.Debug(string.Format("qcodeurl={0},msg={1})", qrcodecommon.qcodeurl, qrcodecommon.msg));
                //if (qrcodecommon == null)
                //{
                //    throw new FaultException("Select Failed");
                //}
                return qrcodecommon;
            }
            catch (Exception ex)
            {
                QRcodeCommon qrcodecommon = new QRcodeCommon();
                Logger.Error("SelectQRcode Exception:" + ex.StackTrace);
                var error = new ServiceError(BaseConfig.ServiceCode.OTHER_ERROR.ToString(),
                                "SelectQRcode", ex.Message);
                qrcodecommon.msg = error.ErrorMessage;
                if (qrcodecommon.msg == "Object reference not set to an instance of an object.")
                {
                    qrcodecommon.msg = "未找到subcode对应的会员";
                }
                qrcodecommon.qcodeurl = null;
                Logger.Debug(string.Format("qcodeurl={0},msg={1})", qrcodecommon.qcodeurl, qrcodecommon.msg));
                return qrcodecommon;
                throw new FaultException<ServiceError>(error, error.ErrorMessage);
                //Logger.Error("SelectQRcode Exception:" + ex.StackTrace);
                //throw new FaultException(ex.Message + ex.StackTrace);
            }
        }
    }
}
