using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextoDeCalculoFinanceiro.Fabricas
{
    public interface IFabricaDeCalculosFinanceiros
    {
        ICalculoFinanceiro CriarCalculoComCorrecaoLinear(decimal valorPresente, decimal taxaDeJuros, int diasDeApropriacao, Periodicidade periodicidade);

        ICalculoFinanceiro CriarCalculoComCorrecaoExponencial(decimal valorPresente, decimal taxaDeJuros, int diasDeApropriacao, Periodicidade periodicidade);
    }
}
