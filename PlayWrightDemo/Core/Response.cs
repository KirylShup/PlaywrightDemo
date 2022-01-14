using Newtonsoft.Json;
using System;
using RestSharp;

namespace PlayWrightDemo.Core
{
    public class Response <T> where T : class
    {
        public T Body { get; private set; }
        public IRestResponse RestResponse { get; private set; }
        public Response(IRestResponse restResponse)
        {
            RestResponse = restResponse;
            try
            {
                Body = JsonConvert.DeserializeObject<T>(restResponse.Content);
            }
            catch (Exception) { }
        }

    }
}
