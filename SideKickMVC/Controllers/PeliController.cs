using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SideKickDLL;
using SideKickMVC.Models;

namespace SideKickMVC.Controllers
{
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
            string json = Helper.GetAll();
            List<Tilasto> t = JsonConvert.DeserializeObject<List<Tilasto>>(json);
            return View(t);
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
            if (korttikoodi.Trim().ToLower() == "platyrhynchos")
            {
                return RedirectToAction("Lista");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Lista()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Lista(string kätyri)
        {
            if (kätyri.Trim().ToLower() == "taavetti pähkinähovi")
            {
                return Content("Oikein");
            }
            else
            {
                return Content("Väärin");
            }
        }

    }
}