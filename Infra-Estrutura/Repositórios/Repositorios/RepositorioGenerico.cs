using BancoDeDados.EF6;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios
{
    public abstract class RepositorioGenerico<TModeloDeDados> : IDisposable where TModeloDeDados : class
    {
        private bool _recursoLiberado = false;
        private readonly IContextoDeBancoDeDados _contexto;
        private readonly DbSet<TModeloDeDados> _entidadesDoContexto;

        protected RepositorioGenerico(IContextoDeBancoDeDados contexto)
        {
            _contexto = contexto;
            _entidadesDoContexto = _contexto.Entidades<TModeloDeDados>();
        }

        #region Propriedades

        protected IContextoDeBancoDeDados Contexto => _contexto;

        protected DbSet<TModeloDeDados> Entidades => _entidadesDoContexto;

        #endregion

        #region Membros de IDisposable

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool liberarRecursosGerenciados)
        {
            if (!_recursoLiberado && liberarRecursosGerenciados)
            {
                ((DbContext)_contexto).Dispose();
            }

            _recursoLiberado = true;
        }

        #endregion
    }
}
