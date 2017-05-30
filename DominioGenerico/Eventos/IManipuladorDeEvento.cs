﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioGenerico.Eventos
{
    public interface IManipuladorDeEvento
    {
    }

    public interface IManipuladorDeEvento<in TEvento> : IManipuladorDeEvento where TEvento : IEvento
    {
        void ManipularEvento(TEvento evento);
    }
}
