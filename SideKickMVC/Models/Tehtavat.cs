using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SideKickMVC.Models
{
    public class Tehtavat
    {
        public static Dictionary<int, string> Kulkukortit = new Dictionary<int, string>();

        public static Dictionary<int, string> KulkukorttiVastaukset = new Dictionary<int, string>();
        public static Dictionary<int, string> Morsekoodit = new Dictionary<int, string>();
        public static Dictionary<int, string> MorseVastaukset = new Dictionary<int, string>();
        public static Dictionary<int, string> LsTeksti = new Dictionary<int, string>();
        public static Dictionary<int, string> LsVastaukset = new Dictionary<int, string>();

        static Tehtavat()
        {
            Kulkukortit.Add(1, "../media/accesscard.jpg");
            Kulkukortit.Add(2, "../media/accesscard2.jpg");
            Kulkukortit.Add(3, "../media/accesscard3.jpg");
            Kulkukortit.Add(4, "../media/accesscard4.jpg");
            Kulkukortit.Add(5, "../media/accesscard5.jpg");
            KulkukorttiVastaukset.Add(1, "platyrhynchos");
            KulkukorttiVastaukset.Add(2, "leucopsis");
            KulkukorttiVastaukset.Add(3, "galericulata");
            KulkukorttiVastaukset.Add(4, "carolinensis");
            KulkukorttiVastaukset.Add(5, "merganser");
            Morsekoodit.Add(1, "../media/piip.wav");
            Morsekoodit.Add(2, "../media/piip2.wav");
            Morsekoodit.Add(3, "../media/piip3.wav");
            Morsekoodit.Add(4, "../media/piip4.wav");
            Morsekoodit.Add(5, "../media/piip5.wav");
            MorseVastaukset.Add(1, "pulu");
            MorseVastaukset.Add(2, "lokki");
            MorseVastaukset.Add(3, "tikka");
            MorseVastaukset.Add(4, "kana");
            MorseVastaukset.Add(5, "lunni");
            LsTeksti.Add(1, $"One morning in June some twenty years ago I was born a rich man's son");
            LsTeksti.Add(2, $"Whoa, ain't the moon a beauty man don't it shine");
            LsTeksti.Add(3, $"Lips as sweet as candy your taste is on my mind");
            LsTeksti.Add(4, $"I don't even wanna try I guess the both of us sing a foolish lullaby");
            LsTeksti.Add(5, $"I've been lookin' back and longin' for the freedom from my chains");
            LsVastaukset.Add(1, "looking for freedom");
            LsVastaukset.Add(2, "night rocker");
            LsVastaukset.Add(3, "hooked on a feeling");
            LsVastaukset.Add(4, "everybody sunshine");
            LsVastaukset.Add(5, "lovin' feelings");
        }
    }
}
