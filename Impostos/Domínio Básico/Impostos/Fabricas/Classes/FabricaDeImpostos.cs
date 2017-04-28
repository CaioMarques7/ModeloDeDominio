using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContextoDeImpostos;
using ContextoDeImpostos.Impostos;

namespace ContextoDeImpostos.Fabricas
{
    internal class FabricaDeImpostos : IFabricaDeImpostos
    {
        public IFabricaDeImpostos CriarImposto<T>(ICollection<IImposto> colecaoDeImpostos) where T : IImposto, new()
        {
            colecaoDeImpostos.Add(new T());

            return this;
        }
    }
}
