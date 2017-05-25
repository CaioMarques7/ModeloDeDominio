using DominioGenerico;
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
        /// Constante para definir valor base para cálculo do hash dos objetos.
        /// </summary>
        protected const int hashCodeSalt = 104723;
        private readonly ServicoDeComparacaoDeObjetos _servicoDeComparacaoDeObjetos;
        protected readonly ICollection<string> _errosDeValidacao = new HashSet<string>();

        #region Construtores

        /// <summary>
        /// Inicia uma nova instância de <see cref="Entidade"/>.
        /// </summary>
        protected Entidade()
        {
            _servicoDeComparacaoDeObjetos = new ServicoDeComparacaoDeObjetos();
        }

        #endregion

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
        public override sealed int GetHashCode()
        {
            return GetHashCode(int.MinValue);
        }

        #endregion

        #region Membros Protegidos

        protected ServicoDeComparacaoDeObjetos ServicoDeComparacaoDeObjetos => _servicoDeComparacaoDeObjetos;

        /// <summary>
        /// Função de hash sobrecarregada.
        /// </summary>
        /// <param name="hashCode">Valor base para o cálculo</param>
        /// <returns>Valor calculado.</returns>
        protected abstract int GetHashCode(int hashCode);

        protected void Validar<TEntidade>(TEntidade entidade, Func<TEntidade, bool> validacao, string mensagemDeErro) where TEntidade : IEntidade
        {
            if (validacao.Invoke(entidade))
                _errosDeValidacao.Add(mensagemDeErro);
        }

        #endregion
    }

    public interface IEntidade : IEquatable<IEntidade>, IComparable<IEntidade>
    {

    }
}
