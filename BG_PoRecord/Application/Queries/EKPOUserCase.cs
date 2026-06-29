using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BG_PoRecord.Application.DTOs;
using BG_PoRecord.Domain.Entities.PoSAP;
using BG_PoRecord.Domain.Interfaces.PoSAP;

namespace BG_PoRecord.Application.Queries
{
    internal class EKPOUserCase
    {
        private readonly IPoSAP _poSAP;
        public EKPOUserCase(IPoSAP poSAP) {
            _poSAP = poSAP;   
        }

        public async Task<List<EKPODtos>> GetInfoTableEKPO(string DateTimeNow)
        {
            var result = await _poSAP.GetInfoTableEKPO(DateTimeNow);
            var DatResturn = result.Select(e => new EKPODtos()
            {
                StatusItemPO = e.StatusItemPO
            }).ToList();
            return DatResturn;
        }
    }
}
