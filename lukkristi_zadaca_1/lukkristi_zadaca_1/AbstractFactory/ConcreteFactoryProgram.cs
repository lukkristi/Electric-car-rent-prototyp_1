using System;
using System.Collections.Generic;
using System.Text;

namespace lukkristi_zadaca_1.AbstractFactory
{
    class ConcreteFactoryProgram : IAbstractProgram
    {
        public IAbstractVrstaPrograma PokreniInteraktivniProgram()
        {
            return new InteraktivniProgramConcrete();
        }

        public IAbstractVrstaPrograma PokreniSkupniProgram()
        {
            return new SkupniProgramConcrete();
        }
    }
}
