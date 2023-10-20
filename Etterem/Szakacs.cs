using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etterem 
{ 
    class Szakacs
    {
        public string nev{ get; private set; } //csak olvasható
        string specialitas;

        //konstruktor
        public Szakacs(string nev, string specialitas)
        {
            this.nev = nev;
            this.specialitas = specialitas;
        }
        //eseménykezelő létrehozása
        public event HozzavaloElkeszultKezelo HozzavaloElkeszult;

        public void SefKerValamit(string hozzavalo)
        {
            if (hozzavalo == specialitas) Foz();
        }
        void Foz()
        {
            Console.WriteLine($"{nev} főz '{specialitas}'-et");
            //eseménykezelő hívása előtt mindíg le kell ellenőrizni, hogy az !=null-e azaz fel vagyunk-e rá iratkozva
            if (HozzavaloElkeszult != null) HozzavaloElkeszult(specialitas);
        }

    }
}
