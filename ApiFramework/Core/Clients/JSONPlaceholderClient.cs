using ApiFramework.Model.ResponseModels;
using Aquality.Selenium.Browsers;
using RestSharp;
using System.Net;

namespace ApiFramework.Core.Clients
{
    public class JSONPlaceholderClient : BaseClient
    {
        private const string PostsUrl = "posts";
        private const string UsersUrl = "users";
        public (HttpStatusCode Status, string? Body) GetAllPost()
        {
            AqualityServices.Logger.Info($"Get request for {RestClient.Options.BaseUrl + "/posts"}");
            return GetRequest(PostsUrl);
        }
        public (HttpStatusCode Status, string? Body) GetPostById(int id)
        {
            AqualityServices.Logger.Info($"Get request for {RestClient.Options.BaseUrl + $"posts/{id}"}");
            return GetRequest(PostsUrl + $"/{id}");
        }
        public (HttpStatusCode Status, string? Body) GetAllUsers()
        {
            AqualityServices.Logger.Info($"Get request for {RestClient.Options.BaseUrl + "/users"}");
            return GetRequest(UsersUrl);
        }
        public (HttpStatusCode Status, string? Body) GetUserById(int id)
        {
            AqualityServices.Logger.Info($"Get request for {RestClient.Options.BaseUrl + $"users/{id}"}");
            return GetRequest(UsersUrl + $"/{id}");
        }

        public (HttpStatusCode Status, string? Body) PostNewPost(PostModel postModel)
        {
            AqualityServices.Logger.Info($"Post request for {RestClient.Options.BaseUrl + $"posts"}");
            var request = new RestRequest("posts", Method.Post);
            return PostRequest(PostsUrl, postModel);
        }
    }
}
