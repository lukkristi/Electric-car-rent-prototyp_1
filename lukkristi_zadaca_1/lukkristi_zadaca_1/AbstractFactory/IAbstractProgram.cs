using System;
using System.Collections.Generic;
using System.Text;

namespace lukkristi_zadaca_1.AbstractFactory
{
    public interface IAbstractProgram
    {
        IAbstractVrstaPrograma PokreniInteraktivniProgram();
        IAbstractVrstaPrograma PokreniSkupniProgram();
    }
}
