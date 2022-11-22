using Dapper;
using DatabaseConnection;
using Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCasesPorts.FormProducto;

namespace UseCases.FormProducto
{
    public class DeleteProductoInteractor : IDeleteProductoInputPort
    {
        readonly Conexion conexion;
        readonly IDeleteProductoOutputPort OutputPort;

        public DeleteProductoInteractor(Conexion conexion, IDeleteProductoOutputPort outputPort)
        {
            this.conexion = new Conexion();
            OutputPort = outputPort;
        }

        //Crear Productos
        public async Task Delete(int id)
        {

            int response = 0;

            try
            {
                using IDbConnection connection = new SqlConnection(conexion.ConnectionString());

                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);


                response = await connection.ExecuteAsync(sql: "dbo.[USP_DELETE_PRODUCTO]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

            }


            catch (Exception ex)
            {
                throw new GeneralException("Error al eliminar producto.", ex.Message);
            }

            await OutputPort.Handle(response);
        }

    }
}
