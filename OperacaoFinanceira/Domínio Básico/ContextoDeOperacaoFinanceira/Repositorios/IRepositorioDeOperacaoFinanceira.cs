using ContextoDeOperacaoFinanceira.Agregacoes.Entidades;
using DominioGenerico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextoDeOperacaoFinanceira.Repositorios
{
    /// <summary>
    /// Define métodos para acesso aos dados de operações financeiras.
    /// </summary>
    public interface IRepositorioDeOperacaoFinanceira : IUnidadeDeTrabalho
    {
        /// <summary>
        /// Persiste uma nova operação financeira no repositório de dados.
        /// </summary>
        /// <param name="operacao">Operação financeira que será persistida.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="InvalidOperationException" />
        void CriarNovaOperacaoFinanceira(IOperacao operacao);
    }
}
