using System;
using System.Collections.Generic;
using System.Text;

namespace lukkristi_zadaca_1.Entiteti
{
    public class Tvrtka : Entitet
    {
        private static Tvrtka _instanca;
        public DateTime TrenutnoVirtualnoVrijeme { get; set; }

        public static Tvrtka GetInstanca()
        {
            if (_instanca == null)
            {
                _instanca = new Tvrtka();

            }           
            return _instanca;
        }
        private Tvrtka() { }


        public void AžurirajVirtualnoVrijeme(DateTime novoVrijeme)
        {
            if (TrenutnoVirtualnoVrijeme < novoVrijeme)
            {
                TrenutnoVirtualnoVrijeme = novoVrijeme;
                
            }
            return;
        }

        public bool ParsirajVirtualnoVrijeme(string novoVrijeme, out DateTime datum)
        {
            string vrijeme = novoVrijeme.Trim('"');
            //vrijeme = vrijeme.Trim('\\');
            vrijeme = vrijeme.Replace("\"", "");
            if (DateTime.TryParseExact(vrijeme.TrimStart(), "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out datum))
            {

                //Console.WriteLine(outputDateTimeValue.ToString("yyyy-MM-dd HH:mm:ss"));
                return true;
            }
            else
            {
                Console.WriteLine("Neispravno vrijeme u komandi: {0}", vrijeme);
                return false;
            }

        }

        

        public override string ToString()
        {
            return TrenutnoVirtualnoVrijeme.ToString("„yyyy-MM-dd HH:mm:ss“");
        }
    }


}
