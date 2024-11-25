using Aquality.Selenium.Browsers;
using Newtonsoft.Json;

namespace ApiFramework.Converters
{
    public static class JsonDataConverter
    {
        public static T DeserializeData<T>(string json)
        {
            AqualityServices.Logger.Info($"Desirializing data to {typeof(T)} model");
            try
            {
                var data = JsonConvert.DeserializeObject<T>(json);

                if (data is null)
                {
                    AqualityServices.Logger.Error("An error occurred while deserializing the json data");
                    throw new InvalidOperationException("Произошла ошибка при десериализации json данных");
                }

                return data;
            }
            catch (Exception ex)
            {
                AqualityServices.Logger.Error($"An error occurred while converting json data {ex.Message}");
                throw new Exception($"Произошла ошибка при конвертации json данных {ex.Message}");
            }
        }

        public static string SerializeData(object json)
        {
            AqualityServices.Logger.Info($"Serializing data to json model");
            try
            {
                var data = JsonConvert.SerializeObject(json);
                return data;
            }
            catch (Exception ex)
            {
                AqualityServices.Logger.Error($"An error occurred while serializing to json {ex.Message}");
                throw new Exception($"Произошла ошибка при сериализации объекта в json {ex.Message}");
            }
        }

    }
}
