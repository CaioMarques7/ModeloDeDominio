using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContextoDeImpostos;
using ContextoDeImpostos.Fabricas;
using ContextoDeOperacaoFinanceira.Servicos.Dominio;
using DominioGenerico;
using ContextoDeCalculoFinanceiro.Fabricas;
using ContextoDeCalculoFinanceiro;

namespace ContextoDeOperacaoFinanceira.Agregacoes.Entidades
{
    /// <summary>
    /// Classe de definição de parcela de operação financeira.
    /// </summary>
    internal class Parcela : Entidade, IParcela
    {
        private readonly IOperacao _operacao;
        private readonly IFabricaDeCalculosFinanceiros _fabricaDeCalculosFinanceiros;

        #region Construtores

        /// <summary>
        /// Cria uma nova instância de <see cref="Parcela"/>.
        /// </summary>
        /// <param name="operacao">Operação a qual a parcela está vinculada.</param>
        /// <param name="valorDaParcela">Valor da parcela.</param>
        /// <param name="dataDeVencimento">Data de vencimento da parcela.</param>
        /// <param name="servicoDeImpostosPorOperacao">Serviço responsável por criar os objetos de imposto por tipo de operação da parcela.</param>
        /// <param name="fabricaDeCalculosFinanceiros">Objeto responsável por criar os cálculos financeiros que serão aplicados a parcela.</param>
        public Parcela(IOperacao operacao, decimal valorDaParcela, DateTime dataDeVencimento, ServicoDeImpostosPorOperacao servicoDeImpostosPorOperacao, IFabricaDeCalculosFinanceiros fabricaDeCalculosFinanceiros)
        {
            _operacao = operacao;
            _fabricaDeCalculosFinanceiros = fabricaDeCalculosFinanceiros;

            Valor = valorDaParcela;
            DataDeVencimento = dataDeVencimento;
            ImpostosIncidentes = servicoDeImpostosPorOperacao.Impostos;
        }

        #endregion

        #region Membros de IParcela

        /// <summary>
        /// Valor da Parcela.
        /// </summary>
        public decimal Valor { get; }

        /// <summary>
        /// Valor de Juros.
        /// </summary>
        public decimal ValorDeJuros { get; private set; }

        /// <summary>
        /// Data de vencimento da parcela.
        /// </summary>
        public DateTime DataDeVencimento { get; }

        /// <summary>
        /// Prazo da parcela.
        /// </summary>
        public short Prazo => (short)((DataDeVencimento - _operacao.DataDaOperacao).Days);

        /// <summary>
        /// Coleção de impostos que incidem sobre a parcela.
        /// </summary>
        public IEnumerable<IImposto> ImpostosIncidentes { get; }

        /// <summary>
        /// Calcula os juros que incidem sobre a parcela.
        /// </summary>
        /// <returns>Parcela com juros calculados.</returns>
        public IParcela CalcularJuros()
        {
            var calculoFinanceiro = Prazo <= 30 ?
                _fabricaDeCalculosFinanceiros.CriarCalculoComCorrecaoLinear(Valor, _operacao.TaxaDeJuros, Prazo, Periodicidade.Mensal) :
                _fabricaDeCalculosFinanceiros.CriarCalculoComCorrecaoExponencial(Valor, _operacao.TaxaDeJuros, Prazo, Periodicidade.Mensal);


            ValorDeJuros = calculoFinanceiro.ValorCalculado() - Valor;

            return this;
        }

        /// <summary>
        /// Calcula os impostos que incidem sobre a parcela.
        /// </summary>
        /// <returns>Parcela com impostos calculados.</returns>
        public IParcela CalcularImpostos()
        {
            CalcularIof();
            CalcularPis();
            CalcularCofins();

            return this;
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
            var parcela = entidade as IParcela;

            return ((parcela == null) || parcela.DataDeVencimento < DataDeVencimento) ? 1 : Equals(parcela) ? 0 : -1;
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
            return Equals(entidade as Parcela);
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
                    ^ (hashCode * hashCodeSalt ^ _operacao.GetHashCode())
                    ^ (hashCode * hashCodeSalt ^ Valor.GetHashCode())
                    ^ (hashCode * hashCodeSalt ^ DataDeVencimento.GetHashCode())
                    ^ (hashCode * hashCodeSalt ^ Prazo.GetHashCode());
            }
        }

        #endregion

        #region Métodos Privados

        private bool Equals(Parcela parcela)
        {
            return ServicoDeComparacaoDeObjetos.OperandosIguais<IEntidade>(parcela, this) || (parcela != null && parcela._operacao.Equals(_operacao) && parcela.DataDeVencimento.Equals(DataDeVencimento) && parcela.Valor.Equals(Valor));
        }
        
        private void CalcularIof()
        {
            var iof = ObterImposto<IIof>();

            if (iof != null)
            {
                iof = iof.ObterIof(Valor, _operacao.TaxaDeIof, Prazo);
                iof.CalcularValorDeImposto();

                AdicionarImposto(iof);
            }
        }

        private void CalcularPis()
        {
            var pis = ObterImposto<IPis>();

            if (pis != null)
            {
                pis = pis.ObterPis(Valor);
                pis.CalcularValorDeImposto();

                AdicionarImposto(pis);
            }
        }

        private void CalcularCofins()
        {
            var cofins = ObterImposto<ICofins>();

            if (cofins != null)
            {
                cofins = cofins.ObterCofins(Valor);
                cofins.CalcularValorDeImposto();

                AdicionarImposto(cofins);
            }
        }

        private T ObterImposto<T>() where T : IImposto
        {
            T imposto = ImpostosIncidentes.OfType<T>().FirstOrDefault();
            RemoverImposto(imposto);
            return imposto;
        }

        private void AdicionarImposto<T>(T imposto) where T : IImposto
        {
            var impostos = ImpostosIncidentes as ICollection<IImposto>;
            impostos.Add(imposto);
        }

        private void RemoverImposto<T>(T imposto) where T : IImposto
        {
            var impostos = ImpostosIncidentes as ICollection<IImposto>;
            impostos.Remove(imposto);
        }

        #endregion
    }
}
