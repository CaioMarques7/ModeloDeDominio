using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContextoDeImpostos;
using Impostos.Fabricas;
using ContextoDeOperacaoFinanceira.ObjetosDeValor;

namespace ContextoDeOperacaoFinanceira.Agregacoes.Entidades
{
    /// <summary>
    /// Classe de definição de parcela de operação financeira.
    /// </summary>
    internal class Parcela : IParcela
    {
        private readonly IOperacao _operacao;

        /// <summary>
        /// Cria uma nova instância de <see cref="Parcela"/>.
        /// </summary>
        /// <param name="operacao">Operação a qual a parcela está vinculada.</param>
        /// <param name="valorDaParcela">Valor da parcela.</param>
        /// <param name="dataDeVencimento">Data de vencimento da parcela.</param>
        /// <param name="impostos">Impostos por tipo de operação da parcela.</param>
        public Parcela(IOperacao operacao, decimal valorDaParcela, DateTime dataDeVencimento, ImpostosPorOperacao impostos)
        {
            _operacao = operacao;

            Valor = valorDaParcela;
            DataDeVencimento = dataDeVencimento;
            ImpostosIncidentes = impostos.Impostos;
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
            CalcularIof();
            CalcularPis();
            CalcularCofins();
        }

        private T ObterImposto<T>() where T : IImposto
        {
            T imposto = ImpostosIncidentes.OfType<T>().FirstOrDefault();

            if (imposto != null)
                ImpostosIncidentes.Remove(imposto);
            
            return imposto;
        }

        private void CalcularIof()
        {
            var iof = ObterImposto<IIof>();

            if (iof != null)
            {
                iof = iof.ObterIof(Valor, _operacao.TaxaDeIof, Prazo);
                iof.CalcularValorDeImposto();

                ImpostosIncidentes.Add(iof);
            }
        }

        private void CalcularPis()
        {
            var pis = ObterImposto<IPis>();

            if (pis != null)
            {
                pis = pis.ObterPis(Valor);
                pis.CalcularValorDeImposto();

                ImpostosIncidentes.Add(pis);
            }
        }

        private void CalcularCofins()
        {
            var cofins = ObterImposto<ICofins>();

            if (cofins != null)
            {
                cofins = cofins.ObterCofins(Valor);
                cofins.CalcularValorDeImposto();

                ImpostosIncidentes.Add(cofins);
            }
        }
    }
}
