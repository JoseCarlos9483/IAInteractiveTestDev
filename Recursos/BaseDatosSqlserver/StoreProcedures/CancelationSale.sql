USE [SaleProductsDev]
GO
/****** Object:  StoredProcedure [dbo].[CancelSales]    Script Date: 17/08/2022 01:54:17 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****************************** ** 
Nombre: CancelSales 
Autor: Molina Alarcon Jose Carlos 
Fecha Creacion: 15/08/2022
Fecha Cambio: 15/08/2022
** PR Date Author Description 
** -- -------- ------- ------------------------------------ 
** 1 15/08/2022 Jose Carlos Se cancela un pedido
*******************************/

CREATE PROCEDURE [dbo].[CancelSales] 
					@IdSale int,
					@IdStatus int,
					@SalesCode varchar(250),
					@Justification varchar(250)
AS
  BEGIN TRY

  DECLARE @IdProducto int;

    BEGIN TRANSACTION

	IF(@SalesCode is not null and @Justification is not null)
	BEGIN
		SET NOCOUNT ON; 
			--Actualiza el estatus en el pedido
			UPDATE [dbo].[Sales]
			   SET [IdStatus] = @IdStatus
			 WHERE IdSale = @IdSale;

			--Desactiva el codigo para que no pueda ser usado en un nuevo pedido
			 UPDATE [SalesCodes]
			 SET JustificationCancelation = @Justification,
				DownDate = GETDATE(),
				Active = 0
			where SalesCode = @SalesCode;

			 --Obtiene el producto para agregarlo al stock
			 set @IdProducto = (select IdProduct from [dbo].[Sales] WHERE IdSale = @IdSale);

			 --Agrega al stock el producto que se cancelo
			update [SaleProductsDev].[dbo].[Products]
			set [Stock] =  [Stock] + 1
			where [IdProduct] = @IdProducto and [Active] = 1;

		select 1 as response;
			
	END

	ELSE
	BEGIN
	 select 0 as response;
	END

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