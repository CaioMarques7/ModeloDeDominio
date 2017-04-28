using ContextoDeOperacaoFinanceira.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContextoDeOperacaoFinanceira.Agregacoes.Entidades;
using ModeloDeDadosDeOperacaoFinanceira = ModeloDeDados.OperacaoFinanceira.Entidades;
using BancoDeDados.EF6;
using ContextoDeImpostos;

namespace RepositoriosDeOperacaoFinanceira
{
    public class RepositorioDeOperacaoFinanceira : IRepositorioDeCriacaoDeOperacaoFinanceira
    {
        private readonly ContextoDeBancoDeDados _contexto;

        public RepositorioDeOperacaoFinanceira(ContextoDeBancoDeDados contexto)
        {
            _contexto = contexto;
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

            var operacaoDoBanco = TransformarEntidadeDeDominioEmEntidadeDoBancoDeDados(operacao);

            _contexto.Operacoes.Add(operacaoDoBanco);
            _contexto.SaveChanges();
        }

        private void IdentificarOperacaoValida(IOperacao operacao)
        {
            Action<IOperacao> validarOperacao = (o) =>
            {
                if (o == null) throw new ArgumentNullException("o", "Operação informada não é válida.");
                if (o.Parcelas.Count().Equals(0)) throw new InvalidOperationException("Operação não possui parcelas.");
            };

            validarOperacao.Invoke(operacao);
        }

        private ModeloDeDadosDeOperacaoFinanceira.Operacao TransformarEntidadeDeDominioEmEntidadeDoBancoDeDados(IOperacao operacao)
        {
            var colecaoDeParcelas = new HashSet<ModeloDeDadosDeOperacaoFinanceira.Parcela>(
                    operacao.Parcelas.Select(parcela => new ModeloDeDadosDeOperacaoFinanceira.Parcela()
                    {
                        DataDeVencimento = parcela.DataDeVencimento,
                        Prazo = parcela.Prazo,
                        Valor = parcela.Valor,
                        ValorDeIof = parcela.ImpostosIncidentes.OfType<IIof>().Sum(iof => iof.ValorApurado),
                        ValorDePis = parcela.ImpostosIncidentes.OfType<IPis>().Sum(pis => pis.ValorApurado),
                        ValorDeCofins = parcela.ImpostosIncidentes.OfType<ICofins>().Sum(cofins => cofins.ValorApurado)
                    }));

            return new ModeloDeDadosDeOperacaoFinanceira.Operacao()
            {
                Id = operacao.Id,
                DataDaOperacao = operacao.DataDaOperacao,
                TaxaDeIof = operacao.TaxaDeIof,
                TipoDeOperacao = (byte)operacao.TipoDeOperacao,
                Parcelas = colecaoDeParcelas,
                Valor = colecaoDeParcelas.Sum(parcela => parcela.Valor),
                ValorDeIof = colecaoDeParcelas.Sum(parcela => parcela.ValorDeIof),
                ValorDePis = colecaoDeParcelas.Sum(parcela => parcela.ValorDePis),
                ValorDeCofins = colecaoDeParcelas.Sum(parcela => parcela.ValorDeCofins)
            };
        }
    }
}
