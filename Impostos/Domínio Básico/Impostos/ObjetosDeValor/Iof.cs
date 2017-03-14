using System;

namespace ContextoDeImpostos.Impostos
{
    /// <summary>
    /// Definição de Imposto sobre Operações Financeiras.
    /// </summary>
    public struct Iof : IImposto<Iof>
    {
        private decimal _valorApurado;
        private readonly int _prazoEmDias;
        private const decimal _aliquota = 0.0038m;
        private readonly decimal _valorBase, _taxaDeIof;

        /// <summary>
        /// Cria uma nova instância de IOF.
        /// </summary>
        /// <param name="valorBase">Valor base para cálculo do IOF.</param>
        /// <param name="taxaDeIof">Taxa de IOF aplicada na operação financeira.</param>
        /// <param name="prazoEmDias">Prazo da operação, em dias.</param>
        public Iof(decimal valorBase, decimal taxaDeIof, int prazoEmDias)
        {
            _valorApurado = 0m;
            _valorBase = valorBase;
            _taxaDeIof = taxaDeIof;
            _prazoEmDias = prazoEmDias;
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
            _valorApurado = Math.Round(IofNoPeriodo + IofAdicional, 2);
        }

        public override string ToString()
        {
            return "IOF - Imposto sobre Operações Financeiras";
        }

        private decimal TaxaDiaria => Math.Round(_taxaDeIof / 365, 4);

        private decimal TaxaNoPeriodo => TaxaDiaria * _prazoEmDias;

        private decimal IofNoPeriodo => TaxaNoPeriodo * _valorBase;

        private decimal IofAdicional => _valorBase * _aliquota;
    }
}
