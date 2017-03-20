using ContextoDeOperacaoFinanceira.Agregacoes.Entidades;
using ContextoDeOperacaoFinanceira.ObjetosDeValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextoDeOperacaoFinanceira.Fabricas
{
    /// <summary>
    /// Contrato para classe responsável por encapsular a lógica de criação de parcelas.
    /// </summary>
    internal interface IFabricaDeParcela
    {
        /// <summary>
        /// Cria uma coleção vazia de parcelas.
        /// </summary>
        /// <returns>Coleção vazia de parcelas.</returns>
        ICollection<IParcela> CriarColecaoVaziaDeParcelas();

        /// <summary>
        /// Cria uma parcela para uma operação.
        /// </summary>
        /// <param name="operacao">Operação à qual a parcela será vinculada.</param>
        /// <param name="valorDaParcela">Valor da parcela.</param>
        /// <param name="dataDeVencimento">Data de vencimento da parcela.</param>
        /// <param name="impostos">Impostos incidentes na operação.</param>
        /// <returns>Parcela criada.</returns>
        IParcela CriarParcela(IOperacao operacao, decimal valorDaParcela, DateTime dataDeVencimento, ImpostosPorOperacao impostos);
    }
}
