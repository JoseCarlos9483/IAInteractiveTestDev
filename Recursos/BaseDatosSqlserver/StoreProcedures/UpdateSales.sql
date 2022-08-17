USE [SaleProductsDev]
GO
/****** Object:  StoredProcedure [dbo].[UpdateSales]    Script Date: 17/08/2022 01:55:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****************************** ** 
Nombre: UpdateSales 
Autor: Molina Alarcon Jose Carlos 
Fecha Creacion: 15/08/2022
Fecha Cambio: 15/08/2022
** PR Date Author Description 
** -- -------- ------- ------------------------------------ 
** 1 15/08/2022 Jose Carlos Se actualiza un pedido
*******************************/

CREATE PROCEDURE [dbo].[UpdateSales] 
					@IdSale int,
					@IdProduct int,
					@IdStatus int
AS
  BEGIN TRY

    BEGIN TRANSACTION

	SET NOCOUNT ON; 
		UPDATE [dbo].[Sales]
		   SET [IdProduct] = @IdProduct
			  ,[IdStatus] = @IdStatus
		 WHERE IdSale = @IdSale;
		
	select 1 response;
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