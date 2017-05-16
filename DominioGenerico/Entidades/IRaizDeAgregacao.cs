using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioGenerico.Entidades
{
    public interface IRaizDeAgregacao
    {
        /// <summary>
        /// Identificador único.
        /// </summary>
        long Id { get; }

        /// <summary>
        /// Define o identificador único para o valor informado.
        /// </summary>
        /// <param name="id">Valor para o identificador único.</param>
        void DefinirId(long id);
    }
}
