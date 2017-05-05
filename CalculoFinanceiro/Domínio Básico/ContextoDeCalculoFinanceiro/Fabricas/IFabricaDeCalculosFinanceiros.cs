using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextoDeCalculoFinanceiro.Fabricas
{
    public interface IFabricaDeCalculosFinanceiros
    {
        CalculoLinear CriarCalculoComCorrecaoLinear(decimal valorPresente, decimal taxaDeJuros, int diasDeApropriacao, Periodicidade periodicidade);

        CalculoExponencial CriarCalculoComCorrecaoExponencial(decimal valorPresente, decimal taxaDeJuros, int diasDeApropriacao, Periodicidade periodicidade);
    }
}
