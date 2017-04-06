using ContextoDeOperacaoFinanceira.Fabricas;
using ContextoDeOperacaoFinanceira.ObjetosDeValor;
using DominioGenerico;
using Impostos.Fabricas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextoDeOperacaoFinanceira.Agregacoes.Entidades
{
    /// <summary>
    /// Classe de definição de operação financeira.
    /// </summary>
    internal class Operacao : Entidade, IOperacao
    {
        private readonly IFabricaDeParcela _fabricaDeParcela;

        /// <summary>
        /// Cria uma nova instância de <see cref="Operacao"/>.
        /// </summary>
        /// <param name="fabricaDeParcela">Fábrica de parcelas.</param>
        /// <param name="tipoDeOperacao">Tipo de operação financeira.</param>
        /// <param name="dataDaOperacao">Data da operação.</param>
        /// <param name="taxaDeIof">Taxa de IOF.</param>
        /// <param name="parcelas">Parcelas da operação.</param>
        public Operacao(IFabricaDeParcela fabricaDeParcela, TipoDeOperacaoFinanceira tipoDeOperacao, DateTime dataDaOperacao, decimal taxaDeIof, ICollection<IParcela> parcelas)
        {
            _fabricaDeParcela = fabricaDeParcela;

            Parcelas = parcelas;
            TipoDeOperacao = tipoDeOperacao;
            DataDaOperacao = dataDaOperacao;
            TaxaDeIof = taxaDeIof;
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="Operacao"/>.
        /// </summary>
        /// <param name="fabricaDeParcela">Fábrica de parcelas.</param>
        /// <param name="tipoDeOperacao">Tipo de operação financeira.</param>
        /// <param name="dataDaOperacao">Data da operação.</param>
        /// <param name="taxaDeIof">Taxa de IOF.</param>
        public Operacao(IFabricaDeParcela fabricaDeParcela, TipoDeOperacaoFinanceira tipoDeOperacao, DateTime dataDaOperacao, decimal taxaDeIof)
            : this(fabricaDeParcela, tipoDeOperacao, dataDaOperacao, taxaDeIof, fabricaDeParcela.CriarColecaoVaziaDeParcelas())
        {
            
        }

        /// <summary>
        /// Tipo de operação.
        /// </summary>
        public TipoDeOperacaoFinanceira TipoDeOperacao { get; }

        /// <summary>
        /// Data da operação.
        /// </summary>
        public DateTime DataDaOperacao { get; }

        /// <summary>
        /// Taxa de IOF.
        /// </summary>
        public decimal TaxaDeIof { get; }

        /// <summary>
        /// Coleção de parcelas da operação.
        /// </summary>
        public IEnumerable<IParcela> Parcelas { get; }

        /// <summary>
        /// Inclui uma nova parcela na operação.
        /// </summary>
        /// <param name="valorDaParcela">Valor da parcela.</param>
        /// <param name="dataDeVencimento">Data de vencimento da parcela.</param>
        public void IncluirParcela(decimal valorDaParcela, DateTime dataDeVencimento)
        {
            var parcelas = Parcelas as ICollection<IParcela>;

            parcelas.Add(_fabricaDeParcela.CriarParcela(this, valorDaParcela, dataDeVencimento));
        }

        /// <summary>
        /// Calcula os impostos que incidem sobre a operação.
        /// </summary>
        public void CalcularImpostos()
        {
            foreach (var parcela in Parcelas)
                parcela.CalcularImpostos();
        }

        /// <summary>
        /// Função de hash padrão.
        /// </summary>
        /// <returns>Inteiro que indica o hash da entidade.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return GetHashCode(int.MinValue) 
                    ^ TipoDeOperacao.GetHashCode()
                    ^ DataDaOperacao.GetHashCode()
                    ^ TaxaDeIof.GetHashCode()
                    ^ Parcelas.GetHashCode();
            }
        }
    }
}
