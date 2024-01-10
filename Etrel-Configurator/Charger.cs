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
            if (response.Content == null) { throw new Exception("GetSystemInfo response from charger was null"); }
            ChargerSystemInformation? info = JsonConvert.DeserializeObject<ChargerSystemInformation>(response.Content);
            if(info == null) { throw new Exception("ChargerSystemInformation was null"); }
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
                    if(item.Key == "CentralSystem[Identity]" && item.Value == "CHARGER_SERIAL_NUMBER")
                    {
                        ChargerSystemInformation info = await GetSystemInfo();
                        request.AddParameter(item.Key, info.SerialNumber);
                        continue;
                    }
                    request.AddParameter(item.Key, item.Value);
                }
                RestResponse response = await _client.ExecuteAsync(request);
            }
        }
    }
}
