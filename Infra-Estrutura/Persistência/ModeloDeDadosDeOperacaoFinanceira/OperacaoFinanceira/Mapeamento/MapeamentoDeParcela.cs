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
    internal class MapeamentoDeParcela : EntityTypeConfiguration<Parcela>
    {
        public MapeamentoDeParcela()
        {
            Property(parcela => parcela.IdDaOperacao).IsRequired();
            Property(parcela => parcela.Valor).IsRequired();
            Property(parcela => parcela.DataDeVencimento).HasColumnType("date").IsRequired();
            Property(parcela => parcela.Prazo).IsRequired();
            Property(parcela => parcela.ValorDeIof).IsRequired();
            Property(parcela => parcela.ValorDePis).IsRequired();
            Property(parcela => parcela.ValorDeCofins).IsRequired();
            Property(parcela => parcela.RowVersion).IsRowVersion();

            ToTable("ParcelaDeOperacao");
            HasKey(parcela => new { parcela.IdDaOperacao, parcela.DataDeVencimento, parcela.Valor });
            HasRequired(parcela => parcela.Operacao);
        }
    }
}
