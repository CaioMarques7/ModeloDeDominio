using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextoDeCalculoFinanceiro.Capitalizacao
{
    struct CapitalizacaoComposta
    {
        private readonly decimal _taxa;
        private readonly double _periodoDeCapitalizacao;

        public CapitalizacaoComposta(decimal taxaDeJuros, double periodoDeCapitalizacao)
        {
            _taxa = taxaDeJuros;
            _periodoDeCapitalizacao = periodoDeCapitalizacao;
        }

        public decimal ObterFatorDeCorrecao()
        {
            return Convert.ToDecimal(Math.Pow(PercentualDeCapitalizacao(), _periodoDeCapitalizacao));
        }

        #region Operadores

        public static decimal operator *(CapitalizacaoComposta capitalizacaoComposta, CapitalizacaoSimples capitalizacaoSimples)
        {
            return capitalizacaoComposta.ObterFatorDeCorrecao() * capitalizacaoSimples.ObterFatorDeCorrecao();
        }

        public static decimal operator *(CapitalizacaoComposta capitalizacaoComposta, decimal valor)
        {
            return capitalizacaoComposta.ObterFatorDeCorrecao() * valor;
        }

        public static decimal operator *(decimal valor, CapitalizacaoComposta capitalizacaoComposta)
        {
            return capitalizacaoComposta * valor;
        }

        #endregion

        private double PercentualDeCapitalizacao()
        {
            return Convert.ToDouble(1m + _taxa / 100m);
        }
    }
}
