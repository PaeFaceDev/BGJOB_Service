using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BG_PoRecord.Application.Queries;
using BG_PoRecord.Domain.Interfaces.PoSAP;
using BG_PoRecord.Infrastructure.Repositories;

namespace BG_PoRecord.ConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Start");
            IPoSAP poSAP = new PoSapRepository();

            var useCase = new EKPOUserCase(poSAP);

            var result = await useCase.GetInfoTableEKPO("20260629");
            foreach (var item in result)
            {
                Console.WriteLine(item.StatusItemPO);
            }
        }
    }
}