using ContextoDeCalculoFinanceiro.Capitalizacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextoDeCalculoFinanceiro.Fabricas
{
    public class FabricaDeCalculos
    {
        public CalculoLinear CriarCalculoComCorrecaoLinear(decimal valorPresente, decimal taxaDeJuros, int diasDeApropriacao, Periodicidade periodicidade)
        {
            var periodoDeCapitalizacao = new PeriodoDeCapitalizacao(diasDeApropriacao, periodicidade);
            var capitalizacaoComposta = new CapitalizacaoComposta(taxaDeJuros, periodoDeCapitalizacao.PeriodosInteiros);
            var capitalizacaoSimples = new CapitalizacaoSimples(taxaDeJuros, periodoDeCapitalizacao.PeriodoFracionario);

            return new CalculoLinear(valorPresente, capitalizacaoComposta, capitalizacaoSimples);
        }

        public CalculoExponencial CriarCalculoComCorrecaoExponencial(decimal valorPresente, decimal taxaDeJuros, int diasDeApropriacao, Periodicidade periodicidade)
        {
            var periodoDeCapitalizacao = new PeriodoDeCapitalizacao(diasDeApropriacao, periodicidade);
            var capitalizacaoComposta = new CapitalizacaoComposta(taxaDeJuros, periodoDeCapitalizacao.PeriodoTotal);

            return new CalculoExponencial(valorPresente, capitalizacaoComposta);
        }
    }
}
