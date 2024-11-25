using ApiFramework.Converters;
using ApiFramework.Infrastructure;
using ApiFramework.Model.DataModels;
using ApiFramework.Model.ResponseModels;
using Aquality.Selenium.Browsers;
using System.Net;

namespace TestProject.TestCase
{
    public class PostByIdTest : BaseTest
    {

        [Test]
        public void TestPostByIdCase()
        {
            AqualityServices.Logger.Info($"Test case \"TestPostByIdCase\" started");
            var testModel = DataProvider<TestDataModel>.GetConfigData().GetPostModel;
            var allPostResponse = Client.GetPostById((int)testModel.Id);
            Assert.IsTrue(allPostResponse.Status == HttpStatusCode.OK, $"Произошла ошибка при получени данных с сервера. Ответ от сервера {allPostResponse.Status}, ожидаемый ответ {HttpStatusCode.OK}");
            var postModels = JsonDataConverter.DeserializeData<PostModel>(allPostResponse.Body);
            Assert.IsTrue(postModels.Id == testModel.Id, "Id полученого поста не совпадает с тестовыми данными");
            Assert.IsTrue(postModels.UserId == testModel.UserId, "Id полученого пользователя не совпадает с тестовыми данными");
            Assert.IsTrue(!string.IsNullOrEmpty(postModels.Body), "Тело поста пусто");
            Assert.IsTrue(!string.IsNullOrEmpty(postModels.Title), "Заголовок поста пуст");
            AqualityServices.Logger.Info($"Test case \"TestPostByIdCase\" is completed");
        }
    }
}
