using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impostos
{
    public struct Pis : IImposto<Pis>
    {
        private const decimal _aliquota = 0.0165m;

        public decimal CalcularValorDeImposto()
        {
            throw new NotImplementedException();
        }
    }
}
