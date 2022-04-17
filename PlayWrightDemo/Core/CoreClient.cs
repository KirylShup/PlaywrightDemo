using RestSharp;

namespace PlayWrightDemo.Core
{
    public class CoreClient
    {
        public RestClient Client { get; set; }  

        public CoreClient ()
        {
            Client = new RestClient ();
        }

        public static CoreClient Instance ()
        {
            return new CoreClient ();
        }

        public RestResponse Execute (RestRequest request)
        {
            RestResponse response = Client.ExecuteAsync(request).Result;
            return response;
        }
    }
}
