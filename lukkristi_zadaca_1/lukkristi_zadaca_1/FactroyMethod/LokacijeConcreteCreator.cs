using lukkristi_zadaca_1.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace lukkristi_zadaca_1.FactroyMethod
{
    public class LokacijeConcreteCreator : EntitetiCreator
    {
        protected override List<Entitet> ObradiPodatke(string[] datoteka)
        {
            List<Entitet> lokacije = new List<Entitet>();
            foreach (var red in datoteka)
            {
                try
                {
                    string[] stupci = red.Split(";");
                    //TODO: provjera stupaca, je li podatak null
                    if (stupci.Length == 4)
                    {
                        Lokacija lokacija = new Lokacija
                        {
                            ID = int.Parse(stupci[0]),
                            Naziv = stupci[1].TrimStart(),
                            Adresa = stupci[2].TrimStart(),
                            GPS = stupci[3]
                        };
                        lokacije.Add(lokacija);
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
            return lokacije;
        }
    }
}
