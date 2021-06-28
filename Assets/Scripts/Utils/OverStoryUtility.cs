using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;

namespace OS
{
    public class Utils
    {
        public static JObject Parse(string json)
        {
            json = json.TrimStart('\"').TrimEnd('\"').Replace("\"", "");
            return JObject.Parse(json);
        }

        private static StringBuilder stringBuilder = null;

        public static StringBuilder StringBuilder
        {
            get
            {
                if (stringBuilder == null)
                {
                    stringBuilder = new StringBuilder();
                }
                return stringBuilder;
            }
        }


    }
}
