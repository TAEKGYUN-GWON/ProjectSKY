using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace OS
{
    public class Utils
    {
        public static JObject Parse(string json)
        {
            json = json.TrimStart('\"').TrimEnd('\"').Replace("\"", "");
            return JObject.Parse(json);
        }
    }
}
