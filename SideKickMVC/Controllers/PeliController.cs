using System;
using System.Linq;
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
            Tilasto t = Helper.GetPlayerByName(User.Claims.First().Value).OrderBy(t => t.Taso).LastOrDefault();
            Taso taso = new Taso();
            taso.Tilasto = t;
            return View(taso);
        }

        public IActionResult Kulkukortti()
        {
            ViewBag.random = new Random().Next(1, Tehtavat.Kulkukortit.Count + 1);
            return View();
        }

        [HttpPost]
        public IActionResult Kulkukortti(string korttikoodi, int random)
        {
            if (string.IsNullOrEmpty(korttikoodi))
            {
                ViewBag.random = random;
                return View();
            }
            else if (korttikoodi.Trim().ToLower() == Tehtavat.KulkukorttiVastaukset[random])
            {
                TallennaTietokantaan(1);
                return RedirectToAction("Lista").WithSuccess("Hienoa!", "Oikea vastaus");
            }
            else
            {
                ViewBag.random = random;
                return View().WithDanger("Väärin meni!", "Syöttämäsi vastaus on väärä");
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
            else return RedirectToAction("Index").WithDanger("Virhe", "Et ole läpäissyt riittävästi tasoja avataksesi tämän tason");
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
                TallennaTietokantaan(2);
                return RedirectToAction("Color_It_Redd").WithSuccess("Hienoa!", "Oikea vastaus");
            }
            else
            {
                return View().WithDanger("Väärin meni!", "Syöttämäsi henkilö ei ole se, jota etsimme!");
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
            else return RedirectToAction("Index").WithDanger("Virhe", "Et ole läpäissyt riittävästi tasoja avataksesi tämän tason");
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
                TallennaTietokantaan(3);
                return RedirectToAction("Morse").WithSuccess("Hienoa!", "Oikea vastaus");
            }
            else
            {
                return View().WithWarning("Väärin meni!", "Etkö tiedä minne kaikki tiet vievät?");
            }
        }

        public IActionResult Morse()
        {
            ViewBag.random = new Random().Next(1, Tehtavat.Morsekoodit.Count + 1);
            Tilasto t = Helper.GetPlayerByName(User.Claims.First().Value).OrderBy(t => t.Taso).LastOrDefault();
            if (t == null)
            {
                return RedirectToAction("Index");
            }
            if (t.Taso >= 3)
            {
                return View();
            }
            else return RedirectToAction("Index").WithDanger("Virhe", "Et ole läpäissyt riittävästi tasoja avataksesi tämän tason");
        }

        [HttpPost]
        public IActionResult Morse(string salasana, int random)
        {
            if (string.IsNullOrEmpty(salasana))
            {
                ViewBag.random = random;
                return View();
            }
            else if (salasana.Trim().ToLower() == Tehtavat.MorseVastaukset[random])
            {
                TallennaTietokantaan(4);
                return RedirectToAction("Labyrintti").WithSuccess("Hienoa!", "Oikea vastaus");
            }
            else
            {
                ViewBag.random = random;
                return View().WithDanger("Väärin meni!", "Antamasi vastaus on väärä");
            }
        }

        public IActionResult Labyrintti()
        {
            Tilasto t = Helper.GetPlayerByName(User.Claims.First().Value).OrderBy(t => t.Taso).LastOrDefault();
            if (t == null)
            {
                return RedirectToAction("Index");
            }
            if (t.Taso >= 4)
            {
                return View();
            }
            else return RedirectToAction("Index").WithDanger("Virhe", "Et ole läpäissyt riittävästi tasoja avataksesi tämän tason");
        }

        [HttpPost]
        [ActionName("Labyrintti")]
        public IActionResult LabyrinttiPost()
        {
            TallennaTietokantaan(5);
            return RedirectToAction("Levysoitin");
        }

        public IActionResult Levysoitin()
        {
            ViewBag.random = new Random().Next(1, Tehtavat.LsTeksti.Count + 1);
            Tilasto t = Helper.GetPlayerByName(User.Claims.First().Value).OrderBy(t => t.Taso).LastOrDefault();
            if (t == null)
            {
                return RedirectToAction("Index");
            }
            if (t.Taso >= 5)
            {
                return View();
            }
            else return RedirectToAction("Index").WithDanger("Virhe", "Et ole läpäissyt riittävästi tasoja avataksesi tämän tason");
        }

        [HttpPost]
        public IActionResult Levysoitin(string albumi, int random)
        {
            if (string.IsNullOrEmpty(albumi))
            {
                ViewBag.random = random;
                return View();
            }
            else if (albumi.Trim().ToLower() == Tehtavat.LsVastaukset[random])
            {
                TallennaTietokantaan(6);
                return RedirectToAction("Portaikko").WithSuccess("Hienoa!", "Oikea vastaus");
            }
            else
            {
                ViewBag.random = random;
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
            else return RedirectToAction("Index").WithDanger("Virhe", "Et ole läpäissyt riittävästi tasoja avataksesi tämän tason");
        }

        public IActionResult Takkahuone()
        {
            Tilasto t = Helper.GetPlayerByName(User.Claims.First().Value).OrderBy(t => t.Taso).LastOrDefault();
            if (t == null)
            {
                return RedirectToAction("Index");
            }
            if (t.Taso >= 6 && HttpContext.Request.Path.ToString().ToLower() == "/peli/takkahuone")
            {
                TallennaTietokantaan(7);
                return View().WithSuccess("Hienoa!", "Oikea vastaus");
            }
            else return RedirectToAction("Index").WithDanger("Virhe", "Et ole läpäissyt riittävästi tasoja avataksesi tämän tason");
        }

        public IActionResult Ankkalampi()
        {
            Tilasto t = Helper.GetPlayerByName(User.Claims.First().Value).OrderBy(t => t.Taso).LastOrDefault();
            if (t == null)
            {
                return RedirectToAction("Index");
            }
            if (t.Taso >= 8)
            {
                return View();
            }
            else return RedirectToAction("Index").WithDanger("Virhe", "Et ole läpäissyt riittävästi tasoja avataksesi tämän tason");
        }

        [HttpPost]
        [ActionName("Ankkalampi")]
        public IActionResult AnkkalampiPost()
        {
            TallennaTietokantaan(9);
            return RedirectToAction("Iccanobif").WithSuccess("Hienoa!", "Löysit oikean sorsan");
        }

        [AllowAnonymous]
        public IActionResult Iccanobif()
        {
            Tilasto t = Helper.GetPlayerByName(User.Claims.First().Value).OrderBy(t => t.Taso).LastOrDefault();
            if (t == null)
            {
                return RedirectToAction("Index");
            }
            if (t.Taso >= 9)
            {
                
                ViewBag.Fibo = LaskeFibo();
                return View();
            }
            else return RedirectToAction("Index").WithDanger("Virhe", "Et ole läpäissyt riittävästi tasoja avataksesi tämän tason");
        }

        [HttpPost]
        public IActionResult Iccanobif(string pinkoodi)
        {
            if (string.IsNullOrEmpty(pinkoodi))
            {
                //ViewBag.random = random;
                ViewBag.Fibo = LaskeFibo();
                return View();
            }
            else if (pinkoodi.Trim().ToLower() == "3524578") // Tehtavat.LsVastaukset[random]
            {
                TallennaTietokantaan(10);
                return RedirectToAction("Lazer").WithSuccess("Hienoa!", "Oikea vastaus");
            }
            else
            {
                //ViewBag.random = random;
                ViewBag.Fibo = LaskeFibo();
                return View().WithInfo("Väärin meni!", "");
            }
        }

        private string LaskeFibo()
        {
            long eka = 1;
            long toka = 1;
            string fibomj = eka.ToString() + toka.ToString();

            for (int i = 0; i < 30; i++)
            {
                long temp = toka + eka;
                fibomj = temp + fibomj;
                eka = toka;
                toka = temp;
            }
            string paluu = "";
            for (int i = 0; i < fibomj.Length; i++)
            {
                if (i % 4 == 0)
                {
                    paluu += " ";
                }
                paluu += fibomj[i];
            }
            return paluu.Trim();
        }

        public IActionResult Lazer()
        {
            return View();
        }

        private void TallennaTietokantaan(int taso)
        {
            Tilasto t = Helper.GetPlayerByName(User.Claims.First().Value).Where(t => t.Taso == taso).FirstOrDefault();
            if (t == null)
            {
                Helper.PostNew(new Tilasto() { Nimi = User.Claims.First().Value, Taso = taso, Aika = DateTime.Now });
            }
        }
    }
}