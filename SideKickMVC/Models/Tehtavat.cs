using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SideKickMVC.Models
{
    public class Tehtavat
    {
        public static Dictionary<int, string> kulkukortit = new Dictionary<int, string>();

        public static Dictionary<int, string> kulkukorttiVastaukset = new Dictionary<int, string>();
        public static Dictionary<int, string> morsekoodit = new Dictionary<int, string>();
        public static Dictionary<int, string> morseVastaukset = new Dictionary<int, string>();
        public static Dictionary<int, string> lsTeksti = new Dictionary<int, string>();
        public static Dictionary<int, string> lsVastaukset = new Dictionary<int, string>();

        static Tehtavat()
        {
            kulkukortit.Add(1, "../media/accesscard.jpg");
            kulkukortit.Add(2, "../media/accesscard2.jpg");
            kulkukortit.Add(3, "../media/accesscard3.jpg");
            kulkukortit.Add(4, "../media/accesscard4.jpg");
            kulkukortit.Add(5, "../media/accesscard5.jpg");
            kulkukorttiVastaukset.Add(1, "platyrhynchos");
            kulkukorttiVastaukset.Add(2, "leucopsis");
            kulkukorttiVastaukset.Add(3, "galericulata");
            kulkukorttiVastaukset.Add(4, "carolinensis");
            kulkukorttiVastaukset.Add(5, "merganser");
            morsekoodit.Add(1, "../media/piip.wav");
            morsekoodit.Add(2, "../media/piip2.wav");
            morsekoodit.Add(3, "../media/piip3.wav");
            morsekoodit.Add(4, "../media/piip4.wav");
            morsekoodit.Add(5, "../media/piip5.wav");
            morseVastaukset.Add(1, "pulu");
            morseVastaukset.Add(2, "lokki");
            morseVastaukset.Add(3, "tikka");
            morseVastaukset.Add(4, "kana");
            morseVastaukset.Add(5, "lunni");
            lsTeksti.Add(1, $"One morning in June some twenty years ago I was born a rich man's son");
            lsTeksti.Add(2, $"Whoa, ain't the moon a beauty man don't it shine");
            lsTeksti.Add(3, $"Lips as sweet as candy your taste is on my mind");
            lsTeksti.Add(4, $"I don't even wanna try I guess the both of us sing a foolish lullaby");
            lsTeksti.Add(5, $"I've been lookin' back and longin' for the freedom from my chains");
            lsVastaukset.Add(1, "looking for freedom");
            lsVastaukset.Add(2, "night rocker");
            lsVastaukset.Add(3, "hooked on a feeling");
            lsVastaukset.Add(4, "everybody sunshine");
            lsVastaukset.Add(5, "lovin' feelings");
        }
    }
}
