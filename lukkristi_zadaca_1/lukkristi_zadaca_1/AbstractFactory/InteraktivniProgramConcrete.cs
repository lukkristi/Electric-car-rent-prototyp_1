using lukkristi_zadaca_1.Entiteti;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace lukkristi_zadaca_1.AbstractFactory
{
    public class InteraktivniProgramConcrete : IAbstractVrstaPrograma
    {
        

        public void PokreniProgram(Tvrtka tvrtka, List<Vozilo> vozila)
        {
            IspisiIzbornik(vozila);
            tvrtka.ToString();
        }

        private  void IspisiIzbornik(List<Vozilo> vozila)
        {
            while (true)
            {              
                Console.WriteLine();
                Console.WriteLine("Akcije:");
                Console.WriteLine("\t1. Pregled raspoloživih vozila odabrane vrste na odabranoj lokaciji.");
                Console.WriteLine("\t2. Najam odabrane vrste vozila na odabranoj lokaciji ");
                Console.WriteLine("\t3. Pregled raspoloživih mjesta odabrane vrste vozila za odabranu lokaciju");
                Console.WriteLine("\t4. Vraćanje vozila na odabranu lokaciju uz unos ukupnog broj kilometara te ispis računa.");
                Console.WriteLine("\t0. Kraj programa ");
                string akcija = Console.ReadLine();
                ProvjeriUnosAktivnosti(akcija);
                string[] stupci = akcija.Split(";");
                switch (stupci[0])
                {
                    case "1":
                        Console.WriteLine("Odaberite program i dan (broj programa sa liste i broj dana u tjednu):");
                        //PregledRaspoloživihVozila(stupci,osobe,vozila,lokacije,tvrtka,kapaciteti_lokacija);
                        string odabraniDan = Console.ReadLine();                       
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Neispravna naredba.");
                        break;
                }
            }
        }

        private void ProvjeriUnosAktivnosti(String aktivnost)
        {
            string[] stupci = aktivnost.Split(";");
            //TODO: provjera stupaca, je li podatak null
            if (stupci.Length != 2 || stupci.Length != 6 || stupci.Length != 5)
            {
                Console.WriteLine("Neispravana aktivnost  {0}", aktivnost);
                return;
            }          
        }

        private void PregledRaspoloživihVozila(string[] stupci, List<Osoba> osobe, List<Vozilo> vozila, List<Lokacija> lokacije, Tvrtka tvrtka, List<Kapacitet_lokacije> kapaciteti_lokacija)
        {
            int idVozila = int.Parse(stupci[4]);
            int idLokacije = int.Parse(stupci[3]);
            int idKorisnika = int.Parse(stupci[2]);
            Osoba osoba = osobe.Find(x => x.ID == idKorisnika);
            Vozilo vozilo = vozila.Find(x => x.ID == idVozila);
            Lokacija lokacija = lokacije.Find(x => x.ID == idLokacije);
            Kapacitet_lokacije kapacitet_Lokacije = kapaciteti_lokacija.Find(x => x.Lokacija.ID == idLokacije && x.Vozilo.ID == idVozila);
            tvrtka.ParsirajVirtualnoVrijeme(stupci[1], out DateTime datum);
            tvrtka.AžurirajVirtualnoVrijeme(datum);
            Console.WriteLine("U " + tvrtka.ToString() + " korisnik " + osoba.ImePrezime + " traži  " + lokacija.Naziv + " " + vozilo.Naziv + " " + kapacitet_Lokacije.RaspolozivBrojVozila + " raspoloziv broj");
            //Emisija emisija = emisije.Find(x => x.Id == emisijaPrograma.Emisija.Id);

        }
    }
}
