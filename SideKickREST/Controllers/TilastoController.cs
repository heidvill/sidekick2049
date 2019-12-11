using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SideKickDLL;

namespace SideKickREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TilastoController : ControllerBase
    {
        private readonly PelaajadbContext _db;

        public TilastoController(PelaajadbContext db)
        {
            _db = db;
        }


        // GET: api/Tilasto
        [HttpGet]
        public IEnumerable<Tilasto> Get()
        {
            return _db.Tilasto.ToList();
        }

        // GET: api/Tilasto/5
        [HttpGet("{id}", Name = "Get")]
        public Tilasto Get(int id)
        {
            Tilasto t = _db.Tilasto.Where(a => a.Id == id).FirstOrDefault();
            return t;
        }

        // GET: api/Tilasto/nimi
        [HttpGet("Search/{nimi}", Name = "Search")]
        public IEnumerable<Tilasto> GetAllByName(string nimi)
        {
            var pelaajat = _db.Tilasto.Where(a => a.Nimi.ToLower().Contains(nimi.ToLower())).ToList();
            return pelaajat;
        }

        [HttpGet("Haku/{nimi}")]
        public IEnumerable<Tilasto> FindPlayerByName(string nimi)
        {
            var pelaaja = _db.Tilasto.Where(a => a.Nimi.ToLower() == nimi.ToLower()).ToList();
            return pelaaja;
        }

        // POST: api/Tilasto
        [HttpPost]
        public void Post([FromBody] Tilasto t)
        {
            _db.Tilasto.Add(t);
            _db.SaveChanges();
        }

        // PUT: api/Tilasto/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Tilasto tilasto)
        {
            Tilasto t = _db.Tilasto.Find(id);
            t.Nimi = tilasto.Nimi;
            t.Taso = tilasto.Taso;
            t.Aika = tilasto.Aika;
            _db.SaveChanges();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Tilasto t = _db.Tilasto.Find(id);
            _db.Tilasto.Remove(t);
            _db.SaveChanges();
        }
    }
}
