using RestSharp;
using System;
using PlayWrightDemo.DTO.Responses;

namespace PlayWrightDemo.Core
{
    public static class RestMethods
    {
        public static Response<T> Get<T>(this CoreClient client, bool useToken = false, string authorizationToken = null, (string key, string value)[] queryParameter = null) where T : class
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

            if (useToken)
            {
                if (authorizationToken != null)
                {
                    request.AddHeader("Authorization", "Bearer " + authorizationToken);
                }
                else
                {
                    throw new Exception("Token equals to null");
                }
            }

            return new Response<T>(client.Execute(request));
        }
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
        public static Response<T> Patch<T>(this CoreClient client, BaseDto body = null, bool useToken = false, string authorizationToken = null, (string key, string value)[] queryParameter = null) where T : class
        {
            var request = new RestRequest(Method.PATCH);
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

            return new Response<T>(client.Execute(request));
        }
        public static Response<T> Put<T>(this CoreClient client, BaseDto body = null, bool useToken = false, string authorizationToken = null, (string key, string value)[] queryParameter = null) where T : class
        {
            var request = new RestRequest(Method.PUT);
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

            return new Response<T>(client.Execute(request));
        }
        public static Response<T> Delete<T>(this CoreClient client, BaseDto body = null, bool useToken = false, string authorizationToken = null, (string key, string value)[] queryParameter = null) where T : class
        {
            var request = new RestRequest(Method.DELETE);
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

            return new Response<T>(client.Execute(request));
        }

        public static Response<TokenDto> GetM2MToken(this CoreClient client)
        {
            var request = new RestRequest(Method.POST);
            request.AddParameter("grant_type", Configuration.Configuration.GrantTypeClientCredentials);
            request.AddParameter("audience", Configuration.Configuration.Audience);
            request.AddParameter("client_id", Configuration.Configuration.ClientIdBackOffice);
            request.AddParameter("client_secret", Configuration.Configuration.ClientSecretBackOffice);

            return new Response<TokenDto>(client.Execute(request));
        }

        public static Response<TokenDto> GetUserToken(this CoreClient client, string userName, string password)
        {
            var request = new RestRequest(Method.POST);
            request.AddParameter("grant_type", Configuration.Configuration.GrantTypePasswordFlow);
            request.AddParameter("audience", "https://api.app.constructconnect.com"); // change config file, audience for M2M token and user-token are different
            request.AddParameter("client_id", Configuration.Configuration.ClientIdTakeoffDesktop);
            request.AddParameter("client_secret", Configuration.Configuration.ClientSecretTakeoffDesktop);
            request.AddParameter("scope", Configuration.Configuration.Scope);
            request.AddParameter("username", userName);
            request.AddParameter("password", password);

            return new Response<TokenDto>(client.Execute(request));
        }
    }
}
