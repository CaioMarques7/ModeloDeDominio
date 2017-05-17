using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeDados.EF6
{
    /// <summary>
    /// Interface para definição de métodos para acesso ao banco de dados.
    /// </summary>
    public interface IContextoDeBancoDeDados
    {
        /// <summary>
        /// Cria uma coleção de entidades de acordo com o tipo informado.
        /// </summary>
        /// <typeparam name="TEntity">Tipo da entidade.</typeparam>
        /// <returns>Coleção de entidades.</returns>
        DbSet<TEntity> Entidades<TEntity>() where TEntity : class;

        /// <summary>
        /// Persiste o modelo de dados do contexto atual no banco de dados.
        /// </summary>
        /// <returns>Número de registros afetados.</returns>
        int PersistirModeloDeDados();

        /// <summary>
        /// Persiste o modelo de dados do contexto atual no banco de dados de maneira assíncrona.
        /// </summary>
        /// <returns>Número de registros afetados.</returns>
        Task<int> PersistirModeloDeDadosAssincrono();
    }
}
