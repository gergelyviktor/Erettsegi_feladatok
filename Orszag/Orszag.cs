using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orszagok {
    internal class Orszag {
        public string Orszagnev { get; set; }
        public int Terulet { get; set; }
        public int Nepesseg { get; set; }
        public string Fovaros { get; set; }
        public int FovarosNepesseg { get; set; }

        public Orszag(string adatsor) {
            string[] sor = adatsor.Split(';');
            Orszagnev = sor[0];
            Terulet = int.Parse(sor[1]);
            if (sor[2].Last() == 'g') {
                Nepesseg = int.Parse(sor[2].Substring(0, sor[2].Length - 1));
            }
            else Nepesseg = int.Parse(sor[2]);
            Fovaros = sor[3];
            FovarosNepesseg = int.Parse(sor[4]);
        }
    }
}
