using DominioGenerico;
using System;

namespace ContextoDeImpostos.Impostos
{
    /// <summary>
    /// Definição de imposto de Contribuição para o Financiamento da Seguridade Social.
    /// </summary>
    internal sealed class Cofins : IObjetoDeValor, ICofins
    {
        private decimal _valorApurado;
        private readonly decimal _valorBase;
        private const decimal _aliquota = 0.076m;

        #region Construtores

        /// <summary>
        /// Cria uma nova instância de <see cref="Cofins"/>.
        /// </summary>
        internal Cofins()
            : this(0m)
        {

        }

        /// <summary>
        /// Cria uma nova instância de <see cref="Cofins"/>.
        /// </summary>
        /// <param name="valorBase">Valor base para cálculo de COFINS.</param>
        private Cofins(decimal valorBase)
        {
            _valorApurado = 0m;
            _valorBase = valorBase;
        }

        #endregion

        #region Membros de IImposto

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

        #endregion

        #region Membros de ICofins

        /// <summary>
        /// Cria o objeto responsável por calcular o COFINS.
        /// </summary>
        /// <param name="valorBase">Valor base para cálculo de COFINS.</param>
        /// <returns>Objeto de valor com o cálculo do COFINS.</returns>
        public ICofins ObterCofins(decimal valorBase)
        {
            return new Cofins(valorBase);
        }

        #endregion

        #region Membros de IObjetoDeValor

        public bool Equals(IObjetoDeValor other)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Membros de Object

        public override sealed bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override sealed int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override sealed string ToString()
        {
            return "COFINS - Imposto de Contribuição para o Financiamento da Seguridade Social.";
        }

        #endregion
    }
}
