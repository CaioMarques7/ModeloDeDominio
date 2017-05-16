using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDeDados
{
    public abstract class EntidadeBase
    {
        #region Propriedade de Verificação de Concorrência

        /// <summary>
        /// Token de Concorrência.
        /// </summary>
        public byte[] RowVersion { get; internal set; }

        #endregion
    }
}
