using RestSharp;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using PlayWrightDemo.DTO.Responses;
using PlayWrightDemo.Configuration;

namespace PlayWrightDemo.Core
{
    public static class RestMethods
    {
        public static Response<T> Post<T> (this CoreClient client, BaseDto body, bool useToken = false, string authorizationToken = null, (string key, string value) [] queryParameter = null) where T : class
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

            if (useToken)
            {
                if (authorizationToken != null)
                {
                    request.AddHeader("Authorization", "Bearer " + authorizationToken);
                    request.AddHeader("User", "AutoQA");
                }
                else
                {
                    throw new Exception("Token equals to null");
                }
            }

            return new Response<T> (client.Execute(request));
        }
        public static Response<TokenDto> GetM2MToken(this CoreClient client)
        {
            var request = new RestRequest(Method.POST);
            request.AddParameter("grant_type", Configuration.Configuration.GrantType);
            request.AddParameter("audience", Configuration.Configuration.Audience);
            request.AddParameter("client_id", Configuration.Configuration.ClientIdBackOffice);
            request.AddParameter("client_secret", Configuration.Configuration.ClientSecretBackOffice);

            return new Response<TokenDto>(client.Execute(request));
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
