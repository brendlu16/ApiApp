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
        public static string NacistID(int ID)
        {
            var result = Task.Run(async () => { return await GetID(ID); }).Result;
            return result;
        }
        private static async Task<string> GetID(int ID)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://api.spacexdata.com/v3/launches/"+ID.ToString());
            string json = await response.Content.ReadAsStringAsync();
            return json;
        }
        public static string NacistVse()
        {
            var result = Task.Run(async () => { return await GetVse(); }).Result;
            return result;
        }
        private static async Task<string> GetVse()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://api.spacexdata.com/v3/launches/");
            string json = await response.Content.ReadAsStringAsync();
            return json;
        }
    }
}
