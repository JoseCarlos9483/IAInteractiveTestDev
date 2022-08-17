using Models.Enum;
using Models.SalesModels;
using Models.ViewModels.Request;

namespace Data.Validations
{
    /// <summary>
    /// Clase para leer y validar los modelos de los metodos SalesDatas.
    /// </summary>
    public static  class ValidationModelSalesData
    {
        /// <summary>
        /// Valida que la informacion venga completa
        /// </summary>
        /// <param name="addSalesRequest"></param>
        /// <returns name="ValidationModels"> La valiacion de del modelo</returns>
        public static ValidationModels ValidateCreateSale(AddSalesRequest addSalesRequest) {

            string message = string.Empty;

            if (addSalesRequest.IdSalesMan == 0) 
                message = $"{message}No se encuentra el vendedor. ";

            if (addSalesRequest.IdProduct == 0)
                message = $"{message}No se encuentra el producto. ";

            if (addSalesRequest.IdBuyer == 0)
                message = $"{message}No se Cuentra el comprador. ";

            if(addSalesRequest.IdStatus != (int)StatusSaleEnum.Pending)
                message = $"{message}Al crear nuevo pedido solo pude tener el estatus de Pending. ";

            if(!string.IsNullOrEmpty(message))
                return new ValidationModels () { Message = message, Succes = false };

            return new ValidationModels();

        }

        /// <summary>
        /// Valida el modelo de la cancelacion 
        /// </summary>
        /// <param name="cancelSaleRequest"></param>
        /// <returns>La validacion del modelo</returns>
        public static ValidationModels ValidateCancelationSales(CancelSaleRequest cancelSaleRequest) {

            string message = string.Empty;
            const int sizePermitted = 250;

            if(cancelSaleRequest.IdSale == 0)
                message = $"{message}No se encuentra el identificador del pedido. ";

            if(cancelSaleRequest.IdStatus != (int)StatusSaleEnum.Canceled)
                message = $"{message}El status del pedido no corresponde al de cancelacion. ";

            if(string.IsNullOrEmpty(cancelSaleRequest.SalesCode))
                message = $"{message}Se requiere el codigo del pedido. ";

            if (string.IsNullOrEmpty(cancelSaleRequest.Justification) || cancelSaleRequest.Justification.Length > sizePermitted)
                message = $"{message}Se debe poner una justificacion y que esta sea menor a 250 caracteres. ";

            if(!string.IsNullOrEmpty(message))
                return new ValidationModels() { Message = message, Succes = false };

            return new ValidationModels();
        }

        /// <summary>
        /// Valida la actulizacion del pedido
        /// </summary>
        /// <param name="updateSalesRequest"></param>
        /// <returns>Valida el modelo para actualizar el pedido</returns>
        public static ValidationModels ValidateUpdateSale(UpdateSalesRequest updateSalesRequest)
        {
            string message = string.Empty;

            if (updateSalesRequest.IdSale == 0)
                message = $"{message}No se encuentra el identificador del pedido. ";

            if(updateSalesRequest.IdProduct == 0)
                message = $"{message}No se encuentra el identificador del producto. ";

            if(updateSalesRequest.IdStatus == (int)StatusSaleEnum.Canceled)
                message = $"{message}Para cancelar el pedido se debe ingresar una justificacion.";

            if (!string.IsNullOrEmpty(message))
                return new ValidationModels() { Message = message, Succes = false };

            return new ValidationModels();
        }
    }
}
