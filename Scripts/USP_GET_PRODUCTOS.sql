                                   
 CREATE PROCEDURE [dbo].[USP_GET_PRODUCTOS]
            
	@nOpcion INT = 0,   
	@IdProducto INT = 0
                                                                                   
AS     

BEGIN
		
  IF @nOpcion = 1  --LISTAR TODO
	BEGIN
		SELECT * FROM Producto
	END
	   
	   
	ELSE IF @nOpcion = 2  -- LISTAR POR ID                                                        
	BEGIN

		SELECT * FROM Producto 
		WHERE
			Id = @IdProducto
		                                    
	END;                            

 
END

