                                   
 CREATE PROCEDURE [dbo].[USP_DELETE_PRODUCTO]          
            	
	@Id INT
	                                                                               
AS  

BEGIN
			
   --ELIMINAR  (D)    

	BEGIN

		BEGIN TRAN
			BEGIN TRY
				BEGIN

					DELETE [PRODUCTO]
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
