using ContextoDeOperacaoFinanceira;
using ContextoDeOperacaoFinanceira.Agregacoes.Entidades;
using ContextoDeOperacaoFinanceira.Fabricas;
using DominioGenerico;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;

namespace TestesDeOperacaoFinanceira.TDD
{
    [TestFixture]
    public class TesteDeOperacao
    {
        private readonly IFabricaDeOperacao _fabricaDeOperacao = new FabricaDeOperacao(new Impostos.Fabricas.FabricaDeImpostos());

        private IOperacao _operacao;

        [SetUp]
        protected void Inicializar()
        {
            _operacao = _fabricaDeOperacao.CriarOperacao(TipoDeOperacaoFinanceira.Tipo0, DateTime.Today, 1.5m);
        }

        [Test]
        public void AdicionarParcelaNaOperacao()
        {
            _operacao.IncluirParcela(540m, DateTime.Today.AddDays(60));

            _operacao.Parcelas.Count().Should().BeGreaterThan(0);
        }
    }
}
