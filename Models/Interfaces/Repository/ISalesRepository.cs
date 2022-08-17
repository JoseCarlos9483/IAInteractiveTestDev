using Models.ViewModels.Request;
using Models.ViewModels.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Models.Interfaces.Repository
{
    /// <summary>
    /// Interfaz para los metodo del repositorio de los pedidos
    /// </summary>
    public interface ISalesRepository
    {
        /// <summary>
        /// Crea un nuevo pedido
        /// </summary>
        /// <param name="addSalesRequest"></param>
        /// <returns>Un pedido nuevo</returns>
        Task<AddSalesResponse> CreateSaleAsync (AddSalesRequest addSalesRequest);

        /// <summary>
        /// Cancela un pedido
        /// </summary>
        /// <param name="cancelSaleRequest"></param>
        /// <returns>Respuesta de la cancelacion del pedido</returns>
        Task<CanceledSaleResponse> DeleteSaleAsync(CancelSaleRequest cancelSaleRequest);

        /// <summary>
        /// Actualiza un pedido
        /// </summary>
        /// <param name="updateSalesRequest"></param>
        /// <returns>Respuesta de la actualizacion de un pedido</returns>
        Task<UpdateSalesResponse> UpdateSaleAsync(UpdateSalesRequest updateSalesRequest);

        /// <summary>
        /// Obtiene los pedidos
        /// </summary>
        /// <param name="getSalesRequest">Obtiene los pedidos puede ser por estatus, id del pedido o codigo del pedido</param>
        /// <returns>Retorna un resumen de los pedidos</returns>
        Task<List<GetSalesResponse>> GetSalesAsync(GetSalesRequest getSalesRequest);
        
    }
}
