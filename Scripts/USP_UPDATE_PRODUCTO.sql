                                   
 CREATE PROCEDURE [dbo].[USP_UPDATE_PRODUCTO]          
            	
	@Id INT,
	@Nombre VARCHAR(MAX),
	@Precio DECIMAL(9,2),
	@Stock INT
	                                                                               
AS  

BEGIN
			
   --ACTUALIZAR  (U)    

	BEGIN

		BEGIN TRAN
			BEGIN TRY
				BEGIN

					UPDATE [PRODUCTO]
					SET
						Nombre = @Nombre,
						Precio = @Precio,
						Stock = @Stock						
					WHERE
						Id = @Id
		
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
