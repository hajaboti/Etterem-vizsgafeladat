using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etterem
{
    class Sef
    {
        Etel[] receptek;
        Etel cel;
        int szuksegesHozzavaloSzam;
        public Sef()
        {
            receptek = new Etel[]
            {
                new Etel("poharviz", new string[] { "viz" } ),
                new Etel("leves", new string[] { "repa", "hus", "krumpli", "viz" } ),
                new Etel("rantotthus", new string[] { "hus", "krumpli" } ),
                new Etel("fozelek", new string[] { "viz", "repa" } )
            };
        }
        public event RendelesTeljesitesKezelo RendelesTeljesitve;
        public event RendelesTeljesitesKezelo RendelesNemTeljesitheto;
        public event HozzavaloSzuksegesKezelo HozzavaloSzukseges; //ha nincs egy adott hozzávaló
        public void Megrendeles(string etelNeve)
        {
            Console.WriteLine($"Séf: Rendelés beérkezett '{etelNeve}'");
            //receptek tömbben a megnevezes adattag egyenlő-e valanol az etelNeve paraméterrel, amit megrendeltünk
            if (receptek.Any(item=> item.megnevezes==etelNeve))
            {
                //receptek.ToList().Find(item=> item.megnevezes==etelNeve) --> visszaadja azt Etel
                //típusú objektumot, ami a megrendelt étel.

                Elkeszites(receptek.ToList().Find(item=> item.megnevezes==etelNeve));
            }
            else if (RendelesNemTeljesitheto != null) ////Volt- e feliratkozás az eseményre
            {  
                RendelesNemTeljesitheto(etelNeve);
            }


        }
        void Elkeszites(Etel recept)
        {
            cel = recept;
            szuksegesHozzavaloSzam = cel.hozzavalok.Length;


            for (int i = 0; i < cel.hozzavalok.Length; i++)
            {
                //feliratkoztunk-e valahol a HozzavaloSzukseges eseményre, mert a recepthez nincs meg minden
                if (HozzavaloSzukseges != null) 
                {
                    HozzavaloSzukseges(cel.hozzavalok[i]); //bekövetkezett az esemény, hívom a feliratkozott metódust (SefKerValamit), átadom a cel.hozzavalok[i]-t, mint hozzávalót
                }
            }

        }
        void SzakacsElkeszult(string hozzavalo)//– ez a metódus fog majd meghívódni akkor, ha elkészült valamelyik szakács valamelyik hozzávalóval
        {
            Console.WriteLine($"Séf: Elkészül a '{hozzavalo}'");
            szuksegesHozzavaloSzam--;

            //csak teszt miatt kell
            if (szuksegesHozzavaloSzam == 0 && RendelesTeljesitve != null)// RendelesTeljesitve != null-- > feliratkoztunk - e az eseményre
            { 
                           
                RendelesTeljesitve(cel.megnevezes); //a delegate az étel nevét várja paraméterként
            }
           
        }
        public void Felvesz(Szakacs szakacs) //felvesz egy szakácsot a séf mellé
        {
            //feliratkozás az eseménykezelőre += ; Leiratkozás -=
            HozzavaloSzukseges += szakacs.SefKerValamit; //ilyenkor nem kell átadni paraméter, mert csak jelezzük, hogy az esemény bekövekezésekor (hívás) melyik metódust hajtsa végre
            szakacs.HozzavaloElkeszult += SzakacsElkeszult;
        }
    }
}
