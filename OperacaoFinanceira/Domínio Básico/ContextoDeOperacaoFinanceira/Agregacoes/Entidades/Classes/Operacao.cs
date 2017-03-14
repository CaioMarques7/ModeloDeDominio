using ContextoDeOperacaoFinanceira.Fabricas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextoDeOperacaoFinanceira.Agregacoes.Entidades
{
    /// <summary>
    /// Classe de definição de operação financeira.
    /// </summary>
    internal class Operacao : IOperacao
    {
        private readonly IFabricaDeParcela _fabricaDeParcela;

        /// <summary>
        /// Cria uma nova instância de operação.
        /// </summary>
        /// <param name="fabricaDeParcela">Fábrica de parcelas.</param>
        /// <param name="parcelas">Parcelas da operação.</param>
        /// <param name="tipoDeOperacao">Tipo de operação financeira.</param>
        public Operacao(IFabricaDeParcela fabricaDeParcela, ICollection<IParcela> parcelas, TipoDeOperacaoFinanceira tipoDeOperacao)
        {
            _fabricaDeParcela = fabricaDeParcela;

            Parcelas = parcelas;
            TipoDeOperacao = tipoDeOperacao;
        }

        /// <summary>
        /// Cria uma nova instância de operação.
        /// </summary>
        /// <param name="fabricaDeParcela">Fábrica de parcelas.</param>
        /// <param name="tipoDeOperacao">Tipo de operação financeira.</param>
        public Operacao(IFabricaDeParcela fabricaDeParcela, TipoDeOperacaoFinanceira tipoDeOperacao)
            : this(fabricaDeParcela, fabricaDeParcela.CriarColecaoVaziaDeParcelas(), tipoDeOperacao)
        {
            
        }

        /// <summary>
        /// Tipo de operação.
        /// </summary>
        public TipoDeOperacaoFinanceira TipoDeOperacao { get; }

        /// <summary>
        /// Coleção de parcelas da operação.
        /// </summary>
        public ICollection<IParcela> Parcelas { get; }

        /// <summary>
        /// Inclui uma nova parcela na operação.
        /// </summary>
        /// <param name="valorDaParcela">Valor da parcela.</param>
        public void IncluirParcela(decimal valorDaParcela)
        {
            Parcelas.Add(_fabricaDeParcela.CriarParcela(this, valorDaParcela));
        }
    }
}
