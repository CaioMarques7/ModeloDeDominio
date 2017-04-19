using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioGenerico
{
    public abstract class ObjetoDeValor : IObjetoDeValor
    {
        /// <summary>
        /// Constante para definir valor base para cálculo do hash dos objetos.
        /// </summary>
        protected const int hashCodeSalt = 77797;

        #region Membros de IEquatable<T>

        /// <summary>
        /// Compara dois objetos de valor e indica se ambos são iguais.
        /// </summary>
        /// <param name="objetoDeValor">Objeto de valor para comparar com o objeto de valor atual.</param>
        /// <returns>Verdadeiro se ambos os objetos de valor forem iguais; caso contrário, falso.</returns>
        public abstract bool Equals(IObjetoDeValor objetoDeValor);

        #endregion

        #region Membros de Object

        /// <summary>
        /// Compara um objeto de valor ao objeto de valor atual e indica se ambos os objetos são iguais.
        /// </summary>
        /// <param name="obj">Objeto de valor para comparar com o objeto de valor atual.</param>
        /// <returns>Verdadeiro se ambos os objetos forem iguais; caso contrário, falso.</returns>
        public override sealed bool Equals(object obj)
        {
            return Equals(obj as IObjetoDeValor);
        }

        /// <summary>
        /// Função de hash padrão.
        /// </summary>
        /// <returns>Inteiro que indica o hash do objeto de valor.</returns>
        public override sealed int GetHashCode()
        {
            return GetHashCode(int.MinValue);
        }

        #endregion

        /// <summary>
        /// Função de hash sobrecarregada.
        /// </summary>
        /// <param name="hashCode">Valor base para o cálculo</param>
        /// <returns>Valor calculado.</returns>
        protected abstract int GetHashCode(int hashCode);
    }

    public interface IObjetoDeValor : IEquatable<IObjetoDeValor>
    {
    }
}
