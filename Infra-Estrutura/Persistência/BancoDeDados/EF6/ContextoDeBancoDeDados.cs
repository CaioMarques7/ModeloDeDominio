using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeDados.EF6
{
    public abstract class ContextoDeBancoDeDados : DbContext, IContextoDeBancoDeDados
    {
        private readonly IConstrutorDeModeloDeDados _construtorDeModeloDeDados;

        protected ContextoDeBancoDeDados(string dadosDeConexao, IConstrutorDeModeloDeDados construtorDeModeloDeDados)
            : base(nameOrConnectionString: dadosDeConexao)
        {
            _construtorDeModeloDeDados = construtorDeModeloDeDados;
        }

        #region Membros de IContextoDeBancoDeDados

        public DbSet<TEntity> Entidades<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }

        public int PersistirModeloDeDados()
        {
            return SaveChanges();
        }

        public Task<int> PersistirModeloDeDadosAssincrono()
        {
            return SaveChangesAsync();
        }

        #endregion

        #region Membros de DbContext

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            _construtorDeModeloDeDados.ConstruirModeloDeDados(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            var i = base.SaveChanges();

            foreach (var entidade in ChangeTracker.Entries<IEntidadeRaizDeAgregacao>().Select(e => e.Entity))
                entidade.NotificarModeloDeDominio();

            return i;
        }

        #endregion
    }
}