using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioGenerico
{
    public abstract class Entidade : IEntidade
    {
        #region Membros de IComparable<T>

        /// <summary>
        /// Compara a instância atual com outro objeto do mesmo tipo e retorna um número inteiro que indica se a instância atual precede, segue ou ocorre na mesma posição na ordem de classificação como o outro objeto.
        /// </summary>
        /// <param name="entidade">Objeto para comparar com a instância atual.</param>
        /// <returns>
        /// Um valor que indica a ordem relativa dos objetos que estão sendo comparados.
        /// </returns>
        public abstract int CompareTo(IEntidade entidade);

        #endregion

        #region Membros de IEquatable<T>

        /// <summary>
        /// Compara duas entidades e indica se ambas são iguais.
        /// </summary>
        /// <param name="entidade">Entidade para comparar com a entidade atual.</param>
        /// <returns>Verdadeiro se ambas as entidades forem iguais; caso contrário, falso.</returns>
        public abstract bool Equals(IEntidade entidade);

        #endregion

        #region Membros de Object

        /// <summary>
        /// Compara um objeto à entidade atual e indica se ambos os objetos são iguais.
        /// </summary>
        /// <param name="obj">Objeto para comparar com a entidade atual.</param>
        /// <returns>Verdadeiro se ambos os objetos forem iguais; caso contrário, falso.</returns>
        public override sealed bool Equals(object obj)
        {
            return Equals(obj as IEntidade);
        }

        /// <summary>
        /// Função de hash padrão.
        /// </summary>
        /// <returns>Inteiro que indica o hash da entidade.</returns>
        public abstract override int GetHashCode();

        /// <summary>
        /// Função de hash sobrecarregada.
        /// </summary>
        /// <param name="hashCode">Valor base para o cálculo</param>
        /// <returns>Valor calculado.</returns>
        protected static int GetHashCode(int hashCode)
        {
            return hashCode * 1024;
        }

        #endregion

        #region Métodos Protegidos

        /// <summary>
        /// Compara dois objetos como operandos e indica se ambos são nulos.
        /// </summary>
        /// <param name="operandoEsquerda">Operando da esquerda.</param>
        /// <param name="operandoDireita">Operando da direita.</param>
        /// <returns>Verdadeiro se ambos os operandos forem nulos; caso contrário, falso.</returns>
        protected static bool OperandosNulos(IEntidade operandoEsquerda, IEntidade operandoDireita)
        {
            return ((operandoEsquerda == null) && (operandoDireita == null));
        }

        /// <summary>
        /// Compara dois objetos como operandos e indica se ambos são iguais.
        /// </summary>
        /// <param name="operandoEsquerda">Operando da esquerda.</param>
        /// <param name="operandoDireita">Operando da direita.</param>
        /// <returns>Verdadeiro se ambos os operandos forem iguais; caso contrário, falso.</returns>
        protected static bool OperandosIguais(IEntidade operandoEsquerda, IEntidade operandoDireita)
        {
            return OperandosNulos(operandoEsquerda, operandoDireita) || ReferenceEquals(operandoEsquerda, operandoDireita);
        }

        /// <summary>
        /// Compara dois objetos como operandos e indica se o da esquerda é maior que o da direita.
        /// </summary>
        /// <param name="operandoEsquerda">Operando da esquerda.</param>
        /// <param name="operandoDireita">Operando da direita.</param>
        /// <returns>Verdadeiro se o operando da esquerda for maior que o da direita; caso contrário falso.</returns>
        protected static bool OperandoAEsquerdaMaiorQueOperandoADireita(IEntidade operandoEsquerda, IEntidade operandoDireita)
        {
            return !OperandosIguais(operandoEsquerda, operandoDireita) && operandoEsquerda != null && operandoEsquerda.CompareTo(operandoDireita) > 0;
        }

        /// <summary>
        /// Compara dois objetos como operandos e indica se o da esquerda é menor que o da direita.
        /// </summary>
        /// <param name="operandoEsquerda">Operando da esquerda.</param>
        /// <param name="operandoDireita">Operando da direita.</param>
        /// <returns>Verdadeiro se o operando da esquerda for menor que o da direita; caso contrário falso.</returns>
        protected static bool OperandoAEsquerdaMenorQueOperandoADireita(IEntidade operandoEsquerda, IEntidade operandoDireita)
        {
            return !OperandosIguais(operandoEsquerda, operandoDireita) && operandoEsquerda != null && operandoEsquerda.CompareTo(operandoDireita) < 0;
        }

        #endregion
    }

    public interface IEntidade : IEquatable<IEntidade>, IComparable<IEntidade>
    {

    }
}
