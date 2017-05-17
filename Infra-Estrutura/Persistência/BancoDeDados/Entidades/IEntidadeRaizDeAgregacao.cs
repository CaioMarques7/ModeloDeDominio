using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeDados
{
    /// <summary>
    /// Interface para definir entidade como raiz de uma agregação.
    /// </summary>
    public interface IEntidadeRaizDeAgregacao
    {
        /// <summary>
        /// Identificador único da entidade.
        /// </summary>
        long Id { get; }

        /// <summary>
        /// Notifica o modelo de domínio sobre alteração na entidade raiz.
        /// </summary>
        void NotificarModeloDeDominio();
    }
}
