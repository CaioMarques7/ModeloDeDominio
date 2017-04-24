using ModeloDeDados.OperacaoFinanceira.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDeDados.OperacaoFinanceira.Mapeamento
{
    public class MapeamentoDeParcela : EntityTypeConfiguration<Parcela>
    {
        public MapeamentoDeParcela()
        {
            Property(parcela => parcela.IdDaOperacao).IsRequired();
            Property(parcela => parcela.Valor).IsRequired().HasPrecision(8, 2);
            Property(parcela => parcela.DataDeVencimento).IsRequired();
            Property(parcela => parcela.Prazo).IsRequired();

            ToTable("ParcelaDeOperacao");
            HasKey(parcela => new { parcela.IdDaOperacao, parcela.DataDeVencimento, parcela.Valor });
            HasRequired(parcela => parcela.Operacao);
        }
    }
}
