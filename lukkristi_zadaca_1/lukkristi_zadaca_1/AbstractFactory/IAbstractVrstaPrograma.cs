using lukkristi_zadaca_1.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace lukkristi_zadaca_1.AbstractFactory
{
    public interface IAbstractVrstaPrograma
    {
        void PokreniProgram(Tvrtka tvrtka, List<Vozilo> vozila);
    }
}
