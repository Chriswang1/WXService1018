using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WXService.DataAccess;
using System.IO;
using System.Web;
using Newtonsoft.Json.Linq;
using log4net;
using System.ServiceModel.Web;

namespace WXService
{
    
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“wccmemberService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 wccmemberService.svc 或 wccmemberService.svc.cs，然后开始调试。
    public class wccmemberService : IwccmemberService
    {
        private readonly static ILog Logger = LogManager.GetLogger(typeof(wccmemberService));
    
        public Status AddWccMemberCommon(string appid, string subcode, string customercode, string customertype, string name, string telephone, string email, string region, string province, string city, string systemaccount, string systempassword, string isAD)
        { 
            Logger.Debug("start insert member&qrcode......................................");
            Logger.Debug(string.Format("AddWccMemberCommon(appid={0},subcode={1},customercode={2},customertype={3},name={4},telephone={5},email={6},region={7},province={8},city={9},systemaccount={10},systempassword={11},isAD={12})",appid,subcode, customercode, customertype, name, telephone, email, region,province, city, systemaccount, systempassword,isAD));
            //pk = Guid.NewGuid().ToString();
            //HttpContext context;
            /**Stream stream = HttpContext.Current.Request.InputStream; 
            Byte[] byteDate = new Byte[stream.Length];
            stream.Read(byteDate, 0, (Int32)stream.Length);
            string jsonData = Encoding.UTF8.GetString(byteDate);
            //string jsonData = OperationContext.Current.RequestContext.RequestMessage.ToString();
            JObject o = JObject.Parse(jsonData);
            WccMemberCommon wcc = new WccMemberCommon();
            wcc.pk = o["pk"].ToString();
            wcc.appid = o["appid"].ToString();
            wcc.subcode = o["subcode"].ToString();**/
            try
            {

                //WccMemberCommon wcc = new WccMemberCommon();
                Status wccmember = SQL.AddWccMemberdetail(appid, subcode, customercode, customertype, name, telephone, email, region, province, city, systemaccount, systempassword, isAD);
                //Status qr =qrcodesql.AddQRcodeCommonDetail(appid, subcode);
                /**if (wccmember.status  != StatusEnum.success.ToString())
                {
                    wccmember.msg = msgEnum.会员中间表和二维码中间表插入失败.ToString();
                    wccmember.status = StatusEnum.fail.ToString(); 
                    //wccmember.status=
                    //throw new FaultException("Insert Failed");

                    //return wccmember;
                }**/
                return wccmember;
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
