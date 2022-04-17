namespace PlayWrightDemo.APIRepository.Endpoints
{
    public class BaseEndpoint
    {
        static string URL => "";
        private static BaseEndpoint endpoint;

        public BaseEndpoint Instance => endpoint ?? (endpoint = new BaseEndpoint());
    }
}
