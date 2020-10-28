using lukkristi_zadaca_1.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace lukkristi_zadaca_1
{
    public class Osoba : Entitet
    {
        public int ID { get; set; }
        public string ImePrezime { get; set; }
        public Boolean IznajmioVozilo { get; set; }

        public Osoba(int iD, string imePrezime)
        {
            ID = iD;
            ImePrezime = imePrezime;
            IznajmioVozilo = false;
        }

        public Osoba()
        {
        }
    }
}
