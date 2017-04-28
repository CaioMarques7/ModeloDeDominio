using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextoDeCalculoFinanceiro.Capitalizacao
{
    struct CapitalizacaoSimples
    {
        private readonly decimal _taxa, _periodoDeCapitalizacao;

        public CapitalizacaoSimples(decimal taxaDeJuros, decimal periodoDeCapitalizacao)
        {
            _taxa = taxaDeJuros;
            _periodoDeCapitalizacao = periodoDeCapitalizacao;
        }

        public decimal ObterFatorDeCorrecao()
        {
            return 1m + PercentualDeCapitalizacao();
        }

        #region Operadores

        public static decimal operator *(CapitalizacaoSimples capitalizacaoSimples, CapitalizacaoComposta capitalizacaoComposta)
        {
            return capitalizacaoSimples.ObterFatorDeCorrecao() * capitalizacaoComposta.ObterFatorDeCorrecao();
        }

        public static decimal operator *(CapitalizacaoSimples capitalizacaoSimples, decimal valor)
        {
            return capitalizacaoSimples.ObterFatorDeCorrecao() * valor;
        }

        public static decimal operator *(decimal valor, CapitalizacaoSimples capitalizacaoSimples)
        {
            return capitalizacaoSimples * valor;
        }

        #endregion

        private decimal PercentualDeCapitalizacao()
        {
            return (_taxa / 100m) * _periodoDeCapitalizacao;
        }
    }
}
