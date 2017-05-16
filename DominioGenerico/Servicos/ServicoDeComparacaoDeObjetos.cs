using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioGenerico
{
    public class ServicoDeComparacaoDeObjetos
    {
        /// <summary>
        /// Inicia uma nova instância de <see cref="ServicoDeComparacaoDeObjetos"/>.
        /// </summary>
        internal ServicoDeComparacaoDeObjetos() { }

        /// <summary>
        /// Compara dois objetos como operandos e indica se ambos são nulos.
        /// </summary>
        /// <param name="operandoEsquerda">Operando da esquerda.</param>
        /// <param name="operandoDireita">Operando da direita.</param>
        /// <returns>Verdadeiro se ambos os operandos forem nulos; caso contrário, falso.</returns>
        public bool OperandosNulos<T>(T operandoEsquerda, T operandoDireita) where T : IEquatable<T>
        {
            return (operandoEsquerda == null) && (operandoDireita == null);
        }

        /// <summary>
        /// Compara dois objetos como operandos e indica se ambos são iguais.
        /// </summary>
        /// <param name="operandoEsquerda">Operando da esquerda.</param>
        /// <param name="operandoDireita">Operando da direita.</param>
        /// <returns>Verdadeiro se ambos os operandos forem iguais; caso contrário, falso.</returns>
        public bool OperandosIguais<T>(T operandoEsquerda, T operandoDireita) where T : IEquatable<T>
        {
            return OperandosNulos(operandoEsquerda, operandoDireita) || ReferenceEquals(operandoEsquerda, operandoDireita);
        }

        /// <summary>
        /// Compara dois objetos como operandos e indica se o da esquerda é maior que o da direita.
        /// </summary>
        /// <param name="operandoEsquerda">Operando da esquerda.</param>
        /// <param name="operandoDireita">Operando da direita.</param>
        /// <returns>Verdadeiro se o operando da esquerda for maior que o da direita; caso contrário falso.</returns>
        public bool OperandoAEsquerdaMaiorQueOperandoADireita<T>(T operandoEsquerda, T operandoDireita) where T : IEquatable<T>, IComparable<T>
        {
            return !OperandosIguais(operandoEsquerda, operandoDireita) && operandoEsquerda != null && operandoEsquerda.CompareTo(operandoDireita) > 0;
        }

        /// <summary>
        /// Compara dois objetos como operandos e indica se o da esquerda é menor que o da direita.
        /// </summary>
        /// <param name="operandoEsquerda">Operando da esquerda.</param>
        /// <param name="operandoDireita">Operando da direita.</param>
        /// <returns>Verdadeiro se o operando da esquerda for menor que o da direita; caso contrário falso.</returns>
        public bool OperandoAEsquerdaMenorQueOperandoADireita<T>(T operandoEsquerda, T operandoDireita) where T : IEquatable<T>, IComparable<T>
        {
            return !OperandosIguais(operandoEsquerda, operandoDireita) && operandoEsquerda != null && operandoEsquerda.CompareTo(operandoDireita) < 0;
        }
    }
}
