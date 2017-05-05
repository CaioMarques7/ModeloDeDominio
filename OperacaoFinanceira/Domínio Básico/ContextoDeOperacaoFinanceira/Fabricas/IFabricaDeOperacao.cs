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
        /// <param name="dataDaOperacao">Data da operação.</param>
        /// <param name="taxaDeIof">Taxa de IOF.</param>
        /// <param name="taxaDeJuros">Taxa de Juros.</param>
        /// <returns>Operação criada.</returns>
        IOperacao CriarOperacao(TipoDeOperacaoFinanceira tipoDeOperacao, DateTime dataDaOperacao, decimal taxaDeIof, decimal taxaDeJuros);
    }
}
