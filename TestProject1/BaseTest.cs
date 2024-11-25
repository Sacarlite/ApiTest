using ApiFramework.Core.Clients;
using ApiFramework.Infrastructure;
using ApiFramework.Model.DataModels;
using Aquality.Selenium.Browsers;

namespace TestProject
{
    public abstract class BaseTest
    {
        protected JSONPlaceholderClient Client;

        [SetUp]
        public void Setup()
        {
            AqualityServices.Logger.Info($"Configurate the client");
            Client = new();
            Client.Configurate(DataProvider<ConfigModel>.GetConfigData());
        }
    }
}