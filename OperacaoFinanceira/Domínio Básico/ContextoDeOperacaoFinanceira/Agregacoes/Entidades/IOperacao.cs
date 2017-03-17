using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextoDeOperacaoFinanceira.Agregacoes.Entidades
{
    /// <summary>
    /// Definição de operação financeira.
    /// </summary>
    public interface IOperacao
    {
        /// <summary>
        /// Tipo de operação.
        /// </summary>
        TipoDeOperacaoFinanceira TipoDeOperacao { get; }

        /// <summary>
        /// Data da operação.
        /// </summary>
        DateTime DataDaOperacao { get; }

        /// <summary>
        /// Taxa de IOF.
        /// </summary>
        decimal TaxaDeIof { get; }

        /// <summary>
        /// Coleção de parcelas da operação.
        /// </summary>
        ICollection<IParcela> Parcelas{ get; }

        /// <summary>
        /// Inclui uma nova parcela na operação.
        /// </summary>
        /// <param name="valorDaParcela">Valor da parcela.</param>
        /// <param name="dataDeVencimento">Data de vencimento da parcela.</param>
        void IncluirParcela(decimal valorDaParcela, DateTime dataDeVencimento);

        /// <summary>
        /// Calcula os impostos que incidem sobre a operação.
        /// </summary>
        void CalcularImpostos();
    }
}
