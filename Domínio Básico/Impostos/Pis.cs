using System;

namespace Impostos
{
    /// <summary>
    /// Definição do imposto de Programas de Integração Social e de Formação do Patrimônio do Servidor Público.
    /// </summary>
    public struct Pis : IImposto<Pis>
    {
        private readonly decimal _valorBase;
        private const decimal _aliquota = 0.0165m;

        /// <summary>
        /// Cria uma nova instância de PIS.
        /// </summary>
        /// <param name="valorBase">Valor base para cálculo de PIS.</param>
        public Pis(decimal valorBase)
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
