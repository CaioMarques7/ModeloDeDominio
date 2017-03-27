using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioGenerico
{
    public abstract class Entidade : IEntidade
    {
        /// <summary>
        /// Identificador único da entidade.
        /// </summary>
        public long Id { get; }

        #region Membros de IComparable<T>

        /// <summary>
        /// Compara a instância atual com outro objeto do mesmo tipo e retorna um número inteiro que indica se a instância atual precede, segue ou ocorre na mesma posição na ordem de classificação como o outro objeto.
        /// </summary>
        /// <param name="entidade">Objeto para comparar com a instância atual.</param>
        /// <returns>
        /// Um valor que indica a ordem relativa dos objetos que estão sendo comparados.
        /// </returns>
        public int CompareTo(IEntidade entidade)
        {
            return ((entidade == null) || entidade.Id < Id) ? 1 : Equals(entidade) ? 0 : -1;
        }

        #endregion

        #region Membros de IEquatable<T>

        /// <summary>
        /// Compara duas entidades e indica se ambas são iguais.
        /// </summary>
        /// <param name="entidade">Entidade para comparar com a entidade atual.</param>
        /// <returns>Verdadeiro se ambas as entidades forem iguais; caso contrário, falso.</returns>
        public bool Equals(IEntidade entidade)
        {
            return entidade != null && (ReferenceEquals(this, entidade) || Id.Equals(entidade.Id));
        }

        #endregion

        #region Membros de Object

        /// <summary>
        /// Compara um objeto à entidade atual e indica se ambos os objetos são iguais.
        /// </summary>
        /// <param name="obj">Objeto para comparar com a entidade atual.</param>
        /// <returns>Verdadeiro se ambos os objetos forem iguais; caso contrário, falso.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as IEntidade);
        }

        /// <summary>
        /// Função de hash padrão.
        /// </summary>
        /// <remarks>Recomendável sobreescrever em entidades derivadas.</remarks>
        /// <returns>Inteiro que indica o hash da entidade.</returns>
        public override int GetHashCode()
        {
            return GetHashCode(int.MinValue);
        }

        /// <summary>
        /// Função de hash sobrecarregada.
        /// </summary>
        /// <param name="hashCode">Valor base para o cálculo</param>
        /// <returns>Valor calculado.</returns>
        protected int GetHashCode(int hashCode)
        {
            unchecked
            {
                return hashCode * 397;
            }
        }

        #endregion

        #region Métodos Protegidos

        protected static bool AmbosNulos(IEntidade x, IEntidade y)
        {
            return ((x == null) && (y == null));
        }

        protected static bool ObjetosIguais(IEntidade x, IEntidade y)
        {
            return AmbosNulos(x, y) || (x != null && x.Equals(y));
        }

        protected static bool ObjetoMaior(IEntidade x, IEntidade y)
        {
            return !AmbosNulos(x, y) || (x != null && x.CompareTo(y) > 0);
        }

        protected static bool ObjetoMenor(IEntidade x, IEntidade y)
        {
            return !AmbosNulos(x, y) || (x != null && x.CompareTo(y) < 0);
        }

        #endregion
    }

    public interface IEntidade : IEquatable<IEntidade>, IComparable<IEntidade>
    {
        /// <summary>
        /// Identificador único da entidade.
        /// </summary>
        long Id { get; }
    }
}
