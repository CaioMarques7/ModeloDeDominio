using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContextoDeImpostos;

namespace ContextoDeOperacaoFinanceira.Agregacoes.Entidades
{
    /// <summary>
    /// Classe de definição de parcela de operação financeira.
    /// </summary>
    internal class Parcela : IParcela
    {
        private readonly IOperacao _operacao;

        /// <summary>
        /// Cria uma nova instância de parcela.
        /// </summary>
        /// <param name="operacao">Operação a qual a parcela está vinculada.</param>
        /// <param name="valorDaParcela">Valor da parcela.</param>
        public Parcela(IOperacao operacao, decimal valorDaParcela)
        {
            _operacao = operacao;
            Valor = valorDaParcela;
        }
        
        /// <summary>
        /// Valor da Parcela.
        /// </summary>
        public decimal Valor { get; }

        /// <summary>
        /// Coleção de impostos que incidem sobre a parcela.
        /// </summary>
        public ICollection<IImposto> ImpostosIncidentes { get; }
    }
}
