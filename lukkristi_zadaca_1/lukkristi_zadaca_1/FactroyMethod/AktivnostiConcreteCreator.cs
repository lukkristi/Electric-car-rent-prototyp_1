using lukkristi_zadaca_1.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace lukkristi_zadaca_1.FactroyMethod
{
    public class AktivnostiConcreteCreator : EntitetiCreator
    {
        protected override List<Entitet> ObradiPodatke(string[] datoteka)
        {
            List<Entitet> Aktivnosti = new List<Entitet>();
            foreach (var red in datoteka)
            {
                try
                {
                    string[] stupci = red.Split(";");
                    //TODO: provjera stupaca, je li podatak null
                    if (stupci.Length >= 2 && stupci.Length<=6)
                    {
                        Aktivnost aktivnost = new Aktivnost()
                        {
                            ID = int.Parse(stupci[0]),
                            Vrijeme = stupci[1]
                            
                        };
                        if (stupci.Length >= 5) {
                            aktivnost.IDOsoba = int.Parse(stupci[2]);
                            aktivnost.IDLokacija = int.Parse(stupci[3]);
                            aktivnost.IDVozilo = int.Parse(stupci[4]);
                            if (stupci.Length == 6)
                                aktivnost.BrojKm = int.Parse(stupci[5]);
                        }
                        Aktivnosti.Add(aktivnost);


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
            return Aktivnosti;
        }
    }
}
