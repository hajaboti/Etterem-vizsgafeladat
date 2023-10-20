using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etterem
{
    public delegate void RendelesTeljesitesKezelo(string etelNeve);
    public delegate void HozzavaloSzuksegesKezelo(string hozzavalo);
    public delegate void HozzavaloElkeszultKezelo(string hozzavalo);
    class Program
    {
        //A sikerült és nem sikerült metódusok visszatérési érték típusa, és bemenő paramétereinek száma, típusa
        //meg kell egyezzen a RendelesTeljesitesKezelo delegate -al, hiszen az esemény amire feliratkozunk ilyen típusú
        static void nemsikerult(string EtelNeve)
        {
            Console.WriteLine($"* Sikertelen rendelés '{EtelNeve}'"); //csak a teszt miatt
        }
        static void sikerult(string EtelNeve)
        {
            Console.WriteLine($"* Sikeres rendelés '{EtelNeve}'");
        }
        static void Main(string[] args)
        {
            Sef sef = new Sef();
            sef.RendelesNemTeljesitheto += nemsikerult; //feliratkozás
            sef.RendelesTeljesitve += sikerult;

            Szakacs Bela = new Szakacs("Bela", "viz");
            Szakacs Jozsi = new Szakacs("Jozsi", "repa");
            sef.Felvesz(Bela);
            sef.Felvesz(Jozsi);
            //sef.Megrendeles("poharviz");
            sef.Megrendeles("fozelek");
            Console.ReadKey();
        }
    }
}
