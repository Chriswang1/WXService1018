using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace WXService.DataAccess
{
  
        public class barcodesql
        {
            private readonly static ILog Logger = LogManager.GetLogger(typeof(DataAccess.barcodesql));
            private static string connstring = string.Empty;
            static barcodesql()
            {
                connstring = ConfigurationManager.AppSettings["DBConnection2"];
            }
            public static  List<BarcodeCommon> SelectBarcode(List<SNCommon> SN)
            {
                List<BarcodeCommon> barcodeCommonlist = new List<BarcodeCommon>();
                BarcodeCommon barcodeCommon = null;
            for (int i = 0; i < SN.Count; i++)
            {
                string sqlCommand = "SELECT top(1)  P.SAP_Code, P.Name_chn, P.EAN, B.ProductionDate, B.ProductCode, B.Lot_No,@SN as SN FROM e_comm.dbo.Product AS P INNER JOIN e_comm.dbo.Box AS B ON P.EAN = B.EAN WHERE B.Lot_No IN(SELECT Lot_No FROM e_comm.dbo.SN WHERE SN = @SN)";
                using (SqlConnection connection = new SqlConnection(connstring))
                {
                    using (SqlCommand command = new SqlCommand(sqlCommand, connection))
                    {
                        SNCommon sncommon = SN[i];
                        //command.Parameters.AddWithValue("@appid", appid);
                        command.Parameters.AddWithValue("@SN", sncommon.SN);
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {

                            barcodeCommon = new BarcodeCommon
                            {

                                SN = reader["SN"].ToString() as string,
                                SAP_Code = reader["SAP_Code"].ToString() as string,
                                Name_chn = reader["Name_chn"].ToString() as string,
                                EAN = reader["EAN"].ToString() as string,
                                ProductionDate = System.Convert.ToDateTime(reader["ProductionDate"]).ToString("yyyy/MM/dd"),
                                ProductCode = reader["ProductCode"].ToString() as string,
                                Lot_No = reader["Lot_No"].ToString() as string
                            };
                            //List<BarcodeCommon> barcodeCommonlist = new List<BarcodeCommon>();
                            //barcodeCommonlist.Add(barcodeCommon);
                            Logger.Info(string.Format("SelectBarcode(SAP_Code={0},Name_chn={1},EAN={2},ProductionDate={3},ProductCode={4},Lot_No={5})", barcodeCommon.SAP_Code, barcodeCommon.Name_chn, barcodeCommon.EAN, barcodeCommon.ProductionDate, barcodeCommon.ProductCode, barcodeCommon.Lot_No));
                            barcodeCommonlist.Add(barcodeCommon);

                        }
                        reader.Close();
                        //barcodeCommonlist.Add(barcodeCommon);

                    }
                    //List<BarcodeCommon> barcodeCommonlist = new List<BarcodeCommon>();
                    //barcodeCommonlist.Add(barcodeCommon);
                }
            }

            return barcodeCommonlist;
        }
    }
}
