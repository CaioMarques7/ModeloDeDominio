using DominioGenerico;
using System;

namespace ContextoDeImpostos.Impostos
{
    /// <summary>
    /// Definição do imposto de Programas de Integração Social e de Formação do Patrimônio do Servidor Público.
    /// </summary>
    public sealed class Pis : ObjetoDeValor, IPis
    {
        private decimal _valorApurado;
        private readonly decimal _valorBase;
        private const decimal _aliquota = 0.0165m;

        #region Construtores

        /// <summary>
        /// Cria uma nova instância de <see cref="Pis"/>.
        /// </summary>
        public Pis()
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

        #region Membros de IEquatable<T>

        /// <summary>
        /// Compara dois objetos de valor e indica se ambos são iguais.
        /// </summary>
        /// <param name="objetoDeValor">Objeto de valor para comparar com o objeto de valor atual.</param>
        /// <returns>Verdadeiro se ambos os objetos de valor forem iguais; caso contrário, falso.</returns>
        public override sealed bool Equals(IObjetoDeValor objetoDeValor)
        {
            return Equals(objetoDeValor as Pis);
        }

        #endregion

        #region Membros de ObjetoDeValor

        protected override sealed int GetHashCode(int hashCode)
        {
            unchecked
            {
                return (hashCode * hashCodeSalt)
                    ^ (hashCode * hashCodeSalt ^ ValorApurado.GetHashCode());
            }
        }

        #endregion

        #region Membros de Object

        public override sealed string ToString()
        {
            return "PIS - Imposto de Programas de Integração Social e de Formação do Patrimônio do Servidor Público.";
        }

        #endregion

        #region Membros Privados

        private bool Equals(Pis pis)
        {
            return ServicoDeComparacaoDeObjetos.OperandosIguais<IObjetoDeValor>(pis, this) || (pis != null && pis.ValorApurado.Equals(ValorApurado));
        }

        #endregion
    }
}
