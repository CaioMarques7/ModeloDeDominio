using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContextoDeImpostos;

namespace ContextoDeOperacaoFinanceira.Agregacoes.Entidades
{
    /// <summary>
    /// Classe de definição de parcela de operação financeira.
    /// </summary>
    internal class Parcela : IParcela
    {
        private readonly IOperacao _operacao;

        /// <summary>
        /// Cria uma nova instância de parcela.
        /// </summary>
        /// <param name="operacao">Operação a qual a parcela está vinculada.</param>
        /// <param name="valorDaParcela">Valor da parcela.</param>
        /// <param name="dataDeVencimento">Data de vencimento da parcela.</param>
        public Parcela(IOperacao operacao, decimal valorDaParcela, DateTime dataDeVencimento)
        {
            _operacao = operacao;

            Valor = valorDaParcela;
            DataDeVencimento = dataDeVencimento;
            ImpostosIncidentes = new HashSet<IImposto>();
        }
        
        /// <summary>
        /// Valor da Parcela.
        /// </summary>
        public decimal Valor { get; }

        /// <summary>
        /// Data de vencimento da parcela.
        /// </summary>
        public DateTime DataDeVencimento { get; }

        /// <summary>
        /// Prazo da parcela.
        /// </summary>
        public int Prazo => (DataDeVencimento - _operacao.DataDaOperacao).Days;

        /// <summary>
        /// Coleção de impostos que incidem sobre a parcela.
        /// </summary>
        public ICollection<IImposto> ImpostosIncidentes { get; }

        /// <summary>
        /// Calcula os impostos que incidem sobre a parcela.
        /// </summary>
        public void CalcularImpostos()
        {
            ImpostosIncidentes.Add(CalcularIof());
            ImpostosIncidentes.Add(CalcularPis());
            ImpostosIncidentes.Add(CalcularCofins());
        }

        private ContextoDeImpostos.Impostos.Iof CalcularIof()
        {
            var iof = new ContextoDeImpostos.Impostos.Iof(Valor, _operacao.TaxaDeIof, Prazo);
            iof.CalcularValorDeImposto();
            return iof;
        }

        private ContextoDeImpostos.Impostos.Pis CalcularPis()
        {
            var pis = new ContextoDeImpostos.Impostos.Pis(Valor);
            pis.CalcularValorDeImposto();
            return pis;
        }

        private ContextoDeImpostos.Impostos.Cofins CalcularCofins()
        {
            var cofins = new ContextoDeImpostos.Impostos.Cofins(Valor);
            cofins.CalcularValorDeImposto();
            return cofins;
        }
    }
}
