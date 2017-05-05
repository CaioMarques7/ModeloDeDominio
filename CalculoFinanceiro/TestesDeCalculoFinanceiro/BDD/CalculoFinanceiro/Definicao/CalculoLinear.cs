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
    public sealed class CalculoLinear
    {
        private int _diasDeApropriacao;
        private Periodicidade _periodicidade;
        private decimal _valorDaParcela, _taxaDeJuros, _valorCalculado;
        private readonly FabricaDeCalculosFinanceiros _fabricaDeCalculos = new FabricaDeCalculosFinanceiros();

        [Given(@"que o valor de uma parcela para correção linear é R\$ (.*)")]
        public void DadoQueOValorDeUmaParcelaParaCorrecaoLinear(decimal valorDaParcela)
        {
            _valorDaParcela = valorDaParcela;
        }

        [Given(@"que o período de apropriação para correção linear é (.*)")]
        public void EQueOPeriodoDeApropriacaoE(int diasDeApropriacao)
        {
            _diasDeApropriacao = diasDeApropriacao;
        }

        [Given(@"que a taxa de juros para correção linear é(.*)%")]
        public void EQueATaxaDeJurosE(decimal taxaDeJuros)
        {
            _taxaDeJuros = taxaDeJuros;
        }

        [Given(@"que a periodicidade de apuração para correção linear é (.*)")]
        public void EQueAPeriodicidadeDeApuracaoE(Periodicidade periodicidade)
        {
            _periodicidade = periodicidade;
        }

        [When(@"eu calcular o valor corrigido aplicando correção linear")]
        public void QuandoCalcularOValorCorrigido()
        {
            var calculoLinear = _fabricaDeCalculos.CriarCalculoComCorrecaoLinear(_valorDaParcela, _taxaDeJuros, _diasDeApropriacao, _periodicidade);

            _valorCalculado = calculoLinear.ValorCalculado();
        }

        [Then(@"o valor corrigido aplicando correção linear deve ser de R\$ (.*)")]
        public void EntaoOValorDeveSerDe(decimal valorCalculado)
        {
            _valorCalculado.Should().Be(valorCalculado);
        }
    }
}
