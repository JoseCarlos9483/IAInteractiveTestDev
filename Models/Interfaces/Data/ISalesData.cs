using Models.ViewModels.Request;
using Models.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces.Data
{
    /// <summary>
    /// Interfaz para metodos en el procesamiento de informacio s
    /// </summary>
    public  interface ISalesData
    {
        /// <summary>
        /// Crea un pedido con los datos que le pasan en el modelo
        /// </summary>
        /// <param name="addSalesRequest"></param>
        /// <returns>Retorna un pedido creado</returns>
        Task<ResponseGeneric<AddSalesResponse>> CreateSaleAsync(AddSalesRequest addSalesRequest);

        /// <summary>
        /// Cancela un pedido
        /// </summary>
        /// <param name="cancelSaleRequest"></param>
        /// <returns>Un response con la respuesta de cancelacion</returns>
        Task<ResponseGeneric<CanceledSaleResponse>> DeleteSalesAsycn(CancelSaleRequest cancelSaleRequest);

        /// <summary>
        /// Actualiza el pedido
        /// </summary>
        /// <param name="updateSalesRequest"></param>
        /// <returns>Retorna si el pedido se actulizo o no</returns>
        Task<ResponseGeneric<UpdateSalesResponse>> UpdateSaleAsync(UpdateSalesRequest updateSalesRequest);

        /// <summary>
        /// Obtienes los pedidos segun los criterios
        /// </summary>
        /// <param name="getSalesRequest">Obtiene los pedidos puede ser por estatus, id del pedido o codigo del pedido</param>
        /// <returns>Retorna un resumen de los pedidos</returns>
        Task<ResponseGeneric<List<GetSalesResponse>>> GetSalesAsync(GetSalesRequest getSalesRequest);
    }
}
