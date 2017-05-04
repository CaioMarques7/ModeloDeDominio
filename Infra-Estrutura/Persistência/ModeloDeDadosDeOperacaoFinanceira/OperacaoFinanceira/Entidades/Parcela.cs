using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDeDados.OperacaoFinanceira.Entidades
{
    public class Parcela : EntidadeBase
    {
        /// <summary>
        /// Identificador único da operação.
        /// </summary>
        internal long IdDaOperacao { get; set; }

        /// <summary>
        /// Valor da Parcela.
        /// </summary>
        public decimal Valor { get; set; }

        /// <summary>
        /// Valor de IOF da parcela.
        /// </summary>
        public decimal ValorDeIof { get; set; }

        /// <summary>
        /// Valor de PIS da parcela.
        /// </summary>
        public decimal ValorDePis { get; set; }

        /// <summary>
        /// Valor de COFINS da parcela.
        /// </summary>
        public decimal ValorDeCofins { get; set; }

        /// <summary>
        /// Data de vencimento da parcela.
        /// </summary>
        public DateTime DataDeVencimento { get; set; }

        /// <summary>
        /// Prazo da parcela.
        /// </summary>
        public short Prazo { get; set; }

        #region Propriedades de Navegação

        /// <summary>
        /// Operação da parcela.
        /// </summary>
        internal virtual Operacao Operacao { get; set; }

        #endregion
    }
}
