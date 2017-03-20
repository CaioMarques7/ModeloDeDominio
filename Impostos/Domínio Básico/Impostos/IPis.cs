using ContextoDeImpostos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextoDeImpostos
{
    /// <summary>
    /// Interface para definição do imposto PIS.
    /// </summary>
    public interface IPis : IImposto
    {
        /// <summary>
        /// Cria o objeto responsável por calcular o PIS.
        /// </summary>
        /// <param name="valorBase">Valor base para cálculo de PIS.</param>
        /// <returns>Objeto de valor com o cálculo do PIS.</returns>
        IPis ObterPis(decimal valorBase);
    }
}
