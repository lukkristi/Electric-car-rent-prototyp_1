using lukkristi_zadaca_1.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace lukkristi_zadaca_1.FactroyMethod
{
    public class KapacitetiLokacijaConcreteCreator : EntitetiCreator
    {
        protected override List<Entitet> ObradiPodatke(string[] datoteka)
        {
            List<Entitet> kapacitetiLokacija = new List<Entitet>();
            foreach (var red in datoteka)
            {
                try
                {
                    string[] stupci = red.Split(";");
                    //TODO: provjera stupaca, je li podatak null
                    if (stupci.Length == 4)
                    {
                        Vozilo vozilo = new Vozilo
                        {
                            ID = int.Parse(stupci[1]),                           
                        };
                        Lokacija lokacija = new Lokacija
                        {
                            ID = int.Parse(stupci[0])
                        };
                        Kapacitet_lokacije kapacitet_Lokacije = new Kapacitet_lokacije(int.Parse(stupci[2]), int.Parse(stupci[3]));
                        kapacitet_Lokacije.Vozilo = vozilo;
                        kapacitet_Lokacije.Lokacija = lokacija;
                        kapacitetiLokacija.Add(kapacitet_Lokacije);
                    }
                    else
                    {
                        Console.WriteLine("Neispravan red u datoteci: {0}", red);
                    }
                }
                catch
                {
                    Console.WriteLine("Neispravan red u datoteci: {0}", red);
                }
            }
            return kapacitetiLokacija;
        }
    }
}
