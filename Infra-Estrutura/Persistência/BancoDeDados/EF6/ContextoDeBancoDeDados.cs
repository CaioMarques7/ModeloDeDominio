using ModeloDeDados.OperacaoFinanceira.Entidades;
using ModeloDeDados.OperacaoFinanceira.Mapeamento;
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
        public ContextoDeBancoDeDados()
            : base(nameOrConnectionString: "data source=localhost;initial catalog=Estudos;persist security info=True;Integrated Security=true;MultipleActiveResultSets=True;App=EntityFramework")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MapeamentoDeOperacao());
            modelBuilder.Configurations.Add(new MapeamentoDeParcela());

            base.OnModelCreating(modelBuilder);
        }
        
        public DbSet<Operacao> Operacoes { get; set; }
    }
}