using lukkristi_zadaca_1.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace lukkristi_zadaca_1
{
    public class Lokacija : Entitet
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string GPS { get; set; }

        public Lokacija(int iD, string naziv, string adresa, string gps)
        {
            ID = iD;
            Naziv = naziv;
            Adresa = adresa;
            GPS = gps;
        }

        public Lokacija()
        {
        }
    }
}
