USE [SaleProductsDev]
GO
/****** Object:  StoredProcedure [dbo].[GetSales]    Script Date: 17/08/2022 01:54:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****************************** ** 
Nombre: GetSales 
Autor: Molina Alarcon Jose Carlos 
Fecha Creacion: 15/08/2022
Fecha Cambio: 15/08/2022
** PR Date Author Description 
** -- -------- ------- ------------------------------------ 
** 1 15/08/2022 Jose Carlos Se crear store procedure para obtener los pedidos por id o por status o por codigo de pedido
*******************************/

CREATE PROCEDURE [dbo].[GetSales] 					
					@IdSale int = 0,
					@IdStatus int = 0,
					@SalesCode varchar(250)= NULL
AS
  BEGIN TRY
    BEGIN TRANSACTION

	SET NOCOUNT ON; 

	--Realiza la consulta para obtener el resumen del pedido
	SELECT  
		s.[IdSale] IdPedido
      ,s.[SalesCode] CodigoPedido
	  ,p.ProductName NombreProducto
	  ,p.[IdProduct] IdProducto
      ,man.[IdSalesMan] IdVendedor
	  ,man.NameSaleMan NombreVendedor
	  ,man.LastName ApellidoPaternoVendedor
	  ,man.MotherLastName ApellidoMaternoVendedor
      ,b.[IdBuyer] IdComprador
	  ,b.NameBuyer NombreComprador
	  ,b.LastName ApellidoPaternoComprado
	  ,b.MotherLastName ApellidoMaternoComprador
      ,st.NameStatus Estatus
	  ,st.IdStatus IdEstatus
      ,s.[PurchaseDate] FechaPedido
      ,s. [DeadLineDate] FechaEntrega
	FROM [SaleProductsDev].[dbo].[Sales] as s
	  inner join Products as p
	  on p.IdProduct = s.IdProduct
	  inner join StatusSales st
	  on st.IdStatus = s.IdStatus
	  inner join SalesMans as man
	  on man.IdSalesMan = s.IdSalesMan
	  inner join [dbo].[Buyers] b
	  on b.IdBuyer = s.IdBuyer
	where ((@IdSale <> 0  and @IdStatus = 0 and @SalesCode = '' ) and s.IdSale = @IdSale) 
		or ((@IdSale = 0  and @IdStatus <> 0 and @SalesCode = '') and s.IdStatus = @IdStatus) 
		or ((@IdSale = 0  and @IdStatus = 0 and @SalesCode <> '') and s.SalesCode = @SalesCode) 
		or  ((@IdSale <> 0  and @IdStatus <> 0 and @SalesCode <> '') and s.IdSale = @IdSale and s.IdStatus = @IdStatus and s.SalesCode = @SalesCode);


    COMMIT TRANSACTION
  END TRY
  BEGIN CATCH
     DECLARE @ErrorMessage NVARCHAR(4000);
    DECLARE @ErrorSeverity INT;
    DECLARE @ErrorState INT;

    SELECT
        @ErrorMessage = ERROR_MESSAGE(),
        @ErrorSeverity = ERROR_SEVERITY(),
        @ErrorState = ERROR_STATE();
	ROLLBACK TRANSACTION 

    RAISERROR (@ErrorMessage, 
               @ErrorSeverity, 
               @ErrorState 
               );
  END CATCH