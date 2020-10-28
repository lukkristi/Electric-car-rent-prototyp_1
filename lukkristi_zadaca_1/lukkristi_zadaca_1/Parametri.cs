using System;
using System.Collections.Generic;
using System.Text;

namespace lukkristi_zadaca_1
{
    class Parametri
    {
        public static Dictionary<string, string> DohvatiPutanjeDatoteka(string[] korisnikoviArgumenti)
        {
            if (korisnikoviArgumenti.Length % 2 != 1)
            {
                Console.WriteLine("Neispravan broj argumenata!");
                Environment.Exit(0);
            }
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            for (int i = 0; i < korisnikoviArgumenti.Length; i += 2)
            {
                if (korisnikoviArgumenti[i] == "-t") {
                    String vrijeme = korisnikoviArgumenti[i + 1] +" " +korisnikoviArgumenti[i + 2];
                    vrijeme = vrijeme.Replace("„", "");
                    vrijeme = vrijeme.Replace("“", "");
                    dictionary.Add(korisnikoviArgumenti[i], vrijeme);
                    Console.WriteLine(vrijeme);
                    i++;
                    continue;
                }
                dictionary.Add(korisnikoviArgumenti[i], korisnikoviArgumenti[i + 1]);

            }
            return dictionary;
        }
    }
}
