using BancoDeDados;
using ContextoDeImpostos;
using ContextoDeOperacaoFinanceira.Agregacoes.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDeDados.OperacaoFinanceira.Entidades
{
    public class Operacao : IEntidadeRaizDeAgregacao, IEntidadeConcorrente
    {
        private readonly IOperacao _operacao;

        #region Construtores

        protected Operacao() { }

        public Operacao(IOperacao operacao)
        {
            _operacao = operacao;

            var parcelasDaOperacao = new HashSet<Parcela>(
                    operacao.Parcelas.Select(parcela => new Parcela(this)
                    {
                        DataDeVencimento = parcela.DataDeVencimento,
                        Prazo = parcela.Prazo,
                        Valor = parcela.Valor,
                        ValorDeJuros = parcela.ValorDeJuros,
                        ValorDeIof = parcela.ValorApuradoPorImposto<IIof>(),
                        ValorDePis = parcela.ValorApuradoPorImposto<IPis>(),
                        ValorDeCofins = parcela.ValorApuradoPorImposto<ICofins>()
                    }));

            DataDaOperacao = operacao.DataDaOperacao;
            TaxaDeIof = operacao.TaxaDeIof;
            TaxaDeJuros = operacao.TaxaDeJuros;
            TipoDeOperacao = (byte)operacao.TipoDeOperacao;
            Parcelas = parcelasDaOperacao;
            Valor = parcelasDaOperacao.Sum(parcela => parcela.Valor);
            ValorDeJuros = parcelasDaOperacao.Sum(parcela => parcela.ValorDeJuros);
            ValorDeIof = parcelasDaOperacao.Sum(parcela => parcela.ValorDeIof);
            ValorDePis = parcelasDaOperacao.Sum(parcela => parcela.ValorDePis);
            ValorDeCofins = parcelasDaOperacao.Sum(parcela => parcela.ValorDeCofins);
        }

        #endregion

        /// <summary>
        /// Identificador único da operação.
        /// </summary>
        public long Id { get; internal set; }

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
        /// Taxa de juros.
        /// </summary>
        public decimal TaxaDeJuros { get; set; }

        /// <summary>
        /// Valor da operação.
        /// </summary>
        public decimal Valor { get; set; }

        /// <summary>
        /// Valor de juros da operação.
        /// </summary>
        public decimal ValorDeJuros { get; set; }

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

        /// <summary>
        /// Token de Concorrência.
        /// </summary>
        public byte[] RowVersion { get; internal set; }

        #region Propriedades de Navegação

        /// <summary>
        /// Coleção de parcelas da operação.
        /// </summary>
        public virtual ICollection<Parcela> Parcelas { get; set; }

        #endregion

        public void NotificarModeloDeDominio()
        {
            _operacao?.DefinirId(Id);
        }
    }
}
