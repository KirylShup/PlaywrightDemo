using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayWrightDemo.Core
{
    public class Response <T> where T : class
    {
        public T Body { get; set; }
        public IRestResponse RestResponse { get; set; }
        public Response(IRestResponse restResponse)
        {
            RestResponse = restResponse;
            try
            {
                Body = JsonConvert.DeserializeObject<T>(restResponse.Content);
            }
            catch (Exception ex) { }
        }

    }
}
