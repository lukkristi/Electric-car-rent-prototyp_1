using lukkristi_zadaca_1.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace lukkristi_zadaca_1
{
    public class Cjenik : Entitet
    {
        public Vozilo Vozilo { get; set; } = new Vozilo();
        public int Najam { get; set; }
        public int PoSatu { get; set; }

        public int PoKm { get; set; }

        public Cjenik(Vozilo vozilo, int najam, int poSatu, int poKm)
        {
            Vozilo = vozilo;
            Najam = najam;
            PoSatu = poSatu;
            PoKm = poKm;
        }
    }
}
