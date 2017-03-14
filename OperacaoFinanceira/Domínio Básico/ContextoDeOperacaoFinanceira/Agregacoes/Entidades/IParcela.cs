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
        /// Coleção de impostos que incidem sobre a parcela.
        /// </summary>
        ICollection<IImposto> ImpostosIncidentes { get; }
    }
}
