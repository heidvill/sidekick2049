using System;
using System.Collections.Generic;

namespace SideKickDLL
{
    public partial class Tilasto
    {
        public int Id { get; set; }
        public string Nimi { get; set; }
        public int Taso { get; set; }
        public DateTime Aika { get; set; }
    }
}
