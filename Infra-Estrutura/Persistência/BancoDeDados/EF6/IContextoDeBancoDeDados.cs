using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeDados.EF6
{
    public interface IContextoDeBancoDeDados
    {
        DbSet<TEntity> Entidades<TEntity>() where TEntity : class;

        int PersistirModeloDeDados();

        Task<int> PersistirModeloDeDadosAssincrono();
    }
}
