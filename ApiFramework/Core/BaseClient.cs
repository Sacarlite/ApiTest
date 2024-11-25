using ApiFramework.Converters;
using ApiFramework.Model.DataModels;
using Aquality.Selenium.Browsers;
using RestSharp;
using System.Net;

namespace ApiFramework.Core
{
    public abstract class BaseClient
    {
        protected RestClient RestClient;
        public void Configurate(ConfigModel model)
        {
            var options = new RestClientOptions(model.Url)
            {
            };
            RestClient = new(options);
        }
        protected (HttpStatusCode Status, string? Body) GetRequest(string url)
        {
            var request = new RestRequest(url, Method.Get);
            RestResponse response = RestClient.Execute(request);
            AqualityServices.Logger.Info($"Response was received from the server with code {response.StatusCode}");
            AqualityServices.Logger.Info($"Response was received from the server with data \n{response.Content}");
            return new(response.StatusCode, response.Content);
        }
        protected (HttpStatusCode Status, string? Body) PostRequest(string url, object model)
        {
            var request = new RestRequest(url, Method.Post);
            string jsonToSend = JsonDataConverter.SerializeData(model);
            request.AddJsonBody(jsonToSend);
            try
            {
                var response = RestClient.Execute(request);
                AqualityServices.Logger.Info($"Response was received from the server with code {response.StatusCode}");
                AqualityServices.Logger.Info($"Response was received from the server with data \n{response.Content}");
                return new(response.StatusCode, response.Content);
            }
            catch (Exception ex)
            {
                AqualityServices.Logger.Error($"Error when sending a Post request {ex.Message}");
                throw new Exception($"Ошибка при отправке Post запроса  {ex.Message}");
            }
        }
    }
}
