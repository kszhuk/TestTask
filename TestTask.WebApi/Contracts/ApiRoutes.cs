namespace TestTask.WebApi.Contracts
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public static class Orders
        {
            public const string Get = $"{Root}/singleorder";
            public const string UpdateSingle = $"{Root}/singleorder";
        }
    }
}
