﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeDados
{
    public interface IEntidadeRaizDeAgregacao
    {
        long Id { get; }

        void NotificarModeloDeDominio();
    }
}
