using ContextoDeOperacaoFinanceira.Agregacoes.Entidades;
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
        /// Cria uma parcela para uma operação.
        /// </summary>
        /// <param name="operacao">Operação à qual a parcela será vinculada.</param>
        /// <param name="valorDaParcela">Valor da parcela.</param>
        /// <returns></returns>
        IParcela CriarParcela(IOperacao operacao, decimal valorDaParcela);

        /// <summary>
        /// Cria uma coleção vazia de parcelas.
        /// </summary>
        /// <returns>Coleção vazia de parcelas.</returns>
        ICollection<IParcela> CriarColecaoVaziaDeParcelas();
    }
}
