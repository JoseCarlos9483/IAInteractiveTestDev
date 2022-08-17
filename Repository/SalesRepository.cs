using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Models.Interfaces.Repository;
using Models.ViewModels.Request;
using Models.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    /// <summary>
    /// Repositorio para conexiones ala base para operacion para los pedidos
    /// </summary>
    public class SalesRepository : ISalesRepository
    {
        /// <summary>
        /// Variable para obtener la conexion.
        /// </summary>
        private readonly SalesDbContext _context;

        /// <summary>
        /// Constructor con las dependencias
        /// </summary>
        /// <param name="context"></param>
        public SalesRepository(SalesDbContext context)
        {
            this._context = context;
        }

       /// <summary>
       /// Crea un nuevo pedido
       /// </summary>
       /// <param name="addSalesRequest">Valores para crear un nuevo pedido</param>
       /// <returns>Un nuevo pedido</returns>
        public async Task<AddSalesResponse> CreateSaleAsync(AddSalesRequest addSalesRequest) {

            AddSalesResponse response = new AddSalesResponse();
            var connection = (SqlConnection)_context.Database.GetDbConnection();
            var command = connection.CreateCommand();

            connection.Open();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "AddSale";
            command.Parameters.Add("@IdProduct", System.Data.SqlDbType.Int).Value = addSalesRequest.IdProduct;
            command.Parameters.Add("@IdSalesMan", System.Data.SqlDbType.Int).Value = addSalesRequest.IdSalesMan;
            command.Parameters.Add("@IdBuyer", System.Data.SqlDbType.Int).Value = addSalesRequest.IdBuyer;
            command.Parameters.Add("@IdStatus", System.Data.SqlDbType.Int).Value = addSalesRequest.IdStatus;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                response.IdSale = (int)reader["IdSale"];
                response.SalesCode = (string)reader["SalesCode"];
                response.IdProduct = (int)reader["IdProduct"];
                response.Price = (decimal)reader["Price"];
                response.Stock = (int)reader["Stock"];
                response.IdSalesMan = (int)reader["IdSalesMan"];
                response.IdBuyer = (int)reader["IdBuyer"];
                response.IdStatus = (int)reader["IdStatus"];
                response.PurchaseDate = (DateTime)reader["PurchaseDate"];
                response.DeadLineDate = (DateTime)reader["DeadLineDate"];
            }
            connection.Close();

            return response;
        }

        /// <summary>
        /// Cancela el pedido
        /// </summary>
        /// <param name="cancelSaleRequest"></param>
        /// <returns>Retorna 1 si se cancelo o 0 si no se cancelo</returns>
        public async Task<CanceledSaleResponse> DeleteSaleAsync(CancelSaleRequest cancelSaleRequest)
        {
            int response = 0;
            var connection = (SqlConnection)_context.Database.GetDbConnection();
            var command = connection.CreateCommand();

            connection.Open();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "CancelSales";
            command.Parameters.Add("@IdSale", System.Data.SqlDbType.Int).Value = cancelSaleRequest.IdSale;
            command.Parameters.Add("@IdStatus", System.Data.SqlDbType.Int).Value=cancelSaleRequest.IdStatus;
            command.Parameters.Add("@SalesCode", System.Data.SqlDbType.VarChar).Value = cancelSaleRequest.SalesCode;
            command.Parameters.Add("@Justification", System.Data.SqlDbType.VarChar).Value = cancelSaleRequest.Justification;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                response = (int)reader["response"];
            }

            connection.Close();
            return new CanceledSaleResponse() { Canceled = response };
        }

        /// <summary>
        /// Obtienes los pedidos segun los criterios
        /// </summary>
        /// <param name="getSalesRequest">Obtiene los pedidos puede ser por estatus, id del pedido o codigo del pedido</param>
        /// <returns>Retorna un resumen de los pedidos</returns>
        public async Task<List<GetSalesResponse>> GetSalesAsync(GetSalesRequest getSalesRequest)
        {
            List<GetSalesResponse> response = new List<GetSalesResponse>();

            var connection = (SqlConnection)_context.Database.GetDbConnection();
            var command = connection.CreateCommand();

            connection.Open();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "GetSales";
            command.Parameters.Add("@IdSale", System.Data.SqlDbType.Int).Value = getSalesRequest.IdSales;
            command.Parameters.Add("@IdStatus", System.Data.SqlDbType.Int).Value = getSalesRequest.IdStatus;
            command.Parameters.Add("@SalesCode", System.Data.SqlDbType.VarChar).Value = getSalesRequest.SalesCode;

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                GetSalesResponse sale = new GetSalesResponse
                {
                    IdPedido = (int)reader["IdPedido"],
                    CodigoPedido = (string)reader["CodigoPedido"],
                    NombreProducto = (string)reader["NombreProducto"],
                    IdProducto = (int)reader["IdProducto"],
                    IdVendedor = (int)reader["IdVendedor"],
                    NombreVendedor = (string)reader["NombreVendedor"],
                    ApellidoPaternoVendedor = (string)reader["ApellidoPaternoVendedor"],
                    ApellidoMaternoVendedor = (string)reader["ApellidoMaternoVendedor"],
                    IdComprador = (int)reader["IdComprador"],
                    NombreComprador = (string)reader["NombreComprador"],
                    ApellidoPaternoComprado = (string)reader["ApellidoPaternoComprado"],
                    ApellidoMaternoComprador = (string)reader["ApellidoMaternoComprador"],
                    Estatus = (string)reader["Estatus"],
                    IdEstatus = (int)reader["IdEstatus"],
                    FechaPedido = (DateTime)reader["FechaPedido"],
                    FechaEntrega = (DateTime)reader["FechaEntrega"]
                };
                
                response.Add(sale); 
            }

            connection.Close();

            return response;
        }

        /// <summary>
        /// Actualiza un pedido
        /// </summary>
        /// <param name="updateSalesRequest"></param>
        /// <returns></returns>
        public async Task<UpdateSalesResponse> UpdateSaleAsync(UpdateSalesRequest updateSalesRequest)
        {
            int response = 0;
            var connection = (SqlConnection)_context.Database.GetDbConnection();
            var command = connection.CreateCommand();

            connection.Open();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "UpdateSales";
            command.Parameters.Add("@IdSale", System.Data.SqlDbType.Int).Value = updateSalesRequest.IdSale;
            command.Parameters.Add("@IdProduct", System.Data.SqlDbType.Int).Value = updateSalesRequest.IdProduct;
            command.Parameters.Add("@IdStatus", System.Data.SqlDbType.Int).Value = updateSalesRequest.IdStatus;

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                response = (int)reader["response"];
            }

            connection.Close();

            return new UpdateSalesResponse() { Update = response };

        }
    }
}
