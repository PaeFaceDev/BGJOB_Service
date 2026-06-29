using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BG_PoRecord.Domain.Entities.PoSAP;

namespace BG_PoRecord.Domain.Interfaces.PoSAP
{
    internal interface IPoSAP
    {
        Task<List<EKPO>> GetInfoTableEKPO(string DateTimeNow);
        Task<List<EKET>> GetInfoTableEKET(string DateTimeNow);
        Task<List<EKKO>> GetInfoTableEKKO(string DateTimeNow);
    }
}
