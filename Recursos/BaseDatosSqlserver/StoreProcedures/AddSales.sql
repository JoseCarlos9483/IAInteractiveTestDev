USE [SaleProductsDev]
GO
/****** Object:  StoredProcedure [dbo].[AddSale]    Script Date: 17/08/2022 01:53:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****************************** ** 
Nombre: AddSale 
Autor: Molina Alarcon Jose Carlos 
Fecha Creacion: 15/08/2022
Fecha Cambio: 15/08/2022
** PR Date Author Description 
** -- -------- ------- ------------------------------------ 
** 1 15/08/2022 Jose Carlos Se crear store procedure para agregar una venta
*******************************/

CREATE PROCEDURE [dbo].[AddSale] 
					@IdProduct int,
					@IdSalesMan int,
					@IdBuyer int,
					@IdStatus int
AS
  BEGIN TRY
  DECLARE @SalesCode varchar(250);
    BEGIN TRANSACTION

	SET NOCOUNT ON; 

	--Se obtiene el codigo de pedido disponible
	SET @SalesCode = (SELECT top 1 SalesCode FROM SalesCodes where Active  = 1 and takeCode = 0);
	
	--Se actualiza el codigo de pedido para apartarlo
	update SalesCodes 
	set TakeCode = 1, 
		DateTakeCode =  GETDATE()
	where SalesCode =  @SalesCode;

	--Se agrega  el pedido
		INSERT INTO [dbo].[Sales]
			   ([SalesCode]
			   ,[IdProduct]
			   ,[IdSalesMan]
			   ,[IdBuyer]
			   ,[IdStatus]
			   ,[PurchaseDate]
			   ,[DeadLineDate])
		 VALUES
			   (@SalesCode,
			   @IdProduct, 
			   @IdSalesMan,
			   @IdBuyer,
			   @IdStatus,
			   GETDATE(),
			   GETDATE() + 5);
	--Se descuenta el producto del stock
	update [SaleProductsDev].[dbo].[Products]
	set [Stock] =  [Stock] - 1
	where [IdProduct] = @IdProduct and [Active] = 1;

	--Retorna el pedido
	SELECT [IdSale]
      ,[SalesCode]
      ,[Sales].[IdProduct]
	  ,Products.Price
	  ,Products.Stock
      ,[IdSalesMan]
      ,[IdBuyer]
      ,[IdStatus]
      ,[PurchaseDate]
      ,[DeadLineDate]
  FROM [SaleProductsDev].[dbo].[Sales]
  inner join [dbo].[Products]
  on Products.IdProduct = Sales.IdProduct
  where [IdSale] = SCOPE_IDENTITY();

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