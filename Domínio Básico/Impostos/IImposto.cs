namespace Impostos
{
    /// <summary>
    /// Interface para definição de imposto.
    /// </summary>
    public interface IImposto
    {

    }

    /// <summary>
    /// Interface genérica para definição de imposto.
    /// </summary>
    public interface IImposto<T> : IImposto where T : struct, IImposto
    {
        /// <summary>
        /// Calcula o valor de imposto a ser cobrado.
        /// </summary>
        /// <returns>Valor de imposto a ser cobrado.</returns>
        decimal CalcularValorDeImposto();
    }
}
