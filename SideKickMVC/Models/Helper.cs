using Newtonsoft.Json;
using SideKickDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SideKickMVC.Models
{
    public class Helper
    {
        private static string polku = "https://sidekick2049api.azurewebsites.net/api/Tilasto";

        public static string GetAll()
        {
            string json;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(polku).Result;
                json = response.Content.ReadAsStringAsync().Result;
            }
            return json;
        }

        public static string GetById(int? id)
        {
            string json;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync($"{polku}/{id}").Result;
                json = response.Content.ReadAsStringAsync().Result;
            }
            return json;
        }

        public static bool PostNew(Tilasto t)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var content = new StringContent(JsonConvert.SerializeObject(t), UTF8Encoding.UTF8, "application/json");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = client.PostAsync(polku, content).Result;
                return response.IsSuccessStatusCode;
            }
        }

        public static bool Edit(int id, Tilasto t)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var content = new StringContent(JsonConvert.SerializeObject(t), UTF8Encoding.UTF8, "application/json");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = client.PutAsync($"{polku}/{id}", content).Result;
                return response.IsSuccessStatusCode;
            }
        }

        public static string Delete(int id)
        {
            string json;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.DeleteAsync($"{polku}/{id}").Result;
                json = response.Content.ReadAsStringAsync().Result;
            }
            return json;
        }
    }
}
