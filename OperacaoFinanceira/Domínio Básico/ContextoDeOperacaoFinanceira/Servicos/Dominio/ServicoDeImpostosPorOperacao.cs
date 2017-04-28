using ContextoDeImpostos;
using ContextoDeImpostos.Impostos;
using ContextoDeImpostos.Fabricas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextoDeOperacaoFinanceira.Servicos.Dominio
{
    /// <summary>
    /// Classe responsável por encapsular a lógica de criação de impostos por tipo de operação financeira.
    /// </summary>
    internal class ServicoDeImpostosPorOperacao
    {
        private readonly ICollection<IImposto> _impostos;
        private readonly IFabricaDeImpostos _fabricaDeImpostos;
        private readonly TipoDeOperacaoFinanceira _tipoDeOperacaoFinanceira;

        /// <summary>
        /// Cria uma nova instância de <see cref="ServicoDeImpostosPorOperacao"/>.
        /// </summary>
        /// <param name="fabricaDeImpostos">Fábrica de impostos.</param>
        /// <param name="tipoDeOperacaoFinanceira">Tipo de operação financeira.</param>
        public ServicoDeImpostosPorOperacao(IFabricaDeImpostos fabricaDeImpostos, TipoDeOperacaoFinanceira tipoDeOperacaoFinanceira)
        {
            _impostos = new HashSet<IImposto>();
            _fabricaDeImpostos = fabricaDeImpostos;
            _tipoDeOperacaoFinanceira = tipoDeOperacaoFinanceira;

            CriarImpostosPorOperacaoFinanceira();
        }

        /// <summary>
        /// Impostos da operação.
        /// </summary>
        public ICollection<IImposto> Impostos => _impostos;

        private void CriarImpostosPorOperacaoFinanceira()
        {
            switch (_tipoDeOperacaoFinanceira)
            {
                case TipoDeOperacaoFinanceira.Tipo0:
                    ImpostosIncidentesEmOperacaoDeTipo0();
                    break;
                case TipoDeOperacaoFinanceira.Tipo1:
                    ImpostosIncidentesEmOperacaoDeTipo1();
                    break;
                case TipoDeOperacaoFinanceira.Tipo2:
                    ImpostosIncidentesEmOperacaoDeTipo2();
                    break;
            }
        }
        
        private void ImpostosIncidentesEmOperacaoDeTipo0()
        {
            _fabricaDeImpostos
                .CriarImposto<Iof>(_impostos)
                .CriarImposto<Pis>(_impostos)
                .CriarImposto<Cofins>(_impostos);
        }

        private void ImpostosIncidentesEmOperacaoDeTipo1()
        {
            _fabricaDeImpostos
                .CriarImposto<Iof>(_impostos)
                .CriarImposto<Pis>(_impostos);
        }

        private void ImpostosIncidentesEmOperacaoDeTipo2()
        {
            _fabricaDeImpostos
                .CriarImposto<Pis>(_impostos)
                .CriarImposto<Cofins>(_impostos);
        }
    }
}
