using lukkristi_zadaca_1.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace lukkristi_zadaca_1.FactroyMethod
{
    public class OsobeConcreteCreator : EntitetiCreator
    {
        protected override List<Entitet> ObradiPodatke(string[] datoteka)
        {
            List<Entitet> osobe = new List<Entitet>();
            foreach (var red in datoteka)
            {
                string[] stupci = red.Split(";");
                if (stupci[0] == "" || stupci[1] == "")
                    continue;
                Osoba osoba = new Osoba
                {
                    ID = int.Parse(stupci[0]),
                    ImePrezime = stupci[1].TrimStart()
                };
                osobe.Add(osoba);
            }
            return osobe;
        }
    }
}
