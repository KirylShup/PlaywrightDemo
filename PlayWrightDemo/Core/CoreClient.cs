using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayWrightDemo.Core
{
    public class CoreClient
    {
        public RestClient Client { get; set; }  

        public CoreClient (string endpoint)
        {
            Client = new RestClient (endpoint);
        }

        public static CoreClient Instance (string endpoint)
        {
            return new CoreClient (endpoint);
        }

        public IRestResponse Execute (RestRequest request)
        {
            IRestResponse response = Client.Execute(request);
            return response;
        }
    }
}
