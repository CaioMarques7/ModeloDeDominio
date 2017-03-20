using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContextoDeImpostos;
using ContextoDeImpostos.Impostos;

namespace Impostos.Fabricas
{
    internal class FabricaDeImpostos : IFabricaDeImpostos
    {
        public T CriarImposto<T>() where T : IImposto
        {
            if (typeof(T) == typeof(IIof))
                return (T)Teste1();

            if (typeof(T) == typeof(IPis))
                return (T)Teste2();

            if (typeof(T) == typeof(ICofins))
                return (T)Teste3();

            throw new ArgumentException();
        }

        private IIof Teste1()
        {
            return new Iof();
        }

        private IPis Teste2()
        {
            return new Pis();
        }

        private ICofins Teste3()
        {
            return new Cofins();
        }
    }
}
