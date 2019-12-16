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
            Linkit.Add(5, "Labyrintti");
            Linkit.Add(6, "Levysoitin");
            Linkit.Add(7, "Portaikko");
            Linkit.Add(8, "Takkahuone");
            Linkit.Add(9, "Ankkalampi");
        }
    }
}
