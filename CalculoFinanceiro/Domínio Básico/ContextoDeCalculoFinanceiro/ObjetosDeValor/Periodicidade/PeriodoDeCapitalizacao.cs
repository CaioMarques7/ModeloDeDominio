using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextoDeCalculoFinanceiro
{
    struct PeriodoDeCapitalizacao
    {
        private readonly int _prazo, _diasNoPeriodo;

        public PeriodoDeCapitalizacao(int prazo, Periodicidade periodicidade)
        {
            _prazo = prazo;
            _diasNoPeriodo = ((int)periodicidade) * 30;
        }

        public int PeriodosInteiros => ObterQuantidadeDePeriodosInteiros();

        public decimal PeriodoFracionario => ObterQuantidadeDePeriodosFracionarios();

        public double PeriodoTotal => Convert.ToDouble(PeriodosInteiros + PeriodoFracionario);

        private int ObterQuantidadeDePeriodosInteiros()
        {
            return _prazo / _diasNoPeriodo;
        }

        private decimal ObterQuantidadeDePeriodosFracionarios()
        {
            return _prazo % Convert.ToDecimal(_diasNoPeriodo) / Convert.ToDecimal(_diasNoPeriodo);
        }
    }
}
