using DominioGenerico;
using System;

namespace ContextoDeImpostos.Impostos
{
    /// <summary>
    /// Definição de Imposto sobre Operações Financeiras.
    /// </summary>
    public sealed class Iof : ObjetoDeValor, IIof
    {
        private decimal _valorApurado;
        private readonly int _prazoEmDias;
        private const decimal _aliquota = 0.0038m;
        private readonly decimal _valorBase, _taxaDeIof;

        #region Construtores

        /// <summary>
        /// Cria uma nova instância de <see cref="Iof"/>.
        /// </summary>
        public Iof()
            : this(0m, 0m, 0)
        {

        }

        /// <summary>
        /// Cria uma nova instância de <see cref="Iof"/>.
        /// </summary>
        /// <param name="valorBase">Valor base para cálculo do IOF.</param>
        /// <param name="taxaDeIof">Taxa de IOF aplicada na operação financeira.</param>
        /// <param name="prazoEmDias">Prazo da operação, em dias.</param>
        private Iof(decimal valorBase, decimal taxaDeIof, int prazoEmDias)
        {
            _valorApurado = 0m;
            _valorBase = valorBase;
            _taxaDeIof = taxaDeIof;
            _prazoEmDias = prazoEmDias;
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
            _valorApurado = Math.Round(IofNoPeriodo + IofAdicional, 2);
        }

        #endregion

        #region Membros de IIof

        /// <summary>
        /// Cria o objeto responsável por calcular o IOF.
        /// </summary>
        /// <param name="valorBase">Valor base para cálculo de IOF.</param>
        /// <param name="taxaDeIof">Taxa de IOF.</param>
        /// <param name="prazoEmDias">Prazo para apuração do imposto.</param>
        /// <returns>Objeto de valor com o cálculo de IOF.</returns>
        public IIof ObterIof(decimal valorBase, decimal taxaDeIof, int prazoEmDias)
        {
            return new Iof(valorBase, taxaDeIof, prazoEmDias);
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
            return Equals(objetoDeValor as Iof);
        }

        #endregion

        #region Membros de ObjetoDeValor

        protected override sealed int GetHashCode(int hashCode)
        {
            unchecked
            {
                return (hashCode * hashCodeSalt)
                    ^ (hashCode * hashCodeSalt ^ ValorApurado.GetHashCode())
                    ^ (hashCode * hashCodeSalt ^ TaxaDiaria.GetHashCode())
                    ^ (hashCode * hashCodeSalt ^ TaxaNoPeriodo.GetHashCode())
                    ^ (hashCode * hashCodeSalt ^ IofNoPeriodo.GetHashCode())
                    ^ (hashCode * hashCodeSalt ^ IofAdicional.GetHashCode());
            }
        }

        #endregion

        #region Membros de Object

        public override sealed string ToString()
        {
            return "IOF - Imposto sobre Operações Financeiras";
        }

        #endregion

        #region Membros Privados

        private decimal TaxaDiaria => Math.Round(_taxaDeIof / 365, 4);

        private decimal TaxaNoPeriodo => TaxaDiaria * _prazoEmDias;

        private decimal IofNoPeriodo => TaxaNoPeriodo * _valorBase;

        private decimal IofAdicional => _valorBase * _aliquota;

        private bool Equals(Iof iof)
        {
            return ServicoDeComparacaoDeObjetos.OperandosIguais<IObjetoDeValor>(iof, this) || (iof != null && iof.ValorApurado.Equals(ValorApurado));
        }

        #endregion
    }
}
