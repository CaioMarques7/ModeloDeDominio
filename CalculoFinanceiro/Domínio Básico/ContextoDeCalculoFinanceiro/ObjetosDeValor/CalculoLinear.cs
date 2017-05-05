using ContextoDeCalculoFinanceiro.Capitalizacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextoDeCalculoFinanceiro
{
    internal struct CalculoLinear : ICalculoFinanceiro
    {
        private readonly decimal _valorPresente;
        private readonly CapitalizacaoComposta _capitalizacaoComposta;
        private readonly CapitalizacaoSimples _capitalizacaoSimples;

        internal CalculoLinear(decimal valorPresente, CapitalizacaoComposta capitalizacaoComposta, CapitalizacaoSimples capitalizacaoSimples)
        {
            _valorPresente = valorPresente;
            _capitalizacaoComposta = capitalizacaoComposta;
            _capitalizacaoSimples = capitalizacaoSimples;
        }

        public decimal ValorCalculado()
        {
            return Math.Round(_valorPresente * _capitalizacaoComposta * _capitalizacaoSimples, 2);
        }
    }
}
