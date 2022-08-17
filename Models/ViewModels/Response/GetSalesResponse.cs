using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels.Response
{
    /// <summary>
    /// Clase para obtener los pedidos
    /// </summary>
    public class GetSalesResponse
    {
        /// <summary>
        /// Obtienes el identificador del pedido
        /// </summary>
        public int IdPedido { get; set; }

        /// <summary>
        /// Obtiene el codigo del pedido
        /// </summary>
        public string CodigoPedido { get; set; }

        /// <summary>
        /// Obtiene el nombre del producto
        /// </summary>
        public string NombreProducto { get; set; }

        /// <summary>
        /// Obtiene el identificador del producto
        /// </summary>
        public int IdProducto { get; set; }

        /// <summary>
        /// Obtiene el identificador del vendedor
        /// </summary>
        public int IdVendedor { get; set; }

        /// <summary>
        /// Obtiene el nombre del vendedor
        /// </summary>
        public string NombreVendedor { get; set; }
       
        /// <summary>
        /// Obtiene el apellido paterno del vendedor
        /// </summary>
        public string ApellidoPaternoVendedor { get; set; }

        /// <summary>
        /// Obtiene el apellido materno si lo tiene del vendedor
        /// </summary>
        public string? ApellidoMaternoVendedor { get; set; }

        /// <summary>
        /// Obtiene el identificador del comprador
        /// </summary>
        public int IdComprador { get; set; }

        /// <summary>
        /// Obtiene el nombre del comprador
        /// </summary>
        public string NombreComprador { get; set; }

        /// <summary>
        /// Obtiene el apelllido pateerno del comprado
        /// </summary>
        public string ApellidoPaternoComprado { get; set; }

        /// <summary>
        /// Obtiene el apellido materno del comprador si tiene
        /// </summary>
        public string? ApellidoMaternoComprador { get; set; }

        /// <summary>
        /// Obtiene el valor del estatus del pedido
        /// </summary>
        public string Estatus { get; set; }

        /// <summary>
        /// Obtiene el identificador del estatus del pedido
        /// </summary>
        public int IdEstatus { get; set; }

        /// <summary>
        /// Obtiene la fecha del pedido
        /// </summary>
        public DateTime FechaPedido { get; set; }

        /// <summary>
        /// Obtiene la fecha de la entrega del pedido
        /// </summary>
        public DateTime FechaEntrega { get; set; }
    }
}
