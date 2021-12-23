using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
