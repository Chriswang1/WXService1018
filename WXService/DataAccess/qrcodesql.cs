using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.Web;
using WXService;

namespace WXService.DataAccess
{
    public class qrcodesql
    {
        private readonly static ILog Logger = LogManager.GetLogger(typeof(qrcodesql));
        private static string connstring = string.Empty;
        static qrcodesql()
        {
            connstring = ConfigurationManager.AppSettings["DBConnection"];
        }

        public static QRcodeCommon SelectQRcode(string appid, string subcode)
        {

            QRcodeCommon qrcodeCommon = null;
            //string sqlcomm = "select count(qrcodeurl) from wechat_new..vw_wcc_member where subcode=@subcode and app_id =@appid";
            //using (SqlConnection connn = new SqlConnection(connstring))
            //{
            //    using (SqlCommand com = new SqlCommand(sqlcomm, connn))
            //    {
            //        com.Parameters.AddWithValue("@appid", appid);
            //        com.Parameters.AddWithValue("@subcode", subcode);
            //        connn.Open();
            //        string result = com.ExecuteScalar().ToString();
            //        if (result == "0")
            //        {
            //            qrcodeCommon.qcodeurl = null;
            //            qrcodeCommon.msg = "未找到对应的会员";
            //            qrcodeCommon.qcodeurl = null;
            //            return qrcodeCommon;
            //        }
            //else if (result == "1")
            //{
            string sqlCommand = "select qrcodeurl from wechat_new..vw_wcc_member where subcode=@subcode and app_id =@appid";
            using (SqlConnection connection = new SqlConnection(connstring))
            {
                using (SqlCommand command = new SqlCommand(sqlCommand, connection))
                {
                    command.Parameters.AddWithValue("@appid", appid);
                    command.Parameters.AddWithValue("@subcode", subcode);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        qrcodeCommon = new QRcodeCommon
                        {


                            qcodeurl = string.Format("{0}{1}",ConfigurationManager.AppSettings["wxurl"],reader["qrcodeurl"].ToString() as string),


                        };
                        Logger.Info(string.Format("SelectQRcode(qrcodeurl={0})", qrcodeCommon.qcodeurl));

                    }
                    reader.Close();
                }
            }
            if (qrcodeCommon.qcodeurl!= ConfigurationManager.AppSettings["wxurl"] && qrcodeCommon.qcodeurl !="")
            {
                qrcodeCommon.msg = "二维码获取成功";
                return qrcodeCommon;
            }
            else if (qrcodeCommon.qcodeurl == ConfigurationManager.AppSettings["wxurl"] || qrcodeCommon.qcodeurl=="")
            {
                string sqlcom = "select result from wechat_new..scrm_qrcode_common where appid=@appid and subcode=@subcode";
                using (SqlConnection con = new SqlConnection(connstring))
                {
                    using (SqlCommand command = new SqlCommand(sqlcom, con))
                    {
                        command.Parameters.AddWithValue("@appid", appid);
                        command.Parameters.AddWithValue("@subcode", subcode);
                        con.Open();
                        try
                        {
                            string res = command.ExecuteScalar().ToString();
                            if (res == "未找到subcode对应的会员")
                            {
                                qrcodeCommon.qcodeurl = null;
                                qrcodeCommon.msg = "未找到subcode对应的会员";
                                //return qrcodeCommon;
                            }
                            else if (res == null || res == "")
                            {
                                qrcodeCommon.qcodeurl = null;
                                qrcodeCommon.msg = "二维码在生成过程中";
                                //return qrcodeCommon;
                            }
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
                                qrcodecommon.msg = "该subcode对应的会员没有生成二维码";
                            }
                            qrcodecommon.qcodeurl = null;
                            return qrcodecommon;
                            throw new FaultException<ServiceError>(error, error.ErrorMessage);
                        }
                       


                    }
                }


            }
            return qrcodeCommon;
        }
        //return qrcodeCommon;
    }
}
