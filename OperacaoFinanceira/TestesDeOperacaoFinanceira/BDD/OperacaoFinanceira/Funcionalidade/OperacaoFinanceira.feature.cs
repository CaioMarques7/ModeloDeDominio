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
namespace TestesDeOperacaoFinanceira.BDD.OperacaoFinanceira.Funcionalidade
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Operação financeira")]
    public partial class OperacaoFinanceiraFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "OperacaoFinanceira.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("pt-BR"), "Operação financeira", null, ProgrammingLanguage.CSharp, ((string[])(null)));
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
        
        public virtual void FeatureBackground()
        {
#line 3
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Valor da Parcela",
                        "Data de Vencimento"});
            table1.AddRow(new string[] {
                        "540,17",
                        "03/11/2017"});
            table1.AddRow(new string[] {
                        "980,06",
                        "03/12/2017"});
#line 4
 testRunner.Given("que as parcelas abaixo fazem parte de uma operação financeira", ((string)(null)), table1, "Dado ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Calculando os impostos que incidem sobre a operação financeira")]
        [NUnit.Framework.TestCaseAttribute("03/04/2017", "1,5", "0,00", "0,00", "0,00", new string[0])]
        [NUnit.Framework.TestCaseAttribute("10/09/2017", "0,61", "0,00", "0,00", "0,00", new string[0])]
        [NUnit.Framework.TestCaseAttribute("01/10/2017", "1,2", "0,00", "0,00", "0,00", new string[0])]
        [NUnit.Framework.TestCaseAttribute("09/07/2017", "0,24", "0,00", "0,00", "0,00", new string[0])]
        public virtual void CalculandoOsImpostosQueIncidemSobreAOperacaoFinanceira(string dataDaOperacao, string taxaDeIOF, string iOFApurado, string pISApurado, string cOFINSApurado, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Calculando os impostos que incidem sobre a operação financeira", exampleTags);
#line 9
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line 10
 testRunner.And(string.Format("que a data dessa operação é {0}", dataDaOperacao), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 11
 testRunner.And(string.Format("a taxa de IOF dessa operação é {0}%", taxaDeIOF), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 12
 testRunner.When("eu calcular os impostos da operação", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 13
 testRunner.Then(string.Format("o valor de IOF apurado deve ser de R$ {0}", iOFApurado), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Então ");
#line 14
 testRunner.And(string.Format("o valor de PIS apurado deve ser de R$ {0}", pISApurado), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 15
 testRunner.And(string.Format("o valor de COFINS apurado deve ser de R$ {0}", cOFINSApurado), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion