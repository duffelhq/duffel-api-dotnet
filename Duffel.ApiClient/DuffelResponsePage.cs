namespace Duffel.ApiClient
{
    /// <summary>
    /// A paginated response that contains requested data as well as properties to retrieve
    /// previous and next page
    /// </summary>
    /// <typeparam name="T">Type of data in the response</typeparam>
    public class DuffelResponsePage<T> where T: class
    {
        public DuffelResponsePage(T data, string previousPage, string nextPage, int limit = 50)
        {
            PreviousPage = !string.IsNullOrEmpty(previousPage) ? $"before={previousPage}" : "";
            NextPage = !string.IsNullOrEmpty(nextPage) ? $"after={nextPage}" : "";
            Limit = limit;
            Data = data;
        }
        public string PreviousPage { get; }
        public string NextPage { get; }
        public int Limit { get; }
        public T Data { get; }
        
    }
    
}