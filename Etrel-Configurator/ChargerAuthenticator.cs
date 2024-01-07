using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace IPChanger
{
    public class ChargerAuthenticator : IAuthenticator
    {
        private readonly string _email;
        private readonly string _password;

        public ChargerAuthenticator(string email, string password)
        {
            _email = email;
            _password = password;
        }

        public async ValueTask Authenticate(IRestClient client, RestRequest request)
        {
            RestClient loginClient = new RestClient(client.Options.BaseUrl ?? throw new ArgumentNullException("baseUrl"));
            RestRequest loginRequest = new RestRequest("api/webOperatorLogin", Method.Post);
            loginRequest.AddHeader("content-type", "application/x-www-form-urlencoded");
            loginRequest.AddParameter("application/x-www-form-urlencoded", $"email={_email}&password={_password}", ParameterType.RequestBody);

            RestResponse loginResponse = await loginClient.ExecuteAsync(loginRequest);

            if (!loginResponse.IsSuccessful || string.IsNullOrEmpty(loginResponse.Content))
            {
                throw new Exception("Charger authentication failed");
            }

            var definition = new { Token = "" };
            var tokenData = JsonConvert.DeserializeAnonymousType(loginResponse.Content, definition);

            request.AddOrUpdateHeader(KnownHeaders.Authorization, "Bearer " + tokenData.Token);
        }
    }
}