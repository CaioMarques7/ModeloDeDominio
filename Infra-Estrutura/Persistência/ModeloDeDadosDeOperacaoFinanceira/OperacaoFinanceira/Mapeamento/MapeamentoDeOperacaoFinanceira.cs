using BancoDeDados.EF6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ModeloDeDados.OperacaoFinanceira.Mapeamento;

namespace ModeloDeDadosDeOperacaoFinanceira.OperacaoFinanceira.Mapeamento
{
    public class MapeamentoDeOperacaoFinanceira : IConstrutorDeModeloDeDados
    {
        public void ConstruirModeloDeDados(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MapeamentoDeOperacao());
            modelBuilder.Configurations.Add(new MapeamentoDeParcela());
        }
    }
}
