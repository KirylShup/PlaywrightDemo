using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayWrightDemo
{
    public class BaseDto
    {
        public virtual JToken ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
