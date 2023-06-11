namespace TestTask.Web.Helpers
{
    public class HttpClientUriOptions
    {
        public const string HttpClientUri = "HttpClientUri";

        public string BaseAddress { get; set; } = String.Empty;
        public string OrderGetUri { get; set; } = String.Empty;
        public string OrderUpdateSingleUri { get; set; } = String.Empty;
    }
}
