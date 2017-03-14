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
        /// Coleção de parcelas da operação.
        /// </summary>
        ICollection<IParcela> Parcelas{ get; }

        /// <summary>
        /// Inclui uma nova parcela na operação.
        /// </summary>
        /// <param name="valorDaParcela">Valor da parcela.</param>
        void IncluirParcela(decimal valorDaParcela);
    }
}
