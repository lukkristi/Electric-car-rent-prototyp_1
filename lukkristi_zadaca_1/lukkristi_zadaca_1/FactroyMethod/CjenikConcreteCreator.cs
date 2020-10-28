using lukkristi_zadaca_1.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace lukkristi_zadaca_1.FactroyMethod
{
    public class CjenikConcreteCreator : EntitetiCreator
    {
        protected override List<Entitet> ObradiPodatke(string[] datoteka)
        {
            List<Entitet> popisCjenika = new List<Entitet>();
            foreach (var red in datoteka)
            {
                try
                {
                    string[] stupci = red.Split(";");
                    //TODO: provjera stupaca, je li podatak null
                    if (stupci.Length == 4)
                    {
                        Vozilo voz = new Vozilo
                        {
                            ID = int.Parse(stupci[0])
                        };
                        Cjenik cjenik = new Cjenik(voz, int.Parse(stupci[1]), int.Parse(stupci[2]), int.Parse(stupci[3]));                      
                        popisCjenika.Add(cjenik);
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
            return popisCjenika;
        }
    }
}
