namespace Duffel.ApiClient.Tests
{
    public static class JsonFixture
    {
        public static string Load(string relativePath)
        {
            return System.IO.File.ReadAllText($"Fixtures/{relativePath}");
        }
    }
}