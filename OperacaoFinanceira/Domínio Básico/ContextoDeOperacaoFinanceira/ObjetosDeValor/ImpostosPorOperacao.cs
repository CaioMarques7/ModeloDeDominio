using ContextoDeImpostos;
using Impostos.Fabricas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextoDeOperacaoFinanceira.ObjetosDeValor
{
    /// <summary>
    /// Classe responsável por encapsular a lógica de criação de impostos por tipo de operação financeira.
    /// </summary>
    internal class ImpostosPorOperacao
    {
        private readonly ICollection<IImposto> _impostos;
        private readonly IFabricaDeImpostos _fabricaDeImpostos;
        private readonly TipoDeOperacaoFinanceira _tipoDeOperacaoFinanceira;

        /// <summary>
        /// Cria uma nova instância de <see cref="ImpostosPorOperacao"/>.
        /// </summary>
        /// <param name="fabricaDeImpostos">Fábrica de impostos.</param>
        /// <param name="tipoDeOperacaoFinanceira">Tipo de operação financeira.</param>
        public ImpostosPorOperacao(IFabricaDeImpostos fabricaDeImpostos, TipoDeOperacaoFinanceira tipoDeOperacaoFinanceira)
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
            _impostos.Add(_fabricaDeImpostos.CriarImposto<IIof>());
            _impostos.Add(_fabricaDeImpostos.CriarImposto<IPis>());
            _impostos.Add(_fabricaDeImpostos.CriarImposto<ICofins>());
        }

        private void ImpostosIncidentesEmOperacaoDeTipo1()
        {
            _impostos.Add(_fabricaDeImpostos.CriarImposto<IIof>());
            _impostos.Add(_fabricaDeImpostos.CriarImposto<IPis>());
        }

        private void ImpostosIncidentesEmOperacaoDeTipo2()
        {
            _impostos.Add(_fabricaDeImpostos.CriarImposto<IPis>());
            _impostos.Add(_fabricaDeImpostos.CriarImposto<ICofins>());
        }
    }
}
