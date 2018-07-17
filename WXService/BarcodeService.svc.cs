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
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“BarcodeService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 BarcodeService.svc 或 BarcodeService.svc.cs，然后开始调试。
    public class BarcodeService : IBarcodeService
    {
        private readonly static ILog Logger = LogManager.GetLogger(typeof(BarcodeService));
        public List<BarcodeCommon> SelectBarcode(List<SNCommon> SN)
        {
            Logger.Debug("start select  barcode..........................");
            Logger.Debug(string.Format("SelectBarcode(SN={0})", SN));
            try
            {
                List<BarcodeCommon> barcodeCommon = barcodesql.SelectBarcode(SN);
                //Logger.Info(barcodeCommon);
                return barcodeCommon;
            }
            catch (Exception ex)
            {
                Logger.Error("SelectBarcode Exception:" + ex.StackTrace);
                throw new FaultException(ex.Message + ex.StackTrace);
            }
        }
    }
}