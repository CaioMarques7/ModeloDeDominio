using BancoDeDados.EF6;
using ContextoDeOperacaoFinanceira;
using ContextoDeOperacaoFinanceira.Agregacoes.Entidades;
using ContextoDeOperacaoFinanceira.Fabricas;
using ContextoDeOperacaoFinanceira.Repositorios;
using FluentAssertions;
using ModeloDeDadosDeOperacaoFinanceira.OperacaoFinanceira.Contexto.EF6;
using ModeloDeDadosDeOperacaoFinanceira.OperacaoFinanceira.Mapeamento;
using Moq;
using NUnit.Framework;
using RepositoriosDeOperacaoFinanceira;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesDeOperacaoFinanceira.TDD
{
    [TestFixture]
    public class TesteDeCriacaoDeOperacao
    {
        private IFabricaDeOperacao _fabricaDeOperacao;
        private IRepositorioDeOperacaoFinanceira _repositorio;
        
        [SetUp]
        protected void Inicializar()
        {
            _fabricaDeOperacao = new FabricaDeOperacao(new ContextoDeImpostos.Fabricas.FabricaDeImpostos(), new ContextoDeCalculoFinanceiro.Fabricas.Classes.FabricaDeCalculosFinanceiros());
            _repositorio = new RepositorioDeOperacaoFinanceira(new ContextoDeBancoDeDadosDeOperacaoFinanceira());
        }

        [Test]
        public void DisparaExcecaoDeParametroNuloQuandoNullForInformado()
        {
            Assert.Throws<ArgumentNullException>(() => _repositorio.CriarNovaOperacaoFinanceira(null));
        }

        [Test]
        public void DisparaExcecaoDeOperacaoInvalidaQuandoNaoExistemParcelasNaOperacao()
        {
            var operacao = _fabricaDeOperacao.CriarOperacao(TipoDeOperacaoFinanceira.Tipo0, DateTime.Today, 0.4852m, 5.25m);

            Assert.Throws<InvalidOperationException>(() => _repositorio.CriarNovaOperacaoFinanceira(operacao));
        }

        [Test]
        public void SalvarNovaOperacaoNoBancoDeDados()
        {
            var operacao = _fabricaDeOperacao.CriarOperacao(TipoDeOperacaoFinanceira.Tipo0, DateTime.Today, 0.9472m, 1.00m);

            Random r = new Random();

            for (int i = 0; i < 10000; i++)
                operacao.IncluirParcela(Math.Round((decimal)(r.Next(1, 32767) * 13 / 11), 2), DateTime.Today.AddDays(r.Next(1, 32767)));

            operacao.CalcularOperacao();
            
            _repositorio.CriarNovaOperacaoFinanceira(operacao);
            _repositorio.PersistirModeloDeDados();

            operacao.Id.Should().BeGreaterThan(0L);
        }
    }
}
