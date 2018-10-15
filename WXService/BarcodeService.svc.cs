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
            for (int i = 0; i < SN.Count; i++)
            {
                Logger.Debug(string.Format("SelectBarcode(SN={0})", SN[i].SN));
            }
            try
            {
                List<BarcodeCommon> barcodeCommon = barcodesql.SelectBarcode(SN);
                for (int i = 0; i < SN.Count; i++)
                {
                    Logger.Debug(string.Format("SAP_Code={0},Name_chn={1},EAN={2},ProductionDate={3},ProductCode={4},Lot_No{5},SN={6}", barcodeCommon[i].SAP_Code,barcodeCommon[i].Name_chn,barcodeCommon[i].EAN,barcodeCommon[i].ProductionDate,barcodeCommon[i].ProductCode,barcodeCommon[i].Lot_No,barcodeCommon[i].SN));
                }
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