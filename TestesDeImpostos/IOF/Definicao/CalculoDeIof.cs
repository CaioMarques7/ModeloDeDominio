using FluentAssertions;
using Impostos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace TestesDeImpostos.IOF.Definicao
{
    [Binding]
    public sealed class CalculoDeIof
    {
        private int _prazoDaOperacao;
        private decimal _valorDaOperacao, _taxaDeIof, _valorDeIofCalculado;

        [Given(@"que uma operação financeira tem valor de R\$ (.*)")]
        public void DadaUmaOperacaoFinanceiraDeValor(decimal valorDaOperacao)
        {
            _valorDaOperacao = valorDaOperacao;
        }

        [Given(@"que essa operação tem prazo de (.*) dias")]
        public void ComPrazoEmDias(int prazoDaOperacao)
        {
            _prazoDaOperacao = prazoDaOperacao;
        }

        [Given(@"que a taxa de IOF é de (.*)%")]
        public void ComTaxaDeIof(decimal taxaDeIof)
        {
            _taxaDeIof = taxaDeIof;
        }

        [When(@"for calculado o valor de IOF a ser cobrado")]
        public void QuandoCalculadoOValorDeIof()
        {
            Console.WriteLine(@"Calculando o IOF...");

            var iof = new Iof(_valorDaOperacao, _taxaDeIof, _prazoDaOperacao);
            _valorDeIofCalculado = iof.CalcularValorDeImposto();
        }

        [Then(@"o valor deve ser igual a R\$ (.*)")]
        public void OValorDeveSer(decimal valorDeIofCalculado)
        {
            _valorDeIofCalculado.Should().Be(valorDeIofCalculado);
        }
    }
}
