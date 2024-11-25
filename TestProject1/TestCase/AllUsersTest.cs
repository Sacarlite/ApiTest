using ApiFramework.Converters;
using ApiFramework.Infrastructure;
using ApiFramework.Model.DataModels;
using ApiFramework.Model.ResponseModels;
using Aquality.Selenium.Browsers;
using System.Net;

namespace TestProject.TestCase
{
    public class AllUsersTest : BaseTest
    {
        [Test]
        public void AllUsersTestCase()
        {
            AqualityServices.Logger.Info($"Test case \"AllUsersTestCase\" started");
            var allPostResponse = Client.GetAllUsers();
            Assert.IsTrue(allPostResponse.Status == HttpStatusCode.OK, $"Произошла ошибка при получени данных с сервера. Ответ от сервера {allPostResponse.Status}, ожидаемый ответ {HttpStatusCode.OK}");
            var postModels = JsonDataConverter.DeserializeData<UserModel[]>(allPostResponse.Body);
            Assert.IsTrue(postModels.Any(user => user.Equals(DataProvider<TestDataModel>.GetConfigData().testUserModel)), "Заданя тестовая модель не найдена среди рассматриваемых в запросе");
            AqualityServices.Logger.Info($"Test case \"AllUsersTestCase\" is completed");
        }
    }
}
