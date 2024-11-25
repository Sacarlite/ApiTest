using ApiFramework.Converters;
using ApiFramework.Model.ResponseModels;
using Aquality.Selenium.Browsers;
using System.Net;

namespace TestProject.TestCase
{
    public class AllPostTest : BaseTest
    {
        [Test]
        public void AllPostTestCase()
        {
            AqualityServices.Logger.Info($"Test case \"AllPostTestCase\" started");
            var allPostResponse = Client.GetAllPost();
            Assert.IsTrue(allPostResponse.Status == HttpStatusCode.OK, $"Произошла ошибка при получени данных с сервера. Ответ от сервера {allPostResponse.Status}, ожидаемый ответ {HttpStatusCode.OK}");
            var postModels = JsonDataConverter.DeserializeData<PostModel[]>(allPostResponse.Body);
            Assert.IsTrue(postModels.Zip(postModels.Skip(1), (current, next) => next.Id > current.Id).All(x => x), "Нумерация постов идёт не по возрастанию");
            AqualityServices.Logger.Info($"Test case \"AllPostTestCase\" is completed");
        }
    }
}
