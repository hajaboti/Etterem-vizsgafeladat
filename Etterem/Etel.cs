using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etterem
{
    class Etel
    {
        public string megnevezes{ get; private set; } //csak olvasható kívülről
        public string[] hozzavalok { get; private set; }
        public Etel(string megnevezes, string[] hozzavalok)
        {
            this.megnevezes = megnevezes;
            this.hozzavalok = hozzavalok;
        }
    }
}
