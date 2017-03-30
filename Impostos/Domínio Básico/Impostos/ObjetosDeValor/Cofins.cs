using System;

namespace ContextoDeImpostos.Impostos
{
    /// <summary>
    /// Definição de imposto de Contribuição para o Financiamento da Seguridade Social.
    /// </summary>
    internal class Cofins : ICofins
    {
        private decimal _valorApurado;
        private readonly decimal _valorBase;
        private const decimal _aliquota = 0.076m;

        /// <summary>
        /// Cria uma nova instância de COFINS.
        /// </summary>
        internal Cofins()
            : this(0m)
        {

        }

        /// <summary>
        /// Cria uma nova instância de COFINS.
        /// </summary>
        /// <param name="valorBase">Valor base para cálculo de COFINS.</param>
        private Cofins(decimal valorBase)
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

        /// <summary>
        /// Cria o objeto responsável por calcular o COFINS.
        /// </summary>
        /// <param name="valorBase">Valor base para cálculo de COFINS.</param>
        /// <returns>Objeto de valor com o cálculo do COFINS.</returns>
        public ICofins ObterCofins(decimal valorBase)
        {
            return new Cofins(valorBase);
        }

        public override string ToString()
        {
            return "COFINS - Imposto de Contribuição para o Financiamento da Seguridade Social.";
        }
    }
}
