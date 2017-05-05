using ContextoDeCalculoFinanceiro.Capitalizacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextoDeCalculoFinanceiro
{
    internal struct CalculoExponencial : ICalculoFinanceiro
    {
        private readonly decimal _valorPresente;
        private readonly CapitalizacaoComposta _capitalizacaoComposta;

        internal CalculoExponencial(decimal valorPresente, CapitalizacaoComposta capitalizacaoComposta)
        {
            _valorPresente = valorPresente;
            _capitalizacaoComposta = capitalizacaoComposta;
        }

        public decimal ValorCalculado()
        {
            return Math.Round(_valorPresente * _capitalizacaoComposta, 2);
        }
    }
}
