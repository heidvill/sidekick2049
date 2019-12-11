using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SideKickDLL
{
    public partial class Tilasto
    {
        public int Id { get; set; }
        public string Nimi { get; set; }
        public int Taso { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH/mm}")]
        public DateTime Aika { get; set; }
        //public string Kayttajanimi { get; set; }
    }
}
