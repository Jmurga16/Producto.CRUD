                                   
 CREATE PROCEDURE [dbo].[USP_CREATE_PRODUCTO]          
            
	
	@Nombre VARCHAR(MAX),
	@Precio DECIMAL(9,2),
	@Stock INT,

	@Id INT OUTPUT
	                                                                               
AS  

	DECLARE @FechaRegistro DATETIME
	SET @FechaRegistro = GETDATE()

BEGIN
			
   --INSERTAR  (C)    

	BEGIN

		BEGIN TRAN
			BEGIN TRY
				BEGIN

					INSERT INTO [PRODUCTO]
							(Nombre, Precio, Stock, FechaRegistro)
					VALUES	(@Nombre,@Precio,@Stock,@FechaRegistro)

					SET @Id = SCOPE_IDENTITY()
					
					SELECT @Id
		
				END
				COMMIT TRAN
			END TRY
			BEGIN CATCH
				ROLLBACK TRAN
				PRINT ERROR_MESSAGE();					
				SELECT 0;
			END CATCH
					
	END   
	   
END
