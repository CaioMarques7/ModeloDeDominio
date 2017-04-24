﻿using ModeloDeDados.OperacaoFinanceira.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDeDados.OperacaoFinanceira.Mapeamento
{
    public class MapeamentoDeOperacao : EntityTypeConfiguration<Operacao>
    {
        public MapeamentoDeOperacao()
        {
            Property(operacao => operacao.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(operacao => operacao.TipoDeOperacao).IsRequired();
            Property(operacao => operacao.DataDaOperacao).IsRequired();
            Property(operacao => operacao.TaxaDeIof).IsRequired().HasPrecision(3, 2);

            ToTable("Operacao");
            HasKey(operacao => operacao.Id);
            HasMany(operacao => operacao.Parcelas).WithRequired(parcela => parcela.Operacao).HasForeignKey(parcela => parcela.IdDaOperacao);
        }
    }
}
