using ContextoDeImpostos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextoDeOperacaoFinanceira.Agregacoes.Entidades
{
    /// <summary>
    /// Definição de parcela da operação.
    /// </summary>
    public interface IParcela
    {
        /// <summary>
        /// Valor da Parcela.
        /// </summary>
        decimal Valor { get; }

        /// <summary>
        /// Data de vencimento da parcela.
        /// </summary>
        DateTime DataDeVencimento { get; }

        /// <summary>
        /// Prazo da parcela.
        /// </summary>
        short Prazo { get; }

        /// <summary>
        /// Coleção de impostos que incidem sobre a parcela.
        /// </summary>
        IEnumerable<IImposto> ImpostosIncidentes { get; }

        /// <summary>
        /// Calcula os impostos que incidem sobre a parcela.
        /// </summary>
        void CalcularImpostos();
    }
}
