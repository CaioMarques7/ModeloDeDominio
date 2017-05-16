using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeDados
{
    public interface IEntidadeConcorrente
    {
        /// <summary>
        /// Token de Concorrência.
        /// </summary>
        byte[] RowVersion { get; }
    }
}
