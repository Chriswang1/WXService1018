using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WXService.DataAccess
{
    public class addqrcommon
    {
        private readonly static ILog Logger = LogManager.GetLogger(typeof(SQL));
        private static string connstring = string.Empty;
        static addqrcommon()
        {
            connstring = ConfigurationManager.AppSettings["DBConnection"];
        }

        public static Status Addqrcommondetail(string appid, string subcode)
        {
            //bool result = false;
            Status qrcommon = new Status();
            string sqlCommand1 = "Insert into wechat_new..scrm_qrcode_common (appid,subcode) values(@appid,@subcode)";
            using (SqlConnection connection = new SqlConnection(connstring))
            {
                using (SqlCommand command1 = new SqlCommand(sqlCommand1, connection))
                {

                    command1.Parameters.AddWithValue("@appid", appid);
                    command1.Parameters.AddWithValue("@subcode", subcode);
                    connection.Open();
                    int count = command1.ExecuteNonQuery();
                    if (count > 0)
                    {
                        qrcommon.status = StatusEnum.success.ToString();
                        qrcommon.msg = msgEnum.二维码插入成功.ToString();
                        Logger.Info("二维码中间表插入成功..........................");
                    }
                    else
                    {
                        qrcommon.status = StatusEnum.fail.ToString();
                        qrcommon.msg = msgEnum.二维码插入失败.ToString();
                        Logger.Info("二维码中间表插入失败..........................");
                    }
                    /**while (reader.Read())
                    {
                        templateCommon.status = StatusEnum.success.ToString();
                        templateCommon.msg = "插入模板消息中间表成功";



                    }**/
                    //reader.Close();
                }
            }
            return qrcommon;
        }
    }
}