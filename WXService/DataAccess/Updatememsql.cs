using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WXService.DataAccess
{
    public class Updatememsql
    {
        private readonly static ILog Logger = LogManager.GetLogger(typeof(Updatememsql));
        private static string connstring = string.Empty;
        static Updatememsql()
        {
            connstring = ConfigurationManager.AppSettings["DBConnection"];
        }

        public static Status Updatememcommon(string appid, string subcode, string name, string telephone, string email, string region, string province, string city, string systempassword, string isAD)
        {
            //bool result = false;
            Status wcc = new Status();
            //WccMemberCommon wccMembercommon = null;
            string sqlCommand = "update wechat_new..wcc_member_common set name =@name,telephone=@telephone,email=@email,region =@region,province =@province,city=@city,systempassword=@systempassword,isad =@isad,ishandle=0,updatetime=getdate() where appid =@appid and subcode=@subcode";
            using (SqlConnection connection = new SqlConnection(connstring))
            {
                using (SqlCommand command = new SqlCommand(sqlCommand, connection))
                {
                    //Guid pk = Guid.NewGuid();
                    //command.Parameters.AddWithValue("@pk", pk);
                    command.Parameters.AddWithValue("@appid", appid);
                    command.Parameters.AddWithValue("@subcode", subcode);
                    //command.Parameters.AddWithValue("@customercode", customercode);
                    //command.Parameters.AddWithValue("@customertype", customertype);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@telephone", telephone);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@region", region);
                    command.Parameters.AddWithValue("@province", province);
                    command.Parameters.AddWithValue("@city", city);
                    //command.Parameters.AddWithValue("@systemaccount", systemaccount);
                    command.Parameters.AddWithValue("@systempassword", systempassword);
                    command.Parameters.AddWithValue("@isAD", isAD);
                    connection.Open();
                    //SqlDataReader reader = command.ExecuteReader();
                    int count = command.ExecuteNonQuery();
                    if (count > 0)
                    {
                        wcc.status = StatusEnum.success.ToString();
                        wcc.msg = msgEnum.会员修改成功.ToString();
                        Logger.Info("会员中间表更新成功..........................");
                    }
                    else
                    {
                        wcc.status = StatusEnum.fail.ToString();
                        wcc.msg = msgEnum.会员修改失败.ToString();
                        Logger.Info("会员中间表更新失败..........................");
                    }
                    //wcc.status = StatusEnum.success.ToString();
                    //wcc.msg = msgEnum.会员中间表插入成功.ToString();
                    //Logger.Info("会员中间表插入成功..........................");
                    //result = true;
                    /**if (reader.Read())
                    {
                        wcc.status =StatusEnum.success.ToString();
                        wcc.msg = "插入会员中间表成功";

                    }
                    else
                    {
                        wcc.status = StatusEnum.fail.ToString();
                        wcc.msg = "插入会员中间表失败";
                    }**/
                    //reader.Close();
                }
            }

            /**string sqlCommand1 = "Insert into wechat_new..scrm_qrcode_common (appid,subcode) values(@appid,@subcode)";
            using (SqlConnection connection = new SqlConnection(connstring))
            {
                using (SqlCommand command1 = new SqlCommand(sqlCommand1, connection))
                {
                  
                    command1.Parameters.AddWithValue("@appid", appid);
                    command1.Parameters.AddWithValue("@subcode", subcode);
                    connection.Open();
                    SqlDataReader reader = command1.ExecuteReader();
                    //TemplateCommon templateCommon = new TemplateCommon(); 
                    wcc.status = StatusEnum.success.ToString();
                    wcc.msg = msgEnum.会员中间表和二维码中间表插入成功.ToString();
                    Logger.Info("二维码中间表插入成功.......................................");
                    /**while (reader.Read())
                    {
                        templateCommon.status = StatusEnum.success.ToString();
                        templateCommon.msg = "插入模板消息中间表成功";



                    }
                    reader.Close();
                }
            }
            if (wcc.status != StatusEnum.success.ToString())
            {
                wcc.msg = msgEnum.会员中间表和二维码中间表插入失败.ToString();
                wcc.status = StatusEnum.fail.ToString();
            }**/
            return wcc;
        }
    }
}