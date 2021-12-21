using RestSharp;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayWrightDemo.Core
{
    public static class RestMethods
    {
        public static IRestResponse Post (this CoreClient client, BaseDto body, (string key, string value) [] queryParameter = null, bool useToken = false, string authorizationToken = null)
        {
            var request = new RestRequest(Method.POST);
            if (body != null)
            {
                var json = body.ToJson().ToString();
                request.AddParameter("application/json", json, ParameterType.RequestBody);
            }

            if (queryParameter != null)
            {
                for (int i = 0; i < queryParameter.Length; i++)
                {
                    (string Key, string Value) tuple = queryParameter[i];
                    string item = tuple.Key;
                    string item2 = tuple.Value;
                    request.AddQueryParameter(item, item2);
                }
            }

            if (!useToken)
            {
                if (authorizationToken != null)
                {
                    request.AddHeader("Authorization", "Bearer" + authorizationToken);
                }
                else
                {
                    throw new Exception("Token equals to null");
                }
            }

            return client.Execute(request);
        }
        public static IRestResponse GetToken(this CoreClient client)
        {
            var request = new RestRequest(Method.POST);
            request.AddParameter("grant_type", "client_credentials");
            request.AddParameter("audience", "https://api.services.constructconnect.com");
            request.AddParameter("client_id", "place_here_clientId_From_Config");
            request.AddParameter("client_secret", "place_here_clientSecret_From_Config");

            return client.Execute(request);
        }
        public static IRestResponse Get (this CoreClient client, (string key, string value)[] queryParameter = null, bool useToken = false, string authorizationToken = null)
        {
            var request = new RestRequest(Method.GET);

            if (queryParameter != null)
            {
                for (int i = 0; i < queryParameter.Length; i++)
                {
                    (string Key, string Value) tuple = queryParameter[i];
                    string item = tuple.Key;
                    string item2 = tuple.Value;
                    request.AddQueryParameter(item, item2);
                }
            }

            if (!useToken)
            {
                if (authorizationToken != null)
                {
                    request.AddHeader("Authorization", "Bearer" + authorizationToken);
                }
                else
                {
                    throw new Exception("Token equals to null");
                }
            }

            return client.Execute(request);
        }
    }
}
