using Dapper;
using DatabaseConnection;
using Entities.Exceptions;
using Entities.POCOEntities;
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
    public class UpdateProductoInteractor: IUpdateProductoInputPort
    {
        readonly Conexion conexion;
        readonly IUpdateProductoOutputPort OutputPort;

        public UpdateProductoInteractor(Conexion conexion, IUpdateProductoOutputPort outputPort)
        {
            this.conexion = new Conexion();
            OutputPort = outputPort;
        }

        //Crear Productos
        public async Task Update(Producto request)
        {

            int response = 0;

            try
            {
                using IDbConnection connection = new SqlConnection(conexion.ConnectionString());

                var parameters = new DynamicParameters();
                parameters.Add("@Id", request.Id);
                parameters.Add("@Nombre", request.Nombre);
                parameters.Add("@Precio", request.Precio);
                parameters.Add("@Stock", request.Stock);

                int result = await connection.ExecuteAsync(sql: "dbo.[USP_UPDATE_PRODUCTO]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                response = parameters.Get<int>("@Id");

            }


            catch (Exception ex)
            {
                throw new GeneralException("Error al actualizar producto.", ex.Message);
            }

            await OutputPort.Handle(response);
        }

    }
}
