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
        T CriarImposto<T>() where T : IImposto;
    }
}
