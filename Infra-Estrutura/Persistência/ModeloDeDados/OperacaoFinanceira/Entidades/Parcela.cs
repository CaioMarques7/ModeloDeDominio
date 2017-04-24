using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDeDados.OperacaoFinanceira.Entidades
{
    public class Parcela
    {
        /// <summary>
        /// Identificador único da operação.
        /// </summary>
        public long IdDaOperacao { get; set; }

        /// <summary>
        /// Valor da Parcela.
        /// </summary>
        public decimal Valor { get; set; }

        /// <summary>
        /// Data de vencimento da parcela.
        /// </summary>
        public DateTime DataDeVencimento { get; set; }

        /// <summary>
        /// Prazo da parcela.
        /// </summary>
        public short Prazo { get; set; }

        /// <summary>
        /// Operação da parcela.
        /// </summary>
        public Operacao Operacao { get; set; }
    }
}
