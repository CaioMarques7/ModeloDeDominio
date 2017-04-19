﻿using ContextoDeOperacaoFinanceira.Fabricas;
using ContextoDeOperacaoFinanceira.Servicos;
using DominioGenerico;
using Impostos.Fabricas;
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
    internal class Operacao : Entidade, IOperacao
    {
        private readonly IFabricaDeParcela _fabricaDeParcela;

        #region Construtores

        /// <summary>
        /// Cria uma nova instância de <see cref="Operacao"/>.
        /// </summary>
        /// <param name="fabricaDeParcela">Fábrica de parcelas.</param>
        /// <param name="tipoDeOperacao">Tipo de operação financeira.</param>
        /// <param name="dataDaOperacao">Data da operação.</param>
        /// <param name="taxaDeIof">Taxa de IOF.</param>
        public Operacao(IFabricaDeParcela fabricaDeParcela, TipoDeOperacaoFinanceira tipoDeOperacao, DateTime dataDaOperacao, decimal taxaDeIof)
            : this(fabricaDeParcela, tipoDeOperacao, dataDaOperacao, taxaDeIof, fabricaDeParcela.CriarColecaoVaziaDeParcelas())
        {
            
        }

        /// <summary>
        /// Cria uma nova instância de <see cref="Operacao"/>.
        /// </summary>
        /// <param name="fabricaDeParcela">Fábrica de parcelas.</param>
        /// <param name="tipoDeOperacao">Tipo de operação financeira.</param>
        /// <param name="dataDaOperacao">Data da operação.</param>
        /// <param name="taxaDeIof">Taxa de IOF.</param>
        /// <param name="parcelas">Parcelas da operação.</param>
        public Operacao(IFabricaDeParcela fabricaDeParcela, TipoDeOperacaoFinanceira tipoDeOperacao, DateTime dataDaOperacao, decimal taxaDeIof, ICollection<IParcela> parcelas)
        {
            _fabricaDeParcela = fabricaDeParcela;

            Parcelas = parcelas;
            TipoDeOperacao = tipoDeOperacao;
            DataDaOperacao = dataDaOperacao;
            TaxaDeIof = taxaDeIof;
        }

        #endregion

        #region Membros de IOperacao

        /// <summary>
        /// Identificador único da operação.
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// Tipo de operação.
        /// </summary>
        public TipoDeOperacaoFinanceira TipoDeOperacao { get; }

        /// <summary>
        /// Data da operação.
        /// </summary>
        public DateTime DataDaOperacao { get; }

        /// <summary>
        /// Taxa de IOF.
        /// </summary>
        public decimal TaxaDeIof { get; }

        /// <summary>
        /// Coleção de parcelas da operação.
        /// </summary>
        public IEnumerable<IParcela> Parcelas { get; }

        /// <summary>
        /// Inclui uma nova parcela na operação.
        /// </summary>
        /// <param name="valorDaParcela">Valor da parcela.</param>
        /// <param name="dataDeVencimento">Data de vencimento da parcela.</param>
        public void IncluirParcela(decimal valorDaParcela, DateTime dataDeVencimento)
        {
            var parcelas = Parcelas as ICollection<IParcela>;

            parcelas.Add(_fabricaDeParcela.CriarParcela(this, valorDaParcela, dataDeVencimento));
        }

        /// <summary>
        /// Calcula os impostos que incidem sobre a operação.
        /// </summary>
        public void CalcularImpostos()
        {
            foreach (var parcela in Parcelas)
                parcela.CalcularImpostos();
        }

        #endregion

        #region Membros de IComparable<T>

        /// <summary>
        /// Compara a instância atual com outro objeto do mesmo tipo e retorna um número inteiro que indica se a instância atual precede, segue ou ocorre na mesma posição na ordem de classificação como o outro objeto.
        /// </summary>
        /// <param name="entidade">Objeto para comparar com a instância atual.</param>
        /// <returns>
        /// Um valor que indica a ordem relativa dos objetos que estão sendo comparados.
        /// </returns>
        public override sealed int CompareTo(IEntidade entidade)
        {
            var operacao = entidade as Operacao;

            return ((operacao == null) || operacao.Id < Id) ? 1 : Equals(operacao) ? 0 : -1;
        }

        #endregion

        #region Membros de IEquatable<T>

        /// <summary>
        /// Compara duas entidades e indica se ambas são iguais.
        /// </summary>
        /// <param name="entidade">Entidade para comparar com a entidade atual.</param>
        /// <returns>Verdadeiro se ambas as entidades forem iguais; caso contrário, falso.</returns>
        public override sealed bool Equals(IEntidade entidade)
        {
            var operacao = entidade as Operacao;

            return OperandosIguais(operacao, this) || Id.Equals(operacao.Id);
        }

        #endregion

        #region Membros de Entidade

        /// <summary>
        /// Função de hash sobrecarregada.
        /// </summary>
        /// <param name="hashCode">Valor base para o cálculo</param>
        /// <returns>Valor calculado.</returns>
        protected override int GetHashCode(int hashCode)
        {
            unchecked
            {
                return (hashCode * hashCodeSalt)
                    ^ (hashCode * hashCodeSalt ^ Id.GetHashCode())
                    ^ (hashCode * hashCodeSalt ^ TipoDeOperacao.GetHashCode())
                    ^ (hashCode * hashCodeSalt ^ DataDaOperacao.GetHashCode())
                    ^ (hashCode * hashCodeSalt ^ TaxaDeIof.GetHashCode());
            }
        }

        #endregion
    }
}
