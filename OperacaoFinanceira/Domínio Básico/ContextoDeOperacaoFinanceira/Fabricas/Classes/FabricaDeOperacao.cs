using ContextoDeOperacaoFinanceira.Agregacoes.Entidades;
using ContextoDeImpostos.Fabricas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextoDeOperacaoFinanceira.Fabricas
{
    internal class FabricaDeOperacao : IFabricaDeOperacao
    {
        private readonly IFabricaDeParcela _fabricaDeParcela;

        /// <summary>
        /// Cria uma nova instância de <see cref="FabricaDeOperacao"/>.
        /// </summary>
        /// <param name="fabricaDeImpostos">Fábrica de impostos incidentes na operação.</param>
        public FabricaDeOperacao(IFabricaDeImpostos fabricaDeImpostos)
        {
            _fabricaDeParcela = new FabricaDeParcela(fabricaDeImpostos);
        }

        /// <summary>
        /// Cria uma nova operação.
        /// </summary>
        /// <param name="tipoDeOperacao">Tipo de operação financeira.</param>
        /// <param name="dataDaOperacao">Data da operação.</param>
        /// <param name="taxaDeIof">Taxa de IOF.</param>
        /// <returns>Operação criada.</returns>
        public IOperacao CriarOperacao(TipoDeOperacaoFinanceira tipoDeOperacao, DateTime dataDaOperacao, decimal taxaDeIof)
        {
            return new Operacao(_fabricaDeParcela, tipoDeOperacao, dataDaOperacao, taxaDeIof);
        }
    }
}
