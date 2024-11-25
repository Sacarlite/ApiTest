using ApiFramework.Converters;
using ApiFramework.Infrastructure;
using ApiFramework.Model.DataModels;
using ApiFramework.Model.ResponseModels;
using ApiFramework.Service;
using Aquality.Selenium.Browsers;
using System.Net;

namespace TestProject.TestCase
{
    public class PostRequestTest : BaseTest
    {
        [Test]
        public void PostRequestTestCase()
        {
            AqualityServices.Logger.Info($"Test case \"PostRequestTestCase\" started");
            var testModel = DataProvider<TestDataModel>.GetConfigData().PostModel;
            testModel.Body = RandomGenerationService.RandomString(DataProvider<TestDataModel>.GetConfigData().BodyLenght);
            testModel.Title = RandomGenerationService.RandomString(DataProvider<TestDataModel>.GetConfigData().TitleLenght);
            var postResp = Client.PostNewPost(testModel);
            Assert.IsTrue(postResp.Status == HttpStatusCode.Created, $"Произошла ошибка при получени данных с сервера. Ответ от сервера {postResp.Status}, ожидаемый ответ {HttpStatusCode.Created}");
            var postModel = JsonDataConverter.DeserializeData<PostModel>(postResp.Body);
            Assert.IsTrue(postModel.UserId == testModel.UserId && postModel.Body == testModel.Body && postModel.Title == testModel.Title, $"Полученные данные не совпадают с введёными. Введёные {testModel.ToString()}. Полученные {postModel.ToString()}");
            AqualityServices.Logger.Info($"Test case \"PostRequestTestCase\" is completed");
        }
    }
}
