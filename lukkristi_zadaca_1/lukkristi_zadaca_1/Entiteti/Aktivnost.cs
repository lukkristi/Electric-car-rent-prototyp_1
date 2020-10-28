using lukkristi_zadaca_1.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace lukkristi_zadaca_1
{
    public class Aktivnost : Entitet
    {
        public int ID { get; set; }
        public string Vrijeme { get; set; }
        public int IDOsoba { get; set; } 
        public int IDLokacija { get; set; } 
        public int IDVozilo { get; set; }
        public int BrojKm { get; set; }

        public Aktivnost(int iD, string vrijeme, int iDOsoba, int iDLokacija, int iDVozilo)
        {
            ID = iD;
            Vrijeme = vrijeme;
            IDOsoba = iDOsoba;
            IDLokacija = iDLokacija;
            IDVozilo = iDVozilo;          
        }
        public Aktivnost() { }
    }
}
