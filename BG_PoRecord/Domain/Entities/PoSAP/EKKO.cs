using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BG_PoRecord.Domain.Entities.PoSAP
{
    internal class EKKO
    {
        public static string tbName = "EKKO";
        public static string fildsName = "BSART,AEDAT,ERNAM,LIFNR,EKORG,EKGRP,WAERS,RESWK,EBELN,STATU";

        public string typeName { get; set; }
        public string createOn { get; set; }
        public string createBy { get; set; }
        public string vendor { get; set; }
        public string poRg { get; set; }
        public string pGr { get; set; }
        public string crCy { get; set; }
        public string sPit { get; set; }
        public string poNumber { get; set; }
        public string statuses { get; set; }
    }
}
