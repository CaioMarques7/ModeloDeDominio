using System;

namespace ContextoDeImpostos.Impostos
{
    /// <summary>
    /// Definição do imposto de Programas de Integração Social e de Formação do Patrimônio do Servidor Público.
    /// </summary>
    internal class Pis : IPis
    {
        private decimal _valorApurado;
        private readonly decimal _valorBase;
        private const decimal _aliquota = 0.0165m;

        /// <summary>
        /// Cria uma nova instância de PIS.
        /// </summary>
        internal Pis()
            : this(0m)
        {

        }

        /// <summary>
        /// Cria uma nova instância de PIS.
        /// </summary>
        /// <param name="valorBase">Valor base para cálculo de PIS.</param>
        private Pis(decimal valorBase)
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
        public void CalcularValorDeImposto()
        {
            _valorApurado = Math.Round(_valorBase * _aliquota, 2);
        }

        /// <summary>
        /// Cria o objeto responsável por calcular o PIS.
        /// </summary>
        /// <param name="valorBase">Valor base para cálculo de PIS.</param>
        /// <returns>Objeto de valor com o cálculo do PIS.</returns>
        public IPis ObterPis(decimal valorBase)
        {
            return new Pis(valorBase);
        }

        public override string ToString()
        {
            return "PIS - Imposto de Programas de Integração Social e de Formação do Patrimônio do Servidor Público.";
        }
    }
}
