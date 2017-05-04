using BancoDeDados.EF6;
using ModeloDeDadosDeOperacaoFinanceira.OperacaoFinanceira.Mapeamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDeDadosDeOperacaoFinanceira.OperacaoFinanceira.Contexto.EF6
{
    public sealed class ContextoDeBancoDeDadosDeOperacaoFinanceira : ContextoDeBancoDeDados
    {
        public ContextoDeBancoDeDadosDeOperacaoFinanceira() 
            : base(dadosDeConexao: "data source=localhost;initial catalog=Estudos;persist security info=True;Integrated Security=true;MultipleActiveResultSets=True;App=EntityFramework", construtorDeModeloDeDados: new MapeamentoDeOperacaoFinanceira())
        {
        }
    }
}
