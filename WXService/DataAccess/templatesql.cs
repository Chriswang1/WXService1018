using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using log4net;
using WXService.common;

namespace WXService.DataAccess
{
    public class templatesql
    {
        private readonly static ILog Logger = LogManager.GetLogger(typeof(templatesql));
        private static string connstring = string.Empty;
        static templatesql()
        {
            connstring = ConfigurationManager.AppSettings["DBConnection"];
        }

        public static Status AddTemplateDetail(string appid,List<Subcode> subcode, List<Send_param> send_param, string msg_id, string template_id, string url, string app_token_name, int ischeck, string time_stamp, string src)
        {

            Status templateCommon = new Status();
            for (int i = 0; i < subcode.Count; i++)
            {
                for(int j=0;j<send_param.Count;j++)
                { 
                string sqlCommand = "insert into wechat_new..wcc_template_common (pk,msg_id,appid,subcode,template_id,send_param,url,app_token_name,ischeck,time_stamp,src,priority)values(@pk,@msg_id,@appid,@subcode,@template_id,@send_param,@url,@app_token_name,@ischeck,@time_stamp,@src,1)";
                    using (SqlConnection connection = new SqlConnection(connstring))
                    {
                        using (SqlCommand command = new SqlCommand(sqlCommand, connection))
                        {
                            Guid pk = Guid.NewGuid();

                            Subcode subcodes = subcode[i];
                        Send_param sp = send_param[j];
                        //Send_param sp = send_param;
                            var data = JsonHelper.Serialize(sp);
                            Logger.Info(string.Format("data={0},subcode={1}", data, subcodes.subcode));
                            command.Parameters.AddWithValue("@subcode", subcodes.subcode);
                            command.Parameters.AddWithValue("@pk", pk);
                            command.Parameters.AddWithValue("@appid", appid);
                            command.Parameters.AddWithValue("@msg_id", msg_id);
                            command.Parameters.AddWithValue("@template_id", template_id);
                            command.Parameters.AddWithValue("@url", url);
                            command.Parameters.AddWithValue("@app_token_name", app_token_name);
                            command.Parameters.AddWithValue("@ischeck", ischeck);
                            command.Parameters.AddWithValue("@time_stamp", time_stamp);
                            command.Parameters.AddWithValue("@src", src);
                            command.Parameters.AddWithValue("@send_param", data);
                            connection.Open();
                            //SqlDataReader reader = command.ExecuteReader();
                            //TemplateCommon templateCommon = new TemplateCommon(); 
                            int count = command.ExecuteNonQuery();
                            if (count > 0)
                            {
                                templateCommon.status = StatusEnum.success.ToString();
                                templateCommon.msg = msgEnum.模板消息插入成功.ToString();
                                Logger.Info("模板消息中间表插入成功..........................");
                                //connection.Close();
                            }
                            else
                            {
                                templateCommon.status = StatusEnum.fail.ToString();
                                templateCommon.msg = msgEnum.模板消息插入失败.ToString();
                                Logger.Info("模板消息中间表插入失败..........................");
                                //connection.Close();
                            }

                        }
                       Logger.Info(string.Format("第{0}个模板消息插入成功", j+1));
                    }
                    //command.Parameters.AddWithValue("@subcode", subcode); 
                    //command.Parameters.AddWithValue("@pk", pk);
                    //command.Parameters.AddWithValue("@send_param", send_param);
                    //connection.Open();
                    ////SqlDataReader reader = command.ExecuteReader();
                    ////TemplateCommon templateCommon = new TemplateCommon(); 
                    //int count = command.ExecuteNonQuery();
                    //if (count > 0)
                    //{
                    //    templateCommon.status = StatusEnum.success.ToString();
                    //    templateCommon.msg = msgEnum.模板消息中间表插入成功.ToString();
                    //    Logger.Info("模板消息中间表插入成功..........................");
                    //}
                    //else
                    //{
                    //    templateCommon.status = StatusEnum.fail.ToString();
                    //    templateCommon.msg = msgEnum.模板消息中间表插入失败.ToString();
                    //    Logger.Info("模板消息中间表插入失败..........................");
                    //}
                    /**while (reader.Read())
                    {
                        templateCommon.status = StatusEnum.success.ToString();
                        templateCommon.msg = "插入模板消息中间表成功";



                    }**/
                    //reader.Close();
                }
                Logger.Info(string.Format("第{0}个需要发送的用户添加成功", i+1));
            }
            
            //if (templateCommon.status != StatusEnum.success.ToString())
            //{
            //    templateCommon.msg = msgEnum.模板消息中间表插入失败.ToString();
            //    templateCommon.status = StatusEnum.fail.ToString();
            //}
            return templateCommon;

        }
    }
}