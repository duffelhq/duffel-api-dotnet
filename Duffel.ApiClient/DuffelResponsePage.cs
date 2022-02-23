namespace Duffel.ApiClient
{
    /// <summary>
    /// A paginated response that contains requested data as well as properties to retrieve
    /// previous and next page
    /// </summary>
    /// <typeparam name="T">Type of data in the response</typeparam>
    public class DuffelResponsePage<T> where T: class
    {
        public DuffelResponsePage(T data, string before, string after, int limit = 50)
        {
            Before = !string.IsNullOrEmpty(before) ? $"before={before}" : "";
            After = !string.IsNullOrEmpty(after) ? $"after={after}" : "";
            Limit = limit;
            Data = data;
        }
        public string Before { get; }
        public string After { get; }
        public int Limit { get; }
        public T Data { get; }
        
    }
    
}