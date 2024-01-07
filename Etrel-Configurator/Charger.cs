using Etrel_Configurator.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace IPChanger
{
    internal class Charger
    {
        private readonly RestClient _client;
        public Charger(string url, string username, string password)
        {
            RestClientOptions? options = new RestClientOptions("http://" + url)
            {
                Authenticator = new ChargerAuthenticator(username, password),
                MaxTimeout = (int)TimeSpan.FromSeconds(100).TotalMilliseconds
            };
            _client = new RestClient(options);
        }

        public async Task RestartCharger()
        {
            RestRequest request = new RestRequest("api/restart", Method.Post);
            RestResponse response = await _client.ExecuteAsync(request);
        }

        public async Task<ChargerSystemInformation> GetSystemInfo()
        {
            RestRequest request = new RestRequest("api/systemInformation", Method.Get);
            RestResponse response = await _client.ExecuteAsync(request);
            ChargerSystemInformation info = JsonConvert.DeserializeObject<ChargerSystemInformation>(response.Content);
            return info;
        }

        public async Task UploadConfig(Dictionary<string, Dictionary<string, string>> config)
        {            
            foreach (KeyValuePair<string, Dictionary<string, string>> endpoint in config)
            {
                RestRequest request = new RestRequest("api/" + endpoint.Key, Method.Post);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                foreach (KeyValuePair<string, string> item in endpoint.Value)
                {
                    request.AddParameter(item.Key, item.Value);
                }
                RestResponse response = await _client.ExecuteAsync(request);
            }
        }

        public async Task BasicConfig()
        {
            ChargerSystemInformation info = await GetSystemInfo();

            //Configuration Operations
            RestRequest request = new RestRequest("api/configurationOperations", Method.Post);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            //GUI Settings
            request.AddParameter("Gui[ScreenSaverBacklightMode]", "SteadyOff");
            request.AddParameter("Gui[ChargingStatus][PublicSlides]", "ChargingPower,ConsumedEnergy,ChargedRange,SessionTime");
            request.AddParameter("Gui[ChargingStatus][PrivateSlides]", "ChargingPower,ConsumedEnergy,ChargedRange,SessionTime");
            request.AddParameter("Session[DefaultChargingMode]", "Smart");

            //EVSE
            //Friendly Code
            request.AddParameter("Evses[0][GridConnection][ConnectedToASinglePhase]", "false");

            
            //Time and Regional Settings
            request.AddParameter("Gui[Cultures]", "en-GB");
            request.AddParameter("Gui[Currency]", "$");
            request.AddParameter("Time[TimeZoneRegion]", "Pacific/Auckland");

            //Charger Auth
            request.AddParameter("Authorization[Type]", "ChargerWhitelistAndCentralSystem");
            request.AddParameter("Authorization[SupportContact]", "0800 387 877");
            request.AddParameter("Authorization[Login][AppDownloadUrl]", "chargenow.thundergrid.net");
            request.AddParameter("Authorization[Login][SupportPage]", "chargenow.thundergrid.net/#/portal/conversations");

            //GSM
            request.AddParameter("Network[Gsm][IsEnabled]", "true");
            request.AddParameter("Network[Gsm][Apn]", "m2mone.co.nz");

            //Central System
            request.AddParameter("CentralSystem[CommunicationEnabled]", "true");
            request.AddParameter("CentralSystem[Identity]", info.SerialNumber);
            request.AddParameter("CentralSystem[Client][Servers][0][Protocol]", "OCPP1_6J");
            request.AddParameter("CentralSystem[Client][Servers][0][Url]", "wss://ecogeekco.etrel.com/Starfish.WebSockets/api/OCPP1_6/");

            RestResponse response = await _client.ExecuteAsync(request);
            Console.WriteLine(response.Content);

            //BELOW IS UNTESTED AND SOME DEF DONT WORK  

            //Configuration Power Management
            RestRequest request2 = new RestRequest("api/configurationPowerManagement", Method.Post);
            request2.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request2.AddParameter("Time[TimeZoneRegion]", "Pacific/Auckland");

            RestResponse response2 = await _client.ExecuteAsync(request2);
            Console.WriteLine(response2.Content);

            //Time Servers
            RestRequest request3 = new RestRequest("api/timeServers", Method.Post);
            request3.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request3.AddParameter("timeServers", "pool.ntp.org,time.windows.com");

            RestResponse response3 = await _client.ExecuteAsync(request3);
            Console.WriteLine(response3.Content);

            //Time
            RestRequest request4 = new RestRequest("api/Time", Method.Post);
            request4.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            string formattedTime = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            request4.AddParameter("time", formattedTime);

            RestResponse response4 = await _client.ExecuteAsync(request4);
            Console.WriteLine(response4.Content);
        }

        public async Task ClusterConfig(string masterAddress)
        {
            RestRequest request = new RestRequest("api/configurationOperations", Method.Post);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            //Power management
            request.AddParameter("PowerManagement[PrimaryMaster][IsEnabled]", "true");
            request.AddParameter("PowerManagement[PrimaryMaster][Address]", masterAddress);
            request.AddParameter("PowerManagement[MaxOutputCurrentWhenClusterCommFails]", "7");

            RestResponse response = await _client.ExecuteAsync(request);
            Console.WriteLine(response.Content);
        }
    }
}
