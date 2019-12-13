using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SideKickDLL;
using SideKickMVC.Extensions.Alerts;
using SideKickMVC.Models;

namespace SideKickMVC.Controllers
{
    [Authorize]
    public class PeliController : Controller
    {
        IConfiguration configuration;
        public PeliController(IConfiguration configuration)
        {
            this.configuration = configuration;
            Helper.polku = configuration.GetConnectionString("RestAPIUrl");

        }

        // GET: Peli
        
        public IActionResult Index()
        {
            try
            {
            Tilasto t = Helper.GetPlayerByName(User.Claims.First().Value).OrderBy(t => t.Taso).LastOrDefault();
            Taso taso = new Taso();
            taso.Tilasto = t;
            return View(taso);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Peli/Details/5
        public IActionResult Details(int? id)
        {
            string json = Helper.GetById(id);
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
            bool success = Helper.PostNew(t);
            return RedirectToAction("Index");
            //return RedirectToAction(nameof(Index));
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
            Helper.Edit(id, t);
            return RedirectToAction(nameof(Index));
        }

        // GET: Peli/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

        // POST: Peli/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Tilasto t)
        {
            string json = Helper.Delete(id);
            return RedirectToAction("Index", "Peli");
        }

        public IActionResult Kulkukortti()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Kulkukortti(string korttikoodi)
        {
            if (string.IsNullOrEmpty(korttikoodi))
            {
                return View();
            }
            else if (korttikoodi.Trim().ToLower() == "platyrhynchos")
            {
                Helper.PostNew(new Tilasto() { Nimi = User.Claims.First().Value, Taso = 1, Aika = DateTime.Now });
                return RedirectToAction("Lista").WithSuccess("Hienoa!", "Oikea vastaus");
            }
            else
            {
                return View().WithWarning("Väärin meni!", "Syöttämäsi vastaus on väärä"); 
            }
        }
        public IActionResult Lista()
        {
            Tilasto t = Helper.GetPlayerByName(User.Claims.First().Value).OrderBy(t => t.Taso).LastOrDefault();
            if (t == null)
            {
                return RedirectToAction("Index");
            }
            if (t.Taso >= 1)
            {
                return View();
            }
            else return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Lista(string kätyri)
        {
            if (string.IsNullOrEmpty(kätyri))
            {
                return View();
            }
            else if (kätyri.Trim().ToLower() == "taavetti pähkinähovi")
            {
                Helper.PostNew(new Tilasto() { Nimi = User.Claims.First().Value, Taso = 2, Aika = DateTime.Now });
                return RedirectToAction("Color_It_Redd").WithSuccess("Hienoa!", "Oikea vastaus");
            }
            else
            {
                return View().WithWarning("Väärin meni!", "Syöttämäsi henkilö ei ole se, jota etsimme!");
            }
        }
        public IActionResult Color_It_Redd()
        {
            Tilasto t = Helper.GetPlayerByName(User.Claims.First().Value).OrderBy(t => t.Taso).LastOrDefault();
            if (t == null)
            {
                return RedirectToAction("Index");
            }
            if (t.Taso >= 2)
            {
                return View();
            }
            else return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Color_It_Redd(string pinkoodi)
        {
            if (string.IsNullOrEmpty(pinkoodi))
            {
                return View();
            }
            else if (pinkoodi.Trim().ToLower() == "2049")
            {
                Helper.PostNew(new Tilasto() { Nimi = User.Claims.First().Value, Taso = 3, Aika = DateTime.Now });
                return RedirectToAction("Morse").WithSuccess("Hienoa!","Oikea vastaus");
            }
            else
            {
                return View().WithWarning("Väärin meni!", "Etkö tiedä minne kaikki tiet vievät?");
            }
        }
        public IActionResult Morse()
        {
            Tilasto t = Helper.GetPlayerByName(User.Claims.First().Value).OrderBy(t => t.Taso).LastOrDefault();
            if (t == null)
            {
                return RedirectToAction("Index");
            }
            if (t.Taso >= 3)
            {
                return View();
            }
            else return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Morse(string salasana)
        {
            if (string.IsNullOrEmpty(salasana))
            {
                return View();
            }
            else if (salasana.Trim().ToLower() == "pulu")
            {
                Helper.PostNew(new Tilasto() { Nimi = User.Claims.First().Value, Taso = 4, Aika = DateTime.Now });
                return RedirectToAction("Levysoitin").WithSuccess("Hienoa!", "Oikea vastaus");
            }
            else
            {
                return View().WithDanger("Väärin meni!", "Antamasi vastaus on väärä");
            }
        }

        public IActionResult Levysoitin()
        {
            Tilasto t = Helper.GetPlayerByName(User.Claims.First().Value).OrderBy(t => t.Taso).LastOrDefault();
            if (t == null)
            {
                return RedirectToAction("Index");
            }
            if (t.Taso >= 5)
            {
                return View();
            }
            else return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Levysoitin(string albumi)
        {
            if (string.IsNullOrEmpty(albumi))
            {
                return View();
            }
            else if (albumi.Trim().ToLower() == "looking for freedom")
            {
                Helper.PostNew(new Tilasto() { Nimi = User.Claims.First().Value, Taso = 6, Aika = DateTime.Now });
                return View().WithSuccess("Hienoa!", "Oikea vastaus");
                //return RedirectToAction("");
            }
            else
            {
                return View().WithInfo("Väärin meni!", "Ehdottamasi albumi ei ole se mitä haetaan");
            }
        }
        public IActionResult Portaikko()
        {
            Tilasto t = Helper.GetPlayerByName(User.Claims.First().Value).OrderBy(t => t.Taso).LastOrDefault();
            if (t == null)
            {
                return RedirectToAction("Index");
            }
            if (t.Taso >= 6)
            {
                return View();
            }
            else return RedirectToAction("Index");
        }

        public IActionResult Takkahuone()
        {
            Tilasto t = Helper.GetPlayerByName(User.Claims.First().Value).OrderBy(t => t.Taso).LastOrDefault();
            if (t == null)
            {
                return RedirectToAction("Index");
            }
            if (t.Taso >= 7)
            {
                return View();
            }
            else return RedirectToAction("Index");
        }
    }
}