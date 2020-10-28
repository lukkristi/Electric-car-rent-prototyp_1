using lukkristi_zadaca_1.AbstractFactory;
using lukkristi_zadaca_1.Entiteti;
using lukkristi_zadaca_1.FactroyMethod;
using System;
using System.Collections.Generic;
using System.Linq;

namespace lukkristi_zadaca_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //if (args.Length != 10)
            //{
            //    Console.WriteLine("Pogrešan broj parametra!");
            //    return;
            //}

            Dictionary<string, string> datoteke = Parametri.DohvatiPutanjeDatoteka(args);
            Tvrtka tvrtka = Tvrtka.GetInstanca();

            UcitajPodatke(datoteke, tvrtka, out List<Vozilo> vozila, out List<Lokacija> lokacije, out List<Osoba> osobe,
                out List<Cjenik> cjenici, out List<Kapacitet_lokacije> kapacitetiLokacija, out List<Aktivnost> aktivnosti);


            //ConcreteFactoryProgram concreteFactoryProgram = new ConcreteFactoryProgram();
            //var inter = concreteFactoryProgram.PokreniInteraktivniProgram();
            //inter.PokreniProgram(tvrtka, vozila);
            IspisiIzbornik(tvrtka, vozila, lokacije, osobe, cjenici, kapacitetiLokacija, aktivnosti);


        }

        private static void UcitajPodatke(Dictionary<string, string> datoteke, Tvrtka tvrtka, out List<Vozilo> vozila, out List<Lokacija> lokacije, out List<Osoba> osobe,
            out List<Cjenik> cjenici, out List<Kapacitet_lokacije> kapacitetiLokacija, out List<Aktivnost> aktivnosti)
        {
            EntitetiCreator entitetiCreator = new VozilaConcreteCreator();
            entitetiCreator.UcitajEntitete(datoteke["-v"]);
            vozila = entitetiCreator.Entiteti.Cast<Vozilo>().ToList();

            entitetiCreator = new LokacijeConcreteCreator();
            entitetiCreator.UcitajEntitete(datoteke["-l"]);
            lokacije = entitetiCreator.Entiteti.Cast<Lokacija>().ToList();
            entitetiCreator = new OsobeConcreteCreator();
            entitetiCreator.UcitajEntitete(datoteke["-o"]);
            osobe = entitetiCreator.Entiteti.Cast<Osoba>().ToList();

            entitetiCreator = new KapacitetiLokacijaConcreteCreator();
            entitetiCreator.UcitajEntitete(datoteke["-k"]);
            kapacitetiLokacija = entitetiCreator.Entiteti.Cast<Kapacitet_lokacije>().ToList();
            entitetiCreator = new CjenikConcreteCreator();
            entitetiCreator.UcitajEntitete(datoteke["-c"]);
            cjenici = entitetiCreator.Entiteti.Cast<Cjenik>().ToList();

            if (datoteke.ContainsKey("-s"))
            {
                entitetiCreator = new AktivnostiConcreteCreator();
                entitetiCreator.UcitajEntitete(datoteke["-s"]);
                aktivnosti = entitetiCreator.Entiteti.Cast<Aktivnost>().ToList();
            }
            else
            {
                aktivnosti = null;
            }


            String virtualnoVrijeme = datoteke["-t"];
            if (!tvrtka.ParsirajVirtualnoVrijeme(virtualnoVrijeme, out DateTime datum))
                Environment.Exit(0);
            tvrtka.TrenutnoVirtualnoVrijeme = datum;

        }

        private static void PregledRaspoloživihVozila(string[] stupci, List<Osoba> osobe, List<Vozilo> vozila, List<Lokacija> lokacije, Tvrtka tvrtka, List<Kapacitet_lokacije> kapaciteti_lokacija)
        {
            Osoba osoba;
            Vozilo vozilo;
            Lokacija lokacija;
            Kapacitet_lokacije kapacitet_Lokacije;
            PretragaPodataka(stupci, osobe, vozila, lokacije, tvrtka, kapaciteti_lokacija, out osoba, out vozilo, out lokacija, out kapacitet_Lokacije);
            Console.WriteLine("U " + tvrtka.ToString() + " korisnik " + osoba.ImePrezime + " traži  " + lokacija.Naziv + " " + kapacitet_Lokacije.RaspolozivBrojVozila + " raspolozivih vozila vrste " + vozilo.Naziv + "");            

        }
        private static void PregledRaspoloživihMjesta(string[] stupci, List<Osoba> osobe, List<Vozilo> vozila, List<Lokacija> lokacije, Tvrtka tvrtka, List<Kapacitet_lokacije> kapaciteti_lokacija)
        {
            Osoba osoba;
            Vozilo vozilo;
            Lokacija lokacija;
            Kapacitet_lokacije kapacitet_Lokacije;
            PretragaPodataka(stupci, osobe, vozila, lokacije, tvrtka, kapaciteti_lokacija, out osoba, out vozilo, out lokacija, out kapacitet_Lokacije);
            Console.WriteLine("U " + tvrtka.ToString() + " korisnik " + osoba.ImePrezime + " traži  " + lokacija.Naziv + " "  + kapacitet_Lokacije.ParkingMjesta + " raspolozivih mjesta za " + vozilo.Naziv);
           

        }
        private static void IznajmiVozilo(string[] stupci, List<Osoba> osobe, List<Vozilo> vozila, List<Lokacija> lokacije, Tvrtka tvrtka, List<Kapacitet_lokacije> kapaciteti_lokacija)
        {
            Osoba osoba;
            Vozilo vozilo;
            Lokacija lokacija;
            Kapacitet_lokacije kapacitet_Lokacije;
            PretragaPodataka(stupci, osobe, vozila, lokacije, tvrtka, kapaciteti_lokacija, out osoba, out vozilo, out lokacija, out kapacitet_Lokacije);
            if(ProvjeriNajam(osoba, kapacitet_Lokacije))
            {
                Osoba nova = osoba;
                osobe.Remove(osoba);
                nova.IznajmioVozilo = true;
                Kapacitet_lokacije kapacitet_ = kapacitet_Lokacije;
                kapaciteti_lokacija.Remove(kapacitet_);
                kapacitet_Lokacije.RaspolozivBrojVozila--;
                kapaciteti_lokacija.Add(kapacitet_Lokacije);
                Console.WriteLine("U " + tvrtka.ToString() + " korisnik " + osoba.ImePrezime + " traži  " + lokacija.Naziv  +" trazi najam " + vozilo.Naziv);
            }
            return;
        }
        private static bool ProvjeriNajam(Osoba osoba, Kapacitet_lokacije kapacitet_Lokacije)
        {
            if (!osoba.IznajmioVozilo)
            {
                if(kapacitet_Lokacije.RaspolozivBrojVozila!=0)
                    return true;
                Console.WriteLine(" nema raspolozivih vozila ! ");
                return false;
            }
            Console.WriteLine(osoba.ImePrezime + " ima iznamljeno vozilo vec! ");
            return false;
        }

        private static void PretragaPodataka(string[] stupci, List<Osoba> osobe, List<Vozilo> vozila, List<Lokacija> lokacije, Tvrtka tvrtka, List<Kapacitet_lokacije> kapaciteti_lokacija, out Osoba osoba, out Vozilo vozilo, out Lokacija lokacija, out Kapacitet_lokacije kapacitet_Lokacije)
        {
            int idVozila = int.Parse(stupci[4]);
            int idLokacije = int.Parse(stupci[3]);
            int idKorisnika = int.Parse(stupci[2]);
            osoba = osobe.Find(x => x.ID == idKorisnika);
            vozilo = vozila.Find(x => x.ID == idVozila);
            lokacija = lokacije.Find(x => x.ID == idLokacije);
            kapacitet_Lokacije = kapaciteti_lokacija.Find(x => x.Lokacija.ID == idLokacije && x.Vozilo.ID == idVozila);
            tvrtka.ParsirajVirtualnoVrijeme(stupci[1], out DateTime datum);
            tvrtka.AžurirajVirtualnoVrijeme(datum);
        }

        private static void IspisiIzbornik(Tvrtka tvrtka, List<Vozilo> vozila, List<Lokacija> lokacije, List<Osoba> osobe, List<Cjenik> cjenici, List<Kapacitet_lokacije> kapacitetiLokacija, List<Aktivnost> aktivnosti)
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
                
                string[] stupci = akcija.Split(";");
                if (ProvjeriUnosAktivnosti(akcija))
                {
                    switch (stupci[0])
                    {
                        case "1":
                            PregledRaspoloživihVozila(stupci, osobe, vozila, lokacije, tvrtka, kapacitetiLokacija);
                            
                            break;
                        case "2":
                            IznajmiVozilo(stupci, osobe, vozila, lokacije, tvrtka, kapacitetiLokacija);
                            break;
                        case "3":
                            
                            PregledRaspoloživihMjesta(stupci, osobe, vozila, lokacije, tvrtka, kapacitetiLokacija);
                            break;
                        case "4":
                            
                            break;
                        case "0":
                            return;
                        default:
                            Console.WriteLine("Neispravna naredba.");
                            break;
                    }
                }
            }
        }
        private static bool ProvjeriUnosAktivnosti(String aktivnost)
        {
            string[] stupci = aktivnost.Split(";");
            //TODO: provjera stupaca, je li podatak null
            if (stupci.Length == 2 || stupci.Length==6 || stupci.Length == 5)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Neispravana aktivnost  {0}", aktivnost);
                return false;
            }
        }

        
    }
}
