namespace Authentication
{
    public static class HttpClientFactorySingleton
    {
        private static IHttpClientFactory _httpClientFactory;

        public static void Initialize(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public static IHttpClientFactory GetHttpClientFactory()
        {
            if (_httpClientFactory == null)
            {
                throw new InvalidOperationException("HttpClientFactory has not been initialized.");
            }
            return _httpClientFactory;
        }
    }
}
