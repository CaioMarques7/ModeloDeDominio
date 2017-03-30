using ContextoDeOperacaoFinanceira;
using ContextoDeOperacaoFinanceira.Agregacoes.Entidades;
using ContextoDeOperacaoFinanceira.Fabricas;
using DominioGenerico;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestesDeOperacaoFinanceira.TDD
{
    [TestFixture]
    public class TesteDeOperacao
    {
        private readonly ICollection<IOperacao> _operacoes = new HashSet<IOperacao>();
        private readonly IFabricaDeOperacao _fabricaDeOperacao = new FabricaDeOperacao(new Impostos.Fabricas.FabricaDeImpostos());
        

        [SetUp]
        protected void Inicializar()
        {
            _operacoes.Add(_fabricaDeOperacao.CriarOperacao(TipoDeOperacaoFinanceira.Tipo0, DateTime.Today, 1.5m));
            _operacoes.Add(_fabricaDeOperacao.CriarOperacao(TipoDeOperacaoFinanceira.Tipo1, DateTime.Today, 0.25m));
            _operacoes.Add(_fabricaDeOperacao.CriarOperacao(TipoDeOperacaoFinanceira.Tipo2, DateTime.Today, 3.1m));
            _operacoes.Add(_fabricaDeOperacao.CriarOperacao(TipoDeOperacaoFinanceira.Tipo2, DateTime.Today, 0.75m));
            _operacoes.Add(_fabricaDeOperacao.CriarOperacao(TipoDeOperacaoFinanceira.Tipo1, DateTime.Today, 2.74m));
            _operacoes.Add(_fabricaDeOperacao.CriarOperacao(TipoDeOperacaoFinanceira.Tipo0, DateTime.Today, 1.47m));
        }

        [TearDown]
        protected void Finalizar()
        {
            _operacoes.Clear();
        }

        [Test]
        public void AdicionarParcelaNaOperacao()
        {
            var operacao = _operacoes.First();

            operacao.IncluirParcela(540m, DateTime.Today.AddDays(60));

            operacao.Parcelas.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void CompararOperacoes()
        {
            var operacao = _fabricaDeOperacao.CriarOperacao(TipoDeOperacaoFinanceira.Tipo1, DateTime.Today.AddDays(-30), 7.77m);

            _operacoes.Contains(operacao).Should().BeFalse();
        }
    }
}
