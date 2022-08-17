using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.Request
{
    /// <summary>
    /// Modelo para cancelar un pedido
    /// </summary>
    public  class CancelSaleRequest
    {
        /// <summary>
        /// Identificador del pedido
        /// </summary>
        [Display(Name = "Identificador del pedido")]
        public int IdSale { get; set; }

        /// <summary>
        /// Obtiene el estatus de la cancelacion
        /// </summary>
        [Required]
        [Display(Name = "Estatus de la cancelacion")]
        public int IdStatus { get; set; }

        /// <summary>
        /// Obtiene el codigo del pedido
        /// </summary>
        [Required]
        [Display(Name = "Identificador del codigo del pedido")]
        public string SalesCode { get; set; }

        /// <summary>
        /// Obtiene la justificacion de la cancelacion del pedido
        /// </summary>
        [Required]
        [Display(Name = "Justificacion de la cancelacion")]
        public string Justification { get; set; }
    }
}
