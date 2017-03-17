﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.1.0.0
//      SpecFlow Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace TestesDeImpostos.BDD.IOF.Funcionalidade
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Cálculo de IOF - (Imposto sobre Operações Financeiras)")]
    public partial class CalculoDeIOF_ImpostoSobreOperacoesFinanceirasFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CalculoDeIof.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("pt-BR"), "Cálculo de IOF - (Imposto sobre Operações Financeiras)", @"	Para calcular o valor de IOF de uma operação financeira de qualquer valor
	Como parte de cálculos obrigatórios para realização de operação financeira
	Eu devo informar o valor base da operação em questão, prazo em dias para incidência do imposto e a taxa de IOF a ser cobrada, bem como aplicar alíquota de 0,38% ao valor da operação
	E obter o valor de IOF a ser cobrado

	NARRATIVA:
	A funcionalidade descrita tem como base fórmula matemática para obtenção do valor de IOF a ser cobrado.
	O valor de IOF a ser cobrado é apurado a partir da soma do valor de IOF no período com o valor de IOF adicional.
	A fórmula deve ser aplicada da seguinte forma:

	Passo 1: Divida a taxa de IOF informada por 365 dias e arredonde o resultado final em 4 casas decimais. Dessa forma será obtida a taxa diária.
	Passo 2: Multiplique a taxa diária pelo prazo em dias que foi informado. Dessa forma será obtida a taxa de IOF no período.
	Passo 3: Multiplique o valor base da operação pela taxa de IOF no período. Dessa forma será obtido o valor de IOF no período.
	Passo 4: Multiplique o valor base da operação pela alíquota. Dessa forma será obtido o valor de IOF adicional.
	Passo 5: Some o valor de IOF no período com o valor de IOF adicional. Dessa forma será obtido o valor de IOF a ser cobrado.", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Cálculo de IOF")]
        [NUnit.Framework.TestCaseAttribute("2491,32", "105", "1,31", "951,19", new string[0])]
        [NUnit.Framework.TestCaseAttribute("413,47", "57", "0,5", "34,57", new string[0])]
        public virtual void CalculoDeIOF(string valorDaOperacao, string prazo, string taxa, string iOFCalculado, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Cálculo de IOF", exampleTags);
#line 18
this.ScenarioSetup(scenarioInfo);
#line 19
 testRunner.Given(string.Format("que uma operação financeira, onde há incidência de IOF, tem valor de R$ {0}", valorDaOperacao), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 20
 testRunner.And(string.Format("que essa operação tem prazo de {0} dias", prazo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 21
 testRunner.And(string.Format("que a taxa de IOF é de {0}%", taxa), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 22
 testRunner.When("for calculado o valor de IOF a ser cobrado", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 23
 testRunner.Then(string.Format("o valor de IOF a ser cobrado deve ser igual a R$ {0}", iOFCalculado), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
