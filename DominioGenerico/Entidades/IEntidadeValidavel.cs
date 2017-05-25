using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioGenerico.Entidades
{
    /// <summary>
    /// Define características de uma entidade validável.
    /// </summary>
    public interface IEntidadeValidavel
    {
        /// <summary>
        /// Indica se a entidade possui ou não erros de validação.
        /// </summary>
        bool EntidadeValida { get; }

        /// <summary>
        /// Lista de erros de validação que foram identificados na entidade.
        /// </summary>
        IEnumerable<string> ErrosDeValidacao { get; }

        /// <summary>
        /// Realiza validações na entidade.
        /// </summary>
        void ValidarEntidade();
    }
}
