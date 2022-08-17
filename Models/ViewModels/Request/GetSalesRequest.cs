using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.Request
{
    /// <summary>
    /// Modelo para obtener los pedidos
    /// </summary>
    public class GetSalesRequest
    {
        /// <summary>
        /// Obtiene el identificador del pedido
        /// </summary>
        [Display(Name = "Identificador del pedido")]
        public int IdSales { get; set; }


        /// <summary>
        /// Obtiene el estatus dle pedido
        /// </summary>
        [Display(Name = "Estatus del pedido")]
        public int IdStatus { get; set; }


        /// <summary>
        /// Obtiene el codigo del pedido
        /// </summary>
        [Display(Name = "Codigo del pedido")]
        public string SalesCode { get; set; }
    }
}
