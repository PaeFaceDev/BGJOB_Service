using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAP.Middleware.Connector;

namespace BG_PoRecord.Infrastructure.Data
{
    internal class DestinationConfiguration : IDestinationConfiguration
    {
        public static string appName = ConfigurationManager.AppSettings["appName"];

        public bool ChangeEventsSupported()
        {
            return true;
        }

        public event RfcDestinationManager.ConfigurationChangeHandler ConfigurationChanged;

        public RfcConfigParameters GetParameters(string destinationName)
        {
            if (destinationName.Equals(appName))
            {
                RfcConfigParameters parms = new RfcConfigParameters();
                parms.Add(RfcConfigParameters.AppServerHost, ConfigurationManager.AppSettings["AppServerHost"]);
                parms.Add(RfcConfigParameters.SystemNumber, ConfigurationManager.AppSettings["SystemNumber"]);
                parms.Add(RfcConfigParameters.SystemID, ConfigurationManager.AppSettings["SystemID"]);
                parms.Add(RfcConfigParameters.User, ConfigurationManager.AppSettings["User"]);
                parms.Add(RfcConfigParameters.Password, ConfigurationManager.AppSettings["Password"]);
                parms.Add(RfcConfigParameters.Client, ConfigurationManager.AppSettings["Client"]);
                parms.Add(RfcConfigParameters.Language, ConfigurationManager.AppSettings["Language"]);
                return parms;
            }
            else
            {
                throw new Exception("Destination configuration not found for " + destinationName);
            }
        }
    }
}
