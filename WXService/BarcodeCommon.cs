using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WXService
{
    [DataContract]
    public class BarcodeCommon
    {
        [DataMember]
        public string SAP_Code { get; set; }
        [DataMember]
        public string Name_chn { get; set; }
        [DataMember]
        public string EAN{ get; set; }
        [DataMember]
        public string ProductionDate { get; set; }
        [DataMember]
        public string ProductCode { get; set; }
        [DataMember]
        public string Lot_No { get; set; }
        [DataMember]
        public string SN { get; set; }
        //[DataMember]
        //public List<BarcodeCommon> barcodeCommonlist { get; set; }
    }
}