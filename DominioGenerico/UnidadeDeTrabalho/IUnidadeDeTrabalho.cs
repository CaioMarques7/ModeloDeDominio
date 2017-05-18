using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioGenerico
{
    /// <summary>
    /// Define métodos de persistência de dados dos repositórios que a implementam.
    /// </summary>
    public interface IUnidadeDeTrabalho
    {
        int PersistirModeloDeDados();
    }

    /// <summary>
    /// Define métodos de persistência assíncrona de dados dos repositórios que a implementam.
    /// </summary>
    public interface IUnidadeDeTrabalhoAssincrona
    {
        Task<int> PersistirModeloDeDadosAssincrono();
    }
}
