using lukkristi_zadaca_1.Entiteti;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace lukkristi_zadaca_1.FactroyMethod
{
    public abstract class EntitetiCreator
    {
        public List<Entitet> Entiteti { get; private set; } = new List<Entitet>();
        public virtual void UcitajEntitete(string putanja)
        {
            if (!File.Exists(putanja))
            {
                Console.WriteLine("Datoteka ne postoji!");
                return;
            }
            string[] datoteka = File.ReadAllLines(putanja).Skip(1).ToArray();
            Entiteti = ObradiPodatke(datoteka);
        }
        protected abstract List<Entitet> ObradiPodatke(string[] datoteka);
    }

}

