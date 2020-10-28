using lukkristi_zadaca_1.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace lukkristi_zadaca_1.FactroyMethod
{
    public class VozilaConcreteCreator : EntitetiCreator
    {
        protected override List<Entitet> ObradiPodatke(string[] datoteka)
        {
            List<Entitet> vozila = new List<Entitet>();
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
                            ID = int.Parse(stupci[0]),
                            Naziv = stupci[1].TrimStart(),
                            VrijemePunjenjaBaterije= int.Parse(stupci[2]),
                            Domet= int.Parse(stupci[3]),
                            PostotakBaterije=100
                        };
                        vozila.Add(vozilo);
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
            return vozila;
        }
    }
}
