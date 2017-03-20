using ContextoDeImpostos;
using ContextoDeImpostos.Impostos;
using ContextoDeOperacaoFinanceira;
using ContextoDeOperacaoFinanceira.Agregacoes.Entidades;
using ContextoDeOperacaoFinanceira.Fabricas;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace TestesDeOperacaoFinanceira.BDD.OperacaoFinanceira.Definicao
{
    [Binding]
    public sealed class OperacaoFinanceira
    {
        private Table _parcelasDaOperacao;
        private IOperacao _operacao;
        private decimal _taxaDeIof;
        private DateTime _dataDaOperacao;
        private readonly IFabricaDeOperacao _fabricaDeOperacao = new FabricaDeOperacao(new Impostos.Fabricas.FabricaDeImpostos());

        [Given(@"que as parcelas abaixo fazem parte de uma operação financeira")]
        public void DadoQueAsParcelasFazemParteDeUmaOperacaoFinanceira(Table parcelasDaOperacao)
        {
            _parcelasDaOperacao = parcelasDaOperacao;
        }

        [Given(@"que a data dessa operação é (.*)")]
        public void EQueADataDessaOperacao(DateTime dataDaOperacao)
        {
            _dataDaOperacao = dataDaOperacao;
        }

        [Given(@"a taxa de IOF dessa operação é(.*)%")]
        public void EATaxaDeIofE(decimal taxaDeIof)
        {
            _taxaDeIof = taxaDeIof;
        }

        [When(@"eu calcular os impostos da operação")]
        public void QuandoCalcularOsImpostosDaOperacao()
        {
            _operacao = _fabricaDeOperacao.CriarOperacao(TipoDeOperacaoFinanceira.Tipo0, _dataDaOperacao, _taxaDeIof);
            foreach (var parcela in _parcelasDaOperacao.Rows.Select(row => new { Valor = Convert.ToDecimal(row.ElementAt(0).Value), Vencimento = Convert.ToDateTime(row.ElementAt(1).Value) }))
                _operacao.IncluirParcela(parcela.Valor, parcela.Vencimento);

            _operacao.CalcularImpostos();
        }

        [Then(@"o valor de IOF apurado deve ser de R\$ (.*)")]
        public void EntaoOValorDeIofApuradoDeveSerDe(decimal valorDeIof)
        {
            var valorApurado = _operacao.Parcelas
                .Select(parcela => parcela.ImpostosIncidentes.OfType<IIof>().First())
                .Sum(iof => iof.ValorApurado);

            valorApurado.Should().Be(valorDeIof);
        }

        [Then(@"o valor de PIS apurado deve ser de R\$ (.*)")]
        public void EOValorDePisApuradoDeveSerDe(decimal valorDePis)
        {
            var valorApurado = _operacao.Parcelas
                .Select(parcela => parcela.ImpostosIncidentes.OfType<IPis>().First())
                .Sum(iof => iof.ValorApurado);

            valorApurado.Should().Be(valorDePis);
        }

        [Then(@"o valor de COFINS apurado deve ser de R\$ (.*)")]
        public void EOValorDeCofinsApuradoDeveSerDe(decimal valorDeCofins)
        {
            var valorApurado = _operacao.Parcelas
                .Select(parcela => parcela.ImpostosIncidentes.OfType<ICofins>().First())
                .Sum(iof => iof.ValorApurado);

            valorApurado.Should().Be(valorDeCofins);
        }
    }
}
