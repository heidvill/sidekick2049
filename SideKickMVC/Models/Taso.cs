using SideKickDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SideKickMVC.Models
{
    public class Taso
    {
        public Tilasto Tilasto { get; set; }
        public static Dictionary<int, string> Linkit { get; set; } = new Dictionary<int, string>();

        static Taso()
        {
            Linkit.Add(1, "Kulkukortti");
            Linkit.Add(2, "Lista");
            Linkit.Add(3, "Color_It_Redd");
            Linkit.Add(4, "Morse");
        }
    }
}
