using DominioGenerico.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioGenerico
{
    public interface IDisparadorDeEventos : IDisposable
    {
        void DispararEvento<TEvento>(TEvento evento) where TEvento : IEvento;
    }

    public class DisparadorDeEventos : IDisparadorDeEventos
    {
        private bool _recursoLiberado;
        private readonly ICollection<IManipuladorDeEvento> _manipuladoresDeEvento;

        public DisparadorDeEventos()
        {
            _manipuladoresDeEvento = new HashSet<IManipuladorDeEvento>();
        }

        #region Membros de IDisparadorDeEventos

        public void DispararEvento<TEvento>(TEvento evento) where TEvento : IEvento
        {
            var manipuladores = _manipuladoresDeEvento.OfType<IManipuladorDeEvento<TEvento>>();

            foreach (var manipulador in manipuladores)
                manipulador.ManipularEvento(evento);
        }

        #endregion

        #region Membros de IDisposable

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool liberarRecursosGerenciados)
        {
            if (!_recursoLiberado && liberarRecursosGerenciados)
            {
                _recursoLiberado = true;

                _manipuladoresDeEvento.Clear();
            }
        }

        #endregion
    }
}
