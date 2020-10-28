using lukkristi_zadaca_1.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace lukkristi_zadaca_1
{
    public class Kapacitet_lokacije : Entitet
    {
        public Lokacija Lokacija { get; set; } = new Lokacija();
        public Vozilo Vozilo { get; set; } = new Vozilo();
        public int ParkingMjesta { get; set; }
        public int RaspolozivBrojVozila { get; set; }

        public Kapacitet_lokacije(int parkingMjesta, int raspolozivBrojVozila)
        {
            ParkingMjesta = parkingMjesta;
            RaspolozivBrojVozila = raspolozivBrojVozila;
        }
    }
}
