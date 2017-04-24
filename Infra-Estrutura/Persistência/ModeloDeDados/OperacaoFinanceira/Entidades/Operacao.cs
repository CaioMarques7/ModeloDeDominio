using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDeDados.OperacaoFinanceira.Entidades
{
    public class Operacao
    {
        /// <summary>
        /// Identificador único da operação.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Tipo de operação.
        /// </summary>
        public byte TipoDeOperacao { get; set; }

        /// <summary>
        /// Data da operação.
        /// </summary>
        public DateTime DataDaOperacao { get; set; }

        /// <summary>
        /// Taxa de IOF.
        /// </summary>
        public decimal TaxaDeIof { get; set; }

        /// <summary>
        /// Coleção de parcelas da operação.
        /// </summary>
        public ICollection<Parcela> Parcelas { get; set; }
    }
}
