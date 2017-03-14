using System;

namespace ContextoDeImpostos.Impostos
{
    /// <summary>
    /// Definição de imposto de Contribuição para o Financiamento da Seguridade Social.
    /// </summary>
    public struct Cofins : IImposto<Cofins>
    {
        private decimal _valorApurado;
        private readonly decimal _valorBase;
        private const decimal _aliquota = 0.076m;

        /// <summary>
        /// Cria uma nova instância de COFINS.
        /// </summary>
        /// <param name="valorBase">Valor base para cálculo de COFINS.</param>
        public Cofins(decimal valorBase)
        {
            _valorApurado = 0m;
            _valorBase = valorBase;
        }

        /// <summary>
        /// Valor de imposto a ser cobrado.
        /// </summary>
        public decimal ValorApurado => _valorApurado;

        /// <summary>
        /// Calcula o valor de imposto a ser cobrado.
        /// </summary>
        /// <returns>Valor de imposto a ser cobrado.</returns>
        public void CalcularValorDeImposto()
        {
            _valorApurado = Math.Round(_valorBase * _aliquota, 2);
        }

        public override string ToString()
        {
            return "COFINS - Imposto de Contribuição para o Financiamento da Seguridade Social.";
        }
    }
}
