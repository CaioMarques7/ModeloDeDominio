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
        [Given(@"que as parcelas abaixo fazem parte de uma operação financeira")]
        public void DadoQueAsParcelasFazemParteDeUmaOperacaoFinanceira(Table parcelasDaOperacao)
        {
            //TODO: implement arrange (precondition) logic

            Console.WriteLine();
        }

        [Given(@"que a data dessa operação é (.*)")]
        public void EQueADataDessaOperacao(DateTime dataDaOperacao)
        {
            //TODO: implement arrange (precondition) logic

            Console.WriteLine();
        }

        [Given(@"a taxa de IOF dessa operação é(.*)%")]
        public void EATaxaDeIofE(decimal taxaDeIof)
        {
            //TODO: implement arrange (precondition) logic

            Console.WriteLine();
        }

        [When(@"eu calcular os impostos da operação")]
        public void QuandoCalcularOsImpostosDaOperacao()
        {
            //TODO: implement act (action) logic

            Console.WriteLine();
        }

        [Then(@"o valor de IOF apurado deve ser de R\$ (.*)")]
        public void EntaoOValorDeIofApuradoDeveSerDe(decimal valorDeIof)
        {
            //TODO: implement assert (verification) logic

            Console.WriteLine();
        }

        [Then(@"o valor de PIS apurado deve ser de R\$ (.*)")]
        public void EOValorDePisApuradoDeveSerDe(decimal valorDePis)
        {
            //TODO: implement assert (verification) logic

            Console.WriteLine();
        }

        [Then(@"o valor de COFINS apurado deve ser de R\$ (.*)")]
        public void EOValorDeCofinsApuradoDeveSerDe(decimal valorDeCofins)
        {
            //TODO: implement assert (verification) logic

            Console.WriteLine();
        }
    }
}
