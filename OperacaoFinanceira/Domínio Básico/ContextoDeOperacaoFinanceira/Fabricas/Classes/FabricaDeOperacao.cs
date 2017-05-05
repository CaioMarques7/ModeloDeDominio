using ContextoDeOperacaoFinanceira.Agregacoes.Entidades;
using ContextoDeImpostos.Fabricas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContextoDeCalculoFinanceiro.Fabricas;

namespace ContextoDeOperacaoFinanceira.Fabricas
{
    internal class FabricaDeOperacao : IFabricaDeOperacao
    {
        private readonly IFabricaDeParcela _fabricaDeParcela;

        /// <summary>
        /// Cria uma nova instância de <see cref="FabricaDeOperacao"/>.
        /// </summary>
        /// <param name="fabricaDeImpostos">Fábrica de impostos incidentes na operação.</param>
        /// <param name="fabricaDeCalculosFinanceiros">Objeto responsável por criar os cálculos financeiros que serão aplicados a parcela.</param>
        public FabricaDeOperacao(IFabricaDeImpostos fabricaDeImpostos, IFabricaDeCalculosFinanceiros fabricaDeCalculosFinanceiros)
        {
            _fabricaDeParcela = new FabricaDeParcela(fabricaDeImpostos, fabricaDeCalculosFinanceiros);
        }

        /// <summary>
        /// Cria uma nova operação.
        /// </summary>
        /// <param name="tipoDeOperacao">Tipo de operação financeira.</param>
        /// <param name="dataDaOperacao">Data da operação.</param>
        /// <param name="taxaDeIof">Taxa de IOF.</param>
        /// <param name="taxaDeJuros">Taxa de Juros.</param>
        /// <returns>Operação criada.</returns>
        public IOperacao CriarOperacao(TipoDeOperacaoFinanceira tipoDeOperacao, DateTime dataDaOperacao, decimal taxaDeIof, decimal taxaDeJuros)
        {
            return new Operacao(_fabricaDeParcela, tipoDeOperacao, dataDaOperacao, taxaDeIof, taxaDeJuros);
        }
    }
}
