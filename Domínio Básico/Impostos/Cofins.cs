using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impostos
{
    public struct Cofins : IImposto<Cofins>
    {
        private const decimal _aliquota = 0.076m;

        public decimal CalcularValorDeImposto()
        {
            throw new NotImplementedException();
        }
    }
}
