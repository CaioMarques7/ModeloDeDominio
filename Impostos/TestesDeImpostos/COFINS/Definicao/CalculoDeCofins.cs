using FluentAssertions;
using ContextoDeImpostos.Impostos;
using TechTalk.SpecFlow;

namespace TestesDeImpostos.COFINS.Definicao
{
    [Binding]
    public sealed class CalculoDeCofins
    {
        private decimal _valorDaOperacao, _valorDeCofinsCalculado;

        [Given(@"que uma operação financeira, onde há incidência de COFINS, tem valor de R\$ (.*)")]
        public void DadaUmaOperacaoFinanceiraComValor(decimal valorDaOperacao)
        {
            _valorDaOperacao = valorDaOperacao;
        }

        [When(@"for calculado o valor de COFINS a ser cobrado")]
        public void QuandoForCalculadoOValorDeCofins()
        {
            var cofins = new Cofins(_valorDaOperacao);
            cofins.CalcularValorDeImposto();
            _valorDeCofinsCalculado = cofins.ValorApurado;
        }

        [Then(@"o valor de COFINS a ser cobrado deve ser igual a R\$ (.*)")]
        public void OValorDeveSer(decimal valorDeCofinsCalculado)
        {
            _valorDeCofinsCalculado.Should().Be(valorDeCofinsCalculado);
        }
    }
}
