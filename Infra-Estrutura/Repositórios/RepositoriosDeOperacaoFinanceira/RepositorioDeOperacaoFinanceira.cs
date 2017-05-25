using ContextoDeOperacaoFinanceira.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContextoDeOperacaoFinanceira.Agregacoes.Entidades;
using ModeloDeOperacaoFinanceira = ModeloDeDados.OperacaoFinanceira.Entidades;
using BancoDeDados.EF6;
using ContextoDeImpostos;
using System.Data.Entity;
using ModeloDeDados;
using Repositorios;
using DominioGenerico;

namespace RepositoriosDeOperacaoFinanceira
{
    public class RepositorioDeOperacaoFinanceira : RepositorioGenerico<ModeloDeOperacaoFinanceira.Operacao>, IRepositorioDeOperacaoFinanceira
    {
        public RepositorioDeOperacaoFinanceira(IContextoDeBancoDeDados contexto) : base(contexto)
        {

        }

        /// <summary>
        /// Persiste uma nova operação financeira no repositório de dados.
        /// </summary>
        /// <param name="operacao">Operação financeira que será persistida.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="InvalidOperationException" />
        public void CriarNovaOperacaoFinanceira(IOperacao operacao)
        {
            IdentificarOperacaoValida(operacao);
            
            Entidades.Add(new ModeloDeOperacaoFinanceira.Operacao(operacao));
        }

        public int PersistirModeloDeDados()
        {
            return Contexto.PersistirModeloDeDados();
        }

        private void IdentificarOperacaoValida(IOperacao operacao)
        {
            Action<IOperacao> validarOperacao = (o) =>
            {
                if (o == null) throw new ArgumentNullException("o", "Operação informada não é válida.");
                o.ValidarEntidade();
            };

            validarOperacao.Invoke(operacao);
        }
    }
}
