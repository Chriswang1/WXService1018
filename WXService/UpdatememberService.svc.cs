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
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“UpdatememberService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 UpdatememberService.svc 或 UpdatememberService.svc.cs，然后开始调试。
    public class UpdatememberService : IUpdatememberService
    {
        private readonly static ILog Logger = LogManager.GetLogger(typeof(UpdatememberService));

        public Status UpdateWccMemberCommon(string appid, string subcode, string name, string telephone, string email, string region, string province, string city, string systempassword, string isAD)
        {
            Logger.Debug("start insert member&qrcode......................................");
            Logger.Debug(string.Format("UpdateWccMemberCommon(appid={0},subcode={1},name={2},telephone={3},email={4},region={5},province={6},city={7},systempassword={8},isAD={9})", appid, subcode, name, telephone, email, region, province, city, systempassword, isAD));

            try
            {


                Status umember = Updatememsql.Updatememcommon(appid, subcode, name, telephone, email, region, province, city, systempassword, isAD);

                return umember;
            }
            catch (Exception ex)
            {
                Status status = new Status();
                Logger.Error("Updatememcommon Exception:" + ex.StackTrace);
                var error = new ServiceError(BaseConfig.ServiceCode.OTHER_ERROR.ToString(),
                                "Updatememcommon", ex.Message);
                status.msg = error.ErrorMessage;
                status.status = StatusEnum.fail.ToString();
                return status;
                throw new FaultException<ServiceError>(error, error.ErrorMessage);

            }
        }

    }
}
