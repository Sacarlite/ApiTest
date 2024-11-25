using ApiFramework.Model.DataModels;
using Aquality.Selenium.Browsers;
using Newtonsoft.Json;

namespace ApiFramework.Infrastructure
{
    public static class DataProvider<T>
    {
        private static readonly Dictionary<Type, string> map = new()
        {
             { typeof(TestDataModel) ,  "testData.json"},
             { typeof(ConfigModel) ,  "config.json"},
         };
        private const string ResoursesPath = "\\Resources";

        public static T GetConfigData()
        {

            if (!map.TryGetValue(typeof(T), out var fileName))
            {
                AqualityServices.Logger.Error($"There are no registered models for the object  {typeof(T)}");
                throw new InvalidOperationException($"Нет зарегистрированных моделей для объекта {typeof(T)}");
            }

            var configPath = Path.Combine(PathService.GetCurentFolderPath(ResoursesPath), fileName);
            try
            {
                var serializedData = File.ReadAllText(configPath);
                var config = JsonConvert.DeserializeObject<T>(serializedData);

                if (config is null)
                {
                    AqualityServices.Logger.Error("An error occurred while deserializing the config file");
                    throw new InvalidOperationException("Произошла ошибка при десериализации config файла");
                }

                return config;
            }
            catch (Exception ex)
            {
                AqualityServices.Logger.Error($"An error occurred while reading and converting the file {fileName} {ex.Message}");
                throw new Exception($"Произошла ошибка при считывании и конвертации файла {fileName} {ex.Message}");
            }
        }
    }
}
