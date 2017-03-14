using System;

namespace Impostos
{
    /// <summary>
    /// Definição de imposto de Contribuição para o Financiamento da Seguridade Social.
    /// </summary>
    public struct Cofins : IImposto<Cofins>
    {
        private readonly decimal _valorBase;
        private const decimal _aliquota = 0.076m;

        /// <summary>
        /// Cria uma nova instância de COFINS.
        /// </summary>
        /// <param name="valorBase">Valor base para cálculo de COFINS.</param>
        public Cofins(decimal valorBase)
        {
            _valorBase = valorBase;
        }

        /// <summary>
        /// Calcula o valor de imposto a ser cobrado.
        /// </summary>
        /// <returns>Valor de imposto a ser cobrado.</returns>
        public decimal CalcularValorDeImposto()
        {
            return Math.Round(_valorBase * _aliquota, 2);
        }
    }
}
