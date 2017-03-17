using ContextoDeOperacaoFinanceira.Agregacoes.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextoDeOperacaoFinanceira.Fabricas
{
    internal class FabricaDeOperacao : IFabricaDeOperacao
    {
        /// <summary>
        /// Cria uma nova operação.
        /// </summary>
        /// <param name="tipoDeOperacao">Tipo de operação financeira.</param>
        /// <returns>Operação criada.</returns>
        public IOperacao CriarOperacao(TipoDeOperacaoFinanceira tipoDeOperacao)
        {
            return new Operacao(new FabricaDeParcela(), tipoDeOperacao);
        }
    }
}
