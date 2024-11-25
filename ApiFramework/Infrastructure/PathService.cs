using Aquality.Selenium.Browsers;

namespace ApiFramework.Infrastructure
{
    public static class PathService
    {
        public static string GetCurentFolderPath(string additionPath = "")
        {
            try
            {
                return Environment.CurrentDirectory + additionPath;
            }
            catch (Exception)
            {
                AqualityServices.Logger.Error("Невозможно установить путь к используемой директории");
                throw new Exception("Невозможно установить путь к используемой директории");
            }
        }
    }
}
