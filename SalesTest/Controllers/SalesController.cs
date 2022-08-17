using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Enum;
using Models.Interfaces.Data;
using Models.ViewModels.Request;
using Models.ViewModels.Response;
using SalesTest.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesTest.Controllers
{
    /// <summary>
    /// Api para ventas
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        /// <summary>
        /// Variables de inyeccion
        /// </summary>
        private ISalesData _salesData;
        MailService _mailService;

        /// <summary>
        /// Construcctor con las dependencias
        /// </summary>
        /// <param name="salesData"></param>
        public SalesController(ISalesData salesData, MailService mailService)
        {
            _salesData = salesData;
            this._mailService = mailService;
        }

        /// <summary>
        /// Crear un nuevo pedido
        /// </summary>
        /// <param name="addSalesRequest"></param>
        /// <returns>Un pedido creado</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ResponseGeneric<AddSalesResponse>>> Post(AddSalesRequest addSalesRequest)
        {
            if (addSalesRequest == null)
            {
                return BadRequest();
            }

            var response =   await _salesData.CreateSaleAsync(addSalesRequest);

            //if (response.Response.Stock < (int)Stock.limit) {
            //    this._mailService.SendEmail(response.Response.IdProduct, response.Response.Stock);
            //}
            return response;    
        }


        /// <summary>
        /// Cancela un pedido 
        /// </summary>
        /// <param name="id">Identificador del pedido</param>
        /// <param name="cancelSaleRequest">I</param>
        /// <returns>Si el pedido se elimino o no</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ResponseGeneric<CanceledSaleResponse>>> Delete(int id, [FromBody] CancelSaleRequest cancelSaleRequest) {

            if (id < 1 || cancelSaleRequest == null) {
                return BadRequest();
            }
            cancelSaleRequest.IdSale = id;
            return await _salesData.DeleteSalesAsycn(cancelSaleRequest); ;
        }

        /// <summary>
        /// Actualiza un pedido
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateSalesRequest"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ResponseGeneric<UpdateSalesResponse>>> Update(int id, [FromBody] UpdateSalesRequest updateSalesRequest) {
            
            if (id < 1 || updateSalesRequest == null)
            {
                return BadRequest();
            }
            updateSalesRequest.IdSale = id;
            return await _salesData.UpdateSaleAsync(updateSalesRequest);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponseGeneric<List<GetSalesResponse>>>> Get(int id, [FromBody] GetSalesRequest getSalesRequest) {
            if (id < 1 || getSalesRequest == null)
            {
                return NotFound();
            }
            
            if (string.IsNullOrEmpty(getSalesRequest.SalesCode) && getSalesRequest.IdStatus == 0)
            {
                getSalesRequest.IdSales = id;
            }
            return await _salesData.GetSalesAsync(getSalesRequest);

        }
    }
}
