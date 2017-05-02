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
        /// Valor da operação.
        /// </summary>
        public decimal Valor { get; set; }

        /// <summary>
        /// Valor de IOF da operação.
        /// </summary>
        public decimal ValorDeIof { get; set; }

        /// <summary>
        /// Valor de PIS da operação.
        /// </summary>
        public decimal ValorDePis { get; set; }

        /// <summary>
        /// Valor de COFINS da operação.
        /// </summary>
        public decimal ValorDeCofins { get; set; }

        #region Propriedade de Verificação de Concorrência

        /// <summary>
        /// Token de Concorrência.
        /// </summary>
        internal byte[] RowVersion { get; set; }

        #endregion

        #region Propriedades de Navegação

        /// <summary>
        /// Coleção de parcelas da operação.
        /// </summary>
        public ICollection<Parcela> Parcelas { get; set; }

        #endregion
    }
}
