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
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Peli/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Tilasto t)
        {
            string json = Helper.Delete(id);
            return RedirectToAction("Index", "Peli");
        }

        public ActionResult Kulkukortti()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Kulkukortti(string korttikoodi)
        {
            if (string.IsNullOrEmpty(korttikoodi))
            {
                return View();
            }
            else if (korttikoodi.Trim().ToLower() == "platyrhynchos")
            {
                Helper.PostNew(new Tilasto() { Nimi = User.Claims.First().Value, Taso = 1, Aika = DateTime.Now });
                return RedirectToAction("Lista");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Lista()
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
        public ActionResult Lista(string kätyri)
        {
            if (string.IsNullOrEmpty(kätyri))
            {
                return View();
            }
            else if (kätyri.Trim().ToLower() == "taavetti pähkinähovi")
            {
                Helper.PostNew(new Tilasto() { Nimi = User.Claims.First().Value, Taso = 2, Aika = DateTime.Now });
                return RedirectToAction("Color_It_Redd");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Color_It_Redd()
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
        public ActionResult Color_It_Redd(string pinkoodi)
        {
            if (string.IsNullOrEmpty(pinkoodi))
            {
                return View();
            }
            else if (pinkoodi.Trim().ToLower() == "2049")
            {
                Helper.PostNew(new Tilasto() { Nimi = User.Claims.First().Value, Taso = 3, Aika = DateTime.Now });
                return RedirectToAction("Morse");
            }
            else
            {
                return Content("Väärin");
            }
        }
        public ActionResult Morse()
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
        public ActionResult Morse(string salasana)
        {
            if (string.IsNullOrEmpty(salasana))
            {
                return View();
            }
            else if (salasana.Trim().ToLower() == "pulu")
            {
                Helper.PostNew(new Tilasto() { Nimi = User.Claims.First().Value, Taso = 4, Aika = DateTime.Now });
                return RedirectToAction("Levysoitin");
            }
            else
            {
                return Content("Väärin");
            }
        }
        public ActionResult Levysoitin()
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
        public ActionResult Levysoitin(string albumi)
        {
            if (string.IsNullOrEmpty(albumi))
            {
                return View();
            }
            else if (albumi.Trim().ToLower() == "looking for freedom")
            {
                Helper.PostNew(new Tilasto() { Nimi = User.Claims.First().Value, Taso = 6, Aika = DateTime.Now });
                return View();
                //return RedirectToAction("");
            }
            else
            {
                return Content("Väärin");
            }
        }
    }
}