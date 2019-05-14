using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiApp
{
    class HttpManager
    {
        public static string NacistNext()
        {
            var result = Task.Run(async () => { return await GetNext(); }).Result;
            return result;
        }
        private static async Task<string> GetNext()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://api.spacexdata.com/v3/launches/next");
            string json = await response.Content.ReadAsStringAsync();
            return json;
        }
    }
}
