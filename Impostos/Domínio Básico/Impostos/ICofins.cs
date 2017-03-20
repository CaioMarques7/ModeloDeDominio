using ContextoDeImpostos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextoDeImpostos
{
    /// <summary>
    /// Interface para definição do imposto COFINS.
    /// </summary>
    public interface ICofins : IImposto
    {
        /// <summary>
        /// Cria o objeto responsável por calcular o COFINS.
        /// </summary>
        /// <param name="valorBase">Valor base para cálculo de COFINS.</param>
        /// <returns>Objeto de valor com o cálculo do COFINS.</returns>
        ICofins ObterCofins(decimal valorBase);
    }
}
