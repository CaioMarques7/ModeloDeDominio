using ContextoDeImpostos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impostos.Fabricas
{
    public interface IFabricaDeImpostos
    {
        IFabricaDeImpostos CriarImposto<T>(ICollection<IImposto> colecaoDeImpostos) where T : IImposto, new();
    }
}
