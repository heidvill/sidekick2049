using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SideKickDLL;

namespace SideKickMVC.Controllers
{
    public class PeliController : Controller
    {

        // GET: Peli
        public IActionResult Index()
        {
            string json;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync($"https://localhost:44342/api/Tilasto").Result;
                json = response.Content.ReadAsStringAsync().Result;
            }
            List<Tilasto> t = JsonConvert.DeserializeObject<List<Tilasto>>(json);
            return View(t);
        }

        // GET: Peli/Details/5
        public IActionResult Details(int? id)
        {
            string json;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync($"https://localhost:44342/api/tilasto/{id}").Result;
                json = response.Content.ReadAsStringAsync().Result;
            }
            Tilasto t = JsonConvert.DeserializeObject<Tilasto>(json);
            return View(t);
        }

        // GET: Peli/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Peli/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tilasto t)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var content = new StringContent(JsonConvert.SerializeObject(t), UTF8Encoding.UTF8, "application/json");
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    var response = client.PostAsync("https://localhost:44342/api/Tilasto/", content).Result;
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Peli/Edit/5
        public IActionResult Edit(int? id)
        {
            return View();
        }

        // POST: Peli/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Tilasto t)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var content = new StringContent(JsonConvert.SerializeObject(t), UTF8Encoding.UTF8, "application/json");
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    var response = client.PutAsync($"https://localhost:44342/api/tilasto/{id}", content).Result;
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Peli/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Peli/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Tilasto t)
        {
            try
            {
                string json = "";
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new
                    MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.DeleteAsync($"https://localhost:44342/api/tilasto/{id}").Result;
                    json = response.Content.ReadAsStringAsync().Result;
                }
                return RedirectToAction("Index", "Peli");
            }
            catch
            {
                return View();
            }
        }
    }
}