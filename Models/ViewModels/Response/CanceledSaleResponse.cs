namespace Models.ViewModels.Response
{
    /// <summary>
    /// Obtiene el response de la cancelacion de un  pedido
    /// </summary>
    public class CanceledSaleResponse
    {
        /// <summary>
        /// Si es 1 se cancelo, 0  que no
        /// </summary>
        public int Canceled { get; set; }
    }
}
