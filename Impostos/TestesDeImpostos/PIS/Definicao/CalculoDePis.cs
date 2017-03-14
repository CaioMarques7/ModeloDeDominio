using FluentAssertions;
using ContextoDeImpostos.Impostos;
using TechTalk.SpecFlow;

namespace TestesDeImpostos.PIS.Definicao
{
    [Binding]
    public sealed class CalculoDePis
    {
        private decimal _valorDaOperacao, _valorDePisCalculado;

        [Given(@"que uma operação financeira, onde há incidência de PIS, tem valor de R\$ (.*)")]
        public void DadaUmaOperacaoFinanceiraComValor(decimal valorDaOperacao)
        {
            _valorDaOperacao = valorDaOperacao;
        }

        [When(@"for calculado o valor de PIS a ser cobrado")]
        public void QuandoForCalculadoOValorDePis()
        {
            var pis = new Pis(_valorDaOperacao);
            pis.CalcularValorDeImposto();
            _valorDePisCalculado = pis.ValorApurado;
        }

        [Then(@"o valor de PIS a ser cobrado deve ser igual a R\$ (.*)")]
        public void OValorDeveSer(decimal valorDePisCalculado)
        {
            _valorDePisCalculado.Should().Be(valorDePisCalculado);
        }
    }
}
