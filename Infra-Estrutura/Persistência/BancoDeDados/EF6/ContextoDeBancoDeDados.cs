using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeDados.EF6
{
    public class ContextoDeBancoDeDados : DbContext
    {
        private readonly IConstrutorDeModeloDeDados _construtorDeModeloDeDados;

        public ContextoDeBancoDeDados(IConstrutorDeModeloDeDados construtorDeModeloDeDados)
            : base(nameOrConnectionString: "data source=localhost;initial catalog=Estudos;persist security info=True;Integrated Security=true;MultipleActiveResultSets=True;App=EntityFramework")
        {
            _construtorDeModeloDeDados = construtorDeModeloDeDados;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            _construtorDeModeloDeDados.ConstruirModeloDeDados(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}