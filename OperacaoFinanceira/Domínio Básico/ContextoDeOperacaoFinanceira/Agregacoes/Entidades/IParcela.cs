using ContextoDeImpostos;
using DominioGenerico.Entidades;
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
    public interface IParcela : IEntidadeValidavel
    {
        /// <summary>
        /// Valor da Parcela.
        /// </summary>
        decimal Valor { get; }

        /// <summary>
        /// Valor de Juros.
        /// </summary>
        decimal ValorDeJuros { get; }

        /// <summary>
        /// Data de vencimento da parcela.
        /// </summary>
        DateTime DataDeVencimento { get; }

        /// <summary>
        /// Prazo da parcela.
        /// </summary>
        short Prazo { get; }

        /// <summary>
        /// Calcula os juros que incidem sobre a parcela.
        /// </summary>
        /// <returns>Parcela com juros calculados.</returns>
        IParcela CalcularJuros();

        /// <summary>
        /// Calcula os impostos que incidem sobre a parcela.
        /// </summary>
        /// <returns>Parcela com impostos calculados.</returns>
        IParcela CalcularImpostos();

        /// <summary>
        /// Retorna o valor apurado por imposto incidente na parcela.
        /// </summary>
        /// <typeparam name="TImposto">Imposto que será avaliado.</typeparam>
        /// <returns>Valor total de imposto apurado.</returns>
        decimal ValorApuradoPorImposto<TImposto>() where TImposto : IImposto;
    }
}
