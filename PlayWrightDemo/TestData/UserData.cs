using PlayWrightDemo.TestData.Models;
using System;
using System.Collections.Generic;

namespace PlayWrightDemo.TestData
{
    public static class UserData
    {
        private static Dictionary<string, UserBody> User = new Dictionary<string, UserBody>()
        {
            { "stagingUser",  stagingUser }
        };

        public static UserBody GetUser(string key)
        {
            if (!User.ContainsKey(key))
            {
                throw new Exception($"User with key '{key}' does not exist.");
            }
            else
            {
                return User[key];
            }
        }

        public static UserBody stagingUser => new UserBody()
        {
            FirstName = "test",
            LastName = "user",
            Email = "", // "fill email here"
            DefaultPassword = "", // "fill password here"
            Status = "Active",
        };
    }
}
