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
    internal class MapeamentoDeOperacao : EntityTypeConfiguration<Operacao>
    {
        public MapeamentoDeOperacao()
        {
            Property(operacao => operacao.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(operacao => operacao.TipoDeOperacao).IsRequired();
            Property(operacao => operacao.DataDaOperacao).HasColumnType("date").IsRequired();
            Property(operacao => operacao.TaxaDeIof).IsRequired().HasPrecision(7, 4);
            Property(operacao => operacao.TaxaDeJuros).IsRequired().HasPrecision(7, 4);
            Property(operacao => operacao.Valor).IsRequired();
            Property(operacao => operacao.ValorDeJuros).IsRequired();
            Property(operacao => operacao.ValorDeIof).IsRequired();
            Property(operacao => operacao.ValorDePis).IsRequired();
            Property(operacao => operacao.ValorDeCofins).IsRequired();
            Property(operacao => operacao.RowVersion).IsRowVersion();

            ToTable("Operacao");
            HasKey(operacao => operacao.Id);
            HasMany(operacao => operacao.Parcelas).WithRequired(parcela => parcela.Operacao).HasForeignKey(parcela => parcela.IdDaOperacao);
        }
    }
}
