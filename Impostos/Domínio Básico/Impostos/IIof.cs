using ContextoDeImpostos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextoDeImpostos
{
    /// <summary>
    /// Interface para definição do imposto IOF.
    /// </summary>
    public interface IIof : IImposto
    {
        /// <summary>
        /// Cria o objeto responsável por calcular o IOF.
        /// </summary>
        /// <param name="valorBase">Valor base para cálculo de IOF.</param>
        /// <param name="taxaDeIof">Taxa de IOF.</param>
        /// <param name="prazoEmDias">Prazo para apuração do imposto.</param>
        /// <returns>Objeto de valor com o cálculo de IOF.</returns>
        IIof ObterIof(decimal valorBase, decimal taxaDeIof, int prazoEmDias);
    }
}
