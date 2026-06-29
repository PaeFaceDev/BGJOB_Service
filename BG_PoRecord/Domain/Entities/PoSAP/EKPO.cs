using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BG_PoRecord.Domain.Entities.PoSAP
{
    internal class EKPO
    {
        public static string tbName = "EKPO";
        public static string fildsName = "EBELN,EBELP,MATNR,LOEKZ,TXZ01,BUKRS,WERKS,MENGE,ELIKZ,LOEKZ,BANFN,AEDAT,LGORT,MEINS,BPRME,NETPR,PEINH,MWSKZ,PSTYP,SPE_ABGRU";
        public string poNumber { get; set; }
        public string items { get; set; }
        public string material { get; set; }
        public string StatusItemPO { get; set; }
        public string shortText { get; set; }
        public string cocd { get; set; }
        public string plant { get; set; }
        public string dic { get; set; }
        public string d { get; set; }
        public string prStar { get; set; }
        public string changedOn { get; set; }
        public string sLoc { get; set; }
        public string oUn { get; set; }
        public string netPrice { get; set; }
        public string per { get; set; }
        public string tx { get; set; }
        public string i { get; set; }
        public string rJ { get; set; }
        public string oPu { get; set; }
        public string poQty { get; set; }
    }
}
