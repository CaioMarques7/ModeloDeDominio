namespace ContextoDeImpostos
{
    /// <summary>
    /// Interface para definição de imposto.
    /// </summary>
    public interface IImposto
    {
        /// <summary>
        /// Valor de imposto a ser cobrado.
        /// </summary>
        decimal ValorApurado { get; }

        /// <summary>
        /// Calcula o valor de imposto a ser cobrado.
        /// </summary>
        void CalcularValorDeImposto();
    }
}
