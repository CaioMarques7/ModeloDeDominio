using DominioGenerico;
using System;

namespace ContextoDeImpostos.Impostos
{
    /// <summary>
    /// Definição do imposto de Programas de Integração Social e de Formação do Patrimônio do Servidor Público.
    /// </summary>
    internal sealed class Pis : IObjetoDeValor, IPis
    {
        private decimal _valorApurado;
        private readonly decimal _valorBase;
        private const decimal _aliquota = 0.0165m;

        #region Construtores

        /// <summary>
        /// Cria uma nova instância de <see cref="Pis"/>.
        /// </summary>
        internal Pis()
            : this(0m)
        {

        }

        /// <summary>
        /// Cria uma nova instância de <see cref="Pis"/>.
        /// </summary>
        /// <param name="valorBase">Valor base para cálculo de PIS.</param>
        private Pis(decimal valorBase)
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
        public void CalcularValorDeImposto()
        {
            _valorApurado = Math.Round(_valorBase * _aliquota, 2);
        }

        #endregion

        #region Membros de IPis

        /// <summary>
        /// Cria o objeto responsável por calcular o PIS.
        /// </summary>
        /// <param name="valorBase">Valor base para cálculo de PIS.</param>
        /// <returns>Objeto de valor com o cálculo do PIS.</returns>
        public IPis ObterPis(decimal valorBase)
        {
            return new Pis(valorBase);
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
            return "PIS - Imposto de Programas de Integração Social e de Formação do Patrimônio do Servidor Público.";
        }

        #endregion
    }
}
