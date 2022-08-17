using Data.Validations;
using Models.Interfaces.Data;
using Models.Interfaces.Repository;
using Models.SalesModels;
using Models.ViewModels.Request;
using Models.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    /// <summary>
    /// Modelo donde se procesan y valida datos
    /// </summary>
    public  class SalesData : ISalesData
    {
        /// <summary>
        /// Variables para inyeccion
        /// </summary>
        private ISalesRepository _salesRepository;

        /// <summary>
        /// Construcctor con las inyeccion
        /// </summary>
        /// <param name="salesData"></param>
        public SalesData(ISalesRepository salesData)
        {
            this._salesRepository = salesData;
        }

        /// <summary>
        /// Crea un nuevo pedido
        /// </summary>
        /// <param name="addSalesRequest"></param>
        /// <returns>El pedido creado</returns>
        public async Task<ResponseGeneric<AddSalesResponse>> CreateSaleAsync(AddSalesRequest addSalesRequest)
        {
            try
            {
                ValidationModels validation = ValidationModelSalesData.ValidateCreateSale(addSalesRequest);
                
                if(!validation.Succes)
                    return new ResponseGeneric<AddSalesResponse>() {
                        Success = false,
                        Error = new Error
                        {
                            Message = validation.Message,
                            MessageFront = validation.Message,
                            Name = $"{nameof(CreateSaleAsync)}"
                        }
                    };

                var response = await _salesRepository.CreateSaleAsync(addSalesRequest);

                return new ResponseGeneric<AddSalesResponse>() { Response = response };
            }
            catch (Exception ex)
            {

                return new ResponseGeneric<AddSalesResponse>() { 
                    Success = false, 
                    Error = new Error { 
                        Code = Convert.ToString(ex.HResult),
                        Message = ex.Message,
                        MessageFront = "Ocurrio un error al crear el pedido. Contacte al administrador",
                        Name = $"{nameof(CreateSaleAsync)}"

                    } 
                };
            }
        }

        /// <summary>
        /// Cancela un pedido
        /// </summary>
        /// <param name="cancelSaleRequest"></param>
        /// <returns>retorna un modelo con la respuesta de cancelacion</returns>
        public async Task<ResponseGeneric<CanceledSaleResponse>> DeleteSalesAsycn(CancelSaleRequest cancelSaleRequest)
        {
            try
            {
                var validation = ValidationModelSalesData.ValidateCancelationSales(cancelSaleRequest);
                if (!validation.Succes)
                    return new ResponseGeneric<CanceledSaleResponse>()
                    {
                        Success = false,
                        Error = new Error
                        {
                            Message = validation.Message,
                            MessageFront = validation.Message,
                            Name = $"{nameof(DeleteSalesAsycn)}"

                        }
                    };

                var response = await _salesRepository.DeleteSaleAsync(cancelSaleRequest);

                return new ResponseGeneric<CanceledSaleResponse> { Response = response };   

            }
            catch (Exception ex)
            {

                return new ResponseGeneric<CanceledSaleResponse>()
                {
                    Success = false,
                    Error = new Error
                    {
                        Code = Convert.ToString(ex.HResult),
                        Message = ex.Message,
                        MessageFront = "Ocurrio un error al cancelar el pedido. Contacte al administrador",
                        Name = $"{nameof(DeleteSalesAsycn)}"

                    }
                };
            }
        }

        /// <summary>
        /// Obtienes los pedidos segun los criterios
        /// </summary>
        /// <param name="getSalesRequest">Obtiene los pedidos puede ser por estatus, id del pedido o codigo del pedido</param>
        /// <returns>Retorna un resumen de los pedidos</returns>
        public async Task<ResponseGeneric<List<GetSalesResponse>>> GetSalesAsync(GetSalesRequest getSalesRequest)
        {
            try
            {
                List<GetSalesResponse> response = await _salesRepository.GetSalesAsync(getSalesRequest);

                return new ResponseGeneric<List<GetSalesResponse>> { Response = response};
            }
            catch (Exception ex)
            {

                return new ResponseGeneric<List<GetSalesResponse>>()
                {
                    Success = false,
                    Error = new Error
                    {
                        Code = Convert.ToString(ex.HResult),
                        Message = ex.Message,
                        MessageFront = "Ocurrio un error al obtener los pedidos. Contacte al administrador",
                        Name = $"{nameof(GetSalesAsync)}"

                    }
                };
            }
        }

        /// <summary>
        /// Actuliza un pedido
        /// </summary>
        /// <param name="updateSalesRequest"></param>
        /// <returns>Retorna si se actualizo el pedido o no</returns>
        public async Task<ResponseGeneric<UpdateSalesResponse>> UpdateSaleAsync(UpdateSalesRequest updateSalesRequest)
        {
            try
            {
                var validation = ValidationModelSalesData.ValidateUpdateSale(updateSalesRequest);
                if (!validation.Succes)
                    return new ResponseGeneric<UpdateSalesResponse>()
                    {
                        Success = false,
                        Error = new Error
                        {
                            Message = validation.Message,
                            MessageFront = validation.Message,
                            Name = $"{nameof(UpdateSaleAsync)}"

                        }
                    };
                var response =  await _salesRepository.UpdateSaleAsync(updateSalesRequest);

                return new ResponseGeneric<UpdateSalesResponse>() { Response = response };
            }
            catch (Exception ex )
            {

                return new ResponseGeneric<UpdateSalesResponse>()
                {
                    Success = false,
                    Error = new Error
                    {
                        Code = Convert.ToString(ex.HResult),
                        Message = ex.Message,
                        MessageFront = "Ocurrio un error al actualizar el pedido. Contacte al administrador",
                        Name = $"{nameof(UpdateSaleAsync)}"

                    }
                };
            }
        }
    }
}
