using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
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

        /// <summary>
        /// Cria uma coleção de entidades de acordo com o tipo informado.
        /// </summary>
        /// <typeparam name="TEntity">Tipo da entidade.</typeparam>
        /// <returns>Coleção de entidades.</returns>
        public DbSet<TEntity> Entidades<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }

        /// <summary>
        /// Persiste o modelo de dados do contexto atual no banco de dados.
        /// </summary>
        /// <returns>Número de registros afetados.</returns>
        public int PersistirModeloDeDados()
        {
            return SaveChanges();
        }

        /// <summary>
        /// Persiste o modelo de dados do contexto atual no banco de dados de maneira assíncrona.
        /// </summary>
        /// <returns>Número de registros afetados.</returns>
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
            return SaveChangesAsync().Result;
        }

        public override Task<int> SaveChangesAsync()
        {
            return SaveChangesAsync(CancellationToken.None);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            IndicarPropriedadesModificadas();
            var entidadesParaNotificar = ObterEntidadesParaNotificar();

            var i = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            foreach (var entidade in entidadesParaNotificar)
                entidade.NotificarModeloDeDominio();

            return i;
        }

        #endregion

        #region Métodos Privados

        /// <summary>
        /// Indica as propriedades modificadas em entidades para atualização.
        /// Isso impede que seja disparado um update em todas as colunas da tabela.
        /// </summary>
        private void IndicarPropriedadesModificadas()
        {
            foreach (var entidade in ChangeTracker.Entries().Where(entry => entry.State == EntityState.Modified))
            {
                Parallel.ForEach(entidade.CurrentValues.PropertyNames, (nomeDaPropriedade) => 
                {
                    entidade.Property(nomeDaPropriedade).IsModified = 
                        entidade.Property(nomeDaPropriedade).OriginalValue != entidade.Property(nomeDaPropriedade).CurrentValue;
                });
            }
        }

        private IEnumerable<IEntidadeRaizDeAgregacao> ObterEntidadesParaNotificar()
        {
            return ChangeTracker.Entries<IEntidadeRaizDeAgregacao>()
                .Where(entry => entry.State == EntityState.Added)
                .Select(entry => entry.Entity)
                .ToList();
        }

        #endregion
    }
}