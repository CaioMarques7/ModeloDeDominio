using ContextoDeOperacaoFinanceira.Agregacoes.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextoDeOperacaoFinanceira.Fabricas
{
    /// <summary>
    /// Contrato para classe responsável por encapsular a lógica de criação de operações.
    /// </summary>
    public interface IFabricaDeOperacao
    {
        /// <summary>
        /// Cria uma nova operação.
        /// </summary>
        /// <param name="tipoDeOperacao">Tipo de operação financeira.</param>
        /// <returns>Operação criada.</returns>
        IOperacao CriarOperacao(TipoDeOperacaoFinanceira tipoDeOperacao);
    }
}
