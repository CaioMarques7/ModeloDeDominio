using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeDados
{
    /// <summary>
    /// Interface para definir que uma entidade possui verificação de concorrência.
    /// </summary>
    public interface IEntidadeConcorrente
    {
        /// <summary>
        /// Token de Concorrência.
        /// </summary>
        byte[] RowVersion { get; }
    }
}
