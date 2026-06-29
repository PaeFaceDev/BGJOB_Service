using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BG_PoRecord.Domain.Entities.PoSAP;
using BG_PoRecord.Domain.Interfaces.PoSAP;
using BG_PoRecord.Infrastructure.Data;
using SAP.Middleware.Connector;


namespace BG_PoRecord.Infrastructure.Repositories
{
    internal class PoSapRepository:IPoSAP
    {
        
        public PoSapRepository()
        {

        }
        public async Task<List<EKPO>> GetInfoTableEKPO(string DateTimeNow)
        {
            try
            {
                string[] fildsName = EKPO.fildsName.Split(",".ToCharArray());

                DestinationConfiguration destinationConfiguration = new DestinationConfiguration();
                RfcDestinationManager.RegisterDestinationConfiguration(destinationConfiguration);

                RfcDestination destination = RfcDestinationManager.GetDestination(DestinationConfiguration.appName);

                IRfcFunction readTable = destination.Repository.CreateFunction("BBP_RFC_READ_TABLE");

                readTable.SetValue("QUERY_TABLE", EKPO.tbName);
                readTable.SetValue("DELIMITER", ";");
                IRfcTable fieldsTable = readTable.GetTable("FIELDS");

                foreach (var item in fildsName)
                {
                    fieldsTable.Append();
                    fieldsTable.SetValue("FIELDNAME", item);
                }

                IRfcTable optsTable = readTable.GetTable("OPTIONS");
                optsTable.Append();
                optsTable.SetValue("TEXT", "BUKRS = '9770'");
                optsTable.Append();
                optsTable.SetValue("TEXT", $@"AND AEDAT eq '{DateTimeNow}'");

                readTable.Invoke(destination);
                IRfcTable result = readTable.GetTable("DATA");

                var dataEkpo = new List<EKPO>();
                for (int idx = 0; idx < result.RowCount; idx++)
                {
                    var value = result.GetString(0).Split(";".ToCharArray());
                    result.CurrentIndex = idx;

                    EKPO models = new EKPO()
                    {
                        poNumber = value[0].Trim(),
                        items = value[1].Trim(),
                        material = value[2].Trim(),
                        shortText = value[3].Trim(),
                        cocd = value[4].Trim(),
                        plant = value[5].Trim(),
                        poQty = value[6].Trim(),
                        dic = value[7].Trim(),
                        d = value[8].Trim(),
                        prStar = value[9].Trim(),
                        changedOn = value[10].Trim(),
                        sLoc = value[11].Trim(),
                        oUn = value[12].Trim(),
                        oPu = value[13].Trim(),
                        netPrice = value[14].Trim(),
                        per = value[15].Trim(),
                        tx = value[16].Trim(),
                        i = value[17].Trim(),
                        rJ = value[18].Trim()
                    };
                    dataEkpo.Add(models);
                }
                RfcSessionManager.EndContext(destination);
                RfcDestinationManager.UnregisterDestinationConfiguration(destinationConfiguration);
                return await Task.FromResult(dataEkpo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                var rows = new List<EKPO>();
                return await Task.FromResult(rows);
            }
            //return await Task.FromResult(new List<EKPO>());
        }
        public async Task<List<EKKO>> GetInfoTableEKKO(string DateTimeNow)
        {
            try
            {
                string[] filds_name = EKKO.fildsName.Split(",".ToArray());

                DestinationConfiguration config = new DestinationConfiguration();

                RfcDestinationManager.RegisterDestinationConfiguration(config);
                RfcDestination destination = RfcDestinationManager.GetDestination(DestinationConfiguration.appName);

                IRfcFunction readTable = destination.Repository.CreateFunction("BBP_RFC_READ_TABLE");
                readTable.SetValue("QUERY_TABLE", EKKO.tbName);
                readTable.SetValue("DELIMITER", ";");

                IRfcTable fildsTable = readTable.GetTable("FIELDS");
                foreach (var item in filds_name)
                {
                    fildsTable.Append();
                    fildsTable.SetValue("FIELDNAME", item);
                }

                IRfcTable optionsTable = readTable.GetTable("OPTIONS");
                optionsTable.Append();
                optionsTable.SetValue("TEXT", "EKORG = '9770'");
                optionsTable.Append();
                optionsTable.SetValue("TEXT", $@"AND AEDAT eq '{DateTimeNow}'");


                readTable.Invoke(destination);

                IRfcTable resulte = readTable.GetTable("DATA");

                var dataEkko = new List<EKKO>();

                for (global::System.Int32 i = 0; i < resulte.RowCount; i++)
                {
                    var value = resulte.GetString(0).Split(";".ToCharArray());
                    resulte.CurrentIndex = i;

                    EKKO models = new EKKO()
                    {
                        typeName = value[0].Trim(),
                        createOn = value[1].Trim(),
                        createBy = value[2].Trim(),
                        vendor = value[3].Trim(),
                        poRg = value[4].Trim(),
                        pGr = value[5].Trim(),
                        crCy = value[6].Trim(),
                        sPit = value[7].Trim(),
                        poNumber = value[8].Trim(),
                        statuses = value[9].Trim()
                    };

                    dataEkko.Add(models);
                }
                RfcSessionManager.EndContext(destination);
                RfcDestinationManager.UnregisterDestinationConfiguration(config);
                return await Task.FromResult(dataEkko);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return await Task.FromResult(new List<EKKO>());
            }
        }
        public async Task<List<EKET>> GetInfoTableEKET(string DateTimeNow)
        {
            try
            {
                string[] fildsName = EKET.fildsName.Split(",".ToCharArray());

                DestinationConfiguration destinationConfiguration = new DestinationConfiguration();
                RfcDestinationManager.RegisterDestinationConfiguration(destinationConfiguration);

                RfcDestination destination = RfcDestinationManager.GetDestination(DestinationConfiguration.appName);

                IRfcFunction readTable = destination.Repository.CreateFunction("BBP_RFC_READ_TABLE");

                readTable.SetValue("QUERY_TABLE", EKET.tbName);
                readTable.SetValue("DELIMITER", ";");
                IRfcTable fieldsTable = readTable.GetTable("FIELDS");

                foreach (var item in fildsName)
                {
                    fieldsTable.Append();
                    fieldsTable.SetValue("FIELDNAME", item);
                }

                IRfcTable optsTable = readTable.GetTable("OPTIONS");
                optsTable.Append();
                optsTable.SetValue("TEXT", $@"BEDAT eq '{DateTimeNow}'");

                readTable.Invoke(destination);
                IRfcTable result = readTable.GetTable("DATA");

                var dataEkpo = new List<EKET>();
                for (int idx = 0; idx < result.RowCount; idx++)
                {
                    var value = result.GetString(0).Split(";".ToCharArray());
                    result.CurrentIndex = idx;

                    EKET models = new EKET()
                    {
                        dNDate = value[0].Trim(),
                        ScheduledQty = value[1].Trim(),
                        poNumber = value[2].Trim(),
                        purReq = value[3].Trim(),
                        items = value[4].Trim()
                    };
                    dataEkpo.Add(models);
                }
                RfcSessionManager.EndContext(destination);
                RfcDestinationManager.UnregisterDestinationConfiguration(destinationConfiguration);
                return await Task.FromResult(dataEkpo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                var rows = new List<EKET>();
                return await Task.FromResult(rows);
            }
        }
        
    }
}
