using ApiFramework.Infrastructure;
using ApiFramework.Model.DataModels;
using Aquality.Selenium.Browsers;
using System.Net;

namespace TestProject.TestCase
{
    public class BadPostByIdTest : BaseTest
    {

        [Test]
        public void TestPostByIdCase()
        {
            AqualityServices.Logger.Info($"Test case \"TestPostByIdCase\" started");
            var testModel = DataProvider<TestDataModel>.GetConfigData().BadGetPostModel;
            var allPostResponse = Client.GetPostById((int)testModel.Id);
            Assert.IsTrue(allPostResponse.Status == HttpStatusCode.NotFound, $"Произошла ошибка при получени данных с сервера. Ответ от сервера {allPostResponse.Status}, ожидаемый ответ {HttpStatusCode.NotFound}");
            Assert.IsTrue(allPostResponse.Body == "{}", "Тело json ответа не пусто");
        }
    }
}
