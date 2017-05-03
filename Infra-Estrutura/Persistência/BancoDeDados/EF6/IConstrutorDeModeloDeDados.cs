using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeDados.EF6
{
    /// <summary>
    /// Contrato para definição de objetos de construção de mapeamento de modelo de dados.
    /// </summary>
    public interface IConstrutorDeModeloDeDados
    {
        /// <summary>
        /// Constrói o modelo de dados e o adiciona a instância de contexto.
        /// </summary>
        /// <param name="modelBuilder">Objeto responsável por armazenar o modelo de dados.</param>
        void ConstruirModeloDeDados(DbModelBuilder modelBuilder);
    }
}
