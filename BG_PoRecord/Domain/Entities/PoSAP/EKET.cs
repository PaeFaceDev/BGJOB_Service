using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BG_PoRecord.Domain.Entities.PoSAP
{
    internal class EKET
    {
        public static string tbName = "EKET";
        public static string fildsName = "EINDT,MENGE,EBELN,BANFN,EBELP";
        public string dNDate { get; set; }
        public string ScheduledQty { get; set; }
        public string poNumber { get; set; }
        public string purReq { get; set; }
        public string items { get; set; }
    }
}
