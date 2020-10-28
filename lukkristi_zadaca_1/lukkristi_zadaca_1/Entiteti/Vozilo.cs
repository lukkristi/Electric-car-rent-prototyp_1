using lukkristi_zadaca_1.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace lukkristi_zadaca_1
{
    public class Vozilo : Entitet
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public int VrijemePunjenjaBaterije { get; set; }
        public int Domet { get; set; }
        public int PrijedjeniKm { get; set; }
        public int PostotakBaterije { get; set; }



        public Vozilo(int iD, string naziv, int vrijemePunjenjaBaterije, int domet)
        {
            ID = iD;
            Naziv = naziv;
            VrijemePunjenjaBaterije = vrijemePunjenjaBaterije;
            Domet = domet;
            PrijedjeniKm = 0;
            PostotakBaterije = 100;
        }

        public Vozilo()
        {
        }
    }
}
