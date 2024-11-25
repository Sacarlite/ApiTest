namespace ApiFramework.Service
{
    public partial class RandomGenerationService
    {
        private static Random Rand = new Random();
        private const string AllChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstvuwxyz0123456789";
        public static string RandomString(int length)
        {
            return new string(Enumerable.Repeat(AllChars, length)
                .Select(s => s[Rand.Next(s.Length)]).ToArray());
        }
    }
}
