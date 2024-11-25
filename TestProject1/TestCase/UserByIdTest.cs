using ApiFramework.Converters;
using ApiFramework.Infrastructure;
using ApiFramework.Model.DataModels;
using ApiFramework.Model.ResponseModels;
using Aquality.Selenium.Browsers;
using System.Net;

namespace TestProject.TestCase
{
    public class UserByIdTest : BaseTest
    {
        [Test]
        public void UserByIdTestCase()
        {
            AqualityServices.Logger.Info($"Test case \"UserByIdTestCase\" started");
            var testUserModel = DataProvider<TestDataModel>.GetConfigData().testUserModel;
            var allPostResponse = Client.GetUserById((int)testUserModel.Id);
            Assert.IsTrue(allPostResponse.Status == HttpStatusCode.OK, "$\"Произошла ошибка при получени данных с сервера. Ответ от сервера {allPostResponse.Status}, ожидаемый ответ {HttpStatusCode.OK}\"");
            var postModel = JsonDataConverter.DeserializeData<UserModel>(allPostResponse.Body);
            Assert.IsTrue(postModel.Equals(testUserModel), $"Полученный ответ не совпадает с тестовыми данными.  Введёные {testUserModel.ToString()}. Полученные {postModel.ToString()}");
            AqualityServices.Logger.Info($"Test case \"UserByIdTestCase\" is completed");
        }
    }
}
