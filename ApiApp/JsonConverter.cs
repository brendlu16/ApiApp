using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ApiApp
{
    class JsonConverter
    {
        public static Dictionary<string, object> DictionaryZJson(string input)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(input);
        }
    }
}
