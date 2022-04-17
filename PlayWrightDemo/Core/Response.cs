using Newtonsoft.Json;
using System;
using RestSharp;

namespace PlayWrightDemo.Core
{
    public class Response <T> where T : class
    {
        public T Body { get; private set; }
        public RestResponse RestResponse { get; private set; }
        public Response(RestResponse restResponse)
        {
            RestResponse = restResponse;
            try
            {
                Body = JsonConvert.DeserializeObject<T>(restResponse.Content);
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
