using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.Request
{
    /// <summary>
    /// Modelo para actualizar un pedido
    /// </summary>
    public  class UpdateSalesRequest
    {
        /// <summary>
        /// Obtiene el identificador dle pedido
        /// </summary>
        [Display(Name = "Identificador del pedido")]
        public int IdSale { get; set; }

        /// <summary>
        /// Obtiene el identificador del producto
        /// </summary>
        [Required]
        [Display(Name = "identificador del producto")]
        public int IdProduct { get; set; }

        /// <summary>
        /// Obtiene el Estatus para el identificador del producto
        /// </summary>
        [Required]
        [Display(Name = "Estatus de la cancelacion")]
        public int IdStatus { get; set; }
    }
}
