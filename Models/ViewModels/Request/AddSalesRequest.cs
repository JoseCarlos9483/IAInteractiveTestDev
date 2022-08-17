using System.ComponentModel.DataAnnotations;


namespace Models.ViewModels.Request
{
    /// <summary>
    /// Modelo para agregar una nueva venta
    /// </summary>
    public class AddSalesRequest
    {
        /// <summary>
        /// Obtiene el identificador del producto
        /// </summary>
        [Required]
        [Display(Name = "Identificador del producto")]
        public int IdProduct { get; set; }

        /// <summary>
        /// Obtiene el identificador del vendedor
        /// </summary>
        [Required]
        [Display(Name = "Identificador del vendedor")]
        public int IdSalesMan { get; set; }

        /// <summary>
        /// Obtiene el identificador del comprador
        /// </summary>
        [Required]
        [Display(Name = "Identificador del Comprador")]
        public int IdBuyer { get; set; }

        /// <summary>
        /// Obtiene el identificador del estatus del pedido
        /// </summary>
        [Required]
        [Display(Name = "Identificador del Estatus")]
        public int IdStatus { get; set; }
    }
}
