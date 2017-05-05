using ContextoDeCalculoFinanceiro;
using ContextoDeCalculoFinanceiro.Fabricas.Classes;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace TestesDeCalculoFinanceiro.BDD.CalculoFinanceiro.Definicao
{
    [Binding]
    public sealed class CalculoExponencial
    {
        private int _diasDeApropriacao;
        private Periodicidade _periodicidade;
        private decimal _valorDaParcela, _taxaDeJuros, _valorCalculado;
        private readonly FabricaDeCalculosFinanceiros _fabricaDeCalculos = new FabricaDeCalculosFinanceiros();

        [Given(@"que o valor de uma parcela para correção exponencial é R\$ (.*)")]
        public void DadoQueOValorDeUmaParcelaParaCorrecaoExponencial(decimal valorDaParcela)
        {
            _valorDaParcela = valorDaParcela;
        }

        [Given(@"que o período de apropriação para correção exponencial é (.*)")]
        public void EQueOPeriodoDeApropriacaoE(int diasDeApropriacao)
        {
            _diasDeApropriacao = diasDeApropriacao;
        }

        [Given(@"que a taxa de juros para correção exponencial é(.*)%")]
        public void EQueATaxaDeJurosE(decimal taxaDeJuros)
        {
            _taxaDeJuros = taxaDeJuros;
        }

        [Given(@"que a periodicidade de apuração para correção exponencial é (.*)")]
        public void EQueAPeriodicidadeDeApuracaoE(Periodicidade periodicidade)
        {
            _periodicidade = periodicidade;
        }

        [When(@"eu calcular o valor corrigido aplicando correção exponencial")]
        public void QuandoCalcularOValorCorrigido()
        {
            var calculoExponencial = _fabricaDeCalculos.CriarCalculoComCorrecaoExponencial(_valorDaParcela, _taxaDeJuros, _diasDeApropriacao, _periodicidade);

            _valorCalculado = calculoExponencial.ValorCalculado();
        }

        [Then(@"o valor corrigido aplicando correção exponencial deve ser de R\$ (.*)")]
        public void EntaoOValorDeveSerDe(decimal valorCalculado)
        {
            _valorCalculado.Should().Be(valorCalculado);
        }
    }
}
