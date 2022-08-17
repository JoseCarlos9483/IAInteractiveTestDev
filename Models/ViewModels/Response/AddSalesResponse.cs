using System;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.Response
{
    /// <summary>
    /// Clase para obtener el pedido creado.
    /// </summary>
    public class AddSalesResponse
    {
        /// <summary>
        /// Identificador del pedido agregador
        /// </summary>
        public int IdSale { get; set; }

        /// <summary>
        /// Codigo del pedido
        /// </summary>
        public string SalesCode { get; set; }

        /// <summary>
        /// Precio del producto
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Stock del producto
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// Identificador del producto
        /// </summary>
        public int IdProduct { get; set; }

        /// <summary>
        /// Identificador del vendedor
        /// </summary>
        public int IdSalesMan { get; set; }

        /// <summary>
        /// Identificador del comprador
        /// </summary>
        public int IdBuyer { get; set; }

        /// <summary>
        /// Estatus del pedido
        /// </summary>
        public int IdStatus { get; set; }

        /// <summary>
        /// Fecha que se realizo el pedido
        /// </summary>
        public DateTime PurchaseDate { get; set; }

        /// <summary>
        /// Fecha que se realizara la entrega
        /// </summary>
        public DateTime DeadLineDate { get; set; }

    }
}
